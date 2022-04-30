using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Strings.Extensions;

// ReSharper disable ConvertToConstant.Local
// ReSharper disable ExpressionIsAlwaysNull

namespace UnitTestProject1.Strings {

    [TestClass]
    public class NameValueCollectionTests {

        [TestMethod]
        public void ToUrlEncodedString1() {

            NameValueCollection nvc = null;

            string encoded = nvc.ToUrlEncodedString();

            Assert.IsNotNull(encoded);
            Assert.AreEqual("", encoded);

        }

        [TestMethod]
        public void ToUrlEncodedString2() {

            NameValueCollection nvc = new NameValueCollection {
                {"hello", "world"}
            };

            string encoded = nvc.ToUrlEncodedString();

            Assert.IsNotNull(encoded);
            Assert.AreEqual("hello=world", encoded);

        }

        [TestMethod]
        public void ToUrlEncodedString3() {

            NameValueCollection nvc = new NameValueCollection {
                {"rød", "grød"},
                {"med", "fløde"}
            };

            string encoded = nvc.ToUrlEncodedString();

            Assert.IsNotNull(encoded);
            Assert.AreEqual("r%c3%b8d=gr%c3%b8d&med=fl%c3%b8de", encoded);

        }

        [TestMethod]
        public void ToNameValueCollection1() {

            string encoded = null;

            NameValueCollection nvc = encoded.ToNameValueCollection();

            Assert.IsNotNull(nvc);
            Assert.AreEqual(0, nvc.Count);

        }

        [TestMethod]
        public void ToNameValueCollection2() {

            string encoded = null;

            NameValueCollection nvc = encoded.ToNameValueCollection();

            Assert.IsNotNull(nvc);
            Assert.AreEqual(0, nvc.Count);

        }

        [TestMethod]
        public void ToNameValueCollection3() {

            string encoded = "hello=world";

            NameValueCollection nvc = encoded.ToNameValueCollection();

            Assert.IsNotNull(nvc);
            Assert.AreEqual(1, nvc.Count);
            Assert.AreEqual("world", nvc["hello"]);

        }

        [TestMethod]
        public void ToNameValueCollection4() {

            string encoded = "r%c3%b8d=gr%c3%b8d&med=fl%c3%b8de";

            NameValueCollection nvc = encoded.ToNameValueCollection();

            Assert.IsNotNull(nvc);
            Assert.AreEqual(2, nvc.Count);
            Assert.AreEqual("grød", nvc["rød"]);
            Assert.AreEqual("fløde", nvc["med"]);

        }

    }

}