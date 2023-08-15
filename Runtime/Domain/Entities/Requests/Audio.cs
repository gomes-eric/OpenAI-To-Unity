using System.IO;
using Newtonsoft.Json;
using OpenAIToUnity.Domain.Types;

namespace OpenAIToUnity.Domain.Entities.Requests.Audio
{
    public class CreateTranscriptionRequest
    {
        private CreateTranscriptionRequest()
        {
        }

        [JsonProperty("file")] public FileStream File { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("prompt")] public string Prompt { get; set; }

        [JsonProperty("response_format")] public AudioResponseFormat ResponseFormat { get; set; }

        [JsonProperty("temperature")] public string Temperature { get; set; }

        [JsonProperty("language")] public Language Language { get; set; }

        public class Builder
        {
            private readonly CreateTranscriptionRequest _request = new();

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
                _request.ResponseFormat = responseFormat;

                return this;
            }

            public Builder SetTemperature(string temperature)
            {
                _request.Temperature = temperature;

                return this;
            }

            public Builder SetLanguage(Language language)
            {
                _request.Language = language;

                return this;
            }

            public CreateTranscriptionRequest Build()
            {
                return _request;
            }
        }
    }

    public class CreateTranslationRequest
    {
        private CreateTranslationRequest()
        {
        }

        [JsonProperty("file")] public FileStream File { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("prompt")] public string Prompt { get; set; }

        [JsonProperty("response_format")] public AudioResponseFormat ResponseFormat { get; set; }

        [JsonProperty("temperature")] public string Temperature { get; set; }

        public class Builder
        {
            private readonly CreateTranslationRequest _request = new();

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
                _request.ResponseFormat = responseFormat;

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
