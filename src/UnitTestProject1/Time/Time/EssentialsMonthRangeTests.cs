using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.Time {

    [TestClass]
    public class EssentialsMonthRangeTests {

        [TestMethod]
        public void RangeAscending() {

            EssentialsMonth month1 = new EssentialsMonth(2023, 1);
            EssentialsMonth month8 = new EssentialsMonth(2023, 8);

            EssentialsMonthRange range = new EssentialsMonthRange(month1, month8);

            Assert.IsFalse(range.IsReverse);
            Assert.AreEqual(8, range.Count);

            Assert.AreEqual("2023-01", range[0].ToString());
            Assert.AreEqual("2023-02", range[1].ToString());
            Assert.AreEqual("2023-03", range[2].ToString());
            Assert.AreEqual("2023-04", range[3].ToString());
            Assert.AreEqual("2023-05", range[4].ToString());
            Assert.AreEqual("2023-06", range[5].ToString());
            Assert.AreEqual("2023-07", range[6].ToString());
            Assert.AreEqual("2023-08", range[7].ToString());

        }

        [TestMethod]
        public void RangeDescending() {

            EssentialsMonth month1 = new EssentialsMonth(2023, 1);
            EssentialsMonth month8 = new EssentialsMonth(2023, 8);

            EssentialsMonthRange range = new EssentialsMonthRange(month8, month1);

            Assert.IsTrue(range.IsReverse);
            Assert.AreEqual(8, range.Count);

            Assert.AreEqual("2023-08", range[0].ToString());
            Assert.AreEqual("2023-07", range[1].ToString());
            Assert.AreEqual("2023-06", range[2].ToString());
            Assert.AreEqual("2023-05", range[3].ToString());
            Assert.AreEqual("2023-04", range[4].ToString());
            Assert.AreEqual("2023-03", range[5].ToString());
            Assert.AreEqual("2023-02", range[6].ToString());
            Assert.AreEqual("2023-01", range[7].ToString());

        }

        [TestMethod]
        public void RangeDescendingReverse() {

            EssentialsMonth month1 = new EssentialsMonth(2023, 1);
            EssentialsMonth month8 = new EssentialsMonth(2023, 8);

            EssentialsMonthRange range = new EssentialsMonthRange(month1, month8).Reverse();

            Assert.IsTrue(range.IsReverse);
            Assert.AreEqual(8, range.Count);

            Assert.AreEqual("2023-08", range[0].ToString());
            Assert.AreEqual("2023-07", range[1].ToString());
            Assert.AreEqual("2023-06", range[2].ToString());
            Assert.AreEqual("2023-05", range[3].ToString());
            Assert.AreEqual("2023-04", range[4].ToString());
            Assert.AreEqual("2023-03", range[5].ToString());
            Assert.AreEqual("2023-02", range[6].ToString());
            Assert.AreEqual("2023-01", range[7].ToString());

        }

        [TestMethod]
        public void GetMonths1() {

            EssentialsMonthRange range = new EssentialsMonthRange(2023, 1, 2023, 8);

            Assert.IsFalse(range.IsReverse);
            Assert.AreEqual(8, range.Count);

            Assert.AreEqual("2023-01", range[0].ToString());
            Assert.AreEqual("2023-02", range[1].ToString());
            Assert.AreEqual("2023-03", range[2].ToString());
            Assert.AreEqual("2023-04", range[3].ToString());
            Assert.AreEqual("2023-05", range[4].ToString());
            Assert.AreEqual("2023-06", range[5].ToString());
            Assert.AreEqual("2023-07", range[6].ToString());
            Assert.AreEqual("2023-08", range[7].ToString());

        }

        [TestMethod]
        public void GetMonths2() {

            EssentialsMonthRange range = new EssentialsMonthRange(2022, 8, 2023, 2);

            Assert.IsFalse(range.IsReverse);
            Assert.AreEqual(7, range.Count);

            Assert.AreEqual("2022-08", range[0].ToString());
            Assert.AreEqual("2022-09", range[1].ToString());
            Assert.AreEqual("2022-10", range[2].ToString());
            Assert.AreEqual("2022-11", range[3].ToString());
            Assert.AreEqual("2022-12", range[4].ToString());
            Assert.AreEqual("2023-01", range[5].ToString());
            Assert.AreEqual("2023-02", range[6].ToString());

        }

        [TestMethod]
        public void GetMonths3() {

            EssentialsMonthRange range = new EssentialsMonthRange(2023, 8, 2023, 1);

            Assert.IsTrue(range.IsReverse);
            Assert.AreEqual(8, range.Count);

            Assert.AreEqual("2023-08", range[0].ToString());
            Assert.AreEqual("2023-07", range[1].ToString());
            Assert.AreEqual("2023-06", range[2].ToString());
            Assert.AreEqual("2023-05", range[3].ToString());
            Assert.AreEqual("2023-04", range[4].ToString());
            Assert.AreEqual("2023-03", range[5].ToString());
            Assert.AreEqual("2023-02", range[6].ToString());
            Assert.AreEqual("2023-01", range[7].ToString());

        }

        [TestMethod]
        public void GetMonths4() {

            EssentialsMonthRange range = new EssentialsMonthRange(2023, 2, 2022, 8);

            Assert.IsTrue(range.IsReverse);
            Assert.AreEqual(7, range.Count);

            Assert.AreEqual("2023-02", range[0].ToString());
            Assert.AreEqual("2023-01", range[1].ToString());
            Assert.AreEqual("2022-12", range[2].ToString());
            Assert.AreEqual("2022-11", range[3].ToString());
            Assert.AreEqual("2022-10", range[4].ToString());
            Assert.AreEqual("2022-09", range[5].ToString());
            Assert.AreEqual("2022-08", range[6].ToString());

        }

    }

}