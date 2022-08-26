using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.TimeUtilsTests {

    [TestClass]
    public class QuarterTests {

        [TestMethod]
        public void GetQuarter() {

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsTime time1 = new EssentialsTime(2022, 3, 24, 12, 0, 0, timeZone);
            EssentialsTime time2 = new EssentialsTime(2022, 3, 31, 12, 0, 0, timeZone);

            EssentialsTime time3 = new EssentialsTime(2022, 10, 27, 12, 0, 0, timeZone);
            EssentialsTime time4 = new EssentialsTime(2022, 11, 3, 12, 0, 0, timeZone);

            Assert.AreEqual(1, TimeUtils.GetQuarter(time1), "#1");
            Assert.AreEqual(1, TimeUtils.GetQuarter(time2), "#2");
            Assert.AreEqual(4, TimeUtils.GetQuarter(time3), "#3");
            Assert.AreEqual(4, TimeUtils.GetQuarter(time4), "#4");

        }

        [TestMethod]
        public void GetStartOf() {

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsTime time1 = new EssentialsTime(2022, 3, 24, 12, 0, 0, timeZone);
            EssentialsTime time2 = new EssentialsTime(2022, 3, 31, 12, 0, 0, timeZone);

            EssentialsTime time3 = new EssentialsTime(2022, 10, 27, 12, 0, 0, timeZone);
            EssentialsTime time4 = new EssentialsTime(2022, 11, 3, 12, 0, 0, timeZone);

            EssentialsTime start1 = TimeUtils.GetStartOfQuarter(time1);
            EssentialsTime start2 = TimeUtils.GetStartOfQuarter(time2);

            EssentialsTime start3 = TimeUtils.GetStartOfQuarter(time3);
            EssentialsTime start4 = TimeUtils.GetStartOfQuarter(time4);

            Assert.AreEqual("2022-01-01T00:00:00.000+01:00", start1.Iso8601);
            Assert.AreEqual("2022-01-01T00:00:00.000+01:00", start2.Iso8601);

            Assert.AreEqual("2022-10-01T00:00:00.000+02:00", start3.Iso8601);
            Assert.AreEqual("2022-10-01T00:00:00.000+02:00", start4.Iso8601);

        }

        [TestMethod]
        public void GetEndOf() {

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsTime time1 = new EssentialsTime(2022, 3, 24, 12, 0, 0, timeZone);
            EssentialsTime time2 = new EssentialsTime(2022, 3, 31, 12, 0, 0, timeZone);

            EssentialsTime time3 = new EssentialsTime(2022, 10, 27, 12, 0, 0, timeZone);
            EssentialsTime time4 = new EssentialsTime(2022, 11, 3, 12, 0, 0, timeZone);

            EssentialsTime end1 = TimeUtils.GetEndOfQuarter(time1);
            EssentialsTime end2 = TimeUtils.GetEndOfQuarter(time2);

            EssentialsTime end3 = TimeUtils.GetEndOfQuarter(time3);
            EssentialsTime end4 = TimeUtils.GetEndOfQuarter(time4);

            Assert.AreEqual("2022-03-31T23:59:59.999+02:00", end1.Iso8601);
            Assert.AreEqual("2022-03-31T23:59:59.999+02:00", end2.Iso8601);

            Assert.AreEqual("2022-12-31T23:59:59.999+01:00", end3.Iso8601);
            Assert.AreEqual("2022-12-31T23:59:59.999+01:00", end4.Iso8601);

        }

        /// <remarks>
        /// This test runs through five consecutive hours on the 27th of March, 2022. While using the same time zone,
        /// the give hours changes offset since <strong>Romanance Standard Time</strong> switches from
        /// <em>Standard Time</em> time to <em>Dayling Savings Time</em> on this exact date.
        ///
        /// Regardless of the offset, the five hours should all result in the same end date, which is what this test
        /// tries to prove.
        /// </remarks>
        [TestMethod]
        public void GetEndOf2() {

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsTime time1 = new EssentialsTime(2022, 3, 27, 00, 0, 0, timeZone);
            EssentialsTime time2 = new EssentialsTime(2022, 3, 27, 01, 0, 0, timeZone);
            EssentialsTime time3 = new EssentialsTime(2022, 3, 27, 02, 0, 0, timeZone);
            EssentialsTime time4 = new EssentialsTime(2022, 3, 27, 03, 0, 0, timeZone);
            EssentialsTime time5 = new EssentialsTime(2022, 3, 27, 04, 0, 0, timeZone);

            EssentialsTime end1 = TimeUtils.GetEndOfQuarter(time1);
            EssentialsTime end2 = TimeUtils.GetEndOfQuarter(time2);
            EssentialsTime end3 = TimeUtils.GetEndOfQuarter(time3);
            EssentialsTime end4 = TimeUtils.GetEndOfQuarter(time4);
            EssentialsTime end5 = TimeUtils.GetEndOfQuarter(time5);

            Assert.AreEqual("2022-03-31T23:59:59.999+02:00", end1.Iso8601);
            Assert.AreEqual("2022-03-31T23:59:59.999+02:00", end2.Iso8601);
            Assert.AreEqual("2022-03-31T23:59:59.999+02:00", end3.Iso8601);
            Assert.AreEqual("2022-03-31T23:59:59.999+02:00", end4.Iso8601);
            Assert.AreEqual("2022-03-31T23:59:59.999+02:00", end5.Iso8601);

        }

        /// <remarks>
        /// This test runs through five consecutive hours on the 30th of October, 2022. While using the same time zone,
        /// the give hours changes offset since <strong>Romanance Standard Time</strong> switches from
        /// <em>Dayling Savings Time</em> time to <em>Standard Time</em> on this exact date.
        ///
        /// Regardless of the offset, the five hours should all result in the same end date, which is what this test
        /// tries to prove.
        /// </remarks>
        [TestMethod]
        public void GetEndOf3() {

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsTime time1 = new EssentialsTime(2022, 10, 30, 00, 0, 0, timeZone);
            EssentialsTime time2 = new EssentialsTime(2022, 10, 30, 01, 0, 0, timeZone);
            EssentialsTime time3 = new EssentialsTime(2022, 10, 30, 02, 0, 0, timeZone);
            EssentialsTime time4 = new EssentialsTime(2022, 10, 30, 03, 0, 0, timeZone);
            EssentialsTime time5 = new EssentialsTime(2022, 10, 30, 04, 0, 0, timeZone);

            EssentialsTime end1 = TimeUtils.GetEndOfQuarter(time1);
            EssentialsTime end2 = TimeUtils.GetEndOfQuarter(time2);
            EssentialsTime end3 = TimeUtils.GetEndOfQuarter(time3);
            EssentialsTime end4 = TimeUtils.GetEndOfQuarter(time4);
            EssentialsTime end5 = TimeUtils.GetEndOfQuarter(time5);

            Assert.AreEqual("2022-12-31T23:59:59.999+01:00", end1.Iso8601);
            Assert.AreEqual("2022-12-31T23:59:59.999+01:00", end2.Iso8601);
            Assert.AreEqual("2022-12-31T23:59:59.999+01:00", end3.Iso8601);
            Assert.AreEqual("2022-12-31T23:59:59.999+01:00", end4.Iso8601);
            Assert.AreEqual("2022-12-31T23:59:59.999+01:00", end5.Iso8601);

        }

    }

}