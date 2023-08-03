using System;
using System.Threading.Tasks;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests.Moderations;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IModerationsRepository;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class ModerationsRepository : IModerationsRepository
    {
        public void CreateModeration(CreateModerationRequest request, OnCreateModerationSuccessCallback onSuccessCallback, OnCreateModerationFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(() => NetworkManager.JsonPostRequest(
                    OpenAIConstants.ModerationsEndpoint,
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

        private static ModerationsRepository _instance;

        private ModerationsRepository()
        {
        }

        public static ModerationsRepository Instance => _instance ??= new ModerationsRepository();

        #endregion
    }
}
