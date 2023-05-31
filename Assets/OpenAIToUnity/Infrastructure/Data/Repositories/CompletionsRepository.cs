using System;
using System.Threading.Tasks;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;
using static OpenAIToUnity.Domain.Interfaces.Repositories.ICompletionsRepository;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class CompletionsRepository : ICompletionsRepository
    {
        public void CreateCompletion(CreateCompletionRequest request, OnCreateCompletionSuccessCallback onSuccessCallback, OnCreateCompletionFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(async () => await NetworkManager.PostRequest(
                    OpenAIConstants.CompletionsEndpoint,
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        #region Singleton

        private static CompletionsRepository _instance;

        private CompletionsRepository()
        {
        }

        public static CompletionsRepository Instance => _instance ??= new CompletionsRepository();

        #endregion
    }
}