using System;
using JetBrains.Annotations;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests.Files;
using OpenAIToUnity.Domain.Entities.Responses.Files;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IFilesRepository;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class FilesRepository : IFilesRepository
    {
        public FilesRepository([NotNull] MonoBehaviour parent, [NotNull] NetworkManager networkManager, [NotNull] string url)
        {
            Parent = parent;
            NetworkManager = networkManager;
            Url = url;
        }

        private MonoBehaviour Parent { get; }

        private NetworkManager NetworkManager { get; }

        private string Url { get; }

        public void ListFiles(OnListFilesSuccessCallback onSuccessCallback, OnListFilesFailureCallback onFailureCallback)
        {
            try
            {
                Parent.StartCoroutine(NetworkManager.JsonGetRequest<string, ListFilesResponse>(
                    $"{Url}/{OpenAIConstants.Endpoints.Files}",
                    null,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()
                ));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void UploadFile(UploadFileRequest request, OnUploadFileSuccessCallback onSuccessCallback, OnUploadFileFailureCallback onFailureCallback)
        {
            try
            {
                Parent.StartCoroutine(NetworkManager.FormPostRequest(
                    $"{Url}/{OpenAIConstants.Endpoints.Files}",
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

        public void DeleteFile(DeleteFileRequest request, OnDeleteFileSuccessCallback onSuccessCallback, OnDeleteFileFailureCallback onFailureCallback)
        {
            try
            {
                Parent.StartCoroutine(NetworkManager.DeleteRequest(
                    $"{Url}/{OpenAIConstants.Endpoints.Files}/{{file_id}}",
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

        public void RetrieveFile(RetrieveFileRequest request, OnRetrieveFileSuccessCallback onSuccessCallback, OnRetrieveFileFailureCallback onFailureCallback)
        {
            try
            {
                Parent.StartCoroutine(NetworkManager.JsonGetRequest(
                    $"{Url}/{OpenAIConstants.Endpoints.Files}/{{file_id}}",
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

        public void RetrieveFileContent(RetrieveFileContentRequest request, OnRetrieveFileContentSuccessCallback onSuccessCallback, OnRetrieveFileContentFailureCallback onFailureCallback)
        {
            try
            {
                Parent.StartCoroutine(NetworkManager.FileGetRequest(
                    $"{Url}/{OpenAIConstants.Endpoints.Files}/{{file_id}}/content",
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
