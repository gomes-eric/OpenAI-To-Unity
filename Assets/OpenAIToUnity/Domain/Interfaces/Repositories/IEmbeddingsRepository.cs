using Data.Entities.Requests;
using Data.Entities.Responses;
using Domain.Entities.Responses;
using UnityEngine;

namespace Domain.Interfaces.Repositories
{
    public interface IEmbeddingsRepository
    {
        public delegate void OnCreateEmbeddingsSuccessCallback(CreateEmbeddingsResponse response);
        public delegate void OnCreateEmbeddingsFailureCallback(Error error);
        public void CreateEmbeddings(MonoBehaviour parent, CreateEmbeddingsRequest request, OnCreateEmbeddingsSuccessCallback onSuccessCallback, OnCreateEmbeddingsFailureCallback onFailureCallback);
    }
}