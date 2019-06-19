using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

#pragma warning disable 618

namespace UnitTestProject1.Time {

    [TestClass]
    public class EssentialsDateTests {

        [TestMethod]
        public void TryParse() {

            bool success1 = EssentialsDate.TryParse("2019-08-17", out EssentialsDate result1);
            bool success2 = EssentialsDate.TryParse("08/17/2019", out EssentialsDate result2);

            Assert.AreEqual(true, success1);
            Assert.AreEqual(false, success2);

            Assert.AreEqual(2019, result1.Year);
            Assert.AreEqual(8, result1.Month);
            Assert.AreEqual(17, result1.Day);

            Assert.IsNull(result2);

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

            bool success1 = EssentialsDate.TryParseExact("2019-08-17", new [] { "yyyy-MM-dd" }, null, DateTimeStyles.None, out EssentialsDate result1);
            bool success2 = EssentialsDate.TryParseExact("08/17/2019", new [] { "MM/dd/yyyy" }, null, DateTimeStyles.None, out EssentialsDate result2);

            Assert.AreEqual(true, success1);
            Assert.AreEqual(true, success2);

            Assert.AreEqual(2019, result1.Year);
            Assert.AreEqual(8, result1.Month);
            Assert.AreEqual(17, result1.Day);

            Assert.AreEqual(2019, result2.Year);
            Assert.AreEqual(8, result2.Month);
            Assert.AreEqual(17, result2.Day);

        }

    }

}

#pragma warning restore 618