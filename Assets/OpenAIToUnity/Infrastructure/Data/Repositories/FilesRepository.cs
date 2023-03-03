using System;
using Data.Constants;
using Data.Entities.Requests;
using Data.Entities.Responses;
using Data.Utils;
using Domain.Interfaces.Repositories;
using Infrastructure.Network;
using UnityEngine;
using static Domain.Interfaces.Repositories.IFilesRepository;

namespace Data.Repositories
{
    public class FilesRepository : IFilesRepository
    {
        #region Singleton Pattern
            private static FilesRepository _instance;
    
            private FilesRepository() { }
    
            public static FilesRepository Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new FilesRepository();
                    }
    
                    return _instance;
                }
            }
        #endregion

        public void ListFiles(MonoBehaviour parent, OnListFilesSuccessCallback onSuccessCallback, OnListFilesFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.GetRequest<ListFilesResponse>(
                    OpenAiConstants.FilesEndpoint,
                    null,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void UploadFile(MonoBehaviour parent, UploadFileRequest request, OnUploadFileSuccessCallback onSuccessCallback, OnUploadFileFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.PostRequest<UploadFileResponse>(
                    OpenAiConstants.FilesEndpoint,
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void DeleteFile(MonoBehaviour parent, DeleteFileRequest request, OnDeleteFileSuccessCallback onSuccessCallback, OnDeleteFileFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.DeleteRequest<DeleteFileResponse>(
                    $"{OpenAiConstants.FilesEndpoint}/{{file_id}}",
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void RetrieveFile(MonoBehaviour parent, RetrieveFileRequest request, OnRetrieveFileSuccessCallback onSuccessCallback, OnRetrieveFileFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.GetRequest<RetrieveFileResponse>(
                    $"{OpenAiConstants.FilesEndpoint}/{{file_id}}",
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void RetrieveFileContent(MonoBehaviour parent, RetrieveFileContentRequest request, OnRetrieveFileContentSuccessCallback onSuccessCallback, OnRetrieveFileContentFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.GetRequest<RetrieveFileContentResponse>(
                    $"{OpenAiConstants.FilesEndpoint}/{{file_id}}/content",
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