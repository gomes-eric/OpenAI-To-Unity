using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Responses.Moderations
{
    public class CategoryScores
    {
        [JsonProperty("hate")] public double? Hate { get; set; }

        [JsonProperty("hate/threatening")] public double? HateThreatening { get; set; }

        [JsonProperty("self-harm")] public double? SelfHarm { get; set; }

        [JsonProperty("sexual")] public double? Sexual { get; set; }

        [JsonProperty("sexual/minors")] public double? SexualMinors { get; set; }

        [JsonProperty("violence")] public double? Violence { get; set; }

        [JsonProperty("violence/graphic")] public double? ViolenceGraphic { get; set; }
    }

    public class Categories
    {
        [JsonProperty("hate")] public bool? Hate { get; set; }

        [JsonProperty("hate/threatening")] public bool? HateThreatening { get; set; }

        [JsonProperty("self-harm")] public bool? SelfHarm { get; set; }

        [JsonProperty("sexual")] public bool? Sexual { get; set; }

        [JsonProperty("sexual/minors")] public bool? SexualMinors { get; set; }

        [JsonProperty("violence")] public bool? Violence { get; set; }

        [JsonProperty("violence/graphic")] public bool? ViolenceGraphic { get; set; }
    }

    public class Result
    {
        [JsonProperty("categories")] public Categories Categories { get; set; }

        [JsonProperty("category_scores")] public CategoryScores CategoryScores { get; set; }

        [JsonProperty("flagged")] public bool? Flagged { get; set; }
    }

    public class CreateModerationResponse
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("results")] public List<Result> Results { get; set; }
    }
}
