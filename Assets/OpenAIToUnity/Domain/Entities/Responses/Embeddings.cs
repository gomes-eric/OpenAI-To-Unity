using System.Collections.Generic;
using Newtonsoft.Json;
using OpenAIToUnity.Domain.Entities.Common;

namespace OpenAIToUnity.Domain.Entities.Responses
{
    public struct EmbeddingsData
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("index")] public int? Index { get; set; }

        [JsonProperty("embedding")] public List<double?> Embedding { get; set; }
    }

    public struct CreateEmbeddingsResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("data")] public List<EmbeddingsData?> Data { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("usage")] public Usage? Usage { get; set; }
    }
}
