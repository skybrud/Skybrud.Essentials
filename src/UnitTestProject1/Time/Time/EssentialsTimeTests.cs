using System;
using System.Globalization;
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

                new Sample("2019-03-01 00:00:00:000 +00:00", new EssentialsTime(2019, 3, 1, utc)),
                new Sample("2019-03-31 00:00:00:000 +00:00", new EssentialsTime(2019, 3, 31, utc)),
                new Sample("2019-04-01 00:00:00:000 +00:00", new EssentialsTime(2019, 4, 1, utc)),

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
        public void ConstructorDateTimeAndTimeZoneInfo1() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            DateTime input = new DateTime(2020, 9, 27, 12, 17, 21, DateTimeKind.Utc);

            EssentialsTime result = new EssentialsTime(input, utc);

            Assert.AreEqual("2020-09-27 12:17:21:000 +00:00", result.ToString(Format));

        }

        [TestMethod]
        public void ConstructorDateTimeAndTimeZoneInfo2() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTime input = new DateTime(2020, 9, 27, 12, 17, 21, DateTimeKind.Utc);

            EssentialsTime result = new EssentialsTime(input, romance);

            Assert.AreEqual("2020-09-27 14:17:21:000 +02:00", result.ToString(Format));

        }

        [TestMethod]
        public void ConstructorDateTimeAndTimeZoneInfo3() {

            // Convert to Eastern European Time
            TimeZoneInfo eet = TimeZoneInfo.FindSystemTimeZoneById("E. Europe Standard Time");

            DateTime input = new DateTime(2020, 9, 27, 12, 17, 21, DateTimeKind.Utc);

            EssentialsTime result = new EssentialsTime(input, eet);

            Assert.AreEqual("2020-09-27 15:17:21:000 +03:00", result.ToString(Format));

        }

        [TestMethod]
        public void ConstructorDateTimeAndTimeZoneInfo4() {

            // Notice: this test is likely fail if the local time zone isn't Romance Standard Time

            DateTime input = new DateTime(2020, 9, 27, 14, 17, 21, DateTimeKind.Local);

            EssentialsTime result = new EssentialsTime(input, TimeZoneInfo.Utc);

            Assert.AreEqual("2020-09-27 12:17:21:000 +00:00", result.ToString(Format));

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

        [TestMethod]
        public void YearAndDay() {

            EssentialsTime a = new EssentialsTime(2019, 1, 1, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime b = new EssentialsTime(2019, 10, 20, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime c = new EssentialsTime(2019, 12, 31, 0, 0, 0, TimeSpan.Zero);

            Assert.AreEqual(2019001, a.YearAndDay);
            Assert.AreEqual(2019293, b.YearAndDay);
            Assert.AreEqual(2019365, c.YearAndDay);

        }

        [TestMethod]
        public void IsToday() {

            EssentialsTime yesterday = EssentialsTime.Today.AddDays(-1);
            EssentialsTime today = EssentialsTime.Today;
            EssentialsTime tomorrow = EssentialsTime.Today.AddDays(+1);

            Assert.AreEqual(false, yesterday.IsToday, "#yesterday");
            Assert.AreEqual(true, today.IsToday, "#today");
            Assert.AreEqual(false, tomorrow.IsToday, "#tomorrow");

        }

        [TestMethod]
        public void IsTomorrow() {

            EssentialsTime yesterday = EssentialsTime.Today.AddDays(-1);
            EssentialsTime today = EssentialsTime.Today;
            EssentialsTime tomorrow = EssentialsTime.Today.AddDays(+1);

            Assert.AreEqual(false, yesterday.IsTomorrow, "#yesterday");
            Assert.AreEqual(false, today.IsTomorrow, "#today");
            Assert.AreEqual(true, tomorrow.IsTomorrow, "#tomorrow");

        }

        [TestMethod]
        public void IsYesterday() {

            EssentialsTime yesterday = EssentialsTime.Today.AddDays(-1);
            EssentialsTime today = EssentialsTime.Today;
            EssentialsTime tomorrow = EssentialsTime.Today.AddDays(+1);

            Assert.AreEqual(true, yesterday.IsYesterday, "#yesterday");
            Assert.AreEqual(false, today.IsYesterday, "#today");
            Assert.AreEqual(false, tomorrow.IsYesterday, "#tomorrow");

        }

        [TestMethod]
        public void FromTicksLocal() {

            DateTime dt = new DateTime(2021, 1, 13, 22, 00, 00, DateTimeKind.Local);
            Assert.AreEqual(637461720000000000, dt.Ticks, "#1");

            // We can't use a format with offset or time zone, as it may differ depending on the environment
            Assert.AreEqual("2021-01-13T22:00:00", dt.ToString("yyyy-MM-ddTHH:mm:ss"), "#2");

            // Convert to EssentialsTime
            EssentialsTime time = EssentialsTime.FromTicks(dt.Ticks);

            Assert.AreEqual(637461720000000000, time.Ticks, "#3");
            Assert.AreEqual("2021-01-13T22:00:00", time.ToString("yyyy-MM-ddTHH:mm:ss"), "#4");

        }

        [TestMethod]
        public void FromTicksLocalUtc() {

            DateTime dt = new DateTime(2021, 1, 13, 22, 00, 00, DateTimeKind.Utc);
            Assert.AreEqual(637461720000000000, dt.Ticks, "#1");

            // We can't use a format with offset or time zone, as it may differ depending on the environment
            Assert.AreEqual("2021-01-13T22:00:00Z", dt.ToString("yyyy-MM-ddTHH:mm:ssK"), "#2");

            // Convert to EssentialsTime
            EssentialsTime time = EssentialsTime.FromTicks(dt.Ticks, TimeSpan.Zero);

            // Same as DateTime
            Assert.AreEqual(637461720000000000, time.Ticks, "#3");
            
            // Offset is now +00:00 instead of Z (difference between DateTimeOffset and DateTime)
            Assert.AreEqual("2021-01-13T22:00:00+00:00", time.ToString("yyyy-MM-ddTHH:mm:ssK"), "#4");

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