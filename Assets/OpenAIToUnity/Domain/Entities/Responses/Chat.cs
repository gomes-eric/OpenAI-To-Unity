using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenAIToUnity.Domain.Types;
using OpenAIToUnity.Domain.Utils;

namespace OpenAIToUnity.Domain.Entities.Responses.Chat
{
    public class FunctionCall
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("arguments")][JsonConverter(typeof(StringToJObjectConverter))] public JObject Arguments { get; set; }
    }

    public class Message
    {
        [JsonProperty("role")] public Role Role { get; set; }

        [JsonProperty("content")] public string Content { get; set; }

        [JsonProperty("function_call")] public FunctionCall FunctionCall { get; set; }
    }

    public class Choice
    {
        [JsonProperty("index")] public int Index { get; set; }

        [JsonProperty("message")] public Message Message { get; set; }

        [JsonProperty("finish_reason")] public string FinishReason { get; set; }
    }

    public class Usage
    {
        [JsonProperty("prompt_tokens")] public int? PromptTokens { get; set; }

        [JsonProperty("completion_tokens")] public int? CompletionTokens { get; set; }

        [JsonProperty("total_tokens")] public int? TotalTokens { get; set; }
    }

    public class CreateChatCompletionResponse
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("created")] public int? Created { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("usage")] public Usage Usage { get; set; }

        [JsonProperty("choices")] public List<Choice> Choices { get; set; }
    }
}
