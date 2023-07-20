namespace OpenAIToUnity.Domain.Constants
{
    public static class OpenAIConstants
    {
        // Configuration
        public const string ApiKey = "YOUR_API_KEY";
        public const string AuthenticationScheme = "Bearer";
        public const string PngMediaType = "image/png";
        public const int SecondsTimeout = 60;

        // Endpoints
        public const string ModelsEndpoint = "https://api.openai.com/v1/models";
        public const string CompletionsEndpoint = "https://api.openai.com/v1/completions";
        public const string ChatEndpoint = "https://api.openai.com/v1/chat";
        public const string EditsEndpoint = "https://api.openai.com/v1/edits";
        public const string ImagesEndpoint = "https://api.openai.com/v1/images";
        public const string EmbeddingsEndpoint = "https://api.openai.com/v1/embeddings";
    }
}
