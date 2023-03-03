using Data.Entities.Requests;
using Data.Entities.Responses;
using Domain.Entities.Responses;
using UnityEngine;

namespace Domain.Interfaces.Repositories
{
    public interface IEditsRepository
    {
        public delegate void OnCreateEditSuccessCallback(CreateEditResponse response);
        public delegate void OnCreateEditFailureCallback(Error error);
        public void CreateEdit(MonoBehaviour parent, CreateEditRequest request, OnCreateEditSuccessCallback onSuccessCallback, OnCreateEditFailureCallback onFailureCallback);
    }
}