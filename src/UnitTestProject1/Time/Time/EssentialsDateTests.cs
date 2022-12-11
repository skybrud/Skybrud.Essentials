using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

// ReSharper disable EqualExpressionComparison

#pragma warning disable CS1718

namespace UnitTestProject1.Time.Time {

    [TestClass]
    public class EssentialsDateTests {

        [TestMethod]
        public void Equals() {

            EssentialsDate date1 = new EssentialsDate(1988, 8, 17);
            EssentialsDate date2 = new EssentialsDate(2000, 5, 1);
            EssentialsDate date3 = new EssentialsDate(2020, 1, 1);
            EssentialsDate date4 = new EssentialsDate(2022, 12, 1);
            EssentialsDate date5 = new EssentialsDate(2022, 12, 24);
            EssentialsDate date6 = new EssentialsDate(2022, 12, 31);

            Assert.IsTrue(date1.Equals(date1), "#1a");
            Assert.IsFalse(date1.Equals(date2), "#1b");
            Assert.IsFalse(date1.Equals(date3), "#1c");
            Assert.IsFalse(date1.Equals(date4), "#1d");
            Assert.IsFalse(date1.Equals(date5), "#1e");
            Assert.IsFalse(date1.Equals(date6), "#1f");

            Assert.IsFalse(date2.Equals(date1), "#2a");
            Assert.IsTrue(date2.Equals(date2), "#2b");
            Assert.IsFalse(date2.Equals(date3), "#2c");
            Assert.IsFalse(date2.Equals(date4), "#2d");
            Assert.IsFalse(date2.Equals(date5), "#2e");
            Assert.IsFalse(date2.Equals(date6), "#2f");

            Assert.IsFalse(date3.Equals(date1), "#3a");
            Assert.IsFalse(date3.Equals(date2), "#3b");
            Assert.IsTrue(date3.Equals(date3), "#3c");
            Assert.IsFalse(date3.Equals(date4), "#3d");
            Assert.IsFalse(date3.Equals(date5), "#3e");
            Assert.IsFalse(date3.Equals(date6), "#3f");

            Assert.IsFalse(date4.Equals(date1), "#4a");
            Assert.IsFalse(date4.Equals(date2), "#4b");
            Assert.IsFalse(date4.Equals(date3), "#4c");
            Assert.IsTrue(date4.Equals(date4), "#4d");
            Assert.IsFalse(date4.Equals(date5), "#4e");
            Assert.IsFalse(date4.Equals(date6), "#4f");

            Assert.IsFalse(date5.Equals(date1), "#5a");
            Assert.IsFalse(date5.Equals(date2), "#5b");
            Assert.IsFalse(date5.Equals(date3), "#5c");
            Assert.IsFalse(date5.Equals(date4), "#5d");
            Assert.IsTrue(date5.Equals(date5), "#5e");
            Assert.IsFalse(date5.Equals(date6), "#5f");

            Assert.IsFalse(date6.Equals(date1), "#6a");
            Assert.IsFalse(date6.Equals(date2), "#6b");
            Assert.IsFalse(date6.Equals(date3), "#6c");
            Assert.IsFalse(date6.Equals(date4), "#6d");
            Assert.IsFalse(date6.Equals(date5), "#6e");
            Assert.IsTrue(date6.Equals(date6), "#6f");

        }

        [TestMethod]
        public void EqualsOperator() {

            EssentialsDate date1 = new EssentialsDate(1988, 8, 17);
            EssentialsDate date2 = new EssentialsDate(2000, 5, 1);
            EssentialsDate date3 = new EssentialsDate(2020, 1, 1);
            EssentialsDate date4 = new EssentialsDate(2022, 12, 1);
            EssentialsDate date5 = new EssentialsDate(2022, 12, 24);
            EssentialsDate date6 = new EssentialsDate(2022, 12, 31);

            Assert.IsTrue(date1 == date1, "#1a");
            Assert.IsFalse(date1 == date2, "#1b");
            Assert.IsFalse(date1 == date3, "#1c");
            Assert.IsFalse(date1 == date4, "#1d");
            Assert.IsFalse(date1 == date5, "#1e");
            Assert.IsFalse(date1 == date6, "#1f");

            Assert.IsFalse(date2 == date1, "#2a");
            Assert.IsTrue(date2 == date2, "#2b");
            Assert.IsFalse(date2 == date3, "#2c");
            Assert.IsFalse(date2 == date4, "#2d");
            Assert.IsFalse(date2 == date5, "#2e");
            Assert.IsFalse(date2 == date6, "#2f");

            Assert.IsFalse(date3 == date1, "#3a");
            Assert.IsFalse(date3 == date2, "#3b");
            Assert.IsTrue(date3 == date3, "#3c");
            Assert.IsFalse(date3 == date4, "#3d");
            Assert.IsFalse(date3 == date5, "#3e");
            Assert.IsFalse(date3 == date6, "#3f");

            Assert.IsFalse(date4 == date1, "#4a");
            Assert.IsFalse(date4 == date2, "#4b");
            Assert.IsFalse(date4 == date3, "#4c");
            Assert.IsTrue(date4 == date4, "#4d");
            Assert.IsFalse(date4 == date5, "#4e");
            Assert.IsFalse(date4 == date6, "#4f");

            Assert.IsFalse(date5 == date1, "#5a");
            Assert.IsFalse(date5 == date2, "#5b");
            Assert.IsFalse(date5 == date3, "#5c");
            Assert.IsFalse(date5 == date4, "#5d");
            Assert.IsTrue(date5 == date5, "#5e");
            Assert.IsFalse(date5 == date6, "#5f");

            Assert.IsFalse(date6 == date1, "#6a");
            Assert.IsFalse(date6 == date2, "#6b");
            Assert.IsFalse(date6 == date3, "#6c");
            Assert.IsFalse(date6 == date4, "#6d");
            Assert.IsFalse(date6 == date5, "#6e");
            Assert.IsTrue(date6 == date6, "#6f");

        }

        [TestMethod]
        public void Min() {

            EssentialsDate date1 = new EssentialsDate(1988, 8, 17);
            EssentialsDate date2 = new EssentialsDate(2000, 5, 1);
            EssentialsDate date3 = new EssentialsDate(2020, 1, 1);
            EssentialsDate date4 = new EssentialsDate(2022, 12, 1);
            EssentialsDate date5 = new EssentialsDate(2022, 12, 24);
            EssentialsDate date6 = new EssentialsDate(2022, 12, 31);

            Assert.AreEqual(date1, EssentialsDate.Min(date1, date1), "#1a");
            Assert.AreEqual(date1, EssentialsDate.Min(date1, date2), "#1b");
            Assert.AreEqual(date1, EssentialsDate.Min(date1, date3), "#1c");
            Assert.AreEqual(date1, EssentialsDate.Min(date1, date4), "#1d");
            Assert.AreEqual(date1, EssentialsDate.Min(date1, date5), "#1e");
            Assert.AreEqual(date1, EssentialsDate.Min(date1, date6), "#1f");

            Assert.AreEqual(date1, EssentialsDate.Min(date2, date1), "#2a");
            Assert.AreEqual(date2, EssentialsDate.Min(date2, date2), "#2b");
            Assert.AreEqual(date2, EssentialsDate.Min(date2, date3), "#2c");
            Assert.AreEqual(date2, EssentialsDate.Min(date2, date4), "#2d");
            Assert.AreEqual(date2, EssentialsDate.Min(date2, date5), "#2e");
            Assert.AreEqual(date2, EssentialsDate.Min(date2, date6), "#2f");

            Assert.AreEqual(date1, EssentialsDate.Min(date3, date1), "#3a");
            Assert.AreEqual(date2, EssentialsDate.Min(date3, date2), "#3b");
            Assert.AreEqual(date3, EssentialsDate.Min(date3, date3), "#3c");
            Assert.AreEqual(date3, EssentialsDate.Min(date3, date4), "#3d");
            Assert.AreEqual(date3, EssentialsDate.Min(date3, date5), "#3e");
            Assert.AreEqual(date3, EssentialsDate.Min(date3, date6), "#3f");

            Assert.AreEqual(date1, EssentialsDate.Min(date4, date1), "#4a");
            Assert.AreEqual(date2, EssentialsDate.Min(date4, date2), "#4b");
            Assert.AreEqual(date3, EssentialsDate.Min(date4, date3), "#4c");
            Assert.AreEqual(date4, EssentialsDate.Min(date4, date4), "#4d");
            Assert.AreEqual(date4, EssentialsDate.Min(date4, date5), "#4e");
            Assert.AreEqual(date4, EssentialsDate.Min(date4, date6), "#4f");

            Assert.AreEqual(date1, EssentialsDate.Min(date5, date1), "#5a");
            Assert.AreEqual(date2, EssentialsDate.Min(date5, date2), "#5b");
            Assert.AreEqual(date3, EssentialsDate.Min(date5, date3), "#5c");
            Assert.AreEqual(date4, EssentialsDate.Min(date5, date4), "#5d");
            Assert.AreEqual(date5, EssentialsDate.Min(date5, date5), "#5e");
            Assert.AreEqual(date5, EssentialsDate.Min(date5, date6), "#5f");

            Assert.AreEqual(date1, EssentialsDate.Min(date6, date1), "#6a");
            Assert.AreEqual(date2, EssentialsDate.Min(date6, date2), "#6b");
            Assert.AreEqual(date3, EssentialsDate.Min(date6, date3), "#6c");
            Assert.AreEqual(date4, EssentialsDate.Min(date6, date4), "#6d");
            Assert.AreEqual(date5, EssentialsDate.Min(date6, date5), "#6e");
            Assert.AreEqual(date6, EssentialsDate.Min(date6, date6), "#6f");

            Assert.AreEqual(date1, EssentialsDate.Min(date1, date2, date3, date4, date5, date6), "#6");

            Assert.AreEqual(date1, EssentialsDate.Min(new List<EssentialsDate> { date1, date2, date3, date4, date5, date6 }), "#7");

        }

        [TestMethod]
        public void Max() {

            EssentialsDate date1 = new EssentialsDate(1988, 8, 17);
            EssentialsDate date2 = new EssentialsDate(2000, 5, 1);
            EssentialsDate date3 = new EssentialsDate(2020, 1, 1);
            EssentialsDate date4 = new EssentialsDate(2022, 12, 1);
            EssentialsDate date5 = new EssentialsDate(2022, 12, 24);
            EssentialsDate date6 = new EssentialsDate(2022, 12, 31);

            Assert.AreEqual(date1, EssentialsDate.Max(date1, date1), "#1a");
            Assert.AreEqual(date2, EssentialsDate.Max(date1, date2), "#1b");
            Assert.AreEqual(date3, EssentialsDate.Max(date1, date3), "#1c");
            Assert.AreEqual(date4, EssentialsDate.Max(date1, date4), "#1d");
            Assert.AreEqual(date5, EssentialsDate.Max(date1, date5), "#1e");
            Assert.AreEqual(date6, EssentialsDate.Max(date1, date6), "#1f");

            Assert.AreEqual(date2, EssentialsDate.Max(date2, date1), "#2a");
            Assert.AreEqual(date2, EssentialsDate.Max(date2, date2), "#2b");
            Assert.AreEqual(date3, EssentialsDate.Max(date2, date3), "#2c");
            Assert.AreEqual(date4, EssentialsDate.Max(date2, date4), "#2d");
            Assert.AreEqual(date5, EssentialsDate.Max(date2, date5), "#2e");
            Assert.AreEqual(date6, EssentialsDate.Max(date2, date6), "#2f");

            Assert.AreEqual(date3, EssentialsDate.Max(date3, date1), "#3a");
            Assert.AreEqual(date3, EssentialsDate.Max(date3, date2), "#3b");
            Assert.AreEqual(date3, EssentialsDate.Max(date3, date3), "#3c");
            Assert.AreEqual(date4, EssentialsDate.Max(date3, date4), "#3d");
            Assert.AreEqual(date5, EssentialsDate.Max(date3, date5), "#3e");
            Assert.AreEqual(date6, EssentialsDate.Max(date3, date6), "#3f");

            Assert.AreEqual(date4, EssentialsDate.Max(date4, date1), "#4a");
            Assert.AreEqual(date4, EssentialsDate.Max(date4, date2), "#4b");
            Assert.AreEqual(date4, EssentialsDate.Max(date4, date3), "#4c");
            Assert.AreEqual(date4, EssentialsDate.Max(date4, date4), "#4d");
            Assert.AreEqual(date5, EssentialsDate.Max(date4, date5), "#4e");
            Assert.AreEqual(date6, EssentialsDate.Max(date4, date6), "#4f");

            Assert.AreEqual(date5, EssentialsDate.Max(date5, date1), "#5a");
            Assert.AreEqual(date5, EssentialsDate.Max(date5, date2), "#5b");
            Assert.AreEqual(date5, EssentialsDate.Max(date5, date3), "#5c");
            Assert.AreEqual(date5, EssentialsDate.Max(date5, date4), "#5d");
            Assert.AreEqual(date5, EssentialsDate.Max(date5, date5), "#5e");
            Assert.AreEqual(date6, EssentialsDate.Max(date5, date6), "#5f");

            Assert.AreEqual(date6, EssentialsDate.Max(date6, date1), "#6a");
            Assert.AreEqual(date6, EssentialsDate.Max(date6, date2), "#6b");
            Assert.AreEqual(date6, EssentialsDate.Max(date6, date3), "#6c");
            Assert.AreEqual(date6, EssentialsDate.Max(date6, date4), "#6d");
            Assert.AreEqual(date6, EssentialsDate.Max(date6, date5), "#6e");
            Assert.AreEqual(date6, EssentialsDate.Max(date6, date6), "#6f");

            Assert.AreEqual(date6, EssentialsDate.Max(date1, date2, date3, date4, date5, date6), "#6");

            Assert.AreEqual(date6, EssentialsDate.Max(new List<EssentialsDate> { date1, date2, date3, date4, date5, date6 }), "#7");

        }

    }

}