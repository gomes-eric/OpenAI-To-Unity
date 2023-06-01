using System.Collections.Generic;
using Newtonsoft.Json;
using OpenAIToUnity.Domain.Entities.Common;

namespace OpenAIToUnity.Domain.Entities.Responses
{
    public struct CompletionsChoice
    {
        [JsonProperty("text")] public string Text { get; set; }

        [JsonProperty("index")] public int? Index { get; set; }

        [JsonProperty("logprobs")] public int? Logprobs { get; set; }

        [JsonProperty("finish_reason")] public string FinishReason { get; set; }
    }

    public struct CreateCompletionResponse
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("created")] public int? Created { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("choices")] public List<CompletionsChoice?> Choices { get; set; }

        [JsonProperty("usage")] public Usage? Usage { get; set; }
    }
}