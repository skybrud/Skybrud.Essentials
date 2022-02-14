using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Json.Extensions;

namespace UnitTestProject1.Json {

    [TestClass]
    public class JsonTests {

        [TestMethod]
        public void ParseJsonObject() {

            JObject obj = JObject.Parse("{\"date\":\"Fri, 25 Nov 2016 16:25:35 GMT\",\"guid\":\"d6cd5a0c-e2d0-44ad-871f-987c263dcbbb\"}");

            Assert.AreEqual("Fri, 25 Nov 2016 16:25:35 GMT", obj.GetString("date"), "Check #1 failed");
            Assert.AreEqual("String", obj.GetString("date").GetType().Name, "Check #2 failed");

            Assert.AreEqual("d6cd5a0c-e2d0-44ad-871f-987c263dcbbb", obj.GetString("guid"), "Check #3 failed");
            Assert.AreEqual("String", obj.GetString("guid").GetType().Name, "Check #4 failed");

        }

        [TestMethod]
        public void ParseJsonObject2() {

            string json1 = "{\"value\":\"1234\"}";

            JObject obj1 = JsonUtils.ParseJsonObject(json1);
            TestObject obj2 = JsonUtils.ParseJsonObject(json1, TestObject.Parse);
            TestObject obj3 = JsonUtils.ParseJsonObject<TestObject>(json1);

            Assert.IsNotNull(obj1, "Check #1 failed");
            Assert.IsNotNull(obj2, "Check #2 failed");
            Assert.IsNotNull(obj3, "Check #3 failed");

        }

        [TestMethod]
        public void ParseJsonArray() {

            string json1 = "[{\"value\":\"1234\"}]";

            JArray obj1 = JsonUtils.ParseJsonArray(json1);
            TestObject[] obj2 = JsonUtils.ParseJsonArray(json1, TestObject.Parse);
            TestObject[] obj3 = JsonUtils.ParseJsonArray<TestObject>(json1);

            Assert.IsNotNull(obj1, "Check #1 failed");
            Assert.IsNotNull(obj2, "Check #2 failed");
            Assert.IsNotNull(obj3, "Check #3 failed");

            Assert.AreEqual(1, obj1.Count, "Check #1 failed");
            Assert.AreEqual(1, obj2.Length, "Check #2 failed");
            Assert.AreEqual(1, obj3.Length, "Check #3 failed");

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