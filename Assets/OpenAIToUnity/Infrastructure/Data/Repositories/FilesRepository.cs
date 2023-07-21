using System;
using System.Threading.Tasks;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests;
using OpenAIToUnity.Domain.Entities.Responses;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IFilesRepository;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class FilesRepository : IFilesRepository
    {
        public void ListFiles(OnListFilesSuccessCallback onSuccessCallback, OnListFilesFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(() => NetworkManager.GetStringRequest<string, ListFilesResponse>(
                    OpenAIConstants.FilesEndpoint,
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
                Task.Run(() => NetworkManager.FormPostRequest(
                    OpenAIConstants.FilesEndpoint,
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
                Task.Run(() => NetworkManager.DeleteRequest(
                    $"{OpenAIConstants.FilesEndpoint}/{{file_id}}",
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
                Task.Run(() => NetworkManager.GetStringRequest(
                    $"{OpenAIConstants.FilesEndpoint}/{{file_id}}",
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
                Task.Run(() => NetworkManager.GetStreamRequest(
                    $"{OpenAIConstants.FilesEndpoint}/{{file_id}}/content",
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

        private static FilesRepository _instance;

        private FilesRepository()
        {
        }

        public static FilesRepository Instance => _instance ??= new FilesRepository();

        #endregion
    }
}
