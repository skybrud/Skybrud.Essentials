using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time {

    [TestClass]
    public class EssentialsTimeTests {

        [TestMethod]
        public void Add() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            EssentialsTime value = new EssentialsTime(2022, 4, 25, 7, 55, 0, utc);

            EssentialsTime result = value.Add(TimeSpan.FromMinutes(5));

            Assert.AreEqual(value.TimeZone, result.TimeZone);

        }

        [TestMethod]
        public void AddDays() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            EssentialsTime value = new EssentialsTime(2022, 4, 25, 7, 55, 0, utc);

            EssentialsTime result = value.AddDays(1);

            Assert.AreEqual(value.TimeZone, result.TimeZone);

        }

        [TestMethod]
        public void AddHours() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            EssentialsTime value = new EssentialsTime(2022, 4, 25, 7, 55, 0, utc);

            EssentialsTime result = value.AddHours(1);

            Assert.AreEqual(value.TimeZone, result.TimeZone);

        }

        [TestMethod]
        public void AddMilliseconds() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            EssentialsTime value = new EssentialsTime(2022, 4, 25, 7, 55, 0, utc);

            EssentialsTime result = value.AddMilliseconds(1);

            Assert.AreEqual(value.TimeZone, result.TimeZone);

        }

        [TestMethod]
        public void AddMinutes() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            EssentialsTime value = new EssentialsTime(2022, 4, 25, 7, 55, 0, utc);

            EssentialsTime result = value.AddMinutes(1);

            Assert.AreEqual(value.TimeZone, result.TimeZone);

        }

        [TestMethod]
        public void AddMonths() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            EssentialsTime value = new EssentialsTime(2022, 4, 25, 7, 55, 0, utc);

            EssentialsTime result = value.AddMonths(1);

            Assert.AreEqual(value.TimeZone, result.TimeZone);

        }

        [TestMethod]
        public void AddSeconds() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            EssentialsTime value = new EssentialsTime(2022, 4, 25, 7, 55, 0, utc);

            EssentialsTime result = value.AddSeconds(1);

            Assert.AreEqual(value.TimeZone, result.TimeZone);

        }

        [TestMethod]
        public void AddTicks() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            EssentialsTime value = new EssentialsTime(2022, 4, 25, 7, 55, 0, utc);

            EssentialsTime result = value.AddTicks(1);

            Assert.AreEqual(value.TimeZone, result.TimeZone);

        }

        [TestMethod]
        public void AddYears() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            EssentialsTime value = new EssentialsTime(2022, 4, 25, 7, 55, 0, utc);

            EssentialsTime result = value.AddYears(1);

            Assert.AreEqual(value.TimeZone, result.TimeZone);

        }

        [TestMethod]
        public void Subtract() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            EssentialsTime value = new EssentialsTime(2022, 4, 25, 7, 55, 0, utc);

            EssentialsTime result = value.Subtract(TimeSpan.FromMinutes(5));

            Assert.AreEqual(value.TimeZone, result.TimeZone);

        }

        [TestMethod]
        public void GetQuarter() {

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsTime time1 = new EssentialsTime(2022, 3, 24, 12, 0, 0, timeZone);
            EssentialsTime time2 = new EssentialsTime(2022, 3, 31, 12, 0, 0, timeZone);

            EssentialsTime time3 = new EssentialsTime(2022, 10, 27, 12, 0, 0, timeZone);
            EssentialsTime time4 = new EssentialsTime(2022, 11, 3, 12, 0, 0, timeZone);

            Assert.AreEqual(1, time1.Quarter, "#1");
            Assert.AreEqual(1, time2.Quarter, "#2");
            Assert.AreEqual(4, time3.Quarter, "#3");
            Assert.AreEqual(4, time4.Quarter, "#4");

        }

        [TestMethod]
        public void GetStartOfQuarter() {

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsTime time1 = new EssentialsTime(2022, 3, 24, 12, 0, 0, timeZone);
            EssentialsTime time2 = new EssentialsTime(2022, 3, 31, 12, 0, 0, timeZone);

            EssentialsTime time3 = new EssentialsTime(2022, 10, 27, 12, 0, 0, timeZone);
            EssentialsTime time4 = new EssentialsTime(2022, 11, 3, 12, 0, 0, timeZone);

            EssentialsTime start1 = time1.GetStartOfQuarter();
            EssentialsTime start2 = time2.GetStartOfQuarter();

            EssentialsTime start3 = time3.GetStartOfQuarter();
            EssentialsTime start4 = time4.GetStartOfQuarter();

            Assert.AreEqual("2022-01-01T00:00:00.000+01:00", start1.Iso8601);
            Assert.AreEqual("2022-01-01T00:00:00.000+01:00", start2.Iso8601);

            Assert.AreEqual("2022-10-01T00:00:00.000+02:00", start3.Iso8601);
            Assert.AreEqual("2022-10-01T00:00:00.000+02:00", start4.Iso8601);

        }

        [TestMethod]
        public void GetEndOfQuarter() {

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsTime time1 = new EssentialsTime(2022, 3, 24, 12, 0, 0, timeZone);
            EssentialsTime time2 = new EssentialsTime(2022, 3, 31, 12, 0, 0, timeZone);

            EssentialsTime time3 = new EssentialsTime(2022, 10, 27, 12, 0, 0, timeZone);
            EssentialsTime time4 = new EssentialsTime(2022, 11, 3, 12, 0, 0, timeZone);

            EssentialsTime end1 = time1.GetEndOfQuarter();
            EssentialsTime end2 = time2.GetEndOfQuarter();

            EssentialsTime end3 = time3.GetEndOfQuarter();
            EssentialsTime end4 = time4.GetEndOfQuarter();

            Assert.AreEqual("2022-03-31T23:59:59.999+02:00", end1.Iso8601);
            Assert.AreEqual("2022-03-31T23:59:59.999+02:00", end2.Iso8601);

            Assert.AreEqual("2022-12-31T23:59:59.999+01:00", end3.Iso8601);
            Assert.AreEqual("2022-12-31T23:59:59.999+01:00", end4.Iso8601);

        }

    }

}