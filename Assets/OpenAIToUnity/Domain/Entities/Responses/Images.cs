using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Responses
{
    public struct ImagesData
    {
        [JsonProperty("url")] public string Url { get; set; }
    }

    public struct CreateImageResponse
    {
        [JsonProperty("created")] public int? Created { get; set; }

        [JsonProperty("data")] public List<ImagesData?> Data { get; set; }
    }

    public struct CreateImageEditResponse
    {
        [JsonProperty("created")] public int? Created { get; set; }

        [JsonProperty("data")] public List<ImagesData?> Data { get; set; }
    }

    public struct CreateImageVariationResponse
    {
        [JsonProperty("created")] public int? Created { get; set; }

        [JsonProperty("data")] public List<ImagesData?> Data { get; set; }
    }
}