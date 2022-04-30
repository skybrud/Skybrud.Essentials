using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;
using System;
using System.Linq;
using System.Text;

namespace UnitTestProject1.Time.Time {

    [TestClass]
    public class EssentialsWeekTests {

        public const string Format = "yyyy-MM-dd HH:mm:ss:fff K";

        [TestMethod]
        public void ConstructorOffset() {

            // Note: offset doesn't take daylight savings into account

            EssentialsWeek week1 = new EssentialsWeek(2019, 12, TimeSpan.Zero);
            EssentialsWeek week2 = new EssentialsWeek(2019, 13, TimeSpan.Zero);
            EssentialsWeek week3 = new EssentialsWeek(2019, 14, TimeSpan.Zero);

            EssentialsWeek week4 = new EssentialsWeek(2019, 12, TimeSpan.FromHours(1));
            EssentialsWeek week5 = new EssentialsWeek(2019, 13, TimeSpan.FromHours(1));
            EssentialsWeek week6 = new EssentialsWeek(2019, 14, TimeSpan.FromHours(1));
            EssentialsWeek week7 = new EssentialsWeek(2019, 14, TimeSpan.FromHours(2));

            Assert.AreEqual(12, week1.WeekNumber, "#1");
            Assert.AreEqual(2019, week1.Year, "#1");
            Assert.AreEqual("2019-03-18 00:00:00:000 +00:00", week1.Start.ToString(Format), "#1");
            Assert.AreEqual("2019-03-24 23:59:59:999 +00:00", week1.End.ToString(Format), "#1");

            Assert.AreEqual(13, week2.WeekNumber, "#2");
            Assert.AreEqual(2019, week2.Year, "#2");
            Assert.AreEqual("2019-03-25 00:00:00:000 +00:00", week2.Start.ToString(Format), "#2");
            Assert.AreEqual("2019-03-31 23:59:59:999 +00:00", week2.End.ToString(Format), "#2");

            Assert.AreEqual(14, week3.WeekNumber, "#3");
            Assert.AreEqual(2019, week3.Year, "#3");
            Assert.AreEqual("2019-04-01 00:00:00:000 +00:00", week3.Start.ToString(Format), "#3");
            Assert.AreEqual("2019-04-07 23:59:59:999 +00:00", week3.End.ToString(Format), "#3");

            Assert.AreEqual(12, week4.WeekNumber, "#4");
            Assert.AreEqual(2019, week4.Year, "#4");
            Assert.AreEqual("2019-03-18 00:00:00:000 +01:00", week4.Start.ToString(Format), "#4");
            Assert.AreEqual("2019-03-24 23:59:59:999 +01:00", week4.End.ToString(Format), "#4");

            Assert.AreEqual(13, week5.WeekNumber, "#2");
            Assert.AreEqual(2019, week5.Year, "#2");
            Assert.AreEqual("2019-03-25 00:00:00:000 +01:00", week5.Start.ToString(Format), "#5");
            Assert.AreEqual("2019-03-31 23:59:59:999 +01:00", week5.End.ToString(Format), "#5");

            Assert.AreEqual(14, week6.WeekNumber, "#6");
            Assert.AreEqual(2019, week6.Year, "#6");
            Assert.AreEqual("2019-04-01 00:00:00:000 +01:00", week6.Start.ToString(Format), "#6");
            Assert.AreEqual("2019-04-07 23:59:59:999 +01:00", week6.End.ToString(Format), "#6");

            Assert.AreEqual(14, week7.WeekNumber, "#7");
            Assert.AreEqual(2019, week7.Year, "#7");
            Assert.AreEqual("2019-04-01 00:00:00:000 +02:00", week7.Start.ToString(Format), "#7");
            Assert.AreEqual("2019-04-07 23:59:59:999 +02:00", week7.End.ToString(Format), "#7");

        }

        [TestMethod]
        public void ConstructorTimeZoneInfo() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsWeek week1 = new EssentialsWeek(2019, 12, utc);
            EssentialsWeek week2 = new EssentialsWeek(2019, 13, utc);
            EssentialsWeek week3 = new EssentialsWeek(2019, 14, utc);

            EssentialsWeek week4 = new EssentialsWeek(2019, 12, romance);
            EssentialsWeek week5 = new EssentialsWeek(2019, 13, romance);
            EssentialsWeek week6 = new EssentialsWeek(2019, 14, romance);

            Assert.AreEqual(12, week1.WeekNumber, "#1");
            Assert.AreEqual(2019, week1.Year, "#1");
            Assert.AreEqual("2019-03-18 00:00:00:000 +00:00", week1.Start.ToString(Format), "#1");
            Assert.AreEqual("2019-03-24 23:59:59:999 +00:00", week1.End.ToString(Format), "#1");

            Assert.AreEqual(13, week2.WeekNumber, "#2");
            Assert.AreEqual(2019, week2.Year, "#2");
            Assert.AreEqual("2019-03-25 00:00:00:000 +00:00", week2.Start.ToString(Format), "#2");
            Assert.AreEqual("2019-03-31 23:59:59:999 +00:00", week2.End.ToString(Format), "#2");

            Assert.AreEqual(14, week3.WeekNumber, "#3");
            Assert.AreEqual(2019, week3.Year, "#3");
            Assert.AreEqual("2019-04-01 00:00:00:000 +00:00", week3.Start.ToString(Format), "#3");
            Assert.AreEqual("2019-04-07 23:59:59:999 +00:00", week3.End.ToString(Format), "#3");

            Assert.AreEqual(12, week4.WeekNumber, "#4");
            Assert.AreEqual(2019, week4.Year, "#4");
            Assert.AreEqual("2019-03-18 00:00:00:000 +01:00", week4.Start.ToString(Format), "#4");
            Assert.AreEqual("2019-03-24 23:59:59:999 +01:00", week4.End.ToString(Format), "#4");

            Assert.AreEqual(13, week5.WeekNumber, "#2");
            Assert.AreEqual(2019, week5.Year, "#2");
            Assert.AreEqual("2019-03-25 00:00:00:000 +01:00", week5.Start.ToString(Format), "#5");
            Assert.AreEqual("2019-03-31 23:59:59:999 +02:00", week5.End.ToString(Format), "#5");

            Assert.AreEqual(14, week6.WeekNumber, "#6");
            Assert.AreEqual(2019, week6.Year, "#6");
            Assert.AreEqual("2019-04-01 00:00:00:000 +02:00", week6.Start.ToString(Format), "#6");
            Assert.AreEqual("2019-04-07 23:59:59:999 +02:00", week6.End.ToString(Format), "#6");

        }

        [TestMethod]
        public void GetPreviousWeek() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsWeek week1 = new EssentialsWeek(2019, 12, utc).GetPreviousWeek();
            EssentialsWeek week2 = new EssentialsWeek(2019, 13, utc).GetPreviousWeek();
            EssentialsWeek week3 = new EssentialsWeek(2019, 14, utc).GetPreviousWeek();

            EssentialsWeek week4 = new EssentialsWeek(2019, 12, romance).GetPreviousWeek();
            EssentialsWeek week5 = new EssentialsWeek(2019, 13, romance).GetPreviousWeek();
            EssentialsWeek week6 = new EssentialsWeek(2019, 14, romance).GetPreviousWeek();

            Assert.AreEqual(11, week1.WeekNumber, "#1");
            Assert.AreEqual(2019, week1.Year, "#1");
            Assert.AreEqual("2019-03-11 00:00:00:000 +00:00", week1.Start.ToString(Format), "#1");
            Assert.AreEqual("2019-03-17 23:59:59:999 +00:00", week1.End.ToString(Format), "#1");

            Assert.AreEqual(12, week2.WeekNumber, "#2");
            Assert.AreEqual(2019, week2.Year, "#2");
            Assert.AreEqual("2019-03-18 00:00:00:000 +00:00", week2.Start.ToString(Format), "#2");
            Assert.AreEqual("2019-03-24 23:59:59:999 +00:00", week2.End.ToString(Format), "#2");

            Assert.AreEqual(13, week3.WeekNumber, "#3");
            Assert.AreEqual(2019, week3.Year, "#3");
            Assert.AreEqual("2019-03-25 00:00:00:000 +00:00", week3.Start.ToString(Format), "#3");
            Assert.AreEqual("2019-03-31 23:59:59:999 +00:00", week3.End.ToString(Format), "#3");

            Assert.AreEqual(11, week4.WeekNumber, "#4");
            Assert.AreEqual(2019, week4.Year, "#4");
            Assert.AreEqual("2019-03-11 00:00:00:000 +01:00", week4.Start.ToString(Format), "#4");
            Assert.AreEqual("2019-03-17 23:59:59:999 +01:00", week4.End.ToString(Format), "#4");

            Assert.AreEqual(12, week5.WeekNumber, "#2");
            Assert.AreEqual(2019, week5.Year, "#2");
            Assert.AreEqual("2019-03-18 00:00:00:000 +01:00", week5.Start.ToString(Format), "#5");
            Assert.AreEqual("2019-03-24 23:59:59:999 +01:00", week5.End.ToString(Format), "#5");

            Assert.AreEqual(13, week6.WeekNumber, "#6");
            Assert.AreEqual(2019, week6.Year, "#6");
            Assert.AreEqual("2019-03-25 00:00:00:000 +01:00", week6.Start.ToString(Format), "#6");
            Assert.AreEqual("2019-03-31 23:59:59:999 +02:00", week6.End.ToString(Format), "#6");

        }

        [TestMethod]
        public void GetNextWeek() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsWeek week1 = new EssentialsWeek(2019, 12, utc).GetNextWeek();
            EssentialsWeek week2 = new EssentialsWeek(2019, 13, utc).GetNextWeek();
            EssentialsWeek week3 = new EssentialsWeek(2019, 14, utc).GetNextWeek();

            EssentialsWeek week4 = new EssentialsWeek(2019, 12, romance).GetNextWeek();
            EssentialsWeek week5 = new EssentialsWeek(2019, 13, romance).GetNextWeek();
            EssentialsWeek week6 = new EssentialsWeek(2019, 14, romance).GetNextWeek();

            Assert.AreEqual(13, week1.WeekNumber, "#1");
            Assert.AreEqual(2019, week1.Year, "#1");
            Assert.AreEqual("2019-03-25 00:00:00:000 +00:00", week1.Start.ToString(Format), "#1");
            Assert.AreEqual("2019-03-31 23:59:59:999 +00:00", week1.End.ToString(Format), "#1");

            Assert.AreEqual(14, week2.WeekNumber, "#2");
            Assert.AreEqual(2019, week2.Year, "#2");
            Assert.AreEqual("2019-04-01 00:00:00:000 +00:00", week2.Start.ToString(Format), "#2");
            Assert.AreEqual("2019-04-07 23:59:59:999 +00:00", week2.End.ToString(Format), "#2");

            Assert.AreEqual(15, week3.WeekNumber, "#3");
            Assert.AreEqual(2019, week3.Year, "#3");
            Assert.AreEqual("2019-04-08 00:00:00:000 +00:00", week3.Start.ToString(Format), "#3");
            Assert.AreEqual("2019-04-14 23:59:59:999 +00:00", week3.End.ToString(Format), "#3");

            Assert.AreEqual(13, week4.WeekNumber, "#4");
            Assert.AreEqual(2019, week4.Year, "#4");
            Assert.AreEqual("2019-03-25 00:00:00:000 +01:00", week4.Start.ToString(Format), "#4");
            Assert.AreEqual("2019-03-31 23:59:59:999 +02:00", week4.End.ToString(Format), "#4");

            Assert.AreEqual(14, week5.WeekNumber, "#2");
            Assert.AreEqual(2019, week5.Year, "#2");
            Assert.AreEqual("2019-04-01 00:00:00:000 +02:00", week5.Start.ToString(Format), "#5");
            Assert.AreEqual("2019-04-07 23:59:59:999 +02:00", week5.End.ToString(Format), "#5");

            Assert.AreEqual(15, week6.WeekNumber, "#6");
            Assert.AreEqual(2019, week6.Year, "#6");
            Assert.AreEqual("2019-04-08 00:00:00:000 +02:00", week6.Start.ToString(Format), "#6");
            Assert.AreEqual("2019-04-14 23:59:59:999 +02:00", week6.End.ToString(Format), "#6");

        }

        [TestMethod]
        public void NewYear() {

            #region 2016 -> 2017

            EssentialsWeek sample1 = new EssentialsWeek(2016, 12, 31);
            Assert.AreEqual(52, sample1.WeekNumber);
            Assert.AreEqual(2016, sample1.Year);

            EssentialsWeek sample2 = new EssentialsWeek(2017, 1, 1);
            Assert.AreEqual(52, sample2.WeekNumber);
            Assert.AreEqual(2016, sample2.Year);

            #endregion

            #region 2017 -> 2018

            EssentialsWeek sample3 = new EssentialsWeek(2017, 12, 31);
            Assert.AreEqual(52, sample3.WeekNumber);
            Assert.AreEqual(2017, sample3.Year);

            EssentialsWeek sample4 = new EssentialsWeek(2018, 1, 1);
            Assert.AreEqual(1, sample4.WeekNumber);
            Assert.AreEqual(2018, sample4.Year);

            #endregion

            #region 2018 -> 2019

            EssentialsWeek sample5 = new EssentialsWeek(2018, 12, 31);
            Assert.AreEqual(1, sample5.WeekNumber);
            Assert.AreEqual(2019, sample5.Year);

            EssentialsWeek sample6 = new EssentialsWeek(2019, 1, 1);
            Assert.AreEqual(1, sample6.WeekNumber);
            Assert.AreEqual(2019, sample6.Year);

            #endregion

            #region 2019 -> 2020

            EssentialsWeek sample7 = new EssentialsWeek(2019, 12, 31);
            Assert.AreEqual(1, sample7.WeekNumber);
            Assert.AreEqual(2020, sample7.Year);

            EssentialsWeek sample8 = new EssentialsWeek(2020, 1, 1);
            Assert.AreEqual(1, sample8.WeekNumber);
            Assert.AreEqual(2020, sample8.Year);

            #endregion

            #region 2020 -> 2021

            EssentialsWeek sample9 = new EssentialsWeek(2020, 12, 31);
            Assert.AreEqual(53, sample9.WeekNumber);
            Assert.AreEqual(2020, sample9.Year);

            EssentialsWeek sample10 = new EssentialsWeek(2021, 1, 1);
            Assert.AreEqual(53, sample10.WeekNumber);
            Assert.AreEqual(2020, sample10.Year);

            #endregion

        }

        [TestMethod]
        public void GetEnumerator() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var date = new EssentialsDate(2019, 10, 24);

            EssentialsWeek week = new EssentialsWeek(date, romance);

            Assert.AreEqual("2019-10-21T00:00:00.000+02:00", week.Start.ToString(), "Start");
            Assert.AreEqual("2019-10-27T23:59:59.999+01:00", week.End.ToString(), "End");

            EssentialsDate[] days = week.ToArray();

            Assert.AreEqual(7, days.Length);

            Assert.AreEqual(DayOfWeek.Monday, days[0].DayOfWeek);
            Assert.AreEqual("2019-10-21", days[0].ToString());

            Assert.AreEqual(DayOfWeek.Tuesday, days[1].DayOfWeek);
            Assert.AreEqual("2019-10-22", days[1].ToString());

            Assert.AreEqual(DayOfWeek.Wednesday, days[2].DayOfWeek);
            Assert.AreEqual("2019-10-23", days[2].ToString());

            Assert.AreEqual(DayOfWeek.Thursday, days[3].DayOfWeek);
            Assert.AreEqual("2019-10-24", days[3].ToString());

            Assert.AreEqual(DayOfWeek.Friday, days[4].DayOfWeek);
            Assert.AreEqual("2019-10-25", days[4].ToString());

            Assert.AreEqual(DayOfWeek.Saturday, days[5].DayOfWeek);
            Assert.AreEqual("2019-10-26", days[5].ToString());

            Assert.AreEqual(DayOfWeek.Sunday, days[6].DayOfWeek);
            Assert.AreEqual("2019-10-27", days[6].ToString());

        }

    }

}