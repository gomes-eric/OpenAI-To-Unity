using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenAIToUnity.Domain.Types
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Purpose
    {
        [EnumMember(Value = "fine-tune")] FineTune
    }
}
