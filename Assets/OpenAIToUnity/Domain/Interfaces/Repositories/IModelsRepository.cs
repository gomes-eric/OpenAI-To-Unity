using OpenAIToUnity.Domain.Entities.Requests;
using OpenAIToUnity.Domain.Entities.Responses;

namespace OpenAIToUnity.Domain.Interfaces.Repositories
{
    public interface IModelsRepository
    {
        public delegate void OnListModelsSuccessCallback(ListModelsResponse response);

        public delegate void OnListModelsFailureCallback(Error error);

        public delegate void OnRetrieveModelSuccessCallback(RetrieveModelResponse response);

        public delegate void OnRetrieveModelFailureCallback(Error error);

        public void ListModels(OnListModelsSuccessCallback onSuccessCallback, OnListModelsFailureCallback onFailureCallback);

        public void RetrieveModel(RetrieveModelRequest request, OnRetrieveModelSuccessCallback onSuccessCallback, OnRetrieveModelFailureCallback onFailureCallback);
    }
}