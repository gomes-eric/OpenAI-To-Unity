using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Requests.Models
{
    public class RetrieveModelRequest
    {
        [JsonProperty("model")] public string Model { get; set; }

        public class Builder
        {
            private RetrieveModelRequest _request;

            public Builder()
            {
                _request = new RetrieveModelRequest();
            }

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
