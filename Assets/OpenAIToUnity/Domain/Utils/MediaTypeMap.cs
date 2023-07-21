using System.Collections.Generic;

namespace OpenAIToUnity.Domain.Utils
{
    public static class MediaTypeMap
    {
        private static readonly Dictionary<string, string> ExtensionToMediaTypeMap = new Dictionary<string, string>
        {
            { ".png", "image/png" },
            { ".mp3", "audio/mpeg" },
            { ".mp4", "video/mp4" },
            { ".mpeg", "video/mpeg" },
            { ".mpga", "audio/mpeg" },
            { ".m4a", "audio/mp4" },
            { ".wav", "audio/wav" },
            { ".webm", "video/webm" },
            { ".jsonl", "application/json+line" },
        };

        public static string GetMediaType(string extension)
        {
            return ExtensionToMediaTypeMap[extension];
        }
    }
}
