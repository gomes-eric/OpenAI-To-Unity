using OpenAIToUnity.Domain.Entities.Requests.Embeddings;
using OpenAIToUnity.Domain.Entities.Responses.Embeddings;
using OpenAIToUnity.Domain.Entities.Responses.Error;
using UnityEngine;

namespace OpenAIToUnity.Domain.Interfaces.Repositories
{
    public interface IEmbeddingsRepository
    {
        public delegate void OnCreateEmbeddingsSuccessCallback(CreateEmbeddingsResponse response);

        public delegate void OnCreateEmbeddingsFailureCallback(Error error);

        public void CreateEmbeddings(CreateEmbeddingsRequest request, OnCreateEmbeddingsSuccessCallback onSuccessCallback, OnCreateEmbeddingsFailureCallback onFailureCallback);
    }
}
