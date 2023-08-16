using System.Collections.Generic;
using Newtonsoft.Json;
using OpenAIToUnity.Domain.Types;

namespace OpenAIToUnity.Domain.Entities.Responses.FineTunes
{
    public class Event
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("level")] public string Level { get; set; }

        [JsonProperty("message")] public string Message { get; set; }

        [JsonProperty("created_at")] public int? CreatedAt { get; set; }
    }

    public class File
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("purpose")] public Purpose Purpose { get; set; }

        [JsonProperty("filename")] public string Filename { get; set; }

        [JsonProperty("bytes")] public int? Bytes { get; set; }

        [JsonProperty("created_at")] public int? CreatedAt { get; set; }

        [JsonProperty("status")] public FineTunesStatus Status { get; set; }

        [JsonProperty("status_details")] public string StatusDetails { get; set; }
    }

    public class Hyperparams
    {
        [JsonProperty("n_epochs")] public int? NEpochs { get; set; }

        [JsonProperty("batch_size")] public int? BatchSize { get; set; }

        [JsonProperty("prompt_loss_weight")] public double? PromptLossWeight { get; set; }

        [JsonProperty("learning_rate_multiplier")] public float? LearningRateMultiplier { get; set; }
    }


    public class Data
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("hyperparams")] public Hyperparams Hyperparams { get; set; }

        [JsonProperty("organization_id")] public string OrganizationId { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("training_files")] public List<File> TrainingFiles { get; set; }

        [JsonProperty("validation_files")] public List<File> ValidationFiles { get; set; }

        [JsonProperty("result_files")] public List<File> ResultFiles { get; set; }

        [JsonProperty("created_at")] public int? CreatedAt { get; set; }

        [JsonProperty("updated_at")] public int? UpdatedAt { get; set; }

        [JsonProperty("status")] public FineTunesStatus Status { get; set; }

        [JsonProperty("fine_tuned_model")] public string FineTunedModel { get; set; }
    }

    public class CreateFineTuneResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("hyperparams")] public Hyperparams Hyperparams { get; set; }

        [JsonProperty("organization_id")] public string OrganizationId { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("training_files")] public List<File> TrainingFiles { get; set; }

        [JsonProperty("validation_files")] public List<File> ValidationFiles { get; set; }

        [JsonProperty("result_files")] public List<File> ResultFiles { get; set; }

        [JsonProperty("created_at")] public int? CreatedAt { get; set; }

        [JsonProperty("updated_at")] public int? UpdatedAt { get; set; }

        [JsonProperty("status")] public FineTunesStatus Status { get; set; }

        [JsonProperty("fine_tuned_model")] public string FineTunedModel { get; set; }

        [JsonProperty("events")] public List<Event> Events { get; set; }
    }

    public class ListFineTunesResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("data")] public List<Data> Data { get; set; }
    }

    public class RetrieveFineTuneResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("hyperparams")] public Hyperparams Hyperparams { get; set; }

        [JsonProperty("organization_id")] public string OrganizationId { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("training_files")] public List<File> TrainingFiles { get; set; }

        [JsonProperty("validation_files")] public List<File> ValidationFiles { get; set; }

        [JsonProperty("result_files")] public List<File> ResultFiles { get; set; }

        [JsonProperty("created_at")] public int? CreatedAt { get; set; }

        [JsonProperty("updated_at")] public int? UpdatedAt { get; set; }

        [JsonProperty("status")] public FineTunesStatus Status { get; set; }

        [JsonProperty("fine_tuned_model")] public string FineTunedModel { get; set; }

        [JsonProperty("events")] public List<Event> Events { get; set; }
    }

    public class CancelFineTuneResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("hyperparams")] public Hyperparams Hyperparams { get; set; }

        [JsonProperty("organization_id")] public string OrganizationId { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("training_files")] public List<File> TrainingFiles { get; set; }

        [JsonProperty("validation_files")] public List<File> ValidationFiles { get; set; }

        [JsonProperty("result_files")] public List<File> ResultFiles { get; set; }

        [JsonProperty("created_at")] public int? CreatedAt { get; set; }

        [JsonProperty("updated_at")] public int? UpdatedAt { get; set; }

        [JsonProperty("status")] public FineTunesStatus Status { get; set; }

        [JsonProperty("fine_tuned_model")] public string FineTunedModel { get; set; }

        [JsonProperty("events")] public List<Event> Events { get; set; }
    }

    public class ListFineTuneEventsResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("data")] public List<Event> Data { get; set; }
    }

    public class DeleteFineTuneModelResponse
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("deleted")] public bool? Deleted { get; set; }
    }
}
