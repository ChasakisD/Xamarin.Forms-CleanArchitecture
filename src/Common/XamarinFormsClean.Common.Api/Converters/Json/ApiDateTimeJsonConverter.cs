using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace XamarinFormsClean.Common.Api.Converters.Json
{
    public class ApiDateTimeJsonConverter : DateTimeConverterBase
    {
        public CultureInfo CultureInfo { get; }
        public string DatetimeFormat { get; }
        
        public ApiDateTimeJsonConverter()
        {
            CultureInfo = new CultureInfo("en-US");
            DatetimeFormat = "yyyy-MM-dd HH:mm:ss UTC";
        }

        public override object? ReadJson(
            JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer) =>
            DateTime.ParseExact(reader.Value?.ToString(), DatetimeFormat, CultureInfo.CurrentCulture);

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (!(value is DateTime dateTime)) return;
            writer.WriteValue(dateTime.ToString(DatetimeFormat, CultureInfo));
        }
    }
}