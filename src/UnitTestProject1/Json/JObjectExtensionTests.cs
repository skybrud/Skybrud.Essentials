using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace UnitTestProject1.Json {

    [TestClass]
    public class JObjectExtensionTests {

        [TestMethod]
        public void GetBoolean() {

            string rawJson = new JObject {
                {"a", null},
                {"b", ""},
                {"c", "true"},
                {"d", "True"},
                {"e", "false"},
                {"f", "False"},
                {"g", "Nope"},
                {"h", "0"},
                {"i", "1"},
                {"j", "2"},
                {"k", 0},
                {"l", 1},
                {"m", 2},
                {"n", true},
                {"o", false},
                {"p", "2021-09-19T13:24:18+02:00"},
                {"q", new JObject()},
                {"r", new JArray()}
            }.ToString();

            JObject json = JObject.Parse(rawJson);

            Assert.IsFalse(json.GetBoolean("a"), "a");
            Assert.IsFalse(json.GetBoolean("b"), "b");
            Assert.IsTrue(json.GetBoolean("c"), "c");
            Assert.IsTrue(json.GetBoolean("d"), "d");
            Assert.IsFalse(json.GetBoolean("e"), "e");
            Assert.IsFalse(json.GetBoolean("f"), "f");
            Assert.IsFalse(json.GetBoolean("g"), "g");
            Assert.IsFalse(json.GetBoolean("h"), "h");
            Assert.IsTrue(json.GetBoolean("i"), "i");
            Assert.IsFalse(json.GetBoolean("j"), "j");
            Assert.IsFalse(json.GetBoolean("k"), "k");
            Assert.IsTrue(json.GetBoolean("l"), "l");
            Assert.IsFalse(json.GetBoolean("m"), "m");
            Assert.IsTrue(json.GetBoolean("n"), "n");
            Assert.IsFalse(json.GetBoolean("o"), "o");
            Assert.IsFalse(json.GetBoolean("p"), "p");
            Assert.IsFalse(json.GetBoolean("q"), "q");
            Assert.IsFalse(json.GetBoolean("r"), "r");
            Assert.IsFalse(json.GetBoolean("t"), "t");

        }

        [TestMethod]
        public void GetBooleanWithFallback() {

            string rawJson = new JObject {
                {"a", null},
                {"b", ""},
                {"c", "true"},
                {"d", "True"},
                {"e", "false"},
                {"f", "False"},
                {"g", "Nope"},
                {"h", "0"},
                {"i", "1"},
                {"j", "2"},
                {"k", 0},
                {"l", 1},
                {"m", 2},
                {"n", true},
                {"o", false},
                {"p", "2021-09-19T13:24:18+02:00"},
                {"q", new JObject()},
                {"r", new JArray()}
            }.ToString();

            JObject json = JObject.Parse(rawJson);

            Assert.IsFalse(json.GetBoolean("a", false), "a");
            Assert.IsFalse(json.GetBoolean("b", false), "b");
            Assert.IsTrue(json.GetBoolean("c", false), "c");
            Assert.IsTrue(json.GetBoolean("d", false), "d");
            Assert.IsFalse(json.GetBoolean("e", false), "e");
            Assert.IsFalse(json.GetBoolean("f", false), "f");
            Assert.IsFalse(json.GetBoolean("g", false), "g");
            Assert.IsFalse(json.GetBoolean("h", false), "h");
            Assert.IsTrue(json.GetBoolean("i", false), "i");
            Assert.IsFalse(json.GetBoolean("j", false), "j");
            Assert.IsFalse(json.GetBoolean("k", false), "k");
            Assert.IsTrue(json.GetBoolean("l", false), "l");
            Assert.IsFalse(json.GetBoolean("m", false), "m");
            Assert.IsTrue(json.GetBoolean("n", false), "n");
            Assert.IsFalse(json.GetBoolean("o", false), "o");
            Assert.IsFalse(json.GetBoolean("p", false), "p");
            Assert.IsFalse(json.GetBoolean("q", false), "q");
            Assert.IsFalse(json.GetBoolean("r", false), "r");
            Assert.IsFalse(json.GetBoolean("t", false), "t");

            Assert.IsTrue(json.GetBoolean("a", true), "a");
            Assert.IsTrue(json.GetBoolean("b", true), "b");
            Assert.IsTrue(json.GetBoolean("c", true), "c");
            Assert.IsTrue(json.GetBoolean("d", true), "d");
            Assert.IsFalse(json.GetBoolean("e", true), "e");
            Assert.IsFalse(json.GetBoolean("f", true), "f");
            Assert.IsTrue(json.GetBoolean("g", true), "g");
            Assert.IsFalse(json.GetBoolean("h", true), "h");
            Assert.IsTrue(json.GetBoolean("i", true), "i");
            Assert.IsTrue(json.GetBoolean("j", true), "j");
            Assert.IsFalse(json.GetBoolean("k", true), "k");
            Assert.IsTrue(json.GetBoolean("l", true), "l");
            Assert.IsTrue(json.GetBoolean("m", true), "m");
            Assert.IsTrue(json.GetBoolean("n", true), "n");
            Assert.IsFalse(json.GetBoolean("o", true), "o");
            Assert.IsTrue(json.GetBoolean("p", true), "p");
            Assert.IsTrue(json.GetBoolean("q", true), "q");
            Assert.IsTrue(json.GetBoolean("r", true), "r");
            Assert.IsTrue(json.GetBoolean("t", true), "t");

        }

    }

}