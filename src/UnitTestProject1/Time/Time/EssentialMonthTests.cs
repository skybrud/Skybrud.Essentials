﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.Time {

    [TestClass]
    public class EssentialMonthTests {

        [TestMethod]
        public void ConstructorRomance() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsTime date01 = new EssentialsTime(2021, 1, 15, TimeSpan.FromHours(1));
            EssentialsTime date02 = new EssentialsTime(2021, 2, 15, TimeSpan.FromHours(1));
            EssentialsTime date03 = new EssentialsTime(2021, 3, 15, TimeSpan.FromHours(1));
            EssentialsTime date04 = new EssentialsTime(2021, 4, 15, TimeSpan.FromHours(2));
            EssentialsTime date05 = new EssentialsTime(2021, 5, 15, TimeSpan.FromHours(2));
            EssentialsTime date06 = new EssentialsTime(2021, 6, 15, TimeSpan.FromHours(2));
            EssentialsTime date07 = new EssentialsTime(2021, 7, 15, TimeSpan.FromHours(2));
            EssentialsTime date08 = new EssentialsTime(2021, 8, 15, TimeSpan.FromHours(2));
            EssentialsTime date09 = new EssentialsTime(2021, 9, 15, TimeSpan.FromHours(2));
            EssentialsTime date10 = new EssentialsTime(2021, 10, 15, TimeSpan.FromHours(2));
            EssentialsTime date11 = new EssentialsTime(2021, 11, 15, TimeSpan.FromHours(1));
            EssentialsTime date12 = new EssentialsTime(2021, 12, 15, TimeSpan.FromHours(1));

            EssentialsMonth january = new EssentialsMonth(date01, romance);
            EssentialsMonth february = new EssentialsMonth(date02, romance);
            EssentialsMonth march = new EssentialsMonth(date03, romance);
            EssentialsMonth april = new EssentialsMonth(date04, romance);
            EssentialsMonth may = new EssentialsMonth(date05, romance);
            EssentialsMonth june = new EssentialsMonth(date06, romance);
            EssentialsMonth july = new EssentialsMonth(date07, romance);
            EssentialsMonth august = new EssentialsMonth(date08, romance);
            EssentialsMonth september = new EssentialsMonth(date09, romance);
            EssentialsMonth october = new EssentialsMonth(date10, romance);
            EssentialsMonth november = new EssentialsMonth(date11, romance);
            EssentialsMonth december = new EssentialsMonth(date12, romance);

            Assert.AreEqual("2021-01-01T00:00:00.000+01:00", january.Start.ToString(), "January - Start");
            Assert.AreEqual("2021-01-31T23:59:59.999+01:00", january.End.ToString(), "January - End");

            Assert.AreEqual("2021-02-01T00:00:00.000+01:00", february.Start.ToString(), "February - Start");
            Assert.AreEqual("2021-02-28T23:59:59.999+01:00", february.End.ToString(), "February - End");

            Assert.AreEqual("2021-03-01T00:00:00.000+01:00", march.Start.ToString(), "March - Start");
            Assert.AreEqual("2021-03-31T23:59:59.999+02:00", march.End.ToString(), "March - End");

            Assert.AreEqual("2021-04-01T00:00:00.000+02:00", april.Start.ToString(), "April - Start");
            Assert.AreEqual("2021-04-30T23:59:59.999+02:00", april.End.ToString(), "April - End");

            Assert.AreEqual("2021-05-01T00:00:00.000+02:00", may.Start.ToString(), "May - Start");
            Assert.AreEqual("2021-05-31T23:59:59.999+02:00", may.End.ToString(), "May - End");

            Assert.AreEqual("2021-06-01T00:00:00.000+02:00", june.Start.ToString(), "June - Start");
            Assert.AreEqual("2021-06-30T23:59:59.999+02:00", june.End.ToString(), "June - End");

            Assert.AreEqual("2021-07-01T00:00:00.000+02:00", july.Start.ToString(), "July - Start");
            Assert.AreEqual("2021-07-31T23:59:59.999+02:00", july.End.ToString(), "July - End");

            Assert.AreEqual("2021-08-01T00:00:00.000+02:00", august.Start.ToString(), "August - Start");
            Assert.AreEqual("2021-08-31T23:59:59.999+02:00", august.End.ToString(), "August - End");

            Assert.AreEqual("2021-09-01T00:00:00.000+02:00", september.Start.ToString(), "September - Start");
            Assert.AreEqual("2021-09-30T23:59:59.999+02:00", september.End.ToString(), "September - End");

            Assert.AreEqual("2021-10-01T00:00:00.000+02:00", october.Start.ToString(), "October - Start");
            Assert.AreEqual("2021-10-31T23:59:59.999+01:00", october.End.ToString(), "October - End");

            Assert.AreEqual("2021-11-01T00:00:00.000+01:00", november.Start.ToString(), "November - Start");
            Assert.AreEqual("2021-11-30T23:59:59.999+01:00", november.End.ToString(), "November - End");

            Assert.AreEqual("2021-12-01T00:00:00.000+01:00", december.Start.ToString(), "December - Start");
            Assert.AreEqual("2021-12-31T23:59:59.999+01:00", december.End.ToString(), "December - End");

        }

        [TestMethod]
        public void GetPrevious1() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsMonth month = new EssentialsMonth(2021, 4, romance);

            Assert.AreEqual("2021-04-01T00:00:00.000+02:00", month.Start.Iso8601);
            Assert.AreEqual("2021-04-30T23:59:59.999+02:00", month.End.Iso8601);

            EssentialsMonth previous = month.GetPrevious(romance);

            Assert.AreEqual("2021-03-01T00:00:00.000+01:00", previous.Start.Iso8601);
            Assert.AreEqual("2021-03-31T23:59:59.999+02:00", previous.End.Iso8601);

        }

        [TestMethod]
        public void GetNext1() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsMonth month = new EssentialsMonth(2021, 3, romance);

            Assert.AreEqual("2021-03-01T00:00:00.000+01:00", month.Start.Iso8601);
            Assert.AreEqual("2021-03-31T23:59:59.999+02:00", month.End.Iso8601);

            EssentialsMonth next = month.GetNext(romance);

            Assert.AreEqual("2021-04-01T00:00:00.000+02:00", next.Start.Iso8601);
            Assert.AreEqual("2021-04-30T23:59:59.999+02:00", next.End.Iso8601);

        }

        [TestMethod]
        public void GetMonths1() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var period = EssentialsMonth.GetMonths(2021, 1, 12, romance);

            Assert.AreEqual(12, period.Length);

            Assert.AreEqual(2021, period[0].Year);
            Assert.AreEqual(1, period[0].Month);

            Assert.AreEqual(2021, period[1].Year);
            Assert.AreEqual(2, period[1].Month);

            Assert.AreEqual(2021, period[2].Year);
            Assert.AreEqual(3, period[2].Month);

            Assert.AreEqual(2021, period[3].Year);
            Assert.AreEqual(4, period[3].Month);

            Assert.AreEqual(2021, period[4].Year);
            Assert.AreEqual(5, period[4].Month);

            Assert.AreEqual(2021, period[5].Year);
            Assert.AreEqual(6, period[5].Month);

            Assert.AreEqual(2021, period[6].Year);
            Assert.AreEqual(7, period[6].Month);

            Assert.AreEqual(2021, period[7].Year);
            Assert.AreEqual(8, period[7].Month);

            Assert.AreEqual(2021, period[8].Year);
            Assert.AreEqual(9, period[8].Month);

            Assert.AreEqual(2021, period[9].Year);
            Assert.AreEqual(10, period[9].Month);

            Assert.AreEqual(2021, period[10].Year);
            Assert.AreEqual(11, period[10].Month);

            Assert.AreEqual(2021, period[11].Year);
            Assert.AreEqual(12, period[11].Month);

        }

        [TestMethod]
        public void GetMonths2() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var period = EssentialsMonth.GetMonths(2021, 7, 12, romance);

            Assert.AreEqual(12, period.Length);

            Assert.AreEqual(2021, period[0].Year);
            Assert.AreEqual(7, period[0].Month);

            Assert.AreEqual(2021, period[1].Year);
            Assert.AreEqual(8, period[1].Month);

            Assert.AreEqual(2021, period[2].Year);
            Assert.AreEqual(9, period[2].Month);

            Assert.AreEqual(2021, period[3].Year);
            Assert.AreEqual(10, period[3].Month);

            Assert.AreEqual(2021, period[4].Year);
            Assert.AreEqual(11, period[4].Month);

            Assert.AreEqual(2021, period[5].Year);
            Assert.AreEqual(12, period[5].Month);

            Assert.AreEqual(2022, period[6].Year);
            Assert.AreEqual(1, period[6].Month);

            Assert.AreEqual(2022, period[7].Year);
            Assert.AreEqual(2, period[7].Month);

            Assert.AreEqual(2022, period[8].Year);
            Assert.AreEqual(3, period[8].Month);

            Assert.AreEqual(2022, period[9].Year);
            Assert.AreEqual(4, period[9].Month);

            Assert.AreEqual(2022, period[10].Year);
            Assert.AreEqual(5, period[10].Month);

            Assert.AreEqual(2022, period[11].Year);
            Assert.AreEqual(6, period[11].Month);

        }

        [TestMethod]
        public void GetStartOfMonth() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsMonth month1 = new EssentialsMonth(2022, 1);
            EssentialsMonth month2 = new EssentialsMonth(2022, 2);
            EssentialsMonth month3 = new EssentialsMonth(2022, 3);
            EssentialsMonth month4 = new EssentialsMonth(2022, 10);

            EssentialsTime start1 = month1.GetStartOfMonth(romance);
            EssentialsTime start2 = month2.GetStartOfMonth(romance);
            EssentialsTime start3 = month3.GetStartOfMonth(romance);
            EssentialsTime start4 = month4.GetStartOfMonth(romance);

            Assert.AreEqual("2022-01-01T00:00:00.000+01:00", start1.ToString(), "#1");
            Assert.AreEqual("2022-02-01T00:00:00.000+01:00", start2.ToString(), "#2");
            Assert.AreEqual("2022-03-01T00:00:00.000+01:00", start3.ToString(), "#3");
            Assert.AreEqual("2022-10-01T00:00:00.000+02:00", start4.ToString(), "#4");

        }

        [TestMethod]
        public void GetStartOfMonthLocal() {

            EssentialsMonth month1 = new EssentialsMonth(2022, 1);
            EssentialsMonth month2 = new EssentialsMonth(2022, 2);
            EssentialsMonth month3 = new EssentialsMonth(2022, 3);
            EssentialsMonth month4 = new EssentialsMonth(2022, 10);

            EssentialsTime end11 = month1.GetStartOfMonth();
            EssentialsTime end12 = month1.GetStartOfMonth(TimeZoneInfo.Local);
            Assert.AreEqual(end11, end12, "#1");

            EssentialsTime end21 = month2.GetStartOfMonth();
            EssentialsTime end22 = month2.GetStartOfMonth(TimeZoneInfo.Local);
            Assert.AreEqual(end21, end22, "#2");

            EssentialsTime end31 = month3.GetStartOfMonth();
            EssentialsTime end32 = month3.GetStartOfMonth(TimeZoneInfo.Local);
            Assert.AreEqual(end31, end32, "#3");

            EssentialsTime end41 = month4.GetStartOfMonth();
            EssentialsTime end42 = month4.GetStartOfMonth(TimeZoneInfo.Local);
            Assert.AreEqual(end41, end42, "#4");

        }

        [TestMethod]
        public void GetStartOfYear() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsMonth month1 = new EssentialsMonth(2022, 1);
            EssentialsMonth month2 = new EssentialsMonth(2022, 2);
            EssentialsMonth month3 = new EssentialsMonth(2022, 3);
            EssentialsMonth month4 = new EssentialsMonth(2022, 10);

            EssentialsTime start1 = month1.GetStartOfYear(romance);
            EssentialsTime start2 = month2.GetStartOfYear(romance);
            EssentialsTime start3 = month3.GetStartOfYear(romance);
            EssentialsTime start4 = month4.GetStartOfYear(romance);

            Assert.AreEqual("2022-01-01T00:00:00.000+01:00", start1.ToString(), "#1");
            Assert.AreEqual("2022-01-01T00:00:00.000+01:00", start2.ToString(), "#2");
            Assert.AreEqual("2022-01-01T00:00:00.000+01:00", start3.ToString(), "#3");
            Assert.AreEqual("2022-01-01T00:00:00.000+01:00", start4.ToString(), "#4");

        }

        [TestMethod]
        public void GetStartOfYearLocal() {

            EssentialsMonth month1 = new EssentialsMonth(2022, 1);
            EssentialsMonth month2 = new EssentialsMonth(2022, 2);
            EssentialsMonth month3 = new EssentialsMonth(2022, 3);
            EssentialsMonth month4 = new EssentialsMonth(2022, 10);

            EssentialsTime end11 = month1.GetStartOfYear();
            EssentialsTime end12 = month1.GetStartOfYear(TimeZoneInfo.Local);
            Assert.AreEqual(end11, end12, "#1");

            EssentialsTime end21 = month2.GetStartOfYear();
            EssentialsTime end22 = month2.GetStartOfYear(TimeZoneInfo.Local);
            Assert.AreEqual(end21, end22, "#2");

            EssentialsTime end31 = month3.GetStartOfYear();
            EssentialsTime end32 = month3.GetStartOfYear(TimeZoneInfo.Local);
            Assert.AreEqual(end31, end32, "#3");

            EssentialsTime end41 = month4.GetStartOfYear();
            EssentialsTime end42 = month4.GetStartOfYear(TimeZoneInfo.Local);
            Assert.AreEqual(end41, end42, "#4");

        }

        [TestMethod]
        public void GetEndOfMonth() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsMonth month1 = new EssentialsMonth(2022, 1);
            EssentialsMonth month2 = new EssentialsMonth(2022, 2);
            EssentialsMonth month3 = new EssentialsMonth(2022, 3);
            EssentialsMonth month4 = new EssentialsMonth(2022, 10);

            EssentialsTime end1 = month1.GetEndOfMonth(romance);
            EssentialsTime end2 = month2.GetEndOfMonth(romance);
            EssentialsTime end3 = month3.GetEndOfMonth(romance);
            EssentialsTime end4 = month4.GetEndOfMonth(romance);

            Assert.AreEqual("2022-01-31T23:59:59.999+01:00", end1.ToString(), "#1");
            Assert.AreEqual("2022-02-28T23:59:59.999+01:00", end2.ToString(), "#2");
            Assert.AreEqual("2022-03-31T23:59:59.999+02:00", end3.ToString(), "#3");
            Assert.AreEqual("2022-10-31T23:59:59.999+01:00", end4.ToString(), "#4");

        }

        [TestMethod]
        public void GetEndOfMonthLocal() {

            EssentialsMonth month1 = new EssentialsMonth(2022, 1);
            EssentialsMonth month2 = new EssentialsMonth(2022, 2);
            EssentialsMonth month3 = new EssentialsMonth(2022, 3);
            EssentialsMonth month4 = new EssentialsMonth(2022, 10);

            EssentialsTime end11 = month1.GetEndOfMonth();
            EssentialsTime end12 = month1.GetEndOfMonth(TimeZoneInfo.Local);
            Assert.AreEqual(end11, end12, "#1");

            EssentialsTime end21 = month2.GetEndOfMonth();
            EssentialsTime end22 = month2.GetEndOfMonth(TimeZoneInfo.Local);
            Assert.AreEqual(end21, end22, "#2");

            EssentialsTime end31 = month3.GetEndOfMonth();
            EssentialsTime end32 = month3.GetEndOfMonth(TimeZoneInfo.Local);
            Assert.AreEqual(end31, end32, "#3");

            EssentialsTime end41 = month4.GetEndOfMonth();
            EssentialsTime end42 = month4.GetEndOfMonth(TimeZoneInfo.Local);
            Assert.AreEqual(end41, end42, "#4");

        }

        [TestMethod]
        public void GetEndOfYear() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsMonth month1 = new EssentialsMonth(2022, 1);
            EssentialsMonth month2 = new EssentialsMonth(2022, 2);
            EssentialsMonth month3 = new EssentialsMonth(2022, 3);
            EssentialsMonth month4 = new EssentialsMonth(2022, 10);

            EssentialsTime end1 = month1.GetEndOfYear(romance);
            EssentialsTime end2 = month2.GetEndOfYear(romance);
            EssentialsTime end3 = month3.GetEndOfYear(romance);
            EssentialsTime end4 = month4.GetEndOfYear(romance);

            Assert.AreEqual("2022-12-31T23:59:59.999+01:00", end1.ToString(), "#1");
            Assert.AreEqual("2022-12-31T23:59:59.999+01:00", end2.ToString(), "#2");
            Assert.AreEqual("2022-12-31T23:59:59.999+01:00", end3.ToString(), "#3");
            Assert.AreEqual("2022-12-31T23:59:59.999+01:00", end4.ToString(), "#4");

        }

        [TestMethod]
        public void GetEndOfYearLocal() {

            EssentialsMonth month1 = new EssentialsMonth(2022, 1);
            EssentialsMonth month2 = new EssentialsMonth(2022, 2);
            EssentialsMonth month3 = new EssentialsMonth(2022, 3);
            EssentialsMonth month4 = new EssentialsMonth(2022, 10);

            EssentialsTime end11 = month1.GetEndOfYear();
            EssentialsTime end12 = month1.GetEndOfYear(TimeZoneInfo.Local);
            Assert.AreEqual(end11, end12, "#1");

            EssentialsTime end21 = month2.GetEndOfYear();
            EssentialsTime end22 = month2.GetEndOfYear(TimeZoneInfo.Local);
            Assert.AreEqual(end21, end22, "#2");

            EssentialsTime end31 = month3.GetEndOfYear();
            EssentialsTime end32 = month3.GetEndOfYear(TimeZoneInfo.Local);
            Assert.AreEqual(end31, end32, "#3");

            EssentialsTime end41 = month4.GetEndOfYear();
            EssentialsTime end42 = month4.GetEndOfYear(TimeZoneInfo.Local);
            Assert.AreEqual(end41, end42, "#4");

        }

        [TestMethod]
        public void Equals() {

            EssentialsMonth month1 = new EssentialsMonth(2022, 1);
            EssentialsMonth month2 = new EssentialsMonth(2022, 2);
            EssentialsMonth month3 = new EssentialsMonth(2022, 3);
            EssentialsMonth month4 = new EssentialsMonth(2022, 10);

            Assert.IsTrue(month1.Equals(month1), "#1");
            Assert.IsFalse(month1.Equals(month2), "#2");
            Assert.IsFalse(month1.Equals(month3), "#3");
            Assert.IsFalse(month1.Equals(month4), "#4");

            Assert.IsFalse(month2.Equals(month1), "#1");
            Assert.IsTrue(month2.Equals(month2), "#2");
            Assert.IsFalse(month2.Equals(month3), "#3");
            Assert.IsFalse(month2.Equals(month4), "#4");

            Assert.IsFalse(month3.Equals(month1), "#1");
            Assert.IsFalse(month3.Equals(month2), "#2");
            Assert.IsTrue(month3.Equals(month3), "#3");
            Assert.IsFalse(month3.Equals(month4), "#4");

            Assert.IsFalse(month4.Equals(month1), "#1");
            Assert.IsFalse(month4.Equals(month2), "#2");
            Assert.IsFalse(month4.Equals(month3), "#3");
            Assert.IsTrue(month4.Equals(month4), "#4");

        }

        [TestMethod]
        public void EqualsOperator() {

            EssentialsMonth month1 = new EssentialsMonth(2022, 1);
            EssentialsMonth month2 = new EssentialsMonth(2022, 2);
            EssentialsMonth month3 = new EssentialsMonth(2022, 3);
            EssentialsMonth month4 = new EssentialsMonth(2022, 10);

            Assert.IsTrue(month1 == month1, "#1");
            Assert.IsFalse(month1 == month2, "#2");
            Assert.IsFalse(month1 == month3, "#3");
            Assert.IsFalse(month1 == month4, "#4");

            Assert.IsFalse(month2 == month1, "#1");
            Assert.IsTrue(month2 == month2, "#2");
            Assert.IsFalse(month2 == month3, "#3");
            Assert.IsFalse(month2 == month4, "#4");

            Assert.IsFalse(month3 == month1, "#1");
            Assert.IsFalse(month3 == month2, "#2");
            Assert.IsTrue(month3 == month3, "#3");
            Assert.IsFalse(month3 == month4, "#4");

            Assert.IsFalse(month4 == month1, "#1");
            Assert.IsFalse(month4 == month2, "#2");
            Assert.IsFalse(month4 == month3, "#3");
            Assert.IsTrue(month4 == month4, "#4");

        }

        [TestMethod]
        public void Min() {

            EssentialsMonth a = new EssentialsMonth(2022, 1);
            EssentialsMonth b = new EssentialsMonth(2022, 8);
            EssentialsMonth c = new EssentialsMonth(2023, 4);
            EssentialsMonth d = new EssentialsMonth(2023, 8);

            Assert.AreEqual(a, EssentialsMonth.Min(a, a), "#A1");
            Assert.AreEqual(a, EssentialsMonth.Min(a, b), "#A2");
            Assert.AreEqual(a, EssentialsMonth.Min(a, c), "#A3");
            Assert.AreEqual(a, EssentialsMonth.Min(a, d), "#A4");

            Assert.AreEqual(a, EssentialsMonth.Min(b, a), "#B1");
            Assert.AreEqual(b, EssentialsMonth.Min(b, b), "#B2");
            Assert.AreEqual(b, EssentialsMonth.Min(b, c), "#B3");
            Assert.AreEqual(b, EssentialsMonth.Min(b, d), "#B4");

            Assert.AreEqual(a, EssentialsMonth.Min(c, a), "#C1");
            Assert.AreEqual(b, EssentialsMonth.Min(c, b), "#C2");
            Assert.AreEqual(c, EssentialsMonth.Min(c, c), "#C3");
            Assert.AreEqual(c, EssentialsMonth.Min(c, d), "#C4");

            Assert.AreEqual(a, EssentialsMonth.Min(d, a), "#D1");
            Assert.AreEqual(b, EssentialsMonth.Min(d, b), "#D2");
            Assert.AreEqual(c, EssentialsMonth.Min(d, c), "#D3");
            Assert.AreEqual(d, EssentialsMonth.Min(d, d), "#D4");

        }

        [TestMethod]
        public void Max() {

            EssentialsMonth a = new EssentialsMonth(2022, 1);
            EssentialsMonth b = new EssentialsMonth(2022, 8);
            EssentialsMonth c = new EssentialsMonth(2023, 4);
            EssentialsMonth d = new EssentialsMonth(2023, 8);

            Assert.AreEqual(a, EssentialsMonth.Max(a, a), "#A1");
            Assert.AreEqual(b, EssentialsMonth.Max(a, b), "#A2");
            Assert.AreEqual(c, EssentialsMonth.Max(a, c), "#A3");
            Assert.AreEqual(d, EssentialsMonth.Max(a, d), "#A4");

            Assert.AreEqual(b, EssentialsMonth.Max(b, a), "#B1");
            Assert.AreEqual(b, EssentialsMonth.Max(b, b), "#B2");
            Assert.AreEqual(c, EssentialsMonth.Max(b, c), "#B3");
            Assert.AreEqual(d, EssentialsMonth.Max(b, d), "#B4");

            Assert.AreEqual(c, EssentialsMonth.Max(c, a), "#C1");
            Assert.AreEqual(c, EssentialsMonth.Max(c, b), "#C2");
            Assert.AreEqual(c, EssentialsMonth.Max(c, c), "#C3");
            Assert.AreEqual(d, EssentialsMonth.Max(c, d), "#C4");

            Assert.AreEqual(d, EssentialsMonth.Max(d, a), "#D1");
            Assert.AreEqual(d, EssentialsMonth.Max(d, b), "#D2");
            Assert.AreEqual(d, EssentialsMonth.Max(d, c), "#D3");
            Assert.AreEqual(d, EssentialsMonth.Max(d, d), "#D4");

        }

    }

}