using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Converters.Time;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;
using TimeConverter = Skybrud.Essentials.Json.Newtonsoft.Converters.Time.TimeConverter;
using UnixTimeConverter = Skybrud.Essentials.Json.Newtonsoft.Converters.Time.UnixTimeConverter;

#pragma warning disable 618

namespace UnitTestProject1.Json.Newtonsoft.Converters {

    [TestClass]
    public class TimeConverterTests {

        [TestMethod]
        public void ToJson() {

            EssentialsTime time1 = new EssentialsTime(2019, 01, 20, 12, 22, 35, TimeSpan.FromHours(1));
            Sample sample1 = new Sample(time1);

            JObject obj = JObject.FromObject(sample1);

            Assert.AreEqual("2019-01-20T12:22:35.000+01:00", obj.GetString("time"), "Time");
            Assert.AreEqual("2019-01-20T12:22:35.000+01:00", obj.GetString("time1"), "Time #1");
            Assert.AreEqual("2019-01-20T12:22:35.000+01:00", obj.GetString("time2"), "Time #2");
            Assert.AreEqual("Sun, 20 Jan 2019 12:22:35 +0100", obj.GetString("time3"), "Time #3");
            Assert.AreEqual("Sun, 20 Jan 2019 12:22:35 +0100", obj.GetString("time4"), "Time #4");
            Assert.AreEqual(1547983355, obj.GetInt32("time5"), "Time #5");
            Assert.AreEqual("1547983355", obj.GetString("time6"), "Time #6");

            Assert.AreEqual("2019-01-20T12:22:35.000+01:00", obj.GetString("offset"), "Offset");
            Assert.AreEqual("2019-01-20T12:22:35.000+01:00", obj.GetString("offset1"), "Offset #1");
            Assert.AreEqual("Sun, 20 Jan 2019 12:22:35 +0100", obj.GetString("offset2"), "Offset #2");
            Assert.AreEqual("Sun, 20 Jan 2019 12:22:35 +0100", obj.GetString("offset3"), "Offset #3");
            Assert.AreEqual(1547983355, obj.GetInt32("offset4"), "Offset #4");
            Assert.AreEqual("1547983355", obj.GetString("offset5"), "Offset #5");
            Assert.AreEqual("2019-01-20T12:22:35.000+01:00", obj.GetString("offset6"), "Offset #6");
            Assert.IsNull(obj.GetString("offset7"), "Offset #7");

        }

        [TestMethod]
        public void FromJson() {

            EssentialsTime time1 = new EssentialsTime(2019, 01, 20, 12, 22, 35, TimeSpan.FromHours(1));
            Sample sample1 = new Sample(time1);

            string source = new JObject {
                {"time", "2019-01-20T12:22:35+01:00"},
                {"time1", "2019-01-20T12:22:35+01:00"},
                {"time2", "2019-01-20T12:22:35+01:00"},
                {"time3", "Sun, 20 Jan 2019 12:22:35 +0100"},
                {"time4", "Sun, 20 Jan 2019 12:22:35 +0100"},
                {"time5", "1547983355"},
                {"time6", 1547983355},
                {"offset", "2019-01-20T12:22:35+01:00"},
                {"offset1", "2019-01-20T12:22:35+01:00"},
                {"offset2", "Sun, 20 Jan 2019 12:22:35 +0100"},
                {"offset3", "Sun, 20 Jan 2019 12:22:35 +0100"},
                {"offset4", "1547983355"},
                {"offset5", 1547983355},
                {"offset6", "2019-01-20T12:22:35+01:00"},
            }.ToString();

            Sample sample2 = JsonUtils.ParseJsonObject<Sample>(source);

            Assert.AreEqual(sample1.Time, sample2.Time, "Time");
            Assert.AreEqual(sample1.Time1, sample2.Time1, "Time1");
            Assert.AreEqual(sample1.Time2, sample2.Time2, "Time2");
            Assert.AreEqual(sample1.Time3, sample2.Time3, "Time3");
            Assert.AreEqual(sample1.Time4, sample2.Time4, "Time4");
            Assert.AreEqual(sample1.Time5, sample2.Time5, "Time5");

            Assert.AreEqual(sample1.Offset, sample2.Offset, "Offset");
            Assert.AreEqual(sample1.Offset1, sample2.Offset1, "Offset1");
            Assert.AreEqual(sample1.Offset2, sample2.Offset2, "Offset2");
            Assert.AreEqual(sample1.Offset3, sample2.Offset3, "Offset3");
            Assert.AreEqual(sample1.Offset4, sample2.Offset4, "Offset4");
            Assert.AreEqual(sample1.Offset5, sample2.Offset5, "Offset5");
            Assert.AreEqual(sample1.Offset5, sample2.Offset6, "Offset6");
            Assert.IsNull(sample2.Offset7, "Offset7");

        }

        [TestMethod]
        public void Legacy() {

            AnotherSample sample1 = new AnotherSample {
                Time1 = new EssentialsDateTime(2019, 01, 20, 14, 24, 12, DateTimeKind.Utc)
            };

            AnotherSample sample2 = new AnotherSample {
                Time1 = new EssentialsDateTime(2019, 01, 20, 14, 24, 12, DateTimeKind.Local)
            };

            AnotherSample sample3 = new AnotherSample {
                Time1 = new EssentialsDateTime(2019, 01, 20, 14, 24, 12, DateTimeKind.Unspecified)
            };

            JObject obj1 = JObject.FromObject(sample1);
            JObject obj2 = JObject.FromObject(sample2);
            JObject obj3 = JObject.FromObject(sample3);

            Assert.AreEqual("2019-01-20T14:24:12.000Z", obj1.GetString("Time1"), "#1");
            Assert.AreEqual("2019-01-20T14:24:12Z", obj1.GetString("Time2"), "#2");
            Assert.AreEqual("1547994252", obj1.GetString("Time3"), "#3");
            Assert.AreEqual("1547994252", obj1.GetString("Time4"), "#4");

            Assert.AreEqual("2019-01-20T14:24:12.000+01:00", obj2.GetString("Time1"), "#5");
            Assert.AreEqual("2019-01-20T14:24:12+01:00", obj2.GetString("Time2"), "#6");
            Assert.AreEqual("1547990652", obj2.GetString("Time3"), "#7");
            Assert.AreEqual("1547990652", obj2.GetString("Time4"), "#8");

            Assert.AreEqual("2019-01-20T14:24:12.000", obj3.GetString("Time1"), "#9");
            Assert.AreEqual("2019-01-20T14:24:12", obj3.GetString("Time2"), "#10");
            Assert.AreEqual("1547990652", obj3.GetString("Time3"), "#11");
            Assert.AreEqual("1547990652", obj3.GetString("Time4"), "#12");

        }

        public class Sample {

            [JsonProperty("time")]
            public EssentialsTime Time { get; set; }

            [JsonProperty("time1")]
            [JsonConverter(typeof(TimeConverter))]
            public EssentialsTime Time1 { get; set; }

            [JsonProperty("time2")]
            [JsonConverter(typeof(TimeConverter), TimeFormat.Iso8601)]
            public EssentialsTime Time2 { get; set; }

            [JsonProperty("time3")]
            [JsonConverter(typeof(TimeConverter), TimeFormat.Rfc822)]
            public EssentialsTime Time3 { get; set; }

            [JsonProperty("time4")]
            [JsonConverter(typeof(TimeConverter), TimeFormat.Rfc2822)]
            public EssentialsTime Time4 { get; set; }

            [JsonProperty("time5")]
            [JsonConverter(typeof(TimeConverter), TimeFormat.UnixTime)]
            public EssentialsTime Time5 { get; set; }

            [JsonProperty("time6")]
            [JsonConverter(typeof(TimeConverter), TimeFormat.UnixTime)]
            public EssentialsTime Time6 { get; set; }

            [JsonProperty("offset")]
            [JsonConverter(typeof(TimeConverter))]
            public DateTimeOffset Offset { get; set; }

            [JsonProperty("offset1")]
            [JsonConverter(typeof(TimeConverter), TimeFormat.Iso8601)]
            public DateTimeOffset Offset1 { get; set; }

            [JsonProperty("offset2")]
            [JsonConverter(typeof(TimeConverter), TimeFormat.Rfc822)]
            public DateTimeOffset Offset2 { get; set; }

            [JsonProperty("offset3")]
            [JsonConverter(typeof(TimeConverter), TimeFormat.Rfc2822)]
            public DateTimeOffset Offset3 { get; set; }

            [JsonProperty("offset4")]
            [JsonConverter(typeof(TimeConverter), TimeFormat.UnixTime)]
            public DateTimeOffset Offset4 { get; set; }

            [JsonProperty("offset5")]
            [JsonConverter(typeof(TimeConverter), TimeFormat.UnixTime)]
            public DateTimeOffset Offset5 { get; set; }

            [JsonProperty("offset6")]
            [JsonConverter(typeof(TimeConverter))]
            public DateTimeOffset? Offset6 { get; set; }

            [JsonProperty("offset7")]
            [JsonConverter(typeof(TimeConverter))]
            public DateTimeOffset? Offset7 { get; set; }

            [JsonConstructor]
            public Sample() { }

            public Sample(EssentialsTime time) {
                Time = Time1 = Time2 = Time3 = Time4 = Time5 = Time6 = time;
                Offset = Offset1 = Offset2 = Offset3 = Offset4 = Offset5 = time.DateTimeOffset;
                Offset6 = Offset;
            }

        }

        public class AnotherSample {

            [JsonConverter(typeof(TimeConverter))]
            public EssentialsDateTime Time1 { get; set; }

            [JsonConverter(typeof(EssentialsDateTimeConverter))]
            public EssentialsDateTime Time2 => Time1;

            [JsonConverter(typeof(TimeConverter), TimeFormat.UnixTime)]
            public EssentialsDateTime Time3 => Time1;

            [JsonConverter(typeof(UnixTimeConverter))]
            public EssentialsDateTime Time4 => Time1;



        }

    }

}