using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace TestProject1.Json.Newtonsoft.Arrays;

[TestClass]
public class ArrayInt64Tests {

    protected static readonly JValue Null = JValue.CreateNull();

    protected const long Zero = 0;

    protected const long One = 1;

    protected const long OneTwoThree = 123;

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
    public void GetInt64() {
        Assert.AreEqual(0, SampleArray.GetInt64(0), "Index 0");
        Assert.AreEqual(0, SampleArray.GetInt64(1), "Index 1");
        Assert.AreEqual(123, SampleArray.GetInt64(2), "Index 2");
        Assert.AreEqual(123, SampleArray.GetInt64(3), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(0, SampleArray.GetInt64(4), "Index 4");
        Assert.AreEqual(0, SampleArray.GetInt64(5), "Index 5");
        Assert.AreEqual(0, SampleArray.GetInt64(6), "Index 6");
        Assert.AreEqual(1, SampleArray.GetInt64(7), "Index 7");
        Assert.AreEqual(0, SampleArray.GetInt64(8), "Index 8");
        Assert.AreEqual(long.MaxValue, SampleArray.GetInt64(9), "Index 9");
        Assert.AreEqual(0, SampleArray.GetInt64(10), "Index 10");
        Assert.AreEqual(0, SampleArray.GetInt64(11), "Index 11");
    }

    [TestMethod]
    public void GetInt64OrNull() {
        Assert.AreEqual(null, SampleArray.GetInt64OrNull(0), "Index 0");
        Assert.AreEqual(null, SampleArray.GetInt64OrNull(1), "Index 1");
        Assert.AreEqual(123, SampleArray.GetInt64OrNull(2), "Index 2");
        Assert.AreEqual(123, SampleArray.GetInt64OrNull(3), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(null, SampleArray.GetInt64OrNull(4), "Index 4");
        Assert.AreEqual(null, SampleArray.GetInt64OrNull(5), "Index 5");
        Assert.AreEqual(null, SampleArray.GetInt64OrNull(6), "Index 6");
        Assert.AreEqual(1, SampleArray.GetInt64OrNull(7), "Index 7");
        Assert.AreEqual(0, SampleArray.GetInt64OrNull(8), "Index 8");
        Assert.AreEqual(long.MaxValue, SampleArray.GetInt64OrNull(9), "Index 9");
        Assert.AreEqual(null, SampleArray.GetInt64OrNull(10), "Index 10");
        Assert.AreEqual(null, SampleArray.GetInt64OrNull(11), "Index 11");
    }

    [TestMethod]
    public void GetInt64ByPath() {
        Assert.AreEqual(0, SampleArray.GetInt64ByPath("[0]"), "Index 0");
        Assert.AreEqual(0, SampleArray.GetInt64ByPath("[1]"), "Index 1");
        Assert.AreEqual(123, SampleArray.GetInt64ByPath("[2]"), "Index 2");
        Assert.AreEqual(123, SampleArray.GetInt64ByPath("[3]"), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(0, SampleArray.GetInt64ByPath("[4]"), "Index 4");
        Assert.AreEqual(0, SampleArray.GetInt64ByPath("[5]"), "Index 5");
        Assert.AreEqual(0, SampleArray.GetInt64ByPath("[6]"), "Index 6");
        Assert.AreEqual(1, SampleArray.GetInt64ByPath("[7]"), "Index 7");
        Assert.AreEqual(0, SampleArray.GetInt64ByPath("[8]"), "Index 8");
        Assert.AreEqual(long.MaxValue, SampleArray.GetInt64ByPath("[9]"), "Index 9");
        Assert.AreEqual(0, SampleArray.GetInt64ByPath("[10]"), "Index 10");
        Assert.AreEqual(0, SampleArray.GetInt64ByPath("[11]"), "Index 11");
    }

    [TestMethod]
    public void GetInt64ByPathOrNull() {
        Assert.AreEqual(null, SampleArray.GetInt64ByPathOrNull("[0]"), "Index 0");
        Assert.AreEqual(null, SampleArray.GetInt64ByPathOrNull("[1]"), "Index 1");
        Assert.AreEqual(123, SampleArray.GetInt64ByPathOrNull("[2]"), "Index 2");
        Assert.AreEqual(123, SampleArray.GetInt64ByPathOrNull("[3]"), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(null, SampleArray.GetInt64ByPathOrNull("[4]"), "Index 4");
        Assert.AreEqual(null, SampleArray.GetInt64ByPathOrNull("[5]"), "Index 5");
        Assert.AreEqual(null, SampleArray.GetInt64ByPathOrNull("[6]"), "Index 6");
        Assert.AreEqual(1, SampleArray.GetInt64ByPathOrNull("[7]"), "Index 7");
        Assert.AreEqual(0, SampleArray.GetInt64ByPathOrNull("[8]"), "Index 8");
        Assert.AreEqual(long.MaxValue, SampleArray.GetInt64ByPathOrNull("[9]"), "Index 9");
        Assert.AreEqual(null, SampleArray.GetInt64ByPathOrNull("[10]"), "Index 10");
        Assert.AreEqual(null, SampleArray.GetInt64ByPathOrNull("[11]"), "Index 11");
    }

    [TestMethod]
    public void TryGetInt64() {

        bool success0 = SampleArray.TryGetInt64(0, out long result0);
        bool success1 = SampleArray.TryGetInt64(1, out long result1);
        bool success2 = SampleArray.TryGetInt64(2, out long result2);
        bool success3 = SampleArray.TryGetInt64(3, out long result3);
        bool success4 = SampleArray.TryGetInt64(4, out long result4);
        bool success5 = SampleArray.TryGetInt64(5, out long result5);
        bool success6 = SampleArray.TryGetInt64(6, out long result6);
        bool success7 = SampleArray.TryGetInt64(7, out long result7);
        bool success8 = SampleArray.TryGetInt64(8, out long result8);
        bool success9 = SampleArray.TryGetInt64(9, out long result9);
        bool success10 = SampleArray.TryGetInt64(10, out long result10);
        bool success11 = SampleArray.TryGetInt64(11, out long result11);

        Assert.IsFalse(success0);
        Assert.AreEqual(0, result0, "Index 0");

        Assert.IsFalse(success1);
        Assert.AreEqual(0, result1, "Index 1");

        Assert.IsTrue(success2);
        Assert.AreEqual(OneTwoThree, result2, "Index 2");

        Assert.IsTrue(success3);
        Assert.AreEqual(OneTwoThree, result3, "Index 3");

        Assert.IsFalse(success4);
        Assert.AreEqual(0, result4, "Index 4");

        Assert.IsFalse(success5);
        Assert.AreEqual(0, result5, "Index 5");

        Assert.IsFalse(success6);
        Assert.AreEqual(0, result6, "Index 6");

        Assert.IsTrue(success7);
        Assert.AreEqual(One, result7, "Index 7");

        Assert.IsTrue(success8);
        Assert.AreEqual(Zero, result8, "Index 8");

        Assert.IsTrue(success9);
        Assert.AreEqual(long.MaxValue, result9, "Index 9");

        Assert.IsFalse(success10);
        Assert.AreEqual(0, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(0, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetInt64OrNull() {

        bool success0 = SampleArray.TryGetInt64(0, out long? result0);
        bool success1 = SampleArray.TryGetInt64(1, out long? result1);
        bool success2 = SampleArray.TryGetInt64(2, out long? result2);
        bool success3 = SampleArray.TryGetInt64(3, out long? result3);
        bool success4 = SampleArray.TryGetInt64(4, out long? result4);
        bool success5 = SampleArray.TryGetInt64(5, out long? result5);
        bool success6 = SampleArray.TryGetInt64(6, out long? result6);
        bool success7 = SampleArray.TryGetInt64(7, out long? result7);
        bool success8 = SampleArray.TryGetInt64(8, out long? result8);
        bool success9 = SampleArray.TryGetInt64(9, out long? result9);
        bool success10 = SampleArray.TryGetInt64(10, out long? result10);
        bool success11 = SampleArray.TryGetInt64(11, out long? result11);

        Assert.IsFalse(success0);
        Assert.AreEqual(null, result0, "Index 0");

        Assert.IsFalse(success1);
        Assert.AreEqual(null, result1, "Index 1");

        Assert.IsTrue(success2);
        Assert.AreEqual(OneTwoThree, result2, "Index 2");

        Assert.IsTrue(success3);
        Assert.AreEqual(OneTwoThree, result3, "Index 3");

        Assert.IsFalse(success4);
        Assert.AreEqual(null, result4, "Index 4");

        Assert.IsFalse(success5);
        Assert.AreEqual(null, result5, "Index 5");

        Assert.IsFalse(success6);
        Assert.AreEqual(null, result6, "Index 6");

        Assert.IsTrue(success7);
        Assert.AreEqual(One, result7, "Index 7");

        Assert.IsTrue(success8);
        Assert.AreEqual(Zero, result8, "Index 8");

        Assert.IsTrue(success9);
        Assert.AreEqual(long.MaxValue, result9, "Index 9");

        Assert.IsFalse(success10);
        Assert.AreEqual(null, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(null, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetInt64ByPath() {

        bool success0 = SampleArray.TryGetInt64ByPath("[0]", out long result0);
        bool success1 = SampleArray.TryGetInt64ByPath("[1]", out long result1);
        bool success2 = SampleArray.TryGetInt64ByPath("[2]", out long result2);
        bool success3 = SampleArray.TryGetInt64ByPath("[3]", out long result3);
        bool success4 = SampleArray.TryGetInt64ByPath("[4]", out long result4);
        bool success5 = SampleArray.TryGetInt64ByPath("[5]", out long result5);
        bool success6 = SampleArray.TryGetInt64ByPath("[6]", out long result6);
        bool success7 = SampleArray.TryGetInt64ByPath("[7]", out long result7);
        bool success8 = SampleArray.TryGetInt64ByPath("[8]", out long result8);
        bool success9 = SampleArray.TryGetInt64ByPath("[9]", out long result9);
        bool success10 = SampleArray.TryGetInt64ByPath("[10]", out long result10);
        bool success11 = SampleArray.TryGetInt64ByPath("[11]", out long result11);

        Assert.IsFalse(success0);
        Assert.AreEqual(0, result0, "Index 0");

        Assert.IsFalse(success1);
        Assert.AreEqual(0, result1, "Index 1");

        Assert.IsTrue(success2);
        Assert.AreEqual(OneTwoThree, result2, "Index 2");

        Assert.IsTrue(success3);
        Assert.AreEqual(OneTwoThree, result3, "Index 3");

        Assert.IsFalse(success4);
        Assert.AreEqual(0, result4, "Index 4");

        Assert.IsFalse(success5);
        Assert.AreEqual(0, result5, "Index 5");

        Assert.IsFalse(success6);
        Assert.AreEqual(0, result6, "Index 6");

        Assert.IsTrue(success7);
        Assert.AreEqual(One, result7, "Index 7");

        Assert.IsTrue(success8);
        Assert.AreEqual(Zero, result8, "Index 8");

        Assert.IsTrue(success9);
        Assert.AreEqual(long.MaxValue, result9, "Index 9");

        Assert.IsFalse(success10);
        Assert.AreEqual(0, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(0, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetInt64ByPathOrNull() {

        bool success0 = SampleArray.TryGetInt64ByPath("[0]", out long? result0);
        bool success1 = SampleArray.TryGetInt64ByPath("[1]", out long? result1);
        bool success2 = SampleArray.TryGetInt64ByPath("[2]", out long? result2);
        bool success3 = SampleArray.TryGetInt64ByPath("[3]", out long? result3);
        bool success4 = SampleArray.TryGetInt64ByPath("[4]", out long? result4);
        bool success5 = SampleArray.TryGetInt64ByPath("[5]", out long? result5);
        bool success6 = SampleArray.TryGetInt64ByPath("[6]", out long? result6);
        bool success7 = SampleArray.TryGetInt64ByPath("[7]", out long? result7);
        bool success8 = SampleArray.TryGetInt64ByPath("[8]", out long? result8);
        bool success9 = SampleArray.TryGetInt64ByPath("[9]", out long? result9);
        bool success10 = SampleArray.TryGetInt64ByPath("[10]", out long? result10);
        bool success11 = SampleArray.TryGetInt64ByPath("[11]", out long? result11);

        Assert.IsFalse(success0);
        Assert.AreEqual(null, result0, "Index 0");

        Assert.IsFalse(success1);
        Assert.AreEqual(null, result1, "Index 1");

        Assert.IsTrue(success2);
        Assert.AreEqual(OneTwoThree, result2, "Index 2");

        Assert.IsTrue(success3);
        Assert.AreEqual(OneTwoThree, result3, "Index 3");

        Assert.IsFalse(success4);
        Assert.AreEqual(null, result4, "Index 4");

        Assert.IsFalse(success5);
        Assert.AreEqual(null, result5, "Index 5");

        Assert.IsFalse(success6);
        Assert.AreEqual(null, result6, "Index 6");

        Assert.IsTrue(success7);
        Assert.AreEqual(One, result7, "Index 7");

        Assert.IsTrue(success8);
        Assert.AreEqual(Zero, result8, "Index 8");

        Assert.IsTrue(success9);
        Assert.AreEqual(long.MaxValue, result9, "Index 9");

        Assert.IsFalse(success10);
        Assert.AreEqual(null, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(null, result11, "Index 11");

    }

}