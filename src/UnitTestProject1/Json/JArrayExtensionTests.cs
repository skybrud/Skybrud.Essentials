using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace UnitTestProject1.Json {

    [TestClass]
    public class JArrayExtensionTests {

        [TestMethod]
        public void GetBooleanByIndex() {

            string rawJson = new JObject {
                {"array", new JArray {
                    null,
                    "",
                    "true",
                    "True",
                    "false",
                    "False",
                    "Nope",
                    "0",
                    "1",
                    "2",
                    0,
                    1,
                    2,
                    true,
                    false,
                    "2021-09-19T13:24:18+02:00",
                    new JObject(),
                    new JArray()
                }}
            }.ToString();

            JObject json = JObject.Parse(rawJson);

            JArray array = json.GetArray("array");

            Assert.IsFalse(array.GetBoolean(0), "#0");
            Assert.IsFalse(array.GetBoolean(1), "#1");
            Assert.IsTrue(array.GetBoolean(2), "#2");
            Assert.IsTrue(array.GetBoolean(3), "#3");
            Assert.IsFalse(array.GetBoolean(4), "#4");
            Assert.IsFalse(array.GetBoolean(5), "#5");
            Assert.IsFalse(array.GetBoolean(6), "#6");
            Assert.IsFalse(array.GetBoolean(7), "#7");
            Assert.IsTrue(array.GetBoolean(8), "#8");
            Assert.IsFalse(array.GetBoolean(9), "#9");
            Assert.IsFalse(array.GetBoolean(10), "#10");
            Assert.IsTrue(array.GetBoolean(11), "#11");
            Assert.IsFalse(array.GetBoolean(12), "#12");
            Assert.IsTrue(array.GetBoolean(13), "#13");
            Assert.IsFalse(array.GetBoolean(14), "#14");
            Assert.IsFalse(array.GetBoolean(15), "#15");
            Assert.IsFalse(array.GetBoolean(16), "#16");
            Assert.IsFalse(array.GetBoolean(17), "#17");

        }

        [TestMethod]
        public void GetBooleanByIndexWithFallback() {

            string rawJson = new JObject {
                {"array", new JArray {
                    null,
                    "",
                    "true",
                    "True",
                    "false",
                    "False",
                    "Nope",
                    "0",
                    "1",
                    "2",
                    0,
                    1,
                    2,
                    true,
                    false,
                    "2021-09-19T13:24:18+02:00",
                    new JObject(),
                    new JArray()
                }}
            }.ToString();

            JObject json = JObject.Parse(rawJson);

            JArray array = json.GetArray("array");

            Assert.IsFalse(array.GetBoolean(0, false), "#0");
            Assert.IsFalse(array.GetBoolean(1, false), "#1");
            Assert.IsTrue(array.GetBoolean(2, false), "#2");
            Assert.IsTrue(array.GetBoolean(3, false), "#3");
            Assert.IsFalse(array.GetBoolean(4, false), "#4");
            Assert.IsFalse(array.GetBoolean(5, false), "#5");
            Assert.IsFalse(array.GetBoolean(6, false), "#6");
            Assert.IsFalse(array.GetBoolean(7, false), "#7");
            Assert.IsTrue(array.GetBoolean(8, false), "#8");
            Assert.IsFalse(array.GetBoolean(9, false), "#9");
            Assert.IsFalse(array.GetBoolean(10, false), "#10");
            Assert.IsTrue(array.GetBoolean(11, false), "#11");
            Assert.IsFalse(array.GetBoolean(12, false), "#12");
            Assert.IsTrue(array.GetBoolean(13, false), "#13");
            Assert.IsFalse(array.GetBoolean(14, false), "#14");
            Assert.IsFalse(array.GetBoolean(15, false), "#15");
            Assert.IsFalse(array.GetBoolean(16, false), "#16");
            Assert.IsFalse(array.GetBoolean(17, false), "#17");

            Assert.IsTrue(array.GetBoolean(0, true), "#0");
            Assert.IsTrue(array.GetBoolean(1, true), "#1");
            Assert.IsTrue(array.GetBoolean(2, true), "#2");
            Assert.IsTrue(array.GetBoolean(3, true), "#3");
            Assert.IsFalse(array.GetBoolean(4, true), "#4");
            Assert.IsFalse(array.GetBoolean(5, true), "#5");
            Assert.IsTrue(array.GetBoolean(6, true), "#6");
            Assert.IsFalse(array.GetBoolean(7, true), "#7");
            Assert.IsTrue(array.GetBoolean(8, true), "#8");
            Assert.IsTrue(array.GetBoolean(9, true), "#9");
            Assert.IsFalse(array.GetBoolean(10, true), "#10");
            Assert.IsTrue(array.GetBoolean(11, true), "#11");
            Assert.IsTrue(array.GetBoolean(12, true), "#12");
            Assert.IsTrue(array.GetBoolean(13, true), "#13");
            Assert.IsFalse(array.GetBoolean(14, true), "#14");
            Assert.IsTrue(array.GetBoolean(15, true), "#15");
            Assert.IsTrue(array.GetBoolean(16, true), "#16");
            Assert.IsTrue(array.GetBoolean(17, true), "#17");

        }

        [TestMethod]
        public void GetBooleanByPath() {

            string rawJson = new JObject {
                {"array", new JArray {
                    null,
                    "",
                    "true",
                    "True",
                    "false",
                    "False",
                    "Nope",
                    "0",
                    "1",
                    "2",
                    0,
                    1,
                    2,
                    true,
                    false,
                    "2021-09-19T13:24:18+02:00",
                    new JObject(),
                    new JArray()
                }}
            }.ToString();

            JObject json = JObject.Parse(rawJson);

            Assert.IsFalse(json.GetBooleanByPath("array[0]"), "#0");
            Assert.IsFalse(json.GetBooleanByPath("array[1]"), "#1");
            Assert.IsTrue(json.GetBooleanByPath("array[2]"), "#2");
            Assert.IsTrue(json.GetBooleanByPath("array[3]"), "#3");
            Assert.IsFalse(json.GetBooleanByPath("array[4]"), "#4");
            Assert.IsFalse(json.GetBooleanByPath("array[5]"), "#5");
            Assert.IsFalse(json.GetBooleanByPath("array[6]"), "#6");
            Assert.IsFalse(json.GetBooleanByPath("array[7]"), "#7");
            Assert.IsTrue(json.GetBooleanByPath("array[8]"), "#8");
            Assert.IsFalse(json.GetBooleanByPath("array[9]"), "#9");
            Assert.IsFalse(json.GetBooleanByPath("array[10]"), "#10");
            Assert.IsTrue(json.GetBooleanByPath("array[11]"), "#11");
            Assert.IsFalse(json.GetBooleanByPath("array[12]"), "#12");
            Assert.IsTrue(json.GetBooleanByPath("array[13]"), "#13");
            Assert.IsFalse(json.GetBooleanByPath("array[14]"), "#14");
            Assert.IsFalse(json.GetBooleanByPath("array[15]"), "#15");
            Assert.IsFalse(json.GetBooleanByPath("array[16]"), "#16");
            Assert.IsFalse(json.GetBooleanByPath("array[17]"), "#17");
            Assert.IsFalse(json.GetBooleanByPath("array[18]"), "#18");

        }

        [TestMethod]
        public void GetBooleanByPathWithFallback() {

            string rawJson = new JObject {
                {"array", new JArray {
                    null,
                    "",
                    "true",
                    "True",
                    "false",
                    "False",
                    "Nope",
                    "0",
                    "1",
                    "2",
                    0,
                    1,
                    2,
                    true,
                    false,
                    "2021-09-19T13:24:18+02:00",
                    new JObject(),
                    new JArray()
                }}
            }.ToString();

            JObject json = JObject.Parse(rawJson);

            Assert.IsFalse(json.GetBooleanByPath("array[0]", false), "#0");
            Assert.IsFalse(json.GetBooleanByPath("array[1]", false), "#1");
            Assert.IsTrue(json.GetBooleanByPath("array[2]", false), "#2");
            Assert.IsTrue(json.GetBooleanByPath("array[3]", false), "#3");
            Assert.IsFalse(json.GetBooleanByPath("array[4]", false), "#4");
            Assert.IsFalse(json.GetBooleanByPath("array[5]", false), "#5");
            Assert.IsFalse(json.GetBooleanByPath("array[6]", false), "#6");
            Assert.IsFalse(json.GetBooleanByPath("array[7]", false), "#7");
            Assert.IsTrue(json.GetBooleanByPath("array[8]", false), "#8");
            Assert.IsFalse(json.GetBooleanByPath("array[9]", false), "#9");
            Assert.IsFalse(json.GetBooleanByPath("array[10]", false), "#10");
            Assert.IsTrue(json.GetBooleanByPath("array[11]", false), "#11");
            Assert.IsFalse(json.GetBooleanByPath("array[12]", false), "#12");
            Assert.IsTrue(json.GetBooleanByPath("array[13]", false), "#13");
            Assert.IsFalse(json.GetBooleanByPath("array[14]", false), "#14");
            Assert.IsFalse(json.GetBooleanByPath("array[15]", false), "#15");
            Assert.IsFalse(json.GetBooleanByPath("array[16]", false), "#16");
            Assert.IsFalse(json.GetBooleanByPath("array[17]", false), "#17");
            Assert.IsFalse(json.GetBooleanByPath("array[18]", false), "#18");

            Assert.IsTrue(json.GetBooleanByPath("array[0]", true), "#0");
            Assert.IsTrue(json.GetBooleanByPath("array[1]", true), "#1");
            Assert.IsTrue(json.GetBooleanByPath("array[2]", true), "#2");
            Assert.IsTrue(json.GetBooleanByPath("array[3]", true), "#3");
            Assert.IsFalse(json.GetBooleanByPath("array[4]", true), "#4");
            Assert.IsFalse(json.GetBooleanByPath("array[5]", true), "#5");
            Assert.IsTrue(json.GetBooleanByPath("array[6]", true), "#6");
            Assert.IsFalse(json.GetBooleanByPath("array[7]", true), "#7");
            Assert.IsTrue(json.GetBooleanByPath("array[8]", true), "#8");
            Assert.IsTrue(json.GetBooleanByPath("array[9]", true), "#9");
            Assert.IsFalse(json.GetBooleanByPath("array[10]", true), "#10");
            Assert.IsTrue(json.GetBooleanByPath("array[11]", true), "#11");
            Assert.IsTrue(json.GetBooleanByPath("array[12]", true), "#12");
            Assert.IsTrue(json.GetBooleanByPath("array[13]", true), "#13");
            Assert.IsFalse(json.GetBooleanByPath("array[14]", true), "#14");
            Assert.IsTrue(json.GetBooleanByPath("array[15]", true), "#15");
            Assert.IsTrue(json.GetBooleanByPath("array[16]", true), "#16");
            Assert.IsTrue(json.GetBooleanByPath("array[17]", true), "#17");
            Assert.IsTrue(json.GetBooleanByPath("array[18]", true), "#18");

        }

    }

}