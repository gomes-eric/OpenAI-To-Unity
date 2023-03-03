using System;
using System.Collections.Generic;
using Data.Entities.Common;
using Data.Interfaces;
using Newtonsoft.Json;

namespace Data.Entities.Responses
{
    [Serializable]
    public class EmbeddingData
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("index")]
        public int? Index { get; set; }

        [JsonProperty("embedding")]
        public List<double> Embedding { get; set; }
    }

    [Serializable]
    public class CreateEmbeddingsResponse : Response
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("data")]
        public List<EmbeddingData> Data { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("usage")]
        public Usage Usage { get; set; }
    }
}