using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Converters.Enums;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Time;
using System.Net;

namespace UnitTestProject1.Json.Converters {

    [TestClass]
    public class EnumStringConverterTests {

        [TestMethod]
        public void Serialize() {

            Sample pd1 = new Sample { Value = HttpStatusCode.InternalServerError };

            JObject obj1 = JObject.FromObject(pd1);

            Assert.AreEqual("internalservererror", obj1.GetString("lower"));
            Assert.AreEqual("INTERNALSERVERERROR", obj1.GetString("upper"));
            Assert.AreEqual("internalServerError", obj1.GetString("camel"));
            Assert.AreEqual("InternalServerError", obj1.GetString("pascal"));
            Assert.AreEqual("internal-server-error", obj1.GetString("kebab"));
            Assert.AreEqual("INTERNAL-SERVER-ERROR", obj1.GetString("train"));
            Assert.AreEqual("internal_server_error", obj1.GetString("underscore"));

        }

        public class Sample {

            [JsonIgnore]
            public HttpStatusCode Value { get; set; }

            [JsonProperty("lower")]
            [JsonConverter(typeof(EnumStringConverter), TextCasing.LowerCase)]
            public HttpStatusCode ToLower => Value;

            [JsonProperty("upper")]
            [JsonConverter(typeof(EnumStringConverter), TextCasing.UpperCase)]
            public HttpStatusCode ToUpper => Value;

            [JsonProperty("camel")]
            [JsonConverter(typeof(EnumStringConverter), TextCasing.CamelCase)]
            public HttpStatusCode ToCamelCase => Value;

            [JsonProperty("pascal")]
            [JsonConverter(typeof(EnumStringConverter), TextCasing.PascalCase)]
            public HttpStatusCode ToPascalCase => Value;

            [JsonProperty("kebab")]
            [JsonConverter(typeof(EnumStringConverter), TextCasing.KebabCase)]
            public HttpStatusCode ToKebabCase => Value;

            [JsonProperty("train")]
            [JsonConverter(typeof(EnumStringConverter), TextCasing.TrainCase)]
            public HttpStatusCode ToTrainCase => Value;

            [JsonProperty("underscore")]
            [JsonConverter(typeof(EnumStringConverter), TextCasing.Underscore)]
            public HttpStatusCode ToUnderscore => Value;

        }

    }

}