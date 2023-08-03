using System.IO;
using Newtonsoft.Json;
using OpenAIToUnity.Domain.Types;

namespace OpenAIToUnity.Domain.Entities.Requests.Images
{
    public class CreateImageRequest
    {
        [JsonProperty("prompt")] public string Prompt { get; set; }

        [JsonProperty("n")] public int? N { get; set; }

        [JsonProperty("size")] public ImagesSize Size { get; set; }

        [JsonProperty("response_format")] public ImagesResponseFormat ResponseFormat { get; set; }

        [JsonProperty("user")] public string User { get; set; }

        public class Builder
        {
            private CreateImageRequest _request;

            public Builder()
            {
                _request = new CreateImageRequest();
            }

            public Builder SetPrompt(string prompt)
            {
                _request.Prompt = prompt;

                return this;
            }

            public Builder SetN(int? n)
            {
                _request.N = n;

                return this;
            }

            public Builder SetSize(ImagesSize size)
            {
                _request.Size = size;

                return this;
            }

            public Builder SetResponseFormat(ImagesResponseFormat responseFormat)
            {
                _request.ResponseFormat = responseFormat;

                return this;
            }

            public Builder SetUser(string user)
            {
                _request.User = user;

                return this;
            }

            public CreateImageRequest Build()
            {
                return _request;
            }
        }
    }

    public class CreateImageEditRequest
    {
        [JsonProperty("image")] public FileStream Image { get; set; }

        [JsonProperty("mask")] public FileStream Mask { get; set; }

        [JsonProperty("prompt")] public string Prompt { get; set; }

        [JsonProperty("n")] public int? N { get; set; }

        [JsonProperty("size")] public ImagesSize Size { get; set; }

        [JsonProperty("response_format")] public string ResponseFormat { get; set; }

        [JsonProperty("user")] public string User { get; set; }

        public class Builder
        {
            private CreateImageEditRequest _request;

            public Builder()
            {
                _request = new CreateImageEditRequest();
            }

            public Builder SetImage(FileStream image)
            {
                _request.Image = image;

                return this;
            }

            public Builder SetMask(FileStream mask)
            {
                _request.Mask = mask;

                return this;
            }

            public Builder SetPrompt(string prompt)
            {
                _request.Prompt = prompt;

                return this;
            }

            public Builder SetN(int? n)
            {
                _request.N = n;

                return this;
            }

            public Builder SetSize(ImagesSize size)
            {
                _request.Size = size;

                return this;
            }

            public Builder SetResponseFormat(string responseFormat)
            {
                _request.ResponseFormat = responseFormat;

                return this;
            }

            public Builder SetUser(string user)
            {
                _request.User = user;

                return this;
            }

            public CreateImageEditRequest Build()
            {
                return _request;
            }
        }
    }

    public class CreateImageVariationRequest
    {
        [JsonProperty("image")] public FileStream Image { get; set; }

        [JsonProperty("n")] public int? N { get; set; }

        [JsonProperty("size")] public ImagesSize Size { get; set; }

        [JsonProperty("response_format")] public string ResponseFormat { get; set; }

        [JsonProperty("user")] public string User { get; set; }

        public class Builder
        {
            private CreateImageVariationRequest _request;

            public Builder()
            {
                _request = new CreateImageVariationRequest();
            }

            public Builder SetImage(FileStream image)
            {
                _request.Image = image;

                return this;
            }

            public Builder SetN(int? n)
            {
                _request.N = n;

                return this;
            }

            public Builder SetSize(ImagesSize size)
            {
                _request.Size = size;

                return this;
            }

            public Builder SetResponseFormat(string responseFormat)
            {
                _request.ResponseFormat = responseFormat;

                return this;
            }

            public Builder SetUser(string user)
            {
                _request.User = user;

                return this;
            }

            public CreateImageVariationRequest Build()
            {
                return _request;
            }
        }
    }
}
