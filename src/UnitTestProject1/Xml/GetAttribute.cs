using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Xml.Extensions;

namespace UnitTestProject1.Xml {

    [TestClass]
    public class GetAttribute {

        [TestMethod]
        public void Test1() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            // Get an attribute using each overload
            XAttribute attr1 = root.GetAttribute((XName) "attr");
            XAttribute attr2 = root.GetAttribute("@attr");
            XAttribute attr3 = root.GetAttribute("element/child/@attribute");
            XAttribute attr4 = root.GetAttribute("test:element/test:child/@attribute", namespaces);

            Assert.IsNotNull(attr1, "#1");
            Assert.AreEqual("value", attr1.Value, "#1");

            Assert.IsNotNull(attr2, "#2");
            Assert.AreEqual("value", attr2.Value, "#2");

            Assert.IsNotNull(attr3, "#3");
            Assert.AreEqual("hejsa", attr3.Value, "#3");

            Assert.IsNotNull(attr4, "#4");
            Assert.AreEqual("hej", attr4.Value, "#4");

        }

    }

}