using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace OpenAIToUnity.Domain.Utils
{
    public class StringToJObjectConverter : CustomCreationConverter<JObject>
    {
        public override JObject Create(Type objectType)
        {
            return new JObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                return JObject.Parse(reader.Value.ToString());
            }
            else
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
        }
    }
}
