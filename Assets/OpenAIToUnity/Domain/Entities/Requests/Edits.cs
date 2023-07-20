using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Requests
{
    public struct CreateEditRequest
    {
        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("input")] public string Input { get; set; }

        [JsonProperty("instruction")] public string Instruction { get; set; }

        [JsonProperty("n")] public int? N { get; set; }

        [JsonProperty("temperature")] public float? Temperature { get; set; }

        [JsonProperty("top_p")] public float? TopP { get; set; }

        public class Builder
        {
            private CreateEditRequest _request;

            public Builder()
            {
                _request = new CreateEditRequest();
            }

            public Builder SetModel(string model)
            {
                _request.Model = model;

                return this;
            }

            public Builder SetInput(string input)
            {
                _request.Input = input;

                return this;
            }

            public Builder SetInstruction(string instruction)
            {
                _request.Instruction = instruction;

                return this;
            }

            public Builder SetN(int? n)
            {
                _request.N = n;

                return this;
            }

            public Builder SetTemperature(float? temperature)
            {
                _request.Temperature = temperature;

                return this;
            }

            public Builder SetTopP(float? topP)
            {
                _request.TopP = topP;

                return this;
            }

            public CreateEditRequest Build()
            {
                return _request;
            }
        }
    }
}
