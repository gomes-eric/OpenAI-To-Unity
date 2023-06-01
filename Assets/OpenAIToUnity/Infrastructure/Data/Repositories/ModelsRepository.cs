using System;
using System.Threading.Tasks;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests;
using OpenAIToUnity.Domain.Entities.Responses;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class ModelsRepository : IModelsRepository
    {
        public void ListModels(IModelsRepository.OnListModelsSuccessCallback onSuccessCallback, IModelsRepository.OnListModelsFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(() => NetworkManager.GetRequest<string, ListModelsResponse>(
                    OpenAIConstants.ModelsEndpoint,
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

        public void RetrieveModel(RetrieveModelRequest request, IModelsRepository.OnRetrieveModelSuccessCallback onSuccessCallback, IModelsRepository.OnRetrieveModelFailureCallback onFailureCallback)
        {
            Task.Run(() => NetworkManager.GetRequest(
                $"{OpenAIConstants.ModelsEndpoint}/{{model}}",
                request,
                onSuccessCallback.ToAction(),
                onFailureCallback.ToAction()
            ));
        }

        #region Singleton

        private static ModelsRepository _instance;

        private ModelsRepository()
        {
        }

        public static ModelsRepository Instance => _instance ??= new ModelsRepository();

        #endregion
    }
}