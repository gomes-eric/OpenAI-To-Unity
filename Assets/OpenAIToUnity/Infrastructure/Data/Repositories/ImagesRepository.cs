using System;
using System.Threading.Tasks;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IImagesRepository;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        public void CreateImage(CreateImageRequest request, OnCreateImageSuccessCallback onSuccessCallback, OnCreateImageFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(() => NetworkManager.JsonPostRequest(
                    $"{OpenAIConstants.ImagesEndpoint}/generations",
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
                Task.Run(() => NetworkManager.FormPostRequest(
                    $"{OpenAIConstants.ImagesEndpoint}/edits",
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
                Task.Run(() => NetworkManager.FormPostRequest(
                    $"{OpenAIConstants.ImagesEndpoint}/variations",
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

        #region Singleton

        private static ImagesRepository _instance;

        private ImagesRepository()
        {
        }

        public static ImagesRepository Instance => _instance ??= new ImagesRepository();

        #endregion
    }
}