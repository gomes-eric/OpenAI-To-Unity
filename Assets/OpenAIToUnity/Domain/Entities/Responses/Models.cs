using System;
using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Responses
{
    [Serializable]
    public class RetrieveModelRequest
    {
        public RetrieveModelRequest(string model)
        {
            Model = model;
        }

        [JsonProperty("model")] public string Model { get; private set; }

        public class Builder
        {
            private readonly RetrieveModelRequest _request;

            public Builder(string model)
            {
                _request = new RetrieveModelRequest(model);
            }

            public RetrieveModelRequest Build()
            {
                return _request;
            }
        }
    }
}