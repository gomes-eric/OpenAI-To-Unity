using OpenAIToUnity.Domain.Constants;

namespace OpenAIToUnity
{
    public class Settings
    {
        public Settings(string protocol = OpenAIConstants.Settings.DefaultProtocol, string domain = OpenAIConstants.Settings.DefaultDomain, string version = OpenAIConstants.Settings.DefaultVersion)
        {
            Protocol = protocol;
            Domain = domain;
            Version = version;
            Url = $"{Protocol}://{Domain}/{Version}";
        }

        public string Protocol { get; }

        public string Domain { get; }

        public string Version { get; }

        public string Url { get; }
    }
}
