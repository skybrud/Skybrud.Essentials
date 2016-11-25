using System.Globalization;
using System.Net;
using Newtonsoft.Json;
using Skybrud.Essentials.Json.Extensions;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace UnitTestProject1.Json {

    [TestClass]
    public class JsonHelperTests {

        [TestMethod]
        public void ParseJsonObject() {

            JObject obj = JObject.Parse("{\"date\":\"Fri, 25 Nov 2016 16:25:35 GMT\",\"guid\":\"d6cd5a0c-e2d0-44ad-871f-987c263dcbbb\"}");

            Assert.AreEqual("Fri, 25 Nov 2016 16:25:35 GMT", obj.GetString("date"), "Check #1 failed");
            Assert.AreEqual("String", obj.GetString("date").GetType().Name, "Check #2 failed");

            Assert.AreEqual("d6cd5a0c-e2d0-44ad-871f-987c263dcbbb", obj.GetString("guid"), "Check #3 failed");
            Assert.AreEqual("String", obj.GetString("guid").GetType().Name, "Check #4 failed");

        }
    
    }

}

// ReSharper restore UseObjectOrCollectionInitializer