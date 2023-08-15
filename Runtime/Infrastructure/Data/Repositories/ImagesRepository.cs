using System;
using JetBrains.Annotations;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests.Images;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IImagesRepository;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        public ImagesRepository([NotNull] MonoBehaviour parent, [NotNull] NetworkManager networkManager, [NotNull] string url)
        {
            Parent = parent;
            NetworkManager = networkManager;
            Url = url;
        }

        private MonoBehaviour Parent { get; }

        private NetworkManager NetworkManager { get; }

        private string Url { get; }

        public void CreateImage(CreateImageRequest request, OnCreateImageSuccessCallback onSuccessCallback, OnCreateImageFailureCallback onFailureCallback)
        {
            try
            {
                Parent.StartCoroutine(NetworkManager.JsonPostRequest(
                    $"{Url}/{OpenAIConstants.Endpoints.Images}/generations",
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()
                ));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void CreateImageEdit(CreateImageEditRequest request, OnCreateImageEditSuccessCallback onSuccessCallback, OnCreateImageEditFailureCallback onFailureCallback)
        {
            try
            {
                Parent.StartCoroutine(NetworkManager.FormPostRequest(
                    $"{Url}/{OpenAIConstants.Endpoints.Images}/edits",
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()
                ));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void CreateImageVariation(CreateImageVariationRequest request, OnCreateImageVariationSuccessCallback onSuccessCallback, OnCreateImageVariationFailureCallback onFailureCallback)
        {
            try
            {
                Parent.StartCoroutine(NetworkManager.FormPostRequest(
                    $"{Url}/{OpenAIConstants.Endpoints.Images}/variations",
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()
                ));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
