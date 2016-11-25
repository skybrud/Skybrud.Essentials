using System;
using Newtonsoft.Json;
using Skybrud.Essentials.Strings;

namespace Skybrud.Essentials.Json.Converters.Enums {
    
    /// <summary>
    /// JSON converter for serializing an enum value into a Pascal cased string.
    /// </summary>
    public class EnumPascalCaseConverter : JsonConverter {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {

            if (value == null) {
                writer.WriteNull();
                return;
            }

            writer.WriteValue(StringHelper.ToPascalCase(value + ""));

        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType) {
            return objectType == typeof(Enum);
        }

    }

}