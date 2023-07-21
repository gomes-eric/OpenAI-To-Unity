using System;
using System.ComponentModel;
using OpenAIToUnity.Domain.Entities.Responses;
using OpenAIToUnity.Domain.Types;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IAudioRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IChatRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.ICompletionsRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IEditsRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IEmbeddingsRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IFilesRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IImagesRepository;
using static OpenAIToUnity.Domain.Interfaces.Repositories.IModelsRepository;

namespace OpenAIToUnity.Domain.Utils
{
    public static class Extensions
    {
        #region Types

        public static string ToRequest(this ImageSize imageSize)
        {
            var field = imageSize.GetType().GetField(imageSize.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute == null ? imageSize.ToString() : attribute.Description;
        }

        public static string ToRequest(this ImageResponseFormat imageResponseFormat)
        {
            var field = imageResponseFormat.GetType().GetField(imageResponseFormat.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute == null ? imageResponseFormat.ToString() : attribute.Description;
        }

        public static string ToRequest(this AudioResponseFormat audioResponseFormat)
        {
            var field = audioResponseFormat.GetType().GetField(audioResponseFormat.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute == null ? audioResponseFormat.ToString() : attribute.Description;
        }

        public static string ToRequest(this Language language)
        {
            var field = language.GetType().GetField(language.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute == null ? language.ToString() : attribute.Description;
        }

        public static string ToRequest(this Purpose purpose)
        {
            var field = purpose.GetType().GetField(purpose.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            return attribute == null ? purpose.ToString() : attribute.Description;
        }

        #endregion

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

        #region Images

        public static Action<CreateImageResponse> ToAction(this OnCreateImageSuccessCallback onSuccessCallback)
        {
            return new Action<CreateImageResponse>(onSuccessCallback);
        }

        public static Action<Error> ToAction(this OnCreateImageFailureCallback onFailureCallback)
        {
            return new Action<Error>(onFailureCallback);
        }

        public static Action<CreateImageEditResponse> ToAction(this OnCreateImageEditSuccessCallback onSuccessCallback)
        {
            return new Action<CreateImageEditResponse>(onSuccessCallback);
        }

        public static Action<Error> ToAction(this OnCreateImageEditFailureCallback onFailureCallback)
        {
            return new Action<Error>(onFailureCallback);
        }

        public static Action<CreateImageVariationResponse> ToAction(this OnCreateImageVariationSuccessCallback onSuccessCallback)
        {
            return new Action<CreateImageVariationResponse>(onSuccessCallback);
        }

        public static Action<Error> ToAction(this OnCreateImageVariationFailureCallback onFailureCallback)
        {
            return new Action<Error>(onFailureCallback);
        }

        #endregion

        #region Embeddings

        public static Action<CreateEmbeddingsResponse> ToAction(this OnCreateEmbeddingsSuccessCallback onSuccessCallback)
        {
            return new Action<CreateEmbeddingsResponse>(onSuccessCallback);
        }

        public static Action<Error> ToAction(this OnCreateEmbeddingsFailureCallback onFailureCallback)
        {
            return new Action<Error>(onFailureCallback);
        }

        #endregion

        #region Audio

        public static Action<CreateTranscriptionResponse> ToAction(this OnCreateTranscriptionSuccessCallback onSuccessCallback)
        {
            return new Action<CreateTranscriptionResponse>(onSuccessCallback);
        }

        public static Action<Error> ToAction(this OnCreateTranscriptionFailureCallback onFailureCallback)
        {
            return new Action<Error>(onFailureCallback);
        }

        public static Action<CreateTranslationResponse> ToAction(this OnCreateTranslationSuccessCallback onSuccessCallback)
        {
            return new Action<CreateTranslationResponse>(onSuccessCallback);
        }

        public static Action<Error> ToAction(this OnCreateTranslationFailureCallback onFailureCallback)
        {
            return new Action<Error>(onFailureCallback);
        }

        #endregion

        #region Files

        public static Action<ListFilesResponse> ToAction(this OnListFilesSuccessCallback onSuccessCallback)
        {
            return new Action<ListFilesResponse>(onSuccessCallback);
        }

        public static Action<Error> ToAction(this OnListFilesFailureCallback onFailureCallback)
        {
            return new Action<Error>(onFailureCallback);
        }

        public static Action<UploadFileResponse> ToAction(this OnUploadFileSuccessCallback onSuccessCallback)
        {
            return new Action<UploadFileResponse>(onSuccessCallback);
        }

        public static Action<Error> ToAction(this OnUploadFileFailureCallback onFailureCallback)
        {
            return new Action<Error>(onFailureCallback);
        }

        public static Action<DeleteFileResponse> ToAction(this OnDeleteFileSuccessCallback onSuccessCallback)
        {
            return new Action<DeleteFileResponse>(onSuccessCallback);
        }

        public static Action<Error> ToAction(this OnDeleteFileFailureCallback onFailureCallback)
        {
            return new Action<Error>(onFailureCallback);
        }

        public static Action<RetrieveFileResponse> ToAction(this OnRetrieveFileSuccessCallback onSuccessCallback)
        {
            return new Action<RetrieveFileResponse>(onSuccessCallback);
        }

        public static Action<Error> ToAction(this OnRetrieveFileFailureCallback onFailureCallback)
        {
            return new Action<Error>(onFailureCallback);
        }

        public static Action<string> ToAction(this OnRetrieveFileContentSuccessCallback onSuccessCallback)
        {
            return new Action<string>(onSuccessCallback);
        }

        public static Action<Error> ToAction(this OnRetrieveFileContentFailureCallback onFailureCallback)
        {
            return new Action<Error>(onFailureCallback);
        }

        #endregion
    }
}
