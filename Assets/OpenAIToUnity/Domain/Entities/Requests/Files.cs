using System.IO;
using Newtonsoft.Json;
using OpenAIToUnity.Domain.Types;
using OpenAIToUnity.Domain.Utils;

namespace OpenAIToUnity.Domain.Entities.Requests
{
    public struct UploadFileRequest
    {
        [JsonProperty("file")] public FileStream File { get; set; }

        [JsonProperty("purpose")] public string Purpose { get; set; }

        public class Builder
        {
            private UploadFileRequest _request;

            public Builder()
            {
                _request = new UploadFileRequest();
            }

            public Builder SetFile(FileStream file)
            {
                _request.File = file;

                return this;
            }

            public Builder SetPurpose(Purpose purpose)
            {
                _request.Purpose = purpose.ToRequest();

                return this;
            }

            public UploadFileRequest Build()
            {
                return _request;
            }
        }
    }

    public struct DeleteFileRequest
    {
        [JsonProperty("file_id")] public string FileId { get; set; }

        public class Builder
        {
            private DeleteFileRequest _request;

            public Builder()
            {
                _request = new DeleteFileRequest();
            }

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

    public struct RetrieveFileRequest
    {
        [JsonProperty("file_id")] public string FileId { get; set; }

        public class Builder
        {
            private RetrieveFileRequest _request;

            public Builder()
            {
                _request = new RetrieveFileRequest();
            }

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

    public struct RetrieveFileContentRequest
    {
        [JsonProperty("file_id")] public string FileId { get; set; }

        public class Builder
        {
            private RetrieveFileContentRequest _request;

            public Builder()
            {
                _request = new RetrieveFileContentRequest();
            }

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
