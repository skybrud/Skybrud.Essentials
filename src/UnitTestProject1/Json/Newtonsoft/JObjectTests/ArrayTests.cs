using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace UnitTestProject1.Json.Newtonsoft.JObjectTests {

    [TestClass]
    public class ArrayTests {

        [TestMethod]
        public void GetArray() {

            JObject obj = JObject.Parse("{\"null\":null,\"root\":{\"array\":[123,456,789]}}");

            Assert.AreEqual(null, obj.GetArray("null"), "Check #1 failed");
            Assert.AreEqual(null, obj.GetArray("nothing"), "Check #2 failed");
            Assert.IsNull(obj.GetArray("root.array"), "Check #3 failed");

        }

        [TestMethod]
        public void GetArrayByPath() {

            JObject obj = JObject.Parse("{\"null\":null,\"root\":{\"array\":[123,456,789]}}");

            Assert.AreEqual(null, obj.GetArrayByPath("null"), "Check #1 failed");
            Assert.AreEqual(null, obj.GetArrayByPath("nothing"), "Check #2 failed");
            Assert.AreEqual(3, obj.GetArrayByPath("root.array")?.Count, "Check #3 failed");

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
            Assert.AreEqual(0, array5.Length, "Check #5 failed");
            Assert.AreEqual(0, array6.Length, "Check #6 failed");

        }

        [TestMethod]
        public void GetArrayItemsByPath1() {

            JObject obj = JObject.Parse("{\"null\":null,\"root\":{\"array\":[123,456,789]}}");

            JToken[] array1 = obj.GetArrayItemsByPath("nope");
            int[] array2 = obj.GetArrayItemsByPath<int>("nope");

            JToken[] array3 = obj.GetArrayItemsByPath("null");
            int[] array4 = obj.GetArrayItemsByPath<int>("null");

            JToken[] array5 = obj.GetArrayItemsByPath("root.array");
            int[] array6 = obj.GetArrayItemsByPath<int>("root.array");

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
            Assert.AreEqual(0, array5.Length, "Check #5 failed");
            Assert.AreEqual(0, array6.Length, "Check #6 failed");

        }

        [TestMethod]
        public void GetArrayItemsByPath2() {

            JObject obj = JObject.Parse("{\"null\":null,\"root\":{\"array\":[{\"value\":\"Alpha\"},{\"value\":\"Bravo\"},{\"value\":\"Charlie\"}]}}");

            TestObject[] array1 = obj.GetArrayItemsByPath<JObject, TestObject>("nope", TestObject.Parse);
            TestObject[] array2 = obj.GetArrayItemsByPath("nope", TestObject.Parse);

            TestObject[] array3 = obj.GetArrayItemsByPath<JObject, TestObject>("null", TestObject.Parse);
            TestObject[] array4 = obj.GetArrayItemsByPath("null", TestObject.Parse);

            TestObject[] array5 = obj.GetArrayItemsByPath<JObject, TestObject>("root.array", TestObject.Parse);
            TestObject[] array6 = obj.GetArrayItemsByPath("root.array", TestObject.Parse);

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

        public class TestObject {
            [JsonProperty("value")]
            public string Value { get; set; }
            public static TestObject Parse(JObject obj) {
                return obj == null ? null : new TestObject { Value = obj.GetString("value") };
            }
        }

    }

}