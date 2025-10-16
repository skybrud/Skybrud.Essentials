using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace TestProject1.Json.Newtonsoft.Arrays;

[TestClass]
public class ArrayUInt32Tests {

    protected const uint Zero = 0;

    protected const uint One = 1;

    protected const uint OneTwoThree = 123;

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
    public void GetUInt32() {
        Assert.AreEqual(Zero, SampleArray.GetUInt32(0), "Index 0");
        Assert.AreEqual(Zero, SampleArray.GetUInt32(1), "Index 1");
        Assert.AreEqual(OneTwoThree, SampleArray.GetUInt32(2), "Index 2");
        Assert.AreEqual(OneTwoThree, SampleArray.GetUInt32(3), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(Zero, SampleArray.GetUInt32(4), "Index 4");
        Assert.AreEqual(Zero, SampleArray.GetUInt32(5), "Index 5");
        Assert.AreEqual(Zero, SampleArray.GetUInt32(6), "Index 6");
        Assert.AreEqual(One, SampleArray.GetUInt32(7), "Index 7");
        Assert.AreEqual(Zero, SampleArray.GetUInt32(8), "Index 8");
        Assert.AreEqual(Zero, SampleArray.GetUInt32(9), "Index 9");
        Assert.AreEqual(Zero, SampleArray.GetUInt32(10), "Index 10");
        Assert.AreEqual(Zero, SampleArray.GetUInt32(11), "Index 11");
    }

    [TestMethod]
    public void GetUInt32OrNull() {
        Assert.AreEqual(null, SampleArray.GetUInt32OrNull(0), "Index 0");
        Assert.AreEqual(null, SampleArray.GetUInt32OrNull(1), "Index 1");
        Assert.AreEqual(OneTwoThree, SampleArray.GetUInt32OrNull(2), "Index 2");
        Assert.AreEqual(OneTwoThree, SampleArray.GetUInt32OrNull(3), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(null, SampleArray.GetUInt32OrNull(4), "Index 4");
        Assert.AreEqual(null, SampleArray.GetUInt32OrNull(5), "Index 5");
        Assert.AreEqual(null, SampleArray.GetUInt32OrNull(6), "Index 6");
        Assert.AreEqual(One, SampleArray.GetUInt32OrNull(7), "Index 7");
        Assert.AreEqual(Zero, SampleArray.GetUInt32OrNull(8), "Index 8");
        Assert.AreEqual(null, SampleArray.GetUInt32OrNull(9), "Index 9");
        Assert.AreEqual(null, SampleArray.GetUInt32OrNull(10), "Index 10");
        Assert.AreEqual(null, SampleArray.GetUInt32OrNull(11), "Index 11");
    }

    [TestMethod]
    public void GetUInt32ByPath() {
        Assert.AreEqual(Zero, SampleArray.GetUInt32ByPath("[0]"), "Index 0");
        Assert.AreEqual(Zero, SampleArray.GetUInt32ByPath("[1]"), "Index 1");
        Assert.AreEqual(OneTwoThree, SampleArray.GetUInt32ByPath("[2]"), "Index 2");
        Assert.AreEqual(OneTwoThree, SampleArray.GetUInt32ByPath("[3]"), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(Zero, SampleArray.GetUInt32ByPath("[4]"), "Index 4");
        Assert.AreEqual(Zero, SampleArray.GetUInt32ByPath("[5]"), "Index 5");
        Assert.AreEqual(Zero, SampleArray.GetUInt32ByPath("[6]"), "Index 6");
        Assert.AreEqual(One, SampleArray.GetUInt32ByPath("[7]"), "Index 7");
        Assert.AreEqual(Zero, SampleArray.GetUInt32ByPath("[8]"), "Index 8");
        Assert.AreEqual(Zero, SampleArray.GetUInt32ByPath("[9]"), "Index 9");
        Assert.AreEqual(Zero, SampleArray.GetUInt32ByPath("[10]"), "Index 10");
        Assert.AreEqual(Zero, SampleArray.GetUInt32ByPath("[11]"), "Index 11");
    }

    [TestMethod]
    public void GetUInt32ByPathOrNull() {
        Assert.AreEqual(null, SampleArray.GetUInt32ByPathOrNull("[0]"), "Index 0");
        Assert.AreEqual(null, SampleArray.GetUInt32ByPathOrNull("[1]"), "Index 1");
        Assert.AreEqual(OneTwoThree, SampleArray.GetUInt32ByPathOrNull("[2]"), "Index 2");
        Assert.AreEqual(OneTwoThree, SampleArray.GetUInt32ByPathOrNull("[3]"), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(null, SampleArray.GetUInt32ByPathOrNull("[4]"), "Index 4");
        Assert.AreEqual(null, SampleArray.GetUInt32ByPathOrNull("[5]"), "Index 5");
        Assert.AreEqual(null, SampleArray.GetUInt32ByPathOrNull("[6]"), "Index 6");
        Assert.AreEqual(One, SampleArray.GetUInt32ByPathOrNull("[7]"), "Index 7");
        Assert.AreEqual(Zero, SampleArray.GetUInt32ByPathOrNull("[8]"), "Index 8");
        Assert.AreEqual(null, SampleArray.GetUInt32ByPathOrNull("[9]"), "Index 9");
        Assert.AreEqual(null, SampleArray.GetUInt32ByPathOrNull("[10]"), "Index 10");
        Assert.AreEqual(null, SampleArray.GetUInt32ByPathOrNull("[11]"), "Index 11");
    }

    [TestMethod]
    public void TryGetUInt32() {

        bool success0 = SampleArray.TryGetUInt32(0, out uint result0);
        bool success1 = SampleArray.TryGetUInt32(1, out uint result1);
        bool success2 = SampleArray.TryGetUInt32(2, out uint result2);
        bool success3 = SampleArray.TryGetUInt32(3, out uint result3);
        bool success4 = SampleArray.TryGetUInt32(4, out uint result4);
        bool success5 = SampleArray.TryGetUInt32(5, out uint result5);
        bool success6 = SampleArray.TryGetUInt32(6, out uint result6);
        bool success7 = SampleArray.TryGetUInt32(7, out uint result7);
        bool success8 = SampleArray.TryGetUInt32(8, out uint result8);
        bool success9 = SampleArray.TryGetUInt32(9, out uint result9);
        bool success10 = SampleArray.TryGetUInt32(10, out uint result10);
        bool success11 = SampleArray.TryGetUInt32(11, out uint result11);

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

        Assert.IsFalse(success9);
        Assert.AreEqual(Zero, result9, "Index 9");

        Assert.IsFalse(success10);
        Assert.AreEqual(Zero, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(Zero, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetUInt32OrNull() {

        bool success0 = SampleArray.TryGetUInt32(0, out uint? result0);
        bool success1 = SampleArray.TryGetUInt32(1, out uint? result1);
        bool success2 = SampleArray.TryGetUInt32(2, out uint? result2);
        bool success3 = SampleArray.TryGetUInt32(3, out uint? result3);
        bool success4 = SampleArray.TryGetUInt32(4, out uint? result4);
        bool success5 = SampleArray.TryGetUInt32(5, out uint? result5);
        bool success6 = SampleArray.TryGetUInt32(6, out uint? result6);
        bool success7 = SampleArray.TryGetUInt32(7, out uint? result7);
        bool success8 = SampleArray.TryGetUInt32(8, out uint? result8);
        bool success9 = SampleArray.TryGetUInt32(9, out uint? result9);
        bool success10 = SampleArray.TryGetUInt32(10, out uint? result10);
        bool success11 = SampleArray.TryGetUInt32(11, out uint? result11);

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

        Assert.IsFalse(success9);
        Assert.AreEqual(null, result9, "Index 9");

        Assert.IsFalse(success10);
        Assert.AreEqual(null, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(null, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetUInt32ByPath() {

        bool success0 = SampleArray.TryGetUInt32ByPath("[0]", out uint result0);
        bool success1 = SampleArray.TryGetUInt32ByPath("[1]", out uint result1);
        bool success2 = SampleArray.TryGetUInt32ByPath("[2]", out uint result2);
        bool success3 = SampleArray.TryGetUInt32ByPath("[3]", out uint result3);
        bool success4 = SampleArray.TryGetUInt32ByPath("[4]", out uint result4);
        bool success5 = SampleArray.TryGetUInt32ByPath("[5]", out uint result5);
        bool success6 = SampleArray.TryGetUInt32ByPath("[6]", out uint result6);
        bool success7 = SampleArray.TryGetUInt32ByPath("[7]", out uint result7);
        bool success8 = SampleArray.TryGetUInt32ByPath("[8]", out uint result8);
        bool success9 = SampleArray.TryGetUInt32ByPath("[9]", out uint result9);
        bool success10 = SampleArray.TryGetUInt32ByPath("[10]", out uint result10);
        bool success11 = SampleArray.TryGetUInt32ByPath("[11]", out uint result11);

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

        Assert.IsFalse(success9);
        Assert.AreEqual(Zero, result9, "Index 9");

        Assert.IsFalse(success10);
        Assert.AreEqual(Zero, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(Zero, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetUInt32ByPathOrNull() {

        bool success0 = SampleArray.TryGetUInt32ByPath("[0]", out uint? result0);
        bool success1 = SampleArray.TryGetUInt32ByPath("[1]", out uint? result1);
        bool success2 = SampleArray.TryGetUInt32ByPath("[2]", out uint? result2);
        bool success3 = SampleArray.TryGetUInt32ByPath("[3]", out uint? result3);
        bool success4 = SampleArray.TryGetUInt32ByPath("[4]", out uint? result4);
        bool success5 = SampleArray.TryGetUInt32ByPath("[5]", out uint? result5);
        bool success6 = SampleArray.TryGetUInt32ByPath("[6]", out uint? result6);
        bool success7 = SampleArray.TryGetUInt32ByPath("[7]", out uint? result7);
        bool success8 = SampleArray.TryGetUInt32ByPath("[8]", out uint? result8);
        bool success9 = SampleArray.TryGetUInt32ByPath("[9]", out uint? result9);
        bool success10 = SampleArray.TryGetUInt32ByPath("[10]", out uint? result10);
        bool success11 = SampleArray.TryGetUInt32ByPath("[11]", out uint? result11);

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

        Assert.IsFalse(success9);
        Assert.AreEqual(null, result9, "Index 9");

        Assert.IsFalse(success10);
        Assert.AreEqual(null, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(null, result11, "Index 11");

    }

}