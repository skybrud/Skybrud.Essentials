using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;
using System;

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

    }

}