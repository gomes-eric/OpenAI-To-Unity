using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Responses.Audio
{
    public class CreateTranscriptionResponse
    {
        [JsonProperty("text")] public string Text { get; set; }
    }

    public class CreateTranslationResponse
    {
        [JsonProperty("text")] public string Text { get; set; }
    }
}
