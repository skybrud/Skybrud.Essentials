using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.Time {

    [TestClass]
    public class EssentialsTimeTests {

        public const string Format = "yyyy-MM-dd HH:mm:ss:fff K";

        [TestMethod]
        public void Constructor() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var samples = new[] {

                new Sample("2019-03-01 00:00:00:000 +00:00", new EssentialsTime(2019, 3, 1, utc)),
                new Sample("2019-03-31 00:00:00:000 +00:00", new EssentialsTime(2019, 3, 31, utc)),
                new Sample("2019-04-01 00:00:00:000 +00:00", new EssentialsTime(2019, 4, 1, utc)),

                new Sample("2019-03-01 00:00:00:000 +01:00", new EssentialsTime(2019, 3, 1, romance)),
                new Sample("2019-03-31 00:00:00:000 +01:00", new EssentialsTime(2019, 3, 31, romance)),
                new Sample("2019-04-01 00:00:00:000 +02:00", new EssentialsTime(2019, 4, 1, romance)),

                new Sample("2019-03-01 12:30:45:000 +01:00", new EssentialsTime(2019, 3, 1, 12, 30, 45, romance)),
                new Sample("2019-03-31 12:30:45:000 +02:00", new EssentialsTime(2019, 3, 31, 12, 30, 45, romance)),
                new Sample("2019-04-01 12:30:45:000 +02:00", new EssentialsTime(2019, 4, 1, 12, 30, 45, romance)),

                new Sample("2019-03-01 12:30:45:500 +01:00", new EssentialsTime(2019, 3, 1, 12, 30, 45, 500, romance)),
                new Sample("2019-03-31 12:30:45:500 +02:00", new EssentialsTime(2019, 3, 31, 12, 30, 45, 500, romance)),
                new Sample("2019-04-01 12:30:45:500 +02:00", new EssentialsTime(2019, 4, 1, 12, 30, 45, 500, romance))

            };

            for (int i = 0; i < samples.Length; i++) {

                var s = samples[i];

                Assert.AreEqual(s.Expected, s.Time.ToString(Format), $"Sample at index {i} failed test");

            }

        }

        [TestMethod]
        public void ConstructorDateTimeAndTimeZoneInfo1() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            DateTime input = new DateTime(2020, 9, 27, 12, 17, 21, DateTimeKind.Utc);

            EssentialsTime result = new EssentialsTime(input, utc);

            Assert.AreEqual("2020-09-27 12:17:21:000 +00:00", result.ToString(Format));

        }

        [TestMethod]
        public void ConstructorDateTimeAndTimeZoneInfo2() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTime input = new DateTime(2020, 9, 27, 12, 17, 21, DateTimeKind.Utc);

            EssentialsTime result = new EssentialsTime(input, romance);

            Assert.AreEqual("2020-09-27 14:17:21:000 +02:00", result.ToString(Format));

        }

        [TestMethod]
        public void ConstructorDateTimeAndTimeZoneInfo3() {

            // Convert to Eastern European Time
            TimeZoneInfo eet = TimeZoneInfo.FindSystemTimeZoneById("E. Europe Standard Time");

            DateTime input = new DateTime(2020, 9, 27, 12, 17, 21, DateTimeKind.Utc);

            EssentialsTime result = new EssentialsTime(input, eet);

            Assert.AreEqual("2020-09-27 15:17:21:000 +03:00", result.ToString(Format));

        }

        [TestMethod]
        public void ConstructorDateTimeAndTimeZoneInfo4() {

            // Notice: this test is likely fail if the local time zone isn't Romance Standard Time

            DateTime input = new DateTime(2020, 9, 27, 14, 17, 21, DateTimeKind.Local);

            EssentialsTime result = new EssentialsTime(input, TimeZoneInfo.Utc);

            Assert.AreEqual("2020-09-27 12:17:21:000 +00:00", result.ToString(Format));

        }

        [TestMethod]
        public void ToTimeZone() {
            
            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var samples = new[] {

                // "Romance Standard Time" changes to "Romance Daylight Time" in the last weekend of March
                new ToTimeZoneSample("2019-03-01 01:00:00:000 +01:00", "2019-03-01 00:00:00:000 +00:00", romance),
                new ToTimeZoneSample("2019-04-01 02:00:00:000 +02:00", "2019-04-01 00:00:00:000 +00:00", romance),
                new ToTimeZoneSample("2019-03-01 00:00:00:000 +00:00", "2019-03-01 01:00:00:000 +01:00", utc),
                new ToTimeZoneSample("2019-04-01 00:00:00:000 +00:00", "2019-04-01 02:00:00:000 +02:00", utc)

            };
            
            for (int i = 0; i < samples.Length; i++) {

                var s = samples[i];

                Assert.AreEqual(s.Expected, s.Time.ToTimeZone(s.TimeZone).ToString(Format), $"Sample at index {i} failed test");

            }

        }
        

        [TestMethod]
        public void FromIso8601Week() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsTime time1 = EssentialsTime.FromIso8601Week(2019, 12, utc);
            EssentialsTime time2 = EssentialsTime.FromIso8601Week(2019, 13, utc);
            EssentialsTime time3 = EssentialsTime.FromIso8601Week(2019, 14, utc);

            EssentialsTime time4 = EssentialsTime.FromIso8601Week(2019, 12, romance);
            EssentialsTime time5 = EssentialsTime.FromIso8601Week(2019, 13, romance);
            EssentialsTime time6 = EssentialsTime.FromIso8601Week(2019, 14, romance);

            Assert.AreEqual("2019-03-18 00:00:00:000 +00:00", time1.ToString(Format), "#1");
            Assert.AreEqual("2019-03-25 00:00:00:000 +00:00", time2.ToString(Format), "#2");
            Assert.AreEqual("2019-04-01 00:00:00:000 +00:00", time3.ToString(Format), "#3");

            Assert.AreEqual("2019-03-18 00:00:00:000 +01:00", time4.ToString(Format), "#4");
            Assert.AreEqual("2019-03-25 00:00:00:000 +01:00", time5.ToString(Format), "#5");
            Assert.AreEqual("2019-04-01 00:00:00:000 +02:00", time6.ToString(Format), "#6");

        }

        [TestMethod]
        public void YearAndDay() {

            EssentialsTime a = new EssentialsTime(2019, 1, 1, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime b = new EssentialsTime(2019, 10, 20, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime c = new EssentialsTime(2019, 12, 31, 0, 0, 0, TimeSpan.Zero);

            Assert.AreEqual(2019001, a.YearAndDay);
            Assert.AreEqual(2019293, b.YearAndDay);
            Assert.AreEqual(2019365, c.YearAndDay);

        }

        [TestMethod]
        public void GetDay() {

            EssentialsTime monday    = new EssentialsTime(2021,  9, 27, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime tuesday   = new EssentialsTime(2021,  9, 28, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime wednesday = new EssentialsTime(2021,  9, 29, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime thursday  = new EssentialsTime(2021,  9, 30, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime friday    = new EssentialsTime(2021, 10,  1, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime saturday  = new EssentialsTime(2021, 10,  2, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime sunday    = new EssentialsTime(2021, 10,  3, 0, 0, 0, TimeSpan.Zero);
            
            Assert.AreEqual(27, monday.Day);
            Assert.AreEqual(28, tuesday.Day);
            Assert.AreEqual(29, wednesday.Day);
            Assert.AreEqual(30, thursday.Day);
            Assert.AreEqual( 1, friday.Day);
            Assert.AreEqual( 2, saturday.Day);
            Assert.AreEqual( 3, sunday.Day);

        }

        [TestMethod]
        public void GetDayOfWeek() {

            EssentialsTime monday    = new EssentialsTime(2021,  9, 27, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime tuesday   = new EssentialsTime(2021,  9, 28, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime wednesday = new EssentialsTime(2021,  9, 29, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime thursday  = new EssentialsTime(2021,  9, 30, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime friday    = new EssentialsTime(2021, 10,  1, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime saturday  = new EssentialsTime(2021, 10,  2, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime sunday    = new EssentialsTime(2021, 10,  3, 0, 0, 0, TimeSpan.Zero);
            
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

            EssentialsTime monday2020    = new EssentialsTime(2020,  9, 27, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime tuesday2020   = new EssentialsTime(2020,  9, 28, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime wednesday2020 = new EssentialsTime(2020,  9, 29, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime thursday2020  = new EssentialsTime(2020,  9, 30, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime friday2020    = new EssentialsTime(2020, 10,  1, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime saturday2020  = new EssentialsTime(2020, 10,  2, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime sunday2020    = new EssentialsTime(2020, 10,  3, 0, 0, 0, TimeSpan.Zero);

            EssentialsTime monday2021    = new EssentialsTime(2021,  9, 27, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime tuesday2021   = new EssentialsTime(2021,  9, 28, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime wednesday2021 = new EssentialsTime(2021,  9, 29, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime thursday2021  = new EssentialsTime(2021,  9, 30, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime friday2021    = new EssentialsTime(2021, 10,  1, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime saturday2021  = new EssentialsTime(2021, 10,  2, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime sunday2021    = new EssentialsTime(2021, 10,  3, 0, 0, 0, TimeSpan.Zero);
            
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
            
            EssentialsTime y2020 = new EssentialsTime(2020, 9, 27, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime y2021 = new EssentialsTime(2021, 9, 27, 0, 0, 0, TimeSpan.Zero);
            
            Assert.IsTrue(y2020.IsLeapYear);
            Assert.IsFalse(y2021.IsLeapYear);

        }

        [TestMethod]
        public void GetDaysInMonth() {

            // 2020 was a leap year, 2021 isn't
            
            EssentialsTime y2020 = new EssentialsTime(2020, 2, 26, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime y2021 = new EssentialsTime(2021, 2, 26, 0, 0, 0, TimeSpan.Zero);
            
            Assert.AreEqual(29, y2020.DaysInMonth);
            Assert.AreEqual(28, y2021.DaysInMonth);

        }

        [TestMethod]
        public void IsWeekday() {

            EssentialsTime monday    = new EssentialsTime(2021,  9, 27, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime tuesday   = new EssentialsTime(2021,  9, 28, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime wednesday = new EssentialsTime(2021,  9, 29, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime thursday  = new EssentialsTime(2021,  9, 30, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime friday    = new EssentialsTime(2021, 10,  1, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime saturday  = new EssentialsTime(2021, 10,  2, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime sunday    = new EssentialsTime(2021, 10,  3, 0, 0, 0, TimeSpan.Zero);
            
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

            EssentialsTime monday    = new EssentialsTime(2021,  9, 27, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime tuesday   = new EssentialsTime(2021,  9, 28, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime wednesday = new EssentialsTime(2021,  9, 29, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime thursday  = new EssentialsTime(2021,  9, 30, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime friday    = new EssentialsTime(2021, 10,  1, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime saturday  = new EssentialsTime(2021, 10,  2, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime sunday    = new EssentialsTime(2021, 10,  3, 0, 0, 0, TimeSpan.Zero);
            
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

            EssentialsTime dec27 = new EssentialsTime(2021, 12, 27, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime dec28 = new EssentialsTime(2021, 12, 28, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime dec29 = new EssentialsTime(2021, 12, 29, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime dec30 = new EssentialsTime(2021, 12, 30, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime dec31 = new EssentialsTime(2021, 12, 31, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan01 = new EssentialsTime(2022,  1,  1, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan02 = new EssentialsTime(2022,  1,  2, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan03 = new EssentialsTime(2022,  1,  3, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan04 = new EssentialsTime(2022,  1,  4, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan05 = new EssentialsTime(2022,  1,  5, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan06 = new EssentialsTime(2022,  1,  6, 0, 0, 0, TimeSpan.Zero);
            
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
            Assert.AreEqual( 1, jan03.WeekNumber, "January 3rd");
            Assert.AreEqual( 1, jan04.WeekNumber, "January 4th");
            Assert.AreEqual( 1, jan05.WeekNumber, "January 5th");
            Assert.AreEqual( 1, jan06.WeekNumber, "January 6th");

        }

        [TestMethod]
        public void GetDaySuffix() {
            
            EssentialsTime jan01 = new EssentialsTime(2021, 1, 1, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan02 = new EssentialsTime(2021, 1, 2, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan03 = new EssentialsTime(2021, 1, 3, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan04 = new EssentialsTime(2021, 1, 4, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan05 = new EssentialsTime(2021, 1, 5, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan06 = new EssentialsTime(2021, 1, 6, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan07 = new EssentialsTime(2021, 1, 7, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan08 = new EssentialsTime(2021, 1, 8, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan09 = new EssentialsTime(2021, 1, 9, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan10 = new EssentialsTime(2021, 1, 10, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan11 = new EssentialsTime(2021, 1, 11, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan12 = new EssentialsTime(2021, 1, 12, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan13 = new EssentialsTime(2021, 1, 13, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan14 = new EssentialsTime(2021, 1, 14, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan15 = new EssentialsTime(2021, 1, 15, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan16 = new EssentialsTime(2021, 1, 16, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan17 = new EssentialsTime(2021, 1, 17, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan18 = new EssentialsTime(2021, 1, 18, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan19 = new EssentialsTime(2021, 1, 19, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan20 = new EssentialsTime(2021, 1, 20, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan21 = new EssentialsTime(2021, 1, 21, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan22 = new EssentialsTime(2021, 1, 22, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan23 = new EssentialsTime(2021, 1, 23, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan24 = new EssentialsTime(2021, 1, 24, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan25 = new EssentialsTime(2021, 1, 25, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan26 = new EssentialsTime(2021, 1, 26, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan27 = new EssentialsTime(2021, 1, 27, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan28 = new EssentialsTime(2021, 1, 28, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan29 = new EssentialsTime(2021, 1, 29, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan30 = new EssentialsTime(2021, 1, 30, 0, 0, 0, TimeSpan.Zero);
            EssentialsTime jan31 = new EssentialsTime(2021, 1, 31, 0, 0, 0, TimeSpan.Zero);
            
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

        [TestMethod]
        public void IsToday() {

            EssentialsTime yesterday = EssentialsTime.Today.AddDays(-1);
            EssentialsTime today = EssentialsTime.Today;
            EssentialsTime tomorrow = EssentialsTime.Today.AddDays(+1);

            Assert.AreEqual(false, yesterday.IsToday, "#yesterday");
            Assert.AreEqual(true, today.IsToday, "#today");
            Assert.AreEqual(false, tomorrow.IsToday, "#tomorrow");

        }

        [TestMethod]
        public void IsTomorrow() {

            EssentialsTime yesterday = EssentialsTime.Today.AddDays(-1);
            EssentialsTime today = EssentialsTime.Today;
            EssentialsTime tomorrow = EssentialsTime.Today.AddDays(+1);

            Assert.AreEqual(false, yesterday.IsTomorrow, "#yesterday");
            Assert.AreEqual(false, today.IsTomorrow, "#today");
            Assert.AreEqual(true, tomorrow.IsTomorrow, "#tomorrow");

        }

        [TestMethod]
        public void IsYesterday() {

            EssentialsTime yesterday = EssentialsTime.Today.AddDays(-1);
            EssentialsTime today = EssentialsTime.Today;
            EssentialsTime tomorrow = EssentialsTime.Today.AddDays(+1);

            Assert.AreEqual(true, yesterday.IsYesterday, "#yesterday");
            Assert.AreEqual(false, today.IsYesterday, "#today");
            Assert.AreEqual(false, tomorrow.IsYesterday, "#tomorrow");

        }

        [TestMethod]
        public void FromTicksLocal() {

            DateTime dt = new DateTime(2021, 1, 13, 22, 00, 00, DateTimeKind.Local);
            Assert.AreEqual(637461720000000000, dt.Ticks, "#1");

            // We can't use a format with offset or time zone, as it may differ depending on the environment
            Assert.AreEqual("2021-01-13T22:00:00", dt.ToString("yyyy-MM-ddTHH:mm:ss"), "#2");

            // Convert to EssentialsTime
            EssentialsTime time = EssentialsTime.FromTicks(dt.Ticks);

            Assert.AreEqual(637461720000000000, time.Ticks, "#3");
            Assert.AreEqual("2021-01-13T22:00:00", time.ToString("yyyy-MM-ddTHH:mm:ss"), "#4");

        }

        [TestMethod]
        public void FromTicksLocalUtc() {

            DateTime dt = new DateTime(2021, 1, 13, 22, 00, 00, DateTimeKind.Utc);
            Assert.AreEqual(637461720000000000, dt.Ticks, "#1");

            // We can't use a format with offset or time zone, as it may differ depending on the environment
            Assert.AreEqual("2021-01-13T22:00:00Z", dt.ToString("yyyy-MM-ddTHH:mm:ssK"), "#2");

            // Convert to EssentialsTime
            EssentialsTime time = EssentialsTime.FromTicks(dt.Ticks, TimeSpan.Zero);

            // Same as DateTime
            Assert.AreEqual(637461720000000000, time.Ticks, "#3");
            
            // Offset is now +00:00 instead of Z (difference between DateTimeOffset and DateTime)
            Assert.AreEqual("2021-01-13T22:00:00+00:00", time.ToString("yyyy-MM-ddTHH:mm:ssK"), "#4");

        }

        public class Sample {

            public string Expected { get; }

            public EssentialsTime Time { get; }

            public Sample(string expected, EssentialsTime time) {
                Expected = expected;
                Time = time;
            }

        }

        public class ToTimeZoneSample {

            public string Expected { get; }

            public EssentialsTime Time { get; }

            public TimeZoneInfo TimeZone { get; }

            public ToTimeZoneSample(string expected, string input, TimeZoneInfo timeZone) {
                Expected = expected;
                Time = DateTimeOffset.ParseExact(input, Format, CultureInfo.InvariantCulture);
                TimeZone = timeZone;
            }

        }

    }

}