using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.GetAge {

    [TestClass]
    public class EssentialsTimeTests {

        [TestMethod]
        public void DateTime() {

            EssentialsTime t = new EssentialsTime(2019, 9, 14, TimeSpan.Zero);

            DateTime a = new DateTime(2020, 9, 13, 0, 0, 0, DateTimeKind.Utc);
            DateTime b = new DateTime(2020, 9, 14, 0, 0, 0, DateTimeKind.Utc);
            DateTime c = new DateTime(2020, 9, 15, 0, 0, 0, DateTimeKind.Utc);

            Assert.AreEqual(0, TimeUtils.GetAge(t, a));
            Assert.AreEqual(1, TimeUtils.GetAge(t, b));
            Assert.AreEqual(1, TimeUtils.GetAge(t, c));

        }

        [TestMethod]
        public void DateTimeOffset() {

            EssentialsTime t = new EssentialsTime(2019, 9, 14, TimeSpan.Zero);

            DateTimeOffset a = new DateTimeOffset(2020, 9, 13, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset b = new DateTimeOffset(2020, 9, 14, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset c = new DateTimeOffset(2020, 9, 15, 0, 0, 0, TimeSpan.Zero);

            Assert.AreEqual(0, TimeUtils.GetAge(t, a));
            Assert.AreEqual(1, TimeUtils.GetAge(t, b));
            Assert.AreEqual(1, TimeUtils.GetAge(t, c));

        }

        [TestMethod]
        public void EssentialsDate() {

            EssentialsTime t = new EssentialsTime(2019, 9, 14, TimeSpan.Zero);

            EssentialsDate a = new EssentialsDate(2020, 9, 13);
            EssentialsDate b = new EssentialsDate(2020, 9, 14);
            EssentialsDate c = new EssentialsDate(2020, 9, 15);

            Assert.AreEqual(0, TimeUtils.GetAge(t, a));
            Assert.AreEqual(1, TimeUtils.GetAge(t, b));
            Assert.AreEqual(1, TimeUtils.GetAge(t, c));

        }

        [TestMethod]
        public void EssentialsDateTime() {

            EssentialsTime t = new EssentialsTime(2019, 9, 14, TimeSpan.Zero);

            EssentialsDateTime a = new EssentialsDateTime(2020, 9, 13, 0, 0, 0, DateTimeKind.Utc);
            EssentialsDateTime b = new EssentialsDateTime(2020, 9, 14, 0, 0, 0, DateTimeKind.Utc);
            EssentialsDateTime c = new EssentialsDateTime(2020, 9, 15, 0, 0, 0, DateTimeKind.Utc);

            Assert.AreEqual(0, TimeUtils.GetAge(t, a));
            Assert.AreEqual(1, TimeUtils.GetAge(t, b));
            Assert.AreEqual(1, TimeUtils.GetAge(t, c));

        }

        [TestMethod]
        public void EssentialsTime() {

            EssentialsTime t = new EssentialsTime(2019, 9, 14, TimeSpan.Zero);

            EssentialsTime a = new EssentialsTime(2020, 9, 13, TimeSpan.Zero);
            EssentialsTime b = new EssentialsTime(2020, 9, 14, TimeSpan.Zero);
            EssentialsTime c = new EssentialsTime(2020, 9, 15, TimeSpan.Zero);

            Assert.AreEqual(0, TimeUtils.GetAge(t, a));
            Assert.AreEqual(1, TimeUtils.GetAge(t, b));
            Assert.AreEqual(1, TimeUtils.GetAge(t, c));

        }

    }

}