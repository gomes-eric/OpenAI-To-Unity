using System;
using Newtonsoft.Json;

namespace Data.Entities.Common
{
    [Serializable]
    public class Choice
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("index")]
        public int? Index { get; set; }

        [JsonProperty("logprobs")]
        public int? Logprobs { get; set; }

        [JsonProperty("finish_reason")]
        public string FinishReason { get; set; }
    }
}