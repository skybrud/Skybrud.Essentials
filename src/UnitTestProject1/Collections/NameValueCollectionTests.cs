using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Collections.Extensions;

namespace UnitTestProject1.Collections {

    [TestClass]
    public class NameValueCollectionTests {

        [TestMethod]
        public void GetBoolean() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "true" },
                {"c", "false" }
            };

            Assert.AreEqual(false, nvc.GetBoolean("a"), "#1");
            Assert.AreEqual(true, nvc.GetBoolean("b"), "#2");
            Assert.AreEqual(false, nvc.GetBoolean("c"), "#3");

        }

        [TestMethod]
        public void GetBooleanWithFallback() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "true" },
                {"c", "false" }
            };

            Assert.AreEqual(true, nvc.GetBoolean("a", true), "#1");
            Assert.AreEqual(true, nvc.GetBoolean("b", true), "#2");
            Assert.AreEqual(false, nvc.GetBoolean("c", true), "#3");

        }

        [TestMethod]
        public void TryGetBoolean() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "true" },
                {"c", "false" }
            };

            Assert.AreEqual(false, nvc.TryGetBoolean("a", out bool result1));
            Assert.AreEqual(false, result1);

            Assert.AreEqual(true, nvc.TryGetBoolean("b", out bool result2));
            Assert.AreEqual(true, result2);

            Assert.AreEqual(true, nvc.TryGetBoolean("c", out bool result3));
            Assert.AreEqual(false, result3);

        }

        [TestMethod]
        public void GetInt32() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "1" },
                {"c", "2" }
            };

            Assert.AreEqual(0, nvc.GetInt32("a"), "#1");
            Assert.AreEqual(1, nvc.GetInt32("b"), "#2");
            Assert.AreEqual(2, nvc.GetInt32("c"), "#3");

        }

        [TestMethod]
        public void GetGetInt32WithFallback() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "1" },
                {"c", "2" }
            };

            Assert.AreEqual(42, nvc.GetInt32("a", 42), "#1");
            Assert.AreEqual(1, nvc.GetInt32("b", 42), "#2");
            Assert.AreEqual(2, nvc.GetInt32("c", 42), "#3");

        }

        [TestMethod]
        public void TryGetInt32() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "1" },
                {"c", "2" }
            };

            Assert.AreEqual(false, nvc.TryGetInt32("a", out int result1));
            Assert.AreEqual(0, result1);

            Assert.AreEqual(true, nvc.TryGetInt32("b", out int result2));
            Assert.AreEqual(1, result2);

            Assert.AreEqual(true, nvc.TryGetInt32("c", out int result3));
            Assert.AreEqual(2, result3);

        }

        [TestMethod]
        public void TryGetValue() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "1" },
                {"c", "2" }
            };

            Assert.AreEqual(true, nvc.TryGetValue("a", out string result1));
            Assert.AreEqual("", result1);

            Assert.AreEqual(true, nvc.TryGetValue("b", out string result2));
            Assert.AreEqual("1", result2);

            Assert.AreEqual(true, nvc.TryGetValue("c", out string result3));
            Assert.AreEqual("2", result3);

            Assert.AreEqual(false, nvc.TryGetValue("d", out string result4));
            Assert.AreEqual(null, result4);

        }

    }

}