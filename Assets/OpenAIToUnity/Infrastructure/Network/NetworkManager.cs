using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using Data.Constants;
using Data.Interfaces;
using Domain.Entities.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;

namespace Infrastructure.Network
{
    public static class NetworkManager
    {
        /// <summary>
        /// Makes an HTTP GET request to the specified endpoint with optional parameters in the query.
        /// </summary>
        /// <param name="endpoint">The endpoint to be called.</param>
        /// <param name="request">The object containing the optional request parameters.</param>
        /// <param name="onSuccessCallback">The callback to be called in case of success.</param>
        /// <param name="onFailureCallback">The callback to be called in case of failure.</param>
        public static IEnumerator GetRequest<T>(string endpoint, Request request, Action<T> onSuccessCallback, Action<Error> onFailureCallback)
        {
            // Creates the base URI of the endpoint
            UriBuilder uriBuilder = new UriBuilder(endpoint);

            if (request != null)
            {
                // Gets the properties of the request object, ignoring null ones
                PropertyInfo[] requestProperties = request.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.GetValue(request) != null)
                    .ToArray();

                // Creates the dictionary of query string parameters
                Dictionary<string, string> queryParams = new Dictionary<string, string>();

                // Iterate over the properties of the request object
                foreach (PropertyInfo property in requestProperties)
                {
                    // Gets the JSON serialization attribute of the property
                    JsonPropertyAttribute jsonPropertyAttribute = property.GetCustomAttribute<JsonPropertyAttribute>();

                    // Checks if the property has the JSON serialization attribute
                    if (jsonPropertyAttribute != null)
                    {
                        // Creates a placeholder for the property value in the URI
                        string placeholder = WebUtility.UrlEncode($"{{{jsonPropertyAttribute.PropertyName}}}");

                        // Checks if the property is present in the URI as a placeholder
                        if (uriBuilder.Path.Contains(placeholder))
                        {
                            // If it is, replaces the placeholder with the property value in the URI
                            uriBuilder.Path = uriBuilder.Path.Replace(placeholder, WebUtility.UrlEncode(property.GetValue(request).ToString()));
                        }
                        else
                        {
                            // If it isn't, adds the parameter to the query string list
                            queryParams.Add(WebUtility.UrlEncode(jsonPropertyAttribute.PropertyName), WebUtility.UrlEncode(property.GetValue(request).ToString()));
                        }
                    }
                }

                // Concatenates the query string parameters to the URI, if any
                if (queryParams.Count > 0)
                {
                    uriBuilder.Query = string.Join("&", queryParams.Select(x => $"{x.Key}={x.Value}"));
                }
            }

            // Creates the HTTP GET request with the built URI
            using (UnityWebRequest webRequest = new UnityWebRequest(uriBuilder.Uri, UnityWebRequest.kHttpVerbGET))
            {
                // Creates the request handler
                DownloadHandler downloadHandler = new DownloadHandlerBuffer();

                // Sets the request handler
                webRequest.downloadHandler = downloadHandler;

                // Sets the maximum waiting time
                webRequest.timeout = OpenAiConstants.Timeout;

                // Sets the request headers
                webRequest.SetRequestHeader("Content-Type", "application/json");
                webRequest.SetRequestHeader("Authorization", "Bearer " + OpenAiConstants.ApiKey);

                // Sends the request and waits for the response
                yield return webRequest.SendWebRequest();

                // Checks if the request was successful and calls the corresponding callback
                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    // Calls the success callback, passing the response object as a parameter
                    onSuccessCallback.Invoke(JsonConvert.DeserializeObject<T>(downloadHandler.text));
                }
                else
                {
                    Error error = JsonConvert.DeserializeObject<Error>(JObject.Parse(downloadHandler.text)["error"].ToString());

                    error.HttpError = webRequest.error;

                    // Calls the failure callback, passing the request error
                    onFailureCallback.Invoke(error);
                }
            }
        }

        /// <summary>
        /// Makes an HTTP POST request to the specified endpoint with the request body constructed from the properties of the request object.
        /// </summary>
        /// <param name="endpoint">The endpoint to be called.</param>
        /// <param name="request">The request object used to construct the request body.</param>
        /// <param name="onSuccessCallback">The callback to be called on success.</param>
        /// <param name="onFailureCallback">The callback to be called on failure.</param>
        public static IEnumerator PostRequest<T>(string endpoint, Request request, Action<T> onSuccessCallback, Action<Error> onFailureCallback)
        {
            // Creates the base URI of the endpoint
            UriBuilder uriBuilder = new UriBuilder(endpoint);

            // Creates the request body as an empty JSON object
            JObject requestBody = new JObject();

            if (request != null)
            {
                // Gets the properties of the request object, ignoring null ones
                PropertyInfo[] requestProperties = request.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.GetValue(request) != null)
                    .ToArray();

                // Iterate over the properties of the request object
                foreach (PropertyInfo property in requestProperties)
                {
                    // Gets the JSON serialization attribute of the property
                    JsonPropertyAttribute jsonPropertyAttribute = property.GetCustomAttribute<JsonPropertyAttribute>();

                    // Checks if the property has the JSON serialization attribute
                    if (jsonPropertyAttribute != null)
                    {
                        // Creates a placeholder for the property value in the URI
                        string placeholder = WebUtility.UrlEncode($"{{{jsonPropertyAttribute.PropertyName}}}");

                        // Checks if the property is present in the URI as a placeholder
                        if (uriBuilder.Path.Contains(placeholder))
                        {
                            // If it is, replaces the placeholder with the property value in the URI
                            uriBuilder.Path = uriBuilder.Path.Replace(placeholder, WebUtility.UrlEncode(property.GetValue(request).ToString()));
                        }
                        else
                        {
                            // If it isn't, adds the parameter to the query string list
                            requestBody[jsonPropertyAttribute.PropertyName] = JToken.FromObject(property.GetValue(request));
                        }
                    }
                }
            }

            // Creates the HTTP POST request with the constructed URI and request body
            using (UnityWebRequest webRequest = new UnityWebRequest(uriBuilder.Uri, UnityWebRequest.kHttpVerbPOST))
            {
                // Creates the request handlers
                UploadHandlerRaw uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(requestBody.ToString()));
                DownloadHandler downloadHandler = new DownloadHandlerBuffer();

                // Sets the content type of the request to JSON
                uploadHandler.contentType = "application/json";

                // Sets the request handlers
                webRequest.uploadHandler = uploadHandler;
                webRequest.downloadHandler = downloadHandler;

                // Sets the maximum waiting time
                webRequest.timeout = OpenAiConstants.Timeout;

                // Sets the request headers
                webRequest.SetRequestHeader("Content-Type", "application/json");
                webRequest.SetRequestHeader("Authorization", "Bearer " + OpenAiConstants.ApiKey);

                // Sends the request and waits for the response
                yield return webRequest.SendWebRequest();

                // Checks if the request was successful and calls the corresponding callback
                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    // Calls the success callback, passing the response object as a parameter
                    onSuccessCallback.Invoke(JsonConvert.DeserializeObject<T>(downloadHandler.text));
                }
                else
                {
                    Error error = JsonConvert.DeserializeObject<Error>(JObject.Parse(downloadHandler.text)["error"].ToString());

                    error.HttpError = webRequest.error;

                    // Calls the failure callback, passing the request error
                    onFailureCallback.Invoke(error);
                }
            }
        }

        /// <summary>
        /// Makes an HTTP DELETE request to the specified endpoint with optional query parameters.
        /// </summary>
        /// <param name="endpoint">The endpoint to call.</param>
        /// <param name="request">The object containing optional request parameters.</param>
        /// <param name="onSuccessCallback">The callback to be called on success.</param>
        /// <param name="onFailureCallback">The callback to be called on failure.</param>
        public static IEnumerator DeleteRequest<T>(string endpoint, Request request, Action<T> onSuccessCallback, Action<Error> onFailureCallback)
        {
            // Creates the base URI of the endpoint
            UriBuilder uriBuilder = new UriBuilder(endpoint);

            if (request != null)
            {
                // Gets the properties of the request object, ignoring null ones
                PropertyInfo[] requestProperties = request.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(p => p.GetValue(request) != null)
                    .ToArray();

                // Creates the dictionary of query string parameters
                Dictionary<string, string> queryParams = new Dictionary<string, string>();

                // Iterate over the properties of the request object
                foreach (PropertyInfo property in requestProperties)
                {
                    // Gets the JSON serialization attribute of the property
                    JsonPropertyAttribute jsonPropertyAttribute = property.GetCustomAttribute<JsonPropertyAttribute>();

                    // Checks if the property has the JSON serialization attribute
                    if (jsonPropertyAttribute != null)
                    {
                        // Creates a placeholder for the property value in the URI
                        string placeholder = WebUtility.UrlEncode($"{{{jsonPropertyAttribute.PropertyName}}}");

                        // Checks if the property is present in the URI as a placeholder
                        if (uriBuilder.Path.Contains(placeholder))
                        {
                            // If it is, replaces the placeholder with the property value in the URI
                            uriBuilder.Path = uriBuilder.Path.Replace(placeholder, WebUtility.UrlEncode(property.GetValue(request).ToString()));
                        }
                        else
                        {
                            // If it isn't, adds the parameter to the query string list
                            queryParams.Add(WebUtility.UrlEncode(jsonPropertyAttribute.PropertyName), WebUtility.UrlEncode(property.GetValue(request).ToString()));
                        }
                    }
                }

                // Concatenates the query string parameters to the URI, if any
                if (queryParams.Count > 0)
                {
                    uriBuilder.Query = string.Join("&", queryParams.Select(x => $"{x.Key}={x.Value}"));
                }
            }

            // Creates the HTTP DELETE request with the built URI
            using (UnityWebRequest webRequest = new UnityWebRequest(uriBuilder.Uri, UnityWebRequest.kHttpVerbDELETE))
            {
                // Creates the request handler
                DownloadHandler downloadHandler = new DownloadHandlerBuffer();

                // Sets the request handler
                webRequest.downloadHandler = downloadHandler;

                // Sets the maximum waiting time
                webRequest.timeout = OpenAiConstants.Timeout;

                // Sets the request headers
                webRequest.SetRequestHeader("Content-Type", "application/json");
                webRequest.SetRequestHeader("Authorization", "Bearer " + OpenAiConstants.ApiKey);

                // Sends the request and waits for the response
                yield return webRequest.SendWebRequest();

                // Checks if the request was successful and calls the corresponding callback
                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    // Calls the success callback, passing the response object as a parameter
                    onSuccessCallback.Invoke(JsonConvert.DeserializeObject<T>(downloadHandler.text));
                }
                else
                {
                    Error error = JsonConvert.DeserializeObject<Error>(JObject.Parse(downloadHandler.text)["error"].ToString());

                    error.HttpError = webRequest.error;

                    // Calls the failure callback, passing the request error
                    onFailureCallback.Invoke(error);
                }
            }
        }
    }
}