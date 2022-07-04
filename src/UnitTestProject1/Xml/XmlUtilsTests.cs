using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Xml;

namespace UnitTestProject1.Xml {

    [TestClass]
    public class XmlUtilsTests {

        [TestMethod]
        public void ToStringDefault() {

            XDocument document = new XDocument(
                new XElement(
                    "hello",
                    new XElement("world", "Hello World")
                )
            );

            const string expected = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<hello>\r\n  <world>Hello World</world>\r\n</hello>";

            Assert.AreEqual(expected, XmlUtils.ToString(document));

        }

        [TestMethod]
        public void ToStringUtf8() {

            XDocument document = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"),
                new XElement(
                    "hello",
                    new XElement("world", "Hello World")
                )
            );

            const string expected = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"no\"?>\r\n<hello>\r\n  <world>Hello World</world>\r\n</hello>";

            Assert.AreEqual(expected, XmlUtils.ToString(document));

        }

        [TestMethod]
        public void ToStringUtf8Standalone() {

            XDocument document = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(
                    "hello",
                    new XElement("world", "Hello World")
                )
            );

            const string expected = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>\r\n<hello>\r\n  <world>Hello World</world>\r\n</hello>";

            Assert.AreEqual(expected, XmlUtils.ToString(document));

        }

        [TestMethod]
        public void ToStringIso8859() {

            XDocument document = new XDocument(
                new XDeclaration("1.0", "ISO-8859-1", "yes"),
                new XElement(
                    "hello",
                    new XElement("world", "Hello World")
                )
            );

            const string expected = "<?xml version=\"1.0\" encoding=\"iso-8859-1\" standalone=\"yes\"?>\r\n<hello>\r\n  <world>Hello World</world>\r\n</hello>";

            Assert.AreEqual(expected, XmlUtils.ToString(document));

        }

        [TestMethod]
        public void ToStringUtf8DisableFormatting() {

            XDocument document = new XDocument(
                new XDeclaration("1.0", "utf-8", null),
                new XElement(
                    "hello",
                    new XElement("world", "Hello World")
                )
            );

            const string expected = "<?xml version=\"1.0\" encoding=\"utf-8\"?><hello><world>Hello World</world></hello>";

            Assert.AreEqual(expected, XmlUtils.ToString(document, SaveOptions.DisableFormatting));

        }

    }

}