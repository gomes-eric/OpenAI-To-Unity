using System.Collections.Generic;
using Newtonsoft.Json;

namespace OpenAIToUnity.Domain.Entities.Requests.FineTunes
{
    public class CreateFineTuneRequest
    {
        private CreateFineTuneRequest()
        {
        }

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
            private readonly CreateFineTuneRequest _request = new();

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
        private RetrieveFineTuneRequest()
        {
        }

        [JsonProperty("fine_tune_id")] public string FineTuneId { get; set; }

        public class Builder
        {
            private readonly RetrieveFineTuneRequest _request = new();

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
        private CancelFineTuneRequest()
        {
        }

        [JsonProperty("fine_tune_id")] public string FineTuneId { get; set; }

        public class Builder
        {
            private readonly CancelFineTuneRequest _request = new();

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
        private ListFineTuneEventsRequest()
        {
        }

        [JsonProperty("fine_tune_id")] public string FineTuneId { get; set; }

        [JsonProperty("stream")] public bool? Stream { get; set; }

        public class Builder
        {
            private readonly ListFineTuneEventsRequest _request = new();

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
        private DeleteFineTuneModelRequest()
        {
        }

        [JsonProperty("model")] public string Model { get; set; }

        public class Builder
        {
            private readonly DeleteFineTuneModelRequest _request = new();

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
