using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Responses
{
    public struct CreateTranscriptionResponse
    {
        [JsonProperty("text")] public string Text { get; set; }
    }

    public struct CreateTranslationResponse
    {
        [JsonProperty("text")] public string Text { get; set; }
    }
}
