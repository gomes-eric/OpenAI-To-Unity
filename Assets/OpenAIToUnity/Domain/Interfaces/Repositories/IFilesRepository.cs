using Data.Entities.Requests;
using Data.Entities.Responses;
using Domain.Entities.Responses;
using UnityEngine;

namespace Domain.Interfaces.Repositories
{
    public interface IFilesRepository
    {
        public delegate void OnListFilesSuccessCallback(ListFilesResponse response);
        public delegate void OnListFilesFailureCallback(Error error);
        public void ListFiles(MonoBehaviour parent, OnListFilesSuccessCallback onSuccessCallback, OnListFilesFailureCallback onFailureCallback);

        public delegate void OnUploadFileSuccessCallback(UploadFileResponse response);
        public delegate void OnUploadFileFailureCallback(Error error);
        public void UploadFile(MonoBehaviour parent, UploadFileRequest request, OnUploadFileSuccessCallback onSuccessCallback, OnUploadFileFailureCallback onFailureCallback);

        public delegate void OnDeleteFileSuccessCallback(DeleteFileResponse response);
        public delegate void OnDeleteFileFailureCallback(Error error);
        public void DeleteFile(MonoBehaviour parent, DeleteFileRequest request, OnDeleteFileSuccessCallback onSuccessCallback, OnDeleteFileFailureCallback onFailureCallback);

        public delegate void OnRetrieveFileSuccessCallback(RetrieveFileResponse response);
        public delegate void OnRetrieveFileFailureCallback(Error error);
        public void RetrieveFile(MonoBehaviour parent, RetrieveFileRequest request, OnRetrieveFileSuccessCallback onSuccessCallback, OnRetrieveFileFailureCallback onFailureCallback);

        public delegate void OnRetrieveFileContentSuccessCallback(RetrieveFileContentResponse response);
        public delegate void OnRetrieveFileContentFailureCallback(Error error);
        public void RetrieveFileContent(MonoBehaviour parent, RetrieveFileContentRequest request, OnRetrieveFileContentSuccessCallback onSuccessCallback, OnRetrieveFileContentFailureCallback onFailureCallback);
    }
}