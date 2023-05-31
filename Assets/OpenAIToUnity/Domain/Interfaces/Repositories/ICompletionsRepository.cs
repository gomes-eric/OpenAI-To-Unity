using OpenAIToUnity.Domain.Entities.Requests;
using OpenAIToUnity.Domain.Entities.Responses;

namespace OpenAIToUnity.Domain.Interfaces.Repositories
{
    public interface ICompletionsRepository
    {
        public delegate void OnCreateCompletionSuccessCallback(CreateCompletionResponse response);

        public delegate void OnCreateCompletionFailureCallback(Error error);

        public void CreateCompletion(CreateCompletionRequest request, OnCreateCompletionSuccessCallback onSuccessCallback, OnCreateCompletionFailureCallback onFailureCallback);
    }
}