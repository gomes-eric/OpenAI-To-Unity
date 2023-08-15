using System;
using JetBrains.Annotations;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests.Chat;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IChatRepository;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class ChatRepository : IChatRepository
    {
        public ChatRepository([NotNull] MonoBehaviour parent, [NotNull] NetworkManager networkManager, [NotNull] string url)
        {
            Parent = parent;
            NetworkManager = networkManager;
            Url = url;
        }

        private MonoBehaviour Parent { get; }

        private NetworkManager NetworkManager { get; }

        private string Url { get; }

        public void CreateChatCompletion(CreateChatCompletionRequest request, OnCreateChatCompletionSuccessCallback onSuccessCallback, OnCreateChatCompletionFailureCallback onFailureCallback)
        {
            try
            {
                Parent.StartCoroutine(NetworkManager.JsonPostRequest(
                    $"{Url}/{OpenAIConstants.Endpoints.Chat}/completions",
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
    }
}
