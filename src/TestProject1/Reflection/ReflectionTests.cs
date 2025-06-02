using Skybrud.Essentials.Reflection;
using Skybrud.Essentials.Reflection.Extensions;

namespace TestProject1.Reflection;

[TestClass]
public class ReflectionTests {

    [TestMethod]
    public void Implements() {

        bool result1 = typeof(List<string>).Implements<IList<string>>();
        bool result2 = typeof(List<string>).Implements<IList<int>>();

        bool result3 = typeof(List<string>).Implements(typeof(IList<string>));
        bool result4 = typeof(List<string>).Implements(typeof(IList<int>));

        bool result5 = ReflectionUtils.Implements(typeof(List<string>), typeof(IList<string>));
        bool result6 = ReflectionUtils.Implements(typeof(List<string>), typeof(IList<int>));

        bool result7 = ReflectionUtils.Implements<List<string>, IList<string>>();
        bool result8 = ReflectionUtils.Implements<List<string>, IList<int>>();

        Assert.IsTrue(result1);
        Assert.IsFalse(result2);
        Assert.IsTrue(result3);
        Assert.IsFalse(result4);
        Assert.IsTrue(result5);
        Assert.IsFalse(result6);
        Assert.IsTrue(result7);
        Assert.IsFalse(result8);

    }

    [TestMethod]
    public void Extends() {

        bool result1 = typeof(StringList).Extends<List<string>>();
        bool result2 = typeof(StringList).Extends<List<int>>();

        bool result3 = typeof(StringList).Extends(typeof(List<string>));
        bool result4 = typeof(StringList).Extends(typeof(List<int>));

        bool result5 = ReflectionUtils.Extends(typeof(StringList), typeof(List<string>));
        bool result6 = ReflectionUtils.Extends(typeof(StringList), typeof(List<int>));

        bool result7 = ReflectionUtils.Extends<StringList, List<string>>();
        bool result8 = ReflectionUtils.Extends<StringList, List<int>>();

        Assert.IsTrue(result1);
        Assert.IsFalse(result2);
        Assert.IsTrue(result3);
        Assert.IsFalse(result4);
        Assert.IsTrue(result5);
        Assert.IsFalse(result6);
        Assert.IsTrue(result7);
        Assert.IsFalse(result8);


    }

    public class StringList : List<string>;

}
