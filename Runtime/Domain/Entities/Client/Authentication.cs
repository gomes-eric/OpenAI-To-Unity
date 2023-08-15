namespace OpenAIToUnity
{
    public class Authentication
    {
        public Authentication(string apiKey, string organizationId)
        {
            ApiKey = apiKey;
            OrganizationId = organizationId;
        }

        public string ApiKey { get; }

        public string OrganizationId { get; }
    }
}
