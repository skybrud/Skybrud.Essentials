using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.Swatch;
using System;

namespace UnitTestProject1.Time {

    [TestClass]
    public class SwatchInternetTimeTests {

        [TestMethod]
        public void GetSwatchInternetTime() {

            var t1 = EssentialsTime.FromUnixTimeSeconds(1605361960);
            var r1 = (int)SwatchUtils.ToDouble(t1);

            var t2 = new DateTime(2020, 11, 14, 13, 52, 40, DateTimeKind.Utc);
            var r2 = (int)SwatchUtils.ToDouble(t2);

            var t3 = new DateTimeOffset(2020, 11, 14, 14, 52, 40, TimeSpan.FromHours(1));
            var r3 = (int)SwatchUtils.ToDouble(t3);

            var t4 = EssentialsTime.FromUnixTimeSeconds(1597646100);
            var r4 = (int)SwatchUtils.ToDouble(t4);

            var t5 = new DateTime(2020, 8, 17, 6, 35, 00, DateTimeKind.Utc);
            var r5 = (int)SwatchUtils.ToDouble(t5);

            var t6 = new DateTimeOffset(2020, 8, 17, 8, 35, 00, TimeSpan.FromHours(2));
            var r6 = (int)SwatchUtils.ToDouble(t6);

            Assert.AreEqual(619, r1, "#1");
            Assert.AreEqual(619, r2, "#2");
            Assert.AreEqual(619, r3, "#3");

            Assert.AreEqual(315, r4, "#1");
            Assert.AreEqual(315, r5, "#2");
            Assert.AreEqual(315, r6, "#3");

        }

        [TestMethod]
        public void ParseSwatchInternetTime() {

            // Notice: A bit of the precision is lost in the conversions, so the seconds doesn't match the cases in the test above.

            Assert.AreEqual("07:33:36", SwatchUtils.ToTimeSpan(315).ToString("hh\\:mm\\:ss"), "#1");

            Assert.AreEqual("14:51:21", SwatchUtils.ToTimeSpan(619).ToString("hh\\:mm\\:ss"), "#2");

        }

        [TestMethod]
        public void FromSwatchInternetTime() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            var r1 = EssentialsTime.FromSwatchInternetTime(2020, 8, 17, 315, utc);
            var r2 = EssentialsTime.FromSwatchInternetTime(2020, 8, 17, 315, romance);

            var r3 = EssentialsTime.FromSwatchInternetTime(new EssentialsDate(2020, 8, 17), 315, utc);
            var r4 = EssentialsTime.FromSwatchInternetTime(new EssentialsDate(2020, 8, 17), 315, romance);

            var r5 = EssentialsTime.FromSwatchInternetTime(2020, 11, 14, 619, utc);
            var r6 = EssentialsTime.FromSwatchInternetTime(2020, 11, 14, 619, romance);

            var r7 = EssentialsTime.FromSwatchInternetTime(new EssentialsDate(2020, 11, 14), 619, utc);
            var r8 = EssentialsTime.FromSwatchInternetTime(new EssentialsDate(2020, 11, 14), 619, romance);

            Assert.AreEqual("2020-08-17T06:33:36.000Z", r1.Iso8601, "#1");
            Assert.AreEqual("2020-08-17T08:33:36.000+02:00", r2.Iso8601, "#2");

            Assert.AreEqual("2020-08-17T06:33:36.000Z", r3.Iso8601, "#1");
            Assert.AreEqual("2020-08-17T08:33:36.000+02:00", r4.Iso8601, "#2");

            Assert.AreEqual("2020-11-14T13:51:21.600Z", r5.Iso8601, "#5");
            Assert.AreEqual("2020-11-14T14:51:21.600+01:00", r6.Iso8601, "#6");

            Assert.AreEqual("2020-11-14T13:51:21.600Z", r7.Iso8601, "#7");
            Assert.AreEqual("2020-11-14T14:51:21.600+01:00", r8.Iso8601, "#8");

        }

    }

}