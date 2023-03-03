using System;
using Data.Interfaces;
using Newtonsoft.Json;

namespace Domain.Entities.Responses
{
    [Serializable]
    public class Error : Response
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("param")]
        public object Param { get; set; }

        [JsonProperty("code")]
        public object Code { get; set; }

        [JsonProperty("http_error")]
        public object HttpError { get; set; }
    }
}