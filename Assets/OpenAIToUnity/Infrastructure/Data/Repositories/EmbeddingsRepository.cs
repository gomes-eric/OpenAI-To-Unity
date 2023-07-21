using System;
using System.Threading.Tasks;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IEmbeddingsRepository;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class EmbeddingsRepository : IEmbeddingsRepository
    {
        public void CreateEmbeddings(CreateEmbeddingsRequest request, OnCreateEmbeddingsSuccessCallback onSuccessCallback, OnCreateEmbeddingsFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(() => NetworkManager.JsonPostRequest(
                    OpenAIConstants.EmbeddingsEndpoint,
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

        private static EmbeddingsRepository _instance;

        private EmbeddingsRepository()
        {
        }

        public static EmbeddingsRepository Instance => _instance ??= new EmbeddingsRepository();

        #endregion
    }
}
