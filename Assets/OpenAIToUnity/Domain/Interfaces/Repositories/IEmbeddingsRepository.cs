using OpenAIToUnity.Domain.Entities.Requests;
using OpenAIToUnity.Domain.Entities.Responses;

namespace OpenAIToUnity.Domain.Interfaces.Repositories
{
    public interface IEmbeddingsRepository
    {
        public delegate void OnCreateEmbeddingsSuccessCallback(CreateEmbeddingsResponse response);

        public delegate void OnCreateEmbeddingsFailureCallback(Error error);

        public void CreateEmbeddings(CreateEmbeddingsRequest request, OnCreateEmbeddingsSuccessCallback onSuccessCallback, OnCreateEmbeddingsFailureCallback onFailureCallback);
    }
}
