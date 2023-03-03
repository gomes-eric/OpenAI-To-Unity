using System;
using System.Collections.Generic;
using Data.Interfaces;
using Newtonsoft.Json;

namespace Data.Entities.Responses
{
    [Serializable]
    public class Categories
    {
        public bool? Hate { get; set; }

        [JsonProperty("hate/threatening")]
        public bool? HateThreatening { get; set; }

        [JsonProperty("self-harm")]
        public bool? SelfHarm { get; set; }
        public bool? Sexual { get; set; }

        [JsonProperty("sexual/minors")]
        public bool? SexualMinors { get; set; }
        public bool? Violence { get; set; }

        [JsonProperty("violence/graphic")]
        public bool? ViolenceGraphic { get; set; }
    }

    [Serializable]
    public class CategoryScores
    {
        public double? Hate { get; set; }

        [JsonProperty("hate/threatening")]
        public double? HateThreatening { get; set; }

        [JsonProperty("self-harm")]
        public double? SelfHarm { get; set; }
        public double? Sexual { get; set; }

        [JsonProperty("sexual/minors")]
        public double? SexualMinors { get; set; }
        public double? Violence { get; set; }

        [JsonProperty("violence/graphic")]
        public double? ViolenceGraphic { get; set; }
    }

    [Serializable]
    public class Result
    {
        public Categories Categories { get; set; }
        public CategoryScores CategoryScores { get; set; }
        public bool? Flagged { get; set; }
    }

    [Serializable]
    public class CreateModerationResponse : Response
    {
        public string Id { get; set; }
        public string Model { get; set; }
        public List<Result> Results { get; set; }
    }
}