using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Responses.Images
{
    public class Data
    {
        [JsonProperty("url")] public string Url { get; set; }
    }

    public class CreateImageResponse
    {
        [JsonProperty("created")] public int? Created { get; set; }

        [JsonProperty("data")] public List<Data> Data { get; set; }
    }

    public class CreateImageEditResponse
    {
        [JsonProperty("created")] public int? Created { get; set; }

        [JsonProperty("data")] public List<Data> Data { get; set; }
    }

    public class CreateImageVariationResponse
    {
        [JsonProperty("created")] public int? Created { get; set; }

        [JsonProperty("data")] public List<Data> Data { get; set; }
    }
}