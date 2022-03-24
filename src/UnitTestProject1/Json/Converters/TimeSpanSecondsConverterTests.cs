using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Time;
using System;

namespace UnitTestProject1.Json.Converters {

    [TestClass]
    public class TimeSpanSecondsConverterTests {

        [TestMethod]
        public void Serialize() {

            Sample sample1 = new Sample { Duration = TimeSpan.FromSeconds(42), Duration2 = TimeSpan.FromSeconds(42) };
            Sample sample2 = new Sample { Duration = TimeSpan.FromSeconds(3.14), Duration2 = null };

            Console.WriteLine(sample2.Duration.TotalSeconds);
            Console.WriteLine();

            Assert.AreEqual("{\"duration\":42,\"duration2\":42}", JsonConvert.SerializeObject(sample1));
            Assert.AreEqual("{\"duration\":3.14,\"duration2\":null}", JsonConvert.SerializeObject(sample2));

        }

        [TestMethod]
        public void Deserialize() {

            Sample sample1 = new Sample { Duration = TimeSpan.FromSeconds(42), Duration2 = TimeSpan.FromSeconds(42) };
            Sample sample2 = new Sample { Duration = TimeSpan.FromSeconds(3.14), Duration2 = null };

            Sample parsed1 = JsonConvert.DeserializeObject<Sample>("{\"duration\":42,\"duration2\":42}");
            Assert.AreEqual(sample1.Duration, parsed1.Duration);
            Assert.AreEqual(sample1.Duration2, parsed1.Duration2);

            Sample parsed2 = JsonConvert.DeserializeObject<Sample>("{\"duration\":3.14}");
            Assert.AreEqual(sample2.Duration, parsed2.Duration);
            Assert.AreEqual(sample2.Duration2, parsed2.Duration2);

        }

        class Sample {

            [JsonProperty("duration")]
            [JsonConverter(typeof(TimeSpanSecondsConverter))]
            public TimeSpan Duration { get; set; }

            [JsonProperty("duration2")]
            [JsonConverter(typeof(TimeSpanSecondsConverter))]
            public TimeSpan? Duration2 { get; set; }

        }

    }

}