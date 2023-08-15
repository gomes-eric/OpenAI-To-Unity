using OpenAIToUnity.Domain.Entities.Requests.Models;
using OpenAIToUnity.Domain.Entities.Responses.Error;
using OpenAIToUnity.Domain.Entities.Responses.Models;
using UnityEngine;

namespace OpenAIToUnity.Domain.Interfaces.Repositories
{
    public interface IModelsRepository
    {
        public delegate void OnListModelsSuccessCallback(ListModelsResponse response);

        public delegate void OnListModelsFailureCallback(Error error);

        public void ListModels(OnListModelsSuccessCallback onSuccessCallback, OnListModelsFailureCallback onFailureCallback);

        public delegate void OnRetrieveModelSuccessCallback(RetrieveModelResponse response);

        public delegate void OnRetrieveModelFailureCallback(Error error);

        public void RetrieveModel(RetrieveModelRequest request, OnRetrieveModelSuccessCallback onSuccessCallback, OnRetrieveModelFailureCallback onFailureCallback);
    }
}
