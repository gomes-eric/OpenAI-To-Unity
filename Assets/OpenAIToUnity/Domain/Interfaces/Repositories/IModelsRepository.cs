using Data.Entities.Requests;
using Data.Entities.Responses;
using Domain.Entities.Responses;
using UnityEngine;

namespace Domain.Interfaces.Repositories
{
    public interface IModelsRepository
    {
        public delegate void OnListModelsSuccessCallback(ListModelsResponse response);
        public delegate void OnListModelsFailureCallback(Error error);
        public void ListModels(MonoBehaviour parent, OnListModelsSuccessCallback onSuccessCallback, OnListModelsFailureCallback onFailureCallback);

        public delegate void OnRetrieveModelSuccessCallback(RetrieveModelResponse response);
        public delegate void OnRetrieveModelFailureCallback(Error error);
        public void RetrieveModel(MonoBehaviour parent, RetrieveModelRequest request, OnRetrieveModelSuccessCallback onSuccessCallback, OnRetrieveModelFailureCallback onFailureCallback);
    }
}