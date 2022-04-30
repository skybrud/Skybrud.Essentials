using System;
using System.Globalization;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

// ReSharper disable UseObjectOrCollectionInitializer

namespace UnitTestProject1.Json {

    [TestClass]
    public class JObjectTests {

        [TestMethod]
        public void HasValue() {

            JObject obj = JObject.Parse("{\"root\":{\"nothing\":null,\"obj\":{\"value\":\"1234\",\"nothing\":null,\"empty\":\"\",\"whitespace\":\"    \"}}}");

            Assert.AreEqual(false, obj.HasValue("root.nothing"), "Check #1 failed");
            Assert.AreEqual(false, obj.HasValue("root.obj.nothing"), "Check #2 failed");
            Assert.AreEqual(true, obj.HasValue("root.obj"), "Check #3 failed");
            Assert.AreEqual(true, obj.HasValue("root.obj.value"), "Check #4 failed");
            Assert.AreEqual(false, obj.HasValue("root.obj.empty"), "Check #5 failed");
            Assert.AreEqual(true, obj.HasValue("root.obj.whitespace"), "Check #6 failed");

        }

        [TestMethod]
        public void GetObject() {

            JObject obj = JObject.Parse("{\"root\":{\"nothing\":null,\"obj\":{\"value\":\"1234\"}}}");

            Assert.AreEqual(null, obj.GetObject("nope"), "Check #1 failed");
            Assert.AreEqual(null, obj.GetObject("root.nothing"), "Check #2 failed");
            Assert.IsNotNull(obj.GetObject("root.obj"), "Check #3 failed");
            Assert.AreEqual("1234", obj.GetObject<TestObject>("root.obj").Value, "Check #4 failed");
            Assert.AreEqual("1234", obj.GetObject("root.obj", TestObject.Parse).Value, "Check #5 failed");
            Assert.IsNull(obj.GetObject<TestObject>("root.hest"), "Check #6 failed");

        }

        [TestMethod]
        public void GetString() {

            JObject obj = JObject.Parse("{\"root\":{\"nothing\":null,\"obj\":{\"value\":\"1234\",\"nothing\":null,\"empty\":\"\",\"whitespace\":\"    \"}}}");

            Assert.AreEqual(null, obj.GetString("root.nope"), "Check #1 failed");
            Assert.AreEqual(null, obj.GetString("root.nothing"), "Check #2 failed");
            Assert.AreEqual("1234", obj.GetString("root.obj.value"), "Check #3 failed");
            Assert.AreEqual(null, obj.GetString("root.obj.nothing"), "Check #4 failed");
            Assert.AreEqual("", obj.GetString("root.obj.empty"), "Check #5 failed");
            Assert.AreEqual("    ", obj.GetString("root.obj.whitespace"), "Check #6 failed");

            Assert.IsNull(obj.GetString("root.obj"), "Check #7 failed");

        }

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
                {"i", "" }
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
        public void GetInt16() {

            JObject obj = JObject.Parse("{\"int16\":0,\"hest\":1234,\"null\":null,\"empty\":\"\"}");

            Assert.AreEqual(0, obj.GetInt16("int16"), "Check #1 failed");
            Assert.AreEqual(1234, obj.GetInt16("hest"), "Check #2 failed");
            Assert.AreEqual(0, obj.GetInt16("null"), "Check #3 failed");
            Assert.AreEqual(0, obj.GetInt16("empty"), "Check #4 failed");
            Assert.AreEqual(0, obj.GetInt16("missing"), "Check #5 failed");

            Assert.AreEqual(4, obj.GetInt16("int16", x => x + 4), "Check #6 failed");
            Assert.AreEqual(1238, obj.GetInt16("hest", x => x + 4), "Check #7 failed");

            // Callback isn't invoked since the properties are empty or not found
            Assert.AreEqual(0, obj.GetInt16("null", x => x + 4), "Check #8 failed");
            Assert.AreEqual(0, obj.GetInt16("empty", x => x + 4), "Check #9 failed");
            Assert.AreEqual(0, obj.GetInt16("missing", x => x + 4), "Check #10 failed");

        }

        [TestMethod]
        public void GetUInt16() {

            JObject obj = JObject.Parse("{\"int16\":0,\"hest\":1234,\"null\":null,\"empty\":\"\"}");

            Assert.AreEqual(0, obj.GetUInt16("int16"), "Check #1 failed");
            Assert.AreEqual(1234, obj.GetUInt16("hest"), "Check #2 failed");
            Assert.AreEqual(0, obj.GetUInt16("null"), "Check #3 failed");
            Assert.AreEqual(0, obj.GetUInt16("empty"), "Check #4 failed");
            Assert.AreEqual(0, obj.GetUInt16("missing"), "Check #5 failed");

            Assert.AreEqual(4, obj.GetUInt16("int16", x => x + 4), "Check #6 failed");
            Assert.AreEqual(1238, obj.GetUInt16("hest", x => x + 4), "Check #7 failed");

            // Callback isn't invoked since the properties are empty or not found
            Assert.AreEqual(0, obj.GetInt16("null", x => x + 4), "Check #8 failed");
            Assert.AreEqual(0, obj.GetInt16("empty", x => x + 4), "Check #9 failed");
            Assert.AreEqual(0, obj.GetInt16("missing", x => x + 4), "Check #10 failed");

        }

        [TestMethod]
        public void GetInt32() {

            JObject obj = JObject.Parse("{\"root\":{\"nothing\":null,\"empty\":\"\",\"obj\":{\"value\":\"1234\",\"nothing\":\"0\",\"number\":1234}}}");

            Assert.AreEqual(0, obj.GetInt32("root.nothing"), "Check #1 failed");
            Assert.AreEqual(1234, obj.GetInt32("root.obj.value"), "Check #2 failed");
            Assert.AreEqual(0, obj.GetInt32("root.obj.nothing"), "Check #3 failed");
            Assert.AreEqual(1234, obj.GetInt32("root.obj.number"), "Check #4 failed");
            Assert.AreEqual(1234, obj.GetInt32("root.obj.number", x => (int) TimeSpan.FromSeconds(x).TotalSeconds), "Check #5 failed");

            Assert.AreEqual(0, obj.GetInt32("root.obj"), "Check #6 failed");
            Assert.AreEqual(0, obj.GetInt32("root.empty"), "Check #7 failed");

        }

        [TestMethod]
        public void GetUInt32() {

            JObject obj = JObject.Parse("{\"int32\":0,\"hest\":1234,\"null\":null,\"empty\":\"\"}");

            Assert.AreEqual((uint) 0, obj.GetUInt32("int32"), "Check #1 failed");
            Assert.AreEqual((uint) 1234, obj.GetUInt32("hest"), "Check #2 failed");
            Assert.AreEqual((uint) 0, obj.GetUInt32("null"), "Check #3 failed");
            Assert.AreEqual((uint) 0, obj.GetUInt32("empty"), "Check #4 failed");
            Assert.AreEqual((uint) 0, obj.GetUInt32("missing"), "Check #5 failed");

            Assert.AreEqual((uint) 4, obj.GetUInt32("int32", x => x + 4), "Check #6 failed");
            Assert.AreEqual((uint) 1238, obj.GetUInt32("hest", x => x + 4), "Check #7 failed");

            // Callback isn't invoked since the properties are empty or not found
            Assert.AreEqual((uint) 0, obj.GetUInt32("null", x => x + 4), "Check #8 failed");
            Assert.AreEqual((uint) 0, obj.GetUInt32("empty", x => x + 4), "Check #9 failed");
            Assert.AreEqual((uint) 0, obj.GetUInt32("missing", x => x + 4), "Check #10 failed");

        }

        [TestMethod]
        public void GetInt64() {

            JObject obj = JObject.Parse("{\"root\":{\"nothing\":null,\"empty\":\"\",\"obj\":{\"value\":\"1234\",\"nothing\":\"0\",\"number\":2147483648}}}");

            Assert.AreEqual(0, obj.GetInt64("root.nothing"), "Check #1 failed");
            Assert.AreEqual(1234, obj.GetInt64("root.obj.value"), "Check #2 failed");
            Assert.AreEqual(0, obj.GetInt64("root.obj.nothing"), "Check #3 failed");
            Assert.AreEqual(2147483648, obj.GetInt64("root.obj.number"), "Check #4 failed");
            Assert.AreEqual(2147483648, obj.GetInt64("root.obj.number", x => (long) TimeSpan.FromSeconds(x).TotalSeconds), "Check #5 failed");

            Assert.AreEqual(0, obj.GetInt64("root.obj"), "Check #6 failed");
            Assert.AreEqual(0, obj.GetInt64("root.empty"), "Check #7 failed");

        }


        [TestMethod]
        public void GetFloat() {

            JObject obj = JObject.Parse("{\"root\":{\"nothing\":null,\"empty\":\"\",\"obj\":{\"value\":\"0.123\",\"nothing\":\"0\",\"number\":1234.567}}}");

            Assert.AreEqual("0.000", String.Format(CultureInfo.InvariantCulture, "{0:0.000}", obj.GetFloat("nothing")), "Check #1 failed");
            Assert.AreEqual("0.000", String.Format(CultureInfo.InvariantCulture, "{0:0.000}", obj.GetFloat("root.nothing")), "Check #2 failed");
            Assert.AreEqual("0.123", String.Format(CultureInfo.InvariantCulture, "{0:0.000}", obj.GetFloat("root.obj.value")), "Check #3 failed");
            Assert.AreEqual("0.000", String.Format(CultureInfo.InvariantCulture, "{0:0.000}", obj.GetFloat("root.obj.nothing")), "Check #4 failed");
            Assert.AreEqual("1234.567", String.Format(CultureInfo.InvariantCulture, "{0:0.000}", obj.GetFloat("root.obj.number")), "Check #5 failed");

            Assert.AreEqual(0, obj.GetFloat("root.obj"), "Check #6 failed");
            Assert.AreEqual(0, obj.GetFloat("root.empty"), "Check #7 failed");

        }

        [TestMethod]
        public void GetDouble() {

            JObject obj = JObject.Parse("{\"root\":{\"nothing\":null,\"empty\":\"\",\"obj\":{\"value\":\"0.123\",\"nothing\":\"0\",\"number\":1234.567}}}");

            Assert.AreEqual("0.000", String.Format(CultureInfo.InvariantCulture, "{0:0.000}", obj.GetDouble("nothing")), "Check #1 failed");
            Assert.AreEqual("0.000", String.Format(CultureInfo.InvariantCulture, "{0:0.000}", obj.GetDouble("root.nothing")), "Check #2 failed");
            Assert.AreEqual("0.123", String.Format(CultureInfo.InvariantCulture, "{0:0.000}", obj.GetDouble("root.obj.value")), "Check #3 failed");
            Assert.AreEqual("0.000", String.Format(CultureInfo.InvariantCulture, "{0:0.000}", obj.GetDouble("root.obj.nothing")), "Check #4 failed");
            Assert.AreEqual("1234.567", String.Format(CultureInfo.InvariantCulture, "{0:0.000}", obj.GetDouble("root.obj.number")), "Check #5 failed");

            Assert.AreEqual(0, obj.GetDouble("root.obj"), "Check #6 failed");
            Assert.AreEqual(0, obj.GetDouble("root.empty"), "Check #7 failed");

        }

        [TestMethod]
        public void GetBoolean() {

            JObject root = new JObject();
            root.Add("property1", null);
            root.Add("property2", true);
            root.Add("property3", false);
            root.Add("property4", 1);
            root.Add("property5", 0);
            root.Add("property6", "true");
            root.Add("property7", "false");
            root.Add("obj", new JObject());
            root.Add("empty", "");

            JObject obj = new JObject();
            obj.Add("root", root);

            Assert.AreEqual(false, obj.GetBoolean("root.property0"), "Check #1 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.property1"), "Check #2 failed");
            Assert.AreEqual(true, obj.GetBoolean("root.property2"), "Check #3 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.property3"), "Check #4 failed");
            Assert.AreEqual(true, obj.GetBoolean("root.property4"), "Check #5 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.property5"), "Check #6 failed");
            Assert.AreEqual(true, obj.GetBoolean("root.property6"), "Check #7 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.property7"), "Check #8 failed");

            Assert.AreEqual(false, obj.GetBoolean("root.obj"), "Check #9 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.empty"), "Check #10 failed");

        }

        [TestMethod]
        public void GetEnumValue() {

            JObject root = new JObject();
            root.Add("property1", "NotFound");
            root.Add("property2", "notfound");
            root.Add("property3", "not_found");
            root.Add("property4", "OK");
            root.Add("property5", "Ok");
            root.Add("property6", "ok");

            JObject obj = new JObject();
            obj.Add("root", root);

            Assert.AreEqual(HttpStatusCode.NotFound, obj.GetEnum<HttpStatusCode>("root.property1"), "Check #1 failed");
            Assert.AreEqual(HttpStatusCode.NotFound, obj.GetEnum<HttpStatusCode>("root.property2"), "Check #2 failed");
            Assert.AreEqual(HttpStatusCode.NotFound, obj.GetEnum<HttpStatusCode>("root.property3"), "Check #3 failed");
            Assert.AreEqual(HttpStatusCode.OK, obj.GetEnum<HttpStatusCode>("root.property4"), "Check #4 failed");
            Assert.AreEqual(HttpStatusCode.OK, obj.GetEnum<HttpStatusCode>("root.property5"), "Check #5 failed");
            Assert.AreEqual(HttpStatusCode.OK, obj.GetEnum<HttpStatusCode>("root.property6"), "Check #6 failed");

        }

        [TestMethod]
        public void GetArray() {

            JObject obj = JObject.Parse("{\"null\":null,\"root\":{\"array\":[123,456,789]}}");

            Assert.AreEqual(null, obj.GetArray("null"), "Check #1 failed");
            Assert.AreEqual(null, obj.GetArray("nothing"), "Check #2 failed");
            Assert.AreEqual(3, obj.GetArray("root.array").Count, "Check #3 failed");

        }

        [TestMethod]
        public void GetArrayItems1() {

            JObject obj = JObject.Parse("{\"null\":null,\"root\":{\"array\":[123,456,789]}}");

            JToken[] array1 = obj.GetArrayItems("nope");
            int[] array2 = obj.GetArrayItems<int>("nope");

            JToken[] array3 = obj.GetArrayItems("null");
            int[] array4 = obj.GetArrayItems<int>("null");

            JToken[] array5 = obj.GetArrayItems("root.array");
            int[] array6 = obj.GetArrayItems<int>("root.array");

            Assert.AreEqual(0, array1.Length, "Check #1 failed");
            Assert.AreEqual(0, array2.Length, "Check #2 failed");
            Assert.AreEqual(0, array3.Length, "Check #3 failed");
            Assert.AreEqual(0, array4.Length, "Check #4 failed");
            Assert.AreEqual(3, array5.Length, "Check #5 failed");
            Assert.AreEqual(3, array6.Length, "Check #6 failed");

            Assert.AreEqual(123, array5[0], "Check #7 failed");
            Assert.AreEqual(456, array5[1], "Check #8 failed");
            Assert.AreEqual(789, array5[2], "Check #9 failed");

        }

        [TestMethod]
        public void GetArrayItems2() {

            JObject obj = JObject.Parse("{\"null\":null,\"root\":{\"array\":[{\"value\":\"Alpha\"},{\"value\":\"Bravo\"},{\"value\":\"Charlie\"}]}}");

            TestObject[] array1 = obj.GetArrayItems<JObject, TestObject>("nope", TestObject.Parse);
            TestObject[] array2 = obj.GetArrayItems("nope", TestObject.Parse);

            TestObject[] array3 = obj.GetArrayItems<JObject, TestObject>("null", TestObject.Parse);
            TestObject[] array4 = obj.GetArrayItems("null", TestObject.Parse);

            TestObject[] array5 = obj.GetArrayItems<JObject, TestObject>("root.array", TestObject.Parse);
            TestObject[] array6 = obj.GetArrayItems("root.array", TestObject.Parse);

            Assert.AreEqual(0, array1.Length, "Check #1 failed");
            Assert.AreEqual(0, array2.Length, "Check #2 failed");
            Assert.AreEqual(0, array3.Length, "Check #3 failed");
            Assert.AreEqual(0, array4.Length, "Check #4 failed");
            Assert.AreEqual(3, array5.Length, "Check #5 failed");
            Assert.AreEqual(3, array6.Length, "Check #6 failed");

            Assert.AreEqual("Alpha", array5[0].Value, "Check #7 failed");
            Assert.AreEqual("Bravo", array5[1].Value, "Check #8 failed");
            Assert.AreEqual("Charlie", array5[2].Value, "Check #9 failed");

        }

        [TestMethod]
        public void GetStringArray() {

            JObject obj = JObject.Parse("{\"null\":null,\"root\":{\"array\":[\"Alpha\",\"Bravo\",\"Charlie\"]}}");

            Assert.AreEqual(0, obj.GetStringArray("null").Length, "Check #1 failed");
            Assert.AreEqual(0, obj.GetStringArray("nothing").Length, "Check #2 failed");
            Assert.AreEqual(3, obj.GetStringArray("root.array").Length, "Check #3 failed");
            Assert.AreEqual("Alpha,Bravo,Charlie", String.Join(",", obj.GetStringArray("root.array")), "Check #4 failed");

        }

        [TestMethod]
        public void GetInt32Array() {

            JObject obj = JObject.Parse("{\"null\":null,\"root\":{\"array\":[123,456,789]}}");

            Assert.AreEqual(0, obj.GetInt32Array("null").Length, "Check #1 failed");
            Assert.AreEqual(0, obj.GetInt32Array("nothing").Length, "Check #2 failed");
            Assert.AreEqual(3, obj.GetInt32Array("root.array").Length, "Check #3 failed");
            Assert.AreEqual("123,456,789", String.Join(",", obj.GetInt32Array("root.array")), "Check #4 failed");

        }

        [TestMethod]
        public void GetInt64Array() {

            JObject obj = JObject.Parse("{\"null\":null,\"root\":{\"array\":[123,456,789]}}");

            Assert.AreEqual(0, obj.GetInt64Array("null").Length, "Check #1 failed");
            Assert.AreEqual(0, obj.GetInt64Array("nothing").Length, "Check #2 failed");
            Assert.AreEqual(3, obj.GetInt64Array("root.array").Length, "Check #3 failed");
            Assert.AreEqual("123,456,789", String.Join(",", obj.GetInt64Array("root.array")), "Check #4 failed");

        }

        public class TestObject {
            [JsonProperty("value")]
            public string Value { get; set; }
            public static TestObject Parse(JObject obj) {
                return obj == null ? null : new TestObject { Value = obj.GetString("value") };
            }
        }

    }

}

// ReSharper restore UseObjectOrCollectionInitializer