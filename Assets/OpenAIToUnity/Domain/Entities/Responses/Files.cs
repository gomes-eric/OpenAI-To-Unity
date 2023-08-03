using System.Collections.Generic;
using Newtonsoft.Json;
using OpenAIToUnity.Domain.Types;

namespace OpenAIToUnity.Domain.Entities.Responses.Files
{
    public class File
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("purpose")] public Purpose Purpose { get; set; }

        [JsonProperty("filename")] public string Filename { get; set; }

        [JsonProperty("bytes")] public int? Bytes { get; set; }

        [JsonProperty("created_at")] public int? CreatedAt { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("status_details")] public string StatusDetails { get; set; }
    }

    public class ListFilesResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("data")] public List<File> Data { get; set; }
    }

    public class UploadFileResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("purpose")] public Purpose Purpose { get; set; }

        [JsonProperty("filename")] public string Filename { get; set; }

        [JsonProperty("bytes")] public int? Bytes { get; set; }

        [JsonProperty("created_at")] public int? CreatedAt { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("status_details")] public string StatusDetails { get; set; }
    }

    public class DeleteFileResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("deleted")] public bool? Deleted { get; set; }
    }

    public class RetrieveFileResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("purpose")] public Purpose Purpose { get; set; }

        [JsonProperty("filename")] public string Filename { get; set; }

        [JsonProperty("bytes")] public int? Bytes { get; set; }

        [JsonProperty("created_at")] public int? CreatedAt { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("status_details")] public string StatusDetails { get; set; }
    }
}
