using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace UnitTestProject1.Json.Newtonsoft.JObjectTests {

    [TestClass]
    public class GuidTests {

        [TestMethod]
        public void GetGuid() {

            Guid expected1 = new Guid("ed377349-6946-4418-91cd-3b3ecc0b1cc6");
            Guid expected2 = new Guid("ccecd33b-3153-486a-8a1d-2c01016a6d42");

            JObject obj = new JObject {
                {"a", "ed377349-6946-4418-91cd-3b3ecc0b1cc6" },
                {"b", "{ed377349-6946-4418-91cd-3b3ecc0b1cc6}" },
                {"c", "(ed377349-6946-4418-91cd-3b3ecc0b1cc6)" },
                {"d", "ED377349-6946-4418-91CD-3B3ECC0B1CC6" },
                {"e", "{ED377349-6946-4418-91CD-3B3ECC0B1CC6}" },
                {"f", "(ED377349-6946-4418-91CD-3B3ECC0B1CC6)" },
                {"g", "nope" },
                {"h", null },
                {"i", "" },
                {"nested", new JObject {
                    {"a", "ed377349-6946-4418-91cd-3b3ecc0b1cc6" },
                    {"b", "{ed377349-6946-4418-91cd-3b3ecc0b1cc6}" },
                    {"c", "(ed377349-6946-4418-91cd-3b3ecc0b1cc6)" },
                    {"d", "ED377349-6946-4418-91CD-3B3ECC0B1CC6" },
                    {"e", "{ED377349-6946-4418-91CD-3B3ECC0B1CC6}" },
                    {"f", "(ED377349-6946-4418-91CD-3B3ECC0B1CC6)" },
                    {"g", "nope" },
                    {"h", null },
                    {"i", "" }
                }}
            };

            Assert.AreEqual(expected1, obj.GetGuid("a"), "Check #1 failed");
            Assert.AreEqual(expected1, obj.GetGuid("b"), "Check #2 failed");
            Assert.AreEqual(expected1, obj.GetGuid("c"), "Check #3 failed");
            Assert.AreEqual(expected1, obj.GetGuid("d"), "Check #4 failed");
            Assert.AreEqual(expected1, obj.GetGuid("e"), "Check #5 failed");
            Assert.AreEqual(expected1, obj.GetGuid("f"), "Check #6 failed");
            Assert.AreEqual(expected2, obj.GetGuid("g", expected2), "Check #7 failed");
            Assert.AreEqual(Guid.Empty, obj.GetGuid("h"), "Check #8 failed");
            Assert.AreEqual(expected2, obj.GetGuid("i", expected2), "Check #9 failed");

            Assert.AreEqual(Guid.Empty, obj.GetGuid("nested.a"), "Check #1 failed");
            Assert.AreEqual(Guid.Empty, obj.GetGuid("nested.b"), "Check #2 failed");
            Assert.AreEqual(Guid.Empty, obj.GetGuid("nested.c"), "Check #3 failed");
            Assert.AreEqual(Guid.Empty, obj.GetGuid("nested.d"), "Check #4 failed");
            Assert.AreEqual(Guid.Empty, obj.GetGuid("nested.e"), "Check #5 failed");
            Assert.AreEqual(Guid.Empty, obj.GetGuid("nested.f"), "Check #6 failed");
            Assert.AreEqual(expected2, obj.GetGuid("nested.g", expected2), "Check #7 failed");
            Assert.AreEqual(Guid.Empty, obj.GetGuid("nested.h"), "Check #8 failed");
            Assert.AreEqual(expected2, obj.GetGuid("nested.i", expected2), "Check #9 failed");

        }

        [TestMethod]
        public void GetGuidByPath() {

            Guid expected1 = new Guid("ed377349-6946-4418-91cd-3b3ecc0b1cc6");
            Guid expected2 = new Guid("ccecd33b-3153-486a-8a1d-2c01016a6d42");

            JObject obj = new JObject {
                {"a", "ed377349-6946-4418-91cd-3b3ecc0b1cc6" },
                {"b", "{ed377349-6946-4418-91cd-3b3ecc0b1cc6}" },
                {"c", "(ed377349-6946-4418-91cd-3b3ecc0b1cc6)" },
                {"d", "ED377349-6946-4418-91CD-3B3ECC0B1CC6" },
                {"e", "{ED377349-6946-4418-91CD-3B3ECC0B1CC6}" },
                {"f", "(ED377349-6946-4418-91CD-3B3ECC0B1CC6)" },
                {"g", "nope" },
                {"h", null },
                {"i", "" },
                {"nested", new JObject {
                    {"a", "ed377349-6946-4418-91cd-3b3ecc0b1cc6" },
                    {"b", "{ed377349-6946-4418-91cd-3b3ecc0b1cc6}" },
                    {"c", "(ed377349-6946-4418-91cd-3b3ecc0b1cc6)" },
                    {"d", "ED377349-6946-4418-91CD-3B3ECC0B1CC6" },
                    {"e", "{ED377349-6946-4418-91CD-3B3ECC0B1CC6}" },
                    {"f", "(ED377349-6946-4418-91CD-3B3ECC0B1CC6)" },
                    {"g", "nope" },
                    {"h", null },
                    {"i", "" }
                }}
            };

            Assert.AreEqual(expected1, obj.GetGuidByPath("a"), "Check #1 failed");
            Assert.AreEqual(expected1, obj.GetGuidByPath("b"), "Check #2 failed");
            Assert.AreEqual(expected1, obj.GetGuidByPath("c"), "Check #3 failed");
            Assert.AreEqual(expected1, obj.GetGuidByPath("d"), "Check #4 failed");
            Assert.AreEqual(expected1, obj.GetGuidByPath("e"), "Check #5 failed");
            Assert.AreEqual(expected1, obj.GetGuidByPath("f"), "Check #6 failed");
            Assert.AreEqual(expected2, obj.GetGuidByPath("g", expected2), "Check #7 failed");
            Assert.AreEqual(Guid.Empty, obj.GetGuidByPath("h"), "Check #8 failed");
            Assert.AreEqual(expected2, obj.GetGuidByPath("i", expected2), "Check #9 failed");

            Assert.AreEqual(expected1, obj.GetGuidByPath("nested.a"), "Check #1 failed");
            Assert.AreEqual(expected1, obj.GetGuidByPath("nested.b"), "Check #2 failed");
            Assert.AreEqual(expected1, obj.GetGuidByPath("nested.c"), "Check #3 failed");
            Assert.AreEqual(expected1, obj.GetGuidByPath("nested.d"), "Check #4 failed");
            Assert.AreEqual(expected1, obj.GetGuidByPath("nested.e"), "Check #5 failed");
            Assert.AreEqual(expected1, obj.GetGuidByPath("nested.f"), "Check #6 failed");
            Assert.AreEqual(expected2, obj.GetGuidByPath("nested.g", expected2), "Check #7 failed");
            Assert.AreEqual(Guid.Empty, obj.GetGuidByPath("nested.h"), "Check #8 failed");
            Assert.AreEqual(expected2, obj.GetGuidByPath("nested.i", expected2), "Check #9 failed");

        }

        [TestMethod]
        public void GetGuidArray() {

            Guid expected1 = new Guid("ed377349-6946-4418-91cd-3b3ecc0b1cc6");
            Guid expected2 = new Guid("ccecd33b-3153-486a-8a1d-2c01016a6d42");

            JObject sample1 = new JObject {
                {"array", new JArray { "ed377349-6946-4418-91cd-3b3ecc0b1cc6", "ccecd33b-3153-486a-8a1d-2c01016a6d42" } },
                {"number", 1},
                {"string", "nope" },
                {"string2", "ed377349-6946-4418-91cd-3b3ecc0b1cc6,ccecd33b-3153-486a-8a1d-2c01016a6d42" },
                {"guid", expected1 }
            };

            JObject sample2 = new JObject {
                {"array", new JArray { "nope", "ed377349-6946-4418-91cd-3b3ecc0b1cc6", "ccecd33b-3153-486a-8a1d-2c01016a6d42" } }
            };

            Guid[] array1 = sample1.GetGuidArray("array");
            Guid[] array2 = sample2.GetGuidArray("array");
            Guid[] array3 = sample1.GetGuidArray("nope");
            Guid[] array4 = sample1.GetGuidArray("number");
            Guid[] array5 = sample1.GetGuidArray("string");
            Guid[] array6 = sample1.GetGuidArray("string2");
            Guid[] array7 = sample1.GetGuidArray("guid");

            Assert.AreEqual(2, array1.Length, "#1");
            Assert.AreEqual(expected1, array1[0], "#1");
            Assert.AreEqual(expected2, array1[1], "#1");

            Assert.AreEqual(2, array2.Length, "#2");
            Assert.AreEqual(expected1, array2[0], "#2");
            Assert.AreEqual(expected2, array2[1], "#2");

            Assert.AreEqual(0, array3.Length, "Array 3");
            Assert.AreEqual(0, array4.Length, "Array 4");
            Assert.AreEqual(0, array5.Length, "Array 5");

            Assert.AreEqual(2, array6.Length, "Array 6");
            Assert.AreEqual(expected1, array6[0], "Array 6");
            Assert.AreEqual(expected2, array6[1], "Array 6");

            Assert.AreEqual(1, array7.Length, "Array 7");
            Assert.AreEqual(expected1, array7[0], "Array 7");

        }

        [TestMethod]
        public void GetGuidArrayByPath() {

            Guid expected1 = new Guid("ed377349-6946-4418-91cd-3b3ecc0b1cc6");
            Guid expected2 = new Guid("ccecd33b-3153-486a-8a1d-2c01016a6d42");

            JObject sample1 = new JObject {
                {"nested", new JObject {
                    {"array", new JArray { "ed377349-6946-4418-91cd-3b3ecc0b1cc6", "ccecd33b-3153-486a-8a1d-2c01016a6d42" } },
                    {"number", 1},
                    {"string", "nope" },
                    {"string2", "ed377349-6946-4418-91cd-3b3ecc0b1cc6,ccecd33b-3153-486a-8a1d-2c01016a6d42" },
                    {"guid", expected1 }
                }}
            };

            JObject sample2 = new JObject {
                {"nested", new JObject {
                    {"array", new JArray { "nope", "ed377349-6946-4418-91cd-3b3ecc0b1cc6", "ccecd33b-3153-486a-8a1d-2c01016a6d42" } }
                }}
            };

            Guid[] array1 = sample1.GetGuidArrayByPath("nested.array");
            Guid[] array2 = sample2.GetGuidArrayByPath("nested.array");
            Guid[] array3 = sample1.GetGuidArrayByPath("nested.nope");
            Guid[] array4 = sample1.GetGuidArrayByPath("nested.number");
            Guid[] array5 = sample1.GetGuidArrayByPath("nested.string");
            Guid[] array6 = sample1.GetGuidArrayByPath("nested.string2");
            Guid[] array7 = sample1.GetGuidArrayByPath("nested.guid");

            Assert.AreEqual(2, array1.Length, "#1");
            Assert.AreEqual(expected1, array1[0], "#1");
            Assert.AreEqual(expected2, array1[1], "#1");

            Assert.AreEqual(2, array2.Length, "#2");
            Assert.AreEqual(expected1, array2[0], "#2");
            Assert.AreEqual(expected2, array2[1], "#2");

            Assert.AreEqual(0, array3.Length, "Array 3");
            Assert.AreEqual(0, array4.Length, "Array 4");
            Assert.AreEqual(0, array5.Length, "Array 5");

            Assert.AreEqual(2, array6.Length, "Array 6");
            Assert.AreEqual(expected1, array6[0], "Array 6");
            Assert.AreEqual(expected2, array6[1], "Array 6");

            Assert.AreEqual(1, array7.Length, "Array 7");
            Assert.AreEqual(expected1, array7[0], "Array 7");

        }

    }

}