using System.Collections.Generic;
using Newtonsoft.Json;
using OpenAIToUnity.Domain.Entities.Common;

namespace OpenAIToUnity.Domain.Entities.Responses
{
    public struct Message
    {
        [JsonProperty("role")] public string Role { get; set; }

        [JsonProperty("content")] public string Content { get; set; }
    }

    public struct ChatChoice
    {
        [JsonProperty("message")] public Message? Message { get; set; }

        [JsonProperty("finish_reason")] public string FinishReason { get; set; }

        [JsonProperty("index")] public int? Index { get; set; }
    }

    public struct CreateChatCompletionResponse
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("created")] public int? Created { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("usage")] public Usage? Usage { get; set; }

        [JsonProperty("choices")] public List<ChatChoice?> Choices { get; set; }
    }
}