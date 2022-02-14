using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.Iso8601;
using static Skybrud.Essentials.Time.Iso8601.Iso8601Constants;

namespace UnitTestProject1.Time.Formats {
    
    [TestClass]
    public class Iso8601Tests {

        [TestMethod]
        public void FromWeekNumberUtc() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");

            DateTimeOffset week1 = Iso8601Utils.FromWeekNumber(2021, 1, utc);

            DateTimeOffset week12 = Iso8601Utils.FromWeekNumber(2021, 12, utc);
            DateTimeOffset week13 = Iso8601Utils.FromWeekNumber(2021, 13, utc);

            DateTimeOffset week43 = Iso8601Utils.FromWeekNumber(2021, 43, utc);
            DateTimeOffset week44 = Iso8601Utils.FromWeekNumber(2021, 44, utc);

            DateTimeOffset week52 = Iso8601Utils.FromWeekNumber(2021, 52, utc);

            Assert.AreEqual("2021-01-04T00:00:00+00:00", week1.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 1");
            Assert.AreEqual("2021-03-22T00:00:00+00:00", week12.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 12");
            Assert.AreEqual("2021-03-29T00:00:00+00:00", week13.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 13");
            Assert.AreEqual("2021-10-25T00:00:00+00:00", week43.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 43");
            Assert.AreEqual("2021-11-01T00:00:00+00:00", week44.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 44");
            Assert.AreEqual("2021-12-27T00:00:00+00:00", week52.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 52");

        }

        [TestMethod]
        public void FromWeekNumberRomance() {

            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            DateTimeOffset week1 = Iso8601Utils.FromWeekNumber(2021, 1, romance);

            DateTimeOffset week12 = Iso8601Utils.FromWeekNumber(2021, 12, romance);
            DateTimeOffset week13 = Iso8601Utils.FromWeekNumber(2021, 13, romance);

            DateTimeOffset week43 = Iso8601Utils.FromWeekNumber(2021, 43, romance);
            DateTimeOffset week44 = Iso8601Utils.FromWeekNumber(2021, 44, romance);

            DateTimeOffset week52 = Iso8601Utils.FromWeekNumber(2021, 52, romance);

            Assert.AreEqual("2021-01-04T00:00:00+01:00", week1.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 1");
            Assert.AreEqual("2021-03-22T00:00:00+01:00", week12.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 12");
            Assert.AreEqual("2021-03-29T00:00:00+02:00", week13.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 13");
            Assert.AreEqual("2021-10-25T00:00:00+02:00", week43.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 43");
            Assert.AreEqual("2021-11-01T00:00:00+01:00", week44.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 44");
            Assert.AreEqual("2021-12-27T00:00:00+01:00", week52.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 52");

        }

        [TestMethod]
        public void FromWeekNumberOffset() {

            TimeSpan gmt1 = TimeSpan.FromHours(1);
            TimeSpan gmt2 = TimeSpan.FromHours(2);

            DateTimeOffset week1 = Iso8601Utils.FromWeekNumber(2021, 1, gmt1);

            DateTimeOffset week12 = Iso8601Utils.FromWeekNumber(2021, 12, gmt1);
            DateTimeOffset week13 = Iso8601Utils.FromWeekNumber(2021, 13, gmt2);

            DateTimeOffset week43 = Iso8601Utils.FromWeekNumber(2021, 43, gmt2);
            DateTimeOffset week44 = Iso8601Utils.FromWeekNumber(2021, 44, gmt1);

            DateTimeOffset week52 = Iso8601Utils.FromWeekNumber(2021, 52, gmt1);

            Assert.AreEqual("2021-01-04T00:00:00+01:00", week1.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 1");
            Assert.AreEqual("2021-03-22T00:00:00+01:00", week12.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 12");
            Assert.AreEqual("2021-03-29T00:00:00+02:00", week13.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 13");
            Assert.AreEqual("2021-10-25T00:00:00+02:00", week43.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 43");
            Assert.AreEqual("2021-11-01T00:00:00+01:00", week44.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 44");
            Assert.AreEqual("2021-12-27T00:00:00+01:00", week52.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 52");

        }

        [TestMethod]
        public void FromWeekNumberOffsetLegacy() {

            TimeSpan gmt1 = TimeSpan.FromHours(1);
            TimeSpan gmt2 = TimeSpan.FromHours(2);

#pragma warning disable 618

            DateTimeOffset week1 = TimeUtils.GetDateTimeOffsetFromIso8601Week(2021, 1, gmt1);

            DateTimeOffset week12 = TimeUtils.GetDateTimeOffsetFromIso8601Week(2021, 12, gmt1);
            DateTimeOffset week13 = TimeUtils.GetDateTimeOffsetFromIso8601Week(2021, 13, gmt2);

            DateTimeOffset week43 = TimeUtils.GetDateTimeOffsetFromIso8601Week(2021, 43, gmt2);
            DateTimeOffset week44 = TimeUtils.GetDateTimeOffsetFromIso8601Week(2021, 44, gmt1);

            DateTimeOffset week52 = TimeUtils.GetDateTimeOffsetFromIso8601Week(2021, 52, gmt1);

#pragma warning restore 618

            Assert.AreEqual("2021-01-04T00:00:00+01:00", week1.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 1");
            Assert.AreEqual("2021-03-22T00:00:00+01:00", week12.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 12");
            Assert.AreEqual("2021-03-29T00:00:00+02:00", week13.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 13");
            Assert.AreEqual("2021-10-25T00:00:00+02:00", week43.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 43");
            Assert.AreEqual("2021-11-01T00:00:00+01:00", week44.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 44");
            Assert.AreEqual("2021-12-27T00:00:00+01:00", week52.ToString(DateTimeSeconds, CultureInfo.InvariantCulture), "Week 52");

        }

        [TestMethod]
        public new void ToString() {

            // Initialize some reference timestamps
            DateTimeOffset reference1 = new DateTime(2013, 08, 07, 21, 07, 24, DateTimeKind.Utc);
            DateTimeOffset reference2 = new DateTime(2016, 10, 07, 17, 33, 38, DateTimeKind.Utc);

            // Universal time
            Assert.AreEqual("2013-08-07T21:07:24+00:00", Iso8601Utils.ToString(reference1));
            Assert.AreEqual("2016-10-07T17:33:38+00:00", Iso8601Utils.ToString(reference2));

            // Declare the timezones
            TimeZoneInfo utcPlus01 = TimeZoneInfo.CreateCustomTimeZone("UTC +01", TimeSpan.FromHours(1), "UTC +01", "UTC +01");
            TimeZoneInfo utcPlus02 = TimeZoneInfo.CreateCustomTimeZone("UTC +02", TimeSpan.FromHours(2), "UTC +02", "UTC +02");
            TimeZoneInfo utcPlus03 = TimeZoneInfo.CreateCustomTimeZone("UTC +03", TimeSpan.FromHours(3), "UTC +03", "UTC +03");
            TimeZoneInfo utcPlus04 = TimeZoneInfo.CreateCustomTimeZone("UTC +04", TimeSpan.FromHours(4), "UTC +04", "UTC +04");
            TimeZoneInfo utcPlus05 = TimeZoneInfo.CreateCustomTimeZone("UTC +05", TimeSpan.FromHours(5), "UTC +05", "UTC +05");
            TimeZoneInfo utcPlus06 = TimeZoneInfo.CreateCustomTimeZone("UTC +06", TimeSpan.FromHours(6), "UTC +06", "UTC +06");
            TimeZoneInfo utcPlus07 = TimeZoneInfo.CreateCustomTimeZone("UTC +07", TimeSpan.FromHours(7), "UTC +07", "UTC +07");
            TimeZoneInfo utcPlus08 = TimeZoneInfo.CreateCustomTimeZone("UTC +08", TimeSpan.FromHours(8), "UTC +08", "UTC +08");
            TimeZoneInfo utcPlus09 = TimeZoneInfo.CreateCustomTimeZone("UTC +09", TimeSpan.FromHours(9), "UTC +09", "UTC +09");
            TimeZoneInfo utcPlus10 = TimeZoneInfo.CreateCustomTimeZone("UTC +10", TimeSpan.FromHours(10), "UTC +10", "UTC +10");
            TimeZoneInfo utcPlus11 = TimeZoneInfo.CreateCustomTimeZone("UTC +11", TimeSpan.FromHours(11), "UTC +11", "UTC +11");
            TimeZoneInfo utcPlus12 = TimeZoneInfo.CreateCustomTimeZone("UTC +12", TimeSpan.FromHours(12), "UTC +12", "UTC +12");
            TimeZoneInfo utcMinus01 = TimeZoneInfo.CreateCustomTimeZone("UTC -01", TimeSpan.FromHours(-1), "UTC -01", "UTC -01");
            TimeZoneInfo utcMinus02 = TimeZoneInfo.CreateCustomTimeZone("UTC -02", TimeSpan.FromHours(-2), "UTC -02", "UTC -02");
            TimeZoneInfo utcMinus03 = TimeZoneInfo.CreateCustomTimeZone("UTC -03", TimeSpan.FromHours(-3), "UTC -03", "UTC -03");
            TimeZoneInfo utcMinus04 = TimeZoneInfo.CreateCustomTimeZone("UTC -04", TimeSpan.FromHours(-4), "UTC -04", "UTC -04");
            TimeZoneInfo utcMinus05 = TimeZoneInfo.CreateCustomTimeZone("UTC -05", TimeSpan.FromHours(-5), "UTC -05", "UTC -05");
            TimeZoneInfo utcMinus06 = TimeZoneInfo.CreateCustomTimeZone("UTC -06", TimeSpan.FromHours(-6), "UTC -06", "UTC -06");
            TimeZoneInfo utcMinus07 = TimeZoneInfo.CreateCustomTimeZone("UTC -07", TimeSpan.FromHours(-7), "UTC -07", "UTC -07");
            TimeZoneInfo utcMinus08 = TimeZoneInfo.CreateCustomTimeZone("UTC -08", TimeSpan.FromHours(-8), "UTC -08", "UTC -08");
            TimeZoneInfo utcMinus09 = TimeZoneInfo.CreateCustomTimeZone("UTC -09", TimeSpan.FromHours(-9), "UTC -09", "UTC -09");
            TimeZoneInfo utcMinus10 = TimeZoneInfo.CreateCustomTimeZone("UTC -10", TimeSpan.FromHours(-10), "UTC -10", "UTC -10");
            TimeZoneInfo utcMinus11 = TimeZoneInfo.CreateCustomTimeZone("UTC -11", TimeSpan.FromHours(-11), "UTC -11", "UTC -11");
            TimeZoneInfo utcMinus12 = TimeZoneInfo.CreateCustomTimeZone("UTC -12", TimeSpan.FromHours(-12), "UTC -12", "UTC -12");
            
            // Offset
            Assert.AreEqual("2013-08-07T22:07:24+01:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus01)));
            Assert.AreEqual("2013-08-07T23:07:24+02:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus02)));
            Assert.AreEqual("2013-08-08T00:07:24+03:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus03)));
            Assert.AreEqual("2013-08-08T01:07:24+04:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus04)));
            Assert.AreEqual("2013-08-08T02:07:24+05:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus05)));
            Assert.AreEqual("2013-08-08T03:07:24+06:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus06)));
            Assert.AreEqual("2013-08-08T04:07:24+07:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus07)));
            Assert.AreEqual("2013-08-08T05:07:24+08:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus08)));
            Assert.AreEqual("2013-08-08T06:07:24+09:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus09)));
            Assert.AreEqual("2013-08-08T07:07:24+10:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus10)));
            Assert.AreEqual("2013-08-08T08:07:24+11:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus11)));
            Assert.AreEqual("2013-08-08T09:07:24+12:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus12)));
            Assert.AreEqual("2013-08-07T20:07:24-01:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus01)));
            Assert.AreEqual("2013-08-07T19:07:24-02:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus02)));
            Assert.AreEqual("2013-08-07T18:07:24-03:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus03)));
            Assert.AreEqual("2013-08-07T17:07:24-04:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus04)));
            Assert.AreEqual("2013-08-07T16:07:24-05:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus05)));
            Assert.AreEqual("2013-08-07T15:07:24-06:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus06)));
            Assert.AreEqual("2013-08-07T14:07:24-07:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus07)));
            Assert.AreEqual("2013-08-07T13:07:24-08:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus08)));
            Assert.AreEqual("2013-08-07T12:07:24-09:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus09)));
            Assert.AreEqual("2013-08-07T11:07:24-10:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus10)));
            Assert.AreEqual("2013-08-07T10:07:24-11:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus11)));
            Assert.AreEqual("2013-08-07T09:07:24-12:00", Iso8601Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus12)));

        }

        [TestMethod]
        public void ToStringLegacy() {

            #pragma warning disable 618

            // Initialize some reference timestamps
            DateTimeOffset reference1 = new DateTime(2013, 08, 07, 21, 07, 24, DateTimeKind.Utc);
            DateTimeOffset reference2 = new DateTime(2016, 10, 07, 17, 33, 38, DateTimeKind.Utc);

            // Universal time
            Assert.AreEqual("2013-08-07T21:07:24+00:00", TimeUtils.ToIso8601(reference1));
            Assert.AreEqual("2016-10-07T17:33:38+00:00", TimeUtils.ToIso8601(reference2));

            // Declare the timezones
            TimeZoneInfo utcPlus01 = TimeZoneInfo.CreateCustomTimeZone("UTC +01", TimeSpan.FromHours(1), "UTC +01", "UTC +01");
            TimeZoneInfo utcPlus02 = TimeZoneInfo.CreateCustomTimeZone("UTC +02", TimeSpan.FromHours(2), "UTC +02", "UTC +02");
            TimeZoneInfo utcPlus03 = TimeZoneInfo.CreateCustomTimeZone("UTC +03", TimeSpan.FromHours(3), "UTC +03", "UTC +03");
            TimeZoneInfo utcPlus04 = TimeZoneInfo.CreateCustomTimeZone("UTC +04", TimeSpan.FromHours(4), "UTC +04", "UTC +04");
            TimeZoneInfo utcPlus05 = TimeZoneInfo.CreateCustomTimeZone("UTC +05", TimeSpan.FromHours(5), "UTC +05", "UTC +05");
            TimeZoneInfo utcPlus06 = TimeZoneInfo.CreateCustomTimeZone("UTC +06", TimeSpan.FromHours(6), "UTC +06", "UTC +06");
            TimeZoneInfo utcPlus07 = TimeZoneInfo.CreateCustomTimeZone("UTC +07", TimeSpan.FromHours(7), "UTC +07", "UTC +07");
            TimeZoneInfo utcPlus08 = TimeZoneInfo.CreateCustomTimeZone("UTC +08", TimeSpan.FromHours(8), "UTC +08", "UTC +08");
            TimeZoneInfo utcPlus09 = TimeZoneInfo.CreateCustomTimeZone("UTC +09", TimeSpan.FromHours(9), "UTC +09", "UTC +09");
            TimeZoneInfo utcPlus10 = TimeZoneInfo.CreateCustomTimeZone("UTC +10", TimeSpan.FromHours(10), "UTC +10", "UTC +10");
            TimeZoneInfo utcPlus11 = TimeZoneInfo.CreateCustomTimeZone("UTC +11", TimeSpan.FromHours(11), "UTC +11", "UTC +11");
            TimeZoneInfo utcPlus12 = TimeZoneInfo.CreateCustomTimeZone("UTC +12", TimeSpan.FromHours(12), "UTC +12", "UTC +12");
            TimeZoneInfo utcMinus01 = TimeZoneInfo.CreateCustomTimeZone("UTC -01", TimeSpan.FromHours(-1), "UTC -01", "UTC -01");
            TimeZoneInfo utcMinus02 = TimeZoneInfo.CreateCustomTimeZone("UTC -02", TimeSpan.FromHours(-2), "UTC -02", "UTC -02");
            TimeZoneInfo utcMinus03 = TimeZoneInfo.CreateCustomTimeZone("UTC -03", TimeSpan.FromHours(-3), "UTC -03", "UTC -03");
            TimeZoneInfo utcMinus04 = TimeZoneInfo.CreateCustomTimeZone("UTC -04", TimeSpan.FromHours(-4), "UTC -04", "UTC -04");
            TimeZoneInfo utcMinus05 = TimeZoneInfo.CreateCustomTimeZone("UTC -05", TimeSpan.FromHours(-5), "UTC -05", "UTC -05");
            TimeZoneInfo utcMinus06 = TimeZoneInfo.CreateCustomTimeZone("UTC -06", TimeSpan.FromHours(-6), "UTC -06", "UTC -06");
            TimeZoneInfo utcMinus07 = TimeZoneInfo.CreateCustomTimeZone("UTC -07", TimeSpan.FromHours(-7), "UTC -07", "UTC -07");
            TimeZoneInfo utcMinus08 = TimeZoneInfo.CreateCustomTimeZone("UTC -08", TimeSpan.FromHours(-8), "UTC -08", "UTC -08");
            TimeZoneInfo utcMinus09 = TimeZoneInfo.CreateCustomTimeZone("UTC -09", TimeSpan.FromHours(-9), "UTC -09", "UTC -09");
            TimeZoneInfo utcMinus10 = TimeZoneInfo.CreateCustomTimeZone("UTC -10", TimeSpan.FromHours(-10), "UTC -10", "UTC -10");
            TimeZoneInfo utcMinus11 = TimeZoneInfo.CreateCustomTimeZone("UTC -11", TimeSpan.FromHours(-11), "UTC -11", "UTC -11");
            TimeZoneInfo utcMinus12 = TimeZoneInfo.CreateCustomTimeZone("UTC -12", TimeSpan.FromHours(-12), "UTC -12", "UTC -12");
            
            // Offset
            Assert.AreEqual("2013-08-07T22:07:24+01:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcPlus01)));
            Assert.AreEqual("2013-08-07T23:07:24+02:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcPlus02)));
            Assert.AreEqual("2013-08-08T00:07:24+03:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcPlus03)));
            Assert.AreEqual("2013-08-08T01:07:24+04:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcPlus04)));
            Assert.AreEqual("2013-08-08T02:07:24+05:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcPlus05)));
            Assert.AreEqual("2013-08-08T03:07:24+06:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcPlus06)));
            Assert.AreEqual("2013-08-08T04:07:24+07:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcPlus07)));
            Assert.AreEqual("2013-08-08T05:07:24+08:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcPlus08)));
            Assert.AreEqual("2013-08-08T06:07:24+09:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcPlus09)));
            Assert.AreEqual("2013-08-08T07:07:24+10:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcPlus10)));
            Assert.AreEqual("2013-08-08T08:07:24+11:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcPlus11)));
            Assert.AreEqual("2013-08-08T09:07:24+12:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcPlus12)));
            Assert.AreEqual("2013-08-07T20:07:24-01:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcMinus01)));
            Assert.AreEqual("2013-08-07T19:07:24-02:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcMinus02)));
            Assert.AreEqual("2013-08-07T18:07:24-03:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcMinus03)));
            Assert.AreEqual("2013-08-07T17:07:24-04:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcMinus04)));
            Assert.AreEqual("2013-08-07T16:07:24-05:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcMinus05)));
            Assert.AreEqual("2013-08-07T15:07:24-06:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcMinus06)));
            Assert.AreEqual("2013-08-07T14:07:24-07:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcMinus07)));
            Assert.AreEqual("2013-08-07T13:07:24-08:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcMinus08)));
            Assert.AreEqual("2013-08-07T12:07:24-09:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcMinus09)));
            Assert.AreEqual("2013-08-07T11:07:24-10:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcMinus10)));
            Assert.AreEqual("2013-08-07T10:07:24-11:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcMinus11)));
            Assert.AreEqual("2013-08-07T09:07:24-12:00", TimeUtils.ToIso8601(TimeZoneInfo.ConvertTime(reference1, utcMinus12)));

            #pragma warning restore 618

        }

        [TestMethod]
        public void Parse() {

            // Initialize some reference timestamps
            DateTimeOffset reference1 = new DateTime(2013, 08, 07, 21, 07, 24, DateTimeKind.Utc);
            DateTimeOffset reference2 = new DateTime(2016, 10, 07, 17, 33, 38, DateTimeKind.Utc);

            // Universal time
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T21:07:24Z"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T21:07:24+00:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T17:33:38Z"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T17:33:38+00:00"));

            // Offset (reference 1)
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T20:07:24-01:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T19:07:24-02:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T18:07:24-03:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T17:07:24-04:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T16:07:24-05:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T15:07:24-06:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T14:07:24-07:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T13:07:24-08:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T12:07:24-09:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T11:07:24-10:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T10:07:24-11:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T09:07:24-12:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T22:07:24+01:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T23:07:24+02:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T00:07:24+03:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T01:07:24+04:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T02:07:24+05:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T03:07:24+06:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T04:07:24+07:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T05:07:24+08:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T06:07:24+09:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T07:07:24+10:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T08:07:24+11:00"));
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T09:07:24+12:00"));

            // Offset (reference 2)
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T16:33:38-01:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T15:33:38-02:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T14:33:38-03:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T13:33:38-04:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T12:33:38-05:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T11:33:38-06:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T10:33:38-07:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T09:33:38-08:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T08:33:38-09:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T07:33:38-10:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T06:33:38-11:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T05:33:38-12:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T18:33:38+01:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T19:33:38+02:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T20:33:38+03:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T21:33:38+04:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T22:33:38+05:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T23:33:38+06:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-08T00:33:38+07:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-08T01:33:38+08:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-08T02:33:38+09:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-08T03:33:38+10:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-08T04:33:38+11:00"));
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-08T05:33:38+12:00"));

        }

        [TestMethod]
        public void ParseWithMilliseconds() {

            // Initialize some reference timestamps
            DateTimeOffset reference1 = new DateTime(2013, 08, 07, 21, 07, 24, 123, DateTimeKind.Utc);
            DateTimeOffset reference2 = new DateTime(2016, 10, 07, 17, 33, 38, 456, DateTimeKind.Utc);

            //var dto = Iso8601Utils.Parse("2016-10-07T16:33:38.456-01:00");

            //throw new Exception(reference2.ToString("yyyy-MM-ddTHH:mm:ss.fffK") + " vs " + dto.ToString("yyyy-MM-ddTHH:mm:ss.fffK"));

            // Universal time
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T21:07:24.123Z"), "Reference 1 - UTC +00");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T21:07:24.123+00:00"), "Reference 1 - UTC +01");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T17:33:38.456Z"), "Reference 1 - UTC +02");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T17:33:38.456+00:00"), "Reference 1 - UTC +02");

            // Offset (reference 1)
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T20:07:24.123-01:00"), "Reference 1 - UTC -01");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T19:07:24.123-02:00"), "Reference 1 - UTC -02");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T18:07:24.123-03:00"), "Reference 1 - UTC -03");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T17:07:24.123-04:00"), "Reference 1 - UTC -04");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T16:07:24.123-05:00"), "Reference 1 - UTC -05");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T15:07:24.123-06:00"), "Reference 1 - UTC -05");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T14:07:24.123-07:00"), "Reference 1 - UTC -07");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T13:07:24.123-08:00"), "Reference 1 - UTC -08");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T12:07:24.123-09:00"), "Reference 1 - UTC -09");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T11:07:24.123-10:00"), "Reference 1 - UTC -10");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T10:07:24.123-11:00"), "Reference 1 - UTC -11");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T09:07:24.123-12:00"), "Reference 1 - UTC -12");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T22:07:24.123+01:00"), "Reference 1 - UTC +01");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-07T23:07:24.123+02:00"), "Reference 1 - UTC +02");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T00:07:24.123+03:00"), "Reference 1 - UTC +03");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T01:07:24.123+04:00"), "Reference 1 - UTC +04");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T02:07:24.123+05:00"), "Reference 1 - UTC +05");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T03:07:24.123+06:00"), "Reference 1 - UTC +06");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T04:07:24.123+07:00"), "Reference 1 - UTC +07");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T05:07:24.123+08:00"), "Reference 1 - UTC +08");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T06:07:24.123+09:00"), "Reference 1 - UTC +09");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T07:07:24.123+10:00"), "Reference 1 - UTC +10");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T08:07:24.123+11:00"), "Reference 1 - UTC +11");
            Assert.AreEqual(reference1, Iso8601Utils.Parse("2013-08-08T09:07:24.123+12:00"), "Reference 1 - UTC +12");

            // Offset (reference 2)
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T16:33:38.456-01:00"), "Reference 2 - UTC -01");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T15:33:38.456-02:00"), "Reference 2 - UTC -02");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T14:33:38.456-03:00"), "Reference 2 - UTC -03");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T13:33:38.456-04:00"), "Reference 2 - UTC -04");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T12:33:38.456-05:00"), "Reference 2 - UTC -05");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T11:33:38.456-06:00"), "Reference 2 - UTC -06");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T10:33:38.456-07:00"), "Reference 2 - UTC -07");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T09:33:38.456-08:00"), "Reference 2 - UTC -08");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T08:33:38.456-09:00"), "Reference 2 - UTC -09");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T07:33:38.456-10:00"), "Reference 2 - UTC -10");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T06:33:38.456-11:00"), "Reference 2 - UTC -11");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T05:33:38.456-12:00"), "Reference 2 - UTC -12");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T18:33:38.456+01:00"), "Reference 2 - UTC +01");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T19:33:38.456+02:00"), "Reference 2 - UTC +02");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T20:33:38.456+03:00"), "Reference 2 - UTC +03");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T21:33:38.456+04:00"), "Reference 2 - UTC +04");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T22:33:38.456+05:00"), "Reference 2 - UTC +05");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-07T23:33:38.456+06:00"), "Reference 2 - UTC +06");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-08T00:33:38.456+07:00"), "Reference 2 - UTC +07");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-08T01:33:38.456+08:00"), "Reference 2 - UTC +08");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-08T02:33:38.456+09:00"), "Reference 2 - UTC +09");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-08T03:33:38.456+10:00"), "Reference 2 - UTC +10");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-08T04:33:38.456+11:00"), "Reference 2 - UTC +11");
            Assert.AreEqual(reference2, Iso8601Utils.Parse("2016-10-08T05:33:38.456+12:00"), "Reference 2 - UTC +12");

        }

        [TestMethod]
        public void ParseLegacy() {

            #pragma warning disable 618

            // Initialize some reference timestamps
            DateTimeOffset reference1 = new DateTime(2013, 08, 07, 21, 07, 24, DateTimeKind.Utc);
            DateTimeOffset reference2 = new DateTime(2016, 10, 07, 17, 33, 38, DateTimeKind.Utc);

            // Universal time
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-07T21:07:24Z"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-07T21:07:24+00:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T17:33:38Z"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T17:33:38+00:00"));

            // Offset (reference 1)
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-07T20:07:24-01:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-07T19:07:24-02:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-07T18:07:24-03:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-07T17:07:24-04:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-07T16:07:24-05:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-07T15:07:24-06:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-07T14:07:24-07:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-07T13:07:24-08:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-07T12:07:24-09:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-07T11:07:24-10:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-07T10:07:24-11:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-07T09:07:24-12:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-07T22:07:24+01:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-07T23:07:24+02:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-08T00:07:24+03:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-08T01:07:24+04:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-08T02:07:24+05:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-08T03:07:24+06:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-08T04:07:24+07:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-08T05:07:24+08:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-08T06:07:24+09:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-08T07:07:24+10:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-08T08:07:24+11:00"));
            Assert.AreEqual(reference1, TimeUtils.Iso8601ToDateTimeOffset("2013-08-08T09:07:24+12:00"));

            // Offset (reference 2)
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T16:33:38-01:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T15:33:38-02:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T14:33:38-03:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T13:33:38-04:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T12:33:38-05:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T11:33:38-06:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T10:33:38-07:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T09:33:38-08:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T08:33:38-09:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T07:33:38-10:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T06:33:38-11:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T05:33:38-12:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T18:33:38+01:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T19:33:38+02:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T20:33:38+03:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T21:33:38+04:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T22:33:38+05:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-07T23:33:38+06:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-08T00:33:38+07:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-08T01:33:38+08:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-08T02:33:38+09:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-08T03:33:38+10:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-08T04:33:38+11:00"));
            Assert.AreEqual(reference2, TimeUtils.Iso8601ToDateTimeOffset("2016-10-08T05:33:38+12:00"));

            #pragma warning restore 618

        }

    }

}