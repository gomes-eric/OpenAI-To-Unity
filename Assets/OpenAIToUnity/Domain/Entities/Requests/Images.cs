using System;
using Data.Interfaces;
using Data.Types;
using Newtonsoft.Json;

namespace Data.Entities.Requests
{
    [Serializable]
    public class CreateImageRequest : Request
    {
        [JsonProperty("prompt")]
        public string Prompt { get; private set; }

        [JsonProperty("n")]
        public int? N { get; set; }

        [JsonProperty("size")]
        public ImageSize Size { get; set; }

        [JsonProperty("response_format")]
        public ImageResponseFormat ResponseFormat { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        public CreateImageRequest(string prompt)
        {
            this.Prompt = prompt;
        }

        public class Builder
        {
            private readonly CreateImageRequest _request;

            public Builder(string prompt)
            {
                _request = new CreateImageRequest(prompt);
            }

            public Builder N(int n)
            {
                _request.N = n;

                return this;
            }

            public Builder Size(ImageSize size)
            {
                _request.Size = size;

                return this;
            }

            public Builder ResponseFormat(ImageResponseFormat responseFormat)
            {
                _request.ResponseFormat = responseFormat;

                return this;
            }

            public Builder User(string user)
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

    [Serializable]
    public class CreateImageEditRequest : Request
    {
        [JsonProperty("image")]
        public string Image { get; private set; }

        [JsonProperty("prompt")]
        public string Prompt { get; private set; }

        [JsonProperty("mask")]
        public string Mask { get; set; }

        [JsonProperty("n")]
        public int? N { get; set; }

        [JsonProperty("size")]
        public ImageSize Size { get; set; }

        [JsonProperty("response_format")]
        public ImageResponseFormat ResponseFormat { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        public CreateImageEditRequest(string image, string prompt)
        {
            this.Image = image;
            this.Prompt = prompt;
        }

        public class Builder
        {
            private readonly CreateImageEditRequest _request;

            public Builder(string image, string prompt)
            {
                _request = new CreateImageEditRequest(image, prompt);
            }

            public Builder Mask(string mask)
            {
                _request.Mask = mask;

                return this;
            }

            public Builder N(int n)
            {
                _request.N = n;

                return this;
            }

            public Builder Size(ImageSize size)
            {
                _request.Size = size;

                return this;
            }

            public Builder ResponseFormat(ImageResponseFormat responseFormat)
            {
                _request.ResponseFormat = responseFormat;

                return this;
            }

            public Builder User(string user)
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

    [Serializable]
    public class CreateImageVariationRequest : Request
    {
        [JsonProperty("image")]
        public string Image { get; private set; }

        [JsonProperty("n")]
        public int? N { get; set; }

        [JsonProperty("size")]
        public ImageSize Size { get; set; }

        [JsonProperty("response_format")]
        public ImageResponseFormat ResponseFormat { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        public CreateImageVariationRequest(string image)
        {
            this.Image = image;
        }

        public class Builder
        {
            private readonly CreateImageVariationRequest _request;

            public Builder(string image, string prompt)
            {
                _request = new CreateImageVariationRequest(image);
            }

            public Builder N(int n)
            {
                _request.N = n;

                return this;
            }

            public Builder Size(ImageSize size)
            {
                _request.Size = size;

                return this;
            }

            public Builder ResponseFormat(ImageResponseFormat responseFormat)
            {
                _request.ResponseFormat = responseFormat;

                return this;
            }

            public Builder User(string user)
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