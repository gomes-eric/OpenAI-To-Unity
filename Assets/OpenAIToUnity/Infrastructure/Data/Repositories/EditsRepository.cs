using System;
using System.Threading.Tasks;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IEditsRepository;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class EditsRepository : IEditsRepository
    {
        public void CreateEdit(CreateEditRequest request, OnCreateEditSuccessCallback onSuccessCallback, OnCreateEditFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(() => NetworkManager.PostRequest(
                    OpenAIConstants.EditsEndpoint,
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

        private static EditsRepository _instance;

        private EditsRepository()
        {
        }

        public static EditsRepository Instance => _instance ??= new EditsRepository();

        #endregion
    }
}