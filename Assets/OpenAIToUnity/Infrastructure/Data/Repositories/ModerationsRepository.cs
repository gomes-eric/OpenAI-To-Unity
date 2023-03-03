using System;
using Data.Constants;
using Data.Entities.Requests;
using Data.Entities.Responses;
using Data.Utils;
using Domain.Interfaces.Repositories;
using Infrastructure.Network;
using UnityEngine;
using static Domain.Interfaces.Repositories.IModerationsRepository;

namespace Data.Repositories
{
    public class ModerationsRepository : IModerationsRepository
    {
        #region Singleton Pattern
            private static ModerationsRepository _instance;
    
            private ModerationsRepository() { }
    
            public static ModerationsRepository Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new ModerationsRepository();
                    }
    
                    return _instance;
                }
            }
        #endregion

        public void CreateModeration(MonoBehaviour parent, CreateModerationRequest request, OnCreateModerationSuccessCallback onSuccessCallback, OnCreateModerationFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.PostRequest<CreateModerationResponse>(
                    OpenAiConstants.ModerationsEndpoint,
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