using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Responses
{
    public class EditsChoice
    {
        [JsonProperty("text")] public string Text { get; set; }

        [JsonProperty("index")] public int Index { get; set; }
    }

    public class EditsUsage
    {
        [JsonProperty("prompt_tokens")] public int? PromptTokens { get; set; }

        [JsonProperty("completion_tokens")] public int? CompletionTokens { get; set; }

        [JsonProperty("total_tokens")] public int? TotalTokens { get; set; }
    }

    public class CreateEditResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("created")] public int Created { get; set; }

        [JsonProperty("choices")] public List<EditsChoice> Choices { get; set; }

        [JsonProperty("usage")] public EditsUsage Usage { get; set; }
    }
}
