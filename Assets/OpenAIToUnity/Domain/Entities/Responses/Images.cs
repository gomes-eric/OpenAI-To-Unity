using System;
using System.Collections.Generic;
using Data.Interfaces;
using Newtonsoft.Json;

namespace Data.Entities.Responses
{
    [Serializable]
    public class ImageData
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    [Serializable]
    public class CreateImageResponse : Response
    {
        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("data")]
        public List<ImageData> Data { get; set; }
    }

    [Serializable]
    public class CreateImageEditResponse : Response
    {
        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("data")]
        public List<ImageData> Data { get; set; }
    }

    [Serializable]
    public class CreateImageVariationResponse : Response
    {
        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("data")]
        public List<ImageData> Data { get; set; }
    }
}