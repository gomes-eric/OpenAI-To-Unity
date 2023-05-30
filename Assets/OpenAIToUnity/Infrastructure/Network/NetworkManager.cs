using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
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
                Authorization = new AuthenticationHeaderValue("Bearer", OpenAIConstants.ApiKey),
                Accept = { new MediaTypeWithQualityHeaderValue("application/json") }
            },
            Timeout = TimeSpan.FromSeconds(OpenAIConstants.Timeout)
        };

        private static Uri BuildQueryUri<T>(string endpoint, T request)
        {
            var uriBuilder = new UriBuilder(endpoint);

            if (request != null)
            {
                var requestProperties = request.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.GetValue(request) != null)
                    .ToArray();
                var queryParams = new Dictionary<string, string>();

                foreach (var property in requestProperties)
                {
                    var jsonPropertyAttribute = property.GetCustomAttribute<JsonPropertyAttribute>();

                    if (jsonPropertyAttribute == null) continue;

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

        private static Tuple<Uri, string> BuildBodyUri<T>(string endpoint, T request)
        {
            var uriBuilder = new UriBuilder(endpoint);
            var requestBody = new JObject();

            if (request != null)
            {
                var requestProperties = request.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.GetValue(request) != null)
                    .ToArray();

                foreach (var property in requestProperties)
                {
                    var jsonPropertyAttribute = property.GetCustomAttribute<JsonPropertyAttribute>();

                    if (jsonPropertyAttribute == null) continue;

                    var uriKey = WebUtility.UrlEncode($"{{{jsonPropertyAttribute.PropertyName}}}");
                    var bodyKey = jsonPropertyAttribute.PropertyName;

                    if (uriKey != null && uriBuilder.Path.Contains(uriKey))
                    {
                        uriBuilder.Path = uriBuilder.Path.Replace(uriKey, WebUtility.UrlEncode(property.GetValue(request).ToString()));
                    }
                    else if (bodyKey != null)
                    {
                        requestBody[bodyKey] = JToken.FromObject(property.GetValue(request));
                    }
                }
            }

            return new Tuple<Uri, string>(uriBuilder.Uri, requestBody.ToString());
        }

        public static async Task GetRequest<T1, T2>(string endpoint, T1 request, Action<T2> onSuccessCallback, Action<Error> onFailureCallback)
        {
            try
            {
                var queryUri = BuildQueryUri(endpoint, request);
                var response = await HttpClient.GetAsync(queryUri);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    onSuccessCallback.Invoke(JsonConvert.DeserializeObject<T2>(content));
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<Error>(JObject.Parse(content)["error"]!.ToString())!;

                    error.HttpError = response.StatusCode.ToString();

                    onFailureCallback.Invoke(error);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public static async Task PostRequest<T1, T2>(string endpoint, T1 request, Action<T2> onSuccessCallback, Action<Error> onFailureCallback)
        {
            try
            {
                var bodyUri = BuildBodyUri(endpoint, request);
                var response = await HttpClient.PostAsync(bodyUri.Item1, new StringContent(bodyUri.Item2));
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    onSuccessCallback.Invoke(JsonConvert.DeserializeObject<T2>(content));
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<Error>(JObject.Parse(content)["error"]!.ToString())!;

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
                var response = await HttpClient.DeleteAsync(queryUri);
                var content = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    onSuccessCallback.Invoke(JsonConvert.DeserializeObject<T2>(content));
                }
                else
                {
                    var error = JsonConvert.DeserializeObject<Error>(JObject.Parse(content)["error"]!.ToString())!;

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