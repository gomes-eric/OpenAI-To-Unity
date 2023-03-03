using System;
using Data.Interfaces;
using Newtonsoft.Json;

namespace Data.Entities.Requests
{
    [Serializable]
    public class UploadFileRequest : Request
    {
        [JsonProperty("file")]
        public string File { get; private set; }

        [JsonProperty("purpose")]
        public string Purpose { get; private set; }

        public UploadFileRequest(string file, string purpose)
        {
            this.File = file;
            this.Purpose = purpose;
        }

        public class Builder
        {
            private readonly UploadFileRequest _request;

            public Builder(string file, string purpose)
            {
                _request = new UploadFileRequest(file, purpose);
            }

            public UploadFileRequest Build()
            {
                return _request;
            }
        }
    }

    [Serializable]
    public class DeleteFileRequest : Request
    {
        [JsonProperty("file_id")]
        public string FileId { get; private set; }

        public DeleteFileRequest(string fileId)
        {
            this.FileId = fileId;
        }

        public class Builder
        {
            private readonly DeleteFileRequest _request;

            public Builder(string fileId)
            {
                _request = new DeleteFileRequest(fileId);
            }

            public DeleteFileRequest Build()
            {
                return _request;
            }
        }
    }

    [Serializable]
    public class RetrieveFileRequest : Request
    {
        [JsonProperty("file_id")]
        public string FileId { get; private set; }

        public RetrieveFileRequest(string fileId)
        {
            this.FileId = fileId;
        }

        public class Builder
        {
            private readonly RetrieveFileRequest _request;

            public Builder(string fileId)
            {
                _request = new RetrieveFileRequest(fileId);
            }

            public RetrieveFileRequest Build()
            {
                return _request;
            }
        }
    }

    [Serializable]
    public class RetrieveFileContentRequest : Request
    {
        [JsonProperty("file_id")]
        public string FileId { get; private set; }

        public RetrieveFileContentRequest(string fileId)
        {
            this.FileId = fileId;
        }

        public class Builder
        {
            private readonly RetrieveFileContentRequest _request;

            public Builder(string fileId)
            {
                _request = new RetrieveFileContentRequest(fileId);
            }

            public RetrieveFileContentRequest Build()
            {
                return _request;
            }
        }
    }
}