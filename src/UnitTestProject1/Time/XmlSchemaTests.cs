using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time.Xml;

namespace UnitTestProject1.Time {

    [TestClass]
    public class XmlSchemaTests {

        [TestMethod]
        public new void ToString() {

            TimeSpan ts1 = TimeSpan.Zero;
            TimeSpan ts2 = TimeSpan.FromMinutes(10);
            TimeSpan ts3 = TimeSpan.FromMinutes(60);
            TimeSpan ts4 = TimeSpan.FromMinutes(120);
            TimeSpan ts5 = TimeSpan.FromDays(1);
            TimeSpan ts6 = TimeSpan.FromDays(31);
            TimeSpan ts7 = TimeSpan.FromDays(31).Add(TimeSpan.FromHours(12));
            TimeSpan ts8 = TimeSpan.FromDays(31)
                .Add(TimeSpan.FromHours(12))
                .Add(TimeSpan.FromMinutes(30))
                .Add(TimeSpan.FromSeconds(17));

            Assert.AreEqual("PT0S", XmlSchemaUtils.ToString(ts1), "#1");
            Assert.AreEqual("PT10M", XmlSchemaUtils.ToString(ts2), "#2");
            Assert.AreEqual("PT1H", XmlSchemaUtils.ToString(ts3), "#3");
            Assert.AreEqual("PT2H", XmlSchemaUtils.ToString(ts4), "#4");
            Assert.AreEqual("P1D", XmlSchemaUtils.ToString(ts5), "#5");
            Assert.AreEqual("P31D", XmlSchemaUtils.ToString(ts6), "#6");
            Assert.AreEqual("P31DT12H", XmlSchemaUtils.ToString(ts7), "#7");
            Assert.AreEqual("P31DT12H30M17S", XmlSchemaUtils.ToString(ts8), "#8");

        }

        [TestMethod]
        public void ParseDuration() {

            Assert.AreEqual(0, (int) XmlSchemaUtils.ParseDuration("PT0S").TotalSeconds, "#1");
            Assert.AreEqual(600, (int) XmlSchemaUtils.ParseDuration("PT10M").TotalSeconds, "#2");
            Assert.AreEqual(3600, (int) XmlSchemaUtils.ParseDuration("PT1H").TotalSeconds, "#3");
            Assert.AreEqual(7200, (int) XmlSchemaUtils.ParseDuration("PT2H").TotalSeconds, "#4");
            Assert.AreEqual(86400, (int) XmlSchemaUtils.ParseDuration("P1D").TotalSeconds, "#5");
            Assert.AreEqual(2678400, (int) XmlSchemaUtils.ParseDuration("P31D").TotalSeconds, "#6");
            Assert.AreEqual(2721600, (int) XmlSchemaUtils.ParseDuration("P31DT12H").TotalSeconds, "#7");
            Assert.AreEqual(2723417, (int) XmlSchemaUtils.ParseDuration("P31DT12H30M17S").TotalSeconds, "#8");

        }

    }

}