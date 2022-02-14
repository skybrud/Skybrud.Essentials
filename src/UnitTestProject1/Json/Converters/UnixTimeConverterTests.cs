using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Converters.Time;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.Iso8601;
using Skybrud.Essentials.Time.UnixTime;
using System.Text;

#pragma warning disable 618

namespace UnitTestProject1.Json.Converters {

    [TestClass]
    public class UnixTimeConverterTests {

        [TestMethod]
        public void ToJson() {
            
            EssentialsTime time1 = new EssentialsTime(2019, 01, 20, 12, 22, 35, TimeSpan.FromHours(1)).AddMilliseconds(123);
            Sample sample1 = new Sample(time1);

            JObject obj = JObject.FromObject(sample1);
            
            Assert.AreEqual(1547983355, obj.GetDouble("time1"), "Time #1");
            Assert.AreEqual(1547983355123, obj.GetDouble("time2"), "Time #2");
            
            Assert.AreEqual(1547983355, obj.GetDouble("time3"), "Time #3");
            Assert.AreEqual(1547983355123, obj.GetDouble("time4"), "Time #4");
            
            Assert.AreEqual(1547983355, obj.GetDouble("time5"), "Time #5");
            Assert.AreEqual(1547983355123, obj.GetDouble("time6"), "Time #6");
            
            Assert.AreEqual(1547983355, obj.GetDouble("time7"), "Time #7");
            Assert.AreEqual(1547983355123, obj.GetDouble("time8"), "Time #8");

        }

        [TestMethod]
        public void FromJsonInt64() {

            EssentialsTime time1 = new EssentialsTime(2019, 01, 20, 11, 22, 35, TimeSpan.Zero).AddMilliseconds(123);
            Sample sample1 = new Sample(time1);

            string source = new JObject {
                {"time1", 1547983355},
                {"time2", 1547983355123},
                {"time3", 1547983355},
                {"time4", 1547983355123},
                {"time5", 1547983355},
                {"time6", 1547983355123},
                {"time7", 1547983355},
                {"time8", 1547983355123}
            }.ToString();

            Sample sample2 = JsonUtils.ParseJsonObject<Sample>(source);
            
            Assert.AreEqual(WithSeconds(sample1.Time1), WithSeconds(sample2.Time1), "Time1");
            Assert.AreEqual(WithMilliseconds(sample1.Time2), WithMilliseconds(sample2.Time2), "Time2");
            
            Assert.AreEqual(WithSeconds(sample1.Time3), WithSeconds(sample2.Time3), "Time3");
            Assert.AreEqual(WithMilliseconds(sample1.Time4), WithMilliseconds(sample2.Time4), "Time4");
            
            Assert.AreEqual(WithSeconds(sample1.Time5), WithSeconds(sample2.Time5), "Time5");
            Assert.AreEqual(WithMilliseconds(sample1.Time6), WithMilliseconds(sample2.Time6), "Time6");
            
            Assert.AreEqual(WithSeconds(sample1.Time7), WithSeconds(sample2.Time7), "Time7");
            Assert.AreEqual(WithMilliseconds(sample1.Time8), WithMilliseconds(sample2.Time8), "Time8");

        }

        [TestMethod]
        public void FromJsonDouble() {

            EssentialsTime time1 = new EssentialsTime(2019, 01, 20, 11, 22, 35, TimeSpan.Zero).AddMilliseconds(123);
            Sample sample1 = new Sample(time1);

            string source = new JObject {
                {"time1", 1547983355.00001},
                {"time2", 1547983355123.00001},
                {"time3", 1547983355.00001},
                {"time4", 1547983355123.00001},
                {"time5", 1547983355.00001},
                {"time6", 1547983355123.00001},
                {"time7", 1547983355.00001},
                {"time8", 1547983355123.00001}
            }.ToString();

            Sample sample2 = JsonUtils.ParseJsonObject<Sample>(source);
            
            Assert.AreEqual(WithSeconds(sample1.Time1), WithSeconds(sample2.Time1), "Time1");
            Assert.AreEqual(WithMilliseconds(sample1.Time2), WithMilliseconds(sample2.Time2), "Time2");
            
            Assert.AreEqual(WithSeconds(sample1.Time3), WithSeconds(sample2.Time3), "Time3");
            Assert.AreEqual(WithMilliseconds(sample1.Time4), WithMilliseconds(sample2.Time4), "Time4");
            
            Assert.AreEqual(WithSeconds(sample1.Time5), WithSeconds(sample2.Time5), "Time5");
            Assert.AreEqual(WithMilliseconds(sample1.Time6), WithMilliseconds(sample2.Time6), "Time6");
            
            Assert.AreEqual(WithSeconds(sample1.Time7), WithSeconds(sample2.Time7), "Time7");
            Assert.AreEqual(WithMilliseconds(sample1.Time8), WithMilliseconds(sample2.Time8), "Time8");

        }

        [TestMethod]
        public void FromJsonString() {

            EssentialsTime time1 = new EssentialsTime(2019, 01, 20, 11, 22, 35, TimeSpan.Zero).AddMilliseconds(123);
            Sample sample1 = new Sample(time1);

            string source = new JObject {
                {"time1", "1547983355.00001"},
                {"time2", "1547983355123.00001"},
                {"time3", "1547983355.00001"},
                {"time4", "1547983355123.00001"},
                {"time5", "1547983355.00001"},
                {"time6", "1547983355123.00001"},
                {"time7", "1547983355.00001"},
                {"time8", "1547983355123.00001"}
            }.ToString();

            Sample sample2 = JsonUtils.ParseJsonObject<Sample>(source);
            
            Assert.AreEqual(WithSeconds(sample1.Time1), WithSeconds(sample2.Time1), "Time1");
            Assert.AreEqual(WithMilliseconds(sample1.Time2), WithMilliseconds(sample2.Time2), "Time2");
            
            Assert.AreEqual(WithSeconds(sample1.Time3), WithSeconds(sample2.Time3), "Time3");
            Assert.AreEqual(WithMilliseconds(sample1.Time4), WithMilliseconds(sample2.Time4), "Time4");
            
            Assert.AreEqual(WithSeconds(sample1.Time5), WithSeconds(sample2.Time5), "Time5");
            Assert.AreEqual(WithMilliseconds(sample1.Time6), WithMilliseconds(sample2.Time6), "Time6");
            
            Assert.AreEqual(WithSeconds(sample1.Time7), WithSeconds(sample2.Time7), "Time7");
            Assert.AreEqual(WithMilliseconds(sample1.Time8), WithMilliseconds(sample2.Time8), "Time8");

        }

        private string WithSeconds(DateTime timestamp) {
            return timestamp.ToUniversalTime().ToString(Iso8601Constants.DateTimeSeconds);
        }

        private string WithSeconds(DateTimeOffset timestamp) {
            return timestamp.ToUniversalTime().ToString(Iso8601Constants.DateTimeSeconds);
        }

        private string WithSeconds(EssentialsDateTime timestamp) {
            return timestamp.ToUniversalTime().ToString(Iso8601Constants.DateTimeSeconds);
        }

        private string WithSeconds(EssentialsTime timestamp) {
            return timestamp.ToUniversalTime().ToString(Iso8601Constants.DateTimeSeconds);
        }

        private string WithMilliseconds(DateTime timestamp) {
            return timestamp.ToUniversalTime().ToString(Iso8601Constants.DateTimeMilliseconds);
        }

        private string WithMilliseconds(DateTimeOffset timestamp) {
            return timestamp.ToUniversalTime().ToString(Iso8601Constants.DateTimeMilliseconds);
        }

        private string WithMilliseconds(EssentialsDateTime timestamp) {
            return timestamp.ToUniversalTime().ToString(Iso8601Constants.DateTimeMilliseconds);
        }

        private string WithMilliseconds(EssentialsTime timestamp) {
            return timestamp.ToUniversalTime().ToString(Iso8601Constants.DateTimeMilliseconds);
        }

        public class Sample {

            [JsonProperty("time1")]
            [JsonConverter(typeof(UnixTimeConverter), UnixTimeFormat.Seconds)]
            public DateTime Time1 { get; set; }

            [JsonProperty("time2")]
            [JsonConverter(typeof(UnixTimeConverter), UnixTimeFormat.Milliseconds)]
            public DateTime Time2 { get; set; }

            [JsonProperty("time3")]
            [JsonConverter(typeof(UnixTimeConverter), UnixTimeFormat.Seconds)]
            public DateTimeOffset Time3 { get; set; }

            [JsonProperty("time4")]
            [JsonConverter(typeof(UnixTimeConverter), UnixTimeFormat.Milliseconds)]
            public DateTimeOffset Time4 { get; set; }

            [JsonProperty("time5")]
            [JsonConverter(typeof(UnixTimeConverter), UnixTimeFormat.Seconds)]
            public EssentialsDateTime Time5 { get; set; }

            [JsonProperty("time6")]
            [JsonConverter(typeof(UnixTimeConverter), UnixTimeFormat.Milliseconds)]
            public EssentialsDateTime Time6 { get; set; }

            [JsonProperty("time7")]
            [JsonConverter(typeof(UnixTimeConverter), UnixTimeFormat.Seconds)]
            public EssentialsTime Time7 { get; set; }

            [JsonProperty("time8")]
            [JsonConverter(typeof(UnixTimeConverter), UnixTimeFormat.Milliseconds)]
            public EssentialsTime Time8 { get; set; }

            [JsonConstructor]
            public Sample() { }

            public Sample(EssentialsTime time) {
                
                Time1 = Time2 = time.DateTimeOffset.DateTime;
                Time3 = Time4 = time.DateTimeOffset;

                Time5 = Time6 = new EssentialsDateTime(time.DateTimeOffset.DateTime);
                Time7 = Time8 = time;

            }

        }

    }

}