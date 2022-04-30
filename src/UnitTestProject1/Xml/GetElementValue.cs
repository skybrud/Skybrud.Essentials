using System;
using System.Globalization;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Xml.Extensions;

namespace UnitTestProject1.Xml {

    [TestClass]
    public class GetElementValue {

        [TestMethod]
        public void AsString() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            // Get an element using each overload
            string element1 = root.GetElementValue((XName) "string");
            int element2 = root.GetElementValue((XName) "integer", Int32.Parse);
            string element3 = root.GetElementValue("element/number");
            string element4 = root.GetElementValue("test:element/test:number", namespaces);
            int element5 = root.GetElementValue("element/number", Int32.Parse);
            int element6 = root.GetElementValue("test:element/test:number", namespaces, Int32.Parse);
            string value7 = root.GetElementValue("element/empty");
            string value8 = root.GetElementValue("test:element/test:empty", namespaces);
            string value9 = root.GetElementValue("element/nothing");
            string value10 = root.GetElementValue("test:element/test:nothing", namespaces);

            Assert.AreEqual("Hello World", element1, "#1");
            Assert.AreEqual(42, element2, "#2");
            Assert.AreEqual("4321", element3, "#3");
            Assert.AreEqual("1234", element4, "#4");
            Assert.AreEqual(4321, element5, "#5");
            Assert.AreEqual(1234, element6, "#6");
            Assert.AreEqual("", value7, "#7");
            Assert.AreEqual("", value8, "#8");
            Assert.AreEqual("", value9, "#9");
            Assert.AreEqual("", value10, "#10");

        }

        [TestMethod]
        public void AsInt32() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            // Get an attribute using each overload
            int attr1 = root.GetElementValueAsInt32((XName) "integer");
            string attr2 = root.GetElementValueAsInt32((XName) "integer", TestHelpers.ToString);
            int attr3 = root.GetElementValueAsInt32("element/number");
            int attr4 = root.GetElementValueAsInt32("test:element/test:number", namespaces);
            string attr5 = root.GetElementValueAsInt32("element/number", TestHelpers.ToString);
            string attr6 = root.GetElementValueAsInt32("test:element/test:number", namespaces, TestHelpers.ToString);
            int attr7 = root.GetElementValueAsInt32("element/empty");
            int attr8 = root.GetElementValueAsInt32("test:element/test:empty", namespaces);

            Assert.AreEqual(42, attr1, "#1");
            Assert.AreEqual("42", attr2, "#2");
            Assert.AreEqual(4321, attr3, "#3");
            Assert.AreEqual(1234, attr4, "#4");
            Assert.AreEqual("4321", attr5, "#5");
            Assert.AreEqual("1234", attr6, "#6");
            Assert.AreEqual(0, attr7, "#7");
            Assert.AreEqual(0, attr8, "#8");

        }

        [TestMethod]
        public void AsInt64() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            // Get an attribute using each overload
            long attr1 = root.GetElementValueAsInt64((XName) "long");
            string attr2 = root.GetElementValueAsInt64((XName) "long", TestHelpers.ToString);
            long attr3 = root.GetElementValueAsInt64("element/long");
            long attr4 = root.GetElementValueAsInt64("test:element/test:long", namespaces);
            string attr5 = root.GetElementValueAsInt64("element/long", TestHelpers.ToString);
            string attr6 = root.GetElementValueAsInt64("test:element/test:long", namespaces, TestHelpers.ToString);
            long attr7 = root.GetElementValueAsInt64("element/empty");
            long attr8 = root.GetElementValueAsInt64("test:element/test:empty", namespaces);

            Assert.AreEqual(1234567891234, attr1, "#1");
            Assert.AreEqual("1234567891234", attr2, "#2");
            Assert.AreEqual(1234567891234, attr3, "#3");
            Assert.AreEqual(1234567891234, attr4, "#4");
            Assert.AreEqual("1234567891234", attr5, "#5");
            Assert.AreEqual("1234567891234", attr6, "#6");
            Assert.AreEqual(0, attr7, "#7");
            Assert.AreEqual(0, attr8, "#8");

        }

        [TestMethod]
        public void AsSingle() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            // Get an attribute using each overload
            float attr1 = root.GetElementValueAsSingle((XName) "float");
            string attr2 = root.GetElementValueAsSingle((XName) "float", TestHelpers.ToString);
            float attr3 = root.GetElementValueAsSingle("element/float");
            float attr4 = root.GetElementValueAsSingle("test:element/test:float", namespaces);
            string attr5 = root.GetElementValueAsSingle("element/float", TestHelpers.ToString);
            string attr6 = root.GetElementValueAsSingle("test:element/test:float", namespaces, TestHelpers.ToString);
            float attr7 = root.GetElementValueAsSingle("element/empty");
            float attr8 = root.GetElementValueAsSingle("test:element/test:empty", namespaces);

            Assert.AreEqual("3.140000", attr1.ToString("N6", CultureInfo.InvariantCulture), "#1");
            Assert.AreEqual("3.14", attr2, "#2");
            Assert.AreEqual("3.140000", attr3.ToString("N6", CultureInfo.InvariantCulture), "#3");
            Assert.AreEqual("3.140000", attr4.ToString("N6", CultureInfo.InvariantCulture), "#4");
            Assert.AreEqual("3.14", attr5, "#5");
            Assert.AreEqual("3.14", attr6, "#6");
            Assert.AreEqual(0, attr7, "#7");
            Assert.AreEqual(0, attr8, "#8");

        }

        [TestMethod]
        public void AsDouble() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            // Get an attribute using each overload
            double attr01 = root.GetElementValueAsDouble((XName) "float");
            string attr02 = root.GetElementValueAsDouble((XName) "float", TestHelpers.ToString);
            double attr03 = root.GetElementValueAsDouble((XName) "double");
            string attr04 = root.GetElementValueAsDouble((XName) "double", TestHelpers.ToString);

            double attr05 = root.GetElementValueAsDouble("element/float");
            double attr06 = root.GetElementValueAsDouble("test:element/test:float", namespaces);
            string attr07 = root.GetElementValueAsDouble("element/float", TestHelpers.ToString);
            string attr08 = root.GetElementValueAsDouble("test:element/test:float", namespaces, TestHelpers.ToString);

            double attr09 = root.GetElementValueAsDouble("element/double");
            double attr10 = root.GetElementValueAsDouble("test:element/test:double", namespaces);
            string attr11 = root.GetElementValueAsDouble("element/double", TestHelpers.ToString);
            string attr12 = root.GetElementValueAsDouble("test:element/test:double", namespaces, TestHelpers.ToString);

            double attr13 = root.GetElementValueAsDouble("element/empty");
            double attr14 = root.GetElementValueAsDouble("test:element/test:empty", namespaces);

            Assert.AreEqual(3.14, attr01, "#1");
            Assert.AreEqual("3.14", attr02, "#2");
            Assert.AreEqual(3.14159265359, attr03, "#3");
            Assert.AreEqual("3.14159265359", attr04, "#4");

            Assert.AreEqual(3.14, attr05, "#5");
            Assert.AreEqual(3.14, attr06, "#6");
            Assert.AreEqual("3.14", attr07, "#7");
            Assert.AreEqual("3.14", attr08, "#8");

            Assert.AreEqual(3.14159265359, attr09, "#9");
            Assert.AreEqual(3.14159265359, attr10, "#10");
            Assert.AreEqual("3.14159265359", attr11, "#11");
            Assert.AreEqual("3.14159265359", attr12, "#12");

            Assert.AreEqual(0, attr13, "#13");
            Assert.AreEqual(0, attr14, "#14");

        }

        [TestMethod]
        public void AsBoolean1() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XElement element = root.GetElement("element");
            XElement booleans = element.GetElement("booleans");

            bool attr01 = booleans.GetElementValueAsBoolean((XName) "boolean1");
            bool attr02 = booleans.GetElementValueAsBoolean((XName) "boolean2");
            bool attr03 = booleans.GetElementValueAsBoolean((XName) "boolean3");
            bool attr04 = booleans.GetElementValueAsBoolean((XName) "boolean4");
            bool attr05 = booleans.GetElementValueAsBoolean((XName) "boolean5");
            bool attr06 = booleans.GetElementValueAsBoolean((XName) "boolean6");
            bool attr07 = booleans.GetElementValueAsBoolean((XName) "boolean7");
            bool attr08 = booleans.GetElementValueAsBoolean((XName) "boolean8");

            string attr09 = booleans.GetElementValueAsBoolean((XName) "boolean1", TestHelpers.ToString);
            string attr10 = booleans.GetElementValueAsBoolean((XName) "boolean2", TestHelpers.ToString);
            string attr11 = booleans.GetElementValueAsBoolean((XName) "boolean3", TestHelpers.ToString);
            string attr12 = booleans.GetElementValueAsBoolean((XName) "boolean4", TestHelpers.ToString);
            string attr13 = booleans.GetElementValueAsBoolean((XName) "boolean5", TestHelpers.ToString);
            string attr14 = booleans.GetElementValueAsBoolean((XName) "boolean6", TestHelpers.ToString);
            string attr15 = booleans.GetElementValueAsBoolean((XName) "boolean7", TestHelpers.ToString);
            string attr16 = booleans.GetElementValueAsBoolean((XName) "boolean8", TestHelpers.ToString);

            Assert.AreEqual(true, attr01, "#1");
            Assert.AreEqual(false, attr02, "#2");
            Assert.AreEqual(true, attr03, "#3");
            Assert.AreEqual(false, attr04, "#4");
            Assert.AreEqual(true, attr05, "#5");
            Assert.AreEqual(false, attr06, "#6");
            Assert.AreEqual(true, attr07, "#7");
            Assert.AreEqual(false, attr08, "#8");

            Assert.AreEqual("True", attr09, "#9");
            Assert.AreEqual("False", attr10, "#10");
            Assert.AreEqual("True", attr11, "#11");
            Assert.AreEqual("False", attr12, "#12");
            Assert.AreEqual("True", attr13, "#13");
            Assert.AreEqual("False", attr14, "#14");
            Assert.AreEqual("True", attr15, "#15");
            Assert.AreEqual("False", attr16, "#16");

        }

        [TestMethod]
        public void AsBoolean2() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            bool attr01 = root.GetElementValueAsBoolean("element/booleans/boolean1");
            bool attr02 = root.GetElementValueAsBoolean("element/booleans/boolean2");
            bool attr03 = root.GetElementValueAsBoolean("element/booleans/boolean3");
            bool attr04 = root.GetElementValueAsBoolean("element/booleans/boolean4");
            bool attr05 = root.GetElementValueAsBoolean("element/booleans/boolean5");
            bool attr06 = root.GetElementValueAsBoolean("element/booleans/boolean6");
            bool attr07 = root.GetElementValueAsBoolean("element/booleans/boolean7");
            bool attr08 = root.GetElementValueAsBoolean("element/booleans/boolean8");

            string attr09 = root.GetElementValueAsBoolean("element/booleans/boolean1", TestHelpers.ToString);
            string attr10 = root.GetElementValueAsBoolean("element/booleans/boolean2", TestHelpers.ToString);
            string attr11 = root.GetElementValueAsBoolean("element/booleans/boolean3", TestHelpers.ToString);
            string attr12 = root.GetElementValueAsBoolean("element/booleans/boolean4", TestHelpers.ToString);
            string attr13 = root.GetElementValueAsBoolean("element/booleans/boolean5", TestHelpers.ToString);
            string attr14 = root.GetElementValueAsBoolean("element/booleans/boolean6", TestHelpers.ToString);
            string attr15 = root.GetElementValueAsBoolean("element/booleans/boolean7", TestHelpers.ToString);
            string attr16 = root.GetElementValueAsBoolean("element/booleans/boolean8", TestHelpers.ToString);

            Assert.AreEqual(true, attr01, "#1");
            Assert.AreEqual(false, attr02, "#2");
            Assert.AreEqual(true, attr03, "#3");
            Assert.AreEqual(false, attr04, "#4");
            Assert.AreEqual(true, attr05, "#5");
            Assert.AreEqual(false, attr06, "#6");
            Assert.AreEqual(true, attr07, "#7");
            Assert.AreEqual(false, attr08, "#8");

            Assert.AreEqual("True", attr09, "#9");
            Assert.AreEqual("False", attr10, "#10");
            Assert.AreEqual("True", attr11, "#11");
            Assert.AreEqual("False", attr12, "#12");
            Assert.AreEqual("True", attr13, "#13");
            Assert.AreEqual("False", attr14, "#14");
            Assert.AreEqual("True", attr15, "#15");
            Assert.AreEqual("False", attr16, "#16");

        }

        [TestMethod]
        public void AsBoolean3() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            bool attr01 = root.GetElementValueAsBoolean("test:element/test:booleans/test:boolean1", namespaces);
            bool attr02 = root.GetElementValueAsBoolean("test:element/test:booleans/test:boolean2", namespaces);
            bool attr03 = root.GetElementValueAsBoolean("test:element/test:booleans/test:boolean3", namespaces);
            bool attr04 = root.GetElementValueAsBoolean("test:element/test:booleans/test:boolean4", namespaces);
            bool attr05 = root.GetElementValueAsBoolean("test:element/test:booleans/test:boolean1", namespaces);
            bool attr06 = root.GetElementValueAsBoolean("test:element/test:booleans/test:boolean2", namespaces);
            bool attr07 = root.GetElementValueAsBoolean("test:element/test:booleans/test:boolean3", namespaces);
            bool attr08 = root.GetElementValueAsBoolean("test:element/test:booleans/test:boolean4", namespaces);

            string attr09 = root.GetElementValueAsBoolean("test:element/test:booleans/test:boolean1", namespaces, TestHelpers.ToString);
            string attr10 = root.GetElementValueAsBoolean("test:element/test:booleans/test:boolean2", namespaces, TestHelpers.ToString);
            string attr11 = root.GetElementValueAsBoolean("test:element/test:booleans/test:boolean3", namespaces, TestHelpers.ToString);
            string attr12 = root.GetElementValueAsBoolean("test:element/test:booleans/test:boolean4", namespaces, TestHelpers.ToString);
            string attr13 = root.GetElementValueAsBoolean("test:element/test:booleans/test:boolean1", namespaces, TestHelpers.ToString);
            string attr14 = root.GetElementValueAsBoolean("test:element/test:booleans/test:boolean2", namespaces, TestHelpers.ToString);
            string attr15 = root.GetElementValueAsBoolean("test:element/test:booleans/test:boolean3", namespaces, TestHelpers.ToString);
            string attr16 = root.GetElementValueAsBoolean("test:element/test:booleans/test:boolean4", namespaces, TestHelpers.ToString);

            Assert.AreEqual(true, attr01, "#1");
            Assert.AreEqual(false, attr02, "#2");
            Assert.AreEqual(true, attr03, "#3");
            Assert.AreEqual(false, attr04, "#4");
            Assert.AreEqual(true, attr05, "#5");
            Assert.AreEqual(false, attr06, "#6");
            Assert.AreEqual(true, attr07, "#7");
            Assert.AreEqual(false, attr08, "#8");

            Assert.AreEqual("True", attr09, "#9");
            Assert.AreEqual("False", attr10, "#10");
            Assert.AreEqual("True", attr11, "#11");
            Assert.AreEqual("False", attr12, "#12");
            Assert.AreEqual("True", attr13, "#13");
            Assert.AreEqual("False", attr14, "#14");
            Assert.AreEqual("True", attr15, "#15");
            Assert.AreEqual("False", attr16, "#16");

        }

        [TestMethod]
        public void AsEnum1() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XElement element = root.GetElement("element");
            XElement enums = element.GetElement("enums");

            HttpStatusCode attr1 = enums.GetElementValueAsEnum<HttpStatusCode>((XName) "enum1");
            HttpStatusCode attr2 = enums.GetElementValueAsEnum<HttpStatusCode>((XName) "enum2");
            HttpStatusCode attr3 = enums.GetElementValueAsEnum<HttpStatusCode>((XName) "enum3");
            HttpStatusCode attr4 = enums.GetElementValueAsEnum<HttpStatusCode>((XName) "enum4");

            HttpStatusCode attr5 = enums.GetElementValueAsEnum((XName) "enum1", HttpStatusCode.NoContent);
            HttpStatusCode attr6 = enums.GetElementValueAsEnum((XName) "enum2", HttpStatusCode.NoContent);
            HttpStatusCode attr7 = enums.GetElementValueAsEnum((XName) "enum3", HttpStatusCode.NoContent);
            HttpStatusCode attr8 = enums.GetElementValueAsEnum((XName) "enum4", HttpStatusCode.NoContent);
            HttpStatusCode attr9 = enums.GetElementValueAsEnum((XName) "enum5", HttpStatusCode.NoContent);
            HttpStatusCode attr10 = enums.GetElementValueAsEnum((XName) "enum6", HttpStatusCode.NoContent);

            Assert.AreEqual(HttpStatusCode.OK, attr1, "#1");
            Assert.AreEqual(HttpStatusCode.NotFound, attr2, "#2");
            Assert.AreEqual(HttpStatusCode.NotFound, attr3, "#3");
            Assert.AreEqual(HttpStatusCode.NotFound, attr4, "#4");

            Assert.AreEqual(HttpStatusCode.OK, attr5, "#5");
            Assert.AreEqual(HttpStatusCode.NotFound, attr6, "#6");
            Assert.AreEqual(HttpStatusCode.NotFound, attr7, "#7");
            Assert.AreEqual(HttpStatusCode.NotFound, attr8, "#8");
            Assert.AreEqual(HttpStatusCode.NoContent, attr9, "#9");
            Assert.AreEqual(HttpStatusCode.NoContent, attr10, "#10");

        }

        [TestMethod]
        public void AsEnum2() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            HttpStatusCode attr1 = root.GetElementValueAsEnum<HttpStatusCode>("element/enums/enum1");
            HttpStatusCode attr2 = root.GetElementValueAsEnum<HttpStatusCode>("element/enums/enum2");
            HttpStatusCode attr3 = root.GetElementValueAsEnum<HttpStatusCode>("element/enums/enum3");
            HttpStatusCode attr4 = root.GetElementValueAsEnum<HttpStatusCode>("element/enums/enum4");

            HttpStatusCode attr5 = root.GetElementValueAsEnum("element/enums/enum1", HttpStatusCode.NoContent);
            HttpStatusCode attr6 = root.GetElementValueAsEnum("element/enums/enum2", HttpStatusCode.NoContent);
            HttpStatusCode attr7 = root.GetElementValueAsEnum("element/enums/enum3", HttpStatusCode.NoContent);
            HttpStatusCode attr8 = root.GetElementValueAsEnum("element/enums/enum4", HttpStatusCode.NoContent);
            HttpStatusCode attr9 = root.GetElementValueAsEnum("element/enums/enum5", HttpStatusCode.NoContent);

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
        public void AsEnum3() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            HttpStatusCode attr1 = root.GetElementValueAsEnum<HttpStatusCode>("test:element/test:enums/test:enum1", namespaces);
            HttpStatusCode attr2 = root.GetElementValueAsEnum<HttpStatusCode>("test:element/test:enums/test:enum2", namespaces);
            HttpStatusCode attr3 = root.GetElementValueAsEnum<HttpStatusCode>("test:element/test:enums/test:enum3", namespaces);
            HttpStatusCode attr4 = root.GetElementValueAsEnum<HttpStatusCode>("test:element/test:enums/test:enum4", namespaces);

            HttpStatusCode attr5 = root.GetElementValueAsEnum("test:element/test:enums/test:enum1", namespaces, HttpStatusCode.NoContent);
            HttpStatusCode attr6 = root.GetElementValueAsEnum("test:element/test:enums/test:enum2", namespaces, HttpStatusCode.NoContent);
            HttpStatusCode attr7 = root.GetElementValueAsEnum("test:element/test:enums/test:enum3", namespaces, HttpStatusCode.NoContent);
            HttpStatusCode attr8 = root.GetElementValueAsEnum("test:element/test:enums/test:enum4", namespaces, HttpStatusCode.NoContent);
            HttpStatusCode attr9 = root.GetElementValueAsEnum("test:element/test:enums/test:enum5", namespaces, HttpStatusCode.NoContent);

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