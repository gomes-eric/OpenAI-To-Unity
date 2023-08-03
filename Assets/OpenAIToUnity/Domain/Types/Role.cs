using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenAIToUnity.Domain.Types
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Role
    {
        [EnumMember(Value = "system")] System,
        [EnumMember(Value = "user")] User,
        [EnumMember(Value = "assistant")] Assistant,
        [EnumMember(Value = "function")] Function
    }
}
