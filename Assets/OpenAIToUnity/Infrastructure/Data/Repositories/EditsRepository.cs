using System;
using Data.Constants;
using Data.Entities.Requests;
using Data.Entities.Responses;
using Data.Utils;
using Domain.Interfaces.Repositories;
using Infrastructure.Network;
using UnityEngine;
using static Domain.Interfaces.Repositories.IEditsRepository;

namespace Data.Repositories
{
    public class EditsRepository : IEditsRepository
    {
        #region Singleton Pattern
            private static EditsRepository _instance;
    
            private EditsRepository() { }
    
            public static EditsRepository Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new EditsRepository();
                    }
    
                    return _instance;
                }
            }
        #endregion

        public void CreateEdit(MonoBehaviour parent, CreateEditRequest request, OnCreateEditSuccessCallback onSuccessCallback, OnCreateEditFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.PostRequest<CreateEditResponse>(
                    OpenAiConstants.EditsEndpoint,
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