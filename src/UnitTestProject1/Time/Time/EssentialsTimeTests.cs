using System;
using System.Globalization;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.Time {

    [TestClass]
    public class EssentialsTimeTests {

        public const string Format = "yyyy-MM-dd HH:mm:ss:fff K";

        [TestMethod]
        public void Constructor() {


            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var samples = new[] {

                new Sample("2019-03-01 00:00:00:000 +01:00", new EssentialsTime(2019, 3, 1, romance)),
                new Sample("2019-03-31 00:00:00:000 +01:00", new EssentialsTime(2019, 3, 31, romance)),
                new Sample("2019-04-01 00:00:00:000 +02:00", new EssentialsTime(2019, 4, 1, romance)),

                new Sample("2019-03-01 12:30:45:000 +01:00", new EssentialsTime(2019, 3, 1, 12, 30, 45, romance)),
                new Sample("2019-03-31 12:30:45:000 +02:00", new EssentialsTime(2019, 3, 31, 12, 30, 45, romance)),
                new Sample("2019-04-01 12:30:45:000 +02:00", new EssentialsTime(2019, 4, 1, 12, 30, 45, romance)),

                new Sample("2019-03-01 12:30:45:500 +01:00", new EssentialsTime(2019, 3, 1, 12, 30, 45, 500, romance)),
                new Sample("2019-03-31 12:30:45:500 +02:00", new EssentialsTime(2019, 3, 31, 12, 30, 45, 500, romance)),
                new Sample("2019-04-01 12:30:45:500 +02:00", new EssentialsTime(2019, 4, 1, 12, 30, 45, 500, romance))

            };

            for (int i = 0; i < samples.Length; i++) {

                var s = samples[i];

                Assert.AreEqual(s.Expected, s.Time.ToString(Format), $"Sample at index {i} failed test");

            }

        }

        [TestMethod]
        public void ToTimeZone() {
            
            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var samples = new[] {

                // "Romance Standard Time" changes to "Romance Daylight Time" in the last weekend of March
                new ToTimeZoneSample("2019-03-01 01:00:00:000 +01:00", "2019-03-01 00:00:00:000 +00:00", romance),
                new ToTimeZoneSample("2019-04-01 02:00:00:000 +02:00", "2019-04-01 00:00:00:000 +00:00", romance),
                new ToTimeZoneSample("2019-03-01 00:00:00:000 +00:00", "2019-03-01 01:00:00:000 +01:00", utc),
                new ToTimeZoneSample("2019-04-01 00:00:00:000 +00:00", "2019-04-01 02:00:00:000 +02:00", utc)

            };
            
            for (int i = 0; i < samples.Length; i++) {

                var s = samples[i];

                Assert.AreEqual(s.Expected, s.Time.ToTimeZone(s.TimeZone).ToString(Format), $"Sample at index {i} failed test");

            }

        }
        

        [TestMethod]
        public void FromIso8601Week() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsTime time1 = EssentialsTime.FromIso8601Week(2019, 12, utc);
            EssentialsTime time2 = EssentialsTime.FromIso8601Week(2019, 13, utc);
            EssentialsTime time3 = EssentialsTime.FromIso8601Week(2019, 14, utc);

            EssentialsTime time4 = EssentialsTime.FromIso8601Week(2019, 12, romance);
            EssentialsTime time5 = EssentialsTime.FromIso8601Week(2019, 13, romance);
            EssentialsTime time6 = EssentialsTime.FromIso8601Week(2019, 14, romance);

            Assert.AreEqual("2019-03-18 00:00:00:000 +00:00", time1.ToString(Format), "#1");
            Assert.AreEqual("2019-03-25 00:00:00:000 +00:00", time2.ToString(Format), "#2");
            Assert.AreEqual("2019-04-01 00:00:00:000 +00:00", time3.ToString(Format), "#3");

            Assert.AreEqual("2019-03-18 00:00:00:000 +01:00", time4.ToString(Format), "#4");
            Assert.AreEqual("2019-03-25 00:00:00:000 +01:00", time5.ToString(Format), "#5");
            Assert.AreEqual("2019-04-01 00:00:00:000 +02:00", time6.ToString(Format), "#6");

        }

        public class Sample {

            public string Expected { get; }

            public EssentialsTime Time { get; }

            public Sample(string expected, EssentialsTime time) {
                Expected = expected;
                Time = time;
            }

        }

        public class ToTimeZoneSample {

            public string Expected { get; }

            public EssentialsTime Time { get; }

            public TimeZoneInfo TimeZone { get; }

            public ToTimeZoneSample(string expected, string input, TimeZoneInfo timeZone) {
                Expected = expected;
                Time = DateTimeOffset.ParseExact(input, Format, CultureInfo.InvariantCulture);
                TimeZone = timeZone;
            }

        }

    }

}