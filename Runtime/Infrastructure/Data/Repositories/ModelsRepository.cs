using System;
using JetBrains.Annotations;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests.Models;
using OpenAIToUnity.Domain.Entities.Responses.Models;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IModelsRepository;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class ModelsRepository : IModelsRepository
    {
        public ModelsRepository([NotNull] MonoBehaviour parent, [NotNull] NetworkManager networkManager, [NotNull] string url)
        {
            Parent = parent;
            NetworkManager = networkManager;
            Url = url;
        }

        private MonoBehaviour Parent { get; }

        private NetworkManager NetworkManager { get; }

        private string Url { get; }

        public void ListModels(OnListModelsSuccessCallback onSuccessCallback, OnListModelsFailureCallback onFailureCallback)
        {
            try
            {
                Parent.StartCoroutine(NetworkManager.JsonGetRequest<string, ListModelsResponse>(
                    $"{Url}/{OpenAIConstants.Endpoints.Models}",
                    null,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()
                ));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void RetrieveModel(RetrieveModelRequest request, OnRetrieveModelSuccessCallback onSuccessCallback, OnRetrieveModelFailureCallback onFailureCallback)
        {
            Parent.StartCoroutine(NetworkManager.JsonGetRequest(
                $"{Url}/{OpenAIConstants.Endpoints.Models}/{{model}}",
                request,
                onSuccessCallback.ToAction(),
                onFailureCallback.ToAction()
            ));
        }
    }
}
