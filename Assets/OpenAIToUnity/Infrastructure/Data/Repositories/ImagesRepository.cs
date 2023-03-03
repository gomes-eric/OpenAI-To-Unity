using System;
using Data.Constants;
using Data.Entities.Requests;
using Data.Entities.Responses;
using Data.Utils;
using Domain.Interfaces.Repositories;
using Infrastructure.Network;
using UnityEngine;
using static Domain.Interfaces.Repositories.IImagesRepository;

namespace Data.Repositories
{
    public class ImagesRepository : IImagesRepository
    {
        #region Singleton Pattern
            private static ImagesRepository _instance;
    
            private ImagesRepository() { }
    
            public static ImagesRepository Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new ImagesRepository();
                    }
    
                    return _instance;
                }
            }
        #endregion

        public void CreateImage(MonoBehaviour parent, CreateImageRequest request, OnCreateImageSuccessCallback onSuccessCallback, OnCreateImageFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.PostRequest<CreateImageResponse>(
                    $"{OpenAiConstants.ImagesEndpoint}/generations",
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void CreateImageEdit(MonoBehaviour parent, CreateImageEditRequest request, OnCreateImageEditSuccessCallback onSuccessCallback, OnCreateImageEditFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.PostRequest<CreateImageEditResponse>(
                    $"{OpenAiConstants.ImagesEndpoint}/edits",
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void CreateImageVariation(MonoBehaviour parent, CreateImageVariationRequest request, OnCreateImageVariationSuccessCallback onSuccessCallback, OnCreateImageVariationFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.PostRequest<CreateImageVariationResponse>(
                    $"{OpenAiConstants.ImagesEndpoint}/variations",
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}