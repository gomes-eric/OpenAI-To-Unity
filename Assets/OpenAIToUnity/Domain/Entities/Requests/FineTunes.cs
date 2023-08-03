using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Requests.FineTunes
{
    public class CreateFineTuneRequest
    {
        [JsonProperty("training_file")] public string TrainingFile { get; set; }

        [JsonProperty("validation_file")] public string ValidationFile { get; set; }

        [JsonProperty("model")] public string Model { get; set; }

        [JsonProperty("n_epochs")] public int? NEpochs { get; set; }

        [JsonProperty("batch_size")] public int? BatchSize { get; set; }

        [JsonProperty("learning_rate_multiplier")] public float? LearningRateMultiplier { get; set; }

        [JsonProperty("prompt_loss_weight")] public float? PromptLossWeight { get; set; }

        [JsonProperty("compute_classification_metrics")] public bool? ComputeClassificationMetrics { get; set; }

        [JsonProperty("classification_n_classes")] public int? ClassificationNClasses { get; set; }

        [JsonProperty("classification_positive_class")] public string ClassificationPositiveClass { get; set; }

        [JsonProperty("classification_betas")] public List<float?> ClassificationBetas { get; set; }

        [JsonProperty("suffix")] public string Suffix { get; set; }

        public class Builder
        {
            private CreateFineTuneRequest _request;

            public Builder()
            {
                _request = new CreateFineTuneRequest();
            }

            public Builder SetTrainingFile(string trainingFile)
            {
                _request.TrainingFile = trainingFile;

                return this;
            }

            public Builder SetValidationFile(string validationFile)
            {
                _request.ValidationFile = validationFile;

                return this;
            }

            public Builder SetModel(string model)
            {
                _request.Model = model;

                return this;
            }

            public Builder SetNEpochs(int nEpochs)
            {
                _request.NEpochs = nEpochs;

                return this;
            }

            public Builder SetBatchSize(int batchSize)
            {
                _request.BatchSize = batchSize;

                return this;
            }

            public Builder SetLearningRateMultiplier(float learningRateMultiplier)
            {
                _request.LearningRateMultiplier = learningRateMultiplier;

                return this;
            }

            public Builder SetPromptLossWeight(float promptLossWeight)
            {
                _request.PromptLossWeight = promptLossWeight;

                return this;
            }

            public Builder SetComputeClassificationMetrics(bool computeClassificationMetrics)
            {
                _request.ComputeClassificationMetrics = computeClassificationMetrics;

                return this;
            }

            public Builder SetClassificationNClasses(int classificationNClasses)
            {
                _request.ClassificationNClasses = classificationNClasses;

                return this;
            }

            public Builder SetClassificationPositiveClass(string classificationPositiveClass)
            {
                _request.ClassificationPositiveClass = classificationPositiveClass;

                return this;
            }

            public Builder SetClassificationBetas(List<float?> classificationBetas)
            {
                _request.ClassificationBetas = classificationBetas;

                return this;
            }

            public Builder SetSuffix(string suffix)
            {
                _request.Suffix = suffix;

                return this;
            }

            public CreateFineTuneRequest Build()
            {
                return _request;
            }
        }
    }

    public class RetrieveFineTuneRequest
    {
        [JsonProperty("fine_tune_id")] public string FineTuneId { get; set; }

        public class Builder
        {
            private RetrieveFineTuneRequest _request;

            public Builder()
            {
                _request = new RetrieveFineTuneRequest();
            }

            public Builder SetFineTuneId(string fineTuneId)
            {
                _request.FineTuneId = fineTuneId;

                return this;
            }

            public RetrieveFineTuneRequest Build()
            {
                return _request;
            }
        }
    }

    public class CancelFineTuneRequest
    {
        [JsonProperty("fine_tune_id")] public string FineTuneId { get; set; }

        public class Builder
        {
            private CancelFineTuneRequest _request;

            public Builder()
            {
                _request = new CancelFineTuneRequest();
            }

            public Builder SetFineTuneId(string fineTuneId)
            {
                _request.FineTuneId = fineTuneId;

                return this;
            }

            public CancelFineTuneRequest Build()
            {
                return _request;
            }
        }
    }

    public class ListFineTuneEventsRequest
    {
        [JsonProperty("fine_tune_id")] public string FineTuneId { get; set; }

        [JsonProperty("stream")] public bool? Stream { get; set; }

        public class Builder
        {
            private ListFineTuneEventsRequest _request;

            public Builder()
            {
                _request = new ListFineTuneEventsRequest();
            }

            public Builder SetFineTuneId(string fineTuneId)
            {
                _request.FineTuneId = fineTuneId;

                return this;
            }

            public Builder SetStream(bool stream)
            {
                _request.Stream = stream;

                return this;
            }

            public ListFineTuneEventsRequest Build()
            {
                return _request;
            }
        }
    }

    public class DeleteFineTuneModelRequest
    {
        [JsonProperty("model")] public string Model { get; set; }

        public class Builder
        {
            private DeleteFineTuneModelRequest _request;

            public Builder()
            {
                _request = new DeleteFineTuneModelRequest();
            }

            public Builder SetModel(string model)
            {
                _request.Model = model;

                return this;
            }

            public DeleteFineTuneModelRequest Build()
            {
                return _request;
            }
        }
    }
}
