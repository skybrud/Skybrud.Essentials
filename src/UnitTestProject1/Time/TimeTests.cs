using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.Extensions;

namespace UnitTestProject1.Time {

    [TestClass]
    public class TimeTests {

        [TestMethod]
        public void GetAge() {

            // Since the age doesn't have a fixed value, we fake the value of "now"
            DateTime fakeNow = new DateTime(2014, 02, 15);

            var samples = new[] {
                new { Date = new DateTime(1970, 01, 01), Age = 44 },
                new { Date = new DateTime(1988, 08, 17), Age = 25 }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Age, TimeHelper.GetAge(sample.Date, fakeNow), "\n\n" + sample.Date + " (TimeHelper)");
                Assert.AreEqual(sample.Age, sample.Date.GetAge(fakeNow), "\n\n" + sample.Date + " (extension method)");
            }

        }

        [TestMethod]
        public void GetAge_DateTimeOffset() {

            // Since the age doesn't have a fixed value, we fake the value of "now"
            DateTimeOffset fakeNow = new DateTimeOffset(2014, 02, 15, 0, 0, 0, TimeSpan.FromHours(0));

            var samples = new[] {
                new { Date = new DateTimeOffset(1970, 01, 01, 0, 0, 0, TimeSpan.FromHours(0)), Age = 44 },
                new { Date = new DateTimeOffset(1988, 08, 17, 0, 0, 0, TimeSpan.FromHours(0)), Age = 25 }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Age, TimeUtils.GetAge(sample.Date, fakeNow), "\n\n" + sample.Date + " (TimeUtils)");
                //Assert.AreEqual(sample.Age, sample.Date.GetAge(fakeNow), "\n\n" + sample.Date + " (extension method)");
            }

        }

        [TestMethod]
        public void GetDayNumberAndSuffix() {

            Assert.AreEqual("1st", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 1)));
            Assert.AreEqual("2nd", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 2)));
            Assert.AreEqual("3rd", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 3)));
            Assert.AreEqual("4th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 4)));
            Assert.AreEqual("5th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 5)));
            Assert.AreEqual("6th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 6)));
            Assert.AreEqual("7th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 7)));
            Assert.AreEqual("8th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 8)));
            Assert.AreEqual("9th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 9)));

            Assert.AreEqual("10th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 10)));
            Assert.AreEqual("11th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 11)));
            Assert.AreEqual("12th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 12)));
            Assert.AreEqual("13th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 13)));
            Assert.AreEqual("14th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 14)));
            Assert.AreEqual("15th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 15)));
            Assert.AreEqual("16th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 16)));
            Assert.AreEqual("17th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 17)));
            Assert.AreEqual("18th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 18)));
            Assert.AreEqual("19th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 19)));

            Assert.AreEqual("20th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 20)));
            Assert.AreEqual("21st", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 21)));
            Assert.AreEqual("22nd", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 22)));
            Assert.AreEqual("23rd", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 23)));
            Assert.AreEqual("24th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 24)));
            Assert.AreEqual("25th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 25)));
            Assert.AreEqual("26th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 26)));
            Assert.AreEqual("27th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 27)));
            Assert.AreEqual("28th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 28)));
            Assert.AreEqual("29th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 29)));

            Assert.AreEqual("30th", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 30)));
            Assert.AreEqual("31st", TimeHelper.GetDayNumberAndSuffix(new DateTime(2014, 1, 31)));

        }

        [TestMethod]
        public void GetDaySuffix() {

            Assert.AreEqual("st", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 1)));
            Assert.AreEqual("nd", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 2)));
            Assert.AreEqual("rd", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 3)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 4)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 5)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 6)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 7)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 8)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 9)));

            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 10)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 11)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 12)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 13)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 14)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 15)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 16)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 17)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 18)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 19)));

            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 20)));
            Assert.AreEqual("st", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 21)));
            Assert.AreEqual("nd", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 22)));
            Assert.AreEqual("rd", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 23)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 24)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 25)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 26)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 27)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 28)));
            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 29)));

            Assert.AreEqual("th", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 30)));
            Assert.AreEqual("st", TimeHelper.GetDaySuffix(new DateTime(2014, 1, 31)));

        }

        [TestMethod]
        public void GetWeekNumber() {

            var samples = new[] {
                new { Date = new DateTime(2014, 12, 29), Week = 1 },
                new { Date = new DateTime(2014, 12, 30), Week = 1 },
                new { Date = new DateTime(2014, 12, 31), Week = 1 },
                new { Date = new DateTime(2015,  1,  1), Week = 1 },
                new { Date = new DateTime(2015,  1,  2), Week = 1 },
                new { Date = new DateTime(2015,  1,  3), Week = 1 },
                new { Date = new DateTime(2015,  1,  4), Week = 1 }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Week, TimeHelper.GetIso8601WeekNumber(sample.Date), "\n\n" + sample.Date + " (TimeHelper)");
                Assert.AreEqual(sample.Week, sample.Date.GetIso8601WeekNumber(), "\n\n" + sample.Date + " (extension method)");
            }

        }

        [TestMethod]
        public void IsWeekDay() {

            Assert.AreEqual(true, TimeHelper.IsWeekday(new DateTime(2014, 2, 10)), "\n\n (TimeHelper)");
            Assert.AreEqual(true, TimeHelper.IsWeekday(new DateTime(2014, 2, 11)), "\n\n (TimeHelper)");
            Assert.AreEqual(true, TimeHelper.IsWeekday(new DateTime(2014, 2, 12)), "\n\n (TimeHelper)");
            Assert.AreEqual(true, TimeHelper.IsWeekday(new DateTime(2014, 2, 13)), "\n\n (TimeHelper)");
            Assert.AreEqual(true, TimeHelper.IsWeekday(new DateTime(2014, 2, 14)), "\n\n (TimeHelper)");
            Assert.AreEqual(false, TimeHelper.IsWeekday(new DateTime(2014, 2, 15)), "\n\n (TimeHelper)");
            Assert.AreEqual(false, TimeHelper.IsWeekday(new DateTime(2014, 2, 16)), "\n\n (TimeHelper)");

            Assert.AreEqual(true, new DateTime(2014, 2, 10).IsWeekday(), "\n\n (extension method)");
            Assert.AreEqual(true, new DateTime(2014, 2, 11).IsWeekday(), "\n\n (extension method)");
            Assert.AreEqual(true, new DateTime(2014, 2, 12).IsWeekday(), "\n\n (extension method)");
            Assert.AreEqual(true, new DateTime(2014, 2, 13).IsWeekday(), "\n\n (extension method)");
            Assert.AreEqual(true, new DateTime(2014, 2, 14).IsWeekday(), "\n\n (extension method)");
            Assert.AreEqual(false, new DateTime(2014, 2, 15).IsWeekday(), "\n\n (extension method)");
            Assert.AreEqual(false, new DateTime(2014, 2, 16).IsWeekday(), "\n\n (extension method)");

        }

        [TestMethod]
        public void IsWeekend() {

            Assert.AreEqual(false, TimeHelper.IsWeekend(new DateTime(2014, 2, 10)), "\n\n (TimeHelper)");
            Assert.AreEqual(false, TimeHelper.IsWeekend(new DateTime(2014, 2, 11)), "\n\n (TimeHelper)");
            Assert.AreEqual(false, TimeHelper.IsWeekend(new DateTime(2014, 2, 12)), "\n\n (TimeHelper)");
            Assert.AreEqual(false, TimeHelper.IsWeekend(new DateTime(2014, 2, 13)), "\n\n (TimeHelper)");
            Assert.AreEqual(false, TimeHelper.IsWeekend(new DateTime(2014, 2, 14)), "\n\n (TimeHelper)");
            Assert.AreEqual(true, TimeHelper.IsWeekend(new DateTime(2014, 2, 15)), "\n\n (TimeHelper)");
            Assert.AreEqual(true, TimeHelper.IsWeekend(new DateTime(2014, 2, 16)), "\n\n (TimeHelper)");

            Assert.AreEqual(false, new DateTime(2014, 2, 10).IsWeekend(), "\n\n (extension method)");
            Assert.AreEqual(false, new DateTime(2014, 2, 11).IsWeekend(), "\n\n (extension method)");
            Assert.AreEqual(false, new DateTime(2014, 2, 12).IsWeekend(), "\n\n (extension method)");
            Assert.AreEqual(false, new DateTime(2014, 2, 13).IsWeekend(), "\n\n (extension method)");
            Assert.AreEqual(false, new DateTime(2014, 2, 14).IsWeekend(), "\n\n (extension method)");
            Assert.AreEqual(true, new DateTime(2014, 2, 15).IsWeekend(), "\n\n (extension method)");
            Assert.AreEqual(true, new DateTime(2014, 2, 16).IsWeekend(), "\n\n (extension method)");

        }

        [TestMethod]
        public void IsLeapYear() {

            // Se more here: http://en.wikipedia.org/wiki/Leap_year#Algorithm

            var samples = new[] {
            
                new { Year = 2000, IsLeapYear = true },
                new { Year = 2001, IsLeapYear = false },
                new { Year = 2002, IsLeapYear = false },
                new { Year = 2003, IsLeapYear = false },
                new { Year = 2004, IsLeapYear = true },
                new { Year = 2005, IsLeapYear = false },
                new { Year = 2006, IsLeapYear = false },
                new { Year = 2007, IsLeapYear = false },
                new { Year = 2008, IsLeapYear = true },
                new { Year = 2009, IsLeapYear = false },
                new { Year = 2010, IsLeapYear = false },
                new { Year = 2011, IsLeapYear = false },
                new { Year = 2012, IsLeapYear = true },
                new { Year = 2013, IsLeapYear = false },
                new { Year = 2014, IsLeapYear = false },
            
                new { Year = 1500, IsLeapYear = false },
                new { Year = 1600, IsLeapYear = true },
                new { Year = 1700, IsLeapYear = false },
                new { Year = 1800, IsLeapYear = false },
                new { Year = 1900, IsLeapYear = false },
                new { Year = 2000, IsLeapYear = true },
                new { Year = 2100, IsLeapYear = false },
                new { Year = 2200, IsLeapYear = false },
                new { Year = 2300, IsLeapYear = false },
                new { Year = 2400, IsLeapYear = true }
            
            };

            foreach (var sample in samples) {

                DateTime dt = new DateTime(sample.Year, 1, 1);

                Assert.AreEqual(sample.IsLeapYear, TimeHelper.IsLeapYear(sample.Year), "\n\n" + sample.Year + " (TimeHelper)");
                Assert.AreEqual(sample.IsLeapYear, TimeHelper.IsLeapYear(dt), "\n\n" + sample.Year + " (TimeHelper)");

                Assert.AreEqual(sample.IsLeapYear, dt.IsLeapYear(), "\n\n" + sample.Year + " (extension method)");

            }

        }

        #region Unix time

        [TestMethod]
        public void GetUnixTimeFromDateTime() {

            var samples = new[] {
                new { Timestamp = 1408269600, Text = "2014-08-17T10:00:00Z" },
                new { Timestamp = 1408269600, Text = "2014-08-17T12:00:00+02:00" },
                new { Timestamp = 1408269600, Text = "2014-08-17T13:00:00+03:00" },
                new { Timestamp = 1419440400, Text = "2014-12-24T17:00:00Z" },
                new { Timestamp = 1419440400, Text = "2014-12-24T18:00:00+01:00" },
                new { Timestamp = 1419440400, Text = "2014-12-24T19:00:00+02:00" }
            };

            foreach (var sample in samples) {

                DateTime date = DateTime.Parse(sample.Text);

                long local = TimeHelper.GetUnixTimeFromDateTime(date);
                long utc = TimeHelper.GetUnixTimeFromDateTime(date.ToUniversalTime());

                Assert.AreEqual(sample.Timestamp, local);
                Assert.AreEqual(sample.Timestamp, utc);

            }

        }

        [TestMethod]
        public void GetUnixTimeFromDateTimeOffset() {

            var samples = new[] {
                new { Timestamp = 1408269600, Text = "2014-08-17T10:00:00Z" },
                new { Timestamp = 1408269600, Text = "2014-08-17T12:00:00+02:00" },
                new { Timestamp = 1408269600, Text = "2014-08-17T13:00:00+03:00" },
                new { Timestamp = 1419440400, Text = "2014-12-24T17:00:00Z" },
                new { Timestamp = 1419440400, Text = "2014-12-24T18:00:00+01:00" },
                new { Timestamp = 1419440400, Text = "2014-12-24T19:00:00+02:00" }
            };

            foreach (var sample in samples) {

                DateTimeOffset date = DateTimeOffset.Parse(sample.Text);

                long local = TimeHelper.GetUnixTimeFromDateTimeOffset(date);
                long utc = TimeHelper.GetUnixTimeFromDateTimeOffset(date.ToUniversalTime());

                Assert.AreEqual(sample.Timestamp, local);
                Assert.AreEqual(sample.Timestamp, utc);

            }

        }

        [TestMethod]
        public void GetDateTimeFromUnixTime() {

            // DateTime is bad a handling timezones besides "Local" and "Utc", so the texttual values doesn't mention the timezones
            
            var samples = new[] {
                new { Timestamp = 1408269600, TextUtc = "2014-08-17T10:00:00", TextLocal = "2014-08-17T12:00:00", TimeZone = "Romance Standard Time" },
                new { Timestamp = 1419440400, TextUtc = "2014-12-24T17:00:00", TextLocal = "2014-12-24T18:00:00", TimeZone = "Romance Standard Time" },
                new { Timestamp = 1419440400, TextUtc = "2014-12-24T17:00:00", TextLocal = "2014-12-24T19:00:00", TimeZone = "Middle East Standard Time" }
            };

            foreach (var sample in samples) {

                // Get the timezone of the sample
                TimeZoneInfo timezone = TimeZoneInfo.FindSystemTimeZoneById(sample.TimeZone);

                // Get the DateTime from the timestamp
                DateTime date = TimeHelper.GetDateTimeFromUnixTime(sample.Timestamp).ToUniversalTime();

                // Convert the DateTime to a local DateTime
                DateTime dateLocal = TimeZoneInfo.ConvertTime(date, TimeZoneInfo.Utc, timezone);

                string local = dateLocal.ToString(TimeHelper.Iso8601DateFormat.Replace("K", ""));
                string utc = date.ToUniversalTime().ToString(TimeHelper.Iso8601DateFormat.Replace("K", ""));

                Assert.AreEqual(sample.TextLocal, local, "local");
                Assert.AreEqual(sample.TextUtc, utc, "utc");

            }

        }

        [TestMethod]
        public void GetDateTimeOffsetFromUnixTime() {

            var samples = new[] {
                new { Timestamp = 1408269600, TextUtc = "2014-08-17T10:00:00+00:00", TextLocal = "2014-08-17T12:00:00+02:00", TimeZone = "Romance Standard Time" },
                new { Timestamp = 1419440400, TextUtc = "2014-12-24T17:00:00+00:00", TextLocal = "2014-12-24T18:00:00+01:00", TimeZone = "Romance Standard Time" },
                new { Timestamp = 1419440400, TextUtc = "2014-12-24T17:00:00+00:00", TextLocal = "2014-12-24T19:00:00+02:00", TimeZone = "Middle East Standard Time" }
            };

            foreach (var sample in samples) {

                // Get the timezone of the sample
                TimeZoneInfo timezone = TimeZoneInfo.FindSystemTimeZoneById(sample.TimeZone);

                // Get the DateTimeOffset from the timestamp
                DateTimeOffset date = TimeHelper.GetDateTimeOffsetFromUnixTime(sample.Timestamp);

                DateTimeOffset dateLocal = TimeZoneInfo.ConvertTime(date, timezone);

                string local = dateLocal.ToString(TimeHelper.Iso8601DateFormat);
                string utc = date.ToUniversalTime().ToString(TimeHelper.Iso8601DateFormat);

                Assert.AreEqual(sample.TextLocal, local, "local");
                Assert.AreEqual(sample.TextUtc, utc, "utc");

            }

        }

        #endregion

        [TestMethod]
        public void GetFirstDayOfMonth() {

            var samples = new[] {
                // TODO: Add more samples
                new { Date = new DateTime(2014, 1, 15), Expected = new DateTime(2014, 1, 1) },
                new { Date = new DateTime(2014, 2, 15), Expected = new DateTime(2014, 2, 1) },
                new { Date = new DateTime(2014, 3, 15), Expected = new DateTime(2014, 3, 1) },
                new { Date = new DateTime(2014, 4, 15), Expected = new DateTime(2014, 4, 1) },
                new { Date = new DateTime(2014, 5, 15), Expected = new DateTime(2014, 5, 1) },
                new { Date = new DateTime(2014, 6, 15), Expected = new DateTime(2014, 6, 1) },
                new { Date = new DateTime(2014, 7, 15), Expected = new DateTime(2014, 7, 1) },
                new { Date = new DateTime(2014, 8, 15), Expected = new DateTime(2014, 8, 1) },
                new { Date = new DateTime(2014, 9, 15), Expected = new DateTime(2014, 9, 1) },
                new { Date = new DateTime(2014, 10, 15), Expected = new DateTime(2014, 10, 1) },
                new { Date = new DateTime(2014, 11, 15), Expected = new DateTime(2014, 11, 1) },
                new { Date = new DateTime(2014, 12, 15), Expected = new DateTime(2014, 12, 1) }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, TimeHelper.GetFirstDayOfMonth(sample.Date), "TimeHelper");
                Assert.AreEqual(sample.Expected, sample.Date.GetFirstDayOfMonth(), "Extension method");
            }

        }

        [TestMethod]
        public void GetLastDayOfMonth() {

            var samples = new[] {
                new { Date = new DateTime(2014, 1, 15), Expected = new DateTime(2014, 1, 31, 23, 59, 59) },
                new { Date = new DateTime(2014, 2, 15), Expected = new DateTime(2014, 2, 28, 23, 59, 59) },
                new { Date = new DateTime(2015, 2, 15), Expected = new DateTime(2015, 2, 28, 23, 59, 59) },
                new { Date = new DateTime(2016, 2, 15), Expected = new DateTime(2016, 2, 29, 23, 59, 59) },
                new { Date = new DateTime(2014, 3, 15), Expected = new DateTime(2014, 3, 31, 23, 59, 59) },
                new { Date = new DateTime(2014, 4, 15), Expected = new DateTime(2014, 4, 30, 23, 59, 59) },
                new { Date = new DateTime(2014, 5, 15), Expected = new DateTime(2014, 5, 31, 23, 59, 59) },
                new { Date = new DateTime(2014, 6, 15), Expected = new DateTime(2014, 6, 30, 23, 59, 59) },
                new { Date = new DateTime(2014, 7, 15), Expected = new DateTime(2014, 7, 31, 23, 59, 59) },
                new { Date = new DateTime(2014, 8, 15), Expected = new DateTime(2014, 8, 31, 23, 59, 59) },
                new { Date = new DateTime(2014, 9, 15), Expected = new DateTime(2014, 9, 30, 23, 59, 59) },
                new { Date = new DateTime(2014, 10, 15), Expected = new DateTime(2014, 10, 31, 23, 59, 59) },
                new { Date = new DateTime(2014, 11, 15), Expected = new DateTime(2014, 11, 30, 23, 59, 59) },
                new { Date = new DateTime(2014, 12, 15), Expected = new DateTime(2014, 12, 31, 23, 59, 59) }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, TimeHelper.GetLastDayOfMonth(sample.Date), "TimeHelper");
                Assert.AreEqual(sample.Expected, sample.Date.GetLastDayOfMonth(), "Extension method");
            }

        }

        [TestMethod]
        public void GetFirstDayOfWeek() {

            var samples = new[] {
                new { Date = new DateTime(2014, 12, 29), Monday = new DateTime(2014, 12, 29), Sunday = new DateTime(2014, 12, 28) },
                new { Date = new DateTime(2014, 12, 30), Monday = new DateTime(2014, 12, 29), Sunday = new DateTime(2014, 12, 28) },
                new { Date = new DateTime(2014, 12, 31), Monday = new DateTime(2014, 12, 29), Sunday = new DateTime(2014, 12, 28) },
                new { Date = new DateTime(2015,  1,  1), Monday = new DateTime(2014, 12, 29), Sunday = new DateTime(2014, 12, 28) },
                new { Date = new DateTime(2015,  1,  2), Monday = new DateTime(2014, 12, 29), Sunday = new DateTime(2014, 12, 28) },
                new { Date = new DateTime(2015,  1,  3), Monday = new DateTime(2014, 12, 29), Sunday = new DateTime(2014, 12, 28) },
                new { Date = new DateTime(2015,  1,  4), Monday = new DateTime(2014, 12, 29), Sunday = new DateTime(2015,  1,  4) }
            };

            foreach (var sample in samples) {

                Assert.AreEqual(sample.Monday, TimeHelper.GetFirstDayOfWeek(sample.Date), "\n\n" + sample.Date + " (TimeHelper - implicit)");
                Assert.AreEqual(sample.Monday, sample.Date.GetFirstDayOfWeek(), "\n\n" + sample.Date + " (Extension method - implicit)");

                Assert.AreEqual(sample.Monday, TimeHelper.GetFirstDayOfWeek(sample.Date, DayOfWeek.Monday), "\n\n" + sample.Date + " (TimeHelper - explicit: Monday)");
                Assert.AreEqual(sample.Monday, sample.Date.GetFirstDayOfWeek(DayOfWeek.Monday), "\n\n" + sample.Date + " (Extension method - explicit: Monday)");

                Assert.AreEqual(sample.Sunday, TimeHelper.GetFirstDayOfWeek(sample.Date, DayOfWeek.Sunday), "\n\n" + sample.Date + " (TimeHelper - explicit: Sunday)");
                Assert.AreEqual(sample.Sunday, sample.Date.GetFirstDayOfWeek(DayOfWeek.Sunday), "\n\n" + sample.Date + " (Extension method - explicit: Sunday)");

            }

        }

        [TestMethod]
        public void GetLastDayOfWeek() {

            var samples = new[] {
                new { Date = new DateTime(2014, 12, 29), Monday = new DateTime(2015,  1,  4, 23, 59, 59), Sunday = new DateTime(2015,  1,  3, 23, 59, 59) },
                new { Date = new DateTime(2014, 12, 30), Monday = new DateTime(2015,  1,  4, 23, 59, 59), Sunday = new DateTime(2015,  1,  3, 23, 59, 59) },
                new { Date = new DateTime(2014, 12, 31), Monday = new DateTime(2015,  1,  4, 23, 59, 59), Sunday = new DateTime(2015,  1,  3, 23, 59, 59) },
                new { Date = new DateTime(2015,  1,  1), Monday = new DateTime(2015,  1,  4, 23, 59, 59), Sunday = new DateTime(2015,  1,  3, 23, 59, 59) },
                new { Date = new DateTime(2015,  1,  2), Monday = new DateTime(2015,  1,  4, 23, 59, 59), Sunday = new DateTime(2015,  1,  3, 23, 59, 59) },
                new { Date = new DateTime(2015,  1,  3), Monday = new DateTime(2015,  1,  4, 23, 59, 59), Sunday = new DateTime(2015,  1,  3, 23, 59, 59) },
                new { Date = new DateTime(2015,  1,  4), Monday = new DateTime(2015,  1,  4, 23, 59, 59), Sunday = new DateTime(2015,  1, 10, 23, 59, 59) }
            };

            foreach (var sample in samples) {

                Assert.AreEqual(sample.Monday, TimeHelper.GetLastDayOfWeek(sample.Date), "\n\n" + sample.Date + " (TimeHelper - implicit)");
                Assert.AreEqual(sample.Monday, sample.Date.GetLastDayOfWeek(), "\n\n" + sample.Date + " (Extension method - implicit)");

                Assert.AreEqual(sample.Monday, TimeHelper.GetLastDayOfWeek(sample.Date, DayOfWeek.Monday), "\n\n" + sample.Date + " (TimeHelper - explicit: Monday)");
                Assert.AreEqual(sample.Monday, sample.Date.GetLastDayOfWeek(DayOfWeek.Monday), "\n\n" + sample.Date + " (Extension method - explicit: Monday)");

                Assert.AreEqual(sample.Sunday, TimeHelper.GetLastDayOfWeek(sample.Date, DayOfWeek.Sunday), "\n\n" + sample.Date + " (TimeHelper - explicit: Sunday)");
                Assert.AreEqual(sample.Sunday, sample.Date.GetLastDayOfWeek(DayOfWeek.Sunday), "\n\n" + sample.Date + " (Extension method - explicit: Sunday)");

            }

        }


        #region Month name

        [TestMethod]
        public void GetMonthNameEnglish() {

            var expected = "January,February,March,April,May,June,July,August,September,October,November,December".Split(',');

            for (int i = 0; i < expected.Length; i++) {
                DateTime dt = new DateTime(2014, i + 1, 15);
                Assert.AreEqual(expected[i], TimeHelper.GetMonthName(dt));
                Assert.AreEqual(expected[i], dt.GetMonthName());
            }

        }

        [TestMethod]
        public void GetLocalMonthNameImplicit() {

            var expected = new Dictionary<string, string[]> {
                {"en-US", "January,February,March,April,May,June,July,August,September,October,November,December".Split(',')},
                {"da-DK", "januar,februar,marts,april,maj,juni,juli,august,september,oktober,november,december".Split(',')},
                {"de-DE", "Januar,Februar,März,April,Mai,Juni,Juli,August,September,Oktober,November,Dezember".Split(',')}
            };

            foreach (var sample in expected) {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(sample.Key);
                for (int i = 0; i < sample.Value.Length; i++) {
                    DateTime dt = new DateTime(2014, i + 1, 15);
                    Assert.AreEqual(sample.Value[i], TimeHelper.GetLocalMonthName(dt));
                    Assert.AreEqual(sample.Value[i], dt.GetLocalMonthName());
                }
            }

        }

        [TestMethod]
        public void GetLocalMonthNameExplicit() {

            var expected = new Dictionary<string, string[]> {
                {"en-US", "January,February,March,April,May,June,July,August,September,October,November,December".Split(',')},
                {"da-DK", "januar,februar,marts,april,maj,juni,juli,august,september,oktober,november,december".Split(',')},
                {"de-DE", "Januar,Februar,März,April,Mai,Juni,Juli,August,September,Oktober,November,Dezember".Split(',')}
            };

            foreach (var sample in expected) {
                for (int i = 0; i < sample.Value.Length; i++) {
                    DateTime dt = new DateTime(2014, i + 1, 15);
                    CultureInfo culture = new CultureInfo(sample.Key);
                    Assert.AreEqual(sample.Value[i], TimeHelper.GetLocalMonthName(dt, culture));
                    Assert.AreEqual(sample.Value[i], dt.GetLocalMonthName(culture));
                }
            }

        }

        #endregion

        #region Day name

        [TestMethod]
        public void GetDayNameEnglish() {

            var expected = "Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday".Split(',');

            DateTime start = new DateTime(2014, 11, 17);

            for (int i = 0; i < expected.Length; i++) {
                DateTime dt = start.AddDays(i);
                Assert.AreEqual(expected[i], TimeHelper.GetDayName(dt));
                Assert.AreEqual(expected[i], dt.GetDayName());
            }

        }

        [TestMethod]
        public void GetLocalDayNameImplicit() {

            var expected = new Dictionary<string, string[]> {
                {"en-US", "Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday".Split(',')},
                {"da-DK", "mandag,tirsdag,onsdag,torsdag,fredag,lørdag,søndag".Split(',')},
                {"de-DE", "Montag,Dienstag,Mittwoch,Donnerstag,Freitag,Samstag,Sonntag".Split(',')}
            };

            DateTime start = new DateTime(2014, 11, 17);

            foreach (var sample in expected) {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(sample.Key);
                for (int i = 0; i < sample.Value.Length; i++) {
                    DateTime dt = start.AddDays(i);
                    Assert.AreEqual(sample.Value[i], TimeHelper.GetLocalDayName(dt));
                    Assert.AreEqual(sample.Value[i], dt.GetLocalDayName());
                }
            }

        }

        [TestMethod]
        public void GetLocalDayNameExplicit() {

            var expected = new Dictionary<string, string[]> {
                {"en-US", "Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday".Split(',')},
                {"da-DK", "mandag,tirsdag,onsdag,torsdag,fredag,lørdag,søndag".Split(',')},
                {"de-DE", "Montag,Dienstag,Mittwoch,Donnerstag,Freitag,Samstag,Sonntag".Split(',')}
            };

            DateTime start = new DateTime(2014, 11, 17);

            foreach (var sample in expected) {
                for (int i = 0; i < sample.Value.Length; i++) {
                    DateTime dt = start.AddDays(i);
                    CultureInfo culture = new CultureInfo(sample.Key);
                    Assert.AreEqual(sample.Value[i], TimeHelper.GetLocalDayName(dt, culture));
                    Assert.AreEqual(sample.Value[i], dt.GetLocalDayName(new CultureInfo(sample.Key)));
                }
            }

        }

        #endregion

        #region RFC 822

        public void ToRfc822() {
            


        }

        #endregion

    }

}