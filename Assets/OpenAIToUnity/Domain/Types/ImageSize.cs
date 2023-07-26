using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenAIToUnity.Domain.Types
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ImagesSize
    {
        [EnumMember(Value = "256x256")] Small,
        [EnumMember(Value = "512x512")] Medium,
        [EnumMember(Value = "1024x1024")] Large
    }
}
