using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Responses.Error
{
    public class Error
    {
        [JsonProperty("message")] public string Message { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("param")] public string Param { get; set; }

        [JsonProperty("code")] public string Code { get; set; }

        [JsonProperty("http_error_message")] public string HttpErrorMessage { get; set; }

        [JsonProperty("http_error_code")] public string HttpErrorCode { get; set; }
    }
}
