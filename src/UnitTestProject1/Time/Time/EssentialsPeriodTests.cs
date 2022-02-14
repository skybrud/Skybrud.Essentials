using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;
using System;

namespace UnitTestProject1.Time.Time {

    [TestClass]
    public class EssentialsPeriodTests {

        [TestMethod]
        public void Today1() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset sample = new DateTimeOffset(2021, 3, 28, 0, 0, 0, TimeSpan.FromHours(1));

            EssentialsPeriod period = EssentialsPeriod.Today(sample, romance);

            Assert.AreEqual("2021-03-28T00:00:00+01:00", period.Start.ToString(), "Start");
            Assert.AreEqual("2021-03-28T23:59:59+02:00", period.End.ToString(), "End");

        }

        [TestMethod]
        public void Today2() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset sample = new DateTimeOffset(2021, 10, 31, 0, 0, 0, TimeSpan.FromHours(1));

            EssentialsPeriod period = EssentialsPeriod.Today(sample, romance);

            Assert.AreEqual("2021-10-31T00:00:00+02:00", period.Start.ToString(), "Start");
            Assert.AreEqual("2021-10-31T23:59:59+01:00", period.End.ToString(), "End");

        }


        [TestMethod]
        public void Yesterday1() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset sample = new DateTimeOffset(2021, 3, 29, 0, 0, 0, TimeSpan.FromHours(1));

            EssentialsPeriod period = EssentialsPeriod.Yesterday(sample, romance);

            Assert.AreEqual("2021-03-28T00:00:00+01:00", period.Start.ToString(), "Start");
            Assert.AreEqual("2021-03-28T23:59:59+02:00", period.End.ToString(), "End");

        }

        [TestMethod]
        public void Yesterday2() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset sample = new DateTimeOffset(2021, 11, 1, 0, 0, 0, TimeSpan.FromHours(1));

            EssentialsPeriod period = EssentialsPeriod.Yesterday(sample, romance);

            Assert.AreEqual("2021-10-31T00:00:00+02:00", period.Start.ToString(), "Start");
            Assert.AreEqual("2021-10-31T23:59:59+01:00", period.End.ToString(), "End");

        }

        [TestMethod]
        public void Tomorrow1() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset sample = new DateTimeOffset(2021, 3, 27, 0, 0, 0, TimeSpan.FromHours(1));

            EssentialsPeriod period = EssentialsPeriod.Tomorrow(sample, romance);

            Assert.AreEqual("2021-03-28T00:00:00+01:00", period.Start.ToString(), "Start");
            Assert.AreEqual("2021-03-28T23:59:59+02:00", period.End.ToString(), "End");

        }

        [TestMethod]
        public void Tomorrow2() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset sample = new DateTimeOffset(2021, 10, 30, 0, 0, 0, TimeSpan.FromHours(1));

            EssentialsPeriod period = EssentialsPeriod.Tomorrow(sample, romance);

            Assert.AreEqual("2021-10-31T00:00:00+02:00", period.Start.ToString(), "Start");
            Assert.AreEqual("2021-10-31T23:59:59+01:00", period.End.ToString(), "End");

        }

        [TestMethod]
        public void NextWeekendRomanceStandardTime() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var start = new DateTimeOffset(2021, 1, 25, 0, 0, 0, TimeSpan.FromHours(1));
            var end = new DateTimeOffset(2021, 1, 31, 23, 59, 59, TimeSpan.FromHours(1));

            for (DateTimeOffset time = start; time <= end; time = time.AddHours(1)) {

                EssentialsPeriod period = EssentialsPeriod.NextWeekend(time, romance);

                string message = $"Based on:       {time:yyyy-MM-ddTHH:mm:ssK}\r\nDay of week:    {time.DayOfWeek} ({(int)time.DayOfWeek})\r\n\r\n";

                switch (time.DayOfWeek) {

                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        Assert.AreEqual("2021-02-06T00:00:00+01:00", period.Start.ToString(), "\r\n\r\nSTART\r\n" + message);
                        Assert.AreEqual("2021-02-07T23:59:59+01:00", period.End.ToString(), "\r\n\r\nEND\r\n" + message);
                        break;

                    default:
                        Assert.AreEqual("2021-01-30T00:00:00+01:00", period.Start.ToString(), "\r\n\r\nSTART\r\n" + message);
                        Assert.AreEqual("2021-01-31T23:59:59+01:00", period.End.ToString(), "\r\n\r\nEND\r\n" + message);
                        break;

                }

            }

        }

        [TestMethod]
        public void NextWeekendRomanceStandardTime2() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var start = new DateTimeOffset(2021, 3, 22, 0, 0, 0, TimeSpan.FromHours(1));
            var end = new DateTimeOffset(2021, 3, 28, 23, 59, 59, TimeSpan.FromHours(2));

            for (DateTimeOffset time = start; time <= end; time = time.AddHours(1)) {

                EssentialsPeriod period = EssentialsPeriod.NextWeekend(time, romance);

                string message = $"Based on:       {time:yyyy-MM-ddTHH:mm:ssK}\r\nDay of week:    {time.DayOfWeek} ({(int)time.DayOfWeek})\r\n\r\n";

                switch (time.DayOfWeek) {

                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        Assert.AreEqual("2021-04-03T00:00:00+02:00", period.Start.ToString(), "\r\n\r\nSTART\r\n" + message);
                        Assert.AreEqual("2021-04-04T23:59:59+02:00", period.End.ToString(), "\r\n\r\nEND\r\n" + message);
                        break;

                    default:
                        Assert.AreEqual("2021-03-27T00:00:00+01:00", period.Start.ToString(), "\r\n\r\nSTART\r\n" + message);
                        Assert.AreEqual("2021-03-28T23:59:59+02:00", period.End.ToString(), "\r\n\r\nEND\r\n" + message);
                        break;

                }

            }

        }

        [TestMethod]
        public void NextWeekendRomanceStandardTimeToUtc() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            var s1 = new DateTimeOffset(2021, 1, 25, 0, 0, 0, TimeSpan.FromHours(1));
            var e1 = new DateTimeOffset(2021, 1, 30, 0, 59, 59, TimeSpan.FromHours(1));

            var s2 = new DateTimeOffset(2021, 1, 30, 1, 0, 0, TimeSpan.FromHours(1));
            var e2 = new DateTimeOffset(2021, 1, 31, 23, 59, 59, TimeSpan.FromHours(1));

            // Run through each hour of the work days
            for (DateTimeOffset time = s1; time <= e1; time = time.AddHours(1)) {

                EssentialsPeriod period = EssentialsPeriod.NextWeekend(time, utc);

                string message = $"Based on:       {time:yyyy-MM-ddTHH:mm:ssK}\r\nDay of week:    {time.DayOfWeek} ({(int)time.DayOfWeek})\r\n\r\n";

                Assert.AreEqual("2021-01-30T00:00:00+00:00", period.Start.ToString(), "\r\n\r\nSTART\r\n" + message);
                Assert.AreEqual("2021-01-31T23:59:59+00:00", period.End.ToString(), "\r\n\r\nEND\r\n" + message);

            }

            // Run through each hour of the weekend
            for (DateTimeOffset time = s2; time <= e2; time = time.AddHours(1)) {

                EssentialsPeriod period = EssentialsPeriod.NextWeekend(time, utc);

                string message = $"Based on:       {time:yyyy-MM-ddTHH:mm:ssK}\r\nDay of week:    {time.DayOfWeek} ({(int)time.DayOfWeek})\r\n\r\n";

                Assert.AreEqual("2021-02-06T00:00:00+00:00", period.Start.ToString(), "\r\n\r\nSTART\r\n" + message);
                Assert.AreEqual("2021-02-07T23:59:59+00:00", period.End.ToString(), "\r\n\r\nEND\r\n" + message);

            }

        }

        [TestMethod]
        public void NextWeekendRomanceStandardTimeToUtc2() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            var s1 = new DateTimeOffset(2021, 3, 22, 1, 0, 0, TimeSpan.FromHours(1));
            var e1 = new DateTimeOffset(2021, 3, 27, 0, 59, 59, TimeSpan.FromHours(1));

            var s2 = new DateTimeOffset(2021, 3, 27, 1, 0, 0, TimeSpan.FromHours(1));
            var e2 = new DateTimeOffset(2021, 3, 28, 23, 59, 59, TimeSpan.FromHours(2));

            // Run through each hour of the work days
            for (DateTimeOffset time = s1; time <= e1; time = time.AddHours(1)) {

                EssentialsPeriod period = EssentialsPeriod.NextWeekend(time, utc);

                string message = $"Based on:       {time:yyyy-MM-ddTHH:mm:ssK}\r\nDay of week:    {time.DayOfWeek} ({(int)time.DayOfWeek})\r\n\r\n";

                Assert.AreEqual("2021-03-27T00:00:00+00:00", period.Start.ToString(), "\r\n\r\nSTART\r\n" + message);
                Assert.AreEqual("2021-03-28T23:59:59+00:00", period.End.ToString(), "\r\n\r\nEND\r\n" + message);

            }

            // Run through each hour of the weekend
            for (DateTimeOffset time = s2; time <= e2; time = time.AddHours(1)) {

                EssentialsPeriod period = EssentialsPeriod.NextWeekend(time, utc);

                string message = $"Based on:       {time:yyyy-MM-ddTHH:mm:ssK}\r\nDay of week:    {time.DayOfWeek} ({(int)time.DayOfWeek})\r\n\r\n";

                Assert.AreEqual("2021-04-03T00:00:00+00:00", period.Start.ToString(), "\r\n\r\nSTART\r\n" + message);
                Assert.AreEqual("2021-04-04T23:59:59+00:00", period.End.ToString(), "\r\n\r\nEND\r\n" + message);

            }

        }

        [TestMethod]
        public void NextWeekendUtcToRomanceStandardTime() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var start1 = new DateTimeOffset(2021, 1, 25, 0, 0, 0, TimeSpan.Zero);
            var end1 = new DateTimeOffset(2021, 1, 29, 22, 59, 59, TimeSpan.Zero);

            var start2 = new DateTimeOffset(2021, 1, 29, 23, 0, 0, TimeSpan.Zero);
            var end2 = new DateTimeOffset(2021, 1, 31, 22, 59, 59, TimeSpan.Zero);

            for (DateTimeOffset time = start1; time <= end1; time = time.AddHours(1)) {

                EssentialsPeriod period = EssentialsPeriod.NextWeekend(time, romance);

                string message = $"Based on:       {time:yyyy-MM-ddTHH:mm:ssK}\r\nDay of week:    {time.DayOfWeek} ({(int)time.DayOfWeek})\r\n\r\n";

                Assert.AreEqual("2021-01-30T00:00:00+01:00", period.Start.ToString(), "\r\n\r\nSTART\r\n" + message);
                Assert.AreEqual("2021-01-31T23:59:59+01:00", period.End.ToString(), "\r\n\r\nEND\r\n" + message);

            }

            for (DateTimeOffset time = start2; time <= end2; time = time.AddHours(1)) {

                EssentialsPeriod period = EssentialsPeriod.NextWeekend(time, romance);

                string message = $"Based on:       {time:yyyy-MM-ddTHH:mm:ssK}\r\nDay of week:    {time.DayOfWeek} ({(int)time.DayOfWeek})\r\n\r\n";

                Assert.AreEqual("2021-02-06T00:00:00+01:00", period.Start.ToString(), "\r\n\r\nSTART\r\n" + message);
                Assert.AreEqual("2021-02-07T23:59:59+01:00", period.End.ToString(), "\r\n\r\nEND\r\n" + message);

            }

        }

        [TestMethod]
        public void NextWeekendUtcToRomanceStandardTime2() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var start1 = new DateTimeOffset(2021, 3, 22, 8, 0, 0, TimeSpan.Zero);
            var end1 = new DateTimeOffset(2021, 3, 26, 22, 59, 59, TimeSpan.Zero);

            var start2 = new DateTimeOffset(2021, 3, 26, 23, 0, 0, TimeSpan.Zero);
            var end2 = new DateTimeOffset(2021, 3, 28, 22, 59, 59, TimeSpan.Zero);

            for (DateTimeOffset time = start1; time <= end1; time = time.AddHours(1)) {

                EssentialsPeriod period = EssentialsPeriod.NextWeekend(time, romance);

                string message = $"Based on:       {time:yyyy-MM-ddTHH:mm:ssK}\r\nDay of week:    {time.DayOfWeek} ({(int)time.DayOfWeek})\r\n\r\n";

                Assert.AreEqual("2021-03-27T00:00:00+01:00", period.Start.ToString(), "\r\n\r\n1: START\r\n" + message);
                Assert.AreEqual("2021-03-28T23:59:59+02:00", period.End.ToString(), "\r\n\r\n1: END\r\n" + message);

            }

            for (DateTimeOffset time = start2; time <= end2; time = time.AddHours(1)) {

                EssentialsPeriod period = EssentialsPeriod.NextWeekend(time, romance);

                string message = $"Based on:       {time:yyyy-MM-ddTHH:mm:ssK}\r\nDay of week:    {time.DayOfWeek} ({(int)time.DayOfWeek})\r\n\r\n";

                Assert.AreEqual("2021-04-03T00:00:00+02:00", period.Start.ToString(), "\r\n\r\n2: START\r\n" + message);
                Assert.AreEqual("2021-04-04T23:59:59+02:00", period.End.ToString(), "\r\n\r\n2: END\r\n" + message);

            }

        }

        [TestMethod]
        public void ThisWeek1() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset sample1 = new DateTimeOffset(2021, 3, 24, 0, 0, 0, TimeSpan.FromHours(1));
            DateTimeOffset sample2 = new DateTimeOffset(2021, 3, 28, 12, 0, 0, TimeSpan.FromHours(2));

            EssentialsPeriod period1 = EssentialsPeriod.ThisWeek(sample1, romance);
            Assert.AreEqual("2021-03-22T00:00:00+01:00", period1.Start.ToString(), "#1 Start");
            Assert.AreEqual("2021-03-28T23:59:59+02:00", period1.End.ToString(), "#1 End");

            EssentialsPeriod period2 = EssentialsPeriod.ThisWeek(sample2, romance);
            Assert.AreEqual("2021-03-22T00:00:00+01:00", period2.Start.ToString(), "#2 Start");
            Assert.AreEqual("2021-03-28T23:59:59+02:00", period2.End.ToString(), "#2 End");

        }

        [TestMethod]
        public void ThisWeek2() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset sample1 = new DateTimeOffset(2021, 10, 26, 0, 0, 0, TimeSpan.FromHours(2));
            DateTimeOffset sample2 = new DateTimeOffset(2021, 10, 31, 12, 0, 0, TimeSpan.FromHours(1));

            EssentialsPeriod period1 = EssentialsPeriod.ThisWeek(sample1, romance);
            Assert.AreEqual("2021-10-25T00:00:00+02:00", period1.Start.ToString(), "#1 Start");
            Assert.AreEqual("2021-10-31T23:59:59+01:00", period1.End.ToString(), "#1 End");

            EssentialsPeriod period2 = EssentialsPeriod.ThisWeek(sample2, romance);
            Assert.AreEqual("2021-10-25T00:00:00+02:00", period2.Start.ToString(), "#2 Start");
            Assert.AreEqual("2021-10-31T23:59:59+01:00", period2.End.ToString(), "#2 End");

        }

        [TestMethod]
        public void ThisMonth1() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset sample1 = new DateTimeOffset(2021, 3, 24, 0, 0, 0, TimeSpan.FromHours(1));
            DateTimeOffset sample2 = new DateTimeOffset(2021, 3, 28, 12, 0, 0, TimeSpan.FromHours(2));

            EssentialsPeriod period1 = EssentialsPeriod.ThisMonth(sample1, romance);
            Assert.AreEqual("2021-03-01T00:00:00+01:00", period1.Start.ToString(), "#1 Start");
            Assert.AreEqual("2021-03-31T23:59:59+02:00", period1.End.ToString(), "#1 End");

            EssentialsPeriod period2 = EssentialsPeriod.ThisMonth(sample2, romance);
            Assert.AreEqual("2021-03-01T00:00:00+01:00", period2.Start.ToString(), "#2 Start");
            Assert.AreEqual("2021-03-31T23:59:59+02:00", period2.End.ToString(), "#2 End");

        }

        [TestMethod]
        public void ThisMonth2() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset sample1 = new DateTimeOffset(2021, 10, 26, 0, 0, 0, TimeSpan.FromHours(2));
            DateTimeOffset sample2 = new DateTimeOffset(2021, 10, 31, 12, 0, 0, TimeSpan.FromHours(1));

            EssentialsPeriod period1 = EssentialsPeriod.ThisMonth(sample1, romance);
            Assert.AreEqual("2021-10-01T00:00:00+02:00", period1.Start.ToString(), "#1 Start");
            Assert.AreEqual("2021-10-31T23:59:59+01:00", period1.End.ToString(), "#1 End");

            EssentialsPeriod period2 = EssentialsPeriod.ThisMonth(sample2, romance);
            Assert.AreEqual("2021-10-01T00:00:00+02:00", period2.Start.ToString(), "#2 Start");
            Assert.AreEqual("2021-10-31T23:59:59+01:00", period2.End.ToString(), "#2 End");

        }

    }

}