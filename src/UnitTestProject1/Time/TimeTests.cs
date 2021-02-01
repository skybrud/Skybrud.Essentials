using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.Extensions;
using Skybrud.Essentials.Time.Iso8601;

#pragma warning disable 618

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
                Assert.AreEqual(sample.Age, TimeUtils.GetAge(sample.Date, fakeNow), "\n\n" + sample.Date + " (TimeUtils)");
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

            Assert.AreEqual("1st", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 1)));
            Assert.AreEqual("2nd", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 2)));
            Assert.AreEqual("3rd", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 3)));
            Assert.AreEqual("4th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 4)));
            Assert.AreEqual("5th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 5)));
            Assert.AreEqual("6th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 6)));
            Assert.AreEqual("7th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 7)));
            Assert.AreEqual("8th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 8)));
            Assert.AreEqual("9th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 9)));

            Assert.AreEqual("10th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 10)));
            Assert.AreEqual("11th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 11)));
            Assert.AreEqual("12th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 12)));
            Assert.AreEqual("13th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 13)));
            Assert.AreEqual("14th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 14)));
            Assert.AreEqual("15th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 15)));
            Assert.AreEqual("16th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 16)));
            Assert.AreEqual("17th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 17)));
            Assert.AreEqual("18th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 18)));
            Assert.AreEqual("19th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 19)));

            Assert.AreEqual("20th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 20)));
            Assert.AreEqual("21st", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 21)));
            Assert.AreEqual("22nd", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 22)));
            Assert.AreEqual("23rd", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 23)));
            Assert.AreEqual("24th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 24)));
            Assert.AreEqual("25th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 25)));
            Assert.AreEqual("26th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 26)));
            Assert.AreEqual("27th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 27)));
            Assert.AreEqual("28th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 28)));
            Assert.AreEqual("29th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 29)));

            Assert.AreEqual("30th", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 30)));
            Assert.AreEqual("31st", TimeUtils.GetDayNumberAndSuffix(new DateTime(2014, 1, 31)));

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

            Assert.AreEqual("st", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 1)));
            Assert.AreEqual("nd", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 2)));
            Assert.AreEqual("rd", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 3)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 4)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 5)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 6)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 7)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 8)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 9)));

            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 10)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 11)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 12)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 13)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 14)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 15)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 16)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 17)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 18)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 19)));

            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 20)));
            Assert.AreEqual("st", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 21)));
            Assert.AreEqual("nd", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 22)));
            Assert.AreEqual("rd", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 23)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 24)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 25)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 26)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 27)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 28)));
            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 29)));

            Assert.AreEqual("th", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 30)));
            Assert.AreEqual("st", TimeUtils.GetDaySuffix(new DateTime(2014, 1, 31)));

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
                Assert.AreEqual(sample.Week, TimeUtils.GetIso8601WeekNumber(sample.Date), "\n\n" + sample.Date + " (TimeUtils)");
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

            Assert.AreEqual(true, TimeUtils.IsWeekday(new DateTime(2014, 2, 10)), "\n\n (TimeUtils)");
            Assert.AreEqual(true, TimeUtils.IsWeekday(new DateTime(2014, 2, 11)), "\n\n (TimeUtils)");
            Assert.AreEqual(true, TimeUtils.IsWeekday(new DateTime(2014, 2, 12)), "\n\n (TimeUtils)");
            Assert.AreEqual(true, TimeUtils.IsWeekday(new DateTime(2014, 2, 13)), "\n\n (TimeUtils)");
            Assert.AreEqual(true, TimeUtils.IsWeekday(new DateTime(2014, 2, 14)), "\n\n (TimeUtils)");
            Assert.AreEqual(false, TimeUtils.IsWeekday(new DateTime(2014, 2, 15)), "\n\n (TimeUtils)");
            Assert.AreEqual(false, TimeUtils.IsWeekday(new DateTime(2014, 2, 16)), "\n\n (TimeUtils)");

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

            Assert.AreEqual(false, TimeUtils.IsWeekend(new DateTime(2014, 2, 10)), "\n\n (TimeUtils)");
            Assert.AreEqual(false, TimeUtils.IsWeekend(new DateTime(2014, 2, 11)), "\n\n (TimeUtils)");
            Assert.AreEqual(false, TimeUtils.IsWeekend(new DateTime(2014, 2, 12)), "\n\n (TimeUtils)");
            Assert.AreEqual(false, TimeUtils.IsWeekend(new DateTime(2014, 2, 13)), "\n\n (TimeUtils)");
            Assert.AreEqual(false, TimeUtils.IsWeekend(new DateTime(2014, 2, 14)), "\n\n (TimeUtils)");
            Assert.AreEqual(true, TimeUtils.IsWeekend(new DateTime(2014, 2, 15)), "\n\n (TimeUtils)");
            Assert.AreEqual(true, TimeUtils.IsWeekend(new DateTime(2014, 2, 16)), "\n\n (TimeUtils)");

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

                Assert.AreEqual(sample.IsLeapYear, TimeUtils.IsLeapYear(sample.Year), "\n\n" + sample.Year + " (TimeUtils)");
                Assert.AreEqual(sample.IsLeapYear, TimeUtils.IsLeapYear(dt), "\n\n" + sample.Year + " (TimeUtils)");

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
                Assert.AreEqual(sample.Expected, TimeUtils.GetFirstDayOfMonth(sample.Date), "TimeUtils");
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
                Assert.AreEqual(sample.Expected, TimeUtils.GetLastDayOfMonth(sample.Date), "TimeUtils");
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
                Assert.AreEqual(sample.Monday, TimeUtils.GetFirstDayOfWeek(sample.Date), "\n\n" + sample.Date + " (TimeUtils - implicit)");
                Assert.AreEqual(sample.Monday, sample.Date.GetFirstDayOfWeek(), "\n\n" + sample.Date + " (Extension method - implicit)");

                Assert.AreEqual(sample.Monday, TimeHelper.GetFirstDayOfWeek(sample.Date, DayOfWeek.Monday), "\n\n" + sample.Date + " (TimeHelper - explicit: Monday)");
                Assert.AreEqual(sample.Monday, TimeUtils.GetFirstDayOfWeek(sample.Date, DayOfWeek.Monday), "\n\n" + sample.Date + " (TimeUtils - explicit: Monday)");
                Assert.AreEqual(sample.Monday, sample.Date.GetFirstDayOfWeek(DayOfWeek.Monday), "\n\n" + sample.Date + " (Extension method - explicit: Monday)");

                Assert.AreEqual(sample.Sunday, TimeHelper.GetFirstDayOfWeek(sample.Date, DayOfWeek.Sunday), "\n\n" + sample.Date + " (TimeHelper - explicit: Sunday)");
                Assert.AreEqual(sample.Sunday, TimeUtils.GetFirstDayOfWeek(sample.Date, DayOfWeek.Sunday), "\n\n" + sample.Date + " (TimeUtils - explicit: Sunday)");
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
                Assert.AreEqual(sample.Monday, TimeUtils.GetLastDayOfWeek(sample.Date), "\n\n" + sample.Date + " (TimeUtils - implicit)");
                Assert.AreEqual(sample.Monday, sample.Date.GetLastDayOfWeek(), "\n\n" + sample.Date + " (Extension method - implicit)");

                Assert.AreEqual(sample.Monday, TimeHelper.GetLastDayOfWeek(sample.Date, DayOfWeek.Monday), "\n\n" + sample.Date + " (TimeHelper - explicit: Monday)");
                Assert.AreEqual(sample.Monday, TimeUtils.GetLastDayOfWeek(sample.Date, DayOfWeek.Monday), "\n\n" + sample.Date + " (TimeUtils - explicit: Monday)");
                Assert.AreEqual(sample.Monday, sample.Date.GetLastDayOfWeek(DayOfWeek.Monday), "\n\n" + sample.Date + " (Extension method - explicit: Monday)");

                Assert.AreEqual(sample.Sunday, TimeHelper.GetLastDayOfWeek(sample.Date, DayOfWeek.Sunday), "\n\n" + sample.Date + " (TimeHelper - explicit: Sunday)");
                Assert.AreEqual(sample.Sunday, TimeUtils.GetLastDayOfWeek(sample.Date, DayOfWeek.Sunday), "\n\n" + sample.Date + " (TimeUtils - explicit: Sunday)");
                Assert.AreEqual(sample.Sunday, sample.Date.GetLastDayOfWeek(DayOfWeek.Sunday), "\n\n" + sample.Date + " (Extension method - explicit: Sunday)");

            }

        }

        #region Month name

        [TestMethod]
        public void GetMonthNameEnglish() {

            var expected = "January,February,March,April,May,June,July,August,September,October,November,December".Split(',');

            for (int i = 0; i < expected.Length; i++) {
                
                DateTime dt = new DateTime(2014, i + 1, 15);

                DateTimeOffset dto = dt;

                EssentialsTime time = new EssentialsTime(dt);

                Assert.AreEqual(expected[i], TimeUtils.GetMonthName(dt.Month));

                Assert.AreEqual(expected[i], TimeHelper.GetMonthName(dt));

                Assert.AreEqual(expected[i], TimeUtils.GetMonthName(dt));
                
                Assert.AreEqual(expected[i], dt.GetMonthName());

                Assert.AreEqual(expected[i], TimeUtils.GetMonthName(dto));

                Assert.AreEqual(expected[i], dto.GetMonthName());

                Assert.AreEqual(expected[i], time.MonthName);

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

                    DateTimeOffset dto = dt;

                    EssentialsTime time = new EssentialsTime(dt);

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetLocalMonthName(dt.Month));

                    Assert.AreEqual(sample.Value[i], TimeHelper.GetLocalMonthName(dt));

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetLocalMonthName(dt));

                    Assert.AreEqual(sample.Value[i], dt.GetLocalMonthName());

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetLocalMonthName(dto));

                    Assert.AreEqual(sample.Value[i], dto.GetLocalMonthName());

                    Assert.AreEqual(sample.Value[i], time.LocalMonthName);

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

                    DateTimeOffset dto = dt;

                    CultureInfo culture = new CultureInfo(sample.Key);

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetLocalMonthName(dt.Month, culture));

                    Assert.AreEqual(sample.Value[i], TimeHelper.GetLocalMonthName(dt, culture));

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetLocalMonthName(dt, culture));

                    Assert.AreEqual(sample.Value[i], dt.GetLocalMonthName(culture));

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetLocalMonthName(dto, culture));

                    Assert.AreEqual(sample.Value[i], dto.GetLocalMonthName(culture));

                }

            }

        }
        
        [TestMethod]
        public void GetAbbreviatedMonthNameEnglish() {

            var expected = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec".Split(',');

            for (int i = 0; i < expected.Length; i++) {
                
                DateTime dt = new DateTime(2014, i + 1, 15);

                DateTimeOffset dto = dt;

                EssentialsTime time = new EssentialsTime(dt);

                Assert.AreEqual(expected[i], TimeUtils.GetAbbreviatedMonthName(dt.Month));

                Assert.AreEqual(expected[i], TimeUtils.GetAbbreviatedMonthName(dt));

                Assert.AreEqual(expected[i], dt.GetAbbreviatedMonthName());

                Assert.AreEqual(expected[i], TimeUtils.GetAbbreviatedMonthName(dto));

                Assert.AreEqual(expected[i], dto.GetAbbreviatedMonthName());

                Assert.AreEqual(expected[i], time.AbbreviatedMonthName);

            }

        }

        [TestMethod]
        public void GetAbbreviatedLocalMonthNameImplicit() {

            var expected = new Dictionary<string, string[]> {
                {"en-US", "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec".Split(',')},
                {"da-DK", "jan,feb,mar,apr,maj,jun,jul,aug,sep,okt,nov,dec".Split(',')},
                {"de-DE", "Jan,Feb,Mrz,Apr,Mai,Jun,Jul,Aug,Sep,Okt,Nov,Dez".Split(',')}
            };

            foreach (var sample in expected) {
                
                Thread.CurrentThread.CurrentCulture = new CultureInfo(sample.Key);
                
                for (int i = 0; i < sample.Value.Length; i++) {
                    
                    DateTime dt = new DateTime(2014, i + 1, 15);

                    DateTimeOffset dto = dt;

                    EssentialsTime time = new EssentialsTime(dt);

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetAbbreviatedLocalMonthName(dt.Month));

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetAbbreviatedLocalMonthName(dt));

                    Assert.AreEqual(sample.Value[i], dt.GetAbbreviatedLocalMonthName());

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetAbbreviatedLocalMonthName(dto));

                    Assert.AreEqual(sample.Value[i], dto.GetAbbreviatedLocalMonthName());

                    Assert.AreEqual(sample.Value[i], time.AbbreviatedLocalMonthName);

                }

            }

        }

        [TestMethod]
        public void GetAbbreviatedLocalMonthNameExplicit() {

            var expected = new Dictionary<string, string[]> {
                {"en-US", "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec".Split(',')},
                {"da-DK", "jan,feb,mar,apr,maj,jun,jul,aug,sep,okt,nov,dec".Split(',')},
                {"de-DE", "Jan,Feb,Mrz,Apr,Mai,Jun,Jul,Aug,Sep,Okt,Nov,Dez".Split(',')}
            };

            foreach (var sample in expected) {
                
                for (int i = 0; i < sample.Value.Length; i++) {

                    CultureInfo culture = new CultureInfo(sample.Key);
                    
                    DateTime dt = new DateTime(2014, i + 1, 15);

                    DateTimeOffset dto = dt;

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetAbbreviatedLocalMonthName(dt.Month, culture));

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetAbbreviatedLocalMonthName(dt, culture));

                    Assert.AreEqual(sample.Value[i], dt.GetAbbreviatedLocalMonthName(culture));

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetAbbreviatedLocalMonthName(dto, culture));

                    Assert.AreEqual(sample.Value[i], dto.GetAbbreviatedLocalMonthName(culture));

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

                DateTimeOffset dto = dt;

                EssentialsTime time = new EssentialsTime(dt);

                Assert.AreEqual(expected[i], TimeUtils.GetDayName(dt.DayOfWeek));

                Assert.AreEqual(expected[i], TimeHelper.GetDayName(dt));

                Assert.AreEqual(expected[i], TimeUtils.GetDayName(dt));

                Assert.AreEqual(expected[i], dt.GetDayName());

                Assert.AreEqual(expected[i], TimeUtils.GetDayName(dto));

                Assert.AreEqual(expected[i], dto.GetDayName());

                Assert.AreEqual(expected[i], time.DayName);

            }

        }

        [TestMethod]
        public void GetAbbreviatedDayNameEnglish() {

            var expected = "Mon,Tue,Wed,Thu,Fri,Sat,Sun".Split(',');

            DateTime start = new DateTime(2014, 11, 17);

            for (int i = 0; i < expected.Length; i++) {
                
                DateTime dt = start.AddDays(i);

                DateTimeOffset dto = dt;

                EssentialsTime time = new EssentialsTime(dt);

                Assert.AreEqual(expected[i], TimeUtils.GetAbbreviatedDayName(dt.DayOfWeek), "#1");

                Assert.AreEqual(expected[i], TimeUtils.GetAbbreviatedDayName(dt), "#2");

                Assert.AreEqual(expected[i], dt.GetAbbreviatedDayName(), "#3");

                Assert.AreEqual(expected[i], TimeUtils.GetAbbreviatedDayName(dto), "#4");

                Assert.AreEqual(expected[i], dto.GetAbbreviatedDayName(), "#5");

                Assert.AreEqual(expected[i], time.AbbreviatedDayName, "#6");

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

                    DateTimeOffset dto = dt;

                    EssentialsTime time = new EssentialsTime(dt);

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetLocalDayName(dt.DayOfWeek), "#1");

                    Assert.AreEqual(sample.Value[i], TimeHelper.GetLocalDayName(dt), "#2");
                    
                    Assert.AreEqual(sample.Value[i], TimeUtils.GetLocalDayName(dt), "#3");

                    Assert.AreEqual(sample.Value[i], dt.GetLocalDayName(), "#4");

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetLocalDayName(dto), "#5");

                    Assert.AreEqual(sample.Value[i], dto.GetLocalDayName(), "#6");

                    Assert.AreEqual(sample.Value[i], time.LocalDayName);

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

                    DateTimeOffset dto = dt;

                    CultureInfo culture = new CultureInfo(sample.Key);

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetLocalDayName(dt.DayOfWeek, culture));

                    Assert.AreEqual(sample.Value[i], TimeHelper.GetLocalDayName(dt, culture));
                    
                    Assert.AreEqual(sample.Value[i], TimeUtils.GetLocalDayName(dt, culture));

                    Assert.AreEqual(sample.Value[i], dt.GetLocalDayName(new CultureInfo(sample.Key)));

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetLocalDayName(dto, culture));

                    Assert.AreEqual(sample.Value[i], dto.GetLocalDayName(new CultureInfo(sample.Key)));

                }

            }

        }

        [TestMethod]
        public void GetAbbreviatedLocalDayNameImplicit() {

            var expected = new Dictionary<string, string[]> {
                {"en-US", "Mon,Tue,Wed,Thu,Fri,Sat,Sun".Split(',')},
                {"da-DK", "ma,ti,on,to,fr,lø,sø".Split(',')},
                {"de-DE", "Mo,Di,Mi,Do,Fr,Sa,So".Split(',')}
            };

            DateTime start = new DateTime(2014, 11, 17);

            foreach (var sample in expected) {
                
                Thread.CurrentThread.CurrentCulture = new CultureInfo(sample.Key);
                
                for (int i = 0; i < sample.Value.Length; i++) {
                    
                    DateTime dt = start.AddDays(i);

                    DateTimeOffset dto = dt;

                    EssentialsTime time = new EssentialsTime(dt);

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetAbbreviatedLocalDayName(dt.DayOfWeek));

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetAbbreviatedLocalDayName(dt));

                    Assert.AreEqual(sample.Value[i], dt.GetAbbreviatedLocalDayName());

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetAbbreviatedLocalDayName(dto));

                    Assert.AreEqual(sample.Value[i], dto.GetAbbreviatedLocalDayName());

                    Assert.AreEqual(sample.Value[i], time.AbbreviatedLocalDayName);

                }

            }

        }

        [TestMethod]
        public void GetAbbreviatedLocalDayNameExplicit() {

            var expected = new Dictionary<string, string[]> {
                {"en-US", "Mon,Tue,Wed,Thu,Fri,Sat,Sun".Split(',')},
                {"da-DK", "ma,ti,on,to,fr,lø,sø".Split(',')},
                {"de-DE", "Mo,Di,Mi,Do,Fr,Sa,So".Split(',')}
            };

            DateTime start = new DateTime(2014, 11, 17);

            foreach (var sample in expected) {
                
                for (int i = 0; i < sample.Value.Length; i++) {
                    
                    DateTime dt = start.AddDays(i);

                    DateTimeOffset dto = dt;

                    CultureInfo culture = new CultureInfo(sample.Key);

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetAbbreviatedLocalDayName(dt.DayOfWeek, culture));

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetAbbreviatedLocalDayName(dt, culture));

                    Assert.AreEqual(sample.Value[i], dt.GetAbbreviatedLocalDayName(culture));

                    Assert.AreEqual(sample.Value[i], TimeUtils.GetAbbreviatedLocalDayName(dto, culture));

                    Assert.AreEqual(sample.Value[i], dto.GetAbbreviatedLocalDayName(culture));

                }

            }

        }

        #endregion

        #region EssentialsPartialDate

        [TestMethod]
        public void EssentialsPartialDateFromDateTime() {

            var samples = new[] {
                new { Date = new DateTime(2014, 12, 29) },
                new { Date = new DateTime(2014, 12, 30) },
                new { Date = new DateTime(2014, 12, 31) },
                new { Date = new DateTime(2015,  1,  1) },
                new { Date = new DateTime(2015,  1,  2) },
                new { Date = new DateTime(2015,  1,  3) },
                new { Date = new DateTime(2015,  1,  4) }
            };

            foreach (var sample in samples) {
                EssentialsPartialDate partial = sample.Date;
                Assert.AreEqual(sample.Date.Year, partial.Year);
                Assert.AreEqual(sample.Date.Month, partial.Month);
                Assert.AreEqual(sample.Date.Day, partial.Day);
            }

        }

        [TestMethod]
        public void EssentialsPartialDateFromDateTimeOffset() {

            var samples = new[] {
                new { Date = new DateTimeOffset(2014, 12, 29, 0, 0, 0, TimeSpan.FromHours(0)) },
                new { Date = new DateTimeOffset(2014, 12, 30, 0, 0, 0, TimeSpan.FromHours(0)) },
                new { Date = new DateTimeOffset(2014, 12, 31, 0, 0, 0, TimeSpan.FromHours(0)) },
                new { Date = new DateTimeOffset(2015,  1,  1, 0, 0, 0, TimeSpan.FromHours(0)) },
                new { Date = new DateTimeOffset(2015,  1,  2, 0, 0, 0, TimeSpan.FromHours(0)) },
                new { Date = new DateTimeOffset(2015,  1,  3, 0, 0, 0, TimeSpan.FromHours(0)) },
                new { Date = new DateTimeOffset(2015,  1,  4, 0, 0, 0, TimeSpan.FromHours(0)) },
                new { Date = new DateTimeOffset(2014, 12, 29, 0, 0, 0, TimeSpan.FromHours(1)) },
                new { Date = new DateTimeOffset(2014, 12, 30, 0, 0, 0, TimeSpan.FromHours(2)) },
                new { Date = new DateTimeOffset(2014, 12, 31, 0, 0, 0, TimeSpan.FromHours(3)) },
                new { Date = new DateTimeOffset(2015,  1,  1, 0, 0, 0, TimeSpan.FromHours(4)) },
                new { Date = new DateTimeOffset(2015,  1,  2, 0, 0, 0, TimeSpan.FromHours(5)) },
                new { Date = new DateTimeOffset(2015,  1,  3, 0, 0, 0, TimeSpan.FromHours(6)) },
                new { Date = new DateTimeOffset(2015,  1,  4, 0, 0, 0, TimeSpan.FromHours(7)) }
            };

            foreach (var sample in samples) {
                EssentialsPartialDate partial = sample.Date;
                Assert.AreEqual(sample.Date.Year, partial.Year);
                Assert.AreEqual(sample.Date.Month, partial.Month);
                Assert.AreEqual(sample.Date.Day, partial.Day);
            }

        }

        [TestMethod]
        public void EssentialsPartialDateFromEssentialsDateTime() {

            var samples = new[] {
                new { Date = new EssentialsDateTime(2014, 12, 29) },
                new { Date = new EssentialsDateTime(2014, 12, 30) },
                new { Date = new EssentialsDateTime(2014, 12, 31) },
                new { Date = new EssentialsDateTime(2015,  1,  1) },
                new { Date = new EssentialsDateTime(2015,  1,  2) },
                new { Date = new EssentialsDateTime(2015,  1,  3) },
                new { Date = new EssentialsDateTime(2015,  1,  4) }
            };

            foreach (var sample in samples) {
                EssentialsPartialDate partial = sample.Date;
                Assert.AreEqual(sample.Date.Year, partial.Year);
                Assert.AreEqual(sample.Date.Month, partial.Month);
                Assert.AreEqual(sample.Date.Day, partial.Day);
            }

        }

        [TestMethod]
        public void EssentialsPartialDateFromString() {

            CultureInfo danish = new CultureInfo("da-DK");

            var samples = new[] {

                new { Expected = "2017-08-00", Input = "august 2017", CultureInfo = CultureInfo.InvariantCulture },
                new { Expected = "2017-08-00", Input = "August, 2017", CultureInfo = CultureInfo.InvariantCulture },
                new { Expected = "2017-08-17", Input = "17 August, 2017", CultureInfo = CultureInfo.InvariantCulture },
                new { Expected = "2017-08-17", Input = "August 17, 2017", CultureInfo = CultureInfo.InvariantCulture },
                new { Expected = "2017-08-17", Input = "August 17th, 2017", CultureInfo = CultureInfo.InvariantCulture },

                new { Expected = "2018-01-00", Input = "january 2018", CultureInfo = CultureInfo.InvariantCulture },
                new { Expected = "2018-01-00", Input = "January 2018", CultureInfo = CultureInfo.InvariantCulture },
                new { Expected = "2018-01-00", Input = "January, 2018", CultureInfo = CultureInfo.InvariantCulture },
                new { Expected = "2018-01-00", Input = "january, 2018", CultureInfo = CultureInfo.InvariantCulture },
                new { Expected = "2018-01-01", Input = "1 January, 2018", CultureInfo = CultureInfo.InvariantCulture },
                new { Expected = "2018-01-01", Input = "1 january, 2018", CultureInfo = CultureInfo.InvariantCulture },
                new { Expected = "2018-01-01", Input = "January 1, 2018", CultureInfo = CultureInfo.InvariantCulture },
                new { Expected = "2018-01-01", Input = "january 1, 2018", CultureInfo = CultureInfo.InvariantCulture },
                new { Expected = "2018-01-01", Input = "January 1st, 2018", CultureInfo = CultureInfo.InvariantCulture },
                new { Expected = "2018-01-01", Input = "january 1st, 2018", CultureInfo = CultureInfo.InvariantCulture },

                new { Expected = "2018-01-00", Input = "januar 2018", CultureInfo = danish },
                new { Expected = "2018-01-00", Input = "Januar 2018", CultureInfo = danish },
                new { Expected = "2018-01-00", Input = "Januar, 2018", CultureInfo = danish },
                new { Expected = "2018-01-00", Input = "januar, 2018", CultureInfo = danish },
                new { Expected = "2018-01-01", Input = "1 Januar, 2018", CultureInfo = danish },
                new { Expected = "2018-01-01", Input = "1 januar, 2018", CultureInfo = danish },
                new { Expected = "2018-01-01", Input = "Januar 1, 2018", CultureInfo = danish },
                new { Expected = "2018-01-01", Input = "januar 1, 2018", CultureInfo = danish },
                new { Expected = "2018-01-01", Input = "Januar 1st, 2018", CultureInfo = danish },
                new { Expected = "2018-01-01", Input = "januar 1st, 2018", CultureInfo = danish }

            };

            foreach (var sample in samples) {
                EssentialsPartialDate partial = EssentialsPartialDate.Parse(sample.Input, sample.CultureInfo);
                Assert.AreEqual(sample.Expected, partial.ToString());
            }

        }


        [TestMethod]
        public void TryParseNumberFromMonthName() {

            CultureInfo danish = new CultureInfo("da-DK");

            var samples1 = new[] {
                new { Input = "January", Expected = true, Result = 1 },
                new { Input = "january", Expected = true, Result = 1 },
                new { Input = "February", Expected = true, Result = 2 },
                new { Input = "february", Expected = true, Result = 2 },
                new { Input = "March", Expected = true, Result = 3 },
                new { Input = "march", Expected = true, Result = 3 },
                new { Input = "April", Expected = true, Result = 4 },
                new { Input = "april", Expected = true, Result = 4 },
                new { Input = "May", Expected = true, Result = 5 },
                new { Input = "may", Expected = true, Result = 5 },
                new { Input = "June", Expected = true, Result = 6 },
                new { Input = "june", Expected = true, Result = 6 },
                new { Input = "July", Expected = true, Result = 7 },
                new { Input = "july", Expected = true, Result = 7 },
                new { Input = "August", Expected = true, Result = 8 },
                new { Input = "august", Expected = true, Result = 8 },
                new { Input = "September", Expected = true, Result = 9 },
                new { Input = "september", Expected = true, Result = 9 },
                new { Input = "October", Expected = true, Result = 10 },
                new { Input = "october", Expected = true, Result = 10 },
                new { Input = "November", Expected = true, Result = 11 },
                new { Input = "november", Expected = true, Result = 11 },
                new { Input = "December", Expected = true, Result = 12 },
                new { Input = "december", Expected = true, Result = 12 },
            };

            var samplesDanish = new[] {
                new { Input = "Januar", Expected = true, Result = 1 },
                new { Input = "januar", Expected = true, Result = 1 },
                new { Input = "Februar", Expected = true, Result = 2 },
                new { Input = "februar", Expected = true, Result = 2 },
                new { Input = "Marts", Expected = true, Result = 3 },
                new { Input = "marts", Expected = true, Result = 3 },
                new { Input = "April", Expected = true, Result = 4 },
                new { Input = "april", Expected = true, Result = 4 },
                new { Input = "Maj", Expected = true, Result = 5 },
                new { Input = "maj", Expected = true, Result = 5 },
                new { Input = "Juni", Expected = true, Result = 6 },
                new { Input = "juni", Expected = true, Result = 6 },
                new { Input = "Juli", Expected = true, Result = 7 },
                new { Input = "juli", Expected = true, Result = 7 },
                new { Input = "August", Expected = true, Result = 8 },
                new { Input = "august", Expected = true, Result = 8 },
                new { Input = "September", Expected = true, Result = 9 },
                new { Input = "september", Expected = true, Result = 9 },
                new { Input = "Oktober", Expected = true, Result = 10 },
                new { Input = "oktober", Expected = true, Result = 10 },
                new { Input = "November", Expected = true, Result = 11 },
                new { Input = "november", Expected = true, Result = 11 },
                new { Input = "December", Expected = true, Result = 12 },
                new { Input = "december", Expected = true, Result = 12 }
            };

            foreach (var sample in samples1) {
                bool expected = TimeUtils.TryParseNumberFromMonthName(sample.Input, out int result);
                Assert.AreEqual(sample.Expected, expected, sample.Input);
                Assert.AreEqual(sample.Result, result, sample.Input);
            }

            foreach (var sample in samplesDanish) {
                bool expected = TimeUtils.TryParseNumberFromMonthName(sample.Input, danish, out int result);
                Assert.AreEqual(sample.Expected, expected, sample.Input);
                Assert.AreEqual(sample.Result, result, sample.Input);
            }

        }

        [TestMethod]
        public void ParseEnumFromMonthName() {

            CultureInfo danish = new CultureInfo("da-DK");

            var samples1 = new [] {
                new { Input = "January", Expected = EssentialsDateMonthName.January },
                new { Input = "january", Expected = EssentialsDateMonthName.January },
                new { Input = "February", Expected = EssentialsDateMonthName.February },
                new { Input = "february", Expected = EssentialsDateMonthName.February },
                new { Input = "March", Expected = EssentialsDateMonthName.March },
                new { Input = "march", Expected = EssentialsDateMonthName.March },
                new { Input = "April", Expected = EssentialsDateMonthName.April },
                new { Input = "april", Expected = EssentialsDateMonthName.April },
                new { Input = "May", Expected = EssentialsDateMonthName.May },
                new { Input = "may", Expected = EssentialsDateMonthName.May },
                new { Input = "June", Expected = EssentialsDateMonthName.June },
                new { Input = "june", Expected = EssentialsDateMonthName.June },
                new { Input = "July", Expected = EssentialsDateMonthName.July },
                new { Input = "july", Expected = EssentialsDateMonthName.July },
                new { Input = "August", Expected = EssentialsDateMonthName.August },
                new { Input = "august", Expected = EssentialsDateMonthName.August },
                new { Input = "September", Expected = EssentialsDateMonthName.September },
                new { Input = "september", Expected = EssentialsDateMonthName.September },
                new { Input = "October", Expected = EssentialsDateMonthName.October },
                new { Input = "october", Expected = EssentialsDateMonthName.October },
                new { Input = "November", Expected = EssentialsDateMonthName.November },
                new { Input = "november", Expected = EssentialsDateMonthName.November },
                new { Input = "December", Expected = EssentialsDateMonthName.December },
                new { Input = "december", Expected = EssentialsDateMonthName.December }
            };

            var samplesDanish = new[] {
                new { Input = "Januar", Expected = EssentialsDateMonthName.January },
                new { Input = "januar", Expected = EssentialsDateMonthName.January },
                new { Input = "Februar", Expected = EssentialsDateMonthName.February },
                new { Input = "februar", Expected = EssentialsDateMonthName.February },
                new { Input = "Marts", Expected = EssentialsDateMonthName.March },
                new { Input = "marts", Expected = EssentialsDateMonthName.March },
                new { Input = "April", Expected = EssentialsDateMonthName.April },
                new { Input = "april", Expected = EssentialsDateMonthName.April },
                new { Input = "Maj", Expected = EssentialsDateMonthName.May },
                new { Input = "maj", Expected = EssentialsDateMonthName.May },
                new { Input = "Juni", Expected = EssentialsDateMonthName.June },
                new { Input = "juni", Expected = EssentialsDateMonthName.June },
                new { Input = "Juli", Expected = EssentialsDateMonthName.July },
                new { Input = "juli", Expected = EssentialsDateMonthName.July },
                new { Input = "August", Expected = EssentialsDateMonthName.August },
                new { Input = "august", Expected = EssentialsDateMonthName.August },
                new { Input = "September", Expected = EssentialsDateMonthName.September },
                new { Input = "september", Expected = EssentialsDateMonthName.September },
                new { Input = "Oktober", Expected = EssentialsDateMonthName.October },
                new { Input = "oktober", Expected = EssentialsDateMonthName.October },
                new { Input = "November", Expected = EssentialsDateMonthName.November },
                new { Input = "november", Expected = EssentialsDateMonthName.November },
                new { Input = "December", Expected = EssentialsDateMonthName.December },
                new { Input = "december", Expected = EssentialsDateMonthName.December }
            };

            foreach (var sample in samples1) {
                EssentialsDateMonthName month = TimeUtils.ParseEnumFromMonthName(sample.Input);
                Assert.AreEqual(sample.Expected, month);
            }

            foreach (var sample in samplesDanish) {
                EssentialsDateMonthName month = TimeUtils.ParseEnumFromMonthName(sample.Input, danish);
                Assert.AreEqual(sample.Expected, month);
            }


        }

        [TestMethod]
        public void TryParseEnumFromMonthName() {

            CultureInfo danish = new CultureInfo("da-DK");

            var samples1 = new[] {
                new { Input = "January", Expected = true, Result = EssentialsDateMonthName.January },
                new { Input = "january", Expected = true, Result = EssentialsDateMonthName.January },
                new { Input = "February", Expected = true, Result = EssentialsDateMonthName.February },
                new { Input = "february", Expected = true, Result = EssentialsDateMonthName.February },
                new { Input = "March", Expected = true, Result = EssentialsDateMonthName.March },
                new { Input = "march", Expected = true, Result = EssentialsDateMonthName.March },
                new { Input = "April", Expected = true, Result = EssentialsDateMonthName.April },
                new { Input = "april", Expected = true, Result = EssentialsDateMonthName.April },
                new { Input = "May", Expected = true, Result = EssentialsDateMonthName.May },
                new { Input = "may", Expected = true, Result = EssentialsDateMonthName.May },
                new { Input = "June", Expected = true, Result = EssentialsDateMonthName.June },
                new { Input = "june", Expected = true, Result = EssentialsDateMonthName.June },
                new { Input = "July", Expected = true, Result = EssentialsDateMonthName.July },
                new { Input = "july", Expected = true, Result = EssentialsDateMonthName.July },
                new { Input = "August", Expected = true, Result = EssentialsDateMonthName.August },
                new { Input = "august", Expected = true, Result = EssentialsDateMonthName.August },
                new { Input = "September", Expected = true, Result = EssentialsDateMonthName.September },
                new { Input = "september", Expected = true, Result = EssentialsDateMonthName.September },
                new { Input = "October", Expected = true, Result = EssentialsDateMonthName.October },
                new { Input = "october", Expected = true, Result = EssentialsDateMonthName.October },
                new { Input = "November", Expected = true, Result = EssentialsDateMonthName.November },
                new { Input = "november", Expected = true, Result = EssentialsDateMonthName.November },
                new { Input = "December", Expected = true, Result = EssentialsDateMonthName.December },
                new { Input = "december", Expected = true, Result = EssentialsDateMonthName.December }
            };

            var samplesDanish = new[] {
                new { Input = "Januar", Expected = true, Result = EssentialsDateMonthName.January },
                new { Input = "januar", Expected = true, Result = EssentialsDateMonthName.January },
                new { Input = "Februar", Expected = true, Result = EssentialsDateMonthName.February },
                new { Input = "februar", Expected = true, Result = EssentialsDateMonthName.February },
                new { Input = "Marts", Expected = true, Result = EssentialsDateMonthName.March },
                new { Input = "marts", Expected = true, Result = EssentialsDateMonthName.March },
                new { Input = "April", Expected = true, Result = EssentialsDateMonthName.April },
                new { Input = "april", Expected = true, Result = EssentialsDateMonthName.April },
                new { Input = "Maj", Expected = true, Result = EssentialsDateMonthName.May },
                new { Input = "maj", Expected = true, Result = EssentialsDateMonthName.May },
                new { Input = "Juni", Expected = true, Result = EssentialsDateMonthName.June },
                new { Input = "juni", Expected = true, Result = EssentialsDateMonthName.June },
                new { Input = "Juli", Expected = true, Result = EssentialsDateMonthName.July },
                new { Input = "juli", Expected = true, Result = EssentialsDateMonthName.July },
                new { Input = "August", Expected = true, Result = EssentialsDateMonthName.August },
                new { Input = "august", Expected = true, Result = EssentialsDateMonthName.August },
                new { Input = "September", Expected = true, Result = EssentialsDateMonthName.September },
                new { Input = "september", Expected = true, Result = EssentialsDateMonthName.September },
                new { Input = "Oktober", Expected = true, Result = EssentialsDateMonthName.October },
                new { Input = "oktober", Expected = true, Result = EssentialsDateMonthName.October },
                new { Input = "November", Expected = true, Result = EssentialsDateMonthName.November },
                new { Input = "november", Expected = true, Result = EssentialsDateMonthName.November },
                new { Input = "December", Expected = true, Result = EssentialsDateMonthName.December },
                new { Input = "december", Expected = true, Result = EssentialsDateMonthName.December }
            };

            foreach (var sample in samples1) {
                bool expected = TimeUtils.TryParseEnumFromMonthName(sample.Input, out EssentialsDateMonthName result);
                Assert.AreEqual(sample.Expected, expected);
                Assert.AreEqual(sample.Result, result);
            }

            foreach (var sample in samplesDanish) {
                bool expected = TimeUtils.TryParseEnumFromMonthName(sample.Input, danish, out EssentialsDateMonthName result);
                Assert.AreEqual(sample.Expected, expected);
                Assert.AreEqual(sample.Result, result);
            }

        }

        #endregion

        [TestMethod]
        public void GetIso8601Year() {

            // Week 52, 2016
            Assert.AreEqual(2016, Iso8601Utils.GetYear(new DateTime(2016, 12, 26)));
            Assert.AreEqual(2016, Iso8601Utils.GetYear(new DateTime(2016, 12, 27)));
            Assert.AreEqual(2016, Iso8601Utils.GetYear(new DateTime(2016, 12, 28)));
            Assert.AreEqual(2016, Iso8601Utils.GetYear(new DateTime(2016, 12, 29)));
            Assert.AreEqual(2016, Iso8601Utils.GetYear(new DateTime(2016, 12, 30)));
            Assert.AreEqual(2016, Iso8601Utils.GetYear(new DateTime(2016, 12, 31)));
            Assert.AreEqual(2016, Iso8601Utils.GetYear(new DateTime(2017, 1, 1)));

            // Week 1, 2017
            Assert.AreEqual(2017, Iso8601Utils.GetYear(new DateTime(2017, 1, 2)));
            Assert.AreEqual(2017, Iso8601Utils.GetYear(new DateTime(2017, 1, 3)));
            Assert.AreEqual(2017, Iso8601Utils.GetYear(new DateTime(2017, 1, 4)));
            Assert.AreEqual(2017, Iso8601Utils.GetYear(new DateTime(2017, 1, 5)));
            Assert.AreEqual(2017, Iso8601Utils.GetYear(new DateTime(2017, 1, 6)));
            Assert.AreEqual(2017, Iso8601Utils.GetYear(new DateTime(2017, 1, 7)));
            Assert.AreEqual(2017, Iso8601Utils.GetYear(new DateTime(2017, 1, 8)));

            // Week 52, 2017
            Assert.AreEqual(2017, Iso8601Utils.GetYear(new DateTime(2017, 12, 25)));
            Assert.AreEqual(2017, Iso8601Utils.GetYear(new DateTime(2017, 12, 26)));
            Assert.AreEqual(2017, Iso8601Utils.GetYear(new DateTime(2017, 12, 27)));
            Assert.AreEqual(2017, Iso8601Utils.GetYear(new DateTime(2017, 12, 28)));
            Assert.AreEqual(2017, Iso8601Utils.GetYear(new DateTime(2017, 12, 29)));
            Assert.AreEqual(2017, Iso8601Utils.GetYear(new DateTime(2017, 12, 30)));
            Assert.AreEqual(2017, Iso8601Utils.GetYear(new DateTime(2017, 12, 31)));

            // Week 1, 2018
            Assert.AreEqual(2018, Iso8601Utils.GetYear(new DateTime(2018, 1, 1)));
            Assert.AreEqual(2018, Iso8601Utils.GetYear(new DateTime(2018, 1, 2)));
            Assert.AreEqual(2018, Iso8601Utils.GetYear(new DateTime(2018, 1, 3)));
            Assert.AreEqual(2018, Iso8601Utils.GetYear(new DateTime(2018, 1, 4)));
            Assert.AreEqual(2018, Iso8601Utils.GetYear(new DateTime(2018, 1, 5)));
            Assert.AreEqual(2018, Iso8601Utils.GetYear(new DateTime(2018, 1, 6)));
            Assert.AreEqual(2018, Iso8601Utils.GetYear(new DateTime(2018, 1, 7)));

            // Week 52, 2018
            Assert.AreEqual(2018, Iso8601Utils.GetYear(new DateTime(2018, 12, 24)));
            Assert.AreEqual(2018, Iso8601Utils.GetYear(new DateTime(2018, 12, 25)));
            Assert.AreEqual(2018, Iso8601Utils.GetYear(new DateTime(2018, 12, 26)));
            Assert.AreEqual(2018, Iso8601Utils.GetYear(new DateTime(2018, 12, 27)));
            Assert.AreEqual(2018, Iso8601Utils.GetYear(new DateTime(2018, 12, 28)));
            Assert.AreEqual(2018, Iso8601Utils.GetYear(new DateTime(2018, 12, 29)));
            Assert.AreEqual(2018, Iso8601Utils.GetYear(new DateTime(2018, 12, 30)));
            
            // Week 1, 2019
            Assert.AreEqual(2019, Iso8601Utils.GetYear(new DateTime(2018, 12, 31)));
            Assert.AreEqual(2019, Iso8601Utils.GetYear(new DateTime(2019, 1, 1)));
            Assert.AreEqual(2019, Iso8601Utils.GetYear(new DateTime(2019, 1, 2)));
            Assert.AreEqual(2019, Iso8601Utils.GetYear(new DateTime(2019, 1, 3)));
            Assert.AreEqual(2019, Iso8601Utils.GetYear(new DateTime(2019, 1, 4)));
            Assert.AreEqual(2019, Iso8601Utils.GetYear(new DateTime(2019, 1, 5)));
            Assert.AreEqual(2019, Iso8601Utils.GetYear(new DateTime(2019, 1, 6)));

            // Week 52, 2019
            Assert.AreEqual(2019, Iso8601Utils.GetYear(new DateTime(2019, 12, 23)));
            Assert.AreEqual(2019, Iso8601Utils.GetYear(new DateTime(2019, 12, 24)));
            Assert.AreEqual(2019, Iso8601Utils.GetYear(new DateTime(2019, 12, 25)));
            Assert.AreEqual(2019, Iso8601Utils.GetYear(new DateTime(2019, 12, 26)));
            Assert.AreEqual(2019, Iso8601Utils.GetYear(new DateTime(2019, 12, 27)));
            Assert.AreEqual(2019, Iso8601Utils.GetYear(new DateTime(2019, 12, 28)));
            Assert.AreEqual(2019, Iso8601Utils.GetYear(new DateTime(2019, 12, 29)));

            // Week 1, 2020
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2019, 12, 30)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2019, 12, 31)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2020, 1, 1)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2020, 1, 2)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2020, 1, 3)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2020, 1, 4)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2020, 1, 5)));

            // Week 52, 2020
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2020, 12, 21)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2020, 12, 22)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2020, 12, 23)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2020, 12, 24)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2020, 12, 25)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2020, 12, 26)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2020, 12, 27)));

            // Week 53, 2020
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2020, 12, 28)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2020, 12, 29)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2020, 12, 30)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2020, 12, 31)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2021, 1, 1)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2021, 1, 2)));
            Assert.AreEqual(2020, Iso8601Utils.GetYear(new DateTime(2021, 1, 3)));

            // Week 1, 2021
            Assert.AreEqual(2021, Iso8601Utils.GetYear(new DateTime(2021, 1, 4)));
            Assert.AreEqual(2021, Iso8601Utils.GetYear(new DateTime(2021, 1, 5)));
            Assert.AreEqual(2021, Iso8601Utils.GetYear(new DateTime(2021, 1, 6)));
            Assert.AreEqual(2021, Iso8601Utils.GetYear(new DateTime(2021, 1, 7)));
            Assert.AreEqual(2021, Iso8601Utils.GetYear(new DateTime(2021, 1, 8)));
            Assert.AreEqual(2021, Iso8601Utils.GetYear(new DateTime(2021, 1, 9)));
            Assert.AreEqual(2021, Iso8601Utils.GetYear(new DateTime(2021, 1, 10)));


        }

    }

}

#pragma warning restore 618