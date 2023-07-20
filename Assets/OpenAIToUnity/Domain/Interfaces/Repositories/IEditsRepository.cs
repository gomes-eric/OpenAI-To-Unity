using OpenAIToUnity.Domain.Entities.Requests;
using OpenAIToUnity.Domain.Entities.Responses;

namespace OpenAIToUnity.Domain.Interfaces.Repositories
{
    public interface IEditsRepository
    {
        public delegate void OnCreateEditSuccessCallback(CreateEditResponse response);

        public delegate void OnCreateEditFailureCallback(Error error);

        public void CreateEdit(CreateEditRequest request, OnCreateEditSuccessCallback onSuccessCallback, OnCreateEditFailureCallback onFailureCallback);
    }
}
