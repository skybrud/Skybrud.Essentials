using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.Iso8601;
using Skybrud.Essentials.Time.UnixTime;

namespace UnitTestProject1.Time.UnixTime {

    [TestClass]
    public class UnixTimeTests {

        [TestMethod]
        public void CurrentSeconds() {

            double actual = UnixTimeUtils.CurrentSeconds;

            // Since Unix time is calculated back to UTC, using "DateTime.Now" and "DateTime.UtcNow" should give the
            // same result
            double expected1 = UnixTimeUtils.ToSeconds(DateTime.Now);
            double expected2 = UnixTimeUtils.ToSeconds(DateTime.UtcNow);

            Assert.AreEqual(expected2, expected1);

            // Comparing against current time is always tricky. If this is the first test to run, there may be a ~100 ms
            // difference between the actual and expected timestamps. If other tests have run first, the two timestamps
            // so far seem to be the same ¯\_(ツ)_/¯

            // Since the important part we want to test here is that the two timestamps are based on the same timezone,
            // we can confirm this by checking that "delta" is below 1 second.

            double delta1 = Math.Abs(actual - expected1);
            double delta2 = Math.Abs(actual - expected2);

            Assert.IsTrue(delta1 < 1, "#1");
            Assert.IsTrue(delta2 < 1, "#2");

        }

        [TestMethod]
        public void CurrentMilliseconds() {

            double actual = UnixTimeUtils.CurrentMilliseconds;

            // Since Unix time is calculated back to UTC, using "DateTime.Now" and "DateTime.UtcNow" should give the
            // same result
            double expected1 = UnixTimeUtils.ToMilliseconds(DateTime.Now);
            double expected2 = UnixTimeUtils.ToMilliseconds(DateTime.UtcNow);

            Assert.AreEqual(expected2, actual);
            Assert.AreEqual(expected2, expected1);

        }

        [TestMethod]
        public void FromSecondsInt32_NormalTime() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset resultUtc = UnixTimeUtils.FromSeconds(1643886000);
            DateTimeOffset resultDenmark = TimeZoneInfo.ConvertTime(resultUtc, romance);

            Assert.AreEqual("2022-02-03T11:00:00+00:00", resultUtc.ToString(Iso8601Constants.DateTimeSeconds));
            Assert.AreEqual("2022-02-03T12:00:00+01:00", resultDenmark.ToString(Iso8601Constants.DateTimeSeconds));

        }

        [TestMethod]
        public void FromSecondsInt32_SummerTime() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset resultUtc = UnixTimeUtils.FromSeconds(1629182100);
            DateTimeOffset resultDenmark = TimeZoneInfo.ConvertTime(resultUtc, romance);

            Assert.AreEqual("2021-08-17T06:35:00+00:00", resultUtc.ToString(Iso8601Constants.DateTimeSeconds));
            Assert.AreEqual("2021-08-17T08:35:00+02:00", resultDenmark.ToString(Iso8601Constants.DateTimeSeconds));

        }

        [TestMethod]
        public void FromSecondsInt64_NormalTime() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset resultUtc = UnixTimeUtils.FromSeconds(1643886000L);
            DateTimeOffset resultDenmark = TimeZoneInfo.ConvertTime(resultUtc, romance);

            Assert.AreEqual("2022-02-03T11:00:00+00:00", resultUtc.ToString(Iso8601Constants.DateTimeSeconds));
            Assert.AreEqual("2022-02-03T12:00:00+01:00", resultDenmark.ToString(Iso8601Constants.DateTimeSeconds));

        }

        [TestMethod]
        public void FromSecondsInt64_SummerTime() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset resultUtc = UnixTimeUtils.FromSeconds(1629182100L);
            DateTimeOffset resultDenmark = TimeZoneInfo.ConvertTime(resultUtc, romance);

            Assert.AreEqual("2021-08-17T06:35:00+00:00", resultUtc.ToString(Iso8601Constants.DateTimeSeconds));
            Assert.AreEqual("2021-08-17T08:35:00+02:00", resultDenmark.ToString(Iso8601Constants.DateTimeSeconds));

        }

        [TestMethod]
        public void FromSecondsDouble_NormalTime() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset resultUtc = UnixTimeUtils.FromSeconds(1643886000d);
            DateTimeOffset resultDenmark = TimeZoneInfo.ConvertTime(resultUtc, romance);

            Assert.AreEqual("2022-02-03T11:00:00+00:00", resultUtc.ToString(Iso8601Constants.DateTimeSeconds));
            Assert.AreEqual("2022-02-03T12:00:00+01:00", resultDenmark.ToString(Iso8601Constants.DateTimeSeconds));

        }

        [TestMethod]
        public void FromSecondsDouble_SummerTime() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset resultUtc = UnixTimeUtils.FromSeconds(1629182100d);
            DateTimeOffset resultDenmark = TimeZoneInfo.ConvertTime(resultUtc, romance);

            Assert.AreEqual("2021-08-17T06:35:00+00:00", resultUtc.ToString(Iso8601Constants.DateTimeSeconds));
            Assert.AreEqual("2021-08-17T08:35:00+02:00", resultDenmark.ToString(Iso8601Constants.DateTimeSeconds));

        }

        [TestMethod]
        public void FromSecondsString_NormalTime() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset resultUtc = UnixTimeUtils.FromSeconds("1643886000");
            DateTimeOffset resultDenmark = TimeZoneInfo.ConvertTime(resultUtc, romance);

            Assert.AreEqual("2022-02-03T11:00:00+00:00", resultUtc.ToString(Iso8601Constants.DateTimeSeconds));
            Assert.AreEqual("2022-02-03T12:00:00+01:00", resultDenmark.ToString(Iso8601Constants.DateTimeSeconds));

        }

        [TestMethod]
        public void FromSecondsString_SummerTime() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset resultUtc = UnixTimeUtils.FromSeconds("1629182100");
            DateTimeOffset resultDenmark = TimeZoneInfo.ConvertTime(resultUtc, romance);

            Assert.AreEqual("2021-08-17T06:35:00+00:00", resultUtc.ToString(Iso8601Constants.DateTimeSeconds));
            Assert.AreEqual("2021-08-17T08:35:00+02:00", resultDenmark.ToString(Iso8601Constants.DateTimeSeconds));

        }













        [TestMethod]
        public void FromMillisecondsInt64_NormalTime() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset resultUtc = UnixTimeUtils.FromMilliseconds(1643886000123);
            DateTimeOffset resultDenmark = TimeZoneInfo.ConvertTime(resultUtc, romance);

            Assert.AreEqual("2022-02-03T11:00:00.123+00:00", resultUtc.ToString("yyyy-MM-ddTHH:mm:ss.fffK"));
            Assert.AreEqual("2022-02-03T12:00:00.123+01:00", resultDenmark.ToString("yyyy-MM-ddTHH:mm:ss.fffK"));

        }

        [TestMethod]
        public void FromMillisecondsInt64_SummerTime() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset resultUtc = UnixTimeUtils.FromMilliseconds(1629182100123);
            DateTimeOffset resultDenmark = TimeZoneInfo.ConvertTime(resultUtc, romance);

            Assert.AreEqual("2021-08-17T06:35:00.123+00:00", resultUtc.ToString("yyyy-MM-ddTHH:mm:ss.fffK"));
            Assert.AreEqual("2021-08-17T08:35:00.123+02:00", resultDenmark.ToString("yyyy-MM-ddTHH:mm:ss.fffK"));

        }

        [TestMethod]
        public void FromMillisecondsDouble_NormalTime() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset resultUtc = UnixTimeUtils.FromMilliseconds(1643886000123d);
            DateTimeOffset resultDenmark = TimeZoneInfo.ConvertTime(resultUtc, romance);

            Assert.AreEqual("2022-02-03T11:00:00.123+00:00", resultUtc.ToString("yyyy-MM-ddTHH:mm:ss.fffK"));
            Assert.AreEqual("2022-02-03T12:00:00.123+01:00", resultDenmark.ToString("yyyy-MM-ddTHH:mm:ss.fffK"));

        }

        [TestMethod]
        public void FromMillisecondsDouble_SummerTime() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset resultUtc = UnixTimeUtils.FromMilliseconds(1629182100123d);
            DateTimeOffset resultDenmark = TimeZoneInfo.ConvertTime(resultUtc, romance);

            Assert.AreEqual("2021-08-17T06:35:00.123+00:00", resultUtc.ToString("yyyy-MM-ddTHH:mm:ss.fffK"));
            Assert.AreEqual("2021-08-17T08:35:00.123+02:00", resultDenmark.ToString("yyyy-MM-ddTHH:mm:ss.fffK"));

        }

        [TestMethod]
        public void FromMillisecondsString_NormalTime() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset resultUtc = UnixTimeUtils.FromMilliseconds("1643886000123");
            DateTimeOffset resultDenmark = TimeZoneInfo.ConvertTime(resultUtc, romance);

            Assert.AreEqual("2022-02-03T11:00:00.123+00:00", resultUtc.ToString("yyyy-MM-ddTHH:mm:ss.fffK"));
            Assert.AreEqual("2022-02-03T12:00:00.123+01:00", resultDenmark.ToString("yyyy-MM-ddTHH:mm:ss.fffK"));

        }

        [TestMethod]
        public void FromMillisecondsString_SummerTime() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset resultUtc = UnixTimeUtils.FromMilliseconds("1629182100123");
            DateTimeOffset resultDenmark = TimeZoneInfo.ConvertTime(resultUtc, romance);

            Assert.AreEqual("2021-08-17T06:35:00.123+00:00", resultUtc.ToString("yyyy-MM-ddTHH:mm:ss.fffK"));
            Assert.AreEqual("2021-08-17T08:35:00.123+02:00", resultDenmark.ToString("yyyy-MM-ddTHH:mm:ss.fffK"));

        }

        [TestMethod]
        public void ToSecondsDateTime() {

            // Must be UTC as we really can't rely on anything else when unit testing DateTime
            DateTime dt = new DateTime(2022, 2, 3, 11, 0, 0, DateTimeKind.Utc);

            // Cast to int as we don't really care about the milliseconds here
            int result = (int) UnixTimeUtils.ToSeconds(dt);

            // Do we have a match?
            Assert.AreEqual(1643886000, result);

        }

        [TestMethod]
        public void ToSecondsDateTimeOffset() {

            // Initialize to different DateTimeOffset representing the same point in time, but with different offsets
            DateTimeOffset dto1 = new DateTimeOffset(2022, 2, 3, 11, 0, 0, TimeSpan.Zero);
            DateTimeOffset dto2 = new DateTimeOffset(2022, 2, 3, 12, 0, 0, TimeSpan.FromHours(1));

            // Cast to int as we don't really care about the milliseconds here
            int result1 = (int) UnixTimeUtils.ToSeconds(dto1);
            int result2 = (int) UnixTimeUtils.ToSeconds(dto2);

            // Do we have a match?
            Assert.AreEqual(1643886000, result1);
            Assert.AreEqual(1643886000, result2);

        }

        [TestMethod]
        public void ToMillisecondsDateTime() {

            // Must be UTC as we really can't rely on anything else when unit testing DateTime
            DateTime dt = new DateTime(2022, 2, 3, 11, 0, 0, 123, DateTimeKind.Utc);

            // Cast to long as we don't really care about any decimals
            long result = (long) UnixTimeUtils.ToMilliseconds(dt);

            // Do we have a match?
            Assert.AreEqual(1643886000123, result);

        }

        [TestMethod]
        public void ToMillisecondsDateTimeOffset() {

            // Initialize to different DateTimeOffset representing the same point in time, but with different offsets
            DateTimeOffset dto1 = new DateTimeOffset(2022, 2, 3, 11, 0, 0, 123, TimeSpan.Zero);
            DateTimeOffset dto2 = new DateTimeOffset(2022, 2, 3, 12, 0, 0, 123, TimeSpan.FromHours(1));

            // Cast to long as we don't really care about any decimals
            long result1 = (long) UnixTimeUtils.ToMilliseconds(dto1);
            long result2 = (long) UnixTimeUtils.ToMilliseconds(dto2);

            // Do we have a match?
            Assert.AreEqual(1643886000123, result1);
            Assert.AreEqual(1643886000123, result2);

        }

        [TestMethod]
        public void GetCurrentSeconds() {

            // DateTimeOffset offers similar logic, but only in newer versions of .NET, which is why we're not using it
            // internally. But insce it's available here in the test project, we can use it for validating our own values :D

            // NOTICE: Working with current time is always a bit tricky, so if we're unlucky, "result1" may be a second
            // ahead of the other result. This is not an error!

            long result1 = DateTimeOffset.Now.ToUnixTimeSeconds();
            long result2 = (long) UnixTimeUtils.CurrentSeconds;
            long result3 = EssentialsTime.CurrentUnixTimeSeconds;
            long result4 = EssentialsTime.Now.UnixTimeSeconds;

            Assert.AreEqual(result1, result2, "#2");
            Assert.AreEqual(result1, result3, "#3");
            Assert.AreEqual(result1, result4, "#4");

        }

        [TestMethod]
        public void GetCurrentMilliseconds() {

            // DateTimeOffset offers similar logic, but only in newer versions of .NET, which is why we're not using it
            // internally. But insce it's available here in the test project, we can use it for validating our own values :D

            // NOTICE: Working with current time is always a bit tricky, so if we're unlucky, "result1" may be a second
            // ahead of the other result. This is not an error!

            long result1 = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            long result2 = (long) UnixTimeUtils.CurrentMilliseconds;
            long result3 = EssentialsTime.CurrentUnixTimeMilliseconds;
            long result4 = EssentialsTime.Now.UnixTimeMilliseconds;

            Assert.AreEqual(result1, result2, "#2");
            Assert.AreEqual(result1, result3, "#3");
            Assert.AreEqual(result1, result4, "#4");

        }

    }

}