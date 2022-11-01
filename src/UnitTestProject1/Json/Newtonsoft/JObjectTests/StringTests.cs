using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace UnitTestProject1.Json.Newtonsoft.JObjectTests {

    [TestClass]
    public class StringTests {

        [TestMethod]
        public void GetString() {

            JObject inner = new JObject {
                {"value", "1234"},
                {"number", 1234},
                {"double", 1234.567},
                {"nothing", null},
                {"empty", string.Empty},
                {"whitespace", "    "},
                {"dateTime", new DateTime(2022, 11, 1, 11, 28, 37, 123)},
                {"dateTimeOffset", new DateTimeOffset(2022, 11, 1, 11, 28, 37, 123, TimeSpan.FromHours(1))}
            };

            JObject outer = new JObject {
                {"nothing", null},
                {"obj", inner}
            };

            JObject json = new JObject {
                {"outer", outer},
                {"obj", inner}
            };

            Assert.AreEqual(null, json.GetString("outer.nope"), "Check #1 failed");
            Assert.AreEqual(null, json.GetString("outer.nothing"), "Check #2 failed");

            Assert.AreEqual(null, json.GetString("outer.obj.nothing"), "Check #3 failed");
            Assert.AreEqual(null, json.GetString("outer.obj.value"), "Check #4 failed");
            Assert.AreEqual(null, json.GetString("outer.obj.number"), "Check #5 failed");
            Assert.AreEqual(null, json.GetString("outer.obj.double"), "Check #6 failed");
            Assert.AreEqual(null, json.GetString("outer.obj.empty"), "Check #7 failed");
            Assert.AreEqual(null, json.GetString("outer.obj.whitespace"), "Check #8 failed");
            Assert.AreEqual(null, json.GetString("outer.obj.dateTime"), "Check #9 failed");
            Assert.AreEqual(null, json.GetString("outer.obj.dateTimeOffset"), "Check #10 failed");

            Assert.IsNull(json.GetString("outer.obj"), "Check #11 failed");

            Assert.AreEqual(null, inner.GetString("nothing"), "Check #12 failed");
            Assert.AreEqual("1234", inner.GetString("value"), "Check #13 failed");
            Assert.AreEqual("1234", inner.GetString("number"), "Check #14 failed");
            Assert.AreEqual("1234.567", inner.GetString("double"), "Check #15 failed");
            Assert.AreEqual("", inner.GetString("empty"), "Check #16 failed");
            Assert.AreEqual("    ", inner.GetString("whitespace"), "Check #17 failed");
            Assert.AreEqual("2022-11-01T11:28:37.123", inner.GetString("dateTime"), "Check #18 failed");
            Assert.AreEqual("2022-11-01T11:28:37.123+01:00", inner.GetString("dateTimeOffset"), "Check #19 failed");

        }

        [TestMethod]
        public void GetStringByPath() {

            JObject inner = new JObject {
                {"value", "1234"},
                {"number", 1234},
                {"double", 1234.567},
                {"nothing", null},
                {"empty", string.Empty},
                {"whitespace", "    "},
                {"dateTime", new DateTime(2022, 11, 1, 11, 28, 37, 123)},
                {"dateTimeOffset", new DateTimeOffset(2022, 11, 1, 11, 28, 37, 123, TimeSpan.FromHours(1))}
            };

            JObject outer = new JObject {
                {"nothing", null},
                {"obj", inner}
            };

            JObject json = new JObject {
                {"outer", outer},
                {"obj", inner}
            };

            Assert.AreEqual(null, json.GetStringByPath("outer.nope"), "Check #1 failed");
            Assert.AreEqual(null, json.GetStringByPath("outer.nothing"), "Check #2 failed");

            Assert.AreEqual(null, json.GetStringByPath("outer.obj.nothing"), "Check #3 failed");
            Assert.AreEqual("1234", json.GetStringByPath("outer.obj.value"), "Check #4 failed");
            Assert.AreEqual("1234", json.GetStringByPath("outer.obj.number"), "Check #5 failed");
            Assert.AreEqual("1234.567", json.GetStringByPath("outer.obj.double"), "Check #6 failed");
            Assert.AreEqual("", json.GetStringByPath("outer.obj.empty"), "Check #7 failed");
            Assert.AreEqual("    ", json.GetStringByPath("outer.obj.whitespace"), "Check #8 failed");
            Assert.AreEqual("2022-11-01T11:28:37.123", json.GetStringByPath("outer.obj.dateTime"), "Check #9 failed");
            Assert.AreEqual("2022-11-01T11:28:37.123+01:00", json.GetStringByPath("outer.obj.dateTimeOffset"), "Check #10 failed");

            Assert.IsNull(json.GetStringByPath("outer.obj"), "Check #11 failed");

            Assert.AreEqual(null, inner.GetStringByPath("nothing"), "Check #12 failed");
            Assert.AreEqual("1234", inner.GetStringByPath("value"), "Check #13 failed");
            Assert.AreEqual("1234", inner.GetStringByPath("number"), "Check #14 failed");
            Assert.AreEqual("1234.567", inner.GetStringByPath("double"), "Check #15 failed");
            Assert.AreEqual("", inner.GetStringByPath("empty"), "Check #16 failed");
            Assert.AreEqual("    ", inner.GetStringByPath("whitespace"), "Check #17 failed");
            Assert.AreEqual("2022-11-01T11:28:37.123", inner.GetStringByPath("dateTime"), "Check #18 failed");
            Assert.AreEqual("2022-11-01T11:28:37.123+01:00", inner.GetStringByPath("dateTimeOffset"), "Check #19 failed");

        }

        [TestMethod]
        public void GetStringArray() {

            JObject json = new JObject {
                { "null", null },
                { "number", 1234 },
                { "float", 123.456 },
                { "string", "hello,world" },
                { "outer", new JObject { { "array", new JArray("Alpha", "Bravo", "Charlie") } } }
            };

            JObject outer = json.GetObject("outer");

            Assert.AreEqual(0, json.GetStringArray("null").Length, "Check #1 failed");
            Assert.AreEqual(0, json.GetStringArray("nothing").Length, "Check #2 failed");
            Assert.AreEqual(1, json.GetStringArray("number").Length, "Check #3 failed");
            Assert.AreEqual(1, json.GetStringArray("float").Length, "Check #4 failed");
            Assert.AreEqual(2, json.GetStringArray("string").Length, "Check #5 failed");
            Assert.AreEqual(0, json.GetStringArray("outer.array").Length, "Check #6 failed");
            Assert.AreEqual(3, outer.GetStringArray("array").Length, "Check #7 failed");

        }

        [TestMethod]
        public void GetStringArrayByPath() {

            JObject json = new JObject {
                { "null", null },
                { "number", 1234 },
                { "float", 123.456 },
                { "string", "hello,world" },
                { "outer", new JObject { { "array", new JArray("Alpha", "Bravo", "Charlie") } } }
            };

            JObject outer = json.GetObject("outer");

            Assert.AreEqual(0, json.GetStringArrayByPath("null").Length, "Check #1 failed");
            Assert.AreEqual(0, json.GetStringArrayByPath("nothing").Length, "Check #2 failed");
            Assert.AreEqual(1, json.GetStringArrayByPath("number").Length, "Check #3 failed");
            Assert.AreEqual(1, json.GetStringArrayByPath("float").Length, "Check #4 failed");
            Assert.AreEqual(2, json.GetStringArrayByPath("string").Length, "Check #5 failed");
            Assert.AreEqual(3, json.GetStringArrayByPath("outer.array").Length, "Check #6 failed");
            Assert.AreEqual(3, outer.GetStringArrayByPath("array").Length, "Check #7 failed");

        }

    }

}