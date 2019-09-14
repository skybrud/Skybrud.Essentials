﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.GetAge {

    [TestClass]
    public class EssentialsDateTimeTests {

        [TestMethod]
        public void DateTime() {

            EssentialsDateTime t = new EssentialsDateTime(2019, 9, 14);

            DateTime a = new DateTime(2020, 9, 13);
            DateTime b = new DateTime(2020, 9, 14);
            DateTime c = new DateTime(2020, 9, 15);

            Assert.AreEqual(0, TimeUtils.GetAge(t, a));
            Assert.AreEqual(1, TimeUtils.GetAge(t, b));
            Assert.AreEqual(1, TimeUtils.GetAge(t, c));

        }

        [TestMethod]
        public void DateTimeOffset() {

            EssentialsDateTime t = new EssentialsDateTime(2019, 9, 14);

            DateTimeOffset a = new DateTimeOffset(2020, 9, 13, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset b = new DateTimeOffset(2020, 9, 14, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset c = new DateTimeOffset(2020, 9, 15, 0, 0, 0, TimeSpan.Zero);

            Assert.AreEqual(0, TimeUtils.GetAge(t, a));
            Assert.AreEqual(1, TimeUtils.GetAge(t, b));
            Assert.AreEqual(1, TimeUtils.GetAge(t, c));

        }

        [TestMethod]
        public void EssentialsDate() {

            EssentialsDateTime t = new EssentialsDateTime(2019, 9, 14);

            EssentialsDate a = new EssentialsDate(2020, 9, 13);
            EssentialsDate b = new EssentialsDate(2020, 9, 14);
            EssentialsDate c = new EssentialsDate(2020, 9, 15);

            Assert.AreEqual(0, TimeUtils.GetAge(t, a));
            Assert.AreEqual(1, TimeUtils.GetAge(t, b));
            Assert.AreEqual(1, TimeUtils.GetAge(t, c));

        }

        [TestMethod]
        public void EssentialsDateTime() {

            EssentialsDateTime t = new EssentialsDateTime(2019, 9, 14);

            EssentialsDateTime a = new EssentialsDateTime(2020, 9, 13);
            EssentialsDateTime b = new EssentialsDateTime(2020, 9, 14);
            EssentialsDateTime c = new EssentialsDateTime(2020, 9, 15);

            Assert.AreEqual(0, TimeUtils.GetAge(t, a));
            Assert.AreEqual(1, TimeUtils.GetAge(t, b));
            Assert.AreEqual(1, TimeUtils.GetAge(t, c));

        }

        [TestMethod]
        public void EssentialsTime() {

            EssentialsDateTime t = new EssentialsDateTime(2019, 9, 14);

            EssentialsTime a = new EssentialsTime(2020, 9, 13, TimeSpan.Zero);
            EssentialsTime b = new EssentialsTime(2020, 9, 14, TimeSpan.Zero);
            EssentialsTime c = new EssentialsTime(2020, 9, 15, TimeSpan.Zero);

            Assert.AreEqual(0, TimeUtils.GetAge(t, a));
            Assert.AreEqual(1, TimeUtils.GetAge(t, b));
            Assert.AreEqual(1, TimeUtils.GetAge(t, c));

        }

    }

}