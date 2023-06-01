﻿using System;
using OpenAIToUnity.Domain.Entities.Responses;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IChatRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.ICompletionsRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IEditsRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IModelsRepository;

namespace OpenAIToUnity.Domain.Utils
{
    public static class Extensions
    {
        #region Models

        public static Action<ListModelsResponse> ToAction(this OnListModelsSuccessCallback onSuccessCallback)
        {
            return new Action<ListModelsResponse>(onSuccessCallback);
        }

        public static Action<Error> ToAction(this OnListModelsFailureCallback onFailureCallback)
        {
            return new Action<Error>(onFailureCallback);
        }

        public static Action<RetrieveModelResponse> ToAction(this OnRetrieveModelSuccessCallback onSuccessCallback)
        {
            return new Action<RetrieveModelResponse>(onSuccessCallback);
        }

        public static Action<Error> ToAction(this OnRetrieveModelFailureCallback onFailureCallback)
        {
            return new Action<Error>(onFailureCallback);
        }

        #endregion

        #region Completions

        public static Action<CreateCompletionResponse> ToAction(this OnCreateCompletionSuccessCallback onSuccessCallback)
        {
            return new Action<CreateCompletionResponse>(onSuccessCallback);
        }

        public static Action<Error> ToAction(this OnCreateCompletionFailureCallback onFailureCallback)
        {
            return new Action<Error>(onFailureCallback);
        }

        #endregion

        #region Chat

        public static Action<CreateChatCompletionResponse> ToAction(this OnCreateChatCompletionSuccessCallback onSuccessCallback)
        {
            return new Action<CreateChatCompletionResponse>(onSuccessCallback);
        }

        public static Action<Error> ToAction(this OnCreateChatCompletionFailureCallback onFailureCallback)
        {
            return new Action<Error>(onFailureCallback);
        }

        #endregion

        #region Edits

        public static Action<CreateEditResponse> ToAction(this OnCreateEditSuccessCallback onSuccessCallback)
        {
            return new Action<CreateEditResponse>(onSuccessCallback);
        }

        public static Action<Error> ToAction(this OnCreateEditFailureCallback onFailureCallback)
        {
            return new Action<Error>(onFailureCallback);
        }

        #endregion
    }
}