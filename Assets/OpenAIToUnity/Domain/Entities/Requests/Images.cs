using System.IO;
using Newtonsoft.Json;
using OpenAIToUnity.Domain.Types;
using OpenAIToUnity.Domain.Utils;

namespace OpenAIToUnity.Domain.Entities.Requests
{
    public struct CreateImageRequest
    {
        [JsonProperty("prompt")] public string Prompt { get; set; }

        [JsonProperty("n")] public int? N { get; set; }

        [JsonProperty("size")] public string Size { get; set; }

        [JsonProperty("response_format")] public string ResponseFormat { get; set; }

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

            public Builder SetSize(ImageSize size)
            {
                _request.Size = size.ToSize();

                return this;
            }

            public Builder SetResponseFormat(ImageResponseFormat responseFormat)
            {
                _request.ResponseFormat = responseFormat.ToFormat();

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

    public struct CreateImageEditRequest
    {
        [JsonProperty("image")] public FileStream Image { get; set; }

        [JsonProperty("mask")] public FileStream Mask { get; set; }

        [JsonProperty("prompt")] public string Prompt { get; set; }

        [JsonProperty("n")] public int? N { get; set; }

        [JsonProperty("size")] public string Size { get; set; }

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

            public Builder SetSize(string size)
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

    public struct CreateImageVariationRequest
    {
        [JsonProperty("image")] public FileStream Image { get; set; }

        [JsonProperty("n")] public int? N { get; set; }

        [JsonProperty("size")] public string Size { get; set; }

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

            public Builder SetSize(string size)
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
