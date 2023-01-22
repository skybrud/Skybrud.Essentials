using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.Time {

    [TestClass]
    public class DateTimeTests {

        private const string _format = "yyyy-MM-dd HH:mm:ss";

        [TestMethod]
        public void GetStartOfDay() {

            DateTime time = new DateTime(2023, 1, 22, 12, 0, 0);

            DateTime result = TimeUtils.GetStartOfDay(time);

            Assert.AreEqual("2023-01-22 00:00:00", result.ToString(_format, CultureInfo.CurrentCulture));

        }

        [TestMethod]
        public void GetEndOfDay() {

            DateTime time = new DateTime(2023, 1, 22, 12, 0, 0);

            DateTime result = TimeUtils.GetEndOfDay(time);

            Assert.AreEqual("2023-01-22 23:59:59", result.ToString(_format, CultureInfo.CurrentCulture));

        }

        [TestMethod]
        public void GetStartOfWeek() {

            DateTime time = new DateTime(2023, 1, 22, 12, 0, 0);

            DateTime result1 = TimeUtils.GetStartOfWeek(time);
            DateTime result2 = TimeUtils.GetStartOfWeek(time, DayOfWeek.Monday);
            DateTime result3 = TimeUtils.GetStartOfWeek(time, DayOfWeek.Sunday);

            Assert.AreEqual("2023-01-16 00:00:00", result1.ToString(_format, CultureInfo.CurrentCulture));
            Assert.AreEqual("2023-01-16 00:00:00", result2.ToString(_format, CultureInfo.CurrentCulture));
            Assert.AreEqual("2023-01-22 00:00:00", result3.ToString(_format, CultureInfo.CurrentCulture));

        }

        [TestMethod]
        public void GetEndOfWeek() {

            DateTime time = new DateTime(2023, 1, 22, 12, 0, 0);

            var result1 = TimeUtils.GetEndOfWeek(time);
            var result2 = TimeUtils.GetEndOfWeek(time, DayOfWeek.Monday);
            var result3 = TimeUtils.GetEndOfWeek(time, DayOfWeek.Sunday);

            Assert.AreEqual("2023-01-22 23:59:59", result1.ToString(_format, CultureInfo.CurrentCulture));
            Assert.AreEqual("2023-01-22 23:59:59", result2.ToString(_format, CultureInfo.CurrentCulture));
            Assert.AreEqual("2023-01-28 23:59:59", result3.ToString(_format, CultureInfo.CurrentCulture));

        }

        [TestMethod]
        public void GetStartOfMonth() {

            DateTime time = new DateTime(2023, 1, 22, 12, 0, 0);

            DateTime result = TimeUtils.GetStartOfMonth(time);

            Assert.AreEqual("2023-01-01 00:00:00", result.ToString(_format, CultureInfo.CurrentCulture));

        }

        [TestMethod]
        public void GetEndOfMonth() {

            DateTime time = new DateTime(2023, 1, 22, 12, 0, 0);

            var result1 = TimeUtils.GetEndOfMonth(time);

            Assert.AreEqual("2023-01-31 23:59:59", result1.ToString(_format, CultureInfo.CurrentCulture));

        }

        [TestMethod]
        public void GetQuarter() {

            DateTime time1 = new DateTime(2023, 1, 22, 12, 0, 0);
            DateTime time2 = new DateTime(2023, 6, 5, 12, 0, 0);
            DateTime time3 = new DateTime(2023, 7, 4, 12, 0, 0);

            int result1 = TimeUtils.GetQuarter(time1);
            int result2 = TimeUtils.GetQuarter(time2);
            int result3 = TimeUtils.GetQuarter(time3);

            Assert.AreEqual(1, result1);
            Assert.AreEqual(2, result2);
            Assert.AreEqual(3, result3);

        }

        [TestMethod]
        public void GetStartOfQuarter() {

            DateTime time = new DateTime(2023, 1, 22, 12, 0, 0);

            DateTime result = TimeUtils.GetStartOfQuarter(time);

            Assert.AreEqual("2023-01-01 00:00:00", result.ToString(_format, CultureInfo.CurrentCulture));

        }

        [TestMethod]
        public void GetEndOfQuarter() {

            DateTime time = new DateTime(2023, 1, 22, 12, 0, 0);

            var result1 = TimeUtils.GetEndOfQuarter(time);

            Assert.AreEqual("2023-03-31 23:59:59", result1.ToString(_format, CultureInfo.CurrentCulture));

        }

    }

}