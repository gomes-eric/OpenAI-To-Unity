using System.IO;
using Newtonsoft.Json;
using OpenAIToUnity.Domain.Types;
using OpenAIToUnity.Domain.Utils;

namespace OpenAIToUnity.Domain.Entities.Requests
{
    public struct CreateTranscriptionRequest
    {
        [JsonProperty("file")] public FileStream File { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("prompt")] public string Prompt { get; set; }

        [JsonProperty("response_format")] public string ResponseFormat { get; set; }

        [JsonProperty("temperature")] public string Temperature { get; set; }

        [JsonProperty("language")] public string Language { get; set; }

        public class Builder
        {
            private CreateTranscriptionRequest _request;

            public Builder()
            {
                _request = new CreateTranscriptionRequest();
            }

            public Builder SetFile(FileStream file)
            {
                _request.File = file;

                return this;
            }

            public Builder SetModel(string model)
            {
                _request.Model = model;

                return this;
            }

            public Builder SetPrompt(string prompt)
            {
                _request.Prompt = prompt;

                return this;
            }

            public Builder SetResponseFormat(AudioResponseFormat responseFormat)
            {
                _request.ResponseFormat = responseFormat.ToFormat();

                return this;
            }

            public Builder SetTemperature(string temperature)
            {
                _request.Temperature = temperature;

                return this;
            }

            public Builder SetLanguage(Language language)
            {
                _request.Language = language.ToCode();

                return this;
            }

            public CreateTranscriptionRequest Build()
            {
                return _request;
            }
        }
    }

    public struct CreateTranslationRequest
    {
        [JsonProperty("file")] public FileStream File { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("prompt")] public string Prompt { get; set; }

        [JsonProperty("response_format")] public string ResponseFormat { get; set; }

        [JsonProperty("temperature")] public string Temperature { get; set; }

        public class Builder
        {
            private CreateTranslationRequest _request;

            public Builder()
            {
                _request = new CreateTranslationRequest();
            }

            public Builder SetFile(FileStream file)
            {
                _request.File = file;

                return this;
            }

            public Builder SetModel(string model)
            {
                _request.Model = model;

                return this;
            }

            public Builder SetPrompt(string prompt)
            {
                _request.Prompt = prompt;

                return this;
            }

            public Builder SetResponseFormat(AudioResponseFormat responseFormat)
            {
                _request.ResponseFormat = responseFormat.ToFormat();

                return this;
            }

            public Builder SetTemperature(string temperature)
            {
                _request.Temperature = temperature;

                return this;
            }

            public CreateTranslationRequest Build()
            {
                return _request;
            }
        }
    }
}
