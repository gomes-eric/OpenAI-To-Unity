using OpenAIToUnity.Domain.Entities.Requests.Moderations;
using OpenAIToUnity.Domain.Entities.Responses.Error;
using OpenAIToUnity.Domain.Entities.Responses.Moderations;
using UnityEngine;

namespace OpenAIToUnity.Domain.Interfaces.Repositories
{
    public interface IModerationsRepository
    {
        public delegate void OnCreateModerationSuccessCallback(CreateModerationResponse response);

        public delegate void OnCreateModerationFailureCallback(Error error);

        public void CreateModeration(CreateModerationRequest request, OnCreateModerationSuccessCallback onSuccessCallback, OnCreateModerationFailureCallback onFailureCallback);
    }
}
