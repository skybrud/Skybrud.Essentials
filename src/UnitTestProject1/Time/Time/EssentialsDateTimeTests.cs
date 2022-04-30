using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

#pragma warning disable 618

namespace UnitTestProject1.Time.Time {

    [TestClass]
    public class EssentialsDateTimeTests {

        [TestMethod]
        public void GetDay() {

            EssentialsDateTime monday = new EssentialsDateTime(2021, 9, 27, 0, 0, 0);
            EssentialsDateTime tuesday = new EssentialsDateTime(2021, 9, 28, 0, 0, 0);
            EssentialsDateTime wednesday = new EssentialsDateTime(2021, 9, 29, 0, 0, 0);
            EssentialsDateTime thursday = new EssentialsDateTime(2021, 9, 30, 0, 0, 0);
            EssentialsDateTime friday = new EssentialsDateTime(2021, 10, 1, 0, 0, 0);
            EssentialsDateTime saturday = new EssentialsDateTime(2021, 10, 2, 0, 0, 0);
            EssentialsDateTime sunday = new EssentialsDateTime(2021, 10, 3, 0, 0, 0);

            Assert.AreEqual(27, monday.Day);
            Assert.AreEqual(28, tuesday.Day);
            Assert.AreEqual(29, wednesday.Day);
            Assert.AreEqual(30, thursday.Day);
            Assert.AreEqual(1, friday.Day);
            Assert.AreEqual(2, saturday.Day);
            Assert.AreEqual(3, sunday.Day);

        }

        [TestMethod]
        public void GetDayOfWeek() {

            EssentialsDateTime monday = new EssentialsDateTime(2021, 9, 27, 0, 0, 0);
            EssentialsDateTime tuesday = new EssentialsDateTime(2021, 9, 28, 0, 0, 0);
            EssentialsDateTime wednesday = new EssentialsDateTime(2021, 9, 29, 0, 0, 0);
            EssentialsDateTime thursday = new EssentialsDateTime(2021, 9, 30, 0, 0, 0);
            EssentialsDateTime friday = new EssentialsDateTime(2021, 10, 1, 0, 0, 0);
            EssentialsDateTime saturday = new EssentialsDateTime(2021, 10, 2, 0, 0, 0);
            EssentialsDateTime sunday = new EssentialsDateTime(2021, 10, 3, 0, 0, 0);

            Assert.AreEqual(DayOfWeek.Monday, monday.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Tuesday, tuesday.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Wednesday, wednesday.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Thursday, thursday.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Friday, friday.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Saturday, saturday.DayOfWeek);
            Assert.AreEqual(DayOfWeek.Sunday, sunday.DayOfWeek);

        }

        [TestMethod]
        public void GetDayOfYear() {

            // 2020 was a leap year, 2021 isn't

            EssentialsDateTime monday2020 = new EssentialsDateTime(2020, 9, 27, 0, 0, 0);
            EssentialsDateTime tuesday2020 = new EssentialsDateTime(2020, 9, 28, 0, 0, 0);
            EssentialsDateTime wednesday2020 = new EssentialsDateTime(2020, 9, 29, 0, 0, 0);
            EssentialsDateTime thursday2020 = new EssentialsDateTime(2020, 9, 30, 0, 0, 0);
            EssentialsDateTime friday2020 = new EssentialsDateTime(2020, 10, 1, 0, 0, 0);
            EssentialsDateTime saturday2020 = new EssentialsDateTime(2020, 10, 2, 0, 0, 0);
            EssentialsDateTime sunday2020 = new EssentialsDateTime(2020, 10, 3, 0, 0, 0);

            EssentialsDateTime monday2021 = new EssentialsDateTime(2021, 9, 27, 0, 0, 0);
            EssentialsDateTime tuesday2021 = new EssentialsDateTime(2021, 9, 28, 0, 0, 0);
            EssentialsDateTime wednesday2021 = new EssentialsDateTime(2021, 9, 29, 0, 0, 0);
            EssentialsDateTime thursday2021 = new EssentialsDateTime(2021, 9, 30, 0, 0, 0);
            EssentialsDateTime friday2021 = new EssentialsDateTime(2021, 10, 1, 0, 0, 0);
            EssentialsDateTime saturday2021 = new EssentialsDateTime(2021, 10, 2, 0, 0, 0);
            EssentialsDateTime sunday2021 = new EssentialsDateTime(2021, 10, 3, 0, 0, 0);

            Assert.AreEqual(271, monday2020.DayOfYear);
            Assert.AreEqual(272, tuesday2020.DayOfYear);
            Assert.AreEqual(273, wednesday2020.DayOfYear);
            Assert.AreEqual(274, thursday2020.DayOfYear);
            Assert.AreEqual(275, friday2020.DayOfYear);
            Assert.AreEqual(276, saturday2020.DayOfYear);
            Assert.AreEqual(277, sunday2020.DayOfYear);

            Assert.AreEqual(270, monday2021.DayOfYear);
            Assert.AreEqual(271, tuesday2021.DayOfYear);
            Assert.AreEqual(272, wednesday2021.DayOfYear);
            Assert.AreEqual(273, thursday2021.DayOfYear);
            Assert.AreEqual(274, friday2021.DayOfYear);
            Assert.AreEqual(275, saturday2021.DayOfYear);
            Assert.AreEqual(276, sunday2021.DayOfYear);

        }

        [TestMethod]
        public void IsLeapYear() {

            // 2020 was a leap year, 2021 isn't

            EssentialsDateTime y2020 = new EssentialsDateTime(2020, 9, 27, 0, 0, 0);
            EssentialsDateTime y2021 = new EssentialsDateTime(2021, 9, 27, 0, 0, 0);

            Assert.IsTrue(y2020.IsLeapYear);
            Assert.IsFalse(y2021.IsLeapYear);

        }

        [TestMethod]
        public void GetDaysInMonth() {

            // 2020 was a leap year, 2021 isn't

            EssentialsDateTime y2020 = new EssentialsDateTime(2020, 2, 26, 0, 0, 0);
            EssentialsDateTime y2021 = new EssentialsDateTime(2021, 2, 26, 0, 0, 0);

            Assert.AreEqual(29, y2020.DaysInMonth);
            Assert.AreEqual(28, y2021.DaysInMonth);

        }

        [TestMethod]
        public void IsWeekday() {

            EssentialsDateTime monday = new EssentialsDateTime(2021, 9, 27, 0, 0, 0);
            EssentialsDateTime tuesday = new EssentialsDateTime(2021, 9, 28, 0, 0, 0);
            EssentialsDateTime wednesday = new EssentialsDateTime(2021, 9, 29, 0, 0, 0);
            EssentialsDateTime thursday = new EssentialsDateTime(2021, 9, 30, 0, 0, 0);
            EssentialsDateTime friday = new EssentialsDateTime(2021, 10, 1, 0, 0, 0);
            EssentialsDateTime saturday = new EssentialsDateTime(2021, 10, 2, 0, 0, 0);
            EssentialsDateTime sunday = new EssentialsDateTime(2021, 10, 3, 0, 0, 0);

            Assert.IsTrue(monday.IsWeekday);
            Assert.IsTrue(tuesday.IsWeekday);
            Assert.IsTrue(wednesday.IsWeekday);
            Assert.IsTrue(thursday.IsWeekday);
            Assert.IsTrue(friday.IsWeekday);
            Assert.IsFalse(saturday.IsWeekday);
            Assert.IsFalse(sunday.IsWeekday);

        }

        [TestMethod]
        public void IsWeekend() {

            EssentialsDateTime monday = new EssentialsDateTime(2021, 9, 27, 0, 0, 0);
            EssentialsDateTime tuesday = new EssentialsDateTime(2021, 9, 28, 0, 0, 0);
            EssentialsDateTime wednesday = new EssentialsDateTime(2021, 9, 29, 0, 0, 0);
            EssentialsDateTime thursday = new EssentialsDateTime(2021, 9, 30, 0, 0, 0);
            EssentialsDateTime friday = new EssentialsDateTime(2021, 10, 1, 0, 0, 0);
            EssentialsDateTime saturday = new EssentialsDateTime(2021, 10, 2, 0, 0, 0);
            EssentialsDateTime sunday = new EssentialsDateTime(2021, 10, 3, 0, 0, 0);

            Assert.IsFalse(monday.IsWeekend);
            Assert.IsFalse(tuesday.IsWeekend);
            Assert.IsFalse(wednesday.IsWeekend);
            Assert.IsFalse(thursday.IsWeekend);
            Assert.IsFalse(friday.IsWeekend);
            Assert.IsTrue(saturday.IsWeekend);
            Assert.IsTrue(sunday.IsWeekend);

        }

        [TestMethod]
        public void GetWeekNumber() {

            EssentialsDateTime dec27 = new EssentialsDateTime(2021, 12, 27, 0, 0, 0);
            EssentialsDateTime dec28 = new EssentialsDateTime(2021, 12, 28, 0, 0, 0);
            EssentialsDateTime dec29 = new EssentialsDateTime(2021, 12, 29, 0, 0, 0);
            EssentialsDateTime dec30 = new EssentialsDateTime(2021, 12, 30, 0, 0, 0);
            EssentialsDateTime dec31 = new EssentialsDateTime(2021, 12, 31, 0, 0, 0);
            EssentialsDateTime jan01 = new EssentialsDateTime(2022, 1, 1, 0, 0, 0);
            EssentialsDateTime jan02 = new EssentialsDateTime(2022, 1, 2, 0, 0, 0);
            EssentialsDateTime jan03 = new EssentialsDateTime(2022, 1, 3, 0, 0, 0);
            EssentialsDateTime jan04 = new EssentialsDateTime(2022, 1, 4, 0, 0, 0);
            EssentialsDateTime jan05 = new EssentialsDateTime(2022, 1, 5, 0, 0, 0);
            EssentialsDateTime jan06 = new EssentialsDateTime(2022, 1, 6, 0, 0, 0);

            // The week number is based on the year with most days of the week. The week with the days from December
            // 27th to Januar 2nd has five days in 2021 and only two days in 2020, so it becomes Week 52 of 2021. The
            // week from Januar 3rd to January 9th has all it's days in 2020, so it becomes Week 1 of 2020.
            Assert.AreEqual(52, dec27.WeekNumber, "December 27th");
            Assert.AreEqual(52, dec28.WeekNumber, "December 28th");
            Assert.AreEqual(52, dec29.WeekNumber, "December 29th");
            Assert.AreEqual(52, dec30.WeekNumber, "December 30th");
            Assert.AreEqual(52, dec31.WeekNumber, "December 31st");
            Assert.AreEqual(52, jan01.WeekNumber, "January 1st");
            Assert.AreEqual(52, jan02.WeekNumber, "January 2nd");
            Assert.AreEqual(1, jan03.WeekNumber, "January 3rd");
            Assert.AreEqual(1, jan04.WeekNumber, "January 4th");
            Assert.AreEqual(1, jan05.WeekNumber, "January 5th");
            Assert.AreEqual(1, jan06.WeekNumber, "January 6th");

        }

        [TestMethod]
        public void GetDaySuffix() {

            EssentialsDateTime jan01 = new EssentialsDateTime(2021, 1, 1, 0, 0, 0);
            EssentialsDateTime jan02 = new EssentialsDateTime(2021, 1, 2, 0, 0, 0);
            EssentialsDateTime jan03 = new EssentialsDateTime(2021, 1, 3, 0, 0, 0);
            EssentialsDateTime jan04 = new EssentialsDateTime(2021, 1, 4, 0, 0, 0);
            EssentialsDateTime jan05 = new EssentialsDateTime(2021, 1, 5, 0, 0, 0);
            EssentialsDateTime jan06 = new EssentialsDateTime(2021, 1, 6, 0, 0, 0);
            EssentialsDateTime jan07 = new EssentialsDateTime(2021, 1, 7, 0, 0, 0);
            EssentialsDateTime jan08 = new EssentialsDateTime(2021, 1, 8, 0, 0, 0);
            EssentialsDateTime jan09 = new EssentialsDateTime(2021, 1, 9, 0, 0, 0);
            EssentialsDateTime jan10 = new EssentialsDateTime(2021, 1, 10, 0, 0, 0);
            EssentialsDateTime jan11 = new EssentialsDateTime(2021, 1, 11, 0, 0, 0);
            EssentialsDateTime jan12 = new EssentialsDateTime(2021, 1, 12, 0, 0, 0);
            EssentialsDateTime jan13 = new EssentialsDateTime(2021, 1, 13, 0, 0, 0);
            EssentialsDateTime jan14 = new EssentialsDateTime(2021, 1, 14, 0, 0, 0);
            EssentialsDateTime jan15 = new EssentialsDateTime(2021, 1, 15, 0, 0, 0);
            EssentialsDateTime jan16 = new EssentialsDateTime(2021, 1, 16, 0, 0, 0);
            EssentialsDateTime jan17 = new EssentialsDateTime(2021, 1, 17, 0, 0, 0);
            EssentialsDateTime jan18 = new EssentialsDateTime(2021, 1, 18, 0, 0, 0);
            EssentialsDateTime jan19 = new EssentialsDateTime(2021, 1, 19, 0, 0, 0);
            EssentialsDateTime jan20 = new EssentialsDateTime(2021, 1, 20, 0, 0, 0);
            EssentialsDateTime jan21 = new EssentialsDateTime(2021, 1, 21, 0, 0, 0);
            EssentialsDateTime jan22 = new EssentialsDateTime(2021, 1, 22, 0, 0, 0);
            EssentialsDateTime jan23 = new EssentialsDateTime(2021, 1, 23, 0, 0, 0);
            EssentialsDateTime jan24 = new EssentialsDateTime(2021, 1, 24, 0, 0, 0);
            EssentialsDateTime jan25 = new EssentialsDateTime(2021, 1, 25, 0, 0, 0);
            EssentialsDateTime jan26 = new EssentialsDateTime(2021, 1, 26, 0, 0, 0);
            EssentialsDateTime jan27 = new EssentialsDateTime(2021, 1, 27, 0, 0, 0);
            EssentialsDateTime jan28 = new EssentialsDateTime(2021, 1, 28, 0, 0, 0);
            EssentialsDateTime jan29 = new EssentialsDateTime(2021, 1, 29, 0, 0, 0);
            EssentialsDateTime jan30 = new EssentialsDateTime(2021, 1, 30, 0, 0, 0);
            EssentialsDateTime jan31 = new EssentialsDateTime(2021, 1, 31, 0, 0, 0);

            Assert.AreEqual("st", jan01.DaySuffix, "January 1st");
            Assert.AreEqual("nd", jan02.DaySuffix, "January 2nd");
            Assert.AreEqual("rd", jan03.DaySuffix, "January 3rd");
            Assert.AreEqual("th", jan04.DaySuffix, "January 4th");
            Assert.AreEqual("th", jan05.DaySuffix, "January 5th");
            Assert.AreEqual("th", jan06.DaySuffix, "January 6th");
            Assert.AreEqual("th", jan07.DaySuffix, "January 7th");
            Assert.AreEqual("th", jan08.DaySuffix, "January 8th");
            Assert.AreEqual("th", jan09.DaySuffix, "January 9th");
            Assert.AreEqual("th", jan10.DaySuffix, "January 10th");
            Assert.AreEqual("th", jan11.DaySuffix, "January 11th");
            Assert.AreEqual("th", jan12.DaySuffix, "January 12th");
            Assert.AreEqual("th", jan13.DaySuffix, "January 13th");
            Assert.AreEqual("th", jan14.DaySuffix, "January 14th");
            Assert.AreEqual("th", jan15.DaySuffix, "January 15th");
            Assert.AreEqual("th", jan16.DaySuffix, "January 16th");
            Assert.AreEqual("th", jan17.DaySuffix, "January 17th");
            Assert.AreEqual("th", jan18.DaySuffix, "January 18th");
            Assert.AreEqual("th", jan19.DaySuffix, "January 19th");
            Assert.AreEqual("th", jan20.DaySuffix, "January 20th");
            Assert.AreEqual("st", jan21.DaySuffix, "January 21st");
            Assert.AreEqual("nd", jan22.DaySuffix, "January 22nd");
            Assert.AreEqual("rd", jan23.DaySuffix, "January 23rd");
            Assert.AreEqual("th", jan24.DaySuffix, "January 24th");
            Assert.AreEqual("th", jan25.DaySuffix, "January 25th");
            Assert.AreEqual("th", jan26.DaySuffix, "January 26th");
            Assert.AreEqual("th", jan27.DaySuffix, "January 27th");
            Assert.AreEqual("th", jan28.DaySuffix, "January 28th");
            Assert.AreEqual("th", jan29.DaySuffix, "January 29th");
            Assert.AreEqual("th", jan30.DaySuffix, "January 30th");
            Assert.AreEqual("st", jan31.DaySuffix, "January 31st");

        }

    }

}