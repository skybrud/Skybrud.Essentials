using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;
using System;

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

    }

}