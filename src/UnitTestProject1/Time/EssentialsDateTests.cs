using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;
// ReSharper disable ExpressionIsAlwaysNull

#pragma warning disable 618

namespace UnitTestProject1.Time {

    [TestClass]
    public class EssentialsDateTests {

        [TestMethod]
        public void YearAndDay() {

            EssentialsDate a = new EssentialsDate(2019, 1, 1);
            EssentialsDate b = new EssentialsDate(2019, 10, 20);
            EssentialsDate c = new EssentialsDate(2019, 12, 31);

            Assert.AreEqual(2019001, a.YearAndDay);
            Assert.AreEqual(2019293, b.YearAndDay);
            Assert.AreEqual(2019365, c.YearAndDay);

        }

        [TestMethod]
        public void TryParse1() {

            bool success1 = EssentialsDate.TryParse("2019-08-17", out EssentialsDate result1);
            bool success2 = EssentialsDate.TryParse("08/17/2019", out EssentialsDate result2);
            bool success3 = EssentialsDate.TryParse("17/08/2019", out EssentialsDate result3);

            Assert.AreEqual(true, success1, "#1");
            Assert.AreEqual(true, success2, "#2");
            Assert.AreEqual(false, success3, "#3");

            Assert.AreEqual(2019, result1.Year);
            Assert.AreEqual(8, result1.Month);
            Assert.AreEqual(17, result1.Day);

            Assert.AreEqual(2019, result2.Year);
            Assert.AreEqual(8, result2.Month);
            Assert.AreEqual(17, result2.Day);

            Assert.IsNull(result3);

        }

        [TestMethod]
        public void TryParse() {

            bool success1 = EssentialsDate.TryParse("2019-08-17", CultureInfo.InvariantCulture, DateTimeStyles.None, out EssentialsDate result1);
            bool success2 = EssentialsDate.TryParse("08/17/2019", CultureInfo.InvariantCulture, DateTimeStyles.None, out EssentialsDate result2);
            bool success3 = EssentialsDate.TryParse("17/08/2019", CultureInfo.InvariantCulture, DateTimeStyles.None, out EssentialsDate result3);

            Assert.AreEqual(true, success1, "#1");
            Assert.AreEqual(true, success2, "#2");
            Assert.AreEqual(false, success3, "#3");

            Assert.AreEqual(2019, result1.Year);
            Assert.AreEqual(8, result1.Month);
            Assert.AreEqual(17, result1.Day);

            Assert.AreEqual(2019, result2.Year);
            Assert.AreEqual(8, result2.Month);
            Assert.AreEqual(17, result2.Day);

            Assert.IsNull(result3);

        }

        [TestMethod]
        public void TryParseDanish() {

            CultureInfo culture = CultureInfo.GetCultureInfo("da-DK");

            bool success1 = EssentialsDate.TryParse("2019-08-17", culture, DateTimeStyles.None, out EssentialsDate result1);
            bool success2 = EssentialsDate.TryParse("08/17/2019", culture, DateTimeStyles.None, out EssentialsDate result2);
            bool success3 = EssentialsDate.TryParse("17/08/2019", culture, DateTimeStyles.None, out EssentialsDate result3);

            Assert.AreEqual(true, success1, "#1");
            Assert.AreEqual(false, success2, "#2");
            Assert.AreEqual(true, success3, "#3");

            Assert.AreEqual(2019, result1.Year);
            Assert.AreEqual(8, result1.Month);
            Assert.AreEqual(17, result1.Day);

            Assert.IsNull(result2);

            Assert.AreEqual(2019, result3.Year);
            Assert.AreEqual(8, result3.Month);
            Assert.AreEqual(17, result3.Day);

        }

        [TestMethod]
        public void TryParseProvider() {

            CultureInfo culture = new CultureInfo("en-US");

            bool success1 = EssentialsDate.TryParse("2019-08-17", culture, DateTimeStyles.None, out EssentialsDate result1);
            bool success2 = EssentialsDate.TryParse("08/17/2019", culture, DateTimeStyles.None, out EssentialsDate result2);

            Assert.AreEqual(true, success1);
            Assert.AreEqual(true, success2);

            Assert.AreEqual(2019, result1.Year);
            Assert.AreEqual(8, result1.Month);
            Assert.AreEqual(17, result1.Day);

            Assert.AreEqual(2019, result2.Year);
            Assert.AreEqual(8, result2.Month);
            Assert.AreEqual(17, result2.Day);

        }

        [TestMethod]
        public void TryParseExact() {

            bool success1 = EssentialsDate.TryParseExact("2019-08-17", "yyyy-MM-dd", null, DateTimeStyles.None, out EssentialsDate result1);
            bool success2 = EssentialsDate.TryParseExact("08/17/2019", "MM/dd/yyyy", null, DateTimeStyles.None, out EssentialsDate result2);

            Assert.AreEqual(true, success1);
            Assert.AreEqual(true, success2);

            Assert.AreEqual(2019, result1.Year);
            Assert.AreEqual(8, result1.Month);
            Assert.AreEqual(17, result1.Day);

            Assert.AreEqual(2019, result2.Year);
            Assert.AreEqual(8, result2.Month);
            Assert.AreEqual(17, result2.Day);

        }

        [TestMethod]
        public void TryParseExactArray() {

            bool success1 = EssentialsDate.TryParseExact("2019-08-17", new[] { "yyyy-MM-dd" }, null, DateTimeStyles.None, out EssentialsDate result1);
            bool success2 = EssentialsDate.TryParseExact("08/17/2019", new[] { "MM/dd/yyyy" }, null, DateTimeStyles.None, out EssentialsDate result2);

            Assert.AreEqual(true, success1);
            Assert.AreEqual(true, success2);

            Assert.AreEqual(2019, result1.Year);
            Assert.AreEqual(8, result1.Month);
            Assert.AreEqual(17, result1.Day);

            Assert.AreEqual(2019, result2.Year);
            Assert.AreEqual(8, result2.Month);
            Assert.AreEqual(17, result2.Day);

        }

        [TestMethod]
        public void CompareTo() {


            EssentialsDate a = new EssentialsDate(2012, 7, 30);
            EssentialsDate b = new EssentialsDate(2019, 8, 17);
            EssentialsDate c = null;

            var samples = new[] {
                new { Left = a, Right = b, Expected = 1.CompareTo(2) },
                new { Left = a, Right = a, Expected = 2.CompareTo(2) },
                new { Left = b, Right = a, Expected = 2.CompareTo(1) },
                new { Left = a, Right = c, Expected = 1 }
            };

            foreach (var sample in samples) {

                int result = sample.Left.CompareTo(sample.Right);

                Assert.AreEqual(sample.Expected, result);

            }

        }

        [TestMethod]
        public void Equals() {

            EssentialsDate a = new EssentialsDate(2012, 7, 30);
            EssentialsDate b = new EssentialsDate(2019, 8, 17);
            EssentialsDate c = null;

            var samples = new[] {
                new { Left = a, Right = a, Expected = true },
                new { Left = a, Right = b, Expected = false },
                new { Left = a, Right = c, Expected = false },
                new { Left = a, Right = c, Expected = false }
            };

            foreach (var sample in samples) {

                bool result = sample.Left.Equals(sample.Right);

                Assert.AreEqual(sample.Expected, result);

            }

        }

        [TestMethod]
        public void OperatorEquals() {

            EssentialsDate a = new EssentialsDate(2012, 7, 30);
            EssentialsDate b = new EssentialsDate(2019, 8, 17);
            EssentialsDate c = null;

            var samples = new[] {
                new { Left = a, Right = a, Expected = true },
                new { Left = a, Right = b, Expected = false },
                new { Left = a, Right = c, Expected = false },
                new { Left = c, Right = a, Expected = false },
                new { Left = c, Right = c, Expected = true }
            };

            int i = 1;
            foreach (var sample in samples) {
                bool result = sample.Left == sample.Right;
                Assert.AreEqual(sample.Expected, result, "#" + i++);
            }

        }

        [TestMethod]
        public void OperatorLessThan() {

            EssentialsDate a = new EssentialsDate(2012, 7, 30);
            EssentialsDate b = new EssentialsDate(2019, 8, 17);
            EssentialsDate c = null;

            var samples = new[] {
                new { Left = a, Right = a, Expected = false },
                new { Left = a, Right = b, Expected = true },
                new { Left = b, Right = a, Expected = false },
                new { Left = a, Right = c, Expected = false },
                new { Left = c, Right = a, Expected = true },
                new { Left = c, Right = c, Expected = false }
            };

            int i = 1;
            foreach (var sample in samples) {
                bool result = sample.Left < sample.Right;
                Assert.AreEqual(sample.Expected, result, "#" + i++);
            }

        }

        [TestMethod]
        public void OperatorLessThanOrEqualTo() {

            EssentialsDate a = new EssentialsDate(2012, 7, 30);
            EssentialsDate b = new EssentialsDate(2019, 8, 17);
            EssentialsDate c = null;

            var samples = new[] {
                new { Left = a, Right = a, Expected = true },
                new { Left = a, Right = b, Expected = true },
                new { Left = b, Right = a, Expected = false },
                new { Left = a, Right = c, Expected = false },
                new { Left = c, Right = a, Expected = true },
                new { Left = c, Right = c, Expected = true }
            };

            int i = 1;
            foreach (var sample in samples) {
                bool result = sample.Left <= sample.Right;
                Assert.AreEqual(sample.Expected, result, "#" + i++);
            }

        }

        [TestMethod]
        public void OperatorGreatorThan() {

            EssentialsDate a = new EssentialsDate(2012, 7, 30);
            EssentialsDate b = new EssentialsDate(2019, 8, 17);
            EssentialsDate c = null;

            var samples = new[] {
                new { Left = a, Right = a, Expected = false },
                new { Left = a, Right = b, Expected = false },
                new { Left = b, Right = a, Expected = true },
                new { Left = a, Right = c, Expected = true },
                new { Left = c, Right = a, Expected = false },
                new { Left = c, Right = c, Expected = false }
            };

            int i = 1;
            foreach (var sample in samples) {
                bool result = sample.Left > sample.Right;
                Assert.AreEqual(sample.Expected, result, "#" + i++);
            }

        }

        [TestMethod]
        public void OperatorGreaterThanOrEqualTo() {

            EssentialsDate a = new EssentialsDate(2012, 7, 30);
            EssentialsDate b = new EssentialsDate(2019, 8, 17);
            EssentialsDate c = null;

            var samples = new[] {
                new { Left = a, Right = a, Expected = true },
                new { Left = a, Right = b, Expected = false },
                new { Left = b, Right = a, Expected = true },
                new { Left = a, Right = c, Expected = true },
                new { Left = c, Right = a, Expected = false },
                new { Left = c, Right = c, Expected = true }
            };

            int i = 1;
            foreach (var sample in samples) {
                bool result = sample.Left >= sample.Right;
                Assert.AreEqual(sample.Expected, result, "#" + i++);
            }

        }

        public void GetDaysBetween() {

            var jan1 = new EssentialsDate(2019, 1, 1);
            var feb1 = new EssentialsDate(2019, 1, 1);

            Assert.AreEqual(31, EssentialsDate.GetDaysBetween(jan1, feb1));
            Assert.AreEqual(-31, EssentialsDate.GetDaysBetween(feb1, jan1));

        }

        [TestMethod]
        public void GetQuarter() {

            EssentialsDate time1 = new EssentialsDate(2022, 3, 24);
            EssentialsDate time2 = new EssentialsDate(2022, 3, 31);

            EssentialsDate time3 = new EssentialsDate(2022, 10, 27);
            EssentialsDate time4 = new EssentialsDate(2022, 11, 3);

            Assert.AreEqual(1, time1.Quarter, "#1");
            Assert.AreEqual(1, time2.Quarter, "#2");
            Assert.AreEqual(4, time3.Quarter, "#3");
            Assert.AreEqual(4, time4.Quarter, "#4");

        }

        [TestMethod]
        public void GetStartOfQuarter() {

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsDate time1 = new EssentialsDate(2022, 3, 24);
            EssentialsDate time2 = new EssentialsDate(2022, 3, 31);

            EssentialsDate time3 = new EssentialsDate(2022, 10, 27);
            EssentialsDate time4 = new EssentialsDate(2022, 11, 3);

            EssentialsTime start1 = time1.GetStartOfQuarter(timeZone);
            EssentialsTime start2 = time2.GetStartOfQuarter(timeZone);

            EssentialsTime start3 = time3.GetStartOfQuarter(timeZone);
            EssentialsTime start4 = time4.GetStartOfQuarter(timeZone);

            Assert.AreEqual("2022-01-01T00:00:00.000+01:00", start1.Iso8601);
            Assert.AreEqual("2022-01-01T00:00:00.000+01:00", start2.Iso8601);

            Assert.AreEqual("2022-10-01T00:00:00.000+02:00", start3.Iso8601);
            Assert.AreEqual("2022-10-01T00:00:00.000+02:00", start4.Iso8601);

        }

        [TestMethod]
        public void GetEndOfQuarter() {

            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsDate time1 = new EssentialsDate(2022, 3, 24);
            EssentialsDate time2 = new EssentialsDate(2022, 3, 31);

            EssentialsDate time3 = new EssentialsDate(2022, 10, 27);
            EssentialsDate time4 = new EssentialsDate(2022, 11, 3);

            EssentialsTime end1 = time1.GetEndOfQuarter(timeZone);
            EssentialsTime end2 = time2.GetEndOfQuarter(timeZone);

            EssentialsTime end3 = time3.GetEndOfQuarter(timeZone);
            EssentialsTime end4 = time4.GetEndOfQuarter(timeZone);

            Assert.AreEqual("2022-03-31T23:59:59.999+02:00", end1.Iso8601);
            Assert.AreEqual("2022-03-31T23:59:59.999+02:00", end2.Iso8601);

            Assert.AreEqual("2022-12-31T23:59:59.999+01:00", end3.Iso8601);
            Assert.AreEqual("2022-12-31T23:59:59.999+01:00", end4.Iso8601);

        }

    }

}

#pragma warning restore 618