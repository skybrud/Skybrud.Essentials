using System;
using Newtonsoft.Json;

namespace Skybrud.Essentials.Json.Converters.Enums {
    
    /// <summary>
    /// JSON converter for serializing an enum value into a lower case string.
    /// </summary>
    public class EnumLowerCaseConverter : JsonConverter {

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