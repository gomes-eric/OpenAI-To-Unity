using System;
using System.Collections.Generic;
using Data.Interfaces;
using Newtonsoft.Json;

namespace Data.Entities.Requests
{
    [Serializable]
    public class CreateEmbeddingsRequest : Request
    {
        [JsonProperty("model")]
        public string Model { get; private set; }

        [JsonProperty("input")]
        public List<string> Input { get; private set; }

        [JsonProperty("user")]
        public string User { get; set; }

        public CreateEmbeddingsRequest(string model, List<string> input)
        {
            this.Model = model;
            this.Input = input;
        }

        public class Builder
        {
            private readonly CreateEmbeddingsRequest _request;

            public Builder(string model, List<string> input)
            {
                _request = new CreateEmbeddingsRequest(model, input);
            }

            public Builder User(string user)
            {
                _request.User = user;

                return this;
            }

            public CreateEmbeddingsRequest Build()
            {
                return _request;
            }
        }
    }
}