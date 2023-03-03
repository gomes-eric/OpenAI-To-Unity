using Data.Entities.Requests;
using Data.Repositories;
using Domain.Interfaces.Repositories;
using UnityEngine;
using static Domain.Interfaces.Repositories.ICompletionsRepository;
using static Domain.Interfaces.Repositories.IEditsRepository;
using static Domain.Interfaces.Repositories.IEmbeddingsRepository;
using static Domain.Interfaces.Repositories.IFineTunesRepository;
using static Domain.Interfaces.Repositories.IImagesRepository;
using static Domain.Interfaces.Repositories.IModelsRepository;
using static Domain.Interfaces.Repositories.IModerationsRepository;

public static class OpenAIManager
{
    /// <summary>
    /// Given a prompt, the model will return one or more predicted completions, and can also return the probabilities of alternative tokens at each position.
    /// <see href="https://platform.openai.com/docs/api-reference/completions"/>
    /// </summary>
    public static class Completions
    {
        /// <summary>
        /// Creates a completion for the provided prompt and parameters
        /// <see href="https://platform.openai.com/docs/api-reference/completions/create"/>
        /// </summary>
        public static void CreateCompletion(MonoBehaviour parent, CreateCompletionRequest request, OnCreateCompletionSuccessCallback onSuccessCallback, OnCreateCompletionFailureCallback onFailureCallback)
        {
            CompletionsRepository.Instance.CreateCompletion(parent, request, onSuccessCallback, onFailureCallback);
        }
    }

    /// <summary>
    /// Given a prompt and an instruction, the model will return an edited version of the prompt.
    /// <see href="https://platform.openai.com/docs/api-reference/edits"/>
    /// </summary>
    public static class Edits
    {
        /// <summary>
        /// Creates a new edit for the provided input, instruction, and parameters.
        /// <see href="https://platform.openai.com/docs/api-reference/edits/create"/>
        /// </summary>
        public static void CreateEdit(MonoBehaviour parent, CreateEditRequest request, OnCreateEditSuccessCallback onSuccessCallback, OnCreateEditFailureCallback onFailureCallback)
        {
            EditsRepository.Instance.CreateEdit(parent, request, onSuccessCallback, onFailureCallback);
        }
    }

    /// <summary>
    /// Get a vector representation of a given input that can be easily consumed by machine learning models and algorithms.
    /// <see href="https://platform.openai.com/docs/api-reference/embeddings"/>
    /// </summary>
    public static class Embeddings
    {
        /// <summary>
        /// Creates an embedding vector representing the input text.
        /// <see href="https://platform.openai.com/docs/api-reference/embeddings/create"/>
        /// </summary>
        public static void CreateEmbeddings(MonoBehaviour parent, CreateEmbeddingsRequest request, OnCreateEmbeddingsSuccessCallback onSuccessCallback, OnCreateEmbeddingsFailureCallback onFailureCallback)
        {
            EmbeddingsRepository.Instance.CreateEmbeddings(parent, request, onSuccessCallback, onFailureCallback);
        }
    }

    /// <summary>
    /// Files are used to upload documents that can be used with features like Fine-tuning.
    /// <see href="https://platform.openai.com/docs/api-reference/files"/>
    /// </summary>
    public static class Files
    {
        /// <summary>
        /// Returns a list of files that belong to the user's organization.
        /// <see href="https://platform.openai.com/docs/api-reference/files/list"/>
        /// </summary>
        public static void ListFiles(MonoBehaviour parent, IFilesRepository.OnListFilesSuccessCallback onSuccessCallback, IFilesRepository.OnListFilesFailureCallback onFailureCallback)
        {
            FilesRepository.Instance.ListFiles(parent, onSuccessCallback, onFailureCallback);
        }

        /// <summary>
        /// Upload a file that contains document(s) to be used across various endpoints/features. Currently, the size of all the files uploaded by one organization can be up to 1 GB. Please contact us if you need to increase the storage limit.
        /// <see href="https://platform.openai.com/docs/api-reference/files/upload"/>
        /// </summary>
        public static void UploadFile(MonoBehaviour parent, UploadFileRequest request, IFilesRepository.OnUploadFileSuccessCallback onSuccessCallback, IFilesRepository.OnUploadFileFailureCallback onFailureCallback)
        {
            FilesRepository.Instance.UploadFile(parent, request, onSuccessCallback, onFailureCallback);
        }

        /// <summary>
        /// Delete a file.
        /// <see href="https://platform.openai.com/docs/api-reference/files/delete"/>
        /// </summary>
        public static void DeleteFile(MonoBehaviour parent, DeleteFileRequest request, IFilesRepository.OnDeleteFileSuccessCallback onSuccessCallback, IFilesRepository.OnDeleteFileFailureCallback onFailureCallback)
        {
            FilesRepository.Instance.DeleteFile(parent, request, onSuccessCallback, onFailureCallback);
        }

        /// <summary>
        /// Returns information about a specific file.
        /// <see href="https://platform.openai.com/docs/api-reference/files/retrieve"/>
        /// </summary>
        public static void RetrieveFile(MonoBehaviour parent, RetrieveFileRequest request, IFilesRepository.OnRetrieveFileSuccessCallback onSuccessCallback, IFilesRepository.OnRetrieveFileFailureCallback onFailureCallback)
        {
            FilesRepository.Instance.RetrieveFile(parent, request, onSuccessCallback, onFailureCallback);
        }

        /// <summary>
        /// Returns the contents of the specified file
        /// <see href="https://platform.openai.com/docs/api-reference/files/retrieve-content"/>
        /// </summary>
        public static void RetrieveFileContent(MonoBehaviour parent, RetrieveFileContentRequest request, IFilesRepository.OnRetrieveFileContentSuccessCallback onSuccessCallback, IFilesRepository.OnRetrieveFileContentFailureCallback onFailureCallback)
        {
            FilesRepository.Instance.RetrieveFileContent(parent, request, onSuccessCallback, onFailureCallback);
        }
    }

    /// <summary>
    /// Manage fine-tuning jobs to tailor a model to your specific training data.
    /// <see href="https://platform.openai.com/docs/api-reference/fine-tunes"/>
    /// </summary>
    public static class FineTunes
    {
        /// <summary>
        /// Creates a job that fine-tunes a specified model from a given dataset.
        /// Response includes details of the enqueued job including job status and the name of the fine-tuned models once complete.
        /// <see href="https://platform.openai.com/docs/api-reference/fine-tunes/create"/>
        /// </summary>
        public static void CreateFineTune(MonoBehaviour parent, CreateFineTuneRequest request, OnCreateFineTuneSuccessCallback onSuccessCallback, OnCreateFineTuneFailureCallback onFailureCallback)
        {
            FineTunesRepository.Instance.CreateFineTune(parent, request, onSuccessCallback, onFailureCallback);
        }

        /// <summary>
        /// List your organization's fine-tuning jobs
        /// <see href="https://platform.openai.com/docs/api-reference/fine-tunes/list"/>
        /// </summary>
        public static void ListFineTunes(MonoBehaviour parent, OnListFineTunesSuccessCallback onSuccessCallback, OnListFineTunesFailureCallback onFailureCallback)
        {
            FineTunesRepository.Instance.ListFineTunes(parent, onSuccessCallback, onFailureCallback);
        }

        /// <summary>
        /// Gets info about the fine-tune job.
        /// <see href="https://platform.openai.com/docs/api-reference/fine-tunes/retrieve"/>
        /// </summary>
        public static void RetrieveFineTune(MonoBehaviour parent, RetrieveFineTuneRequest request, OnRetrieveFineTuneSuccessCallback onSuccessCallback, OnRetrieveFineTuneFailureCallback onFailureCallback)
        {
            FineTunesRepository.Instance.RetrieveFineTune(parent, request, onSuccessCallback, onFailureCallback);
        }

        /// <summary>
        /// Immediately cancel a fine-tune job.
        /// <see href="https://platform.openai.com/docs/api-reference/fine-tunes/cancel"/>
        /// </summary>
        public static void CancelFineTune(MonoBehaviour parent, CancelFineTuneRequest request, OnCancelFineTuneSuccessCallback onSuccessCallback, OnCancelFineTuneFailureCallback onFailureCallback)
        {
            FineTunesRepository.Instance.CancelFineTune(parent, request, onSuccessCallback, onFailureCallback);
        }

        /// <summary>
        /// Get fine-grained status updates for a fine-tune job.
        /// <see href="https://platform.openai.com/docs/api-reference/fine-tunes/events"/>
        /// </summary>
        public static void ListFineTuneEvents(MonoBehaviour parent, ListFineTuneEventsRequest request, OnListFineTuneEventsSuccessCallback onSuccessCallback, OnListFineTuneEventsFailureCallback onFailureCallback)
        {
            FineTunesRepository.Instance.ListFineTuneEvents(parent, request, onSuccessCallback, onFailureCallback);
        }

        /// <summary>
        /// Delete a fine-tuned model. You must have the Owner role in your organization.
        /// <see href="https://platform.openai.com/docs/api-reference/fine-tunes/delete-model"/>
        /// </summary>
        public static void DeleteFineTuneModel(MonoBehaviour parent, DeleteFineTuneModelRequest request, OnDeleteFineTuneModelSuccessCallback onSuccessCallback, OnDeleteFineTuneModelFailureCallback onFailureCallback)
        {
            FineTunesRepository.Instance.DeleteFineTuneModel(parent, request, onSuccessCallback, onFailureCallback);
        }
    }

    /// <summary>
    /// Given a prompt and/or an input image, the model will generate a new image.
    /// <see href="https://platform.openai.com/docs/api-reference/images"/>
    /// </summary>
    public static class Images
    {
        /// <summary>
        /// Creates an image given a prompt.
        /// <see href="https://platform.openai.com/docs/api-reference/images/create"/>
        /// </summary>
        public static void CreateImage(MonoBehaviour parent, CreateImageRequest request, OnCreateImageSuccessCallback onSuccessCallback, OnCreateImageFailureCallback onFailureCallback)
        {
            ImagesRepository.Instance.CreateImage(parent, request, onSuccessCallback, onFailureCallback);
        }

        /// <summary>
        /// Creates an edited or extended image given an original image and a prompt.
        /// <see href="https://platform.openai.com/docs/api-reference/images/create-edit"/>
        /// </summary>
        public static void CreateImageEdit(MonoBehaviour parent, CreateImageEditRequest request, OnCreateImageEditSuccessCallback onSuccessCallback, OnCreateImageEditFailureCallback onFailureCallback)
        {
            ImagesRepository.Instance.CreateImageEdit(parent, request, onSuccessCallback, onFailureCallback);
        }

        /// <summary>
        /// Creates a variation of a given image.
        /// <see href="https://platform.openai.com/docs/api-reference/images/create-variation"/>
        /// </summary>
        public static void CreateImageVariation(MonoBehaviour parent, CreateImageVariationRequest request, OnCreateImageVariationSuccessCallback onSuccessCallback, OnCreateImageVariationFailureCallback onFailureCallback)
        {
            ImagesRepository.Instance.CreateImageVariation(parent, request, onSuccessCallback, onFailureCallback);
        }
    }

    /// <summary>
    /// List and describe the various models available in the API. You can refer to the Models documentation to understand what models are available and the differences between them.
    /// <see href="https://platform.openai.com/docs/api-reference/models"/>
    /// </summary>
    public static class Models
    {
        /// <summary>
        /// Lists the currently available models, and provides basic information about each one such as the owner and availability
        /// <see href="https://platform.openai.com/docs/api-reference/models/list"/>
        /// </summary>
        public static void ListModels(MonoBehaviour parent, OnListModelsSuccessCallback onSuccessCallback, OnListModelsFailureCallback onFailureCallback)
        {
            ModelsRepository.Instance.ListModels(parent, onSuccessCallback, onFailureCallback);
        }

        /// <summary>
        /// Retrieves a model instance, providing basic information about the model such as the owner and permissioning.
        /// <see href="https://platform.openai.com/docs/api-reference/models/retrieve"/>
        /// </summary>
        public static void RetrieveModel(MonoBehaviour parent, RetrieveModelRequest request, OnRetrieveModelSuccessCallback onSuccessCallback, OnRetrieveModelFailureCallback onFailureCallback)
        {
            ModelsRepository.Instance.RetrieveModel(parent, request, onSuccessCallback, onFailureCallback);
        }
    }

    /// <summary>
    /// Given a input text, outputs if the model classifies it as violating OpenAI's content policy.
    /// <see href="https://platform.openai.com/docs/api-reference/moderations"/>
    /// </summary>
    public static class Moderations
    {
        /// <summary>
        /// Classifies if text violates OpenAI's Content Policy
        /// <see href="https://platform.openai.com/docs/api-reference/moderations/create"/>
        /// </summary>
        public static void CreateModeration(MonoBehaviour parent, CreateModerationRequest request, OnCreateModerationSuccessCallback onSuccessCallback, OnCreateModerationFailureCallback onFailureCallback)
        {
            ModerationsRepository.Instance.CreateModeration(parent, request, onSuccessCallback, onFailureCallback);
        }
    }
}