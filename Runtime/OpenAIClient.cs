using System;
using JetBrains.Annotations;
using OpenAIToUnity.Infrastructure.Data.Repositories;
using OpenAIToUnity.Infrastructure.Network;
using UnityEngine;

namespace OpenAIToUnity
{
    public class OpenAIClient
    {
        public OpenAIClient([NotNull] MonoBehaviour parent, [NotNull] Authentication authentication)
        {
            if (parent == null) throw new ArgumentNullException(nameof(parent));
            if (authentication == null) throw new ArgumentNullException(nameof(authentication));

            NetworkManager = new NetworkManager(authentication);
            Settings = new Settings();
            Models = new ModelsRepository(parent, NetworkManager, Settings.Url);
            Chat = new ChatRepository(parent, NetworkManager, Settings.Url);
            Completions = new CompletionsRepository(parent, NetworkManager, Settings.Url);
            Images = new ImagesRepository(parent, NetworkManager, Settings.Url);
            Embeddings = new EmbeddingsRepository(parent, NetworkManager, Settings.Url);
            Audio = new AudioRepository(parent, NetworkManager, Settings.Url);
            Files = new FilesRepository(parent, NetworkManager, Settings.Url);
            FineTunes = new FineTunesRepository(parent, NetworkManager, Settings.Url);
            Moderations = new ModerationsRepository(parent, NetworkManager, Settings.Url);
            Edits = new EditsRepository(parent, NetworkManager, Settings.Url);
        }

        public OpenAIClient([NotNull] MonoBehaviour parent, [NotNull] Authentication authentication, [NotNull] Settings settings)
        {
            if (parent == null) throw new ArgumentNullException(nameof(parent));
            if (authentication == null) throw new ArgumentNullException(nameof(authentication));

            NetworkManager = new NetworkManager(authentication);
            Settings = settings ?? throw new ArgumentNullException(nameof(settings));
            Models = new ModelsRepository(parent, NetworkManager, Settings.Url);
            Chat = new ChatRepository(parent, NetworkManager, Settings.Url);
            Completions = new CompletionsRepository(parent, NetworkManager, Settings.Url);
            Images = new ImagesRepository(parent, NetworkManager, Settings.Url);
            Embeddings = new EmbeddingsRepository(parent, NetworkManager, Settings.Url);
            Audio = new AudioRepository(parent, NetworkManager, Settings.Url);
            Files = new FilesRepository(parent, NetworkManager, Settings.Url);
            FineTunes = new FineTunesRepository(parent, NetworkManager, Settings.Url);
            Moderations = new ModerationsRepository(parent, NetworkManager, Settings.Url);
            Edits = new EditsRepository(parent, NetworkManager, Settings.Url);
        }

        private NetworkManager NetworkManager { get; }

        private Settings Settings { get; }

        public ModelsRepository Models { get; }

        public ChatRepository Chat { get; }

        public CompletionsRepository Completions { get; }

        public ImagesRepository Images { get; }

        public EmbeddingsRepository Embeddings { get; }

        public AudioRepository Audio { get; }

        public FilesRepository Files { get; }

        public FineTunesRepository FineTunes { get; }

        public ModerationsRepository Moderations { get; }

        public EditsRepository Edits { get; }
    }
}
