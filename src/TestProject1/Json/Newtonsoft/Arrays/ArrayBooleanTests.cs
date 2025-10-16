using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace TestProject1.Json.Newtonsoft.Arrays;

[TestClass]
public class ArrayBooleanTests {

    protected static readonly JArray Sample1 = new(new object[11]) {
        [0] = "",
        [1] = "Hello there!",
        [2] = 123,
        [3] = 123.456,
        [4] = null,
        [5] = new JArray(),
        [6] = new JObject(),
        [7] = true,
        [8] = false,
        [9] = long.MaxValue,
        [10] = "9223372036854775808" // long.MaxValue + 1
    };

    protected static readonly JArray SampleBoolean = new(new object[11]) {
        [0] = "",
        [1] = "Hello there!",
        [2] = 1,
        [3] = 123.456,
        [4] = null,
        [5] = new JArray(),
        [6] = new JObject(),
        [7] = true,
        [8] = false,
        [9] = long.MaxValue,
        [10] = "9223372036854775808" // long.MaxValue + 1
    };


    [TestMethod]
    public void GetBoolean() {
        Assert.AreEqual(false, SampleBoolean.GetBoolean(0), "Index 0");
        Assert.AreEqual(false, SampleBoolean.GetBoolean(1), "Index 1");
        Assert.AreEqual(true, SampleBoolean.GetBoolean(2), "Index 2");
        Assert.AreEqual(false, SampleBoolean.GetBoolean(3), "Index 3");
        Assert.AreEqual(false, SampleBoolean.GetBoolean(4), "Index 4");
        Assert.AreEqual(false, SampleBoolean.GetBoolean(5), "Index 5");
        Assert.AreEqual(false, SampleBoolean.GetBoolean(6), "Index 6");
        Assert.AreEqual(true, SampleBoolean.GetBoolean(7), "Index 7");
        Assert.AreEqual(false, SampleBoolean.GetBoolean(8), "Index 8");
        Assert.AreEqual(false, SampleBoolean.GetBoolean(9), "Index 9");
        Assert.AreEqual(false, SampleBoolean.GetBoolean(10), "Index 10");
        Assert.AreEqual(false, SampleBoolean.GetBoolean(11), "Index 11");
    }

    [TestMethod]
    public void GetBooleanOrNull() {
        Assert.AreEqual(null, SampleBoolean.GetBooleanOrNull(0), "Index 0");
        Assert.AreEqual(null, SampleBoolean.GetBooleanOrNull(1), "Index 1");
        Assert.AreEqual(true, SampleBoolean.GetBooleanOrNull(2), "Index 2");
        Assert.AreEqual(null, SampleBoolean.GetBooleanOrNull(3), "Index 3");
        Assert.AreEqual(null, SampleBoolean.GetBooleanOrNull(4), "Index 4");
        Assert.AreEqual(null, SampleBoolean.GetBooleanOrNull(5), "Index 5");
        Assert.AreEqual(null, SampleBoolean.GetBooleanOrNull(6), "Index 6");
        Assert.AreEqual(true, SampleBoolean.GetBooleanOrNull(7), "Index 7");
        Assert.AreEqual(false, SampleBoolean.GetBooleanOrNull(8), "Index 8");
        Assert.AreEqual(null, SampleBoolean.GetBooleanOrNull(9), "Index 9");
        Assert.AreEqual(null, SampleBoolean.GetBooleanOrNull(10), "Index 10");
        Assert.AreEqual(null, SampleBoolean.GetBooleanOrNull(11), "Index 11");
    }

    [TestMethod]
    public void GetBooleanByPath() {
        Assert.AreEqual(false, SampleBoolean.GetBooleanByPath("[0]"), "Index 0");
        Assert.AreEqual(false, SampleBoolean.GetBooleanByPath("[1]"), "Index 1");
        Assert.AreEqual(true, SampleBoolean.GetBooleanByPath("[2]"), "Index 2");
        Assert.AreEqual(false, SampleBoolean.GetBooleanByPath("[3]"), "Index 3");
        Assert.AreEqual(false, SampleBoolean.GetBooleanByPath("[4]"), "Index 4");
        Assert.AreEqual(false, SampleBoolean.GetBooleanByPath("[5]"), "Index 5");
        Assert.AreEqual(false, SampleBoolean.GetBooleanByPath("[6]"), "Index 6");
        Assert.AreEqual(true, SampleBoolean.GetBooleanByPath("[7]"), "Index 7");
        Assert.AreEqual(false, SampleBoolean.GetBooleanByPath("[8]"), "Index 8");
        Assert.AreEqual(false, SampleBoolean.GetBooleanByPath("[9]"), "Index 9");
        Assert.AreEqual(false, SampleBoolean.GetBooleanByPath("[10]"), "Index 10");
        Assert.AreEqual(false, SampleBoolean.GetBooleanByPath("[11]"), "Index 11");
    }

    [TestMethod]
    public void GetBooleanByPathOrNull() {
        Assert.AreEqual(null, SampleBoolean.GetBooleanByPathOrNull("[0]"), "Index 0");
        Assert.AreEqual(null, SampleBoolean.GetBooleanByPathOrNull("[1]"), "Index 1");
        Assert.AreEqual(true, SampleBoolean.GetBooleanByPathOrNull("[2]"), "Index 2");
        Assert.AreEqual(null, SampleBoolean.GetBooleanByPathOrNull("[3]"), "Index 3");
        Assert.AreEqual(null, SampleBoolean.GetBooleanByPathOrNull("[4]"), "Index 4");
        Assert.AreEqual(null, SampleBoolean.GetBooleanByPathOrNull("[5]"), "Index 5");
        Assert.AreEqual(null, SampleBoolean.GetBooleanByPathOrNull("[6]"), "Index 6");
        Assert.AreEqual(true, SampleBoolean.GetBooleanByPathOrNull("[7]"), "Index 7");
        Assert.AreEqual(false, SampleBoolean.GetBooleanByPathOrNull("[8]"), "Index 8");
        Assert.AreEqual(null, SampleBoolean.GetBooleanByPathOrNull("[9]"), "Index 9");
        Assert.AreEqual(null, SampleBoolean.GetBooleanByPathOrNull("[10]"), "Index 10");
        Assert.AreEqual(null, SampleBoolean.GetBooleanByPathOrNull("[11]"), "Index 11");
    }

    [TestMethod]
    public void TryGetBoolean() {

        bool success0 = SampleBoolean.TryGetBoolean(0, out bool result0);
        bool success1 = SampleBoolean.TryGetBoolean(1, out bool result1);
        bool success2 = SampleBoolean.TryGetBoolean(2, out bool result2);
        bool success3 = SampleBoolean.TryGetBoolean(3, out bool result3);
        bool success4 = SampleBoolean.TryGetBoolean(4, out bool result4);
        bool success5 = SampleBoolean.TryGetBoolean(5, out bool result5);
        bool success6 = SampleBoolean.TryGetBoolean(6, out bool result6);
        bool success7 = SampleBoolean.TryGetBoolean(7, out bool result7);
        bool success8 = SampleBoolean.TryGetBoolean(8, out bool result8);
        bool success9 = SampleBoolean.TryGetBoolean(9, out bool result9);
        bool success10 = SampleBoolean.TryGetBoolean(10, out bool result10);
        bool success11 = SampleBoolean.TryGetBoolean(11, out bool result11);

        Assert.IsFalse(success0);
        Assert.AreEqual(false, result0, "Index 0");

        Assert.IsFalse(success1);
        Assert.AreEqual(false, result1, "Index 1");

        Assert.IsTrue(success2);
        Assert.AreEqual(true, result2, "Index 2");

        Assert.IsFalse(success3);
        Assert.AreEqual(false, result3, "Index 3");

        Assert.IsFalse(success4);
        Assert.AreEqual(false, result4, "Index 4");

        Assert.IsFalse(success5);
        Assert.AreEqual(false, result5, "Index 5");

        Assert.IsFalse(success6);
        Assert.AreEqual(false, result6, "Index 6");

        Assert.IsTrue(success7);
        Assert.AreEqual(true, result7, "Index 7");

        Assert.IsTrue(success8);
        Assert.AreEqual(false, result8, "Index 8");

        Assert.IsFalse(success9);
        Assert.AreEqual(false, result9, "Index 9");

        Assert.IsFalse(success10);
        Assert.AreEqual(false, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(false, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetBooleanOrNull() {

        bool success0 = SampleBoolean.TryGetBoolean(0, out bool? result0);
        bool success1 = SampleBoolean.TryGetBoolean(1, out bool? result1);
        bool success2 = SampleBoolean.TryGetBoolean(2, out bool? result2);
        bool success3 = SampleBoolean.TryGetBoolean(3, out bool? result3);
        bool success4 = SampleBoolean.TryGetBoolean(4, out bool? result4);
        bool success5 = SampleBoolean.TryGetBoolean(5, out bool? result5);
        bool success6 = SampleBoolean.TryGetBoolean(6, out bool? result6);
        bool success7 = SampleBoolean.TryGetBoolean(7, out bool? result7);
        bool success8 = SampleBoolean.TryGetBoolean(8, out bool? result8);
        bool success9 = SampleBoolean.TryGetBoolean(9, out bool? result9);
        bool success10 = SampleBoolean.TryGetBoolean(10, out bool? result10);
        bool success11 = SampleBoolean.TryGetBoolean(11, out bool? result11);

        Assert.IsFalse(success0);
        Assert.AreEqual(null, result0, "Index 0");

        Assert.IsFalse(success1);
        Assert.AreEqual(null, result1, "Index 1");

        Assert.IsTrue(success2);
        Assert.AreEqual(true, result2, "Index 2");

        Assert.IsFalse(success3);
        Assert.AreEqual(null, result3, "Index 3");

        Assert.IsFalse(success4);
        Assert.AreEqual(null, result4, "Index 4");

        Assert.IsFalse(success5);
        Assert.AreEqual(null, result5, "Index 5");

        Assert.IsFalse(success6);
        Assert.AreEqual(null, result6, "Index 6");

        Assert.IsTrue(success7);
        Assert.AreEqual(true, result7, "Index 7");

        Assert.IsTrue(success8);
        Assert.AreEqual(false, result8, "Index 8");

        Assert.IsFalse(success9);
        Assert.AreEqual(null, result9, "Index 9");

        Assert.IsFalse(success10);
        Assert.AreEqual(null, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(null, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetBooleanByPath() {

        bool success0 = SampleBoolean.TryGetBooleanByPath("[0]", out bool result0);
        bool success1 = SampleBoolean.TryGetBooleanByPath("[1]", out bool result1);
        bool success2 = SampleBoolean.TryGetBooleanByPath("[2]", out bool result2);
        bool success3 = SampleBoolean.TryGetBooleanByPath("[3]", out bool result3);
        bool success4 = SampleBoolean.TryGetBooleanByPath("[4]", out bool result4);
        bool success5 = SampleBoolean.TryGetBooleanByPath("[5]", out bool result5);
        bool success6 = SampleBoolean.TryGetBooleanByPath("[6]", out bool result6);
        bool success7 = SampleBoolean.TryGetBooleanByPath("[7]", out bool result7);
        bool success8 = SampleBoolean.TryGetBooleanByPath("[8]", out bool result8);
        bool success9 = SampleBoolean.TryGetBooleanByPath("[9]", out bool result9);
        bool success10 = SampleBoolean.TryGetBooleanByPath("[10]", out bool result10);
        bool success11 = SampleBoolean.TryGetBooleanByPath("[11]", out bool result11);

        Assert.IsFalse(success0);
        Assert.AreEqual(false, result0, "Index 0");

        Assert.IsFalse(success1);
        Assert.AreEqual(false, result1, "Index 1");

        Assert.IsTrue(success2);
        Assert.AreEqual(true, result2, "Index 2");

        Assert.IsFalse(success3);
        Assert.AreEqual(false, result3, "Index 3");

        Assert.IsFalse(success4);
        Assert.AreEqual(false, result4, "Index 4");

        Assert.IsFalse(success5);
        Assert.AreEqual(false, result5, "Index 5");

        Assert.IsFalse(success6);
        Assert.AreEqual(false, result6, "Index 6");

        Assert.IsTrue(success7);
        Assert.AreEqual(true, result7, "Index 7");

        Assert.IsTrue(success8);
        Assert.AreEqual(false, result8, "Index 8");

        Assert.IsFalse(success9);
        Assert.AreEqual(false, result9, "Index 9");

        Assert.IsFalse(success10);
        Assert.AreEqual(false, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(false, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetBooleanByPathOrNull() {

        bool success0 = SampleBoolean.TryGetBooleanByPath("[0]", out bool? result0);
        bool success1 = SampleBoolean.TryGetBooleanByPath("[1]", out bool? result1);
        bool success2 = SampleBoolean.TryGetBooleanByPath("[2]", out bool? result2);
        bool success3 = SampleBoolean.TryGetBooleanByPath("[3]", out bool? result3);
        bool success4 = SampleBoolean.TryGetBooleanByPath("[4]", out bool? result4);
        bool success5 = SampleBoolean.TryGetBooleanByPath("[5]", out bool? result5);
        bool success6 = SampleBoolean.TryGetBooleanByPath("[6]", out bool? result6);
        bool success7 = SampleBoolean.TryGetBooleanByPath("[7]", out bool? result7);
        bool success8 = SampleBoolean.TryGetBooleanByPath("[8]", out bool? result8);
        bool success9 = SampleBoolean.TryGetBooleanByPath("[9]", out bool? result9);
        bool success10 = SampleBoolean.TryGetBooleanByPath("[10]", out bool? result10);
        bool success11 = SampleBoolean.TryGetBooleanByPath("[11]", out bool? result11);

        Assert.IsFalse(success0);
        Assert.AreEqual(null, result0, "Index 0");

        Assert.IsFalse(success1);
        Assert.AreEqual(null, result1, "Index 1");

        Assert.IsTrue(success2);
        Assert.AreEqual(true, result2, "Index 2");

        Assert.IsFalse(success3);
        Assert.AreEqual(null, result3, "Index 3");

        Assert.IsFalse(success4);
        Assert.AreEqual(null, result4, "Index 4");

        Assert.IsFalse(success5);
        Assert.AreEqual(null, result5, "Index 5");

        Assert.IsFalse(success6);
        Assert.AreEqual(null, result6, "Index 6");

        Assert.IsTrue(success7);
        Assert.AreEqual(true, result7, "Index 7");

        Assert.IsTrue(success8);
        Assert.AreEqual(false, result8, "Index 8");

        Assert.IsFalse(success9);
        Assert.AreEqual(null, result9, "Index 9");

        Assert.IsFalse(success10);
        Assert.AreEqual(null, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(null, result11, "Index 11");

    }

}