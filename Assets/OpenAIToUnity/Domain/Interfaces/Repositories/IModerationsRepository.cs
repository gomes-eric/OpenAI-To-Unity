using Data.Entities.Requests;
using Data.Entities.Responses;
using Domain.Entities.Responses;
using UnityEngine;

namespace Domain.Interfaces.Repositories
{
    public interface IModerationsRepository
    {
        public delegate void OnCreateModerationSuccessCallback(CreateModerationResponse response);
        public delegate void OnCreateModerationFailureCallback(Error error);
        public void CreateModeration(MonoBehaviour parent, CreateModerationRequest request, OnCreateModerationSuccessCallback onSuccessCallback, OnCreateModerationFailureCallback onFailureCallback);
    }
}