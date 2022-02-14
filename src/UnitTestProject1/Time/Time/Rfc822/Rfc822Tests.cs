using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.Rfc822;
using System;

//#pragma warning disable 618

namespace UnitTestProject1.Time.Time.Rfc822 {

    [TestClass]
    public class Rfc822Tests {

        [TestMethod]
        public new void ToString() {

            // Initialize some reference timestamps
            DateTimeOffset reference1 = new DateTime(2013, 08, 07, 21, 07, 24, DateTimeKind.Utc);
            DateTimeOffset reference2 = new DateTime(2016, 10, 07, 17, 33, 38, DateTimeKind.Utc);

            // Universal time
            Assert.AreEqual("Wed, 07 Aug 2013 21:07:24 +0000", Rfc822Utils.ToString(reference1));
            Assert.AreEqual("Fri, 07 Oct 2016 17:33:38 +0000", Rfc822Utils.ToString(reference2));

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
            Assert.AreEqual("Wed, 07 Aug 2013 22:07:24 +0100", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus01)));
            Assert.AreEqual("Wed, 07 Aug 2013 23:07:24 +0200", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus02)));
            Assert.AreEqual("Thu, 08 Aug 2013 00:07:24 +0300", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus03)));
            Assert.AreEqual("Thu, 08 Aug 2013 01:07:24 +0400", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus04)));
            Assert.AreEqual("Thu, 08 Aug 2013 02:07:24 +0500", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus05)));
            Assert.AreEqual("Thu, 08 Aug 2013 03:07:24 +0600", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus06)));
            Assert.AreEqual("Thu, 08 Aug 2013 04:07:24 +0700", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus07)));
            Assert.AreEqual("Thu, 08 Aug 2013 05:07:24 +0800", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus08)));
            Assert.AreEqual("Thu, 08 Aug 2013 06:07:24 +0900", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus09)));
            Assert.AreEqual("Thu, 08 Aug 2013 07:07:24 +1000", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus10)));
            Assert.AreEqual("Thu, 08 Aug 2013 08:07:24 +1100", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus11)));
            Assert.AreEqual("Thu, 08 Aug 2013 09:07:24 +1200", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcPlus12)));
            Assert.AreEqual("Wed, 07 Aug 2013 20:07:24 -0100", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus01)));
            Assert.AreEqual("Wed, 07 Aug 2013 19:07:24 -0200", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus02)));
            Assert.AreEqual("Wed, 07 Aug 2013 18:07:24 -0300", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus03)));
            Assert.AreEqual("Wed, 07 Aug 2013 17:07:24 -0400", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus04)));
            Assert.AreEqual("Wed, 07 Aug 2013 16:07:24 -0500", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus05)));
            Assert.AreEqual("Wed, 07 Aug 2013 15:07:24 -0600", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus06)));
            Assert.AreEqual("Wed, 07 Aug 2013 14:07:24 -0700", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus07)));
            Assert.AreEqual("Wed, 07 Aug 2013 13:07:24 -0800", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus08)));
            Assert.AreEqual("Wed, 07 Aug 2013 12:07:24 -0900", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus09)));
            Assert.AreEqual("Wed, 07 Aug 2013 11:07:24 -1000", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus10)));
            Assert.AreEqual("Wed, 07 Aug 2013 10:07:24 -1100", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus11)));
            Assert.AreEqual("Wed, 07 Aug 2013 09:07:24 -1200", Rfc822Utils.ToString(TimeZoneInfo.ConvertTime(reference1, utcMinus12)));

        }

        [TestMethod]
        public void DateTimeOffsetToRfc822() {

#pragma warning disable 618

            // Initialize some reference timestamps
            DateTimeOffset reference1 = new DateTime(2013, 08, 07, 21, 07, 24, DateTimeKind.Utc);
            DateTimeOffset reference2 = new DateTime(2016, 10, 07, 17, 33, 38, DateTimeKind.Utc);

            // Universal time
            Assert.AreEqual("Wed, 07 Aug 2013 21:07:24 +0000", TimeUtils.ToRfc822(reference1));
            Assert.AreEqual("Fri, 07 Oct 2016 17:33:38 +0000", TimeUtils.ToRfc822(reference2));

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
            Assert.AreEqual("Wed, 07 Aug 2013 22:07:24 +0100", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcPlus01)));
            Assert.AreEqual("Wed, 07 Aug 2013 23:07:24 +0200", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcPlus02)));
            Assert.AreEqual("Thu, 08 Aug 2013 00:07:24 +0300", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcPlus03)));
            Assert.AreEqual("Thu, 08 Aug 2013 01:07:24 +0400", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcPlus04)));
            Assert.AreEqual("Thu, 08 Aug 2013 02:07:24 +0500", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcPlus05)));
            Assert.AreEqual("Thu, 08 Aug 2013 03:07:24 +0600", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcPlus06)));
            Assert.AreEqual("Thu, 08 Aug 2013 04:07:24 +0700", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcPlus07)));
            Assert.AreEqual("Thu, 08 Aug 2013 05:07:24 +0800", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcPlus08)));
            Assert.AreEqual("Thu, 08 Aug 2013 06:07:24 +0900", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcPlus09)));
            Assert.AreEqual("Thu, 08 Aug 2013 07:07:24 +1000", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcPlus10)));
            Assert.AreEqual("Thu, 08 Aug 2013 08:07:24 +1100", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcPlus11)));
            Assert.AreEqual("Thu, 08 Aug 2013 09:07:24 +1200", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcPlus12)));
            Assert.AreEqual("Wed, 07 Aug 2013 20:07:24 -0100", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcMinus01)));
            Assert.AreEqual("Wed, 07 Aug 2013 19:07:24 -0200", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcMinus02)));
            Assert.AreEqual("Wed, 07 Aug 2013 18:07:24 -0300", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcMinus03)));
            Assert.AreEqual("Wed, 07 Aug 2013 17:07:24 -0400", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcMinus04)));
            Assert.AreEqual("Wed, 07 Aug 2013 16:07:24 -0500", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcMinus05)));
            Assert.AreEqual("Wed, 07 Aug 2013 15:07:24 -0600", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcMinus06)));
            Assert.AreEqual("Wed, 07 Aug 2013 14:07:24 -0700", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcMinus07)));
            Assert.AreEqual("Wed, 07 Aug 2013 13:07:24 -0800", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcMinus08)));
            Assert.AreEqual("Wed, 07 Aug 2013 12:07:24 -0900", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcMinus09)));
            Assert.AreEqual("Wed, 07 Aug 2013 11:07:24 -1000", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcMinus10)));
            Assert.AreEqual("Wed, 07 Aug 2013 10:07:24 -1100", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcMinus11)));
            Assert.AreEqual("Wed, 07 Aug 2013 09:07:24 -1200", TimeUtils.ToRfc822(TimeZoneInfo.ConvertTime(reference1, utcMinus12)));

#pragma warning restore 618

        }

        [TestMethod]
        public void Parse() {

            // Initialize some reference timestamps
            DateTimeOffset reference1 = new DateTime(2013, 08, 07, 21, 07, 24, DateTimeKind.Utc);
            DateTimeOffset reference2 = new DateTime(2016, 10, 07, 17, 33, 38, DateTimeKind.Utc);

            // Universal time (reference 1)
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 21:07:24 GMT"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 21:07:24 UT"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 21:07:24 UTC"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 7 Aug 2013 21:07:24 GMT"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 7 Aug 2013 21:07:24 UT"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 7 Aug 2013 21:07:24 UTC"));

            // Universal time (reference 2)
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 17:33:38 GMT"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 17:33:38 UT"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 17:33:38 UTC"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 7 Oct 2016 17:33:38 GMT"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 7 Oct 2016 17:33:38 UT"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 7 Oct 2016 17:33:38 UTC"));

            // North American time zones (reference 1)
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 16:07:24 EST")); //  -0500
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 17:07:24 EDT")); //  -0400
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 15:07:24 CST")); //  -0600
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 16:07:24 CDT")); //  -0500
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 14:07:24 MST")); //  -0700
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 15:07:24 MDT")); //  -0600
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 13:07:24 PST")); //  -0800
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 14:07:24 PDT")); //  -0700

            // North American time zones (reference 2)
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 12:33:38 EST")); //  -0500
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 13:33:38 EDT")); //  -0400
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 11:33:38 CST")); //  -0600
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 12:33:38 CDT")); //  -0500
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 10:33:38 MST")); //  -0700
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 11:33:38 MDT")); //  -0600
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 09:33:38 PST")); //  -0800
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 10:33:38 PDT")); //  -0700

            // Letter time zones (reference 1)
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 20:07:24 A")); // -0100
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 19:07:24 B")); // -0200
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 18:07:24 C")); // -0300
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 17:07:24 D")); // -0400
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 16:07:24 E")); // -0500
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 15:07:24 F")); // -0600
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 14:07:24 G")); // -0700
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 13:07:24 H")); // -0800
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 12:07:24 I")); // -0900
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 11:07:24 K")); // -1000
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 10:07:24 L")); // -1100
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 09:07:24 M")); // -1200
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 22:07:24 N")); // +0100
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 23:07:24 O")); // +0200
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 00:07:24 P")); // +0300
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 01:07:24 Q")); // +0400
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 02:07:24 R")); // +0500
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 03:07:24 S")); // +0600
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 04:07:24 T")); // +0700
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 05:07:24 U")); // +0800
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 06:07:24 V")); // +0900
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 07:07:24 W")); // +1000
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 08:07:24 X")); // +1100
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 09:07:24 Y")); // +1200
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 21:07:24 Z")); // +0000

            // Letter time zones (reference 2)
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 16:33:38 A")); // -0100
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 15:33:38 B")); // -0200
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 14:33:38 C")); // -0300
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 13:33:38 D")); // -0400
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 12:33:38 E")); // -0500
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 11:33:38 F")); // -0600
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 10:33:38 G")); // -0700
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 09:33:38 H")); // -0800
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 08:33:38 I")); // -0900
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 07:33:38 K")); // -1000
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 06:33:38 L")); // -1100
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 05:33:38 M")); // -1200
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 18:33:38 N")); // +0100
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 19:33:38 O")); // +0200
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 20:33:38 P")); // +0300
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 21:33:38 Q")); // +0400
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 22:33:38 R")); // +0500
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 23:33:38 S")); // +0600
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Sat, 08 Oct 2016 00:33:38 T")); // +0700
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Sat, 08 Oct 2016 01:33:38 U")); // +0800
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Sat, 08 Oct 2016 02:33:38 V")); // +0900
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Sat, 08 Oct 2016 03:33:38 W")); // +1000
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Sat, 08 Oct 2016 04:33:38 X")); // +1100
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Sat, 08 Oct 2016 05:33:38 Y")); // +1200
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 17:33:38 Z")); // +0000

            // Offset (reference 1)
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 20:07:24 -0100"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 19:07:24 -0200"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 18:07:24 -0300"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 17:07:24 -0400"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 16:07:24 -0500"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 15:07:24 -0600"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 14:07:24 -0700"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 13:07:24 -0800"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 12:07:24 -0900"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 11:07:24 -1000"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 10:07:24 -1100"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 09:07:24 -1200"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 22:07:24 +0100"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Wed, 07 Aug 2013 23:07:24 +0200"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 00:07:24 +0300"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 01:07:24 +0400"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 02:07:24 +0500"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 03:07:24 +0600"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 04:07:24 +0700"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 05:07:24 +0800"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 06:07:24 +0900"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 07:07:24 +1000"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 08:07:24 +1100"));
            Assert.AreEqual(reference1, Rfc822Utils.Parse("Thu, 08 Aug 2013 09:07:24 +1200"));

            // Offset (reference 2)
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 16:33:38 -0100"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 15:33:38 -0200"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 14:33:38 -0300"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 13:33:38 -0400"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 12:33:38 -0500"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 11:33:38 -0600"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 10:33:38 -0700"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 09:33:38 -0800"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 08:33:38 -0900"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 07:33:38 -1000"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 06:33:38 -1100"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 05:33:38 -1200"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 18:33:38 +0100"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 19:33:38 +0200"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 20:33:38 +0300"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 21:33:38 +0400"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 22:33:38 +0500"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Fri, 07 Oct 2016 23:33:38 +0600"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Sat, 08 Oct 2016 00:33:38 +0700"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Sat, 08 Oct 2016 01:33:38 +0800"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Sat, 08 Oct 2016 02:33:38 +0900"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Sat, 08 Oct 2016 03:33:38 +1000"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Sat, 08 Oct 2016 04:33:38 +1100"));
            Assert.AreEqual(reference2, Rfc822Utils.Parse("Sat, 08 Oct 2016 05:33:38 +1200"));

        }

        [TestMethod]
        public void ParseLegacy() {

#pragma warning disable 618

            // Initialize some reference timestamps
            DateTimeOffset reference1 = new DateTime(2013, 08, 07, 21, 07, 24, DateTimeKind.Utc);
            DateTimeOffset reference2 = new DateTime(2016, 10, 07, 17, 33, 38, DateTimeKind.Utc);

            // Universal time (reference 1)
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 21:07:24 GMT"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 21:07:24 UT"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 21:07:24 UTC"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 7 Aug 2013 21:07:24 GMT"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 7 Aug 2013 21:07:24 UT"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 7 Aug 2013 21:07:24 UTC"));

            // Universal time (reference 2)
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 17:33:38 GMT"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 17:33:38 UT"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 17:33:38 UTC"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 7 Oct 2016 17:33:38 GMT"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 7 Oct 2016 17:33:38 UT"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 7 Oct 2016 17:33:38 UTC"));

            // North American time zones (reference 1)
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 16:07:24 EST")); //  -0500
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 17:07:24 EDT")); //  -0400
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 15:07:24 CST")); //  -0600
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 16:07:24 CDT")); //  -0500
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 14:07:24 MST")); //  -0700
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 15:07:24 MDT")); //  -0600
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 13:07:24 PST")); //  -0800
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 14:07:24 PDT")); //  -0700

            // North American time zones (reference 2)
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 12:33:38 EST")); //  -0500
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 13:33:38 EDT")); //  -0400
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 11:33:38 CST")); //  -0600
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 12:33:38 CDT")); //  -0500
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 10:33:38 MST")); //  -0700
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 11:33:38 MDT")); //  -0600
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 09:33:38 PST")); //  -0800
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 10:33:38 PDT")); //  -0700

            // Letter time zones (reference 1)
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 20:07:24 A")); // -0100
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 19:07:24 B")); // -0200
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 18:07:24 C")); // -0300
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 17:07:24 D")); // -0400
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 16:07:24 E")); // -0500
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 15:07:24 F")); // -0600
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 14:07:24 G")); // -0700
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 13:07:24 H")); // -0800
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 12:07:24 I")); // -0900
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 11:07:24 K")); // -1000
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 10:07:24 L")); // -1100
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 09:07:24 M")); // -1200
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 22:07:24 N")); // +0100
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 23:07:24 O")); // +0200
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 00:07:24 P")); // +0300
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 01:07:24 Q")); // +0400
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 02:07:24 R")); // +0500
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 03:07:24 S")); // +0600
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 04:07:24 T")); // +0700
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 05:07:24 U")); // +0800
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 06:07:24 V")); // +0900
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 07:07:24 W")); // +1000
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 08:07:24 X")); // +1100
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 09:07:24 Y")); // +1200
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 21:07:24 Z")); // +0000

            // Letter time zones (reference 2)
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 16:33:38 A")); // -0100
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 15:33:38 B")); // -0200
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 14:33:38 C")); // -0300
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 13:33:38 D")); // -0400
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 12:33:38 E")); // -0500
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 11:33:38 F")); // -0600
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 10:33:38 G")); // -0700
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 09:33:38 H")); // -0800
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 08:33:38 I")); // -0900
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 07:33:38 K")); // -1000
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 06:33:38 L")); // -1100
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 05:33:38 M")); // -1200
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 18:33:38 N")); // +0100
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 19:33:38 O")); // +0200
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 20:33:38 P")); // +0300
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 21:33:38 Q")); // +0400
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 22:33:38 R")); // +0500
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 23:33:38 S")); // +0600
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Sat, 08 Oct 2016 00:33:38 T")); // +0700
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Sat, 08 Oct 2016 01:33:38 U")); // +0800
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Sat, 08 Oct 2016 02:33:38 V")); // +0900
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Sat, 08 Oct 2016 03:33:38 W")); // +1000
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Sat, 08 Oct 2016 04:33:38 X")); // +1100
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Sat, 08 Oct 2016 05:33:38 Y")); // +1200
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 17:33:38 Z")); // +0000

            // Offset (reference 1)
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 20:07:24 -0100"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 19:07:24 -0200"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 18:07:24 -0300"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 17:07:24 -0400"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 16:07:24 -0500"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 15:07:24 -0600"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 14:07:24 -0700"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 13:07:24 -0800"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 12:07:24 -0900"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 11:07:24 -1000"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 10:07:24 -1100"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 09:07:24 -1200"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 22:07:24 +0100"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Wed, 07 Aug 2013 23:07:24 +0200"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 00:07:24 +0300"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 01:07:24 +0400"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 02:07:24 +0500"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 03:07:24 +0600"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 04:07:24 +0700"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 05:07:24 +0800"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 06:07:24 +0900"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 07:07:24 +1000"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 08:07:24 +1100"));
            Assert.AreEqual(reference1, TimeUtils.Rfc822ToDateTimeOffset("Thu, 08 Aug 2013 09:07:24 +1200"));

            // Offset (reference 2)
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 16:33:38 -0100"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 15:33:38 -0200"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 14:33:38 -0300"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 13:33:38 -0400"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 12:33:38 -0500"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 11:33:38 -0600"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 10:33:38 -0700"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 09:33:38 -0800"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 08:33:38 -0900"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 07:33:38 -1000"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 06:33:38 -1100"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 05:33:38 -1200"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 18:33:38 +0100"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 19:33:38 +0200"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 20:33:38 +0300"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 21:33:38 +0400"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 22:33:38 +0500"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Fri, 07 Oct 2016 23:33:38 +0600"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Sat, 08 Oct 2016 00:33:38 +0700"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Sat, 08 Oct 2016 01:33:38 +0800"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Sat, 08 Oct 2016 02:33:38 +0900"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Sat, 08 Oct 2016 03:33:38 +1000"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Sat, 08 Oct 2016 04:33:38 +1100"));
            Assert.AreEqual(reference2, TimeUtils.Rfc822ToDateTimeOffset("Sat, 08 Oct 2016 05:33:38 +1200"));

#pragma warning restore 618

        }

    }

}