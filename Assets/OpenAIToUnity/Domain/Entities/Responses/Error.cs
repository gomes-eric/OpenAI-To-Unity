using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Responses
{
    public class Error
    {
        [JsonProperty("message")] public string Message { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("param")] public string Param { get; set; }

        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("http_error")] public string HttpError { get; set; }
    }
}
