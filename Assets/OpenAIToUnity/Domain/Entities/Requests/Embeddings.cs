using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Requests
{
    public class CreateEmbeddingsRequest
    {
        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("input")] public List<string> Input { get; set; }

        [JsonProperty("user")] public string User { get; set; }

        public class Builder
        {
            private CreateEmbeddingsRequest _request;

            public Builder()
            {
                _request = new CreateEmbeddingsRequest();
            }

            public Builder SetModel(string model)
            {
                _request.Model = model;

                return this;
            }

            public Builder SetInput(List<string> input)
            {
                _request.Input = input;

                return this;
            }

            public Builder SetUser(string user)
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
