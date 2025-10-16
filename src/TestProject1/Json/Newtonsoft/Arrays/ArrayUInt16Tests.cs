using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace TestProject1.Json.Newtonsoft.Arrays;

[TestClass]
public class ArrayUInt16Tests {

    protected const ushort Zero = 0;

    protected const ushort One = 1;

    protected const ushort OneTwoThree = 123;

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
    public void GetUInt16() {
        Assert.AreEqual(0, SampleArray.GetUInt16(0), "Index 0");
        Assert.AreEqual(0, SampleArray.GetUInt16(1), "Index 1");
        Assert.AreEqual(123, SampleArray.GetUInt16(2), "Index 2");
        Assert.AreEqual(123, SampleArray.GetUInt16(3), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(0, SampleArray.GetUInt16(4), "Index 4");
        Assert.AreEqual(0, SampleArray.GetUInt16(5), "Index 5");
        Assert.AreEqual(0, SampleArray.GetUInt16(6), "Index 6");
        Assert.AreEqual(1, SampleArray.GetUInt16(7), "Index 7");
        Assert.AreEqual(0, SampleArray.GetUInt16(8), "Index 8");
        Assert.AreEqual(0, SampleArray.GetUInt16(9), "Index 9");
        Assert.AreEqual(0, SampleArray.GetUInt16(10), "Index 10");
        Assert.AreEqual(0, SampleArray.GetUInt16(11), "Index 11");
    }

    [TestMethod]
    public void GetUInt16OrNull() {
        Assert.AreEqual(null, SampleArray.GetUInt16OrNull(0), "Index 0");
        Assert.AreEqual(null, SampleArray.GetUInt16OrNull(1), "Index 1");
        Assert.AreEqual((ushort) 123, SampleArray.GetUInt16OrNull(2), "Index 2");
        Assert.AreEqual((ushort) 123, SampleArray.GetUInt16OrNull(3), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(null, SampleArray.GetUInt16OrNull(4), "Index 4");
        Assert.AreEqual(null, SampleArray.GetUInt16OrNull(5), "Index 5");
        Assert.AreEqual(null, SampleArray.GetUInt16OrNull(6), "Index 6");
        Assert.AreEqual((ushort) 1, SampleArray.GetUInt16OrNull(7), "Index 7");
        Assert.AreEqual((ushort) 0, SampleArray.GetUInt16OrNull(8), "Index 8");
        Assert.AreEqual(null, SampleArray.GetUInt16OrNull(9), "Index 9");
        Assert.AreEqual(null, SampleArray.GetUInt16OrNull(10), "Index 10");
        Assert.AreEqual(null, SampleArray.GetUInt16OrNull(11), "Index 11");
    }

    [TestMethod]
    public void GetUInt16ByPath() {
        Assert.AreEqual(0, SampleArray.GetUInt16ByPath("[0]"), "Index 0");
        Assert.AreEqual(0, SampleArray.GetUInt16ByPath("[1]"), "Index 1");
        Assert.AreEqual(123, SampleArray.GetUInt16ByPath("[2]"), "Index 2");
        Assert.AreEqual(123, SampleArray.GetUInt16ByPath("[3]"), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(0, SampleArray.GetUInt16ByPath("[4]"), "Index 4");
        Assert.AreEqual(0, SampleArray.GetUInt16ByPath("[5]"), "Index 5");
        Assert.AreEqual(0, SampleArray.GetUInt16ByPath("[6]"), "Index 6");
        Assert.AreEqual(1, SampleArray.GetUInt16ByPath("[7]"), "Index 7");
        Assert.AreEqual(0, SampleArray.GetUInt16ByPath("[8]"), "Index 8");
        Assert.AreEqual(0, SampleArray.GetUInt16ByPath("[9]"), "Index 9");
        Assert.AreEqual(0, SampleArray.GetUInt16ByPath("[10]"), "Index 10");
        Assert.AreEqual(0, SampleArray.GetUInt16ByPath("[11]"), "Index 11");
    }

    [TestMethod]
    public void GetUInt16ByPathOrNull() {
        Assert.AreEqual(null, SampleArray.GetUInt16ByPathOrNull("[0]"), "Index 0");
        Assert.AreEqual(null, SampleArray.GetUInt16ByPathOrNull("[1]"), "Index 1");
        Assert.AreEqual((ushort) 123, SampleArray.GetUInt16ByPathOrNull("[2]"), "Index 2");
        Assert.AreEqual((ushort) 123, SampleArray.GetUInt16ByPathOrNull("[3]"), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(null, SampleArray.GetUInt16ByPathOrNull("[4]"), "Index 4");
        Assert.AreEqual(null, SampleArray.GetUInt16ByPathOrNull("[5]"), "Index 5");
        Assert.AreEqual(null, SampleArray.GetUInt16ByPathOrNull("[6]"), "Index 6");
        Assert.AreEqual((ushort) 1, SampleArray.GetUInt16ByPathOrNull("[7]"), "Index 7");
        Assert.AreEqual((ushort) 0, SampleArray.GetUInt16ByPathOrNull("[8]"), "Index 8");
        Assert.AreEqual(null, SampleArray.GetUInt16ByPathOrNull("[9]"), "Index 9");
        Assert.AreEqual(null, SampleArray.GetUInt16ByPathOrNull("[10]"), "Index 10");
        Assert.AreEqual(null, SampleArray.GetUInt16ByPathOrNull("[11]"), "Index 11");
    }

    [TestMethod]
    public void TryGetUInt16() {

        bool success0 = SampleArray.TryGetUInt16(0, out ushort result0);
        bool success1 = SampleArray.TryGetUInt16(1, out ushort result1);
        bool success2 = SampleArray.TryGetUInt16(2, out ushort result2);
        bool success3 = SampleArray.TryGetUInt16(3, out ushort result3);
        bool success4 = SampleArray.TryGetUInt16(4, out ushort result4);
        bool success5 = SampleArray.TryGetUInt16(5, out ushort result5);
        bool success6 = SampleArray.TryGetUInt16(6, out ushort result6);
        bool success7 = SampleArray.TryGetUInt16(7, out ushort result7);
        bool success8 = SampleArray.TryGetUInt16(8, out ushort result8);
        bool success9 = SampleArray.TryGetUInt16(9, out ushort result9);
        bool success10 = SampleArray.TryGetUInt16(10, out ushort result10);
        bool success11 = SampleArray.TryGetUInt16(11, out ushort result11);

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

        Assert.IsFalse(success9);
        Assert.AreEqual(0, result9, "Index 9");

        Assert.IsFalse(success10);
        Assert.AreEqual(0, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(0, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetUInt16OrNull() {

        bool success0 = SampleArray.TryGetUInt16(0, out ushort? result0);
        bool success1 = SampleArray.TryGetUInt16(1, out ushort? result1);
        bool success2 = SampleArray.TryGetUInt16(2, out ushort? result2);
        bool success3 = SampleArray.TryGetUInt16(3, out ushort? result3);
        bool success4 = SampleArray.TryGetUInt16(4, out ushort? result4);
        bool success5 = SampleArray.TryGetUInt16(5, out ushort? result5);
        bool success6 = SampleArray.TryGetUInt16(6, out ushort? result6);
        bool success7 = SampleArray.TryGetUInt16(7, out ushort? result7);
        bool success8 = SampleArray.TryGetUInt16(8, out ushort? result8);
        bool success9 = SampleArray.TryGetUInt16(9, out ushort? result9);
        bool success10 = SampleArray.TryGetUInt16(10, out ushort? result10);
        bool success11 = SampleArray.TryGetUInt16(11, out ushort? result11);

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
    public void TryGetUInt16ByPath() {

        bool success0 = SampleArray.TryGetUInt16ByPath("[0]", out ushort result0);
        bool success1 = SampleArray.TryGetUInt16ByPath("[1]", out ushort result1);
        bool success2 = SampleArray.TryGetUInt16ByPath("[2]", out ushort result2);
        bool success3 = SampleArray.TryGetUInt16ByPath("[3]", out ushort result3);
        bool success4 = SampleArray.TryGetUInt16ByPath("[4]", out ushort result4);
        bool success5 = SampleArray.TryGetUInt16ByPath("[5]", out ushort result5);
        bool success6 = SampleArray.TryGetUInt16ByPath("[6]", out ushort result6);
        bool success7 = SampleArray.TryGetUInt16ByPath("[7]", out ushort result7);
        bool success8 = SampleArray.TryGetUInt16ByPath("[8]", out ushort result8);
        bool success9 = SampleArray.TryGetUInt16ByPath("[9]", out ushort result9);
        bool success10 = SampleArray.TryGetUInt16ByPath("[10]", out ushort result10);
        bool success11 = SampleArray.TryGetUInt16ByPath("[11]", out ushort result11);

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

        Assert.IsFalse(success9);
        Assert.AreEqual(0, result9, "Index 9");

        Assert.IsFalse(success10);
        Assert.AreEqual(0, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(0, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetUInt16ByPathOrNull() {

        bool success0 = SampleArray.TryGetUInt16ByPath("[0]", out ushort? result0);
        bool success1 = SampleArray.TryGetUInt16ByPath("[1]", out ushort? result1);
        bool success2 = SampleArray.TryGetUInt16ByPath("[2]", out ushort? result2);
        bool success3 = SampleArray.TryGetUInt16ByPath("[3]", out ushort? result3);
        bool success4 = SampleArray.TryGetUInt16ByPath("[4]", out ushort? result4);
        bool success5 = SampleArray.TryGetUInt16ByPath("[5]", out ushort? result5);
        bool success6 = SampleArray.TryGetUInt16ByPath("[6]", out ushort? result6);
        bool success7 = SampleArray.TryGetUInt16ByPath("[7]", out ushort? result7);
        bool success8 = SampleArray.TryGetUInt16ByPath("[8]", out ushort? result8);
        bool success9 = SampleArray.TryGetUInt16ByPath("[9]", out ushort? result9);
        bool success10 = SampleArray.TryGetUInt16ByPath("[10]", out ushort? result10);
        bool success11 = SampleArray.TryGetUInt16ByPath("[11]", out ushort? result11);

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