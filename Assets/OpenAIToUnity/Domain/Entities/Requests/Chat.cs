using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Requests
{
    public struct Message
    {
        [JsonProperty("role")] public string Role { get; set; }

        [JsonProperty("content")] public string Content { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        public class Builder
        {
            private Message _message;

            public Builder()
            {
                _message = new Message();
            }

            public Builder SetRole(string role)
            {
                _message.Role = role;

                return this;
            }

            public Builder SetContent(string content)
            {
                _message.Content = content;

                return this;
            }

            public Builder SetName(string name)
            {
                _message.Name = name;

                return this;
            }

            public Message Build()
            {
                return _message;
            }
        }
    }

    public struct CreateChatCompletionRequest
    {
        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("messages")] public List<Message?> Messages { get; set; }

        [JsonProperty("temperature")] public float? Temperature { get; set; }

        [JsonProperty("top_p")] public float? TopP { get; set; }

        [JsonProperty("n")] public int? N { get; set; }

        [JsonProperty("stream")] public bool? Stream { get; set; }

        [JsonProperty("stop")] public List<string> Stop { get; set; }

        [JsonProperty("max_tokens")] public int? MaxTokens { get; set; }

        [JsonProperty("presence_penalty")] public float? PresencePenalty { get; set; }

        [JsonProperty("frequency_penalty")] public float? FrequencyPenalty { get; set; }

        [JsonProperty("logit_bias")] public Dictionary<string, int?> LogitBias { get; set; }

        [JsonProperty("user")] public string User { get; set; }

        public class Builder
        {
            private CreateChatCompletionRequest _request;

            public Builder()
            {
                _request = new CreateChatCompletionRequest();
            }

            public Builder SetModel(string model)
            {
                _request.Model = model;

                return this;
            }

            public Builder SetMessages(List<Message?> messages)
            {
                _request.Messages = messages;

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

            public Builder SetStop(List<string> stop)
            {
                _request.Stop = stop;

                return this;
            }

            public Builder SetMaxTokens(int? maxTokens)
            {
                _request.MaxTokens = maxTokens;

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

            public CreateChatCompletionRequest Build()
            {
                return _request;
            }
        }
    }
}