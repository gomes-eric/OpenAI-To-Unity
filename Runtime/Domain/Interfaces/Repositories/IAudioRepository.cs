using OpenAIToUnity.Domain.Entities.Requests.Audio;
using OpenAIToUnity.Domain.Entities.Responses.Audio;
using OpenAIToUnity.Domain.Entities.Responses.Error;
using UnityEngine;

namespace OpenAIToUnity.Domain.Interfaces.Repositories
{
    public interface IAudioRepository
    {
        public delegate void OnCreateTranscriptionSuccessCallback(CreateTranscriptionResponse response);

        public delegate void OnCreateTranscriptionFailureCallback(Error error);

        public void CreateTranscription(CreateTranscriptionRequest request, OnCreateTranscriptionSuccessCallback onSuccessCallback, OnCreateTranscriptionFailureCallback onFailureCallback);

        public delegate void OnCreateTranslationSuccessCallback(CreateTranslationResponse response);

        public delegate void OnCreateTranslationFailureCallback(Error error);

        public void CreateTranslation(CreateTranslationRequest request, OnCreateTranslationSuccessCallback onSuccessCallback, OnCreateTranslationFailureCallback onFailureCallback);
    }
}
