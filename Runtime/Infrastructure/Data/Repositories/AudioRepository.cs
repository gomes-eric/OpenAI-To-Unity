using System;
using JetBrains.Annotations;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests.Audio;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IAudioRepository;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class AudioRepository : IAudioRepository
    {
        public AudioRepository([NotNull] MonoBehaviour parent, [NotNull] NetworkManager networkManager, [NotNull] string url)
        {
            Parent = parent;
            NetworkManager = networkManager;
            Url = url;
        }

        private MonoBehaviour Parent { get; }

        private NetworkManager NetworkManager { get; }

        private string Url { get; }

        public void CreateTranscription(CreateTranscriptionRequest request, OnCreateTranscriptionSuccessCallback onSuccessCallback, OnCreateTranscriptionFailureCallback onFailureCallback)
        {
            try
            {
                Parent.StartCoroutine(NetworkManager.FormPostRequest(
                    $"{Url}/{OpenAIConstants.Endpoints.Audio}/transcriptions",
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
                Parent.StartCoroutine(NetworkManager.FormPostRequest(
                    $"{Url}/{OpenAIConstants.Endpoints.Audio}/translations",
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
    }
}
