using System;
using System.Collections.Generic;
using Data.Interfaces;
using Newtonsoft.Json;

namespace Data.Entities.Requests
{
    [Serializable]
    public class CreateModerationRequest : Request
    {
        [JsonProperty("input")]
        public List<string> Input { get; private set; }

        [JsonProperty("model")]
        public string model { get; set; }

        public CreateModerationRequest(List<string> input)
        {
            this.Input = input;
        }

        public class Builder
        {
            private readonly CreateModerationRequest _request;

            public Builder(List<string> input)
            {
                _request = new CreateModerationRequest(input);
            }

            public Builder Model(string model)
            {
                _request.model = model;

                return this;
            }

            public CreateModerationRequest Build()
            {
                return _request;
            }
        }
    }
}