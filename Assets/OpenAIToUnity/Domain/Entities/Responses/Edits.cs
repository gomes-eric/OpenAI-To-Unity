using System;
using System.Collections.Generic;
using Data.Entities.Common;
using Data.Interfaces;
using Newtonsoft.Json;

namespace Data.Entities.Responses
{
    [Serializable]
    public class CreateEditResponse : Response
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("created")]
        public int? Created { get; set; }

        [JsonProperty("choices")]
        public List<Choice> Choices { get; set; }

        [JsonProperty("usage")]
        public Usage Usage { get; set; }
    }
}