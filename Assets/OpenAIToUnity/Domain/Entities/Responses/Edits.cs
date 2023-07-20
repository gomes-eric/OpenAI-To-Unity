using System.Collections.Generic;
using Newtonsoft.Json;
using OpenAIToUnity.Domain.Entities.Common;

namespace OpenAIToUnity.Domain.Entities.Responses
{
    public struct EditsChoice
    {
        [JsonProperty("text")] public string Text { get; set; }

        [JsonProperty("index")] public int Index { get; set; }
    }

    public struct CreateEditResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("created")] public int Created { get; set; }

        [JsonProperty("choices")] public List<EditsChoice?> Choices { get; set; }

        [JsonProperty("usage")] public Usage Usage { get; set; }
    }
}
