using Data.Entities.Requests;
using Data.Entities.Responses;
using Domain.Entities.Responses;
using UnityEngine;

namespace Domain.Interfaces.Repositories
{
    public interface IImagesRepository
    {
        public delegate void OnCreateImageSuccessCallback(CreateImageResponse response);
        public delegate void OnCreateImageFailureCallback(Error error);
        public void CreateImage(MonoBehaviour parent, CreateImageRequest request, OnCreateImageSuccessCallback onSuccessCallback, OnCreateImageFailureCallback onFailureCallback);

        public delegate void OnCreateImageEditSuccessCallback(CreateImageEditResponse response);
        public delegate void OnCreateImageEditFailureCallback(Error error);
        public void CreateImageEdit(MonoBehaviour parent, CreateImageEditRequest request, OnCreateImageEditSuccessCallback onSuccessCallback, OnCreateImageEditFailureCallback onFailureCallback);

        public delegate void OnCreateImageVariationSuccessCallback(CreateImageVariationResponse response);
        public delegate void OnCreateImageVariationFailureCallback(Error error);
        public void CreateImageVariation(MonoBehaviour parent, CreateImageVariationRequest request, OnCreateImageVariationSuccessCallback onSuccessCallback, OnCreateImageVariationFailureCallback onFailureCallback);
    }
}