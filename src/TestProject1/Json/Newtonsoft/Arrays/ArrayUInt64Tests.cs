using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace TestProject1.Json.Newtonsoft.Arrays;

[TestClass]
public class ArrayUInt64Tests {

    protected const ulong Zero = 0;

    protected const ulong One = 1;

    protected const ulong OneTwoThree = 123;

    protected const ulong Int64MaxValue = 9223372036854775808; // technically this should be 9223372036854775807, but it becomes 9223372036854775808 with JSON.net

    protected static readonly JArray SampleArray = new(new object[11]) {
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

    [TestMethod]
    public void GetUInt64() {

        Assert.AreEqual(Zero, SampleArray.GetUInt64(0), "Index 0");
        Assert.AreEqual(Zero, SampleArray.GetUInt64(1), "Index 1");
        Assert.AreEqual(OneTwoThree, SampleArray.GetUInt64(2), "Index 2");
        Assert.AreEqual(OneTwoThree, SampleArray.GetUInt64(3), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(Zero, SampleArray.GetUInt64(4), "Index 4");
        Assert.AreEqual(Zero, SampleArray.GetUInt64(5), "Index 5");
        Assert.AreEqual(Zero, SampleArray.GetUInt64(6), "Index 6");
        Assert.AreEqual(One, SampleArray.GetUInt64(7), "Index 7");
        Assert.AreEqual(Zero, SampleArray.GetUInt64(8), "Index 8");
        Assert.AreEqual(Int64MaxValue, SampleArray.GetUInt64(9), "Index 9");
        Assert.AreEqual(Int64MaxValue, SampleArray.GetUInt64(10), "Index 10");
        Assert.AreEqual(Zero, SampleArray.GetUInt64(11), "Index 11");
    }

    [TestMethod]
    public void GetUInt64OrNull() {
        Assert.AreEqual(null, SampleArray.GetUInt64OrNull(0), "Index 0");
        Assert.AreEqual(null, SampleArray.GetUInt64OrNull(1), "Index 1");
        Assert.AreEqual(OneTwoThree, SampleArray.GetUInt64OrNull(2), "Index 2");
        Assert.AreEqual(OneTwoThree, SampleArray.GetUInt64OrNull(3), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(null, SampleArray.GetUInt64OrNull(4), "Index 4");
        Assert.AreEqual(null, SampleArray.GetUInt64OrNull(5), "Index 5");
        Assert.AreEqual(null, SampleArray.GetUInt64OrNull(6), "Index 6");
        Assert.AreEqual(One, SampleArray.GetUInt64OrNull(7), "Index 7");
        Assert.AreEqual(Zero, SampleArray.GetUInt64OrNull(8), "Index 8");
        Assert.AreEqual(Int64MaxValue, SampleArray.GetUInt64OrNull(9), "Index 9");
        Assert.AreEqual(Int64MaxValue, SampleArray.GetUInt64OrNull(10), "Index 10");
        Assert.AreEqual(null, SampleArray.GetUInt64OrNull(11), "Index 11");
    }

    [TestMethod]
    public void GetUInt64ByPath() {
        Assert.AreEqual(Zero, SampleArray.GetUInt64ByPath("[0]"), "Index 0");
        Assert.AreEqual(Zero, SampleArray.GetUInt64ByPath("[1]"), "Index 1");
        Assert.AreEqual(OneTwoThree, SampleArray.GetUInt64ByPath("[2]"), "Index 2");
        Assert.AreEqual(OneTwoThree, SampleArray.GetUInt64ByPath("[3]"), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(Zero, SampleArray.GetUInt64ByPath("[4]"), "Index 4");
        Assert.AreEqual(Zero, SampleArray.GetUInt64ByPath("[5]"), "Index 5");
        Assert.AreEqual(Zero, SampleArray.GetUInt64ByPath("[6]"), "Index 6");
        Assert.AreEqual(One, SampleArray.GetUInt64ByPath("[7]"), "Index 7");
        Assert.AreEqual(Zero, SampleArray.GetUInt64ByPath("[8]"), "Index 8");
        Assert.AreEqual(Int64MaxValue, SampleArray.GetUInt64ByPath("[9]"), "Index 9");
        Assert.AreEqual(Int64MaxValue, SampleArray.GetUInt64ByPath("[10]"), "Index 10");
        Assert.AreEqual(Zero, SampleArray.GetUInt64ByPath("[11]"), "Index 11");
    }

    [TestMethod]
    public void GetUInt64ByPathOrNull() {
        Assert.AreEqual(null, SampleArray.GetUInt64ByPathOrNull("[0]"), "Index 0");
        Assert.AreEqual(null, SampleArray.GetUInt64ByPathOrNull("[1]"), "Index 1");
        Assert.AreEqual(OneTwoThree, SampleArray.GetUInt64ByPathOrNull("[2]"), "Index 2");
        Assert.AreEqual(OneTwoThree, SampleArray.GetUInt64ByPathOrNull("[3]"), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(null, SampleArray.GetUInt64ByPathOrNull("[4]"), "Index 4");
        Assert.AreEqual(null, SampleArray.GetUInt64ByPathOrNull("[5]"), "Index 5");
        Assert.AreEqual(null, SampleArray.GetUInt64ByPathOrNull("[6]"), "Index 6");
        Assert.AreEqual(One, SampleArray.GetUInt64ByPathOrNull("[7]"), "Index 7");
        Assert.AreEqual(Zero, SampleArray.GetUInt64ByPathOrNull("[8]"), "Index 8");
        Assert.AreEqual(Int64MaxValue, SampleArray.GetUInt64ByPathOrNull("[9]"), "Index 9");
        Assert.AreEqual(Int64MaxValue, SampleArray.GetUInt64ByPathOrNull("[10]"), "Index 10");
        Assert.AreEqual(null, SampleArray.GetUInt64ByPathOrNull("[11]"), "Index 11");
    }

    [TestMethod]
    public void TryGetUInt64() {

        bool success0 = SampleArray.TryGetUInt64(0, out ulong result0);
        bool success1 = SampleArray.TryGetUInt64(1, out ulong result1);
        bool success2 = SampleArray.TryGetUInt64(2, out ulong result2);
        bool success3 = SampleArray.TryGetUInt64(3, out ulong result3);
        bool success4 = SampleArray.TryGetUInt64(4, out ulong result4);
        bool success5 = SampleArray.TryGetUInt64(5, out ulong result5);
        bool success6 = SampleArray.TryGetUInt64(6, out ulong result6);
        bool success7 = SampleArray.TryGetUInt64(7, out ulong result7);
        bool success8 = SampleArray.TryGetUInt64(8, out ulong result8);
        bool success9 = SampleArray.TryGetUInt64(9, out ulong result9);
        bool success10 = SampleArray.TryGetUInt64(10, out ulong result10);
        bool success11 = SampleArray.TryGetUInt64(11, out ulong result11);

        Assert.IsFalse(success0);
        Assert.AreEqual(Zero, result0, "Index 0");

        Assert.IsFalse(success1);
        Assert.AreEqual(Zero, result1, "Index 1");

        Assert.IsTrue(success2);
        Assert.AreEqual(OneTwoThree, result2, "Index 2");

        Assert.IsTrue(success3);
        Assert.AreEqual(OneTwoThree, result3, "Index 3");

        Assert.IsFalse(success4);
        Assert.AreEqual(Zero, result4, "Index 4");

        Assert.IsFalse(success5);
        Assert.AreEqual(Zero, result5, "Index 5");

        Assert.IsFalse(success6);
        Assert.AreEqual(Zero, result6, "Index 6");

        Assert.IsTrue(success7);
        Assert.AreEqual(One, result7, "Index 7");

        Assert.IsTrue(success8);
        Assert.AreEqual(Zero, result8, "Index 8");

        Assert.IsTrue(success9);
        Assert.AreEqual(Int64MaxValue, result9, "Index 9");

        Assert.IsTrue(success10);
        Assert.AreEqual(Int64MaxValue, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(Zero, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetUInt64OrNull() {

        bool success0 = SampleArray.TryGetUInt64(0, out ulong? result0);
        bool success1 = SampleArray.TryGetUInt64(1, out ulong? result1);
        bool success2 = SampleArray.TryGetUInt64(2, out ulong? result2);
        bool success3 = SampleArray.TryGetUInt64(3, out ulong? result3);
        bool success4 = SampleArray.TryGetUInt64(4, out ulong? result4);
        bool success5 = SampleArray.TryGetUInt64(5, out ulong? result5);
        bool success6 = SampleArray.TryGetUInt64(6, out ulong? result6);
        bool success7 = SampleArray.TryGetUInt64(7, out ulong? result7);
        bool success8 = SampleArray.TryGetUInt64(8, out ulong? result8);
        bool success9 = SampleArray.TryGetUInt64(9, out ulong? result9);
        bool success10 = SampleArray.TryGetUInt64(10, out ulong? result10);
        bool success11 = SampleArray.TryGetUInt64(11, out ulong? result11);

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
        Assert.AreEqual(Int64MaxValue, result9, "Index 9");

        Assert.IsTrue(success10);
        Assert.AreEqual(Int64MaxValue, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(null, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetUInt64ByPath() {

        bool success0 = SampleArray.TryGetUInt64ByPath("[0]", out ulong result0);
        bool success1 = SampleArray.TryGetUInt64ByPath("[1]", out ulong result1);
        bool success2 = SampleArray.TryGetUInt64ByPath("[2]", out ulong result2);
        bool success3 = SampleArray.TryGetUInt64ByPath("[3]", out ulong result3);
        bool success4 = SampleArray.TryGetUInt64ByPath("[4]", out ulong result4);
        bool success5 = SampleArray.TryGetUInt64ByPath("[5]", out ulong result5);
        bool success6 = SampleArray.TryGetUInt64ByPath("[6]", out ulong result6);
        bool success7 = SampleArray.TryGetUInt64ByPath("[7]", out ulong result7);
        bool success8 = SampleArray.TryGetUInt64ByPath("[8]", out ulong result8);
        bool success9 = SampleArray.TryGetUInt64ByPath("[9]", out ulong result9);
        bool success10 = SampleArray.TryGetUInt64ByPath("[10]", out ulong result10);
        bool success11 = SampleArray.TryGetUInt64ByPath("[11]", out ulong result11);

        Assert.IsFalse(success0);
        Assert.AreEqual(Zero, result0, "Index 0");

        Assert.IsFalse(success1);
        Assert.AreEqual(Zero, result1, "Index 1");

        Assert.IsTrue(success2);
        Assert.AreEqual(OneTwoThree, result2, "Index 2");

        Assert.IsTrue(success3);
        Assert.AreEqual(OneTwoThree, result3, "Index 3");

        Assert.IsFalse(success4);
        Assert.AreEqual(Zero, result4, "Index 4");

        Assert.IsFalse(success5);
        Assert.AreEqual(Zero, result5, "Index 5");

        Assert.IsFalse(success6);
        Assert.AreEqual(Zero, result6, "Index 6");

        Assert.IsTrue(success7);
        Assert.AreEqual(One, result7, "Index 7");

        Assert.IsTrue(success8);
        Assert.AreEqual(Zero, result8, "Index 8");

        Assert.IsTrue(success9);
        Assert.AreEqual(Int64MaxValue, result9, "Index 9");

        Assert.IsTrue(success10);
        Assert.AreEqual(Int64MaxValue, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(Zero, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetUInt64ByPathOrNull() {

        bool success0 = SampleArray.TryGetUInt64ByPath("[0]", out ulong? result0);
        bool success1 = SampleArray.TryGetUInt64ByPath("[1]", out ulong? result1);
        bool success2 = SampleArray.TryGetUInt64ByPath("[2]", out ulong? result2);
        bool success3 = SampleArray.TryGetUInt64ByPath("[3]", out ulong? result3);
        bool success4 = SampleArray.TryGetUInt64ByPath("[4]", out ulong? result4);
        bool success5 = SampleArray.TryGetUInt64ByPath("[5]", out ulong? result5);
        bool success6 = SampleArray.TryGetUInt64ByPath("[6]", out ulong? result6);
        bool success7 = SampleArray.TryGetUInt64ByPath("[7]", out ulong? result7);
        bool success8 = SampleArray.TryGetUInt64ByPath("[8]", out ulong? result8);
        bool success9 = SampleArray.TryGetUInt64ByPath("[9]", out ulong? result9);
        bool success10 = SampleArray.TryGetUInt64ByPath("[10]", out ulong? result10);
        bool success11 = SampleArray.TryGetUInt64ByPath("[11]", out ulong? result11);

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
        Assert.AreEqual(Int64MaxValue, result9, "Index 9");

        Assert.IsTrue(success10);
        Assert.AreEqual(Int64MaxValue, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(null, result11, "Index 11");

    }

}