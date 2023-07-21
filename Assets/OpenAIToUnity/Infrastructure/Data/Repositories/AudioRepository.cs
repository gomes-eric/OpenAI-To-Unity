using System;
using System.Threading.Tasks;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IAudioRepository;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class AudioRepository : IAudioRepository
    {
        public void CreateTranscription(CreateTranscriptionRequest request, OnCreateTranscriptionSuccessCallback onSuccessCallback, OnCreateTranscriptionFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(() => NetworkManager.FormPostRequest(
                    $"{OpenAIConstants.AudioEndpoint}/transcriptions",
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

        public void CreateTranslation(CreateTranslationRequest request, OnCreateTranslationSuccessCallback onSuccessCallback, OnCreateTranslationFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(() => NetworkManager.FormPostRequest(
                    $"{OpenAIConstants.AudioEndpoint}/translations",
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

        private static AudioRepository _instance;

        private AudioRepository()
        {
        }

        public static AudioRepository Instance => _instance ??= new AudioRepository();

        #endregion
    }
}
