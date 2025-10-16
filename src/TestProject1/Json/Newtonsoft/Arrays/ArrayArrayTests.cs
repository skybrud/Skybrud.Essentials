using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace TestProject1.Json.Newtonsoft.Arrays;

[TestClass]
public class ArrayArrayTests {

    [TestMethod]
    public void GetObject() {

        JArray array = new("", "Hello there!", 1, 123.456, null, new JArray(), new JObject(), true, false, long.MaxValue, "9223372036854775808");

        Assert.IsNull(array.GetObject(0), "Index 0");
        Assert.IsNull(array.GetObject(1), "Index 1");
        Assert.IsNull(array.GetObject(2), "Index 2");
        Assert.IsNull(array.GetObject(3), "Index 3");
        Assert.IsNull(array.GetObject(4), "Index 4");
        Assert.IsNull(array.GetObject(5), "Index 5");
        Assert.IsNotNull(array.GetObject(6), "Index 6");
        Assert.IsNull(array.GetObject(7), "Index 7");
        Assert.IsNull(array.GetObject(8), "Index 8");
        Assert.IsNull(array.GetObject(9), "Index 9");
        Assert.IsNull(array.GetObject(10), "Index 10");
        Assert.IsNull(array.GetObject(11), "Index 11");

    }

    [TestMethod]
    public void GetObjectByPath() {

        JArray array = new("", "Hello there!", 1, 123.456, null, new JArray(), new JObject(), true, false, long.MaxValue, "9223372036854775808");

        Assert.IsNull(array.GetObjectByPath("[0]"), "Index 0");
        Assert.IsNull(array.GetObjectByPath("[1]"), "Index 1");
        Assert.IsNull(array.GetObjectByPath("[2]"), "Index 2");
        Assert.IsNull(array.GetObjectByPath("[3]"), "Index 3");
        Assert.IsNull(array.GetObjectByPath("[4]"), "Index 4");
        Assert.IsNull(array.GetObjectByPath("[5]"), "Index 5");
        Assert.IsNotNull(array.GetObjectByPath("[6]"), "Index 6");
        Assert.IsNull(array.GetObjectByPath("[7]"), "Index 7");
        Assert.IsNull(array.GetObjectByPath("[8]"), "Index 8");
        Assert.IsNull(array.GetObjectByPath("[9]"), "Index 9");
        Assert.IsNull(array.GetObjectByPath("[10]"), "Index 10");
        Assert.IsNull(array.GetObjectByPath("[11]"), "Index 11");

    }

    [TestMethod]
    public void GetArray() {

        JArray array = new("", "Hello there!", 1, 123.456, null, new JArray(), new JObject(), true, false, long.MaxValue, "9223372036854775808");

        Assert.IsNull(array.GetArray(0), "Index 0");
        Assert.IsNull(array.GetArray(1), "Index 1");
        Assert.IsNull(array.GetArray(2), "Index 2");
        Assert.IsNull(array.GetArray(3), "Index 3");
        Assert.IsNull(array.GetArray(4), "Index 4");
        Assert.IsNotNull(array.GetArray(5), "Index 5");
        Assert.IsNull(array.GetArray(6), "Index 6");
        Assert.IsNull(array.GetArray(7), "Index 7");
        Assert.IsNull(array.GetArray(8), "Index 8");
        Assert.IsNull(array.GetArray(9), "Index 9");
        Assert.IsNull(array.GetArray(10), "Index 10");
        Assert.IsNull(array.GetArray(11), "Index 11");

    }

    [TestMethod]
    public void GetArrayByPath() {

        JArray array = new("", "Hello there!", 1, 123.456, null, new JArray(), new JObject(), true, false, long.MaxValue, "9223372036854775808");

        Assert.IsNull(array.GetArrayByPath("[0]"), "Index 0");
        Assert.IsNull(array.GetArrayByPath("[1]"), "Index 1");
        Assert.IsNull(array.GetArrayByPath("[2]"), "Index 2");
        Assert.IsNull(array.GetArrayByPath("[3]"), "Index 3");
        Assert.IsNull(array.GetArrayByPath("[4]"), "Index 4");
        Assert.IsNotNull(array.GetArrayByPath("[5]"), "Index 5");
        Assert.IsNull(array.GetArrayByPath("[6]"), "Index 6");
        Assert.IsNull(array.GetArrayByPath("[7]"), "Index 7");
        Assert.IsNull(array.GetArrayByPath("[8]"), "Index 8");
        Assert.IsNull(array.GetArrayByPath("[9]"), "Index 9");
        Assert.IsNull(array.GetArrayByPath("[10]"), "Index 10");
        Assert.IsNull(array.GetArrayByPath("[11]"), "Index 11");

    }

}