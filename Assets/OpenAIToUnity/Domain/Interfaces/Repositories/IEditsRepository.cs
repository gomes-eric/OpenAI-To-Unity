using OpenAIToUnity.Domain.Entities.Requests.Edits;
using OpenAIToUnity.Domain.Entities.Responses.Edits;
using OpenAIToUnity.Domain.Entities.Responses.Error;

namespace OpenAIToUnity.Domain.Interfaces.Repositories
{
    public interface IEditsRepository
    {
        public delegate void OnCreateEditSuccessCallback(CreateEditResponse response);

        public delegate void OnCreateEditFailureCallback(Error error);

        public void CreateEdit(CreateEditRequest request, OnCreateEditSuccessCallback onSuccessCallback, OnCreateEditFailureCallback onFailureCallback);
    }
}
