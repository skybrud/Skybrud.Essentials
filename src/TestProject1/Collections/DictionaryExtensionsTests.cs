
using Skybrud.Essentials.Collections.Extensions;

namespace TestProject1.Collections {

    [TestClass]
    public class DictionaryExtensionsTests {

        [TestMethod]
        public void GetInt32() {

            Dictionary<object, object?> dictionary = new() {
                {"number", 123},
                {"long", 123L},
                {"longMax", long.MaxValue},
                {"string", "123"},
                {"null", null}
            };

            int a = dictionary.GetInt32("number");
            Assert.AreEqual(123, a, "#A");

            int b = dictionary.GetInt32("long");
            Assert.AreEqual(123, b, "#B");

            int c = dictionary.GetInt32("longMax");
            Assert.AreEqual(0, c, "#C");

            int d = dictionary.GetInt32("string");
            Assert.AreEqual(123, d, "#D");

            int e = dictionary.GetInt32("null");
            Assert.AreEqual(0, e, "#E");

            int f = dictionary.GetInt32("nope");
            Assert.AreEqual(0, f, "#F");

        }

        [TestMethod]
        public void GetInt32OrNull() {

            Dictionary<object, object?> dictionary = new() {
                {"number", 123},
                {"long", 123L},
                {"longMax", long.MaxValue},
                {"string", "123"},
                {"null", null}
            };

            int? a = dictionary.GetInt32OrNull("number");
            Assert.AreEqual(123, a, "#A");

            int? b = dictionary.GetInt32OrNull("long");
            Assert.AreEqual(123, b, "#B");

            int? c = dictionary.GetInt32OrNull("longMax");
            Assert.AreEqual(null, c, "#C");

            int? d = dictionary.GetInt32OrNull("string");
            Assert.AreEqual(123, d, "#D");

            int? e = dictionary.GetInt32OrNull("null");
            Assert.AreEqual(null, e, "#E");

            int? f = dictionary.GetInt32OrNull("nope");
            Assert.AreEqual(null, f, "#F");

        }

        [TestMethod]
        public void GetInt64() {

            Dictionary<object, object?> dictionary = new() {
                {"number", 123},
                {"long", 123L},
                {"longMax", long.MaxValue},
                {"string", "123"},
                {"null", null}
            };

            long a = dictionary.GetInt64("number");
            Assert.AreEqual(123, a, "#A");

            long b = dictionary.GetInt64("long");
            Assert.AreEqual(123, b, "#B");

            long c = dictionary.GetInt64("longMax");
            Assert.AreEqual(long.MaxValue, c, "#C");

            long d = dictionary.GetInt64("string");
            Assert.AreEqual(123, d, "#D");

            long e = dictionary.GetInt64("null");
            Assert.AreEqual(0, e, "#E");

            long f = dictionary.GetInt64("nope");
            Assert.AreEqual(0, f, "#F");

        }

        [TestMethod]
        public void GetInt64OrNull() {

            Dictionary<object, object?> dictionary = new() {
                {"number", 123},
                {"long", 123L},
                {"longMax", long.MaxValue},
                {"string", "123"},
                {"null", null}
            };

            long? a = dictionary.GetInt64OrNull("number");
            Assert.AreEqual(123, a, "#A");

            long? b = dictionary.GetInt64OrNull("long");
            Assert.AreEqual(123, b, "#B");

            long? c = dictionary.GetInt64OrNull("longMax");
            Assert.AreEqual(long.MaxValue, c, "#C");

            long? d = dictionary.GetInt64OrNull("string");
            Assert.AreEqual(123, d, "#D");

            long? e = dictionary.GetInt64OrNull("null");
            Assert.AreEqual(null, e, "#E");

            long? f = dictionary.GetInt64OrNull("nope");
            Assert.AreEqual(null, f, "#E");

        }

    }

}