using System.ComponentModel;

namespace OpenAIToUnity.Domain.Types
{
    public enum ImageSize
    {
        [Description("256x256")] Small,
        [Description("512x512")] Medium,
        [Description("1024x1024")] Large
    }
}
