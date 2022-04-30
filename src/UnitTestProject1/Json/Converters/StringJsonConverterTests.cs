using System;
using System.Collections.Specialized;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Converters;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Strings.Extensions;

namespace UnitTestProject1.Json.Converters {

    [TestClass]
    public class StringJsonConverterTests {

        [TestMethod]
        public void SerializeNameValueCollection() {

            Sample1 sample = new Sample1 {
                Query = new NameValueCollection {
                    { "Hello", "There" },
                    { "General", "Kenobi" }
                }
            };

            JObject obj = JObject.FromObject(sample);

            Assert.AreEqual("Hello=There&General=Kenobi", obj.GetString("query"));

        }

        [TestMethod]
        public void DeserializeNameValueCollection() {

            JObject obj = new JObject {
                {"query", "Hello=There&General=Kenobi"}
            };

            Sample1 sample = obj.ToObject<Sample1>();

            Assert.IsNotNull(sample.Query);

            Assert.AreEqual("There", sample.Query["Hello"]);
            Assert.AreEqual("Kenobi", sample.Query["General"]);

        }

        [TestMethod]
        public void SerializeEnum() {

            Sample2 sample = new Sample2 {
                Value = HttpStatusCode.InternalServerError
            };

            JObject obj = JObject.FromObject(sample);

            Assert.AreEqual("InternalServerError", obj.GetString("value"));

        }

        [TestMethod]
        public void DeserializeEnum() {

            JObject obj = new JObject {
                {"value", "InternalServerError"}
            };

            Sample2 sample = obj.ToObject<Sample2>();

            Assert.AreEqual(HttpStatusCode.InternalServerError, sample.Value);

        }

        public class Sample1 {

            [JsonConverter(typeof(StringJsonConverter))]
            [JsonProperty("query")]
            public NameValueCollection Query { get; set; }

        }

        public class Sample2 {

            [JsonConverter(typeof(StringJsonConverter))]
            [JsonProperty("value")]
            public HttpStatusCode Value { get; set; }

        }

    }

}