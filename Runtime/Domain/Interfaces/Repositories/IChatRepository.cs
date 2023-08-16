using OpenAIToUnity.Domain.Entities.Requests.Chat;
using OpenAIToUnity.Domain.Entities.Responses.Chat;
using OpenAIToUnity.Domain.Entities.Responses.Error;
using UnityEngine;

namespace OpenAIToUnity.Domain.Interfaces.Repositories
{
    public interface IChatRepository
    {
        public delegate void OnCreateChatCompletionSuccessCallback(CreateChatCompletionResponse response);

        public delegate void OnCreateChatCompletionFailureCallback(Error error);

        public void CreateChatCompletion(CreateChatCompletionRequest request, OnCreateChatCompletionSuccessCallback onSuccessCallback, OnCreateChatCompletionFailureCallback onFailureCallback);
    }
}
