using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.Time {

    [TestClass]
    public class EssentialsYearTests {

        public const string Format = "yyyy-MM-dd HH:mm:ss:fff K";

        [TestMethod]
        public void Constructor1() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsTime date1 = new EssentialsTime(2021, 1, 15, 12, 0, 0, TimeSpan.FromHours(1));
            EssentialsTime date2 = new EssentialsTime(2021, 6, 15, 12, 0, 0, TimeSpan.FromHours(2));
            EssentialsTime date3 = new EssentialsTime(2021, 12, 15, 12, 0, 0, TimeSpan.FromHours(1));

            EssentialsYear year1 = new EssentialsYear(date1, romance);
            EssentialsYear year2 = new EssentialsYear(date2, romance);
            EssentialsYear year3 = new EssentialsYear(date3, romance);

            Assert.AreEqual(2021, year1.Year, "#1");
            Assert.AreEqual("2021-01-01T00:00:00+01:00", year1.Start.ToString(), "#1");
            Assert.AreEqual("2021-12-31T23:59:59+01:00", year1.End.ToString(), "#1");

            Assert.AreEqual(2021, year2.Year, "#2");
            Assert.AreEqual("2021-01-01T00:00:00+01:00", year2.Start.ToString(), "#2");
            Assert.AreEqual("2021-12-31T23:59:59+01:00", year2.End.ToString(), "#2");

            Assert.AreEqual(2021, year2.Year, "#3");
            Assert.AreEqual("2021-01-01T00:00:00+01:00", year3.Start.ToString(), "#3");
            Assert.AreEqual("2021-12-31T23:59:59+01:00", year3.End.ToString(), "#3");

        }

    }

}