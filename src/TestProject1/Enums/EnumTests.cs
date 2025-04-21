using System.Net;
using Skybrud.Essentials.Enums;

namespace TestProject1.Enums;

[TestClass]
public class EnumTests {

    [TestMethod]
    public void Parse() {

        Assert.ThrowsException<ArgumentNullException>(() => {
            EnumUtils.ParseEnum(null!, typeof(HttpStatusCode));
        }, "#1");

        Assert.ThrowsException<ArgumentException>(() => {
            EnumUtils.ParseEnum("", typeof(HttpStatusCode));
        }, "#2");

        Assert.AreEqual(HttpStatusCode.OK, EnumUtils.ParseEnum("ok", typeof(HttpStatusCode)), "#3");

    }

    [TestMethod]
    public void TryParseString() {

        bool success1 = EnumUtils.TryParseEnum("ok", typeof(HttpStatusCode), out Enum? result1);
        bool success2 = EnumUtils.TryParseEnum("hello", typeof(HttpStatusCode), out Enum? result2);
        bool success3 = EnumUtils.TryParseEnum("", typeof(HttpStatusCode), out Enum? result3);
        bool success4 = EnumUtils.TryParseEnum(null, typeof(HttpStatusCode), out Enum? result4);
        bool success5 = EnumUtils.TryParseEnum("ok", typeof(string), out Enum? result5);

        Assert.IsTrue(success1, "#1a");
        Assert.AreEqual(HttpStatusCode.OK, result1, "#1b");

        Assert.IsFalse(success2, "#2a");
        Assert.IsNull(result2, "#2b");

        Assert.IsFalse(success3, "#3a");
        Assert.IsNull(result3, "#3b");

        Assert.IsFalse(success4, "#4a");
        Assert.IsNull(result4, "#4b");

        Assert.IsFalse(success5, "#5a");
        Assert.IsNull(result5, "#5b");

    }

    [TestMethod]
    public void TryParseStringToT() {

        bool success1 = EnumUtils.TryParseEnum("ok", out HttpStatusCode result1);
        bool success2 = EnumUtils.TryParseEnum("not_found", out HttpStatusCode result2);
        bool success3 = EnumUtils.TryParseEnum("not-found", out HttpStatusCode result3);
        bool success4 = EnumUtils.TryParseEnum("not found", out HttpStatusCode result4);
        bool success5 = EnumUtils.TryParseEnum("404", out HttpStatusCode result5);
        bool success6 = EnumUtils.TryParseEnum(404, out HttpStatusCode result6);
        bool success7 = EnumUtils.TryParseEnum("hello", out HttpStatusCode result7);
        bool success8 = EnumUtils.TryParseEnum("", out HttpStatusCode result8);
        bool success9 = EnumUtils.TryParseEnum(default(string), out HttpStatusCode result9);

        Assert.IsTrue(success1, "#1a");
        Assert.AreEqual(HttpStatusCode.OK, result1, "#1b");

        Assert.IsTrue(success2, "#2a");
        Assert.AreEqual(HttpStatusCode.NotFound, result2, "#2b");

        Assert.IsTrue(success3, "#3a");
        Assert.AreEqual(HttpStatusCode.NotFound, result3, "#3b");

        Assert.IsTrue(success4, "#4a");
        Assert.AreEqual(HttpStatusCode.NotFound, result4, "#4b");

        Assert.IsTrue(success5, "#5a");
        Assert.AreEqual(HttpStatusCode.NotFound, result5, "#5b");

        Assert.IsTrue(success6, "#6a");
        Assert.AreEqual(HttpStatusCode.NotFound, result6, "#6b");

        Assert.IsFalse(success7, "#7a");
        Assert.AreEqual(default, result7, "#7b");

        Assert.IsFalse(success8, "#8a");
        Assert.AreEqual(default, result8, "#8b");

        Assert.IsFalse(success9, "#9a");
        Assert.AreEqual(default, result9, "#9b");

    }

    [TestMethod]
    public void TryParseStringToTNullable() {

        bool success1 = EnumUtils.TryParseEnum("ok", out HttpStatusCode? result1);
        bool success2 = EnumUtils.TryParseEnum("not_found", out HttpStatusCode? result2);
        bool success3 = EnumUtils.TryParseEnum("not-found", out HttpStatusCode? result3);
        bool success4 = EnumUtils.TryParseEnum("not found", out HttpStatusCode? result4);
        bool success5 = EnumUtils.TryParseEnum("404", out HttpStatusCode? result5);
        bool success6 = EnumUtils.TryParseEnum(404, out HttpStatusCode? result6);
        bool success7 = EnumUtils.TryParseEnum("hello", out HttpStatusCode? result7);
        bool success8 = EnumUtils.TryParseEnum("", out HttpStatusCode? result8);
        bool success9 = EnumUtils.TryParseEnum(null, typeof(HttpStatusCode), out Enum? result9);

        Assert.IsTrue(success1, "#1a");
        Assert.AreEqual(HttpStatusCode.OK, result1, "#1b");

        Assert.IsTrue(success2, "#2a");
        Assert.AreEqual(HttpStatusCode.NotFound, result2, "#2b");

        Assert.IsTrue(success3, "#3a");
        Assert.AreEqual(HttpStatusCode.NotFound, result3, "#3b");

        Assert.IsTrue(success4, "#4a");
        Assert.AreEqual(HttpStatusCode.NotFound, result4, "#4b");

        Assert.IsTrue(success5, "#5a");
        Assert.AreEqual(HttpStatusCode.NotFound, result5, "#5b");

        Assert.IsTrue(success6, "#6a");
        Assert.AreEqual(HttpStatusCode.NotFound, result6, "#6b");

        Assert.IsFalse(success7, "#7a");
        Assert.IsNull(result7, "#7b");

        Assert.IsFalse(success8, "#8a");
        Assert.IsNull(result8, "#8b");

        Assert.IsFalse(success9, "#9a");
        Assert.IsNull(result9, "#9b");

    }

}