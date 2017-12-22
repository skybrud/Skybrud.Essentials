using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Time;

namespace UnitTestProject1.Json.Converters {

    [TestClass]
    public class TimeSpanSecondsConverterTests {

        [TestMethod]
        public void Serialize() {

            Sample sample1 = new Sample { Duration = TimeSpan.FromSeconds(42) };
            Sample sample2 = new Sample { Duration = TimeSpan.FromSeconds(3.14) };

            Console.WriteLine(sample2.Duration.TotalSeconds);
            Console.WriteLine();

            Assert.AreEqual("{\"duration\":42}", JsonConvert.SerializeObject(sample1));
            Assert.AreEqual("{\"duration\":3.14}", JsonConvert.SerializeObject(sample2));

        }

        [TestMethod]
        public void Deserialize() {
            
            Sample sample1 = new Sample { Duration = TimeSpan.FromSeconds(42) };
            Sample sample2 = new Sample { Duration = TimeSpan.FromSeconds(3.14) };

            Sample parsed1 = JsonConvert.DeserializeObject<Sample>("{\"duration\":42}");
            Assert.AreEqual(sample1.Duration, parsed1.Duration);
            Assert.AreEqual(sample1.Duration, parsed1.Duration);

            Sample parsed2 = JsonConvert.DeserializeObject<Sample>("{\"duration\":3.14}");
            Assert.AreEqual(sample2.Duration, parsed2.Duration);
            Assert.AreEqual(sample2.Duration, parsed2.Duration);

        }

        class Sample {

            [JsonProperty("duration")]
            [JsonConverter(typeof(TimeSpanSecondsConverter))]
            public TimeSpan Duration { get; set; }

        }

    }

}