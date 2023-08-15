using System;
using JetBrains.Annotations;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests.Embeddings;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IEmbeddingsRepository;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class EmbeddingsRepository : IEmbeddingsRepository
    {
        public EmbeddingsRepository([NotNull] MonoBehaviour parent, [NotNull] NetworkManager networkManager, [NotNull] string url)
        {
            Parent = parent;
            NetworkManager = networkManager;
            Url = url;
        }

        private MonoBehaviour Parent { get; }

        private NetworkManager NetworkManager { get; }

        private string Url { get; }

        public void CreateEmbeddings(CreateEmbeddingsRequest request, OnCreateEmbeddingsSuccessCallback onSuccessCallback, OnCreateEmbeddingsFailureCallback onFailureCallback)
        {
            try
            {
                Parent.StartCoroutine(NetworkManager.JsonPostRequest(
                    $"{Url}/{OpenAIConstants.Endpoints.Embeddings}",
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
