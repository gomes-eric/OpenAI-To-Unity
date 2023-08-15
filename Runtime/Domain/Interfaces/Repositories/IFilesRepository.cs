using OpenAIToUnity.Domain.Entities.Requests.Files;
using OpenAIToUnity.Domain.Entities.Responses.Error;
using OpenAIToUnity.Domain.Entities.Responses.Files;
using UnityEngine;

namespace OpenAIToUnity.Domain.Interfaces.Repositories
{
    public interface IFilesRepository
    {
        public delegate void OnListFilesSuccessCallback(ListFilesResponse response);

        public delegate void OnListFilesFailureCallback(Error error);

        public void ListFiles(OnListFilesSuccessCallback onSuccessCallback, OnListFilesFailureCallback onFailureCallback);

        public delegate void OnUploadFileSuccessCallback(UploadFileResponse response);

        public delegate void OnUploadFileFailureCallback(Error error);

        public void UploadFile(UploadFileRequest request, OnUploadFileSuccessCallback onSuccessCallback, OnUploadFileFailureCallback onFailureCallback);

        public delegate void OnDeleteFileSuccessCallback(DeleteFileResponse response);

        public delegate void OnDeleteFileFailureCallback(Error error);

        public void DeleteFile(DeleteFileRequest request, OnDeleteFileSuccessCallback onSuccessCallback, OnDeleteFileFailureCallback onFailureCallback);

        public delegate void OnRetrieveFileSuccessCallback(RetrieveFileResponse response);

        public delegate void OnRetrieveFileFailureCallback(Error error);

        public void RetrieveFile(RetrieveFileRequest request, OnRetrieveFileSuccessCallback onSuccessCallback, OnRetrieveFileFailureCallback onFailureCallback);

        public delegate void OnRetrieveFileContentSuccessCallback(string response);

        public delegate void OnRetrieveFileContentFailureCallback(Error error);

        public void RetrieveFileContent(RetrieveFileContentRequest request, OnRetrieveFileContentSuccessCallback onSuccessCallback, OnRetrieveFileContentFailureCallback onFailureCallback);
    }
}
