namespace OpenAIToUnity.Domain.Constants
{
    public static class OpenAIConstants
    {
        // Configuration
        public const string ApiKey = "YOUR_API_KEY";
        public const string AuthenticationScheme = "Bearer";
        public const string MediaType = "application/json";
        public const int SecondsTimeout = 5;

        // Endpoints
        public const string ModelsEndpoint = "https://api.openai.com/v1/models";
        public const string CompletionsEndpoint = "https://api.openai.com/v1/completions";
        public const string ChatEndpoint = "https://api.openai.com/v1/chat/completions";
    }
}