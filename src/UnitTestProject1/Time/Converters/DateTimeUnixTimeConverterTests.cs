using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Time;
using System;

namespace UnitTestProject1.Time.Converters {

    [TestClass]
    public class DateTimeUnixTimeConverterTests {

#pragma warning disable 618

        [TestMethod]
        public void TestMethod1() {

            SampleClass sc1 = new SampleClass {
                StringValue = "Hello World",
                Timestamp = new DateTime(2000, 5, 1, 0, 0, 0, DateTimeKind.Utc)
            };

            string json = JsonConvert.SerializeObject(sc1, Formatting.None);

            Assert.AreEqual("{\"string\":\"Hello World\",\"timestamp\":957139200}", json);

            SampleClass sc2 = JsonConvert.DeserializeObject<SampleClass>(json);

            Assert.AreEqual(sc1.StringValue, sc2.StringValue);
            Assert.AreEqual(sc1.Timestamp, sc2.Timestamp);

        }

        public class SampleClass {

            [JsonProperty("string")]
            public string StringValue { get; set; }

            [JsonProperty("timestamp")]
            [JsonConverter(typeof(DateTimeUnixTimeConverter))]
            public DateTime Timestamp { get; set; }

        }

#pragma warning restore 618

    }

}