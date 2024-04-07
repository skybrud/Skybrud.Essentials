using Skybrud.Essentials.Collections;

namespace TestProject1.Collections;

[TestClass]
public class ReadOnlySetTests {

    [TestMethod]
    public void Empty() {

        var a = ReadOnlySet.Empty<string>();
        var b = ReadOnlySet.Empty<string>();

        Assert.AreEqual(a, b);

        Assert.AreEqual(a.GetHashCode(), b.GetHashCode());

    }

}