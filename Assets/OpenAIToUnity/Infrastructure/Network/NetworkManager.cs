using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Responses;
using UnityEngine;

namespace OpenAIToUnity.Infrastructure.Network
{
    public static class NetworkManager
    {
        private static readonly HttpClient HttpClient = new()
        {
            DefaultRequestHeaders =
            {
                Authorization = new AuthenticationHeaderValue(OpenAIConstants.AuthenticationScheme, OpenAIConstants.ApiKey),
                Accept = { new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json) }
            },
            Timeout = TimeSpan.FromSeconds(OpenAIConstants.SecondsTimeout)
        };

        private static Uri BuildQueryUri<T>(string endpoint, T request)
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
                    var value = WebUtility.UrlEncode(property.GetValue(request).ToString());

                    if (uriKey != null && uriBuilder.Path.Contains(uriKey))
                    {
                        uriBuilder.Path = uriBuilder.Path.Replace(uriKey, value);
                    }
                    else if (queryKey != null)
                    {
                        queryParams.Add(queryKey, value);
                    }
                }

                if (queryParams.Count > 0)
                {
                    uriBuilder.Query = string.Join("&", queryParams.Select(x => $"{x.Key}={x.Value}"));
                }
            }

            return uriBuilder.Uri;
        }

        private static Tuple<Uri, string> BuildJsonBodyUri<T>(string endpoint, T request)
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

                var jsonSerializer = new JsonSerializer
                {
                    NullValueHandling = NullValueHandling.Ignore
                };

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
                        requestBody[bodyKey] = JToken.FromObject(property.GetValue(request), jsonSerializer);
                    }
                }
            }

            return new Tuple<Uri, string>(uriBuilder.Uri, requestBody.ToString());
        }

        private static Tuple<Uri, MultipartFormDataContent> BuildFormBodyUri<T>(string endpoint, T request)
        {
            var uriBuilder = new UriBuilder(endpoint);
            var requestBody = new MultipartFormDataContent();

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
                            case FileStream fileStream:
                                {
                                    using var fileContent = new ByteArrayContent(File.ReadAllBytes(fileStream.Name))
                                    {
                                        Headers = { ContentType = MediaTypeHeaderValue.Parse(OpenAIConstants.PngMediaType) }
                                    };

                                    requestBody.Add(fileContent, bodyKey, Path.GetFileName(fileStream.Name));

                                    break;
                                }
                            default:
                                requestBody.Add(new StringContent(propertyValue.ToString()), bodyKey);

                                break;
                        }
                    }
                }
            }

            return new Tuple<Uri, MultipartFormDataContent>(uriBuilder.Uri, requestBody);
        }

        public static async Task GetRequest<T1, T2>(string endpoint, T1 request, Action<T2> onSuccessCallback, Action<Error> onFailureCallback)
        {
            try
            {
                var queryUri = BuildQueryUri(endpoint, request);
                var response = await HttpClient.GetAsync(queryUri).ConfigureAwait(false);
                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    onSuccessCallback.Invoke(JsonConvert.DeserializeObject<T2>(responseContent));
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<Error>(JObject.Parse(responseContent)["error"]!.ToString());

                    error.HttpError = response.StatusCode.ToString();

                    onFailureCallback.Invoke(error);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public static async Task JsonPostRequest<T1, T2>(string endpoint, T1 request, Action<T2> onSuccessCallback, Action<Error> onFailureCallback)
        {
            try
            {
                var bodyUri = BuildJsonBodyUri(endpoint, request);
                var requestContent = new StringContent(bodyUri.Item2, Encoding.UTF8, MediaTypeNames.Application.Json);
                var response = await HttpClient.PostAsync(bodyUri.Item1, requestContent).ConfigureAwait(false);
                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    onSuccessCallback.Invoke(JsonConvert.DeserializeObject<T2>(responseContent));
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<Error>(JObject.Parse(responseContent)["error"]!.ToString());

                    error.HttpError = response.StatusCode.ToString();

                    onFailureCallback.Invoke(error);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public static async Task FormPostRequest<T1, T2>(string endpoint, T1 request, Action<T2> onSuccessCallback, Action<Error> onFailureCallback)
        {
            try
            {
                var bodyUri = BuildFormBodyUri(endpoint, request);
                var response = await HttpClient.PostAsync(bodyUri.Item1, bodyUri.Item2).ConfigureAwait(false);
                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    onSuccessCallback.Invoke(JsonConvert.DeserializeObject<T2>(responseContent));
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<Error>(JObject.Parse(responseContent)["error"]!.ToString());

                    error.HttpError = response.StatusCode.ToString();

                    onFailureCallback.Invoke(error);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public static async Task DeleteRequest<T1, T2>(string endpoint, T1 request, Action<T2> onSuccessCallback, Action<Error> onFailureCallback)
        {
            try
            {
                var queryUri = BuildQueryUri(endpoint, request);
                var response = await HttpClient.DeleteAsync(queryUri).ConfigureAwait(false);
                var responseContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    onSuccessCallback.Invoke(JsonConvert.DeserializeObject<T2>(responseContent));
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<Error>(JObject.Parse(responseContent)["error"]!.ToString());

                    error.HttpError = response.StatusCode.ToString();

                    onFailureCallback.Invoke(error);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
