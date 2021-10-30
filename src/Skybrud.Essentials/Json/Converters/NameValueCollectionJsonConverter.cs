#if NET_FRAMEWORK

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;

namespace Skybrud.Essentials.Json.Converters {

    /// <summary>
    /// JSON converter class for serializing and deserializing <see cref="NameValueCollection"/> instances.
    ///
    /// The serializes value will be a JSON object. If you wish to serialize to an URL encoded string instead, see the <see cref="StringJsonConverter"/>.
    /// </summary>
    public class NameValueCollectionJsonConverter : JsonConverter {
        
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)  {

            // Write a null value if the specified value is not the correct type
            if (value is not NameValueCollection nvc) {
                writer.WriteNull();
                return;
            }

            // Initialize a new JSON object
            JObject obj = new JObject();

            // Append a new property for each item in the name value collection
            foreach (string key in nvc.Keys)  {
                obj.Add(key, nvc[key]);
            }
            
            // Write the object to the current writer
            obj.WriteTo(writer);

        }
        
        /// <inheritdoc />
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            
            // We only care about the value if it's a 
            if (reader.TokenType is not JsonToken.StartObject) return null;
            
            // Initialize a new name value collection
            NameValueCollection nvc = new NameValueCollection();

            // Parse the JSON object and iterate through it's properties
            foreach (var property in JObject.Load(reader).Properties()) {
                nvc[property.Name] = property.Value.ToString();
            }

            return nvc;

        }

        /// <inheritdoc />
        public override bool CanConvert(Type objectType) {
            return objectType == typeof(NameValueCollection);
        }

    }
}

#endif