using System;
using Newtonsoft.Json;
using XamarinFormsClean.Common.Data.Utils;

namespace XamarinFormsClean.Common.Data.Converters.Json
{
    public class OptionJsonConverter<T> : JsonConverter<Option<T>> where T : class
    {
        public override Option<T> ReadJson(
            JsonReader reader, 
            Type objectType, 
            Option<T> existingValue, 
            bool hasExistingValue, 
            JsonSerializer serializer)
        {
            var value = serializer.Deserialize<T>(reader);

            return value == null
                ? Option.None<T>()
                : Option.Some(value);
        }

        public override void WriteJson(
            JsonWriter writer, 
            Option<T> value, 
            JsonSerializer serializer)
        {
            switch (value)
            {
                case (_, false):
                    serializer.Serialize(writer, null);
                    break;
                case (var innerValue, true):
                    serializer.Serialize(writer, innerValue);
                    break;
            }
        }
    }
}