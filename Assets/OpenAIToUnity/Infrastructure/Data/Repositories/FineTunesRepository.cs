using System;
using System.Threading.Tasks;
using OpenAIToUnity.Domain.Constants;
using OpenAIToUnity.Domain.Entities.Requests.FineTunes;
using OpenAIToUnity.Domain.Entities.Responses.FineTunes;
using OpenAIToUnity.Domain.Interfaces.Repositories;
using OpenAIToUnity.Domain.Utils;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IFineTunesRepository;

namespace OpenAIToUnity.Infrastructure.Data.Repositories
{
    public class FineTunesRepository : IFineTunesRepository
    {
        public void CreateFineTune(CreateFineTuneRequest request, OnCreateFineTuneSuccessCallback onSuccessCallback, OnCreateFineTuneFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(() => NetworkManager.JsonPostRequest(
                    OpenAIConstants.FineTunesEndpoint,
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

        public void ListFineTunes(OnListFineTunesSuccessCallback onSuccessCallback, OnListFineTunesFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(() => NetworkManager.JsonGetRequest<string, ListFineTunesResponse>(
                    OpenAIConstants.FineTunesEndpoint,
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

        public void RetrieveFineTune(RetrieveFineTuneRequest request, OnRetrieveFineTuneSuccessCallback onSuccessCallback, OnRetrieveFineTuneFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(() => NetworkManager.JsonGetRequest(
                    $"{OpenAIConstants.FineTunesEndpoint}/{{fine_tune_id}}",
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

        public void CancelFineTune(CancelFineTuneRequest request, OnCancelFineTuneSuccessCallback onSuccessCallback, OnCancelFineTuneFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(() => NetworkManager.JsonPostRequest(
                    $"{OpenAIConstants.FineTunesEndpoint}/{{fine_tune_id}}/cancel",
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

        public void ListFineTuneEvents(ListFineTuneEventsRequest request, OnListFineTuneEventsSuccessCallback onSuccessCallback, OnListFineTuneEventsFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(() => NetworkManager.JsonGetRequest(
                    $"{OpenAIConstants.FineTunesEndpoint}/{{fine_tune_id}}/events",
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

        public void DeleteFineTuneModel(DeleteFineTuneModelRequest request, OnDeleteFineTuneModelSuccessCallback onSuccessCallback, OnDeleteFineTuneModelFailureCallback onFailureCallback)
        {
            try
            {
                Task.Run(() => NetworkManager.DeleteRequest(
                    $"{OpenAIConstants.ModelsEndpoint}/{{model}}",
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

        private static FineTunesRepository _instance;

        private FineTunesRepository()
        {
        }

        public static FineTunesRepository Instance => _instance ??= new FineTunesRepository();

        #endregion
    }
}
