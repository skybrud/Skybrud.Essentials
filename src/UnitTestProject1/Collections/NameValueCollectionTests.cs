using System;
using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Collections.Extensions;

namespace UnitTestProject1.Collections {

    [TestClass]
    public class NameValueCollectionTests {

        #region String

        [TestMethod]
        public void GetString() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "Hello there!" },
                {"c", "Hej verden!" },
                {"d", "Hello there!" },
                {"d", "Hej verden!" }
            };

            Assert.AreEqual("", nvc.GetString("a"), "#1");
            Assert.AreEqual("Hello there!", nvc.GetString("b"), "#2");
            Assert.AreEqual("Hej verden!", nvc.GetString("c"), "#3");
            Assert.AreEqual("Hello there!", nvc.GetString("d"), "#4");

        }


        [TestMethod]
        public void TryGetString() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "Hello there!" },
                {"c", "Hej verden!" },
                {"d", "Hello there!" },
                {"d", "Hej verden!" }
            };

            Assert.AreEqual(false, nvc.TryGetString("a", out string result1));
            Assert.IsNull(result1);

            Assert.AreEqual(true, nvc.TryGetString("b", out string result2));
            Assert.AreEqual("Hello there!", result2);

            Assert.AreEqual(true, nvc.TryGetString("c", out string result3));
            Assert.AreEqual("Hej verden!", result3);

            Assert.AreEqual(true, nvc.TryGetString("d", out string result4));
            Assert.AreEqual("Hello there!", result4);

        }

        #endregion

        #region Boolean

        [TestMethod]
        public void GetBoolean() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "true" },
                {"c", "false" },
                {"d", "true" },
                {"d", "false" }
            };

            Assert.AreEqual(false, nvc.GetBoolean("a"), "#1");
            Assert.AreEqual(true, nvc.GetBoolean("b"), "#2");
            Assert.AreEqual(false, nvc.GetBoolean("c"), "#3");
            Assert.AreEqual(true, nvc.GetBoolean("d"), "#4");

        }

        [TestMethod]
        public void GetBooleanWithFallback() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "true" },
                {"c", "false" },
                {"d", "true" },
                {"d", "false" },
                {"e", "false" },
                {"e", "true" }
            };

            Assert.AreEqual(true, nvc.GetBoolean("a", true), "#1");
            Assert.AreEqual(true, nvc.GetBoolean("b", true), "#2");
            Assert.AreEqual(false, nvc.GetBoolean("c", true), "#3");
            Assert.AreEqual(true, nvc.GetBoolean("d", true), "#4");
            Assert.AreEqual(false, nvc.GetBoolean("e", true), "#5");

        }

        [TestMethod]
        public void TryGetBoolean() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "true" },
                {"c", "false" },
                {"d", "true" },
                {"d", "false" },
                {"e", "false" },
                {"e", "true" }
            };

            Assert.AreEqual(false, nvc.TryGetBoolean("a", out bool result1));
            Assert.AreEqual(false, result1);

            Assert.AreEqual(true, nvc.TryGetBoolean("b", out bool result2));
            Assert.AreEqual(true, result2);

            Assert.AreEqual(true, nvc.TryGetBoolean("c", out bool result3));
            Assert.AreEqual(false, result3);

            Assert.AreEqual(true, nvc.TryGetBoolean("d", out bool result4));
            Assert.AreEqual(true, result4);

            Assert.AreEqual(true, nvc.TryGetBoolean("e", out bool result5));
            Assert.AreEqual(false, result5);

        }

        #endregion

        #region Guid

        [TestMethod]
        public void GetGuid() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "Hello there!" },
                {"c", "400149d7-f2fa-413b-b1ee-32b167653e5f" },
                {"d", "400149d7-f2fa-413b-b1ee-32b167653e5f" },
                {"d", "5b3735b6-034f-4482-ab86-8bf436e81dc5" }
            };

            Assert.AreEqual("00000000-0000-0000-0000-000000000000", nvc.GetGuid("a").ToString(), "#1");
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", nvc.GetGuid("b").ToString(), "#2");
            Assert.AreEqual("400149d7-f2fa-413b-b1ee-32b167653e5f", nvc.GetGuid("c").ToString(), "#3");
            Assert.AreEqual("400149d7-f2fa-413b-b1ee-32b167653e5f", nvc.GetGuid("d").ToString(), "#4");

        }

        [TestMethod]
        public void GetGetGuidWithFallback() {

            Guid fallback = new Guid("977b5202-d3ce-4845-957c-40947bcc0c60");

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "Hello there!" },
                {"c", "400149d7-f2fa-413b-b1ee-32b167653e5f" },
                {"d", "400149d7-f2fa-413b-b1ee-32b167653e5f" },
                {"d", "5b3735b6-034f-4482-ab86-8bf436e81dc5" }
            };

            Assert.AreEqual("977b5202-d3ce-4845-957c-40947bcc0c60", nvc.GetGuid("a", fallback).ToString(), "#1");
            Assert.AreEqual("977b5202-d3ce-4845-957c-40947bcc0c60", nvc.GetGuid("b", fallback).ToString(), "#2");
            Assert.AreEqual("400149d7-f2fa-413b-b1ee-32b167653e5f", nvc.GetGuid("c", fallback).ToString(), "#3");
            Assert.AreEqual("400149d7-f2fa-413b-b1ee-32b167653e5f", nvc.GetGuid("d", fallback).ToString(), "#4");

        }

        [TestMethod]
        public void TryGetGuid() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "Hello there!" },
                {"c", "400149d7-f2fa-413b-b1ee-32b167653e5f" },
                {"d", "400149d7-f2fa-413b-b1ee-32b167653e5f" },
                {"d", "5b3735b6-034f-4482-ab86-8bf436e81dc5" }
            };

            Assert.AreEqual(false, nvc.TryGetGuid("a", out Guid result1));
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", result1.ToString());

            Assert.AreEqual(false, nvc.TryGetGuid("b", out Guid result2));
            Assert.AreEqual("00000000-0000-0000-0000-000000000000", result2.ToString());

            Assert.AreEqual(true, nvc.TryGetGuid("c", out Guid result3));
            Assert.AreEqual("400149d7-f2fa-413b-b1ee-32b167653e5f", result3.ToString());

            Assert.AreEqual(true, nvc.TryGetGuid("d", out Guid result4));
            Assert.AreEqual("400149d7-f2fa-413b-b1ee-32b167653e5f", result4.ToString());

        }

        [TestMethod]
        public void TryGetGuidNullable() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "Hello there!" },
                {"c", "400149d7-f2fa-413b-b1ee-32b167653e5f" },
                {"d", "400149d7-f2fa-413b-b1ee-32b167653e5f" },
                {"d", "5b3735b6-034f-4482-ab86-8bf436e81dc5" }
            };

            Assert.AreEqual(false, nvc.TryGetGuid("a", out Guid? result1));
            Assert.IsNull(result1);

            Assert.AreEqual(false, nvc.TryGetGuid("b", out Guid? result2));
            Assert.IsNull(result2);

            Assert.AreEqual(true, nvc.TryGetGuid("c", out Guid? result3));
            Assert.AreEqual("400149d7-f2fa-413b-b1ee-32b167653e5f", result3?.ToString());

            Assert.AreEqual(true, nvc.TryGetGuid("d", out Guid? result4));
            Assert.AreEqual("400149d7-f2fa-413b-b1ee-32b167653e5f", result4?.ToString());

        }

        #endregion

        #region Int32

        [TestMethod]
        public void GetInt32() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "1" },
                {"c", "2" },
                {"d", "3" },
                {"d", "4" }
            };

            Assert.AreEqual(0, nvc.GetInt32("a"), "#1");
            Assert.AreEqual(1, nvc.GetInt32("b"), "#2");
            Assert.AreEqual(2, nvc.GetInt32("c"), "#3");
            Assert.AreEqual(3, nvc.GetInt32("d"), "#4");

        }

        [TestMethod]
        public void GetGetInt32WithFallback() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "1" },
                {"c", "2" },
                {"d", "3" },
                {"d", "4" }
            };

            Assert.AreEqual(42, nvc.GetInt32("a", 42), "#1");
            Assert.AreEqual(1, nvc.GetInt32("b", 42), "#2");
            Assert.AreEqual(2, nvc.GetInt32("c", 42), "#3");
            Assert.AreEqual(3, nvc.GetInt32("d", 42), "#4");

        }

        [TestMethod]
        public void TryGetInt32() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "1" },
                {"c", "2" },
                {"d", "3" },
                {"d", "4" }
            };

            Assert.AreEqual(false, nvc.TryGetInt32("a", out int result1));
            Assert.AreEqual(0, result1);

            Assert.AreEqual(true, nvc.TryGetInt32("b", out int result2));
            Assert.AreEqual(1, result2);

            Assert.AreEqual(true, nvc.TryGetInt32("c", out int result3));
            Assert.AreEqual(2, result3);

            Assert.AreEqual(true, nvc.TryGetInt32("d", out int result4));
            Assert.AreEqual(3, result4);

        }

        [TestMethod]
        public void TryGetInt32Nullable() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "1" },
                {"c", "2" },
                {"d", "3" },
                {"d", "4" }
            };

            Assert.AreEqual(false, nvc.TryGetInt32("a", out int? result1));
            Assert.IsNull(result1);

            Assert.AreEqual(true, nvc.TryGetInt32("b", out int? result2));
            Assert.AreEqual(1, result2);

            Assert.AreEqual(true, nvc.TryGetInt32("c", out int? result3));
            Assert.AreEqual(2, result3);

            Assert.AreEqual(true, nvc.TryGetInt32("d", out int? result4));
            Assert.AreEqual(3, result4);

        }

        #endregion

        #region Int64

        [TestMethod]
        public void GetInt64() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "1" },
                {"c", "2" },
                {"d", "3" },
                {"d", "4" }
            };

            Assert.AreEqual(0, nvc.GetInt64("a"), "#1");
            Assert.AreEqual(1, nvc.GetInt64("b"), "#2");
            Assert.AreEqual(2, nvc.GetInt64("c"), "#3");
            Assert.AreEqual(3, nvc.GetInt64("d"), "#4");

        }

        [TestMethod]
        public void GetGetInt64WithFallback() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "1" },
                {"c", "2" },
                {"d", "3" },
                {"d", "4" }
            };

            Assert.AreEqual(42, nvc.GetInt64("a", 42), "#1");
            Assert.AreEqual(1, nvc.GetInt64("b", 42), "#2");
            Assert.AreEqual(2, nvc.GetInt64("c", 42), "#3");
            Assert.AreEqual(3, nvc.GetInt64("d", 42), "#4");

        }

        [TestMethod]
        public void TryGetInt64() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "1" },
                {"c", "2" },
                {"d", "3" },
                {"d", "4" }
            };

            Assert.AreEqual(false, nvc.TryGetInt64("a", out long result1));
            Assert.AreEqual(0, result1);

            Assert.AreEqual(true, nvc.TryGetInt64("b", out long result2));
            Assert.AreEqual(1, result2);

            Assert.AreEqual(true, nvc.TryGetInt64("c", out long result3));
            Assert.AreEqual(2, result3);

            Assert.AreEqual(true, nvc.TryGetInt64("d", out long result4));
            Assert.AreEqual(3, result4);

        }

        [TestMethod]
        public void TryGetInt64Nullable() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "1" },
                {"c", "2" },
                {"d", "3" },
                {"d", "4" }
            };

            Assert.AreEqual(false, nvc.TryGetInt64("a", out long? result1));
            Assert.IsNull(result1);

            Assert.AreEqual(true, nvc.TryGetInt64("b", out long? result2));
            Assert.AreEqual(1, result2);

            Assert.AreEqual(true, nvc.TryGetInt64("c", out long? result3));
            Assert.AreEqual(2, result3);

            Assert.AreEqual(true, nvc.TryGetInt64("d", out long? result4));
            Assert.AreEqual(3, result4);

        }

        #endregion

        #region Float

        [TestMethod]
        public void GetFloat() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "3.14" },
                {"c", "6.28" },
                {"d", "6.28" },
                {"d", "3.14" }
            };

            Assert.AreEqual(0.00f, nvc.GetFloat("a"), "#1");
            Assert.AreEqual(3.14f, nvc.GetFloat("b"), "#2");
            Assert.AreEqual(6.28f, nvc.GetFloat("c"), "#3");
            Assert.AreEqual(6.28f, nvc.GetFloat("d"), "#4");

        }

        [TestMethod]
        public void GetGetFloatWithFallback() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "3.14" },
                {"c", "6.28" },
                {"d", "6.28" },
                {"d", "3.14" }
            };

            Assert.AreEqual(42, nvc.GetFloat("a", 42), "#1");
            Assert.AreEqual(3.14f, nvc.GetFloat("b", 42), "#2");
            Assert.AreEqual(6.28f, nvc.GetFloat("c", 42), "#3");
            Assert.AreEqual(6.28f, nvc.GetFloat("d", 42), "#4");

        }

        [TestMethod]
        public void TryGetFloat() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "3.14" },
                {"c", "6.28" },
                {"d", "6.28" },
                {"d", "3.14" }
            };

            Assert.AreEqual(false, nvc.TryGetFloat("a", out float result1));
            Assert.AreEqual(0, result1);

            Assert.AreEqual(true, nvc.TryGetFloat("b", out float result2));
            Assert.AreEqual(3.14f, result2);

            Assert.AreEqual(true, nvc.TryGetFloat("c", out float result3));
            Assert.AreEqual(6.28f, result3);

            Assert.AreEqual(true, nvc.TryGetFloat("d", out float result4));
            Assert.AreEqual(6.28f, result4);

        }

        [TestMethod]
        public void TryGetFloatNullable() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "3.14" },
                {"c", "6.28" },
                {"d", "6.28" },
                {"d", "3.14" }
            };

            Assert.AreEqual(false, nvc.TryGetFloat("a", out float? result1));
            Assert.IsNull(result1);

            Assert.AreEqual(true, nvc.TryGetFloat("b", out float? result2));
            Assert.AreEqual(3.14f, result2);

            Assert.AreEqual(true, nvc.TryGetFloat("c", out float? result3));
            Assert.AreEqual(6.28f, result3);

            Assert.AreEqual(true, nvc.TryGetFloat("d", out float? result4));
            Assert.AreEqual(6.28f, result4);

        }

        #endregion

        #region Double

        [TestMethod]
        public void GetDouble() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "3.14" },
                {"c", "6.28" },
                {"d", "6.28" },
                {"d", "3.14" }
            };

            Assert.AreEqual(0.00, nvc.GetDouble("a"), "#1");
            Assert.AreEqual(3.14, nvc.GetDouble("b"), "#2");
            Assert.AreEqual(6.28, nvc.GetDouble("c"), "#3");
            Assert.AreEqual(6.28, nvc.GetDouble("d"), "#4");

        }

        [TestMethod]
        public void GetDoubleWithFallback() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "3.14" },
                {"c", "6.28" },
                {"d", "6.28" },
                {"d", "3.14" }
            };

            Assert.AreEqual(42, nvc.GetDouble("a", 42), "#1");
            Assert.AreEqual(3.14, nvc.GetDouble("b", 42), "#2");
            Assert.AreEqual(6.28, nvc.GetDouble("c", 42), "#3");
            Assert.AreEqual(6.28, nvc.GetDouble("d", 42), "#4");

        }

        [TestMethod]
        public void TryGetDouble() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "3.14" },
                {"c", "6.28" },
                {"d", "6.28" },
                {"d", "3.14" }
            };

            Assert.AreEqual(false, nvc.TryGetDouble("a", out double result1));
            Assert.AreEqual(0, result1);

            Assert.AreEqual(true, nvc.TryGetDouble("b", out double result2));
            Assert.AreEqual(3.14, result2);

            Assert.AreEqual(true, nvc.TryGetDouble("c", out double result3));
            Assert.AreEqual(6.28, result3);

            Assert.AreEqual(true, nvc.TryGetDouble("d", out double result4));
            Assert.AreEqual(6.28, result4);

        }

        [TestMethod]
        public void TryGetDoubleNullable() {

            NameValueCollection nvc = new NameValueCollection {
                {"a", "" },
                {"b", "3.14" },
                {"c", "6.28" },
                {"d", "6.28" },
                {"d", "3.14" }
            };

            Assert.AreEqual(false, nvc.TryGetDouble("a", out double? result1));
            Assert.IsNull(result1);

            Assert.AreEqual(true, nvc.TryGetDouble("b", out double? result2));
            Assert.AreEqual(3.14, result2);

            Assert.AreEqual(true, nvc.TryGetDouble("c", out double? result3));
            Assert.AreEqual(6.28, result3);

            Assert.AreEqual(true, nvc.TryGetDouble("d", out double? result4));
            Assert.AreEqual(6.28, result4);

        }

        #endregion

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