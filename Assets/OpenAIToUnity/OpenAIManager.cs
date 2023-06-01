using OpenAIToUnity.Domain.Entities.Requests;
using OpenAIToUnity.Infrastructure.Data.Repositories;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IChatRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.ICompletionsRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IEditsRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IModelsRepository;

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
    }
}