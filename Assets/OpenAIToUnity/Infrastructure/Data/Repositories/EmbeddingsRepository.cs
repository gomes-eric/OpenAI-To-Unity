using System;
using Data.Constants;
using Data.Entities.Requests;
using Data.Entities.Responses;
using Data.Utils;
using Domain.Interfaces.Repositories;
using Infrastructure.Network;
using UnityEngine;
using static Domain.Interfaces.Repositories.IEmbeddingsRepository;

namespace Data.Repositories
{
    public class EmbeddingsRepository : IEmbeddingsRepository
    {
        #region Singleton Pattern
            private static EmbeddingsRepository _instance;
    
            private EmbeddingsRepository() { }
    
            public static EmbeddingsRepository Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new EmbeddingsRepository();
                    }
    
                    return _instance;
                }
            }
        #endregion

        public void CreateEmbeddings(MonoBehaviour parent, CreateEmbeddingsRequest request, OnCreateEmbeddingsSuccessCallback onSuccessCallback, OnCreateEmbeddingsFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.PostRequest<CreateEmbeddingsResponse>(
                    OpenAiConstants.EmbeddingsEndpoint,
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