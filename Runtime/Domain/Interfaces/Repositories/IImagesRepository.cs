using OpenAIToUnity.Domain.Entities.Requests.Images;
using OpenAIToUnity.Domain.Entities.Responses.Error;
using OpenAIToUnity.Domain.Entities.Responses.Images;

namespace OpenAIToUnity.Domain.Interfaces.Repositories
{
    public interface IImagesRepository
    {
        public delegate void OnCreateImageSuccessCallback(CreateImageResponse response);

        public delegate void OnCreateImageFailureCallback(Error error);

        public void CreateImage(CreateImageRequest request, OnCreateImageSuccessCallback onSuccessCallback, OnCreateImageFailureCallback onFailureCallback);

        public delegate void OnCreateImageEditSuccessCallback(CreateImageEditResponse response);

        public delegate void OnCreateImageEditFailureCallback(Error error);

        public void CreateImageEdit(CreateImageEditRequest request, OnCreateImageEditSuccessCallback onSuccessCallback, OnCreateImageEditFailureCallback onFailureCallback);

        public delegate void OnCreateImageVariationSuccessCallback(CreateImageVariationResponse response);

        public delegate void OnCreateImageVariationFailureCallback(Error error);

        public void CreateImageVariation(CreateImageVariationRequest request, OnCreateImageVariationSuccessCallback onSuccessCallback, OnCreateImageVariationFailureCallback onFailureCallback);
    }
}
