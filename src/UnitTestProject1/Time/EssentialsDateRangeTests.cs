using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;
// ReSharper disable ExpressionIsAlwaysNull

#pragma warning disable 618

namespace UnitTestProject1.Time {

    [TestClass]
    public class EssentialsDateRangeTests {

        [TestMethod]
        public void Default() {

            EssentialsDate start = new EssentialsDate(2019, 10, 14);
            EssentialsDate end = new EssentialsDate(2019, 10, 20);

            var range = new EssentialsDateRange(start, end);

            Assert.AreEqual(false, range.IsReverse, "# reverse");

            Assert.AreEqual(7, range.Days.Length, "# length");

            Assert.AreEqual("2019-10-14", range.Days[0].Iso8601, "# index 0");
            Assert.AreEqual("2019-10-15", range.Days[1].Iso8601, "# index 1");
            Assert.AreEqual("2019-10-16", range.Days[2].Iso8601, "# index 2");
            Assert.AreEqual("2019-10-17", range.Days[3].Iso8601, "# index 3");
            Assert.AreEqual("2019-10-18", range.Days[4].Iso8601, "# index 4");
            Assert.AreEqual("2019-10-19", range.Days[5].Iso8601, "# index 5");
            Assert.AreEqual("2019-10-20", range.Days[6].Iso8601, "# index 6");

        }

        [TestMethod]
        public void Reverse() {

            EssentialsDate start = new EssentialsDate(2019, 10, 20);
            EssentialsDate end = new EssentialsDate(2019, 10, 14);

            var range = new EssentialsDateRange(start, end);

            Assert.AreEqual(true, range.IsReverse, "# reverse");

            Assert.AreEqual(7, range.Days.Length, "# length");

            Assert.AreEqual("2019-10-20", range.Days[0].Iso8601, "# index 0");
            Assert.AreEqual("2019-10-19", range.Days[1].Iso8601, "# index 1");
            Assert.AreEqual("2019-10-18", range.Days[2].Iso8601, "# index 2");
            Assert.AreEqual("2019-10-17", range.Days[3].Iso8601, "# index 3");
            Assert.AreEqual("2019-10-16", range.Days[4].Iso8601, "# index 4");
            Assert.AreEqual("2019-10-15", range.Days[5].Iso8601, "# index 5");
            Assert.AreEqual("2019-10-14", range.Days[6].Iso8601, "# index 6");

        }

    }

}

#pragma warning restore 618