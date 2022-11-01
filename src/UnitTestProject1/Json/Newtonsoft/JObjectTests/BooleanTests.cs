using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

// ReSharper disable UseObjectOrCollectionInitializer

namespace UnitTestProject1.Json.Newtonsoft.JObjectTests {

    [TestClass]
    public class BooleanTests {

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

            Assert.AreEqual(false, root.GetBoolean("property0"), "Check #1 failed");
            Assert.AreEqual(false, root.GetBoolean("property1"), "Check #2 failed");
            Assert.AreEqual(true, root.GetBoolean("property2"), "Check #3 failed");
            Assert.AreEqual(false, root.GetBoolean("property3"), "Check #4 failed");
            Assert.AreEqual(true, root.GetBoolean("property4"), "Check #5 failed");
            Assert.AreEqual(false, root.GetBoolean("property5"), "Check #6 failed");
            Assert.AreEqual(true, root.GetBoolean("property6"), "Check #7 failed");
            Assert.AreEqual(false, root.GetBoolean("property7"), "Check #8 failed");

            Assert.AreEqual(false, obj.GetBoolean("obj"), "Check #9 failed");
            Assert.AreEqual(false, obj.GetBoolean("empty"), "Check #10 failed");

            Assert.AreEqual(false, obj.GetBoolean("root.property0"), "Check #11 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.property1"), "Check #12 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.property2"), "Check #13 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.property3"), "Check #14 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.property4"), "Check #15 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.property5"), "Check #16 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.property6"), "Check #17 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.property7"), "Check #18 failed");

            Assert.AreEqual(false, obj.GetBoolean("root.obj"), "Check #19 failed");
            Assert.AreEqual(false, obj.GetBoolean("root.empty"), "Check #20 failed");

        }

        [TestMethod]
        public void GetBooleanByPath() {

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

            Assert.AreEqual(false, obj.GetBooleanByPath("root.property0"), "Check #1 failed");
            Assert.AreEqual(false, obj.GetBooleanByPath("root.property1"), "Check #2 failed");
            Assert.AreEqual(true, obj.GetBooleanByPath("root.property2"), "Check #3 failed");
            Assert.AreEqual(false, obj.GetBooleanByPath("root.property3"), "Check #4 failed");
            Assert.AreEqual(true, obj.GetBooleanByPath("root.property4"), "Check #5 failed");
            Assert.AreEqual(false, obj.GetBooleanByPath("root.property5"), "Check #6 failed");
            Assert.AreEqual(true, obj.GetBooleanByPath("root.property6"), "Check #7 failed");
            Assert.AreEqual(false, obj.GetBooleanByPath("root.property7"), "Check #8 failed");

            Assert.AreEqual(false, obj.GetBooleanByPath("root.obj"), "Check #9 failed");
            Assert.AreEqual(false, obj.GetBooleanByPath("root.empty"), "Check #10 failed");

        }

    }

}