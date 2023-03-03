namespace Data.Types
{
    public class ImageSize
    {
        private ImageSize(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static ImageSize Small
        {
            get
            {
                return new ImageSize("256x256");
            }
        }
        public static ImageSize Medium
        {
            get
            {
                return new ImageSize("512x512");
            }
        }
        public static ImageSize Large
        {
            get
            {
                return new ImageSize("1024x1024");
            }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}