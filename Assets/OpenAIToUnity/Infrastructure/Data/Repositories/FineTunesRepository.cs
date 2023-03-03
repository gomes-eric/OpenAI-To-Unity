using System;
using Data.Constants;
using Data.Entities.Requests;
using Data.Entities.Responses;
using Data.Utils;
using Domain.Interfaces.Repositories;
using Infrastructure.Network;
using UnityEngine;
using static Domain.Interfaces.Repositories.IFineTunesRepository;

namespace Data.Repositories
{
    public class FineTunesRepository : IFineTunesRepository
    {
        #region Singleton Pattern
            private static FineTunesRepository _instance;
    
            private FineTunesRepository() { }
    
            public static FineTunesRepository Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new FineTunesRepository();
                    }
    
                    return _instance;
                }
            }
        #endregion

        public void CreateFineTune(MonoBehaviour parent, CreateFineTuneRequest request, OnCreateFineTuneSuccessCallback onSuccessCallback, OnCreateFineTuneFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.PostRequest<CreateFineTuneResponse>(
                    OpenAiConstants.FineTunesEndpoint,
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void ListFineTunes(MonoBehaviour parent, OnListFineTunesSuccessCallback onSuccessCallback, OnListFineTunesFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.GetRequest<ListFineTunesResponse>(
                    OpenAiConstants.FineTunesEndpoint,
                    null,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void RetrieveFineTune(MonoBehaviour parent, RetrieveFineTuneRequest request, OnRetrieveFineTuneSuccessCallback onSuccessCallback, OnRetrieveFineTuneFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.GetRequest<RetrieveFineTuneResponse>(
                    $"{OpenAiConstants.FineTunesEndpoint}/{{fine_tune_id}}",
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void CancelFineTune(MonoBehaviour parent, CancelFineTuneRequest request, OnCancelFineTuneSuccessCallback onSuccessCallback, OnCancelFineTuneFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.PostRequest<CancelFineTuneResponse>(
                    $"{OpenAiConstants.FineTunesEndpoint}/{{fine_tune_id}}/cancel",
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void ListFineTuneEvents(MonoBehaviour parent, ListFineTuneEventsRequest request, OnListFineTuneEventsSuccessCallback onSuccessCallback, OnListFineTuneEventsFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.GetRequest<ListFineTuneEventsResponse>(
                    $"{OpenAiConstants.FineTunesEndpoint}/{{fine_tune_id}}/events",
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void DeleteFineTuneModel(MonoBehaviour parent, DeleteFineTuneModelRequest request, OnDeleteFineTuneModelSuccessCallback onSuccessCallback, OnDeleteFineTuneModelFailureCallback onFailureCallback)
        {
            try
            {
                parent.StartCoroutine(NetworkManager.DeleteRequest<DeleteFineTuneModelResponse>(
                    $"{OpenAiConstants.ModelsEndpoint}/{{model}}",
                    request,
                    onSuccessCallback.ToAction(),
                    onFailureCallback.ToAction()));
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}