using System.ComponentModel;

namespace OpenAIToUnity.Domain.Types
{
    public enum ImageResponseFormat
    {
        [Description("url")] Url,
        [Description("b64_json")] B64Json
    }

    public enum AudioResponseFormat
    {
        [Description("json")] Json,
        [Description("text")] Text,
        [Description("srt")] Srt,
        [Description("verbose_json")] VerboseJson,
        [Description("vtt")] Vtt
    }
}
