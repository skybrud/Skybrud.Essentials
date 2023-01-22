using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.Time {

    [TestClass]
    public class EssentialsDateUtilsTests {

        #region Get ... of week

        [TestMethod]
        public void GetStartOfWeek1() {

            Assert.AreEqual("2023-01-02", EssentialsDateUtils.GetStartOfWeek(2023, 1, 6).ToString(), "#D1");
            Assert.AreEqual("2023-01-09", EssentialsDateUtils.GetStartOfWeek(2023, 1, 13).ToString(), "#D2");

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfWeek(2023, 1, 6, DayOfWeek.Sunday).ToString(), "#D1");
            Assert.AreEqual("2023-01-08", EssentialsDateUtils.GetStartOfWeek(2023, 1, 13, DayOfWeek.Sunday).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfWeek2() {

            EssentialsDate d1 = new EssentialsDate(2023, 1, 6);
            EssentialsDate d2 = new EssentialsDate(2023, 1, 13);

            Assert.AreEqual("2023-01-02", EssentialsDateUtils.GetStartOfWeek(d1).ToString(), "#D1");
            Assert.AreEqual("2023-01-09", EssentialsDateUtils.GetStartOfWeek(d2).ToString(), "#D2");

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfWeek(d1, DayOfWeek.Sunday).ToString(), "#D1");
            Assert.AreEqual("2023-01-08", EssentialsDateUtils.GetStartOfWeek(d2, DayOfWeek.Sunday).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfWeek3() {

            DateTime d1 = new DateTime(2023, 1, 6);
            DateTime d2 = new DateTime(2023, 1, 13);

            Assert.AreEqual("2023-01-02", EssentialsDateUtils.GetStartOfWeek(d1).ToString(), "#D1");
            Assert.AreEqual("2023-01-09", EssentialsDateUtils.GetStartOfWeek(d2).ToString(), "#D2");

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfWeek(d1, DayOfWeek.Sunday).ToString(), "#D1");
            Assert.AreEqual("2023-01-08", EssentialsDateUtils.GetStartOfWeek(d2, DayOfWeek.Sunday).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfWeek4() {

            DateTimeOffset d1 = new DateTimeOffset(2023, 1, 6, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset d2 = new DateTimeOffset(2023, 1, 13, 0, 0, 0, TimeSpan.Zero);

            Assert.AreEqual("2023-01-02", EssentialsDateUtils.GetStartOfWeek(d1).ToString(), "#D1");
            Assert.AreEqual("2023-01-09", EssentialsDateUtils.GetStartOfWeek(d2).ToString(), "#D2");

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfWeek(d1, DayOfWeek.Sunday).ToString(), "#D1");
            Assert.AreEqual("2023-01-08", EssentialsDateUtils.GetStartOfWeek(d2, DayOfWeek.Sunday).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfWeek5() {

            EssentialsDate d1 = new EssentialsDate(2023, 1, 6);
            EssentialsDate d2 = new EssentialsDate(2023, 1, 13);

            Assert.AreEqual("2023-01-02", EssentialsDateUtils.GetStartOfWeek(d1).ToString(), "#D1");
            Assert.AreEqual("2023-01-09", EssentialsDateUtils.GetStartOfWeek(d2).ToString(), "#D2");

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfWeek(d1, DayOfWeek.Sunday).ToString(), "#D1");
            Assert.AreEqual("2023-01-08", EssentialsDateUtils.GetStartOfWeek(d2, DayOfWeek.Sunday).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfWeek6() {

            EssentialsTime d1 = new EssentialsTime(2023, 1, 6, TimeSpan.Zero);
            EssentialsTime d2 = new EssentialsTime(2023, 1, 13, TimeSpan.Zero);

            Assert.AreEqual("2023-01-02", EssentialsDateUtils.GetStartOfWeek(d1).ToString(), "#D1");
            Assert.AreEqual("2023-01-09", EssentialsDateUtils.GetStartOfWeek(d2).ToString(), "#D2");

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfWeek(d1, DayOfWeek.Sunday).ToString(), "#D1");
            Assert.AreEqual("2023-01-08", EssentialsDateUtils.GetStartOfWeek(d2, DayOfWeek.Sunday).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfWeek1() {

            Assert.AreEqual("2023-01-08", EssentialsDateUtils.GetEndOfWeek(2023, 1, 6).ToString(), "#D1");
            Assert.AreEqual("2023-01-15", EssentialsDateUtils.GetEndOfWeek(2023, 1, 13).ToString(), "#D2");

            Assert.AreEqual("2023-01-07", EssentialsDateUtils.GetEndOfWeek(2023, 1, 6, DayOfWeek.Sunday).ToString(), "#D1");
            Assert.AreEqual("2023-01-14", EssentialsDateUtils.GetEndOfWeek(2023, 1, 13, DayOfWeek.Sunday).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfWeek2() {

            DateTime d1 = new DateTime(2023, 1, 6);
            DateTime d2 = new DateTime(2023, 1, 13);

            Assert.AreEqual("2023-01-08", EssentialsDateUtils.GetEndOfWeek(d1).ToString(), "#D1");
            Assert.AreEqual("2023-01-15", EssentialsDateUtils.GetEndOfWeek(d2).ToString(), "#D2");

            Assert.AreEqual("2023-01-07", EssentialsDateUtils.GetEndOfWeek(d1, DayOfWeek.Sunday).ToString(), "#D1");
            Assert.AreEqual("2023-01-14", EssentialsDateUtils.GetEndOfWeek(d2, DayOfWeek.Sunday).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfWeek3() {

            DateTimeOffset d1 = new DateTimeOffset(2023, 1, 6, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset d2 = new DateTimeOffset(2023, 1, 13, 0, 0, 0, TimeSpan.Zero);

            Assert.AreEqual("2023-01-08", EssentialsDateUtils.GetEndOfWeek(d1).ToString(), "#D1");
            Assert.AreEqual("2023-01-15", EssentialsDateUtils.GetEndOfWeek(d2).ToString(), "#D2");

            Assert.AreEqual("2023-01-07", EssentialsDateUtils.GetEndOfWeek(d1, DayOfWeek.Sunday).ToString(), "#D1");
            Assert.AreEqual("2023-01-14", EssentialsDateUtils.GetEndOfWeek(d2, DayOfWeek.Sunday).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfWeek4() {

            EssentialsDate d1 = new EssentialsDate(2023, 1, 6);
            EssentialsDate d2 = new EssentialsDate(2023, 1, 13);

            Assert.AreEqual("2023-01-08", EssentialsDateUtils.GetEndOfWeek(d1).ToString(), "#D1");
            Assert.AreEqual("2023-01-15", EssentialsDateUtils.GetEndOfWeek(d2).ToString(), "#D2");

            Assert.AreEqual("2023-01-07", EssentialsDateUtils.GetEndOfWeek(d1, DayOfWeek.Sunday).ToString(), "#D1");
            Assert.AreEqual("2023-01-14", EssentialsDateUtils.GetEndOfWeek(d2, DayOfWeek.Sunday).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfWeek5() {

            EssentialsTime d1 = new EssentialsTime(2023, 1, 6, TimeSpan.Zero);
            EssentialsTime d2 = new EssentialsTime(2023, 1, 13, TimeSpan.Zero);

            Assert.AreEqual("2023-01-08", EssentialsDateUtils.GetEndOfWeek(d1).ToString(), "#D1");
            Assert.AreEqual("2023-01-15", EssentialsDateUtils.GetEndOfWeek(d2).ToString(), "#D2");

            Assert.AreEqual("2023-01-07", EssentialsDateUtils.GetEndOfWeek(d1, DayOfWeek.Sunday).ToString(), "#D1");
            Assert.AreEqual("2023-01-14", EssentialsDateUtils.GetEndOfWeek(d2, DayOfWeek.Sunday).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfWeek6() {

            EssentialsDate d1 = new EssentialsDate(2023, 1, 6);
            EssentialsDate d2 = new EssentialsDate(2023, 1, 13);

            Assert.AreEqual("2023-01-08", EssentialsDateUtils.GetEndOfWeek(d1).ToString(), "#D1");
            Assert.AreEqual("2023-01-15", EssentialsDateUtils.GetEndOfWeek(d2).ToString(), "#D2");

            Assert.AreEqual("2023-01-07", EssentialsDateUtils.GetEndOfWeek(d1, DayOfWeek.Sunday).ToString(), "#D1");
            Assert.AreEqual("2023-01-14", EssentialsDateUtils.GetEndOfWeek(d2, DayOfWeek.Sunday).ToString(), "#D2");

        }

        #endregion

        #region Get ... of month

        [TestMethod]
        public void GetStartOfMonth1() {

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfMonth(2023, 1).ToString(), "#D1");
            Assert.AreEqual("2023-08-01", EssentialsDateUtils.GetStartOfMonth(2023, 8).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfMonth2() {

            EssentialsDate d1 = new EssentialsDate(2023, 1, 6);
            EssentialsDate d2 = new EssentialsDate(2023, 8, 17);

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfMonth(d1).ToString(), "#D1");
            Assert.AreEqual("2023-08-01", EssentialsDateUtils.GetStartOfMonth(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfMonth3() {

            DateTime d1 = new DateTime(2023, 1, 6);
            DateTime d2 = new DateTime(2023, 8, 17);

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfMonth(d1).ToString(), "#D1");
            Assert.AreEqual("2023-08-01", EssentialsDateUtils.GetStartOfMonth(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfMonth4() {

            DateTimeOffset d1 = new DateTimeOffset(2023, 1, 6, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset d2 = new DateTimeOffset(2023, 8, 17, 0, 0, 0, TimeSpan.Zero);

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfMonth(d1).ToString(), "#D1");
            Assert.AreEqual("2023-08-01", EssentialsDateUtils.GetStartOfMonth(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfMonth5() {

            EssentialsDate d1 = new EssentialsDate(2023, 1, 6);
            EssentialsDate d2 = new EssentialsDate(2023, 8, 17);

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfMonth(d1).ToString(), "#D1");
            Assert.AreEqual("2023-08-01", EssentialsDateUtils.GetStartOfMonth(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfMonth6() {

            EssentialsTime d1 = new EssentialsTime(2023, 1, 6, TimeSpan.Zero);
            EssentialsTime d2 = new EssentialsTime(2023, 8, 17, TimeSpan.Zero);

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfMonth(d1).ToString(), "#D1");
            Assert.AreEqual("2023-08-01", EssentialsDateUtils.GetStartOfMonth(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfMonth1() {

            Assert.AreEqual("2023-01-31", EssentialsDateUtils.GetEndOfMonth(2023, 1).ToString(), "#D1");
            Assert.AreEqual("2023-08-31", EssentialsDateUtils.GetEndOfMonth(2023, 8).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfMonth2() {

            DateTime d1 = new DateTime(2023, 1, 6);
            DateTime d2 = new DateTime(2023, 8, 17);

            Assert.AreEqual("2023-01-31", EssentialsDateUtils.GetEndOfMonth(d1).ToString(), "#D1");
            Assert.AreEqual("2023-08-31", EssentialsDateUtils.GetEndOfMonth(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfMonth3() {

            DateTimeOffset d1 = new DateTimeOffset(2023, 1, 6, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset d2 = new DateTimeOffset(2023, 8, 17, 0, 0, 0, TimeSpan.Zero);

            Assert.AreEqual("2023-01-31", EssentialsDateUtils.GetEndOfMonth(d1).ToString(), "#D1");
            Assert.AreEqual("2023-08-31", EssentialsDateUtils.GetEndOfMonth(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfMonth4() {

            EssentialsDate d1 = new EssentialsDate(2023, 1, 6);
            EssentialsDate d2 = new EssentialsDate(2023, 8, 17);

            Assert.AreEqual("2023-01-31", EssentialsDateUtils.GetEndOfMonth(d1).ToString(), "#D1");
            Assert.AreEqual("2023-08-31", EssentialsDateUtils.GetEndOfMonth(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfMonth5() {

            EssentialsTime d1 = new EssentialsTime(2023, 1, 6, TimeSpan.Zero);
            EssentialsTime d2 = new EssentialsTime(2023, 8, 17, TimeSpan.Zero);

            Assert.AreEqual("2023-01-31", EssentialsDateUtils.GetEndOfMonth(d1).ToString(), "#D1");
            Assert.AreEqual("2023-08-31", EssentialsDateUtils.GetEndOfMonth(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfMonth6() {

            EssentialsDate d1 = new EssentialsDate(2023, 1, 6);
            EssentialsDate d2 = new EssentialsDate(2023, 8, 17);

            Assert.AreEqual("2023-01-31", EssentialsDateUtils.GetEndOfMonth(d1).ToString(), "#D1");
            Assert.AreEqual("2023-08-31", EssentialsDateUtils.GetEndOfMonth(d2).ToString(), "#D2");

        }

        #endregion

        #region Get ... of quarter

        [TestMethod]
        public void GetStartOfQuarter1() {

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfQuarter(2023, 1).ToString(), "#D1");
            Assert.AreEqual("2023-07-01", EssentialsDateUtils.GetStartOfQuarter(2023, 8).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfQuarter2() {

            EssentialsDate d1 = new EssentialsDate(2023, 1, 6);
            EssentialsDate d2 = new EssentialsDate(2023, 8, 17);

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfQuarter(d1).ToString(), "#D1");
            Assert.AreEqual("2023-07-01", EssentialsDateUtils.GetStartOfQuarter(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfQuarter3() {

            DateTime d1 = new DateTime(2023, 1, 6);
            DateTime d2 = new DateTime(2023, 8, 17);

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfQuarter(d1).ToString(), "#D1");
            Assert.AreEqual("2023-07-01", EssentialsDateUtils.GetStartOfQuarter(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfQuarter4() {

            DateTimeOffset d1 = new DateTimeOffset(2023, 1, 6, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset d2 = new DateTimeOffset(2023, 8, 17, 0, 0, 0, TimeSpan.Zero);

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfQuarter(d1).ToString(), "#D1");
            Assert.AreEqual("2023-07-01", EssentialsDateUtils.GetStartOfQuarter(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfQuarter5() {

            EssentialsDate d1 = new EssentialsDate(2023, 1, 6);
            EssentialsDate d2 = new EssentialsDate(2023, 8, 17);

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfQuarter(d1).ToString(), "#D1");
            Assert.AreEqual("2023-07-01", EssentialsDateUtils.GetStartOfQuarter(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfQuarter6() {

            EssentialsTime d1 = new EssentialsTime(2023, 1, 6, TimeSpan.Zero);
            EssentialsTime d2 = new EssentialsTime(2023, 8, 17, TimeSpan.Zero);

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfQuarter(d1).ToString(), "#D1");
            Assert.AreEqual("2023-07-01", EssentialsDateUtils.GetStartOfQuarter(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfQuarter1() {

            Assert.AreEqual("2023-03-31", EssentialsDateUtils.GetEndOfQuarter(2023, 1).ToString(), "#D1");
            Assert.AreEqual("2023-09-30", EssentialsDateUtils.GetEndOfQuarter(2023, 8).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfQuarter2() {

            DateTime d1 = new DateTime(2023, 1, 6);
            DateTime d2 = new DateTime(2023, 8, 17);

            Assert.AreEqual("2023-03-31", EssentialsDateUtils.GetEndOfQuarter(d1).ToString(), "#D1");
            Assert.AreEqual("2023-09-30", EssentialsDateUtils.GetEndOfQuarter(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfQuarter3() {

            DateTimeOffset d1 = new DateTimeOffset(2023, 1, 6, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset d2 = new DateTimeOffset(2023, 8, 17, 0, 0, 0, TimeSpan.Zero);

            Assert.AreEqual("2023-03-31", EssentialsDateUtils.GetEndOfQuarter(d1).ToString(), "#D1");
            Assert.AreEqual("2023-09-30", EssentialsDateUtils.GetEndOfQuarter(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfQuarter4() {

            EssentialsDate d1 = new EssentialsDate(2023, 1, 6);
            EssentialsDate d2 = new EssentialsDate(2023, 8, 17);

            Assert.AreEqual("2023-03-31", EssentialsDateUtils.GetEndOfQuarter(d1).ToString(), "#D1");
            Assert.AreEqual("2023-09-30", EssentialsDateUtils.GetEndOfQuarter(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfQuarter5() {

            EssentialsTime d1 = new EssentialsTime(2023, 1, 6, TimeSpan.Zero);
            EssentialsTime d2 = new EssentialsTime(2023, 8, 17, TimeSpan.Zero);

            Assert.AreEqual("2023-03-31", EssentialsDateUtils.GetEndOfQuarter(d1).ToString(), "#D1");
            Assert.AreEqual("2023-09-30", EssentialsDateUtils.GetEndOfQuarter(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfQuarter6() {

            EssentialsDate d1 = new EssentialsDate(2023, 1, 6);
            EssentialsDate d2 = new EssentialsDate(2023, 8, 17);

            Assert.AreEqual("2023-03-31", EssentialsDateUtils.GetEndOfQuarter(d1).ToString(), "#D1");
            Assert.AreEqual("2023-09-30", EssentialsDateUtils.GetEndOfQuarter(d2).ToString(), "#D2");

        }

        #endregion

        #region Get ... of year

        [TestMethod]
        public void GetStartOfYear1() {

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfYear(2023).ToString(), "#D1");

        }

        [TestMethod]
        public void GetStartOfYear2() {

            EssentialsDate d1 = new EssentialsDate(2023, 1, 6);
            EssentialsDate d2 = new EssentialsDate(2023, 8, 17);

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfYear(d1).ToString(), "#D1");
            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfYear(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfYear3() {

            DateTime d1 = new DateTime(2023, 1, 6);
            DateTime d2 = new DateTime(2023, 8, 17);

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfYear(d1).ToString(), "#D1");
            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfYear(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfYear4() {

            DateTimeOffset d1 = new DateTimeOffset(2023, 1, 6, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset d2 = new DateTimeOffset(2023, 8, 17, 0, 0, 0, TimeSpan.Zero);

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfYear(d1).ToString(), "#D1");
            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfYear(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfYear5() {

            EssentialsDate d1 = new EssentialsDate(2023, 1, 6);
            EssentialsDate d2 = new EssentialsDate(2023, 8, 17);

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfYear(d1).ToString(), "#D1");
            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfYear(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetStartOfYear6() {

            EssentialsTime d1 = new EssentialsTime(2023, 1, 6, TimeSpan.Zero);
            EssentialsTime d2 = new EssentialsTime(2023, 8, 17, TimeSpan.Zero);

            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfYear(d1).ToString(), "#D1");
            Assert.AreEqual("2023-01-01", EssentialsDateUtils.GetStartOfYear(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfYear1() {

            Assert.AreEqual("2023-12-31", EssentialsDateUtils.GetEndOfYear(2023).ToString(), "#D1");

        }

        [TestMethod]
        public void GetEndOfYear2() {

            DateTime d1 = new DateTime(2023, 1, 6);
            DateTime d2 = new DateTime(2023, 8, 17);

            Assert.AreEqual("2023-12-31", EssentialsDateUtils.GetEndOfYear(d1).ToString(), "#D1");
            Assert.AreEqual("2023-12-31", EssentialsDateUtils.GetEndOfYear(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfYear3() {

            DateTimeOffset d1 = new DateTimeOffset(2023, 1, 6, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset d2 = new DateTimeOffset(2023, 8, 17, 0, 0, 0, TimeSpan.Zero);

            Assert.AreEqual("2023-12-31", EssentialsDateUtils.GetEndOfYear(d1).ToString(), "#D1");
            Assert.AreEqual("2023-12-31", EssentialsDateUtils.GetEndOfYear(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfYear4() {

            EssentialsDate d1 = new EssentialsDate(2023, 1, 6);
            EssentialsDate d2 = new EssentialsDate(2023, 8, 17);

            Assert.AreEqual("2023-12-31", EssentialsDateUtils.GetEndOfYear(d1).ToString(), "#D1");
            Assert.AreEqual("2023-12-31", EssentialsDateUtils.GetEndOfYear(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfYear5() {

            EssentialsTime d1 = new EssentialsTime(2023, 1, 6, TimeSpan.Zero);
            EssentialsTime d2 = new EssentialsTime(2023, 8, 17, TimeSpan.Zero);

            Assert.AreEqual("2023-12-31", EssentialsDateUtils.GetEndOfYear(d1).ToString(), "#D1");
            Assert.AreEqual("2023-12-31", EssentialsDateUtils.GetEndOfYear(d2).ToString(), "#D2");

        }

        [TestMethod]
        public void GetEndOfYear6() {

            EssentialsDate d1 = new EssentialsDate(2023, 1, 6);
            EssentialsDate d2 = new EssentialsDate(2023, 8, 17);

            Assert.AreEqual("2023-12-31", EssentialsDateUtils.GetEndOfYear(d1).ToString(), "#D1");
            Assert.AreEqual("2023-12-31", EssentialsDateUtils.GetEndOfYear(d2).ToString(), "#D2");

        }

        #endregion

    }

}