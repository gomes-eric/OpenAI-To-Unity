using System;
using Data.Interfaces;
using Newtonsoft.Json;

namespace Data.Entities.Requests
{
    [Serializable]
    public class CreateEditRequest : Request
    {
        [JsonProperty("model")]
        public string Model { get; private set; }

        [JsonProperty("instruction")]
        public string Instruction { get; private set; }

        [JsonProperty("input")]
        public string Input { get; set; }

        [JsonProperty("n")]
        public int? N { get; set; }

        [JsonProperty("temperature")]
        public float? Temperature { get; set; }

        [JsonProperty("top_p")]
        public float? TopP { get; set; }

        public CreateEditRequest(string model, string instruction)
        {
            this.Model = model;
            this.Instruction = instruction;
        }

        public class Builder
        {
            private readonly CreateEditRequest _request;

            public Builder(string model, string instruction)
            {
                _request = new CreateEditRequest(model, instruction);
            }

            public Builder Input(string input)
            {
                _request.Input = input;

                return this;
            }

            public Builder N(int n)
            {
                _request.N = n;

                return this;
            }

            public Builder Temperature(float temperature)
            {
                _request.Temperature = temperature;

                return this;
            }

            public Builder TopP(float topP)
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