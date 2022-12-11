using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.Time {

    [TestClass]
    public class EssentialsDateRangeTests {

        [TestMethod]
        public new void ToString() {

            EssentialsDate date1 = new EssentialsDate(2022, 10, 1);
            EssentialsDate date2 = new EssentialsDate(2022, 12, 31);

            EssentialsDateRange range1 = new EssentialsDateRange(date1, date2);
            EssentialsDateRange range2 = new EssentialsDateRange(date2, date1);

            Assert.AreEqual("2022-10-01", date1.ToString());
            Assert.AreEqual("2022-12-31", date2.ToString());
            Assert.AreEqual("2022-10-01__2022-12-31", range1.ToString());
            Assert.AreEqual("2022-12-31__2022-10-01", range2.ToString());

        }

        [TestMethod]
        public void Parse() {

            EssentialsDateRange range1 = EssentialsDateRange.Parse(null);
            EssentialsDateRange range2 = EssentialsDateRange.Parse(string.Empty);
            EssentialsDateRange range3 = EssentialsDateRange.Parse("2022-10-01__2022-12-31");
            EssentialsDateRange range4 = EssentialsDateRange.Parse("2022-12-31__2022-10-01");

            Assert.IsNull(range1);
            Assert.IsNull(range2);

            Assert.IsNotNull(range3);
            Assert.IsFalse(range3.IsReverse);
            Assert.AreEqual("2022-10-01", range3.Days[0].ToString());
            Assert.AreEqual("2022-12-31", range3.Days[range3.Days.Length - 1].ToString());
            Assert.AreEqual("2022-10-01__2022-12-31", range3.ToString());

            Assert.IsNotNull(range4);
            Assert.IsTrue(range4.IsReverse);
            Assert.AreEqual("2022-12-31", range4.Days[0].ToString());
            Assert.AreEqual("2022-10-01", range4.Days[range4.Days.Length - 1].ToString());
            Assert.AreEqual("2022-12-31__2022-10-01", range4.ToString());

        }

    }

}