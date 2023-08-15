using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Responses.Error;
using OpenAIToUnity.Domain.Utils;
using UnityEngine;
using UnityEngine.Networking;

namespace OpenAIToUnity.Infrastructure.Network
{
    public class NetworkManager
    {
        public NetworkManager(Authentication authentication)
        {
            Authentication = authentication;
        }

        private JsonSerializer JsonSerializer { get; } = new()
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        private Authentication Authentication { get; }

        private Uri BuildQueryUri<T>(string endpoint, T request)
        {
            var uriBuilder = new UriBuilder(endpoint);

            if (request != null)
            {
                var requestProperties = request.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.GetValue(request) != null)
                    .Select(p => (Property: p, Attribute: p.GetCustomAttribute<JsonPropertyAttribute>()))
                    .Where(x => x.Attribute != null)
                    .ToList();

                var queryParams = new Dictionary<string, string>();

                foreach (var (property, jsonPropertyAttribute) in requestProperties)
                {
                    var uriKey = WebUtility.UrlEncode($"{{{jsonPropertyAttribute.PropertyName}}}");
                    var queryKey = WebUtility.UrlEncode(jsonPropertyAttribute.PropertyName);
                    var propertyValue = property.GetValue(request);
                    var value = propertyValue switch
                    {
                        Enum _ => WebUtility.UrlEncode(JToken.FromObject(propertyValue, JsonSerializer).ToString()),
                        _ => WebUtility.UrlEncode(propertyValue.ToString())
                    };

                    if (uriKey != null && uriBuilder.Path.Contains(uriKey))
                        uriBuilder.Path = uriBuilder.Path.Replace(uriKey, value);
                    else if (queryKey != null) queryParams.Add(queryKey, value);
                }

                uriBuilder.Query = string.Join("&", queryParams.Select(x => $"{x.Key}={x.Value}"));
            }

            return uriBuilder.Uri;
        }

        private (Uri, string) BuildJsonBodyUri<T>(string endpoint, T request)
        {
            var uriBuilder = new UriBuilder(endpoint);
            var requestBody = new JObject();

            if (request != null)
            {
                var requestProperties = request.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.GetValue(request) != null)
                    .Select(p => (Property: p, Attribute: p.GetCustomAttribute<JsonPropertyAttribute>()))
                    .Where(x => x.Attribute != null)
                    .ToList();

                foreach (var (property, jsonPropertyAttribute) in requestProperties)
                {
                    var uriKey = WebUtility.UrlEncode($"{{{jsonPropertyAttribute.PropertyName}}}");
                    var bodyKey = jsonPropertyAttribute.PropertyName;

                    if (uriKey != null && uriBuilder.Path.Contains(uriKey))
                        uriBuilder.Path = uriBuilder.Path.Replace(uriKey, WebUtility.UrlEncode(property.GetValue(request).ToString()));
                    else if (bodyKey != null) requestBody[bodyKey] = JToken.FromObject(property.GetValue(request), JsonSerializer);
                }
            }

            return (uriBuilder.Uri, requestBody.ToString());
        }

        private (Uri, List<IMultipartFormSection>) BuildFormBodyUri<T>(string endpoint, T request)
        {
            var uriBuilder = new UriBuilder(endpoint);
            var requestBody = new List<IMultipartFormSection>();

            if (request != null)
            {
                var requestProperties = request.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.GetValue(request) != null)
                    .Select(p => (Property: p, Attribute: p.GetCustomAttribute<JsonPropertyAttribute>()))
                    .Where(x => x.Attribute != null)
                    .ToList();

                foreach (var (property, jsonPropertyAttribute) in requestProperties)
                {
                    var uriKey = WebUtility.UrlEncode($"{{{jsonPropertyAttribute.PropertyName}}}");
                    var bodyKey = jsonPropertyAttribute.PropertyName;

                    if (uriKey != null && uriBuilder.Path.Contains(uriKey))
                    {
                        uriBuilder.Path = uriBuilder.Path.Replace(uriKey, WebUtility.UrlEncode(property.GetValue(request).ToString()));
                    }
                    else if (bodyKey != null)
                    {
                        var propertyValue = property.GetValue(request);

                        switch (propertyValue)
                        {
                            case Enum _:
                            {
                                var enumValue = JToken.FromObject(propertyValue, JsonSerializer).ToString();

                                requestBody.Add(new MultipartFormDataSection(bodyKey, enumValue));

                                break;
                            }
                            case FileStream fileStream:
                            {
                                if (fileStream.Name != null)
                                {
                                    var fileName = Path.GetFileName(fileStream.Name);
                                    var mediaType = MediaType.GetMediaTypeName(Path.GetExtension(fileStream.Name));

                                    requestBody.Add(new MultipartFormFileSection(bodyKey, File.ReadAllBytes(fileStream.Name), fileName, mediaType));
                                }

                                break;
                            }
                            default:
                            {
                                requestBody.Add(new MultipartFormDataSection(bodyKey, propertyValue.ToString()));

                                break;
                            }
                        }
                    }
                }
            }

            return (uriBuilder.Uri, requestBody);
        }

        private (UnityWebRequest, DownloadHandler) CreateRequest(Uri uri, string method)
        {
            var www = new UnityWebRequest(uri, method);
            var downloadHandler = new DownloadHandlerBuffer();

            www.downloadHandler = downloadHandler;
            www.timeout = OpenAIConstants.Http.SecondsTimeout;

            www.SetRequestHeader(OpenAIConstants.Http.Authorization, $"{OpenAIConstants.Http.Bearer} {Authentication.ApiKey}");
            www.SetRequestHeader(OpenAIConstants.Http.OpenAIOrganization, $"{Authentication.OrganizationId}");
            www.SetRequestHeader(OpenAIConstants.Http.Accept, MediaType.Names.Application.Json);

            return (www, downloadHandler);
        }

        public IEnumerator JsonGetRequest<T1, T2>(string endpoint, T1 request, Action<T2> onSuccessCallback, Action<Error> onFailureCallback)
        {
            var queryUri = BuildQueryUri(endpoint, request);
            var (www, downloadHandler) = CreateRequest(queryUri, UnityWebRequest.kHttpVerbGET);

            using (www)
            using (downloadHandler)
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    onSuccessCallback(JsonConvert.DeserializeObject<T2>(downloadHandler.text));
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<Error>(JObject.Parse(downloadHandler.text)["error"]!.ToString());

                    error.HttpErrorMessage = www.error;
                    error.HttpErrorCode = www.responseCode.ToString();

                    onFailureCallback(error);
                }
            }
        }

        public IEnumerator FileGetRequest<T1>(string endpoint, T1 request, Action<string> onSuccessCallback, Action<Error> onFailureCallback)
        {
            var queryUri = BuildQueryUri(endpoint, request);
            var (www, downloadHandler) = CreateRequest(queryUri, UnityWebRequest.kHttpVerbGET);

            using (www)
            using (downloadHandler)
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    var fileName = www.GetResponseHeader(OpenAIConstants.Http.ContentDisposition).Replace("attachment; filename=", string.Empty).Replace("\"", string.Empty);
                    var fullPath = Path.Combine(Application.persistentDataPath, fileName);

                    Directory.CreateDirectory(Application.persistentDataPath);
                    File.WriteAllBytes(fullPath, downloadHandler.data);

                    onSuccessCallback(fullPath);
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<Error>(JObject.Parse(downloadHandler.text)["error"]!.ToString());

                    error.HttpErrorMessage = www.error;
                    error.HttpErrorCode = www.responseCode.ToString();

                    onFailureCallback(error);
                }
            }
        }

        public IEnumerator JsonPostRequest<T1, T2>(string endpoint, T1 request, Action<T2> onSuccessCallback, Action<Error> onFailureCallback)
        {
            var (queryUri, body) = BuildJsonBodyUri(endpoint, request);
            var (www, downloadHandler) = CreateRequest(queryUri, UnityWebRequest.kHttpVerbPOST);
            var uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(body));

            using (www)
            using (downloadHandler)
            using (uploadHandler)
            {
                uploadHandler.contentType = MediaType.Names.Application.Json;
                www.uploadHandler = uploadHandler;

                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    onSuccessCallback(JsonConvert.DeserializeObject<T2>(downloadHandler.text));
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<Error>(JObject.Parse(downloadHandler.text)["error"]!.ToString());

                    error.HttpErrorMessage = www.error;
                    error.HttpErrorCode = www.responseCode.ToString();

                    onFailureCallback(error);
                }
            }
        }

        public IEnumerator FormPostRequest<T1, T2>(string endpoint, T1 request, Action<T2> onSuccessCallback, Action<Error> onFailureCallback)
        {
            var (queryUri, form) = BuildFormBodyUri(endpoint, request);
            var boundary = UnityWebRequest.GenerateBoundary();
            var (www, downloadHandler) = CreateRequest(queryUri, UnityWebRequest.kHttpVerbPOST);
            var uploadHandler = new UploadHandlerRaw(UnityWebRequest.SerializeFormSections(form, boundary));

            using (www)
            using (downloadHandler)
            using (uploadHandler)
            {
                uploadHandler.contentType = MediaType.Names.Application.Json;
                www.uploadHandler = uploadHandler;

                www.SetRequestHeader(OpenAIConstants.Http.ContentType, $"{MediaType.Names.Multipart.Form}; boundary={Encoding.UTF8.GetString(boundary)}");

                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    onSuccessCallback(JsonConvert.DeserializeObject<T2>(downloadHandler.text));
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<Error>(JObject.Parse(downloadHandler.text)["error"]!.ToString());

                    error.HttpErrorMessage = www.error;
                    error.HttpErrorCode = www.responseCode.ToString();

                    onFailureCallback(error);
                }
            }
        }

        public IEnumerator DeleteRequest<T1, T2>(string endpoint, T1 request, Action<T2> onSuccessCallback, Action<Error> onFailureCallback)
        {
            var queryUri = BuildQueryUri(endpoint, request);
            var (www, downloadHandler) = CreateRequest(queryUri, UnityWebRequest.kHttpVerbDELETE);

            using (www)
            using (downloadHandler)
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    onSuccessCallback(JsonConvert.DeserializeObject<T2>(downloadHandler.text));
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<Error>(JObject.Parse(downloadHandler.text)["error"]!.ToString());

                    error.HttpErrorMessage = www.error;
                    error.HttpErrorCode = www.responseCode.ToString();

                    onFailureCallback(error);
                }
            }
        }
    }
}
