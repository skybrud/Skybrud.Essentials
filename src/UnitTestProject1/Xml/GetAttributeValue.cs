using System;
using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Xml.Extensions;

namespace UnitTestProject1.Xml {
    
    [TestClass]
    public class GetAttributeValue {

        [TestMethod]
        public void AsString() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            // Get an attribute using each overload
            string attr1 = root.GetAttributeValue((XName)"attr");
            int attr2 = root.GetAttributeValue((XName)"integer", Int32.Parse);
            string attr3 = root.GetAttributeValue("element/child/@number");
            string attr4 = root.GetAttributeValue("test:element/test:child/@number", namespaces);
            int attr5 = root.GetAttributeValue("element/child/@number", Int32.Parse);
            int attr6 = root.GetAttributeValue("test:element/test:child/@number", namespaces, Int32.Parse);

            Assert.AreEqual("value", attr1, "#1");
            Assert.AreEqual(42, attr2, "#2");
            Assert.AreEqual("4321", attr3, "#3");
            Assert.AreEqual("1234", attr4, "#4");
            Assert.AreEqual(4321, attr5, "#5");
            Assert.AreEqual(1234, attr6, "#6");

        }

        [TestMethod]
        public void AsInt32() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            // Get an attribute using each overload
            int attr1 = root.GetAttributeValueAsInt32((XName)"integer");
            string attr2 = root.GetAttributeValueAsInt32((XName)"integer", x => x + "");
            int attr3 = root.GetAttributeValueAsInt32("element/child/@number");
            int attr4 = root.GetAttributeValueAsInt32("test:element/test:child/@number", namespaces);
            string attr5 = root.GetAttributeValueAsInt32("element/child/@number", x => x + "");
            string attr6 = root.GetAttributeValueAsInt32("test:element/test:child/@number", namespaces, x => x + "");

            Assert.AreEqual(42, attr1, "#1");
            Assert.AreEqual("42", attr2, "#2");
            Assert.AreEqual(4321, attr3, "#3");
            Assert.AreEqual(1234, attr4, "#4");
            Assert.AreEqual("4321", attr5, "#5");
            Assert.AreEqual("1234", attr6, "#6");

        }
    
    }

}