using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Time;
using Skybrud.Essentials.Time;

#pragma warning disable 618

namespace UnitTestProject1.Time.Converters {

    [TestClass]
    public class UnixTimeConverterTests {

        [TestMethod]
        public void TestMethod1() {

            SampleClass sc1 = new SampleClass {
                StringValue = "Hello World",
                Timestamp1 = new DateTime(2000, 5, 1, 0, 0, 0, DateTimeKind.Utc),
                Timestamp2 = new DateTime(2000, 5, 1, 0, 0, 0, DateTimeKind.Utc)
            };

            string json = JsonConvert.SerializeObject(sc1, Formatting.None);

            Assert.AreEqual("{\"string\":\"Hello World\",\"timestamp1\":957139200,\"timestamp2\":957139200}", json);

            SampleClass sc2 = JsonConvert.DeserializeObject<SampleClass>(json);

            Assert.AreEqual(sc1.StringValue, sc2.StringValue);
            Assert.AreEqual(sc1.Timestamp1, sc2.Timestamp1);
            Assert.AreEqual(sc1.Timestamp2, sc2.Timestamp2);

        }

        public class SampleClass {

            [JsonProperty("string")]
            public string StringValue { get; set; }

            [JsonProperty("timestamp1")]
            [JsonConverter(typeof(UnixTimeConverter))]
            public DateTime Timestamp1 { get; set; }

            [JsonProperty("timestamp2")]
            [JsonConverter(typeof(UnixTimeConverter))]
            public EssentialsDateTime Timestamp2 { get; set; }

        }

    }

}