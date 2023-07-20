using System;
using System.Threading.Tasks;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IChatRepository;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class ChatRepository : IChatRepository
    {
        public void CreateChatCompletion(CreateChatCompletionRequest request, OnCreateChatCompletionSuccessCallback onSuccessCallback, OnCreateChatCompletionFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(() => NetworkManager.JsonPostRequest(
                    $"{OpenAIConstants.ChatEndpoint}/completions",
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()
                ));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        #region Singleton

        private static ChatRepository _instance;

        private ChatRepository()
        {
        }

        public static ChatRepository Instance => _instance ??= new ChatRepository();

        #endregion
    }
}
