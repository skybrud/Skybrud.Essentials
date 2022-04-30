using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.Iso8601;

namespace UnitTestProject1.Time {

    [TestClass]
    public class TimeUtilsTests {

        [TestMethod]
        public void GetStartOfWeek() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset day1 = new DateTimeOffset(2019, 3, 25, 12, 0, 0, TimeSpan.FromHours(1));
            DateTimeOffset day2 = new DateTimeOffset(2019, 3, 26, 12, 0, 0, TimeSpan.FromHours(1));
            DateTimeOffset day3 = new DateTimeOffset(2019, 3, 27, 12, 0, 0, TimeSpan.FromHours(1));
            DateTimeOffset day4 = new DateTimeOffset(2019, 3, 28, 12, 0, 0, TimeSpan.FromHours(1));
            DateTimeOffset day5 = new DateTimeOffset(2019, 3, 29, 12, 0, 0, TimeSpan.FromHours(1));
            DateTimeOffset day6 = new DateTimeOffset(2019, 3, 30, 12, 0, 0, TimeSpan.FromHours(1));
            DateTimeOffset day7 = new DateTimeOffset(2019, 3, 31, 12, 0, 0, TimeSpan.FromHours(2));

            DateTimeOffset start1 = TimeUtils.GetStartOfWeek(day1, romance);
            DateTimeOffset start2 = TimeUtils.GetStartOfWeek(day2, romance);
            DateTimeOffset start3 = TimeUtils.GetStartOfWeek(day3, romance);
            DateTimeOffset start4 = TimeUtils.GetStartOfWeek(day4, romance);
            DateTimeOffset start5 = TimeUtils.GetStartOfWeek(day5, romance);
            DateTimeOffset start6 = TimeUtils.GetStartOfWeek(day6, romance);
            DateTimeOffset start7 = TimeUtils.GetStartOfWeek(day7, romance);

            Assert.AreEqual("2019-03-25T00:00:00+01:00", start1.ToString(Iso8601Constants.DateTimeSeconds), "Day 1");
            Assert.AreEqual("2019-03-25T00:00:00+01:00", start2.ToString(Iso8601Constants.DateTimeSeconds), "Day 2");
            Assert.AreEqual("2019-03-25T00:00:00+01:00", start3.ToString(Iso8601Constants.DateTimeSeconds), "Day 3");
            Assert.AreEqual("2019-03-25T00:00:00+01:00", start4.ToString(Iso8601Constants.DateTimeSeconds), "Day 4");
            Assert.AreEqual("2019-03-25T00:00:00+01:00", start5.ToString(Iso8601Constants.DateTimeSeconds), "Day 5");
            Assert.AreEqual("2019-03-25T00:00:00+01:00", start6.ToString(Iso8601Constants.DateTimeSeconds), "Day 6");
            Assert.AreEqual("2019-03-25T00:00:00+01:00", start7.ToString(Iso8601Constants.DateTimeSeconds), "Day 7");

        }

        [TestMethod]
        public void GetEndOfWeek() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset day1 = new DateTimeOffset(2019, 3, 25, 12, 0, 0, TimeSpan.FromHours(1));
            DateTimeOffset day2 = new DateTimeOffset(2019, 3, 26, 12, 0, 0, TimeSpan.FromHours(1));
            DateTimeOffset day3 = new DateTimeOffset(2019, 3, 27, 12, 0, 0, TimeSpan.FromHours(1));
            DateTimeOffset day4 = new DateTimeOffset(2019, 3, 28, 12, 0, 0, TimeSpan.FromHours(1));
            DateTimeOffset day5 = new DateTimeOffset(2019, 3, 29, 12, 0, 0, TimeSpan.FromHours(1));
            DateTimeOffset day6 = new DateTimeOffset(2019, 3, 30, 12, 0, 0, TimeSpan.FromHours(1));
            DateTimeOffset day7 = new DateTimeOffset(2019, 3, 31, 12, 0, 0, TimeSpan.FromHours(2));

            DateTimeOffset end1 = TimeUtils.GetEndOfWeek(day1, romance);
            DateTimeOffset end2 = TimeUtils.GetEndOfWeek(day2, romance);
            DateTimeOffset end3 = TimeUtils.GetEndOfWeek(day3, romance);
            DateTimeOffset end4 = TimeUtils.GetEndOfWeek(day4, romance);
            DateTimeOffset end5 = TimeUtils.GetEndOfWeek(day5, romance);
            DateTimeOffset end6 = TimeUtils.GetEndOfWeek(day6, romance);
            DateTimeOffset end7 = TimeUtils.GetEndOfWeek(day7, romance);

            Assert.AreEqual("2019-03-31T23:59:59+02:00", end1.ToString(Iso8601Constants.DateTimeSeconds), "Day 1");
            Assert.AreEqual("2019-03-31T23:59:59+02:00", end2.ToString(Iso8601Constants.DateTimeSeconds), "Day 2");
            Assert.AreEqual("2019-03-31T23:59:59+02:00", end3.ToString(Iso8601Constants.DateTimeSeconds), "Day 3");
            Assert.AreEqual("2019-03-31T23:59:59+02:00", end4.ToString(Iso8601Constants.DateTimeSeconds), "Day 4");
            Assert.AreEqual("2019-03-31T23:59:59+02:00", end5.ToString(Iso8601Constants.DateTimeSeconds), "Day 5");
            Assert.AreEqual("2019-03-31T23:59:59+02:00", end6.ToString(Iso8601Constants.DateTimeSeconds), "Day 6");
            Assert.AreEqual("2019-03-31T23:59:59+02:00", end7.ToString(Iso8601Constants.DateTimeSeconds), "Day 7");

        }

    }

}