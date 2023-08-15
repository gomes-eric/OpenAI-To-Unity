using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenAIToUnity.Domain.Types;
using OpenAIToUnity.Domain.Utils;

namespace OpenAIToUnity.Domain.Entities.Requests.Chat
{
    public class Parameters
    {
        private Parameters()
        {
        }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("properties")][JsonConverter(typeof(StringToJObjectConverter))] public JObject Properties { get; set; }

        [JsonProperty("required")] public List<string> Required { get; set; }

        public class Builder
        {
            private readonly Parameters _parameters = new();

            public Builder SetType(string type)
            {
                _parameters.Type = type;

                return this;
            }

            public Builder SetProperties(JObject properties)
            {
                _parameters.Properties = properties;

                return this;
            }

            public Builder SetRequired(List<string> required)
            {
                _parameters.Required = required;

                return this;
            }

            public Parameters Build()
            {
                return _parameters;
            }
        }
    }

    public class Function
    {
        private Function()
        {
        }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("parameters")] public Parameters Parameters { get; set; }

        public class Builder
        {
            private readonly Function _function = new();

            public Builder SetName(string name)
            {
                _function.Name = name;

                return this;
            }

            public Builder SetDescription(string description)
            {
                _function.Description = description;

                return this;
            }

            public Builder SetParameters(Parameters parameters)
            {
                _function.Parameters = parameters;

                return this;
            }

            public Function Build()
            {
                return _function;
            }
        }
    }

    public class FunctionCall
    {
        private FunctionCall()
        {
        }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("arguments")][JsonConverter(typeof(StringToJObjectConverter))] public JObject Arguments { get; set; }

        public class Builder
        {
            private readonly FunctionCall functionCall = new();

            public Builder SetName(string name)
            {
                functionCall.Name = name;

                return this;
            }

            public Builder SetArguments(JObject arguments)
            {
                functionCall.Arguments = arguments;

                return this;
            }

            public FunctionCall Build()
            {
                return functionCall;
            }
        }
    }

    public class Message
    {
        private Message()
        {
        }

        [JsonProperty("role")] public Role Role { get; set; }

        [JsonProperty("content")] public string Content { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("function_call")] public FunctionCall FunctionCall { get; set; }

        public class Builder
        {
            private readonly Message _message = new();

            public Builder SetRole(Role role)
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

            public Builder SetFunctionCall(FunctionCall functionCall)
            {
                _message.FunctionCall = functionCall;

                return this;
            }

            public Message Build()
            {
                return _message;
            }
        }
    }

    public class CreateChatCompletionRequest
    {
        private CreateChatCompletionRequest()
        {
        }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("messages")] public List<Message> Messages { get; set; }

        [JsonProperty("functions")] public List<Function> Functions { get; set; }

        [JsonProperty("function_call")] public FunctionCall FunctionCall { get; set; }

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
            private readonly CreateChatCompletionRequest _request = new();

            public Builder SetModel(string model)
            {
                _request.Model = model;

                return this;
            }

            public Builder SetMessages(List<Message> messages)
            {
                _request.Messages = messages;

                return this;
            }

            public Builder SetFunctions(List<Function> functions)
            {
                _request.Functions = functions;

                return this;
            }

            public Builder SetFunctionCall(FunctionCall functionCall)
            {
                _request.FunctionCall = functionCall;

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
