using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Converters;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Json.Converters {

    [TestClass]
    public class TimeSpanConverterTests {

        [TestMethod]
        public void Serialize1() {

            JObject json = new JObject {
                {"alpha", "123"},
                {"bravo", "123"},
                {"charlie", "PT2M3S"}
            };

            var obj = json.ToObject<Sample>();

            Assert.AreEqual("123.000", obj.Alpha.TotalSeconds.ToString("N3", CultureInfo.InvariantCulture), "#1");
            Assert.AreEqual("0.123", obj.Bravo.TotalSeconds.ToString("N3", CultureInfo.InvariantCulture), "#2");
            Assert.AreEqual("123.000", obj.Charlie.TotalSeconds.ToString("N3", CultureInfo.InvariantCulture), "#3");

        }

        [TestMethod]
        public void Serialize2() {

            JObject json = new JObject();

            var obj = json.ToObject<Sample>();

            Assert.AreEqual("0.000", obj.Alpha.TotalSeconds.ToString("N3", CultureInfo.InvariantCulture), "#1");
            Assert.AreEqual("0.000", obj.Bravo.TotalSeconds.ToString("N3", CultureInfo.InvariantCulture), "#2");
            Assert.AreEqual("0.000", obj.Charlie.TotalSeconds.ToString("N3", CultureInfo.InvariantCulture), "#3");

        }

        [TestMethod]
        public void Serialize3() {

            JObject json = new JObject {
                {"alpha", null},
                {"bravo", null},
                {"charlie", null}
            };

            var obj = json.ToObject<Sample>();

            Assert.AreEqual("0.000", obj.Alpha.TotalSeconds.ToString("N3"), "#1");
            Assert.AreEqual("0.000", obj.Bravo.TotalSeconds.ToString("N3"), "#2");
            Assert.AreEqual("0.000", obj.Charlie.TotalSeconds.ToString("N3"), "#3");

        }

        [TestMethod]
        public void Serialize4() {

            JObject json = new JObject {
                {"alpha", ""},
                {"bravo", ""},
                {"charlie", ""}
            };

            var obj = json.ToObject<Sample>();

            Assert.AreEqual("0.000", obj.Alpha.TotalSeconds.ToString("N3"), "#1");
            Assert.AreEqual("0.000", obj.Bravo.TotalSeconds.ToString("N3"), "#2");
            Assert.AreEqual("0.000", obj.Charlie.TotalSeconds.ToString("N3"), "#3");

        }

        [TestMethod]
        public void Serialize5() {

            JObject json = new JObject();

            var obj = json.ToObject<Sample2>();

            Assert.IsNull(obj.Alpha, "#1");
            Assert.IsNull(obj.Bravo, "#2");
            Assert.IsNull(obj.Charlie, "#3");

        }

        [TestMethod]
        public void Serialize6() {

            JObject json = new JObject {
                {"alpha", null},
                {"bravo", null},
                {"charlie", null}
            };

            var obj = json.ToObject<Sample2>();

            Assert.IsNull(obj.Alpha, "#1");
            Assert.IsNull(obj.Bravo, "#2");
            Assert.IsNull(obj.Charlie, "#3");

        }

        [TestMethod]
        public void Serialize7() {

            JObject json = new JObject {
                {"alpha", ""},
                {"bravo", ""},
                {"charlie", ""}
            };

            var obj = json.ToObject<Sample2>();

            Assert.IsNull(obj.Alpha, "#1");
            Assert.IsNull(obj.Bravo, "#2");
            Assert.IsNull(obj.Charlie, "#3");

        }

    }

    public class Sample {

        [JsonProperty("alpha")]
        [JsonConverter(typeof(TimeSpanConverter), TimeSpanFormat.Seconds)]
        public TimeSpan Alpha { get; set; }

        [JsonProperty("bravo")]
        [JsonConverter(typeof(TimeSpanConverter), TimeSpanFormat.Milliseconds)]
        public TimeSpan Bravo { get; set; }

        [JsonProperty("charlie")]
        [JsonConverter(typeof(TimeSpanConverter), TimeSpanFormat.Iso8601)]
        public TimeSpan Charlie { get; set; }

    }

    public class Sample2 {

        [JsonProperty("alpha")]
        [JsonConverter(typeof(TimeSpanConverter), TimeSpanFormat.Seconds)]
        public TimeSpan? Alpha { get; set; }

        [JsonProperty("bravo")]
        [JsonConverter(typeof(TimeSpanConverter), TimeSpanFormat.Milliseconds)]
        public TimeSpan? Bravo { get; set; }

        [JsonProperty("charlie")]
        [JsonConverter(typeof(TimeSpanConverter), TimeSpanFormat.Iso8601)]
        public TimeSpan? Charlie { get; set; }

    }

}