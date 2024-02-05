#if NETSTANDARD2_0_OR_GREATER || NET45_OR_GREATER || NET5_0_OR_GREATER

using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Skybrud.Essentials.Json.Newtonsoft.Converters;

/// <summary>
/// JSON converter for serializing and deserializing instances of <see cref="JsonObjectBase"/>.
/// </summary>
internal class JsonObjectBaseConverter : JsonConverter {

    /// <inheritdoc />
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) {
        switch (value) {
            case null:
                writer.WriteNull();
                return;
            case JsonObjectBase obj: {
                    if (obj.JObject == null) {
                        writer.WriteNull();
                    } else {
                        obj.JObject.WriteTo(writer);
                    }
                    return;
                }
            default:
                throw new Exception($"Unsupported type: {value.GetType()}");
        }
    }

    /// <inheritdoc />
    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer) {

        if (reader.TokenType != JsonToken.StartObject)
            throw new JsonSerializationException($"Token of type {reader.TokenType} not supported...");

        // Look for a constructor taking a "JObject"
        ConstructorInfo? constructor = objectType
            .GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .FirstOrDefault(x => x.GetParameters().Length == 1 && x.GetParameters()[0].ParameterType == typeof(JObject));

        if (constructor == null)
            throw new JsonSerializationException(
                $"Type {objectType} does not contain a constructor taking an instance of {typeof(JObject)}...");

        JObject obj = JObject.Load(reader);

        return Activator.CreateInstance(objectType, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new object[] { obj }, null)!;

    }

    /// <inheritdoc />
    public override bool CanConvert(Type objectType) {
        return objectType == typeof(JsonObjectBase);
    }

}

#endif