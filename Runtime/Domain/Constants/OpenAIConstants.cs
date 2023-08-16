namespace OpenAIToUnity.Domain.Constants
{
    public static class OpenAIConstants
    {
        public static class Settings
        {
            public const string DefaultProtocol = "https";
            public const string DefaultDomain = "api.openai.com";
            public const string DefaultVersion = "v1";
        }

        public static class Environment
        {
            public const string ApiKey = "OPENAI_API_KEY";
            public const string OrganizationId = "OPENAI_ORGANIZATION_ID ";
        }

        public static class Endpoints
        {
            public const string Models = "models";
            public const string Completions = "completions";
            public const string Chat = "chat";
            public const string Edits = "edits";
            public const string Images = "images";
            public const string Embeddings = "embeddings";
            public const string Audio = "audio";
            public const string Files = "files";
            public const string FineTunes = "fine-tunes";
            public const string Moderations = "moderations";
        }

        public static class Http
        {
            public const string Accept = "Accept";
            public const string Authorization = "Authorization";
            public const string Bearer = "Bearer";
            public const string ContentDisposition = "Content-Disposition";
            public const string ContentType = "Content-Type";
            public const string OpenAIOrganization = "OpenAI-Organization";
            public const int SecondsTimeout = 60;
        }
    }
}
