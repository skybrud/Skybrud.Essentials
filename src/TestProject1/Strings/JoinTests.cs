using Skybrud.Essentials.Strings.Extensions;

namespace TestProject1.Strings;

[TestClass]
public class JoinTests {

    [TestMethod]
    public void JoinT() {

        string[] array = { "hello", "world" };

        Assert.AreEqual("hello,world", array.Join(','));
        Assert.AreEqual("hello,world", array.Join(","));

        Assert.AreEqual("hello,world", array.Join(','));
        Assert.AreEqual("hello,world", array.Join(","));

    }

    [TestMethod]
    public void JoinObject() {

        object[] array = { "hello", "world" };

        Assert.AreEqual("hello,world", array.Join(','));
        Assert.AreEqual("hello,world", array.Join(","));

        Assert.AreEqual("hello,world", array.Join(','));
        Assert.AreEqual("hello,world", array.Join(","));

    }

}