using Data.Entities.Requests;
using Data.Entities.Responses;
using Domain.Entities.Responses;
using UnityEngine;

namespace Domain.Interfaces.Repositories
{
    public interface ICompletionsRepository
    {
        public delegate void OnCreateCompletionSuccessCallback(CreateCompletionResponse response);
        public delegate void OnCreateCompletionFailureCallback(Error error);
        public void CreateCompletion(MonoBehaviour parent, CreateCompletionRequest request, OnCreateCompletionSuccessCallback onSuccessCallback, OnCreateCompletionFailureCallback onFailureCallback);
    }
}