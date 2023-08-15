using System.IO;
using Newtonsoft.Json;
using OpenAIToUnity.Domain.Types;

namespace OpenAIToUnity.Domain.Entities.Requests.Files
{
    public class UploadFileRequest
    {
        private UploadFileRequest()
        {
        }

        [JsonProperty("file")] public FileStream File { get; set; }

        [JsonProperty("purpose")] public Purpose Purpose { get; set; }

        public class Builder
        {
            private readonly UploadFileRequest _request = new();

            public Builder SetFile(FileStream file)
            {
                _request.File = file;

                return this;
            }

            public Builder SetPurpose(Purpose purpose)
            {
                _request.Purpose = purpose;

                return this;
            }

            public UploadFileRequest Build()
            {
                return _request;
            }
        }
    }

    public class DeleteFileRequest
    {
        private DeleteFileRequest()
        {
        }

        [JsonProperty("file_id")] public string FileId { get; set; }

        public class Builder
        {
            private readonly DeleteFileRequest _request = new();

            public Builder SetFileId(string fileId)
            {
                _request.FileId = fileId;

                return this;
            }

            public DeleteFileRequest Build()
            {
                return _request;
            }
        }
    }

    public class RetrieveFileRequest
    {
        private RetrieveFileRequest()
        {
        }

        [JsonProperty("file_id")] public string FileId { get; set; }

        public class Builder
        {
            private readonly RetrieveFileRequest _request = new();

            public Builder SetFileId(string fileId)
            {
                _request.FileId = fileId;

                return this;
            }

            public RetrieveFileRequest Build()
            {
                return _request;
            }
        }
    }

    public class RetrieveFileContentRequest
    {
        private RetrieveFileContentRequest()
        {
        }

        [JsonProperty("file_id")] public string FileId { get; set; }

        public class Builder
        {
            private readonly RetrieveFileContentRequest _request = new();

            public Builder SetFileId(string fileId)
            {
                _request.FileId = fileId;

                return this;
            }

            public RetrieveFileContentRequest Build()
            {
                return _request;
            }
        }
    }
}
