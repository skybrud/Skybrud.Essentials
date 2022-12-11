using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

// ReSharper disable EqualExpressionComparison

#pragma warning disable CS1718

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

        [TestMethod]
        public void GetYear() {

            EssentialsTime time = new EssentialsTime(2023, 1, 1, TimeSpan.Zero);

            EssentialsWeek week = new EssentialsWeek(time);

            EssentialsYear year = week.GetYear();

            Assert.AreEqual(2022, week.Year);
            Assert.AreEqual(52, week.WeekNumber);
            Assert.AreEqual(2022, year.Year);

        }

        [TestMethod]
        public void Parse() {

            EssentialsWeek week1 = EssentialsWeek.Parse("2022-W52");
            EssentialsWeek week2 = EssentialsWeek.Parse("2022W52");
            EssentialsWeek week3 = EssentialsWeek.Parse("2022-52");

            Assert.AreEqual(2022, week1?.Year);
            Assert.AreEqual(52, week1?.WeekNumber);

            Assert.AreEqual(2022, week2?.Year);
            Assert.AreEqual(52, week2?.WeekNumber);

            Assert.AreEqual(2022, week3?.Year);
            Assert.AreEqual(52, week3?.WeekNumber);

        }

        [TestMethod]
        public void GetStartOfWeek() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsWeek week1 = new EssentialsWeek(2022, 1);
            EssentialsWeek week2 = new EssentialsWeek(2022, 2);
            EssentialsWeek week3 = new EssentialsWeek(2022, 12);
            EssentialsWeek week4 = new EssentialsWeek(2022, 43);
            EssentialsWeek week5 = new EssentialsWeek(2022, 51);
            EssentialsWeek week6 = new EssentialsWeek(2022, 52);

            EssentialsTime start1 = week1.GetStartOfWeek(romance);
            EssentialsTime start2 = week2.GetStartOfWeek(romance);
            EssentialsTime start3 = week3.GetStartOfWeek(romance);
            EssentialsTime start4 = week4.GetStartOfWeek(romance);
            EssentialsTime start5 = week5.GetStartOfWeek(romance);
            EssentialsTime start6 = week6.GetStartOfWeek(romance);

            Assert.AreEqual("2022-01-03T00:00:00.000+01:00", start1.ToString(), "#1");
            Assert.AreEqual("2022-01-10T00:00:00.000+01:00", start2.ToString(), "#2");
            Assert.AreEqual("2022-03-21T00:00:00.000+01:00", start3.ToString(), "#3");
            Assert.AreEqual("2022-10-24T00:00:00.000+02:00", start4.ToString(), "#4");
            Assert.AreEqual("2022-12-19T00:00:00.000+01:00", start5.ToString(), "#5");
            Assert.AreEqual("2022-12-26T00:00:00.000+01:00", start6.ToString(), "#6");

        }

        [TestMethod]
        public void GetEndOfWeek() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsWeek week1 = new EssentialsWeek(2022, 1);
            EssentialsWeek week2 = new EssentialsWeek(2022, 2);
            EssentialsWeek week3 = new EssentialsWeek(2022, 12);
            EssentialsWeek week4 = new EssentialsWeek(2022, 43);
            EssentialsWeek week5 = new EssentialsWeek(2022, 51);
            EssentialsWeek week6 = new EssentialsWeek(2022, 52);

            EssentialsTime end1 = week1.GetEndOfWeek(romance);
            EssentialsTime end2 = week2.GetEndOfWeek(romance);
            EssentialsTime end3 = week3.GetEndOfWeek(romance);
            EssentialsTime end4 = week4.GetEndOfWeek(romance);
            EssentialsTime end5 = week5.GetEndOfWeek(romance);
            EssentialsTime end6 = week6.GetEndOfWeek(romance);

            Assert.AreEqual("2022-01-09T23:59:59.999+01:00", end1.ToString(), "#1");
            Assert.AreEqual("2022-01-16T23:59:59.999+01:00", end2.ToString(), "#2");
            Assert.AreEqual("2022-03-27T23:59:59.999+02:00", end3.ToString(), "#3");
            Assert.AreEqual("2022-10-30T23:59:59.999+01:00", end4.ToString(), "#4");
            Assert.AreEqual("2022-12-25T23:59:59.999+01:00", end5.ToString(), "#5");
            Assert.AreEqual("2023-01-01T23:59:59.999+01:00", end6.ToString(), "#6");

        }

        [TestMethod]
        public void Equals() {

            EssentialsWeek week1 = new EssentialsWeek(2021, 51);
            EssentialsWeek week2 = new EssentialsWeek(2021, 52);
            EssentialsWeek week3 = new EssentialsWeek(2022, 1);
            EssentialsWeek week4 = new EssentialsWeek(2022, 2);
            EssentialsWeek week5 = new EssentialsWeek(2022, 51);
            EssentialsWeek week6 = new EssentialsWeek(2022, 52);
            EssentialsWeek week7 = new EssentialsWeek(2023, 1);
            EssentialsWeek week8 = new EssentialsWeek(2023, 2);

            Assert.IsTrue(week1.Equals(week1), "#1a");
            Assert.IsFalse(week1.Equals(week2), "#1b");
            Assert.IsFalse(week1.Equals(week3), "#1c");
            Assert.IsFalse(week1.Equals(week4), "#1d");
            Assert.IsFalse(week1.Equals(week5), "#1e");
            Assert.IsFalse(week1.Equals(week6), "#1f");
            Assert.IsFalse(week1.Equals(week7), "#1g");
            Assert.IsFalse(week1.Equals(week8), "#1h");

            Assert.IsFalse(week2.Equals(week1), "#2a");
            Assert.IsTrue(week2.Equals(week2), "#2b");
            Assert.IsFalse(week2.Equals(week3), "#2c");
            Assert.IsFalse(week2.Equals(week4), "#2d");
            Assert.IsFalse(week2.Equals(week5), "#2e");
            Assert.IsFalse(week2.Equals(week6), "#2f");
            Assert.IsFalse(week2.Equals(week7), "#2g");
            Assert.IsFalse(week2.Equals(week8), "#2h");

            Assert.IsFalse(week3.Equals(week1), "#3a");
            Assert.IsFalse(week3.Equals(week2), "#3b");
            Assert.IsTrue(week3.Equals(week3), "#3c");
            Assert.IsFalse(week3.Equals(week4), "#3d");
            Assert.IsFalse(week3.Equals(week5), "#3e");
            Assert.IsFalse(week3.Equals(week6), "#3f");
            Assert.IsFalse(week3.Equals(week7), "#3g");
            Assert.IsFalse(week3.Equals(week8), "#3h");

            Assert.IsFalse(week4.Equals(week1), "#4a");
            Assert.IsFalse(week4.Equals(week2), "#4b");
            Assert.IsFalse(week4.Equals(week3), "#4c");
            Assert.IsTrue(week4.Equals(week4), "#4d");
            Assert.IsFalse(week4.Equals(week5), "#4e");
            Assert.IsFalse(week4.Equals(week6), "#4f");
            Assert.IsFalse(week4.Equals(week7), "#4g");
            Assert.IsFalse(week4.Equals(week8), "#4h");

            Assert.IsFalse(week5.Equals(week1), "#5a");
            Assert.IsFalse(week5.Equals(week2), "#5b");
            Assert.IsFalse(week5.Equals(week3), "#5c");
            Assert.IsFalse(week5.Equals(week4), "#5d");
            Assert.IsTrue(week5.Equals(week5), "#5e");
            Assert.IsFalse(week5.Equals(week6), "#5f");
            Assert.IsFalse(week5.Equals(week7), "#5g");
            Assert.IsFalse(week5.Equals(week8), "#5h");

            Assert.IsFalse(week6.Equals(week1), "#6a");
            Assert.IsFalse(week6.Equals(week2), "#6b");
            Assert.IsFalse(week6.Equals(week3), "#6c");
            Assert.IsFalse(week6.Equals(week4), "#6d");
            Assert.IsFalse(week6.Equals(week5), "#6e");
            Assert.IsTrue(week6.Equals(week6), "#6f");
            Assert.IsFalse(week6.Equals(week7), "#6g");
            Assert.IsFalse(week6.Equals(week8), "#6h");

            Assert.IsFalse(week7.Equals(week1), "#7a");
            Assert.IsFalse(week7.Equals(week2), "#7b");
            Assert.IsFalse(week7.Equals(week3), "#7c");
            Assert.IsFalse(week7.Equals(week4), "#7d");
            Assert.IsFalse(week7.Equals(week5), "#7e");
            Assert.IsFalse(week7.Equals(week6), "#7f");
            Assert.IsTrue(week7.Equals(week7), "#7g");
            Assert.IsFalse(week7.Equals(week8), "#7h");

            Assert.IsFalse(week8.Equals(week1), "#8a");
            Assert.IsFalse(week8.Equals(week2), "#8b");
            Assert.IsFalse(week8.Equals(week3), "#8c");
            Assert.IsFalse(week8.Equals(week4), "#8d");
            Assert.IsFalse(week8.Equals(week5), "#8e");
            Assert.IsFalse(week8.Equals(week6), "#8f");
            Assert.IsFalse(week8.Equals(week7), "#8g");
            Assert.IsTrue(week8.Equals(week8), "#8h");

        }

        [TestMethod]
        public void EqualsOperator() {

            EssentialsWeek week1 = new EssentialsWeek(2021, 51);
            EssentialsWeek week2 = new EssentialsWeek(2021, 52);
            EssentialsWeek week3 = new EssentialsWeek(2022, 1);
            EssentialsWeek week4 = new EssentialsWeek(2022, 2);
            EssentialsWeek week5 = new EssentialsWeek(2022, 51);
            EssentialsWeek week6 = new EssentialsWeek(2022, 52);
            EssentialsWeek week7 = new EssentialsWeek(2023, 1);
            EssentialsWeek week8 = new EssentialsWeek(2023, 2);

            Assert.IsTrue(week1 == week1, "#1a");
            Assert.IsFalse(week1 == week2, "#1b");
            Assert.IsFalse(week1 == week3, "#1c");
            Assert.IsFalse(week1 == week4, "#1d");
            Assert.IsFalse(week1 == week5, "#1e");
            Assert.IsFalse(week1 == week6, "#1f");
            Assert.IsFalse(week1 == week7, "#1g");
            Assert.IsFalse(week1 == week8, "#1h");

            Assert.IsFalse(week2 == week1, "#2a");
            Assert.IsTrue(week2 == week2, "#2b");
            Assert.IsFalse(week2 == week3, "#2c");
            Assert.IsFalse(week2 == week4, "#2d");
            Assert.IsFalse(week2 == week5, "#2e");
            Assert.IsFalse(week2 == week6, "#2f");
            Assert.IsFalse(week2 == week7, "#2g");
            Assert.IsFalse(week2 == week8, "#2h");

            Assert.IsFalse(week3 == week1, "#3a");
            Assert.IsFalse(week3 == week2, "#3b");
            Assert.IsTrue(week3 == week3, "#3c");
            Assert.IsFalse(week3 == week4, "#3d");
            Assert.IsFalse(week3 == week5, "#3e");
            Assert.IsFalse(week3 == week6, "#3f");
            Assert.IsFalse(week3 == week7, "#3g");
            Assert.IsFalse(week3 == week8, "#3h");

            Assert.IsFalse(week4 == week1, "#4a");
            Assert.IsFalse(week4 == week2, "#4b");
            Assert.IsFalse(week4 == week3, "#4c");
            Assert.IsTrue(week4 == week4, "#4d");
            Assert.IsFalse(week4 == week5, "#4e");
            Assert.IsFalse(week4 == week6, "#4f");
            Assert.IsFalse(week4 == week7, "#4g");
            Assert.IsFalse(week4 == week8, "#4h");

            Assert.IsFalse(week5 == week1, "#5a");
            Assert.IsFalse(week5 == week2, "#5b");
            Assert.IsFalse(week5 == week3, "#5c");
            Assert.IsFalse(week5 == week4, "#5d");
            Assert.IsTrue(week5 == week5, "#5e");
            Assert.IsFalse(week5 == week6, "#5f");
            Assert.IsFalse(week5 == week7, "#5g");
            Assert.IsFalse(week5 == week8, "#5h");

            Assert.IsFalse(week6 == week1, "#6a");
            Assert.IsFalse(week6 == week2, "#6b");
            Assert.IsFalse(week6 == week3, "#6c");
            Assert.IsFalse(week6 == week4, "#6d");
            Assert.IsFalse(week6 == week5, "#6e");
            Assert.IsTrue(week6 == week6, "#6f");
            Assert.IsFalse(week6 == week7, "#6g");
            Assert.IsFalse(week6 == week8, "#6h");

            Assert.IsFalse(week7 == week1, "#7a");
            Assert.IsFalse(week7 == week2, "#7b");
            Assert.IsFalse(week7 == week3, "#7c");
            Assert.IsFalse(week7 == week4, "#7d");
            Assert.IsFalse(week7 == week5, "#7e");
            Assert.IsFalse(week7 == week6, "#7f");
            Assert.IsTrue(week7 == week7, "#7g");
            Assert.IsFalse(week7 == week8, "#7h");

            Assert.IsFalse(week8 == week1, "#8a");
            Assert.IsFalse(week8 == week2, "#8b");
            Assert.IsFalse(week8 == week3, "#8c");
            Assert.IsFalse(week8 == week4, "#8d");
            Assert.IsFalse(week8 == week5, "#8e");
            Assert.IsFalse(week8 == week6, "#8f");
            Assert.IsFalse(week8 == week7, "#8g");
            Assert.IsTrue(week8 == week8, "#8h");

        }

        [TestMethod]
        public void Min() {

            EssentialsWeek week1 = new EssentialsWeek(2021, 51);
            EssentialsWeek week2 = new EssentialsWeek(2021, 52);
            EssentialsWeek week3 = new EssentialsWeek(2022, 1);
            EssentialsWeek week4 = new EssentialsWeek(2022, 2);
            EssentialsWeek week5 = new EssentialsWeek(2022, 51);
            EssentialsWeek week6 = new EssentialsWeek(2022, 52);
            EssentialsWeek week7 = new EssentialsWeek(2023, 1);
            EssentialsWeek week8 = new EssentialsWeek(2023, 2);

            Assert.AreEqual(week1, EssentialsWeek.Min(week1, week1), "#1a");
            Assert.AreEqual(week1, EssentialsWeek.Min(week1, week2), "#1b");
            Assert.AreEqual(week1, EssentialsWeek.Min(week1, week3), "#1c");
            Assert.AreEqual(week1, EssentialsWeek.Min(week1, week4), "#1d");
            Assert.AreEqual(week1, EssentialsWeek.Min(week1, week5), "#1e");
            Assert.AreEqual(week1, EssentialsWeek.Min(week1, week6), "#1f");
            Assert.AreEqual(week1, EssentialsWeek.Min(week1, week7), "#1g");
            Assert.AreEqual(week1, EssentialsWeek.Min(week1, week8), "#1h");

            Assert.AreEqual(week1, EssentialsWeek.Min(week2, week1), "#2a");
            Assert.AreEqual(week2, EssentialsWeek.Min(week2, week2), "#2b");
            Assert.AreEqual(week2, EssentialsWeek.Min(week2, week3), "#2c");
            Assert.AreEqual(week2, EssentialsWeek.Min(week2, week4), "#2d");
            Assert.AreEqual(week2, EssentialsWeek.Min(week2, week5), "#2e");
            Assert.AreEqual(week2, EssentialsWeek.Min(week2, week6), "#2f");
            Assert.AreEqual(week2, EssentialsWeek.Min(week2, week7), "#2g");
            Assert.AreEqual(week2, EssentialsWeek.Min(week2, week8), "#2h");

            Assert.AreEqual(week1, EssentialsWeek.Min(week3, week1), "#3a");
            Assert.AreEqual(week2, EssentialsWeek.Min(week3, week2), "#3b");
            Assert.AreEqual(week3, EssentialsWeek.Min(week3, week3), "#3c");
            Assert.AreEqual(week3, EssentialsWeek.Min(week3, week4), "#3d");
            Assert.AreEqual(week3, EssentialsWeek.Min(week3, week5), "#3e");
            Assert.AreEqual(week3, EssentialsWeek.Min(week3, week6), "#3f");
            Assert.AreEqual(week3, EssentialsWeek.Min(week3, week7), "#3g");
            Assert.AreEqual(week3, EssentialsWeek.Min(week3, week8), "#3h");

            Assert.AreEqual(week1, EssentialsWeek.Min(week4, week1), "#4a");
            Assert.AreEqual(week2, EssentialsWeek.Min(week4, week2), "#4b");
            Assert.AreEqual(week3, EssentialsWeek.Min(week4, week3), "#4c");
            Assert.AreEqual(week4, EssentialsWeek.Min(week4, week4), "#4d");
            Assert.AreEqual(week4, EssentialsWeek.Min(week4, week5), "#4e");
            Assert.AreEqual(week4, EssentialsWeek.Min(week4, week6), "#4f");
            Assert.AreEqual(week4, EssentialsWeek.Min(week4, week7), "#4g");
            Assert.AreEqual(week4, EssentialsWeek.Min(week4, week8), "#4h");

            Assert.AreEqual(week1, EssentialsWeek.Min(week5, week1), "#5a");
            Assert.AreEqual(week2, EssentialsWeek.Min(week5, week2), "#5b");
            Assert.AreEqual(week3, EssentialsWeek.Min(week5, week3), "#5c");
            Assert.AreEqual(week4, EssentialsWeek.Min(week5, week4), "#5d");
            Assert.AreEqual(week5, EssentialsWeek.Min(week5, week5), "#5e");
            Assert.AreEqual(week5, EssentialsWeek.Min(week5, week6), "#5f");
            Assert.AreEqual(week5, EssentialsWeek.Min(week5, week7), "#5g");
            Assert.AreEqual(week5, EssentialsWeek.Min(week5, week8), "#5h");

            Assert.AreEqual(week1, EssentialsWeek.Min(week6, week1), "#6a");
            Assert.AreEqual(week2, EssentialsWeek.Min(week6, week2), "#6b");
            Assert.AreEqual(week3, EssentialsWeek.Min(week6, week3), "#6c");
            Assert.AreEqual(week4, EssentialsWeek.Min(week6, week4), "#6d");
            Assert.AreEqual(week5, EssentialsWeek.Min(week6, week5), "#6e");
            Assert.AreEqual(week6, EssentialsWeek.Min(week6, week6), "#6f");
            Assert.AreEqual(week6, EssentialsWeek.Min(week6, week7), "#6g");
            Assert.AreEqual(week6, EssentialsWeek.Min(week6, week8), "#6h");

            Assert.AreEqual(week1, EssentialsWeek.Min(week7, week1), "#7a");
            Assert.AreEqual(week2, EssentialsWeek.Min(week7, week2), "#7b");
            Assert.AreEqual(week3, EssentialsWeek.Min(week7, week3), "#7c");
            Assert.AreEqual(week4, EssentialsWeek.Min(week7, week4), "#7d");
            Assert.AreEqual(week5, EssentialsWeek.Min(week7, week5), "#7e");
            Assert.AreEqual(week6, EssentialsWeek.Min(week7, week6), "#7f");
            Assert.AreEqual(week7, EssentialsWeek.Min(week7, week7), "#7g");
            Assert.AreEqual(week7, EssentialsWeek.Min(week7, week8), "#7h");

            Assert.AreEqual(week1, EssentialsWeek.Min(week8, week1), "#8a");
            Assert.AreEqual(week2, EssentialsWeek.Min(week8, week2), "#8b");
            Assert.AreEqual(week3, EssentialsWeek.Min(week8, week3), "#8c");
            Assert.AreEqual(week4, EssentialsWeek.Min(week8, week4), "#8d");
            Assert.AreEqual(week5, EssentialsWeek.Min(week8, week5), "#8e");
            Assert.AreEqual(week6, EssentialsWeek.Min(week8, week6), "#8f");
            Assert.AreEqual(week7, EssentialsWeek.Min(week8, week7), "#8g");
            Assert.AreEqual(week8, EssentialsWeek.Min(week8, week8), "#8h");

            Assert.AreEqual(week1, EssentialsWeek.Min(week1, week2, week3, week4, week5, week6, week7, week8), "#9");

            Assert.AreEqual(week1, EssentialsWeek.Min(new List<EssentialsWeek> { week1, week2, week3, week4, week5, week6, week7, week8 }), "#10");

        }

        [TestMethod]
        public void Max() {

            EssentialsWeek week1 = new EssentialsWeek(2021, 51);
            EssentialsWeek week2 = new EssentialsWeek(2021, 52);
            EssentialsWeek week3 = new EssentialsWeek(2022, 1);
            EssentialsWeek week4 = new EssentialsWeek(2022, 2);
            EssentialsWeek week5 = new EssentialsWeek(2022, 51);
            EssentialsWeek week6 = new EssentialsWeek(2022, 52);
            EssentialsWeek week7 = new EssentialsWeek(2023, 1);
            EssentialsWeek week8 = new EssentialsWeek(2023, 2);

            Assert.AreEqual(week1, EssentialsWeek.Max(week1, week1), "#1a");
            Assert.AreEqual(week2, EssentialsWeek.Max(week1, week2), "#1b");
            Assert.AreEqual(week3, EssentialsWeek.Max(week1, week3), "#1c");
            Assert.AreEqual(week4, EssentialsWeek.Max(week1, week4), "#1d");
            Assert.AreEqual(week5, EssentialsWeek.Max(week1, week5), "#1e");
            Assert.AreEqual(week6, EssentialsWeek.Max(week1, week6), "#1f");
            Assert.AreEqual(week7, EssentialsWeek.Max(week1, week7), "#1g");
            Assert.AreEqual(week8, EssentialsWeek.Max(week1, week8), "#1h");

            Assert.AreEqual(week2, EssentialsWeek.Max(week2, week1), "#2a");
            Assert.AreEqual(week2, EssentialsWeek.Max(week2, week2), "#2b");
            Assert.AreEqual(week3, EssentialsWeek.Max(week2, week3), "#2c");
            Assert.AreEqual(week4, EssentialsWeek.Max(week2, week4), "#2d");
            Assert.AreEqual(week5, EssentialsWeek.Max(week2, week5), "#2e");
            Assert.AreEqual(week6, EssentialsWeek.Max(week2, week6), "#2f");
            Assert.AreEqual(week7, EssentialsWeek.Max(week2, week7), "#2g");
            Assert.AreEqual(week8, EssentialsWeek.Max(week2, week8), "#2h");

            Assert.AreEqual(week3, EssentialsWeek.Max(week3, week1), "#3a");
            Assert.AreEqual(week3, EssentialsWeek.Max(week3, week2), "#3b");
            Assert.AreEqual(week3, EssentialsWeek.Max(week3, week3), "#3c");
            Assert.AreEqual(week4, EssentialsWeek.Max(week3, week4), "#3d");
            Assert.AreEqual(week5, EssentialsWeek.Max(week3, week5), "#3e");
            Assert.AreEqual(week6, EssentialsWeek.Max(week3, week6), "#3f");
            Assert.AreEqual(week7, EssentialsWeek.Max(week3, week7), "#3g");
            Assert.AreEqual(week8, EssentialsWeek.Max(week3, week8), "#3h");

            Assert.AreEqual(week4, EssentialsWeek.Max(week4, week1), "#4a");
            Assert.AreEqual(week4, EssentialsWeek.Max(week4, week2), "#4b");
            Assert.AreEqual(week4, EssentialsWeek.Max(week4, week3), "#4c");
            Assert.AreEqual(week4, EssentialsWeek.Max(week4, week4), "#4d");
            Assert.AreEqual(week5, EssentialsWeek.Max(week4, week5), "#4e");
            Assert.AreEqual(week6, EssentialsWeek.Max(week4, week6), "#4f");
            Assert.AreEqual(week7, EssentialsWeek.Max(week4, week7), "#4g");
            Assert.AreEqual(week8, EssentialsWeek.Max(week4, week8), "#4h");

            Assert.AreEqual(week5, EssentialsWeek.Max(week5, week1), "#5a");
            Assert.AreEqual(week5, EssentialsWeek.Max(week5, week2), "#5b");
            Assert.AreEqual(week5, EssentialsWeek.Max(week5, week3), "#5c");
            Assert.AreEqual(week5, EssentialsWeek.Max(week5, week4), "#5d");
            Assert.AreEqual(week5, EssentialsWeek.Max(week5, week5), "#5e");
            Assert.AreEqual(week6, EssentialsWeek.Max(week5, week6), "#5f");
            Assert.AreEqual(week7, EssentialsWeek.Max(week5, week7), "#5g");
            Assert.AreEqual(week8, EssentialsWeek.Max(week5, week8), "#5h");

            Assert.AreEqual(week6, EssentialsWeek.Max(week6, week1), "#6a");
            Assert.AreEqual(week6, EssentialsWeek.Max(week6, week2), "#6b");
            Assert.AreEqual(week6, EssentialsWeek.Max(week6, week3), "#6c");
            Assert.AreEqual(week6, EssentialsWeek.Max(week6, week4), "#6d");
            Assert.AreEqual(week6, EssentialsWeek.Max(week6, week5), "#6e");
            Assert.AreEqual(week6, EssentialsWeek.Max(week6, week6), "#6f");
            Assert.AreEqual(week7, EssentialsWeek.Max(week6, week7), "#6g");
            Assert.AreEqual(week8, EssentialsWeek.Max(week6, week8), "#6h");

            Assert.AreEqual(week7, EssentialsWeek.Max(week7, week1), "#7a");
            Assert.AreEqual(week7, EssentialsWeek.Max(week7, week2), "#7b");
            Assert.AreEqual(week7, EssentialsWeek.Max(week7, week3), "#7c");
            Assert.AreEqual(week7, EssentialsWeek.Max(week7, week4), "#7d");
            Assert.AreEqual(week7, EssentialsWeek.Max(week7, week5), "#7e");
            Assert.AreEqual(week7, EssentialsWeek.Max(week7, week6), "#7f");
            Assert.AreEqual(week7, EssentialsWeek.Max(week7, week7), "#7g");
            Assert.AreEqual(week8, EssentialsWeek.Max(week7, week8), "#7h");

            Assert.AreEqual(week8, EssentialsWeek.Max(week8, week1), "#8a");
            Assert.AreEqual(week8, EssentialsWeek.Max(week8, week2), "#8b");
            Assert.AreEqual(week8, EssentialsWeek.Max(week8, week3), "#8c");
            Assert.AreEqual(week8, EssentialsWeek.Max(week8, week4), "#8d");
            Assert.AreEqual(week8, EssentialsWeek.Max(week8, week5), "#8e");
            Assert.AreEqual(week8, EssentialsWeek.Max(week8, week6), "#8f");
            Assert.AreEqual(week8, EssentialsWeek.Max(week8, week7), "#8g");
            Assert.AreEqual(week8, EssentialsWeek.Max(week8, week8), "#8h");

            Assert.AreEqual(week8, EssentialsWeek.Max(week1, week2, week3, week4, week5, week6, week7, week8), "#9");

            Assert.AreEqual(week8, EssentialsWeek.Max(new List<EssentialsWeek> { week1, week2, week3, week4, week5, week6, week7, week8 }), "#10");

        }

    }

}