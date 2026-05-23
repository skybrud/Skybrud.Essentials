using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace TestProject1.Json.Newtonsoft.Arrays;

[TestClass]
public class ArrayInt32Tests {

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
    public void GetInt32() {
        Assert.AreEqual(0, SampleArray.GetInt32(0), "Index 0");
        Assert.AreEqual(0, SampleArray.GetInt32(1), "Index 1");
        Assert.AreEqual(123, SampleArray.GetInt32(2), "Index 2");
        Assert.AreEqual(123, SampleArray.GetInt32(3), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(0, SampleArray.GetInt32(4), "Index 4");
        Assert.AreEqual(0, SampleArray.GetInt32(5), "Index 5");
        Assert.AreEqual(0, SampleArray.GetInt32(6), "Index 6");
        Assert.AreEqual(1, SampleArray.GetInt32(7), "Index 7");
        Assert.AreEqual(0, SampleArray.GetInt32(8), "Index 8");
        Assert.AreEqual(0, SampleArray.GetInt32(9), "Index 9");
        Assert.AreEqual(0, SampleArray.GetInt32(10), "Index 10");
        Assert.AreEqual(0, SampleArray.GetInt32(11), "Index 11");
    }

    [TestMethod]
    public void GetInt32OrNull() {
        Assert.AreEqual(null, SampleArray.GetInt32OrNull(0), "Index 0");
        Assert.AreEqual(null, SampleArray.GetInt32OrNull(1), "Index 1");
        Assert.AreEqual(123, SampleArray.GetInt32OrNull(2), "Index 2");
        Assert.AreEqual(123, SampleArray.GetInt32OrNull(3), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(null, SampleArray.GetInt32OrNull(4), "Index 4");
        Assert.AreEqual(null, SampleArray.GetInt32OrNull(5), "Index 5");
        Assert.AreEqual(null, SampleArray.GetInt32OrNull(6), "Index 6");
        Assert.AreEqual(1, SampleArray.GetInt32OrNull(7), "Index 7");
        Assert.AreEqual(0, SampleArray.GetInt32OrNull(8), "Index 8");
        Assert.AreEqual(null, SampleArray.GetInt32OrNull(9), "Index 9");
        Assert.AreEqual(null, SampleArray.GetInt32OrNull(10), "Index 10");
        Assert.AreEqual(null, SampleArray.GetInt32OrNull(11), "Index 11");
    }

    [TestMethod]
    public void GetInt32ByPath() {
        Assert.AreEqual(0, SampleArray.GetInt32ByPath("[0]"), "Index 0");
        Assert.AreEqual(0, SampleArray.GetInt32ByPath("[1]"), "Index 1");
        Assert.AreEqual(123, SampleArray.GetInt32ByPath("[2]"), "Index 2");
        Assert.AreEqual(123, SampleArray.GetInt32ByPath("[3]"), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(0, SampleArray.GetInt32ByPath("[4]"), "Index 4");
        Assert.AreEqual(0, SampleArray.GetInt32ByPath("[5]"), "Index 5");
        Assert.AreEqual(0, SampleArray.GetInt32ByPath("[6]"), "Index 6");
        Assert.AreEqual(1, SampleArray.GetInt32ByPath("[7]"), "Index 7");
        Assert.AreEqual(0, SampleArray.GetInt32ByPath("[8]"), "Index 8");
        Assert.AreEqual(0, SampleArray.GetInt32ByPath("[9]"), "Index 9");
        Assert.AreEqual(0, SampleArray.GetInt32ByPath("[10]"), "Index 10");
        Assert.AreEqual(0, SampleArray.GetInt32ByPath("[11]"), "Index 11");
    }

    [TestMethod]
    public void GetInt32ByPathOrNull() {
        Assert.AreEqual(null, SampleArray.GetInt32ByPathOrNull("[0]"), "Index 0");
        Assert.AreEqual(null, SampleArray.GetInt32ByPathOrNull("[1]"), "Index 1");
        Assert.AreEqual(123, SampleArray.GetInt32ByPathOrNull("[2]"), "Index 2");
        Assert.AreEqual(123, SampleArray.GetInt32ByPathOrNull("[3]"), "Index 3"); // TODO: should this be 123 or 0?
        Assert.AreEqual(null, SampleArray.GetInt32ByPathOrNull("[4]"), "Index 4");
        Assert.AreEqual(null, SampleArray.GetInt32ByPathOrNull("[5]"), "Index 5");
        Assert.AreEqual(null, SampleArray.GetInt32ByPathOrNull("[6]"), "Index 6");
        Assert.AreEqual(1, SampleArray.GetInt32ByPathOrNull("[7]"), "Index 7");
        Assert.AreEqual(0, SampleArray.GetInt32ByPathOrNull("[8]"), "Index 8");
        Assert.AreEqual(null, SampleArray.GetInt32ByPathOrNull("[9]"), "Index 9");
        Assert.AreEqual(null, SampleArray.GetInt32ByPathOrNull("[10]"), "Index 10");
        Assert.AreEqual(null, SampleArray.GetInt32ByPathOrNull("[11]"), "Index 11");
    }

    [TestMethod]
    public void TryGetInt32() {

        bool success0 = SampleArray.TryGetInt32(0, out int result0);
        bool success1 = SampleArray.TryGetInt32(1, out int result1);
        bool success2 = SampleArray.TryGetInt32(2, out int result2);
        bool success3 = SampleArray.TryGetInt32(3, out int result3);
        bool success4 = SampleArray.TryGetInt32(4, out int result4);
        bool success5 = SampleArray.TryGetInt32(5, out int result5);
        bool success6 = SampleArray.TryGetInt32(6, out int result6);
        bool success7 = SampleArray.TryGetInt32(7, out int result7);
        bool success8 = SampleArray.TryGetInt32(8, out int result8);
        bool success9 = SampleArray.TryGetInt32(9, out int result9);
        bool success10 = SampleArray.TryGetInt32(10, out int result10);
        bool success11 = SampleArray.TryGetInt32(11, out int result11);

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
    public void TryGetInt32OrNull() {

        bool success0 = SampleArray.TryGetInt32(0, out int? result0);
        bool success1 = SampleArray.TryGetInt32(1, out int? result1);
        bool success2 = SampleArray.TryGetInt32(2, out int? result2);
        bool success3 = SampleArray.TryGetInt32(3, out int? result3);
        bool success4 = SampleArray.TryGetInt32(4, out int? result4);
        bool success5 = SampleArray.TryGetInt32(5, out int? result5);
        bool success6 = SampleArray.TryGetInt32(6, out int? result6);
        bool success7 = SampleArray.TryGetInt32(7, out int? result7);
        bool success8 = SampleArray.TryGetInt32(8, out int? result8);
        bool success9 = SampleArray.TryGetInt32(9, out int? result9);
        bool success10 = SampleArray.TryGetInt32(10, out int? result10);
        bool success11 = SampleArray.TryGetInt32(11, out int? result11);

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
    public void TryGetInt32ByPath() {

        bool success0 = SampleArray.TryGetInt32ByPath("[0]", out int result0);
        bool success1 = SampleArray.TryGetInt32ByPath("[1]", out int result1);
        bool success2 = SampleArray.TryGetInt32ByPath("[2]", out int result2);
        bool success3 = SampleArray.TryGetInt32ByPath("[3]", out int result3);
        bool success4 = SampleArray.TryGetInt32ByPath("[4]", out int result4);
        bool success5 = SampleArray.TryGetInt32ByPath("[5]", out int result5);
        bool success6 = SampleArray.TryGetInt32ByPath("[6]", out int result6);
        bool success7 = SampleArray.TryGetInt32ByPath("[7]", out int result7);
        bool success8 = SampleArray.TryGetInt32ByPath("[8]", out int result8);
        bool success9 = SampleArray.TryGetInt32ByPath("[9]", out int result9);
        bool success10 = SampleArray.TryGetInt32ByPath("[10]", out int result10);
        bool success11 = SampleArray.TryGetInt32ByPath("[11]", out int result11);

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
    public void TryGetInt32ByPathOrNull() {

        bool success0 = SampleArray.TryGetInt32ByPath("[0]", out int? result0);
        bool success1 = SampleArray.TryGetInt32ByPath("[1]", out int? result1);
        bool success2 = SampleArray.TryGetInt32ByPath("[2]", out int? result2);
        bool success3 = SampleArray.TryGetInt32ByPath("[3]", out int? result3);
        bool success4 = SampleArray.TryGetInt32ByPath("[4]", out int? result4);
        bool success5 = SampleArray.TryGetInt32ByPath("[5]", out int? result5);
        bool success6 = SampleArray.TryGetInt32ByPath("[6]", out int? result6);
        bool success7 = SampleArray.TryGetInt32ByPath("[7]", out int? result7);
        bool success8 = SampleArray.TryGetInt32ByPath("[8]", out int? result8);
        bool success9 = SampleArray.TryGetInt32ByPath("[9]", out int? result9);
        bool success10 = SampleArray.TryGetInt32ByPath("[10]", out int? result10);
        bool success11 = SampleArray.TryGetInt32ByPath("[11]", out int? result11);

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