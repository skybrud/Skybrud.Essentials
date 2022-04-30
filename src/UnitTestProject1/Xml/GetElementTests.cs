using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Xml.Extensions;

namespace UnitTestProject1.Xml {

    [TestClass]
    public class GetElementTests {

        [TestMethod]
        public void GetElement() {

            XElement root = XElement.Parse(
                "<root xmlns:test=\"http://social.skybrud.dk/schemas/test\">" +
                "<example>12345678</example>" +
                "<test:example>87654321</test:example>" +
                "<test><example>XPath</example></test>" +
                "</root>"
            );

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            // Test with a normal XName parameter (element name)
            XElement example1 = root.GetElement((XName) "example");
            Assert.IsNotNull(example1);
            Assert.AreEqual("12345678", example1.Value);

            // Test with XPath and namespaces
            XElement example2 = root.GetElement("test:example", namespaces);
            Assert.IsNotNull(example2);
            Assert.AreEqual("87654321", example2.Value);

            // Test with regular XPath query
            XElement example3 = root.GetElement("test/example");
            Assert.IsNotNull(example3);
            Assert.AreEqual("XPath", example3.Value);

        }

        [TestMethod]
        public void GetElements() {

            XElement root = XElement.Parse(
                "<root xmlns:test=\"http://social.skybrud.dk/schemas/test\">" +
                "<example>12345678</example>" +
                "<example>ABCDEFGH</example>" +
                "<test:example>87654321</test:example>" +
                "<test:example>ABCDEFGH</test:example>" +
                "<test><example>XPath</example></test>" +
                "</root>"
            );

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            // Test with a normal XName parameter (element name)
            XElement[] example1 = root.GetElements((XName) "example");
            Assert.IsNotNull(example1);
            Assert.AreEqual("12345678", example1[0].Value);
            Assert.AreEqual("ABCDEFGH", example1[1].Value);

            // Test with XPath and namespaces
            XElement[] example2 = root.GetElements("test:example", namespaces);
            Assert.IsNotNull(example2);
            Assert.AreEqual("87654321", example2[0].Value);
            Assert.AreEqual("ABCDEFGH", example2[1].Value);

            // Test with regular XPath query
            XElement[] example3 = root.GetElements("test/example");
            Assert.IsNotNull(example3);
            Assert.AreEqual("XPath", example3[0].Value);

        }

    }

}