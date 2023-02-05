using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.Time {

    [TestClass]
    public class EssentialsWeekRangeTests {

        [TestMethod]
        public new void ToString() {

            EssentialsWeek week1 = new EssentialsWeek(2022, 49);
            EssentialsWeek week2 = new EssentialsWeek(2023, 1);

            EssentialsWeekRange range1 = new EssentialsWeekRange(week1, week2);
            EssentialsWeekRange range2 = new EssentialsWeekRange(week2, week1);

            Assert.AreEqual("2022-W49", week1.ToString());
            Assert.AreEqual("2023-W01", week2.ToString());
            Assert.AreEqual("2022-W49__2023-W01", range1.ToString());
            Assert.AreEqual("2023-W01__2022-W49", range2.ToString());

        }

        [TestMethod]
        public void Parse() {

            EssentialsWeekRange range1 = EssentialsWeekRange.Parse(null);
            EssentialsWeekRange range2 = EssentialsWeekRange.Parse(string.Empty);
            EssentialsWeekRange range3 = EssentialsWeekRange.Parse("2022-W49__2023-W01");
            EssentialsWeekRange range4 = EssentialsWeekRange.Parse("2023-W01__2022-W49");

            Assert.IsNull(range1);
            Assert.IsNull(range2);

            Assert.IsNotNull(range3);
            Assert.IsFalse(range3.IsReverse);
            Assert.AreEqual("2022-W49", range3[0].ToString());
            Assert.AreEqual("2023-W01", range3[range3.Count - 1].ToString());

            Assert.IsNotNull(range4);
            Assert.IsTrue(range4.IsReverse);
            Assert.AreEqual("2023-W01", range4[0].ToString());
            Assert.AreEqual("2022-W49", range4[range4.Count - 1].ToString());

        }

    }

}