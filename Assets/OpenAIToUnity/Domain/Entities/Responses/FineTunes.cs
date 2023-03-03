using System;
using System.Collections.Generic;
using Data.Entities.Common;
using Data.Interfaces;
using Newtonsoft.Json;

namespace Data.Entities.Responses
{
    [Serializable]
    public class Event
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("created_at")]
        public int? CreatedAt { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }

    [Serializable]
    public class Hyperparams
    {
        [JsonProperty("batch_size")]
        public int? BatchSize { get; set; }

        [JsonProperty("learning_rate_multiplier")]
        public double? LearningRateMultiplier { get; set; }

        [JsonProperty("n_epochs")]
        public int? NEpochs { get; set; }

        [JsonProperty("prompt_loss_weight")]
        public double? PromptLossWeight { get; set; }
    }

    [Serializable]
    public class FineTune
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("created_at")]
        public int? CreatedAt { get; set; }

        [JsonProperty("fine_tuned_model")]
        public string FineTunedModel { get; set; }

        [JsonProperty("hyperparams")]
        public Hyperparams Hyperparams { get; set; }

        [JsonProperty("organization_id")]
        public string OrganizationId { get; set; }

        [JsonProperty("result_files")]
        public List<File> ResultFiles { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("validation_files")]
        public List<File> ValidationFiles { get; set; }

        [JsonProperty("training_files")]
        public List<File> TrainingFiles { get; set; }

        [JsonProperty("updated_at")]
        public int? UpdatedAt { get; set; }
    }

    [Serializable]
    public class CreateFineTuneResponse : FineTune, Response
    {
        [JsonProperty("events")]
        public List<Event> Events { get; set; }
    }

    [Serializable]
    public class ListFineTunesResponse : Response
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("data")]
        public List<FineTune> Data { get; set; }
    }

    [Serializable]
    public class RetrieveFineTuneResponse : FineTune, Response
    {
        [JsonProperty("events")]
        public List<Event> Events { get; set; }
    }

    [Serializable]
    public class CancelFineTuneResponse : FineTune, Response
    {
        [JsonProperty("events")]
        public List<Event> Events { get; set; }
    }

    [Serializable]
    public class ListFineTuneEventsResponse : Response
    {
        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("data")]
        public List<Event> Data { get; set; }
    }

    [Serializable]
    public class DeleteFineTuneModelResponse : Response
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }
    }
}