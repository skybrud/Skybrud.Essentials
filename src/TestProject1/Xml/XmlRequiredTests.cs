using System.Xml.Linq;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Xml.Exceptions;
using Skybrud.Essentials.Xml.Extensions;

namespace TestProject1.Xml;

[TestClass]
public class XmlRequiredTests {

    #region Boolean

    [TestMethod]
    public void GetBooleanValue() {

        XElement meh = new("meh", new XAttribute("off", "off"), new XAttribute("on", "on"));
        XElement hej = new("hej", new XElement("zero", 0), new XElement("one", "1"), meh);
        XElement root = new("root", hej, new XAttribute("false", "false"), new XAttribute("true", "true"));

        Assert.IsFalse(root.GetBooleanValue("@false"), "#1");
        Assert.IsTrue(root.GetBooleanValue("@true"), "#2");
        Assert.IsFalse(root.GetBooleanValue("hej/meh/@off"), "#3");
        Assert.IsTrue(root.GetBooleanValue("hej/meh/@on"), "#4");
        Assert.IsFalse(root.GetBooleanValue("hej/zero"), "#5");
        Assert.IsTrue(root.GetBooleanValue("hej/one"), "#6");
        Assert.IsFalse(root.GetBooleanValue("hej/null"), "#7");
        Assert.IsFalse(root.GetBooleanValue("hej/@null"), "#8");

    }

    [TestMethod]
    public void GetBooleanValueFallback() {

        XElement meh = new("meh", new XAttribute("off", "off"), new XAttribute("on", "on"));
        XElement hej = new("hej", new XElement("zero", 0), new XElement("one", "1"), meh);
        XElement root = new("root", hej, new XAttribute("false", "false"), new XAttribute("true", "true"));

        Assert.IsFalse(root.GetBooleanValue("hej/null", false), "#1");
        Assert.IsTrue(root.GetBooleanValue("hej/null", true), "#2");

        Assert.IsFalse(root.GetBooleanValue("hej/@null", false), "#2");
        Assert.IsTrue(root.GetBooleanValue("hej/@null", true), "#2");

    }

    [TestMethod]
    public void GetBooleanValueCallback() {

        XElement meh = new("meh", new XAttribute("off", "off"), new XAttribute("on", "on"));
        XElement hej = new("hej", new XElement("zero", 0), new XElement("one", "1"), meh);
        XElement root = new("root", hej, new XAttribute("false", "false"), new XAttribute("true", "true"));

        Assert.AreEqual("False", root.GetBooleanValue("@false", x => x.ToString()), "#1");
        Assert.AreEqual("True", root.GetBooleanValue("@true", x => x.ToString()), "#2");
        Assert.AreEqual("False", root.GetBooleanValue("hej/meh/@off", x => x.ToString()), "#3");
        Assert.AreEqual("True", root.GetBooleanValue("hej/meh/@on", x => x.ToString()), "#4");
        Assert.AreEqual("False", root.GetBooleanValue("hej/zero", x => x.ToString()), "#5");
        Assert.AreEqual("True", root.GetBooleanValue("hej/one", x => x.ToString()), "#6");
        Assert.IsNull(root.GetBooleanValue("hej/null", x => x.ToString()), "#7");
        Assert.IsNull(root.GetBooleanValue("hej/@null", x => x.ToString()), "#8");

    }

    [TestMethod]
    public void GetBooleanValueNull() {

        XElement meh = new("meh", new XAttribute("off", "off"), new XAttribute("on", "on"));
        XElement hej = new("hej", new XElement("zero", 0), new XElement("one", "1"), meh);
        XElement root = new("root", hej, new XAttribute("false", "false"), new XAttribute("true", "true"));

        Assert.IsFalse(root.GetBooleanValueOrNull("@false"), "#1");
        Assert.IsTrue(root.GetBooleanValueOrNull("@true"), "#2");
        Assert.IsFalse(root.GetBooleanValueOrNull("hej/meh/@off"), "#3");
        Assert.IsTrue(root.GetBooleanValueOrNull("hej/meh/@on"), "#4");
        Assert.IsFalse(root.GetBooleanValueOrNull("hej/zero"), "#5");
        Assert.IsTrue(root.GetBooleanValueOrNull("hej/one"), "#6");
        Assert.IsNull(root.GetBooleanValueOrNull("hej/null"), "#7");
        Assert.IsNull(root.GetBooleanValueOrNull("hej/@null"), "#8");

    }

    //[TestMethod]
    //public void GetRequiredDoubleValue() {

    //    XElement meh = new("meh", new XAttribute("id", "1234"));
    //    XElement hej = new("hej", new XAttribute("id", 123), new XElement("count", "12345"), new XElement("length", 12345), meh);
    //    XElement root = new("root", hej);

    //    Assert.AreEqual(123, root.GetRequiredDoubleValue("hej/@id"));
    //    Assert.AreEqual(1234, root.GetRequiredDoubleValue("hej/meh/@id"));
    //    Assert.AreEqual(12345, root.GetRequiredDoubleValue("hej/count"));
    //    Assert.AreEqual(12345, root.GetRequiredDoubleValue("hej/length"));
    //    Assert.ThrowsException<XmlXPathException>(() => root.GetRequiredDoubleValue("hej/null"));
    //    Assert.ThrowsException<XmlXPathException>(() => root.GetRequiredDoubleValue("hej/@null"));

    //}

    //[TestMethod]
    //public void GetRequiredDoubleValueCallback() {

    //    XElement meh = new("meh", new XAttribute("id", "1234"));
    //    XElement hej = new("hej", new XAttribute("id", 123), new XElement("count", "12345"), new XElement("length", 12345), meh);
    //    XElement root = new("root", hej);

    //    Assert.AreEqual(10123, root.GetRequiredDoubleValue("hej/@id", x => x + 10000));
    //    Assert.AreEqual(11234, root.GetRequiredDoubleValue("hej/meh/@id", x => x + 10000));
    //    Assert.AreEqual(22345, root.GetRequiredDoubleValue("hej/count", x => x + 10000));
    //    Assert.AreEqual(22345, root.GetRequiredDoubleValue("hej/length", x => x + 10000));
    //    Assert.ThrowsException<XmlXPathException>(() => root.GetRequiredDoubleValue("hej/null", x => x + 10000));
    //    Assert.ThrowsException<XmlXPathException>(() => root.GetRequiredDoubleValue("hej/@null", x => x + 10000));

    //    Assert.AreEqual("_123", root.GetRequiredDoubleValue("hej/@id", x => $"_{x}"));
    //    Assert.AreEqual("_1234", root.GetRequiredDoubleValue("hej/meh/@id", x => $"_{x}"));
    //    Assert.AreEqual("_12345", root.GetRequiredDoubleValue("hej/count", x => $"_{x}"));
    //    Assert.AreEqual("_12345", root.GetRequiredDoubleValue("hej/length", x => $"_{x}"));
    //    Assert.ThrowsException<XmlXPathException>(() => root.GetRequiredDoubleValue("hej/null", x => $"_{x}"));
    //    Assert.ThrowsException<XmlXPathException>(() => root.GetRequiredDoubleValue("hej/@null", x => $"_{x}"));

    //}

    #endregion

    #region Int16

    [TestMethod]
    public void GetDoubleValue() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("count", "12345"), new XElement("length", 12345), meh);
        XElement root = new("root", hej);

        Assert.AreEqual(123, root.GetDoubleValue("hej/@id"));
        Assert.AreEqual(1234, root.GetDoubleValue("hej/meh/@id"));
        Assert.AreEqual(12345, root.GetDoubleValue("hej/count"));
        Assert.AreEqual(12345, root.GetDoubleValue("hej/length"));
        Assert.AreEqual(0, root.GetDoubleValue("hej/null"));
        Assert.AreEqual(0, root.GetDoubleValue("hej/@null"));

    }

    [TestMethod]
    public void GetDoubleValueNull() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("count", "12345"), new XElement("length", 12345), meh);
        XElement root = new("root", hej);

        Assert.AreEqual(123d, root.GetDoubleValueOrNull("hej/@id"));
        Assert.AreEqual(1234d, root.GetDoubleValueOrNull("hej/meh/@id"));
        Assert.AreEqual(12345d, root.GetDoubleValueOrNull("hej/count"));
        Assert.AreEqual(12345d, root.GetDoubleValueOrNull("hej/length"));
        Assert.IsNull(root.GetDoubleValueOrNull("hej/null"));
        Assert.IsNull(root.GetDoubleValueOrNull("hej/@null"));

    }

    [TestMethod]
    public void GetDoubleValueCallback() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("count", "12345"), new XElement("length", 12345), meh);
        XElement root = new("root", hej);

        Assert.AreEqual(10123, root.GetDoubleValue("hej/@id", x => x + 10000));
        Assert.AreEqual(11234, root.GetDoubleValue("hej/meh/@id", x => x + 10000));
        Assert.AreEqual(22345, root.GetDoubleValue("hej/count", x => x + 10000));
        Assert.AreEqual(22345, root.GetDoubleValue("hej/length", x => x + 10000));
        Assert.AreEqual(0, root.GetDoubleValue("hej/null", x => x + 10000));

        Assert.AreEqual("_123", root.GetDoubleValue("hej/@id", x => $"_{x}"));
        Assert.AreEqual("_1234", root.GetDoubleValue("hej/meh/@id", x => $"_{x}"));
        Assert.AreEqual("_12345", root.GetDoubleValue("hej/count", x => $"_{x}"));
        Assert.AreEqual("_12345", root.GetDoubleValue("hej/length", x => $"_{x}"));
        Assert.IsNull(root.GetDoubleValue("hej/null", x => $"_{x}"));
        Assert.IsNull(root.GetDoubleValue("hej/@null", x => $"_{x}"));

    }

    [TestMethod]
    public void GetRequiredDoubleValue() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("count", "12345"), new XElement("length", 12345), meh);
        XElement root = new("root", hej);

        Assert.AreEqual(123, root.GetRequiredDoubleValue("hej/@id"));
        Assert.AreEqual(1234, root.GetRequiredDoubleValue("hej/meh/@id"));
        Assert.AreEqual(12345, root.GetRequiredDoubleValue("hej/count"));
        Assert.AreEqual(12345, root.GetRequiredDoubleValue("hej/length"));
        Assert.ThrowsException<XmlXPathException>(() => root.GetRequiredDoubleValue("hej/null"));
        Assert.ThrowsException<XmlXPathException>(() => root.GetRequiredDoubleValue("hej/@null"));

    }

    [TestMethod]
    public void GetRequiredDoubleValueCallback() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("count", "12345"), new XElement("length", 12345), meh);
        XElement root = new("root", hej);

        Assert.AreEqual(10123, root.GetRequiredDoubleValue("hej/@id", x => x + 10000));
        Assert.AreEqual(11234, root.GetRequiredDoubleValue("hej/meh/@id", x => x + 10000));
        Assert.AreEqual(22345, root.GetRequiredDoubleValue("hej/count", x => x + 10000));
        Assert.AreEqual(22345, root.GetRequiredDoubleValue("hej/length", x => x + 10000));
        Assert.ThrowsException<XmlXPathException>(() => root.GetRequiredDoubleValue("hej/null", x => x + 10000));
        Assert.ThrowsException<XmlXPathException>(() => root.GetRequiredDoubleValue("hej/@null", x => x + 10000));

        Assert.AreEqual("_123", root.GetRequiredDoubleValue("hej/@id", x => $"_{x}"));
        Assert.AreEqual("_1234", root.GetRequiredDoubleValue("hej/meh/@id", x => $"_{x}"));
        Assert.AreEqual("_12345", root.GetRequiredDoubleValue("hej/count", x => $"_{x}"));
        Assert.AreEqual("_12345", root.GetRequiredDoubleValue("hej/length", x => $"_{x}"));
        Assert.ThrowsException<XmlXPathException>(() => root.GetRequiredDoubleValue("hej/null", x => $"_{x}"));
        Assert.ThrowsException<XmlXPathException>(() => root.GetRequiredDoubleValue("hej/@null", x => $"_{x}"));

    }

    #endregion












    #region Int16

    [TestMethod]
    public void GetInt16Value() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("count", "12345"), new XElement("length", 12345), meh);
        XElement root = new("root", hej);

        Assert.AreEqual(123, root.GetInt16Value("hej/@id"));
        Assert.AreEqual(1234, root.GetInt16Value("hej/meh/@id"));
        Assert.AreEqual(12345, root.GetInt16Value("hej/count"));
        Assert.AreEqual(12345, root.GetInt16Value("hej/length"));
        Assert.AreEqual(0, root.GetInt16Value("hej/null"));
        Assert.AreEqual(0, root.GetInt16Value("hej/@null"));

    }

    [TestMethod]
    public void GetInt16ValueNull() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("count", "12345"), new XElement("length", 12345), meh);
        XElement root = new("root", hej);

        Assert.AreEqual((short) 123, root.GetInt16ValueOrNull("hej/@id"));
        Assert.AreEqual((short) 1234, root.GetInt16ValueOrNull("hej/meh/@id"));
        Assert.AreEqual((short) 12345, root.GetInt16ValueOrNull("hej/count"));
        Assert.AreEqual((short) 12345, root.GetInt16ValueOrNull("hej/length"));
        Assert.IsNull(root.GetInt16ValueOrNull("hej/null"));
        Assert.IsNull(root.GetInt16ValueOrNull("hej/@null"));

    }

    [TestMethod]
    public void GetInt16ValueCallback() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("count", "12345"), new XElement("length", 12345), meh);
        XElement root = new("root", hej);

        Assert.AreEqual(10123, root.GetInt16Value("hej/@id", x => x + 10000));
        Assert.AreEqual(11234, root.GetInt16Value("hej/meh/@id", x => x + 10000));
        Assert.AreEqual(22345, root.GetInt16Value("hej/count", x => x + 10000));
        Assert.AreEqual(22345, root.GetInt16Value("hej/length", x => x + 10000));
        Assert.AreEqual(0, root.GetInt16Value("hej/null", x => x + 10000));

        Assert.AreEqual("_123", root.GetInt16Value("hej/@id", x => $"_{x}"));
        Assert.AreEqual("_1234", root.GetInt16Value("hej/meh/@id", x => $"_{x}"));
        Assert.AreEqual("_12345", root.GetInt16Value("hej/count", x => $"_{x}"));
        Assert.AreEqual("_12345", root.GetInt16Value("hej/length", x => $"_{x}"));
        Assert.IsNull(root.GetInt16Value("hej/null", x => $"_{x}"));
        Assert.IsNull(root.GetInt16Value("hej/@null", x => $"_{x}"));

    }

    #endregion

    #region Int32

    [TestMethod]
    public void GetInt32Value() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("count", "12345"), new XElement("length", 12345), meh);
        XElement root = new("root", hej);

        Assert.AreEqual(123, root.GetInt32Value("hej/@id"));
        Assert.AreEqual(1234, root.GetInt32Value("hej/meh/@id"));
        Assert.AreEqual(12345, root.GetInt32Value("hej/count"));
        Assert.AreEqual(12345, root.GetInt32Value("hej/length"));
        Assert.AreEqual(0, root.GetInt32Value("hej/null"));
        Assert.AreEqual(0, root.GetInt32Value("hej/@null"));

    }

    [TestMethod]
    public void GetInt32ValueNull() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("count", "12345"), new XElement("length", 12345), meh);
        XElement root = new("root", hej);

        Assert.AreEqual(123, root.GetInt32ValueOrNull("hej/@id"));
        Assert.AreEqual(1234, root.GetInt32ValueOrNull("hej/meh/@id"));
        Assert.AreEqual(12345, root.GetInt32ValueOrNull("hej/count"));
        Assert.AreEqual(12345, root.GetInt32ValueOrNull("hej/length"));
        Assert.IsNull(root.GetInt32ValueOrNull("hej/null"));
        Assert.IsNull(root.GetInt32ValueOrNull("hej/@null"));

    }

    [TestMethod]
    public void GetInt32ValueCallback() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("count", "12345"), new XElement("length", 12345), meh);
        XElement root = new("root", hej);

        Assert.AreEqual(10123, root.GetInt32Value("hej/@id", x => x + 10000));
        Assert.AreEqual(11234, root.GetInt32Value("hej/meh/@id", x => x + 10000));
        Assert.AreEqual(22345, root.GetInt32Value("hej/count", x => x + 10000));
        Assert.AreEqual(22345, root.GetInt32Value("hej/length", x => x + 10000));
        Assert.AreEqual(0, root.GetInt32Value("hej/null", x => x + 10000));

        Assert.AreEqual("_123", root.GetInt32Value("hej/@id", x => $"_{x}"));
        Assert.AreEqual("_1234", root.GetInt32Value("hej/meh/@id", x => $"_{x}"));
        Assert.AreEqual("_12345", root.GetInt32Value("hej/count", x => $"_{x}"));
        Assert.AreEqual("_12345", root.GetInt32Value("hej/length", x => $"_{x}"));
        Assert.IsNull(root.GetInt32Value("hej/null", x => $"_{x}"));
        Assert.IsNull(root.GetInt32Value("hej/@null", x => $"_{x}"));

    }

    #endregion

    #region Int64

    [TestMethod]
    public void GetInt64Value() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("count", "12345"), new XElement("length", 12345), meh);
        XElement root = new("root", hej);

        Assert.AreEqual(123, root.GetInt64Value("hej/@id"));
        Assert.AreEqual(1234, root.GetInt64Value("hej/meh/@id"));
        Assert.AreEqual(12345, root.GetInt64Value("hej/count"));
        Assert.AreEqual(12345, root.GetInt64Value("hej/length"));
        Assert.AreEqual(0, root.GetInt64Value("hej/null"));
        Assert.AreEqual(0, root.GetInt64Value("hej/@null"));

    }

    [TestMethod]
    public void GetInt64ValueNull() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("count", "12345"), new XElement("length", 12345), meh);
        XElement root = new("root", hej);

        Assert.AreEqual(123, root.GetInt64ValueOrNull("hej/@id"));
        Assert.AreEqual(1234, root.GetInt64ValueOrNull("hej/meh/@id"));
        Assert.AreEqual(12345, root.GetInt64ValueOrNull("hej/count"));
        Assert.AreEqual(12345, root.GetInt64ValueOrNull("hej/length"));
        Assert.IsNull(root.GetInt64ValueOrNull("hej/null"));
        Assert.IsNull(root.GetInt64ValueOrNull("hej/@null"));

    }

    [TestMethod]
    public void GetInt64ValueCallback() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("count", "12345"), new XElement("length", 12345), meh);
        XElement root = new("root", hej);

        Assert.AreEqual(10123, root.GetInt64Value("hej/@id", x => x + 10000));
        Assert.AreEqual(11234, root.GetInt64Value("hej/meh/@id", x => x + 10000));
        Assert.AreEqual(22345, root.GetInt64Value("hej/count", x => x + 10000));
        Assert.AreEqual(22345, root.GetInt64Value("hej/length", x => x + 10000));
        Assert.AreEqual(0, root.GetInt64Value("hej/null", x => x + 10000));

        Assert.AreEqual("_123", root.GetInt64Value("hej/@id", x => $"_{x}"));
        Assert.AreEqual("_1234", root.GetInt64Value("hej/meh/@id", x => $"_{x}"));
        Assert.AreEqual("_12345", root.GetInt64Value("hej/count", x => $"_{x}"));
        Assert.AreEqual("_12345", root.GetInt64Value("hej/length", x => $"_{x}"));
        Assert.IsNull(root.GetInt64Value("hej/null", x => $"_{x}"));
        Assert.IsNull(root.GetInt64Value("hej/@null", x => $"_{x}"));

    }

    #endregion

    #region String

    [TestMethod]
    public void GetStringValue() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("url", "omgbacon.dk"), meh);
        XElement root = new("root", hej);

        Assert.AreEqual("123", root.GetStringValue("hej/@id"));
        Assert.AreEqual("1234", root.GetStringValue("hej/meh/@id"));
        Assert.AreEqual("omgbacon.dk", root.GetStringValue("hej/url"));
        Assert.IsNull(root.GetStringValue("hej/url/null"));

    }

    [TestMethod]
    public void GetStringValueCallback() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("url", "omgbacon.dk"), meh);
        XElement root = new("root", hej);

        Assert.AreEqual("_123", root.GetStringValue("hej/@id", x => $"_{x}"));
        Assert.AreEqual("_1234", root.GetStringValue("hej/meh/@id", x => $"_{x}"));
        Assert.AreEqual("_omgbacon.dk", root.GetStringValue("hej/url", x => $"_{x}"));
        Assert.IsNull(root.GetStringValue("hej/url/null"));

    }

    [TestMethod]
    public void GetRequiredStringValue() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("url", "omgbacon.dk"), meh);
        XElement root = new("root", hej);

        Assert.AreEqual("123", root.GetRequiredStringValue("hej/@id"));
        Assert.AreEqual("1234", root.GetRequiredStringValue("hej/meh/@id"));
        Assert.AreEqual("omgbacon.dk", root.GetRequiredStringValue("hej/url"));
        Assert.ThrowsException<XmlXPathException>(() => root.GetRequiredStringValue("hej/url/null"));

    }

    [TestMethod]
    public void GetRequiredStringValueCallback() {

        XElement meh = new("meh", new XAttribute("id", "1234"));
        XElement hej = new("hej", new XAttribute("id", 123), new XElement("url", "omgbacon.dk"), meh);
        XElement root = new("root", hej);

        Assert.AreEqual("_123", root.GetRequiredStringValue("hej/@id", x => $"_{x}"));
        Assert.AreEqual("_1234", root.GetRequiredStringValue("hej/meh/@id", x => $"_{x}"));
        Assert.AreEqual("_omgbacon.dk", root.GetRequiredStringValue("hej/url", x => $"_{x}"));
        Assert.ThrowsException<XmlXPathException>(() => root.GetRequiredStringValue("hej/url/null", x => $"_{x}"));

    }

    #endregion

}