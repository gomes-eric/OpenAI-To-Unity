namespace Data.Types
{
    public class ImageResponseFormat
    {
        private ImageResponseFormat(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        public static ImageResponseFormat Url
        {
            get
            {
                return new ImageResponseFormat("url");
            }
        }

        public static ImageResponseFormat B64Json
        {
            get
            {
                return new ImageResponseFormat("b64_json");
            }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}