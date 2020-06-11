using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Collections.Extensions;

namespace UnitTestProject1.Collections {

    [TestClass]
    public class CollectionTests {
        
        [TestMethod]
        public void OrderByComparerBoolean() {

            StringComparer comparer = StringComparer.Create(CultureInfo.InvariantCulture, false);

            string[] samples = {
                "and", "aand"
            };

            IOrderedEnumerable<string> result = samples.OrderBy(x => x, comparer, false);

            Assert.AreEqual("aand,and", string.Join(",", result));

        }
        
        [TestMethod]
        public void OrderByComparerEnum() {

            StringComparer comparer = StringComparer.Create(CultureInfo.InvariantCulture, false);

            string[] samples = {
                "and", "aand"
            };

            IOrderedEnumerable<string> result = samples.OrderBy(x => x, comparer, SortOrder.Ascending);

            Assert.AreEqual("aand,and", string.Join(",", result));

        }
        
        [TestMethod]
        public void OrderByComparerDanishBoolean() {

            StringComparer comparer = StringComparer.Create(CultureInfo.GetCultureInfo("da-DK"), false);

            string[] samples = {
                "and", "aand"
            };

            IOrderedEnumerable<string> result = samples.OrderBy(x => x, comparer, false);

            Assert.AreEqual("and,aand", string.Join(",", result));

        }
        
        [TestMethod]
        public void OrderByComparerDanishEnum() {

            StringComparer comparer = StringComparer.Create(CultureInfo.GetCultureInfo("da-DK"), false);

            string[] samples = {
                "and", "aand"
            };

            IOrderedEnumerable<string> result = samples.OrderBy(x => x, comparer, SortOrder.Ascending);

            Assert.AreEqual("and,aand", string.Join(",", result));

        }
        
        [TestMethod]
        public void OrderByDescendingComparerBoolean() {

            StringComparer comparer = StringComparer.Create(CultureInfo.InvariantCulture, false);

            string[] samples = {
                "and", "aand"
            };

            IOrderedEnumerable<string> result = samples.OrderBy(x => x, comparer, true);

            Assert.AreEqual("and,aand", string.Join(",", result));

        }
        
        [TestMethod]
        public void OrderByDescendingComparerEnum() {

            StringComparer comparer = StringComparer.Create(CultureInfo.InvariantCulture, false);

            string[] samples = {
                "and", "aand"
            };

            IOrderedEnumerable<string> result = samples.OrderBy(x => x, comparer, SortOrder.Descending);

            Assert.AreEqual("and,aand", string.Join(",", result));

        }
        
        [TestMethod]
        public void OrderByDescendingComparerDanishBoolean() {

            StringComparer comparer = StringComparer.Create(CultureInfo.GetCultureInfo("da-DK"), false);

            string[] samples = {
                "and", "aand"
            };

            IOrderedEnumerable<string> result = samples.OrderBy(x => x, comparer, true);

            Assert.AreEqual("aand,and", string.Join(",", result));

        }
        
        [TestMethod]
        public void OrderByDescendingComparerDanishEnum() {

            StringComparer comparer = StringComparer.Create(CultureInfo.GetCultureInfo("da-DK"), false);

            string[] samples = {
                "and", "aand"
            };

            IOrderedEnumerable<string> result = samples.OrderBy(x => x, comparer, SortOrder.Descending);

            Assert.AreEqual("aand,and", string.Join(",", result));

        }

    }

}