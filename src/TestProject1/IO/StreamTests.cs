using System.Text;
using Skybrud.Essentials.IO;

namespace TestProject1.IO;

[TestClass]
public class StreamTests {

    [TestMethod]
    public void ToStream() {

        const string value = "Rød grød med fløde";

        using Stream stream = StreamUtils.ToStream(value);

        string result = StreamUtils.ToString(stream);

        Assert.AreEqual(value, result);

    }

    [TestMethod]
    public void ToStreamUtf8() {

        const string value = "Rød grød med fløde";

        using Stream stream = StreamUtils.ToStream(value, Encoding.UTF8);

        string result = StreamUtils.ToString(stream);

        Assert.AreEqual(value, result);

    }


    [TestMethod]
    public void ToStreamAscii() {

        const string value = "Rød grød med fløde";

        using Stream stream = StreamUtils.ToStream(value, Encoding.ASCII);

        string result = StreamUtils.ToString(stream, Encoding.ASCII);

        // The two strings will not be equal as ASCII doesn't support special characters like 'ø'
        Assert.AreNotEqual(value, result);

    }


    [TestMethod]
    public void ToStreamWindows1252() {

        Encoding windows1252 = CodePagesEncodingProvider.Instance.GetEncoding(1252)!;

        const string value = "Rød grød med fløde";

        using Stream stream = StreamUtils.ToStream(value, windows1252);

        string result = StreamUtils.ToString(stream, windows1252);

        Assert.AreEqual(value, result);

    }

}