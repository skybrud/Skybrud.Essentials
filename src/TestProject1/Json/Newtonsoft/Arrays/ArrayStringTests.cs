using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace TestProject1.Json.Newtonsoft.Arrays;

[TestClass]
public class ArrayStringTests {

    protected static readonly JValue Null = JValue.CreateNull();

    protected const int Zero = 0;

    protected const int One = 1;

    protected const int OneTwoThree = 123;

    protected static readonly JArray SampleArray = new(new object[11]) {
        [0] = "",
        [1] = "Hello there!",
        [2] = 123,
        [3] = 123.456,
        [4] = Null,
        [5] = new JArray(),
        [6] = new JObject(),
        [7] = true,
        [8] = false,
        [9] = long.MaxValue,
        [10] = "9223372036854775808" // long.MaxValue + 1
    };


    [TestMethod]
    public void GetString() {
        Assert.AreEqual("", SampleArray.GetString(0), "Index 0");
        Assert.AreEqual("Hello there!", SampleArray.GetString(1), "Index 1");
        Assert.AreEqual("123", SampleArray.GetString(2), "Index 2");
        Assert.AreEqual("123.456", SampleArray.GetString(3), "Index 3");
        Assert.AreEqual(null, SampleArray.GetString(4), "Index 4");
        Assert.AreEqual(null, SampleArray.GetString(5), "Index 5");
        Assert.AreEqual(null, SampleArray.GetString(6), "Index 6");
        Assert.AreEqual("True", SampleArray.GetString(7), "Index 7");
        Assert.AreEqual("False", SampleArray.GetString(8), "Index 8");
        Assert.AreEqual("9223372036854775807", SampleArray.GetString(9), "Index 9");
        Assert.AreEqual("9223372036854775808", SampleArray.GetString(10), "Index 10");
        Assert.AreEqual(null, SampleArray.GetString(11), "Index 11");
    }

    [TestMethod]
    public void GetStringByPath() {
        Assert.AreEqual("", SampleArray.GetStringByPath("[0]"), "Index 0");
        Assert.AreEqual("Hello there!", SampleArray.GetStringByPath("[1]"), "Index 1");
        Assert.AreEqual("123", SampleArray.GetStringByPath("[2]"), "Index 2");
        Assert.AreEqual("123.456", SampleArray.GetStringByPath("[3]"), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(null, SampleArray.GetStringByPath("[4]"), "Index 4");
        Assert.AreEqual(null, SampleArray.GetStringByPath("[5]"), "Index 5");
        Assert.AreEqual(null, SampleArray.GetStringByPath("[6]"), "Index 6");
        Assert.AreEqual("True", SampleArray.GetStringByPath("[7]"), "Index 7");
        Assert.AreEqual("False", SampleArray.GetStringByPath("[8]"), "Index 8");
        Assert.AreEqual("9223372036854775807", SampleArray.GetStringByPath("[9]"), "Index 9");
        Assert.AreEqual("9223372036854775808", SampleArray.GetStringByPath("[10]"), "Index 10");
        Assert.AreEqual(null, SampleArray.GetStringByPath("[11]"), "Index 11");
    }

    [TestMethod]
    public void TryGetString() {

        bool success0 = SampleArray.TryGetString(0, out string? result0);
        bool success1 = SampleArray.TryGetString(1, out string? result1);
        bool success2 = SampleArray.TryGetString(2, out string? result2);
        bool success3 = SampleArray.TryGetString(3, out string? result3);
        bool success4 = SampleArray.TryGetString(4, out string? result4);
        bool success5 = SampleArray.TryGetString(5, out string? result5);
        bool success6 = SampleArray.TryGetString(6, out string? result6);
        bool success7 = SampleArray.TryGetString(7, out string? result7);
        bool success8 = SampleArray.TryGetString(8, out string? result8);
        bool success9 = SampleArray.TryGetString(9, out string? result9);
        bool success10 = SampleArray.TryGetString(10, out string? result10);
        bool success11 = SampleArray.TryGetString(11, out string? result11);

        Assert.IsTrue(success0, "Index 0");
        Assert.AreEqual("", result0, "Index 0");

        Assert.IsTrue(success1, "Index 1");
        Assert.AreEqual("Hello there!", result1, "Index 1");

        Assert.IsTrue(success2, "Index 2");
        Assert.AreEqual("123", result2, "Index 2");

        Assert.IsTrue(success3, "Index 3");
        Assert.AreEqual("123.456", result3, "Index 3");

        Assert.IsFalse(success4, "Index 4");
        Assert.AreEqual(null, result4, "Index 4");

        Assert.IsFalse(success5, "Index 5");
        Assert.AreEqual(null, result5, "Index 5");

        Assert.IsFalse(success6, "Index 6");
        Assert.AreEqual(null, result6, "Index 6");

        Assert.IsTrue(success7, "Index 7");
        Assert.AreEqual("True", result7, "Index 7");

        Assert.IsTrue(success8, "Index 8");
        Assert.AreEqual("False", result8, "Index 8");

        Assert.IsTrue(success9, "Index 9");
        Assert.AreEqual("9223372036854775807", result9, "Index 9");

        Assert.IsTrue(success10, "Index 10");
        Assert.AreEqual("9223372036854775808", result10, "Index 10");

        Assert.IsFalse(success11, "Index 11");
        Assert.AreEqual(null, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetStringByPath() {

        bool success0 = SampleArray.TryGetStringByPath("[0]", out string? result0);
        bool success1 = SampleArray.TryGetStringByPath("[1]", out string? result1);
        bool success2 = SampleArray.TryGetStringByPath("[2]", out string? result2);
        bool success3 = SampleArray.TryGetStringByPath("[3]", out string? result3);
        bool success4 = SampleArray.TryGetStringByPath("[4]", out string? result4);
        bool success5 = SampleArray.TryGetStringByPath("[5]", out string? result5);
        bool success6 = SampleArray.TryGetStringByPath("[6]", out string? result6);
        bool success7 = SampleArray.TryGetStringByPath("[7]", out string? result7);
        bool success8 = SampleArray.TryGetStringByPath("[8]", out string? result8);
        bool success9 = SampleArray.TryGetStringByPath("[9]", out string? result9);
        bool success10 = SampleArray.TryGetStringByPath("[10]", out string? result10);
        bool success11 = SampleArray.TryGetStringByPath("[11]", out string? result11);

        Assert.IsTrue(success0, "Index 0");
        Assert.AreEqual("", result0, "Index 0");

        Assert.IsTrue(success1, "Index 1");
        Assert.AreEqual("Hello there!", result1, "Index 1");

        Assert.IsTrue(success2, "Index 2");
        Assert.AreEqual("123", result2, "Index 2");

        Assert.IsTrue(success3, "Index 3");
        Assert.AreEqual("123.456", result3, "Index 3");

        Assert.IsFalse(success4, "Index 4");
        Assert.AreEqual(null, result4, "Index 4");

        Assert.IsFalse(success5, "Index 5");
        Assert.AreEqual(null, result5, "Index 5");

        Assert.IsFalse(success6, "Index 6");
        Assert.AreEqual(null, result6, "Index 6");

        Assert.IsTrue(success7, "Index 7");
        Assert.AreEqual("True", result7, "Index 7");

        Assert.IsTrue(success8, "Index 8");
        Assert.AreEqual("False", result8, "Index 8");

        Assert.IsTrue(success9, "Index 9");
        Assert.AreEqual("9223372036854775807", result9, "Index 9");

        Assert.IsTrue(success10, "Index 10");
        Assert.AreEqual("9223372036854775808", result10, "Index 10");

        Assert.IsFalse(success11, "Index 11");
        Assert.AreEqual(null, result11, "Index 11");

    }

}