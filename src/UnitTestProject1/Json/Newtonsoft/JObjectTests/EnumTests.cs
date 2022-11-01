using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

// ReSharper disable UseObjectOrCollectionInitializer

namespace UnitTestProject1.Json.Newtonsoft.JObjectTests {

    [TestClass]
    public class EnumTests {

        [TestMethod]
        public void GetEnumValue() {

            JObject root = new JObject();
            root.Add("property1", "NotFound");
            root.Add("property2", "notfound");
            root.Add("property3", "not_found");
            root.Add("property4", "OK");
            root.Add("property5", "Ok");
            root.Add("property6", "ok");

            JObject json = new JObject();
            json.Add("root", root);

            Assert.AreEqual(default, json.GetEnum<HttpStatusCode>("root.property1", default), "Check #1 failed");
            Assert.AreEqual(default, json.GetEnum<HttpStatusCode>("root.property2", default), "Check #2 failed");
            Assert.AreEqual(default, json.GetEnum<HttpStatusCode>("root.property3", default), "Check #3 failed");
            Assert.AreEqual(default, json.GetEnum<HttpStatusCode>("root.property4", default), "Check #4 failed");
            Assert.AreEqual(default, json.GetEnum<HttpStatusCode>("root.property5", default), "Check #5 failed");
            Assert.AreEqual(default, json.GetEnum<HttpStatusCode>("root.property6", default), "Check #6 failed");

            Assert.AreEqual(HttpStatusCode.NotFound, root.GetEnum<HttpStatusCode>("property1", default), "Check #7 failed");
            Assert.AreEqual(HttpStatusCode.NotFound, root.GetEnum<HttpStatusCode>("property2", default), "Check #8 failed");
            Assert.AreEqual(HttpStatusCode.NotFound, root.GetEnum<HttpStatusCode>("property3", default), "Check #9 failed");
            Assert.AreEqual(HttpStatusCode.OK, root.GetEnum<HttpStatusCode>("property4", default), "Check #10 failed");
            Assert.AreEqual(HttpStatusCode.OK, root.GetEnum<HttpStatusCode>("property5", default), "Check #11 failed");
            Assert.AreEqual(HttpStatusCode.OK, root.GetEnum<HttpStatusCode>("property6", default), "Check #12 failed");

        }

        [TestMethod]
        public void GetEnumValueByPath() {

            JObject root = new JObject();
            root.Add("property1", "NotFound");
            root.Add("property2", "notfound");
            root.Add("property3", "not_found");
            root.Add("property4", "OK");
            root.Add("property5", "Ok");
            root.Add("property6", "ok");

            JObject json = new JObject();
            json.Add("root", root);

            Assert.AreEqual(HttpStatusCode.NotFound, json.GetEnumByPath<HttpStatusCode>("root.property1", default), "Check #1 failed");
            Assert.AreEqual(HttpStatusCode.NotFound, json.GetEnumByPath<HttpStatusCode>("root.property2", default), "Check #2 failed");
            Assert.AreEqual(HttpStatusCode.NotFound, json.GetEnumByPath<HttpStatusCode>("root.property3", default), "Check #3 failed");
            Assert.AreEqual(HttpStatusCode.OK, json.GetEnumByPath<HttpStatusCode>("root.property4", default), "Check #4 failed");
            Assert.AreEqual(HttpStatusCode.OK, json.GetEnumByPath<HttpStatusCode>("root.property5", default), "Check #5 failed");
            Assert.AreEqual(HttpStatusCode.OK, json.GetEnumByPath<HttpStatusCode>("root.property6", default), "Check #6 failed");

            Assert.AreEqual(HttpStatusCode.NotFound, root.GetEnumByPath<HttpStatusCode>("property1", default), "Check #7 failed");
            Assert.AreEqual(HttpStatusCode.NotFound, root.GetEnumByPath<HttpStatusCode>("property2", default), "Check #8 failed");
            Assert.AreEqual(HttpStatusCode.NotFound, root.GetEnumByPath<HttpStatusCode>("property3", default), "Check #9 failed");
            Assert.AreEqual(HttpStatusCode.OK, root.GetEnumByPath<HttpStatusCode>("property4", default), "Check #10 failed");
            Assert.AreEqual(HttpStatusCode.OK, root.GetEnumByPath<HttpStatusCode>("property5", default), "Check #11 failed");
            Assert.AreEqual(HttpStatusCode.OK, root.GetEnumByPath<HttpStatusCode>("property6", default), "Check #12 failed");

        }

    }

}