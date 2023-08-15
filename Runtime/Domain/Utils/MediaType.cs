using System.Collections.Generic;
using System.Linq;

namespace OpenAIToUnity.Domain.Utils
{
    public static class MediaType
    {
        private static readonly Dictionary<string, string> MediaTypes = new()
        {
            { Extensions.Application.Json, Names.Application.Json },
            { Extensions.Application.JsonLine, Names.Application.JsonLine },
            { Extensions.Image.Png, Names.Image.Png },
            { Extensions.Audio.Mpga, Names.Audio.Mpga },
            { Extensions.Audio.Mp3, Names.Audio.Mp3 },
            { Extensions.Audio.Mp4, Names.Audio.Mp4 },
            { Extensions.Audio.Wav, Names.Audio.Wav },
            { Extensions.Video.Mpeg, Names.Video.Mpeg },
            { Extensions.Video.Mp4, Names.Video.Mp4 },
            { Extensions.Video.Webm, Names.Video.Webm }
        };

        public static string GetMediaTypeName(string mediaTypeExtension)
        {
            return MediaTypes[mediaTypeExtension];
        }

        public static string GetMediaTypeExtension(string mediaTypeName)
        {
            return MediaTypes.First(x => x.Value == mediaTypeName).Key;
        }

        public static class Extensions
        {
            public static class Application
            {
                public const string Json = ".json";
                public const string JsonLine = ".jsonl";
            }

            public static class Image
            {
                public const string Png = ".png";
            }

            public static class Audio
            {
                public const string Mpga = ".mpga";
                public const string Mp3 = ".mp3";
                public const string Mp4 = ".m4a";
                public const string Wav = ".wav";
            }

            public static class Video
            {
                public const string Mpeg = ".mpeg";
                public const string Mp4 = ".mp4";
                public const string Webm = ".webm";
            }
        }

        public static class Names
        {
            public static class Application
            {
                public const string Json = "application/json";
                public const string JsonLine = "application/json+line";
            }

            public static class Image
            {
                public const string Png = "image/png";
            }

            public static class Audio
            {
                public const string Mpga = "audio/mpeg";
                public const string Mp3 = "audio/mpeg";
                public const string Mp4 = "audio/mp4";
                public const string Wav = "audio/wav";
            }

            public static class Video
            {
                public const string Mpeg = "video/mpeg";
                public const string Mp4 = "video/mp4";
                public const string Webm = "video/webm";
            }

            public static class Multipart
            {
                public const string Form = "multipart/form-data";
            }
        }
    }
}
