using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OpenAIToUnity.Domain.Types
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FilesStatus
    {
        [EnumMember(Value = "uploaded")] Uploaded,
        [EnumMember(Value = "processed")] Processed,
        [EnumMember(Value = "pending")] Pending,
        [EnumMember(Value = "error")] Error,
        [EnumMember(Value = "deleting")] Deleting,
        [EnumMember(Value = "deleted")] Deleted
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum FineTunesStatus
    {
        [EnumMember(Value = "created")] Created,
        [EnumMember(Value = "pending")] Pending,
        [EnumMember(Value = "running")] Running,
        [EnumMember(Value = "succeeded")] Succeeded,
        [EnumMember(Value = "failed")] Failed,
        [EnumMember(Value = "cancelled")] Cancelled
    }
}
