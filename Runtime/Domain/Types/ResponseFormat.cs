using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenAIToUnity.Domain.Types
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ImagesResponseFormat
    {
        [EnumMember(Value = "url")] Url,
        [EnumMember(Value = "b64_json")] B64Json
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AudioResponseFormat
    {
        [EnumMember(Value = "json")] Json,
        [EnumMember(Value = "text")] Text,
        [EnumMember(Value = "srt")] Srt,
        [EnumMember(Value = "verbose_json")] VerboseJson,
        [EnumMember(Value = "vtt")] Vtt
    }
}
