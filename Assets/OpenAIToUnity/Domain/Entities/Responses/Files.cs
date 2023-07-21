using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Responses
{
    public struct FilesData
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("purpose")] public string Purpose { get; set; }

        [JsonProperty("filename")] public string Filename { get; set; }

        [JsonProperty("bytes")] public int? Bytes { get; set; }

        [JsonProperty("created_at")] public int? CreatedAt { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("status_details")] public string StatusDetails { get; set; }
    }

    public struct ListFilesResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("data")] public List<FilesData?> Data { get; set; }
    }

    public struct UploadFileResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("purpose")] public string Purpose { get; set; }

        [JsonProperty("filename")] public string Filename { get; set; }

        [JsonProperty("bytes")] public int? Bytes { get; set; }

        [JsonProperty("created_at")] public int? CreatedAt { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("status_details")] public string StatusDetails { get; set; }
    }

    public struct DeleteFileResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("deleted")] public bool? Deleted { get; set; }
    }

    public struct RetrieveFileResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("purpose")] public string Purpose { get; set; }

        [JsonProperty("filename")] public string Filename { get; set; }

        [JsonProperty("bytes")] public int? Bytes { get; set; }

        [JsonProperty("created_at")] public int? CreatedAt { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("status_details")] public string StatusDetails { get; set; }
    }
}
