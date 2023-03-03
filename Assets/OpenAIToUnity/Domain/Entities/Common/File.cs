using System;
using Newtonsoft.Json;

namespace Data.Entities.Common
{
    [Serializable]
    public class File
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("bytes")]
        public int? Bytes { get; set; }

        [JsonProperty("created_at")]
        public int? CreatedAt { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("purpose")]
        public string Purpose { get; set; }
    }
}