using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Requests.Models
{
    public class RetrieveModelRequest
    {
        private RetrieveModelRequest()
        {
        }

        [JsonProperty("model")] public string Model { get; set; }

        public class Builder
        {
            private readonly RetrieveModelRequest _request = new();

            public Builder SetModel(string model)
            {
                _request.Model = model;

                return this;
            }

            public RetrieveModelRequest Build()
            {
                return _request;
            }
        }
    }
}
