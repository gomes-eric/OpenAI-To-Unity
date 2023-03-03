using System;
using Data.Constants;
using Data.Entities.Requests;
using Data.Entities.Responses;
using Data.Utils;
using Domain.Interfaces.Repositories;
using Infrastructure.Network;
using UnityEngine;
using static Domain.Interfaces.Repositories.ICompletionsRepository;

namespace Data.Repositories
{
    public class CompletionsRepository : ICompletionsRepository
    {
        #region Singleton Pattern
        private static CompletionsRepository _instance;

        private CompletionsRepository() { }

        public static CompletionsRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CompletionsRepository();
                }

                return _instance;
            }
        }
        #endregion

        public void CreateCompletion(MonoBehaviour parent, CreateCompletionRequest request, OnCreateCompletionSuccessCallback onSuccessCallback, OnCreateCompletionFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.PostRequest<CreateCompletionResponse>(
                    OpenAiConstants.CompletionsEndpoint,
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