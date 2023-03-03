using System;
using System.Collections.Generic;
using Data.Interfaces;
using Newtonsoft.Json;

namespace Data.Entities.Requests
{
    [Serializable]
    public class CreateCompletionRequest : Request
    {
        [JsonProperty("model")]
        public string Model { get; private set; }

        [JsonProperty("prompt")]
        public List<string> Prompt { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        [JsonProperty("max_tokens")]
        public int? MaxTokens { get; set; }

        [JsonProperty("temperature")]
        public float? Temperature { get; set; }

        [JsonProperty("top_p")]
        public float? TopP { get; set; }

        [JsonProperty("n")]
        public int? N { get; set; }

        [JsonProperty("stream")]
        public bool? Stream { get; set; }

        [JsonProperty("logprobs")]
        public int? Logprobs { get; set; }

        [JsonProperty("echo")]
        public bool? Echo { get; set; }

        [JsonProperty("stop")]
        public List<string> Stop { get; set; }

        [JsonProperty("presence_penalty")]
        public float? PresencePenalty { get; set; }

        [JsonProperty("frequency_penalty")]
        public float? FrequencyPenalty { get; set; }

        [JsonProperty("best_of")]
        public int? BestOf { get; set; }

        [JsonProperty("logit_bias")]
        public Dictionary<string, int> LogitBias { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        public CreateCompletionRequest(string model)
        {
            this.Model = model;
        }

        public class Builder
        {
            private readonly CreateCompletionRequest _request;

            public Builder(string model)
            {
                _request = new CreateCompletionRequest(model);
            }

            public Builder Prompt(List<string> prompt)
            {
                _request.Prompt = prompt;

                return this;
            }

            public Builder Suffix(string suffix)
            {
                _request.Suffix = suffix;

                return this;
            }

            public Builder MaxTokens(int? maxTokens)
            {
                _request.MaxTokens = maxTokens;

                return this;
            }

            public Builder Temperature(float? temperature)
            {
                _request.Temperature = temperature;

                return this;
            }

            public Builder TopP(float? topP)
            {
                _request.TopP = topP;

                return this;
            }

            public Builder N(int? n)
            {
                _request.N = n;

                return this;
            }

            public Builder Stream(bool? stream)
            {
                _request.Stream = stream;

                return this;
            }

            public Builder Logprobs(int? logprobs)
            {
                _request.Logprobs = logprobs;

                return this;
            }

            public Builder Echo(bool? echo)
            {
                _request.Echo = echo;

                return this;
            }

            public Builder Stop(List<string> stop)
            {
                _request.Stop = stop;

                return this;
            }

            public Builder PresencePenalty(float? presencePenalty)
            {
                _request.PresencePenalty = presencePenalty;

                return this;
            }

            public Builder FrequencyPenalty(float? frequencyPenalty)
            {
                _request.FrequencyPenalty = frequencyPenalty;

                return this;
            }

            public Builder BestOf(int? bestOf)
            {
                _request.BestOf = bestOf;

                return this;
            }

            public Builder LogitBias(Dictionary<string, int> logitBias)
            {
                _request.LogitBias = logitBias;

                return this;
            }

            public Builder User(string user)
            {
                _request.User = user;

                return this;
            }

            public CreateCompletionRequest Build()
            {
                return _request;
            }
        }
    }
}