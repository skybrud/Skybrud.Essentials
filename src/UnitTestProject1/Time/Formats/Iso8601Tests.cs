using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.Formats {

    [TestClass]
    public class Iso8601 {

        [TestMethod]
        public void DateTimeOffsetToIso8601() {

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

        }

        [TestMethod]
        public void Iso8601ToDateTimeOffset() {

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

        }

    }

}