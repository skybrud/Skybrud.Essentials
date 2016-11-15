using System;
using System.Globalization;
using System.Net;
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
            string attr2 = root.GetAttributeValueAsInt32((XName)"integer", TestHelpers.ToString);
            int attr3 = root.GetAttributeValueAsInt32("element/child/@number");
            int attr4 = root.GetAttributeValueAsInt32("test:element/test:child/@number", namespaces);
            string attr5 = root.GetAttributeValueAsInt32("element/child/@number", TestHelpers.ToString);
            string attr6 = root.GetAttributeValueAsInt32("test:element/test:child/@number", namespaces, TestHelpers.ToString);

            Assert.AreEqual(42, attr1, "#1");
            Assert.AreEqual("42", attr2, "#2");
            Assert.AreEqual(4321, attr3, "#3");
            Assert.AreEqual(1234, attr4, "#4");
            Assert.AreEqual("4321", attr5, "#5");
            Assert.AreEqual("1234", attr6, "#6");

        }

        [TestMethod]
        public void AsInt64() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            // Get an attribute using each overload
            long attr1 = root.GetAttributeValueAsInt64((XName)"long");
            string attr2 = root.GetAttributeValueAsInt64((XName)"long", TestHelpers.ToString);
            long attr3 = root.GetAttributeValueAsInt64("element/child/@long");
            long attr4 = root.GetAttributeValueAsInt64("test:element/test:child/@long", namespaces);
            string attr5 = root.GetAttributeValueAsInt64("element/child/@long", TestHelpers.ToString);
            string attr6 = root.GetAttributeValueAsInt64("test:element/test:child/@long", namespaces, TestHelpers.ToString);

            Assert.AreEqual(1234567891234, attr1, "#1");
            Assert.AreEqual("1234567891234", attr2, "#2");
            Assert.AreEqual(1234567891234, attr3, "#3");
            Assert.AreEqual(1234567891234, attr4, "#4");
            Assert.AreEqual("1234567891234", attr5, "#5");
            Assert.AreEqual("1234567891234", attr6, "#6");

        }

        [TestMethod]
        public void AsSingle() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            // Get an attribute using each overload
            float attr1 = root.GetAttributeValueAsSingle((XName)"pi");
            string attr2 = root.GetAttributeValueAsSingle((XName)"pi", TestHelpers.ToString);
            float attr3 = root.GetAttributeValueAsSingle("element/child/@pi");
            float attr4 = root.GetAttributeValueAsSingle("test:element/test:child/@pi", namespaces);
            string attr5 = root.GetAttributeValueAsSingle("element/child/@pi", TestHelpers.ToString);
            string attr6 = root.GetAttributeValueAsSingle("test:element/test:child/@pi", namespaces, TestHelpers.ToString);

            Assert.AreEqual("3.140000", attr1.ToString("N6", CultureInfo.InvariantCulture), "#1");
            Assert.AreEqual("3.14", attr2, "#2");
            Assert.AreEqual("3.140000", attr3.ToString("N6", CultureInfo.InvariantCulture), "#3");
            Assert.AreEqual("3.140000", attr4.ToString("N6", CultureInfo.InvariantCulture), "#4");
            Assert.AreEqual("3.14", attr5, "#5");
            Assert.AreEqual("3.14", attr6, "#6");

        }

        [TestMethod]
        public void AsDouble() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            // Get an attribute using each overload
            double attr1 = root.GetAttributeValueAsDouble((XName)"pi");
            string attr2 = root.GetAttributeValueAsDouble((XName)"pi", TestHelpers.ToString);
            double attr3 = root.GetAttributeValueAsDouble("element/child/@double");
            double attr4 = root.GetAttributeValueAsDouble("test:element/test:child/@double", namespaces);
            string attr5 = root.GetAttributeValueAsDouble("element/child/@double", TestHelpers.ToString);
            string attr6 = root.GetAttributeValueAsDouble("test:element/test:child/@double", namespaces, TestHelpers.ToString);

            Assert.AreEqual(3.14, attr1, "#1");
            Assert.AreEqual("3.14", attr2, "#2");
            Assert.AreEqual(3.14159265359, attr3, "#3");
            Assert.AreEqual(3.14, attr4, "#4");
            Assert.AreEqual("3.14159265359", attr5, "#5");
            Assert.AreEqual("3.14", attr6, "#6");

        }

        [TestMethod]
        public void AsBoolean1() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            bool attr1 = root.GetAttributeAsBoolean((XName) "boolean1");
            bool attr2 = root.GetAttributeAsBoolean((XName) "boolean2");
            bool attr3 = root.GetAttributeAsBoolean((XName) "boolean3");
            bool attr4 = root.GetAttributeAsBoolean((XName) "boolean4");
            string attr5 = root.GetAttributeAsBoolean((XName) "boolean1", TestHelpers.ToString);
            string attr6 = root.GetAttributeAsBoolean((XName) "boolean2", TestHelpers.ToString);
            string attr7 = root.GetAttributeAsBoolean((XName) "boolean3", TestHelpers.ToString);
            string attr8 = root.GetAttributeAsBoolean((XName) "boolean4", TestHelpers.ToString);

            Assert.AreEqual(true, attr1, "#1");
            Assert.AreEqual(false, attr2, "#2");
            Assert.AreEqual(true, attr3, "#3");
            Assert.AreEqual(false, attr4, "#4");

            Assert.AreEqual("True", attr5, "#5");
            Assert.AreEqual("False", attr6, "#6");
            Assert.AreEqual("True", attr7, "#7");
            Assert.AreEqual("False", attr8, "#8");

        }

        [TestMethod]
        public void AsBoolean2() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            bool attr1 = root.GetAttributeAsBoolean("element/a/@boolean1");
            bool attr2 = root.GetAttributeAsBoolean("element/a/@boolean2");
            bool attr3 = root.GetAttributeAsBoolean("element/a/@boolean3");
            bool attr4 = root.GetAttributeAsBoolean("element/a/@boolean4");
            bool attr5 = root.GetAttributeAsBoolean("element/b/@boolean1");
            bool attr6 = root.GetAttributeAsBoolean("element/b/@boolean2");
            bool attr7 = root.GetAttributeAsBoolean("element/b/@boolean3");
            bool attr8 = root.GetAttributeAsBoolean("element/b/@boolean4");

            Assert.AreEqual(true, attr1, "#1");
            Assert.AreEqual(false, attr2, "#2");
            Assert.AreEqual(true, attr3, "#3");
            Assert.AreEqual(false, attr4, "#4");
            Assert.AreEqual(true, attr5, "#5");
            Assert.AreEqual(false, attr6, "#6");
            Assert.AreEqual(true, attr7, "#7");
            Assert.AreEqual(false, attr8, "#8");

        }

        [TestMethod]
        public void AsBoolean3() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            string attr1 = root.GetAttributeAsBoolean("element/a/@boolean1", TestHelpers.ToString);
            string attr2 = root.GetAttributeAsBoolean("element/a/@boolean2", TestHelpers.ToString);
            string attr3 = root.GetAttributeAsBoolean("element/a/@boolean3", TestHelpers.ToString);
            string attr4 = root.GetAttributeAsBoolean("element/a/@boolean4", TestHelpers.ToString);
            string attr5 = root.GetAttributeAsBoolean("element/b/@boolean1", TestHelpers.ToString);
            string attr6 = root.GetAttributeAsBoolean("element/b/@boolean2", TestHelpers.ToString);
            string attr7 = root.GetAttributeAsBoolean("element/b/@boolean3", TestHelpers.ToString);
            string attr8 = root.GetAttributeAsBoolean("element/b/@boolean4", TestHelpers.ToString);

            Assert.AreEqual("True", attr1, "#1");
            Assert.AreEqual("False", attr2, "#2");
            Assert.AreEqual("True", attr3, "#3");
            Assert.AreEqual("False", attr4, "#4");
            Assert.AreEqual("True", attr5, "#5");
            Assert.AreEqual("False", attr6, "#6");
            Assert.AreEqual("True", attr7, "#7");
            Assert.AreEqual("False", attr8, "#8");

        }

        [TestMethod]
        public void AsBoolean4() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            bool attr1 = root.GetAttributeAsBoolean("test:element/test:a/@boolean1", namespaces);
            bool attr2 = root.GetAttributeAsBoolean("test:element/test:a/@boolean2", namespaces);
            bool attr3 = root.GetAttributeAsBoolean("test:element/test:a/@boolean3", namespaces);
            bool attr4 = root.GetAttributeAsBoolean("test:element/test:a/@boolean4", namespaces);
            bool attr5 = root.GetAttributeAsBoolean("test:element/test:b/@boolean1", namespaces);
            bool attr6 = root.GetAttributeAsBoolean("test:element/test:b/@boolean2", namespaces);
            bool attr7 = root.GetAttributeAsBoolean("test:element/test:b/@boolean3", namespaces);
            bool attr8 = root.GetAttributeAsBoolean("test:element/test:b/@boolean4", namespaces);

            Assert.AreEqual(true, attr1, "#1");
            Assert.AreEqual(false, attr2, "#2");
            Assert.AreEqual(true, attr3, "#3");
            Assert.AreEqual(false, attr4, "#4");
            Assert.AreEqual(true, attr5, "#5");
            Assert.AreEqual(false, attr6, "#6");
            Assert.AreEqual(true, attr7, "#7");
            Assert.AreEqual(false, attr8, "#8");

        }

        [TestMethod]
        public void AsBoolean5() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            string attr1 = root.GetAttributeAsBoolean("test:element/test:a/@boolean1", namespaces, TestHelpers.ToString);
            string attr2 = root.GetAttributeAsBoolean("test:element/test:a/@boolean2", namespaces, TestHelpers.ToString);
            string attr3 = root.GetAttributeAsBoolean("test:element/test:a/@boolean3", namespaces, TestHelpers.ToString);
            string attr4 = root.GetAttributeAsBoolean("test:element/test:a/@boolean4", namespaces, TestHelpers.ToString);
            string attr5 = root.GetAttributeAsBoolean("test:element/test:b/@boolean1", namespaces, TestHelpers.ToString);
            string attr6 = root.GetAttributeAsBoolean("test:element/test:b/@boolean2", namespaces, TestHelpers.ToString);
            string attr7 = root.GetAttributeAsBoolean("test:element/test:b/@boolean3", namespaces, TestHelpers.ToString);
            string attr8 = root.GetAttributeAsBoolean("test:element/test:b/@boolean4", namespaces, TestHelpers.ToString);

            Assert.AreEqual("True", attr1, "#1");
            Assert.AreEqual("False", attr2, "#2");
            Assert.AreEqual("True", attr3, "#3");
            Assert.AreEqual("False", attr4, "#4");
            Assert.AreEqual("True", attr5, "#5");
            Assert.AreEqual("False", attr6, "#6");
            Assert.AreEqual("True", attr7, "#7");
            Assert.AreEqual("False", attr8, "#8");

        }

        [TestMethod]
        public void AsEnum1() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            HttpStatusCode attr1 = root.GetAttributeValueAsEnum<HttpStatusCode>("element/c/@enum1");
            HttpStatusCode attr2 = root.GetAttributeValueAsEnum<HttpStatusCode>("element/c/@enum2");
            HttpStatusCode attr3 = root.GetAttributeValueAsEnum<HttpStatusCode>("element/c/@enum3");
            HttpStatusCode attr4 = root.GetAttributeValueAsEnum<HttpStatusCode>("element/c/@enum4");

            HttpStatusCode attr5 = root.GetAttributeValueAsEnum("element/c/@enum1", HttpStatusCode.NoContent);
            HttpStatusCode attr6 = root.GetAttributeValueAsEnum("element/c/@enum2", HttpStatusCode.NoContent);
            HttpStatusCode attr7 = root.GetAttributeValueAsEnum("element/c/@enum3", HttpStatusCode.NoContent);
            HttpStatusCode attr8 = root.GetAttributeValueAsEnum("element/c/@enum4", HttpStatusCode.NoContent);
            HttpStatusCode attr9 = root.GetAttributeValueAsEnum("element/c/@enum5", HttpStatusCode.NoContent);

            Assert.AreEqual(HttpStatusCode.OK, attr1, "#1");
            Assert.AreEqual(HttpStatusCode.NotFound, attr2, "#2");
            Assert.AreEqual(HttpStatusCode.NotFound, attr3, "#3");
            Assert.AreEqual(HttpStatusCode.NotFound, attr4, "#4");

            Assert.AreEqual(HttpStatusCode.OK, attr5, "#5");
            Assert.AreEqual(HttpStatusCode.NotFound, attr6, "#6");
            Assert.AreEqual(HttpStatusCode.NotFound, attr7, "#7");
            Assert.AreEqual(HttpStatusCode.NotFound, attr8, "#8");
            Assert.AreEqual(HttpStatusCode.NoContent, attr9, "#9");

        }
        
        [TestMethod]
        public void AsEnum2() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            HttpStatusCode attr1 = root.GetAttributeValueAsEnum<HttpStatusCode>("test:element/test:c/@enum1", namespaces);
            HttpStatusCode attr2 = root.GetAttributeValueAsEnum<HttpStatusCode>("test:element/test:c/@enum2", namespaces);
            HttpStatusCode attr3 = root.GetAttributeValueAsEnum<HttpStatusCode>("test:element/test:c/@enum3", namespaces);
            HttpStatusCode attr4 = root.GetAttributeValueAsEnum<HttpStatusCode>("test:element/test:c/@enum4", namespaces);

            HttpStatusCode attr5 = root.GetAttributeValueAsEnum("test:element/test:c/@enum1", namespaces, HttpStatusCode.NoContent);
            HttpStatusCode attr6 = root.GetAttributeValueAsEnum("test:element/test:c/@enum2", namespaces, HttpStatusCode.NoContent);
            HttpStatusCode attr7 = root.GetAttributeValueAsEnum("test:element/test:c/@enum3", namespaces, HttpStatusCode.NoContent);
            HttpStatusCode attr8 = root.GetAttributeValueAsEnum("test:element/test:c/@enum4", namespaces, HttpStatusCode.NoContent);
            HttpStatusCode attr9 = root.GetAttributeValueAsEnum("test:element/test:c/@enum5", namespaces, HttpStatusCode.NoContent);

            Assert.AreEqual(HttpStatusCode.OK, attr1, "#1");
            Assert.AreEqual(HttpStatusCode.NotFound, attr2, "#2");
            Assert.AreEqual(HttpStatusCode.NotFound, attr3, "#3");
            Assert.AreEqual(HttpStatusCode.NotFound, attr4, "#4");

            Assert.AreEqual(HttpStatusCode.OK, attr5, "#5");
            Assert.AreEqual(HttpStatusCode.NotFound, attr6, "#6");
            Assert.AreEqual(HttpStatusCode.NotFound, attr7, "#7");
            Assert.AreEqual(HttpStatusCode.NotFound, attr8, "#8");
            Assert.AreEqual(HttpStatusCode.NoContent, attr9, "#9");

        }

    }

}