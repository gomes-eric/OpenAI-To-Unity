using OpenAIToUnity.Domain.Entities.Requests;
using OpenAIToUnity.Domain.Entities.Responses;

namespace OpenAIToUnity.Domain.Interfaces.Repositories
{
    public interface IImagesRepository
    {
        public delegate void OnCreateImageSuccessCallback(CreateImageResponse response);

        public delegate void OnCreateImageFailureCallback(Error error);

        public delegate void OnCreateImageEditSuccessCallback(CreateImageEditResponse response);

        public delegate void OnCreateImageEditFailureCallback(Error error);

        public delegate void OnCreateImageVariationSuccessCallback(CreateImageVariationResponse response);

        public delegate void OnCreateImageVariationFailureCallback(Error error);

        public void CreateImage(CreateImageRequest request, OnCreateImageSuccessCallback onSuccessCallback, OnCreateImageFailureCallback onFailureCallback);

        public void CreateImageEdit(CreateImageEditRequest request, OnCreateImageEditSuccessCallback onSuccessCallback, OnCreateImageEditFailureCallback onFailureCallback);

        public void CreateImageVariation(CreateImageVariationRequest request, OnCreateImageVariationSuccessCallback onSuccessCallback, OnCreateImageVariationFailureCallback onFailureCallback);
    }
}