using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.Time {

    [TestClass]
    public class DateTimeOffsetTests {

        public const string Format = "yyyy-MM-dd HH:mm:ss:fff K";

        [TestMethod]
        public void GetStartOfDay() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var samples = new[] {

                new GetOfDaySample("2019-03-18 00:00:00:000 +00:00", "2019-03-18 12:00:00:000 +00:00", null),
                new GetOfDaySample("2019-03-23 00:00:00:000 +00:00", "2019-03-23 12:00:00:000 +00:00", null),
                new GetOfDaySample("2019-03-26 00:00:00:000 +00:00", "2019-03-26 12:00:00:000 +00:00", null),

                new GetOfDaySample("2019-03-18 00:00:00:000 +00:00", "2019-03-18 12:00:00:000 +00:00", utc),
                new GetOfDaySample("2019-03-23 00:00:00:000 +00:00", "2019-03-23 12:00:00:000 +00:00", utc),
                new GetOfDaySample("2019-03-26 00:00:00:000 +00:00", "2019-03-26 12:00:00:000 +00:00", utc),

                new GetOfDaySample("2019-03-23 00:00:00:000 +01:00", "2019-03-23 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-24 00:00:00:000 +01:00", "2019-03-24 12:00:00:000 +01:00", romance),

                new GetOfDaySample("2019-03-25 00:00:00:000 +01:00", "2019-03-25 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-26 00:00:00:000 +01:00", "2019-03-26 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-27 00:00:00:000 +01:00", "2019-03-27 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-28 00:00:00:000 +01:00", "2019-03-28 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-29 00:00:00:000 +01:00", "2019-03-29 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-30 00:00:00:000 +01:00", "2019-03-30 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 00:00:00:000 +01:00", "2019-03-31 12:00:00:000 +02:00", romance),

                new GetOfDaySample("2019-04-01 00:00:00:000 +02:00", "2019-04-01 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-04-02 00:00:00:000 +02:00", "2019-04-02 12:00:00:000 +02:00", romance),

                new GetOfDaySample("2019-10-23 00:00:00:000 +02:00", "2019-10-23 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-10-25 00:00:00:000 +02:00", "2019-10-25 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-10-27 00:00:00:000 +02:00", "2019-10-27 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-10-29 00:00:00:000 +01:00", "2019-10-29 12:00:00:000 +01:00", romance)

            };

            for (int i = 0; i < samples.Length; i++) {

                var s = samples[i];

                DateTimeOffset result1 = TimeUtils.GetStartOfDay(s.Time, s.TimeZone);

                EssentialsTime result2 = new EssentialsTime(s.Time, s.TimeZone).GetStartOfDay();

                EssentialsTime result3 = new EssentialsTime(s.Time, s.TimeZone).GetStartOfDay(s.TimeZone);

                Assert.AreEqual(s.Expected, result1.ToString(Format), $"Sample at index {i} failed test (DateTimeOffset)");

                Assert.AreEqual(s.Expected, result2.ToString(Format), $"Sample at index {i} failed test (EssentialsTime)");

                Assert.AreEqual(s.Expected, result3.ToString(Format), $"Sample at index {i} failed test (EssentialsTime)");

            }

        }

        [TestMethod]
        public void GetEndOfDay() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var samples = new[] {

                new GetOfDaySample("2019-03-18 23:59:59:999 +00:00", "2019-03-18 12:00:00:000 +00:00", null),
                new GetOfDaySample("2019-03-23 23:59:59:999 +00:00", "2019-03-23 12:00:00:000 +00:00", null),
                new GetOfDaySample("2019-03-26 23:59:59:999 +00:00", "2019-03-26 12:00:00:000 +00:00", null),

                new GetOfDaySample("2019-03-18 23:59:59:999 +00:00", "2019-03-18 12:00:00:000 +00:00", utc),
                new GetOfDaySample("2019-03-23 23:59:59:999 +00:00", "2019-03-23 12:00:00:000 +00:00", utc),
                new GetOfDaySample("2019-03-26 23:59:59:999 +00:00", "2019-03-26 12:00:00:000 +00:00", utc),

                new GetOfDaySample("2019-03-23 23:59:59:999 +01:00", "2019-03-23 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-24 23:59:59:999 +01:00", "2019-03-24 12:00:00:000 +01:00", romance),

                new GetOfDaySample("2019-03-25 23:59:59:999 +01:00", "2019-03-25 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-26 23:59:59:999 +01:00", "2019-03-26 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-27 23:59:59:999 +01:00", "2019-03-27 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-28 23:59:59:999 +01:00", "2019-03-28 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-29 23:59:59:999 +01:00", "2019-03-29 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-30 23:59:59:999 +01:00", "2019-03-30 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-31 12:00:00:000 +02:00", romance),

                new GetOfDaySample("2019-04-01 23:59:59:999 +02:00", "2019-04-01 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-04-02 23:59:59:999 +02:00", "2019-04-02 12:00:00:000 +02:00", romance),

                new GetOfDaySample("2019-10-23 23:59:59:999 +02:00", "2019-10-23 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-10-25 23:59:59:999 +02:00", "2019-10-25 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-10-27 23:59:59:999 +01:00", "2019-10-27 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-10-29 23:59:59:999 +01:00", "2019-10-29 12:00:00:000 +01:00", romance)

            };

            for (int i = 0; i < samples.Length; i++) {

                var s = samples[i];

                DateTimeOffset result1 = TimeUtils.GetEndOfDay(s.Time, s.TimeZone);

                EssentialsTime result2 = new EssentialsTime(s.Time, s.TimeZone).GetEndOfDay();

                EssentialsTime result3 = new EssentialsTime(s.Time, s.TimeZone).GetEndOfDay(s.TimeZone);

                Assert.AreEqual(s.Expected, result1.ToString(Format), $"Sample at index {i} failed test (DateTimeOffset)");

                Assert.AreEqual(s.Expected, result2.ToString(Format), $"Sample at index {i} failed test (EssentialsTime)");

                Assert.AreEqual(s.Expected, result3.ToString(Format), $"Sample at index {i} failed test (EssentialsTime)");

            }

        }

        [TestMethod]
        public void GetStartOfWeek() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var samples = new[] {

                new GetOfDaySample("2019-03-18 00:00:00:000 +00:00", "2019-03-18 12:00:00:000 +00:00", null),
                new GetOfDaySample("2019-03-18 00:00:00:000 +00:00", "2019-03-23 12:00:00:000 +00:00", null),
                new GetOfDaySample("2019-03-25 00:00:00:000 +00:00", "2019-03-26 12:00:00:000 +00:00", null),

                new GetOfDaySample("2019-03-18 00:00:00:000 +00:00", "2019-03-18 12:00:00:000 +00:00", utc),
                new GetOfDaySample("2019-03-18 00:00:00:000 +00:00", "2019-03-23 12:00:00:000 +00:00", utc),
                new GetOfDaySample("2019-03-25 00:00:00:000 +00:00", "2019-03-26 12:00:00:000 +00:00", utc),

                new GetOfDaySample("2019-03-18 00:00:00:000 +01:00", "2019-03-23 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-18 00:00:00:000 +01:00", "2019-03-24 12:00:00:000 +01:00", romance),

                new GetOfDaySample("2019-03-25 00:00:00:000 +01:00", "2019-03-25 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-25 00:00:00:000 +01:00", "2019-03-26 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-25 00:00:00:000 +01:00", "2019-03-27 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-25 00:00:00:000 +01:00", "2019-03-28 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-25 00:00:00:000 +01:00", "2019-03-29 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-25 00:00:00:000 +01:00", "2019-03-30 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-25 00:00:00:000 +01:00", "2019-03-31 12:00:00:000 +02:00", romance),

                new GetOfDaySample("2019-04-01 00:00:00:000 +02:00", "2019-04-01 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-04-01 00:00:00:000 +02:00", "2019-04-02 12:00:00:000 +02:00", romance),

                new GetOfDaySample("2019-10-21 00:00:00:000 +02:00", "2019-10-23 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-10-21 00:00:00:000 +02:00", "2019-10-25 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-10-21 00:00:00:000 +02:00", "2019-10-27 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-10-28 00:00:00:000 +01:00", "2019-10-29 12:00:00:000 +01:00", romance)

            };

            for (int i = 0; i < samples.Length; i++) {

                var s = samples[i];

                DateTimeOffset result1 = TimeUtils.GetStartOfWeek(s.Time, s.TimeZone);

                EssentialsTime result2 = new EssentialsTime(s.Time, s.TimeZone).GetStartOfWeek();

                EssentialsTime result3 = new EssentialsTime(s.Time, s.TimeZone).GetStartOfWeek(s.TimeZone);

                Assert.AreEqual(s.Expected, result1.ToString(Format), $"Sample at index {i} failed test (DateTimeOffset)");

                Assert.AreEqual(s.Expected, result2.ToString(Format), $"Sample at index {i} failed test (EssentialsTime)");

                Assert.AreEqual(s.Expected, result3.ToString(Format), $"Sample at index {i} failed test (EssentialsTime)");

            }

        }

        [TestMethod]
        public void GetEndOfWeek() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var samples = new[] {

                new GetOfDaySample("2019-03-24 23:59:59:999 +00:00", "2019-03-18 12:00:00:000 +00:00", null),
                new GetOfDaySample("2019-03-24 23:59:59:999 +00:00", "2019-03-23 12:00:00:000 +00:00", null),
                new GetOfDaySample("2019-03-31 23:59:59:999 +00:00", "2019-03-26 12:00:00:000 +00:00", null),

                new GetOfDaySample("2019-03-24 23:59:59:999 +00:00", "2019-03-18 12:00:00:000 +00:00", utc),
                new GetOfDaySample("2019-03-24 23:59:59:999 +00:00", "2019-03-23 12:00:00:000 +00:00", utc),
                new GetOfDaySample("2019-03-31 23:59:59:999 +00:00", "2019-03-26 12:00:00:000 +00:00", utc),

                new GetOfDaySample("2019-03-24 23:59:59:999 +01:00", "2019-03-23 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-24 23:59:59:999 +01:00", "2019-03-24 12:00:00:000 +01:00", romance),

                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-25 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-26 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-27 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-28 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-29 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-30 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-31 12:00:00:000 +02:00", romance),

                new GetOfDaySample("2019-04-07 23:59:59:999 +02:00", "2019-04-01 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-04-07 23:59:59:999 +02:00", "2019-04-02 12:00:00:000 +02:00", romance),

                new GetOfDaySample("2019-10-27 23:59:59:999 +01:00", "2019-10-23 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-10-27 23:59:59:999 +01:00", "2019-10-25 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-10-27 23:59:59:999 +01:00", "2019-10-27 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-11-03 23:59:59:999 +01:00", "2019-10-29 12:00:00:000 +01:00", romance)

            };

            for (int i = 0; i < samples.Length; i++) {

                var s = samples[i];

                DateTimeOffset result1 = TimeUtils.GetEndOfWeek(s.Time, s.TimeZone);

                EssentialsTime result2 = new EssentialsTime(s.Time, s.TimeZone).GetEndOfWeek();

                EssentialsTime result3 = new EssentialsTime(s.Time, s.TimeZone).GetEndOfWeek(s.TimeZone);

                Assert.AreEqual(s.Expected, result1.ToString(Format), $"Sample at index {i} failed test (DateTimeOffset)");

                Assert.AreEqual(s.Expected, result2.ToString(Format), $"Sample at index {i} failed test (EssentialsTime)");

                Assert.AreEqual(s.Expected, result3.ToString(Format), $"Sample at index {i} failed test (EssentialsTime)");

            }

        }

        [TestMethod]
        public void GetStartOfMonth() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var samples = new[] {

                new GetOfDaySample("2019-03-01 00:00:00:000 +00:00", "2019-03-18 12:00:00:000 +00:00", null),
                new GetOfDaySample("2019-03-01 00:00:00:000 +00:00", "2019-03-23 12:00:00:000 +00:00", null),
                new GetOfDaySample("2019-03-01 00:00:00:000 +00:00", "2019-03-26 12:00:00:000 +00:00", null),

                new GetOfDaySample("2019-03-01 00:00:00:000 +00:00", "2019-03-18 12:00:00:000 +00:00", utc),
                new GetOfDaySample("2019-03-01 00:00:00:000 +00:00", "2019-03-23 12:00:00:000 +00:00", utc),
                new GetOfDaySample("2019-03-01 00:00:00:000 +00:00", "2019-03-26 12:00:00:000 +00:00", utc),

                new GetOfDaySample("2019-03-01 00:00:00:000 +01:00", "2019-03-23 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-01 00:00:00:000 +01:00", "2019-03-24 12:00:00:000 +01:00", romance),

                new GetOfDaySample("2019-03-01 00:00:00:000 +01:00", "2019-03-25 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-01 00:00:00:000 +01:00", "2019-03-26 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-01 00:00:00:000 +01:00", "2019-03-27 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-01 00:00:00:000 +01:00", "2019-03-28 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-01 00:00:00:000 +01:00", "2019-03-29 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-01 00:00:00:000 +01:00", "2019-03-30 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-01 00:00:00:000 +01:00", "2019-03-31 12:00:00:000 +02:00", romance),

                new GetOfDaySample("2019-04-01 00:00:00:000 +02:00", "2019-04-01 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-04-01 00:00:00:000 +02:00", "2019-04-02 12:00:00:000 +02:00", romance),

                new GetOfDaySample("2019-10-01 00:00:00:000 +02:00", "2019-10-23 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-10-01 00:00:00:000 +02:00", "2019-10-25 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-10-01 00:00:00:000 +02:00", "2019-10-27 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-10-01 00:00:00:000 +02:00", "2019-10-29 12:00:00:000 +01:00", romance)

            };

            for (int i = 0; i < samples.Length; i++) {

                var s = samples[i];

                DateTimeOffset result1 = TimeUtils.GetStartOfMonth(s.Time, s.TimeZone);

                EssentialsTime result2 = new EssentialsTime(s.Time, s.TimeZone).GetStartOfMonth();

                EssentialsTime result3 = new EssentialsTime(s.Time, s.TimeZone).GetStartOfMonth(s.TimeZone);

                Assert.AreEqual(s.Expected, result1.ToString(Format), $"Sample at index {i} failed test (DateTimeOffset)");

                Assert.AreEqual(s.Expected, result2.ToString(Format), $"Sample at index {i} failed test (EssentialsTime)");

                Assert.AreEqual(s.Expected, result3.ToString(Format), $"Sample at index {i} failed test (EssentialsTime)");

            }

        }

        [TestMethod]
        public void GetEndOfMonth() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var samples = new[] {

                new GetOfDaySample("2019-03-31 23:59:59:999 +00:00", "2019-03-18 12:00:00:000 +00:00", null),
                new GetOfDaySample("2019-03-31 23:59:59:999 +00:00", "2019-03-23 12:00:00:000 +00:00", null),
                new GetOfDaySample("2019-03-31 23:59:59:999 +00:00", "2019-03-26 12:00:00:000 +00:00", null),

                new GetOfDaySample("2019-03-31 23:59:59:999 +00:00", "2019-03-18 12:00:00:000 +00:00", utc),
                new GetOfDaySample("2019-03-31 23:59:59:999 +00:00", "2019-03-23 12:00:00:000 +00:00", utc),
                new GetOfDaySample("2019-03-31 23:59:59:999 +00:00", "2019-03-26 12:00:00:000 +00:00", utc),

                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-23 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-24 12:00:00:000 +01:00", romance),

                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-25 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-26 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-27 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-28 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-29 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-30 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-31 12:00:00:000 +02:00", romance),

                new GetOfDaySample("2019-04-30 23:59:59:999 +02:00", "2019-04-01 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-04-30 23:59:59:999 +02:00", "2019-04-02 12:00:00:000 +02:00", romance),

                new GetOfDaySample("2019-10-31 23:59:59:999 +01:00", "2019-10-23 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-10-31 23:59:59:999 +01:00", "2019-10-25 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-10-31 23:59:59:999 +01:00", "2019-10-27 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-10-31 23:59:59:999 +01:00", "2019-10-29 12:00:00:000 +01:00", romance)

            };

            for (int i = 0; i < samples.Length; i++) {

                var s = samples[i];

                DateTimeOffset result1 = TimeUtils.GetEndOfMonth(s.Time, s.TimeZone);

                EssentialsTime result2 = new EssentialsTime(s.Time, s.TimeZone).GetEndOfMonth();

                EssentialsTime result3 = new EssentialsTime(s.Time, s.TimeZone).GetEndOfMonth(s.TimeZone);

                Assert.AreEqual(s.Expected, result1.ToString(Format), $"Sample at index {i} failed test (DateTimeOffset)");

                Assert.AreEqual(s.Expected, result2.ToString(Format), $"Sample at index {i} failed test (EssentialsTime)");

                Assert.AreEqual(s.Expected, result3.ToString(Format), $"Sample at index {i} failed test (EssentialsTime)");

            }

        }

        [TestMethod]
        public void GetStartOfQuarter() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var samples = new[] {

                new GetOfDaySample("2019-01-01 00:00:00:000 +00:00", "2019-03-18 12:00:00:000 +00:00", null),
                new GetOfDaySample("2019-01-01 00:00:00:000 +00:00", "2019-03-23 12:00:00:000 +00:00", null),
                new GetOfDaySample("2019-01-01 00:00:00:000 +00:00", "2019-03-26 12:00:00:000 +00:00", null),

                new GetOfDaySample("2019-01-01 00:00:00:000 +00:00", "2019-03-18 12:00:00:000 +00:00", utc),
                new GetOfDaySample("2019-01-01 00:00:00:000 +00:00", "2019-03-23 12:00:00:000 +00:00", utc),
                new GetOfDaySample("2019-01-01 00:00:00:000 +00:00", "2019-03-26 12:00:00:000 +00:00", utc),

                new GetOfDaySample("2019-01-01 00:00:00:000 +01:00", "2019-03-23 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-01-01 00:00:00:000 +01:00", "2019-03-24 12:00:00:000 +01:00", romance),

                new GetOfDaySample("2019-01-01 00:00:00:000 +01:00", "2019-03-25 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-01-01 00:00:00:000 +01:00", "2019-03-26 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-01-01 00:00:00:000 +01:00", "2019-03-27 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-01-01 00:00:00:000 +01:00", "2019-03-28 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-01-01 00:00:00:000 +01:00", "2019-03-29 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-01-01 00:00:00:000 +01:00", "2019-03-30 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-01-01 00:00:00:000 +01:00", "2019-03-31 12:00:00:000 +02:00", romance),

                new GetOfDaySample("2019-04-01 00:00:00:000 +02:00", "2019-04-01 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-04-01 00:00:00:000 +02:00", "2019-04-02 12:00:00:000 +02:00", romance),

                new GetOfDaySample("2019-10-01 00:00:00:000 +02:00", "2019-10-23 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-10-01 00:00:00:000 +02:00", "2019-10-25 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-10-01 00:00:00:000 +02:00", "2019-10-27 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-10-01 00:00:00:000 +02:00", "2019-10-29 12:00:00:000 +01:00", romance)

            };

            for (int i = 0; i < samples.Length; i++) {

                var s = samples[i];

                DateTimeOffset result1 = TimeUtils.GetStartOfQuarter(s.Time, s.TimeZone);

                EssentialsTime result2 = new EssentialsTime(s.Time, s.TimeZone).GetStartOfQuarter();

                EssentialsTime result3 = new EssentialsTime(s.Time, s.TimeZone).GetStartOfQuarter(s.TimeZone);

                Assert.AreEqual(s.Expected, result1.ToString(Format), $"Sample at index {i} failed test (DateTimeOffset)");

                Assert.AreEqual(s.Expected, result2.ToString(Format), $"Sample at index {i} failed test (EssentialsTime)");

                Assert.AreEqual(s.Expected, result3.ToString(Format), $"Sample at index {i} failed test (EssentialsTime)");

            }

        }

        [TestMethod]
        public void GetEndOfQuarter() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var samples = new[] {

                new GetOfDaySample("2019-03-31 23:59:59:999 +00:00", "2019-03-18 12:00:00:000 +00:00", null),
                new GetOfDaySample("2019-03-31 23:59:59:999 +00:00", "2019-03-23 12:00:00:000 +00:00", null),
                new GetOfDaySample("2019-03-31 23:59:59:999 +00:00", "2019-03-26 12:00:00:000 +00:00", null),

                new GetOfDaySample("2019-03-31 23:59:59:999 +00:00", "2019-03-18 12:00:00:000 +00:00", utc),
                new GetOfDaySample("2019-03-31 23:59:59:999 +00:00", "2019-03-23 12:00:00:000 +00:00", utc),
                new GetOfDaySample("2019-03-31 23:59:59:999 +00:00", "2019-03-26 12:00:00:000 +00:00", utc),

                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-23 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-24 12:00:00:000 +01:00", romance),

                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-25 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-26 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-27 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-28 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-29 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-30 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-03-31 23:59:59:999 +02:00", "2019-03-31 12:00:00:000 +02:00", romance),

                new GetOfDaySample("2019-06-30 23:59:59:999 +02:00", "2019-04-01 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-06-30 23:59:59:999 +02:00", "2019-04-02 12:00:00:000 +02:00", romance),

                new GetOfDaySample("2019-12-31 23:59:59:999 +01:00", "2019-10-23 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-12-31 23:59:59:999 +01:00", "2019-10-25 12:00:00:000 +02:00", romance),
                new GetOfDaySample("2019-12-31 23:59:59:999 +01:00", "2019-10-27 12:00:00:000 +01:00", romance),
                new GetOfDaySample("2019-12-31 23:59:59:999 +01:00", "2019-10-29 12:00:00:000 +01:00", romance)

            };

            for (int i = 0; i < samples.Length; i++) {

                var s = samples[i];

                DateTimeOffset result1 = TimeUtils.GetEndOfQuarter(s.Time, s.TimeZone);

                EssentialsTime result2 = new EssentialsTime(s.Time, s.TimeZone).GetEndOfQuarter();

                EssentialsTime result3 = new EssentialsTime(s.Time, s.TimeZone).GetEndOfQuarter(s.TimeZone);

                Assert.AreEqual(s.Expected, result1.ToString(Format), $"Sample at index {i} failed test (DateTimeOffset)");

                Assert.AreEqual(s.Expected, result2.ToString(Format), $"Sample at index {i} failed test (EssentialsTime)");

                Assert.AreEqual(s.Expected, result3.ToString(Format), $"Sample at index {i} failed test (EssentialsTime)");

            }

        }


        public class GetOfDaySample {

            public string Expected { get; }

            public DateTimeOffset Time { get; }

            public TimeZoneInfo TimeZone { get; }

            public GetOfDaySample(string expected, int year, int month, int day, int hour, int minute, int second, TimeSpan offset, TimeZoneInfo timeZone) {
                Expected = expected;
                Time = new DateTimeOffset(year, month, day, hour, minute, second, offset);
                TimeZone = timeZone;
            }

            public GetOfDaySample(string expected, string input, TimeZoneInfo timeZone) {
                Expected = expected;
                Time = DateTimeOffset.ParseExact(input, Format, CultureInfo.InvariantCulture);
                TimeZone = timeZone;
            }

        }

    }

}