using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Requests
{
    public class CreateModerationRequest
    {
        [JsonProperty("input")] public List<string> Input { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        public class Builder
        {
            private CreateModerationRequest _request;

            public Builder()
            {
                _request = new CreateModerationRequest();
            }

            public Builder SetInput(List<string> input)
            {
                _request.Input = input;

                return this;
            }

            public Builder SetModel(string model)
            {
                _request.Model = model;

                return this;
            }

            public CreateModerationRequest Build()
            {
                return _request;
            }
        }
    }
}
