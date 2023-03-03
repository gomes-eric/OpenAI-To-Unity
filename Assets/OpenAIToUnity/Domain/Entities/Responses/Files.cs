using System;
using System.Collections.Generic;
using Data.Entities.Common;
using Data.Interfaces;
using Newtonsoft.Json;

namespace Data.Entities.Responses
{
    [Serializable]
    public class ListFilesResponse : Response
    {
        [JsonProperty("data")]
        public List<File> Data { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }
    }

    [Serializable]
    public class UploadFileResponse : File, Response
    {

    }

    [Serializable]
    public class DeleteFileResponse : Response
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }
    }

    [Serializable]
    public class RetrieveFileResponse : File, Response
    {

    }

    [Serializable]
    public class RetrieveFileContentResponse : Response
    {

    }
}