using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Requests
{
    public struct CreateCompletionRequest
    {
        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("prompt")] public List<string> Prompt { get; set; }

        [JsonProperty("suffix")] public string Suffix { get; set; }

        [JsonProperty("max_tokens")] public int? MaxTokens { get; set; }

        [JsonProperty("temperature")] public float? Temperature { get; set; }

        [JsonProperty("top_p")] public float? TopP { get; set; }

        [JsonProperty("n")] public int? N { get; set; }

        [JsonProperty("stream")] public bool? Stream { get; set; }

        [JsonProperty("logprobs")] public int? Logprobs { get; set; }

        [JsonProperty("echo")] public bool? Echo { get; set; }

        [JsonProperty("stop")] public List<string> Stop { get; set; }

        [JsonProperty("presence_penalty")] public float? PresencePenalty { get; set; }

        [JsonProperty("frequency_penalty")] public float? FrequencyPenalty { get; set; }

        [JsonProperty("best_of")] public int? BestOf { get; set; }

        [JsonProperty("logit_bias")] public Dictionary<string, int?> LogitBias { get; set; }

        [JsonProperty("user")] public string User { get; set; }

        public class Builder
        {
            private CreateCompletionRequest _request;

            public Builder()
            {
                _request = new CreateCompletionRequest();
            }

            public Builder SetModel(string model)
            {
                _request.Model = model;

                return this;
            }

            public Builder SetPrompt(List<string> prompt)
            {
                _request.Prompt = prompt;

                return this;
            }

            public Builder SetSuffix(string suffix)
            {
                _request.Suffix = suffix;

                return this;
            }

            public Builder SetMaxTokens(int? maxTokens)
            {
                _request.MaxTokens = maxTokens;

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

            public Builder SetN(int? n)
            {
                _request.N = n;

                return this;
            }

            public Builder SetStream(bool? stream)
            {
                _request.Stream = stream;

                return this;
            }

            public Builder SetLogprobs(int? logprobs)
            {
                _request.Logprobs = logprobs;

                return this;
            }

            public Builder SetEcho(bool? echo)
            {
                _request.Echo = echo;

                return this;
            }

            public Builder SetStop(List<string> stop)
            {
                _request.Stop = stop;

                return this;
            }

            public Builder SetPresencePenalty(float? presencePenalty)
            {
                _request.PresencePenalty = presencePenalty;

                return this;
            }

            public Builder SetFrequencyPenalty(float? frequencyPenalty)
            {
                _request.FrequencyPenalty = frequencyPenalty;

                return this;
            }

            public Builder SetBestOf(int? bestOf)
            {
                _request.BestOf = bestOf;

                return this;
            }

            public Builder SetLogitBias(Dictionary<string, int?> logitBias)
            {
                _request.LogitBias = logitBias;

                return this;
            }

            public Builder SetUser(string user)
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