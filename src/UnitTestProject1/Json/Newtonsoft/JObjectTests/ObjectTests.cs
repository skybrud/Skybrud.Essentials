using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace UnitTestProject1.Json.Newtonsoft.JObjectTests {

    [TestClass]
    public class ObjectTests {

        [TestMethod]
        public void GetObject() {

            JObject json = JObject.Parse("{\"nothing\":null,\"obj\":{\"value\":\"1234\"},\"outer\":{\"nothing\":null,\"obj\":{\"value\":\"1234\"}}}");

            Assert.IsNull(json.GetObject("nope"), "Check #1 failed");
            Assert.IsNull(json.GetObject("nothing"), "Check #2 failed");
            Assert.IsNotNull(json.GetObject("obj"), "Check #3 failed");

            Assert.IsNotNull(json.GetObject("outer"), "Check #4 failed");

            Assert.IsNull(json.GetObject("outer.nope"), "Check #5 failed");
            Assert.IsNull(json.GetObject("outer.nothing"), "Check #6 failed");
            Assert.IsNull(json.GetObject("outer.obj"), "Check #7 failed");

            Assert.IsNull(json.GetObject<TestObject>("outer.hest"), "Check #8 failed");
            Assert.IsNull(json.GetObject<TestObject>("outer.obj"), "Check #9 failed");

        }

        [TestMethod]
        public void GetObjectByPath() {

            JObject json = JObject.Parse("{\"nothing\":null,\"obj\":{\"value\":\"1234\"},\"outer\":{\"nothing\":null,\"obj\":{\"value\":\"1234\"}}}");

            Assert.IsNull(json.GetObjectByPath("nope"), "Check #1 failed");
            Assert.IsNull(json.GetObjectByPath("nothing"), "Check #2 failed");
            Assert.IsNotNull(json.GetObjectByPath("obj"), "Check #3 failed");

            Assert.IsNotNull(json.GetObjectByPath("outer"), "Check #4 failed");

            Assert.IsNull(json.GetObjectByPath("outer.nope"), "Check #5 failed");
            Assert.IsNull(json.GetObjectByPath("outer.nothing"), "Check #6 failed");
            Assert.IsNotNull(json.GetObjectByPath("outer.obj"), "Check #7 failed");

            Assert.IsNull(json.GetObjectByPath<TestObject>("outer.hest"), "Check #8 failed");
            Assert.IsNotNull(json.GetObjectByPath<TestObject>("outer.obj"), "Check #9 failed");

        }

        public class TestObject {
            [JsonProperty("value")]
            public string Value { get; set; }
            public static ArrayTests.TestObject Parse(JObject obj) {
                return obj == null ? null : new ArrayTests.TestObject { Value = obj.GetString("value") };
            }
        }

    }

}