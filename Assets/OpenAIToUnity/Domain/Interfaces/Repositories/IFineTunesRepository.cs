using Data.Entities.Requests;
using Data.Entities.Responses;
using Domain.Entities.Responses;
using UnityEngine;

namespace Domain.Interfaces.Repositories
{
    public interface IFineTunesRepository
    {
        public delegate void OnCreateFineTuneSuccessCallback(CreateFineTuneResponse response);
        public delegate void OnCreateFineTuneFailureCallback(Error error);
        public void CreateFineTune(MonoBehaviour parent, CreateFineTuneRequest request, OnCreateFineTuneSuccessCallback onSuccessCallback, OnCreateFineTuneFailureCallback onFailureCallback);

        public delegate void OnListFineTunesSuccessCallback(ListFineTunesResponse response);
        public delegate void OnListFineTunesFailureCallback(Error error);
        public void ListFineTunes(MonoBehaviour parent, OnListFineTunesSuccessCallback onSuccessCallback, OnListFineTunesFailureCallback onFailureCallback);

        public delegate void OnRetrieveFineTuneSuccessCallback(RetrieveFineTuneResponse response);
        public delegate void OnRetrieveFineTuneFailureCallback(Error error);
        public void RetrieveFineTune(MonoBehaviour parent, RetrieveFineTuneRequest request, OnRetrieveFineTuneSuccessCallback onSuccessCallback, OnRetrieveFineTuneFailureCallback onFailureCallback);

        public delegate void OnCancelFineTuneSuccessCallback(CancelFineTuneResponse response);
        public delegate void OnCancelFineTuneFailureCallback(Error error);
        public void CancelFineTune(MonoBehaviour parent, CancelFineTuneRequest request, OnCancelFineTuneSuccessCallback onSuccessCallback, OnCancelFineTuneFailureCallback onFailureCallback);

        public delegate void OnListFineTuneEventsSuccessCallback(ListFineTuneEventsResponse response);
        public delegate void OnListFineTuneEventsFailureCallback(Error error);
        public void ListFineTuneEvents(MonoBehaviour parent, ListFineTuneEventsRequest request, OnListFineTuneEventsSuccessCallback onSuccessCallback, OnListFineTuneEventsFailureCallback onFailureCallback);

        public delegate void OnDeleteFineTuneModelSuccessCallback(DeleteFineTuneModelResponse response);
        public delegate void OnDeleteFineTuneModelFailureCallback(Error error);
        public void DeleteFineTuneModel(MonoBehaviour parent, DeleteFineTuneModelRequest request, OnDeleteFineTuneModelSuccessCallback onSuccessCallback, OnDeleteFineTuneModelFailureCallback onFailureCallback);
    }
}