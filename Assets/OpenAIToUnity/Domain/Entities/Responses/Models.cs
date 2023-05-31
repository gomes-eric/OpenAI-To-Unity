using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Responses
{
    public struct Permission
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("created")] public int? Created { get; set; }

        [JsonProperty("allow_create_engine")] public bool? AllowCreateEngine { get; set; }

        [JsonProperty("allow_sampling")] public bool? AllowSampling { get; set; }

        [JsonProperty("allow_logprobs")] public bool? AllowLogprobs { get; set; }

        [JsonProperty("allow_search_indices")] public bool? AllowSearchIndices { get; set; }

        [JsonProperty("allow_view")] public bool? AllowView { get; set; }

        [JsonProperty("allow_fine_tuning")] public bool? AllowFineTuning { get; set; }

        [JsonProperty("organization")] public string Organization { get; set; }

        [JsonProperty("group")] public string Group { get; set; }

        [JsonProperty("is_blocking")] public bool? IsBlocking { get; set; }
    }

    public struct Model
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("created")] public int? Created { get; set; }

        [JsonProperty("owned_by")] public string OwnedBy { get; set; }

        [JsonProperty("permission")] public List<Permission?> Permission { get; set; }

        [JsonProperty("root")] public string Root { get; set; }

        [JsonProperty("parent")] public string Parent { get; set; }
    }

    public struct ListModelsResponse
    {
        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("data")] public List<Model?> Data { get; set; }
    }

    public struct RetrieveModelResponse
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("object")] public string Object { get; set; }

        [JsonProperty("created")] public int? Created { get; set; }

        [JsonProperty("owned_by")] public string OwnedBy { get; set; }

        [JsonProperty("permission")] public List<Permission?> Permission { get; set; }

        [JsonProperty("root")] public string Root { get; set; }

        [JsonProperty("parent")] public string Parent { get; set; }
    }
}