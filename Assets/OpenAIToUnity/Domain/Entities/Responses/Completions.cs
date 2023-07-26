using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Responses
{
    public class CompletionsChoice
    {
        [JsonProperty("text")] public string Text { get; set; }

        [JsonProperty("index")] public int? Index { get; set; }

        [JsonProperty("logprobs")] public int? Logprobs { get; set; }

        [JsonProperty("finish_reason")] public string FinishReason { get; set; }
    }

    public class CompletionsUsage
    {
        [JsonProperty("prompt_tokens")] public int? PromptTokens { get; set; }

        [JsonProperty("completion_tokens")] public int? CompletionTokens { get; set; }

        [JsonProperty("total_tokens")] public int? TotalTokens { get; set; }
    }

    public class CreateCompletionResponse
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("created")] public int? Created { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("choices")] public List<CompletionsChoice> Choices { get; set; }

        [JsonProperty("usage")] public CompletionsUsage Usage { get; set; }
    }
}
