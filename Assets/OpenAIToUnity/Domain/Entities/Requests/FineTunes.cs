using System;
using System.Collections.Generic;
using Data.Interfaces;
using Newtonsoft.Json;

namespace Data.Entities.Requests
{
    [Serializable]
    public class CreateFineTuneRequest : Request
    {
        [JsonProperty("training_file")]
        public string TrainingFile { get; private set; }

        [JsonProperty("validation_file")]
        public string ValidationFile { get; set; }

        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("n_epochs")]
        public int? NEpochs { get; set; }

        [JsonProperty("batch_size")]
        public int? BatchSize { get; set; }

        [JsonProperty("learning_rate_multiplier")]
        public float? LearningRateMultiplier { get; set; }

        [JsonProperty("prompt_loss_weight")]
        public float? PromptLossWeight { get; set; }

        [JsonProperty("compute_classification_metrics")]
        public bool? ComputeClassificationMetrics { get; set; }

        [JsonProperty("classification_n_classes")]
        public int? ClassificationNClasses { get; set; }

        [JsonProperty("classification_positive_class")]
        public string ClassificationPositiveClass { get; set; }

        [JsonProperty("classification_betas")]
        public List<int> ClassificationBetas { get; set; }

        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        public CreateFineTuneRequest(string trainingFile)
        {
            this.TrainingFile = trainingFile;
        }

        public class Builder
        {
            private readonly CreateFineTuneRequest _request;

            public Builder(string trainingFile)
            {
                _request = new CreateFineTuneRequest(trainingFile);
            }

            public Builder ValidationFile(string validationFile)
            {
                _request.ValidationFile = validationFile;

                return this;
            }

            public Builder Model(string model)
            {
                _request.Model = model;

                return this;
            }

            public Builder NEpochs(int? nEpochs)
            {
                _request.NEpochs = nEpochs;

                return this;
            }

            public Builder BatchSize(int? batchSize)
            {
                _request.BatchSize = batchSize;

                return this;
            }

            public Builder LearningRateMultiplier(float? learningRateMultiplier)
            {
                _request.LearningRateMultiplier = learningRateMultiplier;

                return this;
            }

            public Builder PromptLossWeight(float? promptLossWeight)
            {
                _request.PromptLossWeight = promptLossWeight;

                return this;
            }

            public Builder ComputeClassificationMetrics(bool? computeClassificationMetrics)
            {
                _request.ComputeClassificationMetrics = computeClassificationMetrics;

                return this;
            }

            public Builder ClassificationNClasses(int? classificationNClasses)
            {
                _request.ClassificationNClasses = classificationNClasses;

                return this;
            }

            public Builder ClassificationPositiveClass(string classificationPositiveClass)
            {
                _request.ClassificationPositiveClass = classificationPositiveClass;

                return this;
            }

            public Builder ClassificationBetas(List<int> classificationBetas)
            {
                _request.ClassificationBetas = classificationBetas;

                return this;
            }

            public Builder Suffix(string suffix)
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

    [Serializable]
    public class RetrieveFineTuneRequest : Request
    {
        [JsonProperty("fine_tune_id")]
        public string FineTuneId { get; private set; }

        public RetrieveFineTuneRequest(string fineTuneId)
        {
            this.FineTuneId = fineTuneId;
        }

        public class Builder
        {
            private readonly RetrieveFineTuneRequest _request;

            public Builder(string fineTuneId)
            {
                _request = new RetrieveFineTuneRequest(fineTuneId);
            }

            public RetrieveFineTuneRequest Build()
            {
                return _request;
            }
        }
    }

    [Serializable]
    public class CancelFineTuneRequest : Request
    {
        [JsonProperty("fine_tune_id")]
        public string FineTuneId { get; private set; }

        public CancelFineTuneRequest(string fineTuneId)
        {
            this.FineTuneId = fineTuneId;
        }

        public class Builder
        {
            private readonly CancelFineTuneRequest _request;

            public Builder(string fineTuneId)
            {
                _request = new CancelFineTuneRequest(fineTuneId);
            }

            public CancelFineTuneRequest Build()
            {
                return _request;
            }
        }
    }

    [Serializable]
    public class ListFineTuneEventsRequest : Request
    {
        [JsonProperty("fine_tune_id")]
        public string FineTuneId { get; private set; }

        [JsonProperty("stream")]
        public bool? Stream { get; set; }

        public ListFineTuneEventsRequest(string fineTuneId)
        {
            this.FineTuneId = fineTuneId;
        }

        public class Builder
        {
            private readonly ListFineTuneEventsRequest _request;

            public Builder(string fineTuneId)
            {
                _request = new ListFineTuneEventsRequest(fineTuneId);
            }

            public Builder Stream(bool? stream)
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

    [Serializable]
    public class DeleteFineTuneModelRequest : Request
    {
        [JsonProperty("model")]
        public string Model { get; private set; }

        public DeleteFineTuneModelRequest(string model)
        {
            this.Model = model;
        }

        public class Builder
        {
            private readonly DeleteFineTuneModelRequest _request;

            public Builder(string model)
            {
                _request = new DeleteFineTuneModelRequest(model);
            }

            public DeleteFineTuneModelRequest Build()
            {
                return _request;
            }
        }
    }
}