using System;
using JetBrains.Annotations;
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
        public FineTunesRepository([NotNull] MonoBehaviour parent, [NotNull] NetworkManager networkManager, [NotNull] string url)
        {
            Parent = parent;
            NetworkManager = networkManager;
            Url = url;
        }

        private MonoBehaviour Parent { get; }

        private NetworkManager NetworkManager { get; }

        private string Url { get; }

        public void CreateFineTune(CreateFineTuneRequest request, OnCreateFineTuneSuccessCallback onSuccessCallback, OnCreateFineTuneFailureCallback onFailureCallback)
        {
            try
            {
                Parent.StartCoroutine(NetworkManager.JsonPostRequest(
                    $"{Url}/{OpenAIConstants.Endpoints.FineTunes}",
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
                Parent.StartCoroutine(NetworkManager.JsonGetRequest<string, ListFineTunesResponse>(
                    $"{Url}/{OpenAIConstants.Endpoints.FineTunes}",
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
                Parent.StartCoroutine(NetworkManager.JsonGetRequest(
                    $"{Url}/{OpenAIConstants.Endpoints.FineTunes}/{{fine_tune_id}}",
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
                Parent.StartCoroutine(NetworkManager.JsonPostRequest(
                    $"{Url}/{OpenAIConstants.Endpoints.FineTunes}/{{fine_tune_id}}/cancel",
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
                Parent.StartCoroutine(NetworkManager.JsonGetRequest(
                    $"{Url}/{OpenAIConstants.Endpoints.FineTunes}/{{fine_tune_id}}/events",
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
                Parent.StartCoroutine(NetworkManager.DeleteRequest(
                    $"{Url}/{OpenAIConstants.Endpoints.Models}/{{model}}",
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
