using System;
using Newtonsoft.Json;

namespace Skybrud.Essentials.Json.Converters {
    
    /// <summary>
    /// JSON converter for serializing an enum value into a lowercase string.
    /// </summary>
    public class EnumLowercaseConverter : JsonConverter {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {

            if (value == null) {
                writer.WriteNull();
                return;
            }

            writer.WriteValue((value + "").ToLower());

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType) {
            return objectType == typeof(Enum);
        }

    }

}