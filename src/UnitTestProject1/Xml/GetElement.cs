using System.Xml;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Xml.Extensions;

namespace UnitTestProject1.Xml {
    
    [TestClass]
    public class GetElement {

        [TestMethod]
        public void Test1() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XElement result1 = root.GetElement((XName)"element");
            Class1 result2 = root.GetElement((XName)"element", Class1.Parse);

            Assert.IsNotNull(result1);
            Assert.AreEqual("world", result1.GetElement("hello").Value);

            Assert.IsNotNull(result2);
            Assert.AreEqual("world", result2.Hello);

        }

        [TestMethod]
        public void Test2() {

            XElement root = XElement.Load(TestHelpers.MapPath("~/Xml/Hest.xml"));

            XmlNamespaceManager namespaces = new XmlNamespaceManager(new NameTable());
            namespaces.AddNamespace("test", "http://social.skybrud.dk/schemas/test");

            XElement result1 = root.GetElement("element");
            Class1 result2 = root.GetElement("element", Class1.Parse);
            
            XElement result3 = root.GetElement("test:element", namespaces);
            Class2 result4 = root.GetElement("test:element", namespaces, Class2.Parse);

            Assert.IsNotNull(result1);
            Assert.AreEqual("world", result1.GetElement("hello").Value);

            Assert.IsNotNull(result2);
            Assert.AreEqual("world", result2.Hello);

            Assert.IsNotNull(result3);
            Assert.AreEqual("world", result3.GetElement("test:hello", namespaces).Value);

            Assert.IsNotNull(result4);
            Assert.AreEqual("world", result4.Hello);

        }

        public class Class1 {
            public string Hello { get; set; }
            public Class1(XElement xml) {
                Hello = xml.GetElement("hello").Value;
            }
            public static Class1 Parse(XElement xml) {
                return xml == null ? null : new Class1(xml);
            }
        }

        public class Class2 {
            public string Hello { get; set; }
            public Class2(XElement xml, IXmlNamespaceResolver resolver) {
                Hello = xml.GetElement("test:hello", resolver).Value;
            }
            public static Class2 Parse(XElement xml, IXmlNamespaceResolver resolver) {
                return xml == null ? null : new Class2(xml, resolver);
            }
        }
    
    }

}