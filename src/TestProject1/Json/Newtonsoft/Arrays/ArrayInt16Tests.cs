using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace TestProject1.Json.Newtonsoft.Arrays;

[TestClass]
public class ArrayInt16Tests {

    protected const short Zero = 0;

    protected const short One = 1;

    protected const short OneTwoThree = 123;

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
    public void GetInt16() {
        Assert.AreEqual(0, SampleArray.GetInt16(0), "Index 0");
        Assert.AreEqual(0, SampleArray.GetInt16(1), "Index 1");
        Assert.AreEqual(123, SampleArray.GetInt16(2), "Index 2");
        Assert.AreEqual(123, SampleArray.GetInt16(3), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(0, SampleArray.GetInt16(4), "Index 4");
        Assert.AreEqual(0, SampleArray.GetInt16(5), "Index 5");
        Assert.AreEqual(0, SampleArray.GetInt16(6), "Index 6");
        Assert.AreEqual(1, SampleArray.GetInt16(7), "Index 7");
        Assert.AreEqual(0, SampleArray.GetInt16(8), "Index 8");
        Assert.AreEqual(0, SampleArray.GetInt16(9), "Index 9");
        Assert.AreEqual(0, SampleArray.GetInt16(10), "Index 10");
        Assert.AreEqual(0, SampleArray.GetInt16(11), "Index 11");
    }

    [TestMethod]
    public void GetInt16OrNull() {
        Assert.AreEqual(null, SampleArray.GetInt16OrNull(0), "Index 0");
        Assert.AreEqual(null, SampleArray.GetInt16OrNull(1), "Index 1");
        Assert.AreEqual((short) 123, SampleArray.GetInt16OrNull(2), "Index 2");
        Assert.AreEqual((short) 123, SampleArray.GetInt16OrNull(3), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(null, SampleArray.GetInt16OrNull(4), "Index 4");
        Assert.AreEqual(null, SampleArray.GetInt16OrNull(5), "Index 5");
        Assert.AreEqual(null, SampleArray.GetInt16OrNull(6), "Index 6");
        Assert.AreEqual((short) 1, SampleArray.GetInt16OrNull(7), "Index 7");
        Assert.AreEqual((short) 0, SampleArray.GetInt16OrNull(8), "Index 8");
        Assert.AreEqual(null, SampleArray.GetInt16OrNull(9), "Index 9");
        Assert.AreEqual(null, SampleArray.GetInt16OrNull(10), "Index 10");
        Assert.AreEqual(null, SampleArray.GetInt16OrNull(11), "Index 11");
    }

    [TestMethod]
    public void GetInt16ByPath() {
        Assert.AreEqual(0, SampleArray.GetInt16ByPath("[0]"), "Index 0");
        Assert.AreEqual(0, SampleArray.GetInt16ByPath("[1]"), "Index 1");
        Assert.AreEqual(123, SampleArray.GetInt16ByPath("[2]"), "Index 2");
        Assert.AreEqual(123, SampleArray.GetInt16ByPath("[3]"), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(0, SampleArray.GetInt16ByPath("[4]"), "Index 4");
        Assert.AreEqual(0, SampleArray.GetInt16ByPath("[5]"), "Index 5");
        Assert.AreEqual(0, SampleArray.GetInt16ByPath("[6]"), "Index 6");
        Assert.AreEqual(1, SampleArray.GetInt16ByPath("[7]"), "Index 7");
        Assert.AreEqual(0, SampleArray.GetInt16ByPath("[8]"), "Index 8");
        Assert.AreEqual(0, SampleArray.GetInt16ByPath("[9]"), "Index 9");
        Assert.AreEqual(0, SampleArray.GetInt16ByPath("[10]"), "Index 10");
        Assert.AreEqual(0, SampleArray.GetInt16ByPath("[11]"), "Index 11");
    }

    [TestMethod]
    public void GetInt16ByPathOrNull() {
        Assert.AreEqual(null, SampleArray.GetInt16ByPathOrNull("[0]"), "Index 0");
        Assert.AreEqual(null, SampleArray.GetInt16ByPathOrNull("[1]"), "Index 1");
        Assert.AreEqual((short) 123, SampleArray.GetInt16ByPathOrNull("[2]"), "Index 2");
        Assert.AreEqual((short) 123, SampleArray.GetInt16ByPathOrNull("[3]"), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(null, SampleArray.GetInt16ByPathOrNull("[4]"), "Index 4");
        Assert.AreEqual(null, SampleArray.GetInt16ByPathOrNull("[5]"), "Index 5");
        Assert.AreEqual(null, SampleArray.GetInt16ByPathOrNull("[6]"), "Index 6");
        Assert.AreEqual((short) 1, SampleArray.GetInt16ByPathOrNull("[7]"), "Index 7");
        Assert.AreEqual((short) 0, SampleArray.GetInt16ByPathOrNull("[8]"), "Index 8");
        Assert.AreEqual(null, SampleArray.GetInt16ByPathOrNull("[9]"), "Index 9");
        Assert.AreEqual(null, SampleArray.GetInt16ByPathOrNull("[10]"), "Index 10");
        Assert.AreEqual(null, SampleArray.GetInt16ByPathOrNull("[11]"), "Index 11");
    }

    [TestMethod]
    public void TryGetInt16() {

        bool success0 = SampleArray.TryGetInt16(0, out short result0);
        bool success1 = SampleArray.TryGetInt16(1, out short result1);
        bool success2 = SampleArray.TryGetInt16(2, out short result2);
        bool success3 = SampleArray.TryGetInt16(3, out short result3);
        bool success4 = SampleArray.TryGetInt16(4, out short result4);
        bool success5 = SampleArray.TryGetInt16(5, out short result5);
        bool success6 = SampleArray.TryGetInt16(6, out short result6);
        bool success7 = SampleArray.TryGetInt16(7, out short result7);
        bool success8 = SampleArray.TryGetInt16(8, out short result8);
        bool success9 = SampleArray.TryGetInt16(9, out short result9);
        bool success10 = SampleArray.TryGetInt16(10, out short result10);
        bool success11 = SampleArray.TryGetInt16(11, out short result11);

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
    public void TryGetInt16OrNull() {

        bool success0 = SampleArray.TryGetInt16(0, out short? result0);
        bool success1 = SampleArray.TryGetInt16(1, out short? result1);
        bool success2 = SampleArray.TryGetInt16(2, out short? result2);
        bool success3 = SampleArray.TryGetInt16(3, out short? result3);
        bool success4 = SampleArray.TryGetInt16(4, out short? result4);
        bool success5 = SampleArray.TryGetInt16(5, out short? result5);
        bool success6 = SampleArray.TryGetInt16(6, out short? result6);
        bool success7 = SampleArray.TryGetInt16(7, out short? result7);
        bool success8 = SampleArray.TryGetInt16(8, out short? result8);
        bool success9 = SampleArray.TryGetInt16(9, out short? result9);
        bool success10 = SampleArray.TryGetInt16(10, out short? result10);
        bool success11 = SampleArray.TryGetInt16(11, out short? result11);

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
    public void TryGetInt16ByPath() {

        bool success0 = SampleArray.TryGetInt16ByPath("[0]", out short result0);
        bool success1 = SampleArray.TryGetInt16ByPath("[1]", out short result1);
        bool success2 = SampleArray.TryGetInt16ByPath("[2]", out short result2);
        bool success3 = SampleArray.TryGetInt16ByPath("[3]", out short result3);
        bool success4 = SampleArray.TryGetInt16ByPath("[4]", out short result4);
        bool success5 = SampleArray.TryGetInt16ByPath("[5]", out short result5);
        bool success6 = SampleArray.TryGetInt16ByPath("[6]", out short result6);
        bool success7 = SampleArray.TryGetInt16ByPath("[7]", out short result7);
        bool success8 = SampleArray.TryGetInt16ByPath("[8]", out short result8);
        bool success9 = SampleArray.TryGetInt16ByPath("[9]", out short result9);
        bool success10 = SampleArray.TryGetInt16ByPath("[10]", out short result10);
        bool success11 = SampleArray.TryGetInt16ByPath("[11]", out short result11);

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
    public void TryGetInt16ByPathOrNull() {

        bool success0 = SampleArray.TryGetInt16ByPath("[0]", out short? result0);
        bool success1 = SampleArray.TryGetInt16ByPath("[1]", out short? result1);
        bool success2 = SampleArray.TryGetInt16ByPath("[2]", out short? result2);
        bool success3 = SampleArray.TryGetInt16ByPath("[3]", out short? result3);
        bool success4 = SampleArray.TryGetInt16ByPath("[4]", out short? result4);
        bool success5 = SampleArray.TryGetInt16ByPath("[5]", out short? result5);
        bool success6 = SampleArray.TryGetInt16ByPath("[6]", out short? result6);
        bool success7 = SampleArray.TryGetInt16ByPath("[7]", out short? result7);
        bool success8 = SampleArray.TryGetInt16ByPath("[8]", out short? result8);
        bool success9 = SampleArray.TryGetInt16ByPath("[9]", out short? result9);
        bool success10 = SampleArray.TryGetInt16ByPath("[10]", out short? result10);
        bool success11 = SampleArray.TryGetInt16ByPath("[11]", out short? result11);

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