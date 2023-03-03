using System;
using Data.Constants;
using Data.Entities.Requests;
using Data.Entities.Responses;
using Data.Utils;
using Domain.Interfaces.Repositories;
using Infrastructure.Network;
using UnityEngine;
using static Domain.Interfaces.Repositories.IModelsRepository;

namespace Data.Repositories
{
    public class ModelsRepository : IModelsRepository
    {
        #region Singleton Pattern
        private static ModelsRepository _instance;

        private ModelsRepository() { }

        public static ModelsRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ModelsRepository();
                }

                return _instance;
            }
        }
        #endregion

        public void ListModels(MonoBehaviour parent, OnListModelsSuccessCallback onSuccessCallback, OnListModelsFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.GetRequest<ListModelsResponse>(
                    OpenAiConstants.ModelsEndpoint,
                    null,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void RetrieveModel(MonoBehaviour parent, RetrieveModelRequest request, OnRetrieveModelSuccessCallback onSuccessCallback, OnRetrieveModelFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.GetRequest<RetrieveModelResponse>(
                    $"{OpenAiConstants.ModelsEndpoint}/{{model}}",
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}