using System;
using System.Threading.Tasks;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests;
using OpenAIToUnity.Domain.Entities.Responses;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IModelsRepository;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class ModelsRepository : IModelsRepository
    {
        public void ListModels(OnListModelsSuccessCallback onSuccessCallback, OnListModelsFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(() => NetworkManager.JsonGetRequest<string, ListModelsResponse>(
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

        public void RetrieveModel(RetrieveModelRequest request, OnRetrieveModelSuccessCallback onSuccessCallback, OnRetrieveModelFailureCallback onFailureCallback)
        {
            Task.Run(() => NetworkManager.JsonGetRequest(
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
