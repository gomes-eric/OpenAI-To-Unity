using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Responses.Embeddings
{
    public class Usage
    {
        [JsonProperty("prompt_tokens")] public int? PromptTokens { get; set; }

        [JsonProperty("completion_tokens")] public int? CompletionTokens { get; set; }

        [JsonProperty("total_tokens")] public int? TotalTokens { get; set; }
    }

    public class Data
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("index")] public int? Index { get; set; }

        [JsonProperty("embedding")] public List<double?> Embedding { get; set; }
    }

    public class CreateEmbeddingsResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("data")] public List<Data> Data { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("usage")] public Usage Usage { get; set; }
    }
}
