using System;
using Data.Interfaces;
using Newtonsoft.Json;

namespace Data.Entities.Requests
{
    [Serializable]
    public class RetrieveModelRequest : Request
    {
        [JsonProperty("model")]
        public string Model { get; private set; }

        public RetrieveModelRequest(string model)
        {
            this.Model = model;
        }

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
