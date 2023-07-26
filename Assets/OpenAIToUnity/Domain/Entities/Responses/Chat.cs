using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Responses
{
    public class ChatUsage
    {
        [JsonProperty("prompt_tokens")] public int? PromptTokens { get; set; }

        [JsonProperty("completion_tokens")] public int? CompletionTokens { get; set; }

        [JsonProperty("total_tokens")] public int? TotalTokens { get; set; }
    }

    public class ChatResponseMessage
    {
        [JsonProperty("role")] public string Role { get; set; }

        [JsonProperty("content")] public string Content { get; set; }
    }

    public class ChatChoice
    {
        [JsonProperty("message")] public ChatResponseMessage Message { get; set; }

        [JsonProperty("finish_reason")] public string FinishReason { get; set; }

        [JsonProperty("index")] public int? Index { get; set; }
    }

    public class CreateChatCompletionResponse
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("created")] public int? Created { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("usage")] public ChatUsage Usage { get; set; }

        [JsonProperty("choices")] public List<ChatChoice> Choices { get; set; }
    }
}
