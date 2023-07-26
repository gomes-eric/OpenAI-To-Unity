using OpenAIToUnity.Domain.Entities.Requests;
using OpenAIToUnity.Infrastructure.Data.Repositories;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IAudioRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IChatRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.ICompletionsRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IEditsRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IEmbeddingsRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IFilesRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IFineTunesRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IImagesRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IModelsRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IModerationsRepository;

namespace OpenAIToUnity
{
    public static class OpenAIManager
    {
        public static class Models
        {
            public static void ListModels(OnListModelsSuccessCallback onSuccessCallback, OnListModelsFailureCallback onFailureCallback)
            {
                ModelsRepository.Instance.ListModels(onSuccessCallback, onFailureCallback);
            }

            public static void RetrieveModel(RetrieveModelRequest request, OnRetrieveModelSuccessCallback onSuccessCallback, OnRetrieveModelFailureCallback onFailureCallback)
            {
                ModelsRepository.Instance.RetrieveModel(request, onSuccessCallback, onFailureCallback);
            }
        }

        public static class Completions
        {
            public static void CreateCompletion(CreateCompletionRequest request, OnCreateCompletionSuccessCallback onSuccessCallback, OnCreateCompletionFailureCallback onFailureCallback)
            {
                CompletionsRepository.Instance.CreateCompletion(request, onSuccessCallback, onFailureCallback);
            }
        }

        public static class Chat
        {
            public static void CreateChatCompletion(CreateChatCompletionRequest request, OnCreateChatCompletionSuccessCallback onSuccessCallback, OnCreateChatCompletionFailureCallback onFailureCallback)
            {
                ChatRepository.Instance.CreateChatCompletion(request, onSuccessCallback, onFailureCallback);
            }
        }

        public static class Edits
        {
            public static void CreateEdit(CreateEditRequest request, OnCreateEditSuccessCallback onSuccessCallback, OnCreateEditFailureCallback onFailureCallback)
            {
                EditsRepository.Instance.CreateEdit(request, onSuccessCallback, onFailureCallback);
            }
        }

        public static class Images
        {
            public static void CreateImage(CreateImageRequest request, OnCreateImageSuccessCallback onSuccessCallback, OnCreateImageFailureCallback onFailureCallback)
            {
                ImagesRepository.Instance.CreateImage(request, onSuccessCallback, onFailureCallback);
            }

            public static void CreateImageEdit(CreateImageEditRequest request, OnCreateImageEditSuccessCallback onSuccessCallback, OnCreateImageEditFailureCallback onFailureCallback)
            {
                ImagesRepository.Instance.CreateImageEdit(request, onSuccessCallback, onFailureCallback);
            }

            public static void CreateImageVariation(CreateImageVariationRequest request, OnCreateImageVariationSuccessCallback onSuccessCallback, OnCreateImageVariationFailureCallback onFailureCallback)
            {
                ImagesRepository.Instance.CreateImageVariation(request, onSuccessCallback, onFailureCallback);
            }
        }

        public static class Embeddings
        {
            public static void CreateEmbeddings(CreateEmbeddingsRequest request, OnCreateEmbeddingsSuccessCallback onSuccessCallback, OnCreateEmbeddingsFailureCallback onFailureCallback)
            {
                EmbeddingsRepository.Instance.CreateEmbeddings(request, onSuccessCallback, onFailureCallback);
            }
        }

        public static class Audio
        {
            public static void CreateTranscription(CreateTranscriptionRequest request, OnCreateTranscriptionSuccessCallback onSuccessCallback, OnCreateTranscriptionFailureCallback onFailureCallback)
            {
                AudioRepository.Instance.CreateTranscription(request, onSuccessCallback, onFailureCallback);
            }

            public static void CreateTranslation(CreateTranslationRequest request, OnCreateTranslationSuccessCallback onSuccessCallback, OnCreateTranslationFailureCallback onFailureCallback)
            {
                AudioRepository.Instance.CreateTranslation(request, onSuccessCallback, onFailureCallback);
            }
        }

        public static class Files
        {
            public static void ListFiles(OnListFilesSuccessCallback onSuccessCallback, OnListFilesFailureCallback onFailureCallback)
            {
                FilesRepository.Instance.ListFiles(onSuccessCallback, onFailureCallback);
            }

            public static void UploadFile(UploadFileRequest request, OnUploadFileSuccessCallback onSuccessCallback, OnUploadFileFailureCallback onFailureCallback)
            {
                FilesRepository.Instance.UploadFile(request, onSuccessCallback, onFailureCallback);
            }

            public static void DeleteFile(DeleteFileRequest request, OnDeleteFileSuccessCallback onSuccessCallback, OnDeleteFileFailureCallback onFailureCallback)
            {
                FilesRepository.Instance.DeleteFile(request, onSuccessCallback, onFailureCallback);
            }

            public static void RetrieveFile(RetrieveFileRequest request, OnRetrieveFileSuccessCallback onSuccessCallback, OnRetrieveFileFailureCallback onFailureCallback)
            {
                FilesRepository.Instance.RetrieveFile(request, onSuccessCallback, onFailureCallback);
            }

            public static void RetrieveFileContent(RetrieveFileContentRequest request, OnRetrieveFileContentSuccessCallback onSuccessCallback, OnRetrieveFileContentFailureCallback onFailureCallback)
            {
                FilesRepository.Instance.RetrieveFileContent(request, onSuccessCallback, onFailureCallback);
            }
        }

        public static class FineTunes
        {
            public static void CreateFineTune(CreateFineTuneRequest request, OnCreateFineTuneSuccessCallback onSuccessCallback, OnCreateFineTuneFailureCallback onFailureCallback)
            {
                FineTunesRepository.Instance.CreateFineTune(request, onSuccessCallback, onFailureCallback);
            }

            public static void ListFineTunes(OnListFineTunesSuccessCallback onSuccessCallback, OnListFineTunesFailureCallback onFailureCallback)
            {
                FineTunesRepository.Instance.ListFineTunes(onSuccessCallback, onFailureCallback);
            }

            public static void RetrieveFineTune(RetrieveFineTuneRequest request, OnRetrieveFineTuneSuccessCallback onSuccessCallback, OnRetrieveFineTuneFailureCallback onFailureCallback)
            {
                FineTunesRepository.Instance.RetrieveFineTune(request, onSuccessCallback, onFailureCallback);
            }

            public static void CancelFineTune(CancelFineTuneRequest request, OnCancelFineTuneSuccessCallback onSuccessCallback, OnCancelFineTuneFailureCallback onFailureCallback)
            {
                FineTunesRepository.Instance.CancelFineTune(request, onSuccessCallback, onFailureCallback);
            }

            public static void ListFineTuneEvents(ListFineTuneEventsRequest request, OnListFineTuneEventsSuccessCallback onSuccessCallback, OnListFineTuneEventsFailureCallback onFailureCallback)
            {
                FineTunesRepository.Instance.ListFineTuneEvents(request, onSuccessCallback, onFailureCallback);
            }

            public static void DeleteFineTuneModel(DeleteFineTuneModelRequest request, OnDeleteFineTuneModelSuccessCallback onSuccessCallback, OnDeleteFineTuneModelFailureCallback onFailureCallback)
            {
                FineTunesRepository.Instance.DeleteFineTuneModel(request, onSuccessCallback, onFailureCallback);
            }
        }

        public static class Moderations
        {
            public static void CreateModeration(CreateModerationRequest request, OnCreateModerationSuccessCallback onSuccessCallback, OnCreateModerationFailureCallback onFailureCallback)
            {
                ModerationsRepository.Instance.CreateModeration(request, onSuccessCallback, onFailureCallback);
            }
        }
    }
}
