using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Strings.Extensions;

namespace TestProject1.Json.Newtonsoft.Arrays;

[TestClass]
public class ArrayFloatTests {

    protected const float Zero = 0;

    protected static readonly JArray SampleArray = new(new object[13]) {
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
        [10] = "9223372036854775808", // long.MaxValue + 1,
        [11] = double.MaxValue,
        [12] = "1797693134862315708145274237317043567980705675258449965989174768031572607800285387605895586327668781715404589535143824642343213268894641827684675467035375169860499105765512820762454900903893289440758685084551339423045832369032229481658085593321233482747978262041447231687381771809192998812504040261841248583680" // greater than double.MaxValue
    };


    [TestMethod]
    public void GetFloat() {
        Assert.AreEqual(0, SampleArray.GetFloat(0), "Index 0");
        Assert.AreEqual(0, SampleArray.GetFloat(1), "Index 1");
        Assert.AreEqual(123, SampleArray.GetFloat(2), "Index 2");
        Assert.AreEqual("123.456", SampleArray.GetFloat(3).ToInvariantString("F3"), "Index 3");
        Assert.AreEqual(0, SampleArray.GetFloat(4), "Index 4");
        Assert.AreEqual(0, SampleArray.GetFloat(5), "Index 5");
        Assert.AreEqual(0, SampleArray.GetFloat(6), "Index 6");
        Assert.AreEqual(1, SampleArray.GetFloat(7), "Index 7");
        Assert.AreEqual(0, SampleArray.GetFloat(8), "Index 8");
        Assert.AreEqual("9223372036854775808", SampleArray.GetFloat(9).ToInvariantString("F0"), "Index 9"); // Not sure why this comes back as 9223372036854775808 and not 9223372036854775807 (floats are a bit weird, so leaving this for now, considering it an edge case)
        Assert.AreEqual("9223372036854775808", SampleArray.GetFloat(10).ToInvariantString("F0"), "Index 10");
        Assert.AreEqual(0, SampleArray.GetFloat(11), "Index 11");
        Assert.AreEqual(0, SampleArray.GetFloat(12), "Index 12");
        Assert.AreEqual(0, SampleArray.GetFloat(13), "Index 13");
    }

    [TestMethod]
    public void GetFloatOrNull() {
        Assert.AreEqual(null, SampleArray.GetFloatOrNull(0), "Index 0");
        Assert.AreEqual(null, SampleArray.GetFloatOrNull(1), "Index 1");
        Assert.AreEqual(123, SampleArray.GetFloatOrNull(2), "Index 2");
        Assert.AreEqual("123.456", SampleArray.GetFloatOrNull(3).ToInvariantString("F3"), "Index 3");
        Assert.AreEqual(null, SampleArray.GetFloatOrNull(4), "Index 4");
        Assert.AreEqual(null, SampleArray.GetFloatOrNull(5), "Index 5");
        Assert.AreEqual(null, SampleArray.GetFloatOrNull(6), "Index 6");
        Assert.AreEqual(1, SampleArray.GetFloatOrNull(7), "Index 7");
        Assert.AreEqual(0, SampleArray.GetFloatOrNull(8), "Index 8");
        Assert.AreEqual("9223372036854775808", SampleArray.GetFloat(9).ToInvariantString("F0"), "Index 9"); // Not sure why this comes back as 9223372036854775808 and not 9223372036854775807 (floats are a bit weird, so leaving this for now, considering it an edge case)
        Assert.AreEqual("9223372036854775808", SampleArray.GetFloat(10).ToInvariantString("F0"), "Index 10");
        Assert.AreEqual(null, SampleArray.GetFloatOrNull(11), "Index 11");
        Assert.AreEqual(null, SampleArray.GetFloatOrNull(12), "Index 12");
        Assert.AreEqual(null, SampleArray.GetFloatOrNull(13), "Index 13");
    }

    [TestMethod]
    public void GetFloatByPath() {
        Assert.AreEqual(0, SampleArray.GetFloatByPath("[0]"), "Index 0");
        Assert.AreEqual(0, SampleArray.GetFloatByPath("[1]"), "Index 1");
        Assert.AreEqual(123, SampleArray.GetFloatByPath("[2]"), "Index 2");
        Assert.AreEqual("123.456", SampleArray.GetFloatByPath("[3]").ToInvariantString("F3"), "Index 3");
        Assert.AreEqual(0, SampleArray.GetFloatByPath("[4]"), "Index 4");
        Assert.AreEqual(0, SampleArray.GetFloatByPath("[5]"), "Index 5");
        Assert.AreEqual(0, SampleArray.GetFloatByPath("[6]"), "Index 6");
        Assert.AreEqual(1, SampleArray.GetFloatByPath("[7]"), "Index 7");
        Assert.AreEqual(0, SampleArray.GetFloatByPath("[8]"), "Index 8");
        Assert.AreEqual("9223372036854775808", SampleArray.GetFloatByPath("[9]").ToInvariantString("F0"), "Index 9"); // Not sure why this comes back as 9223372036854775808 and not 9223372036854775807 (floats are a bit weird, so leaving this for now, considering it an edge case)
        Assert.AreEqual("9223372036854775808", SampleArray.GetFloatByPath("[10]").ToInvariantString("F0"), "Index 10");
        Assert.AreEqual(0, SampleArray.GetFloatByPath("[11]"), "Index 11");
        Assert.AreEqual(0, SampleArray.GetFloatByPath("[12]"), "Index 12");
        Assert.AreEqual(0, SampleArray.GetFloatByPath("[13]"), "Index 13");
    }

    [TestMethod]
    public void GetFloatByPathOrNull() {
        Assert.AreEqual(null, SampleArray.GetFloatByPathOrNull("[0]"), "Index 0");
        Assert.AreEqual(null, SampleArray.GetFloatByPathOrNull("[1]"), "Index 1");
        Assert.AreEqual(123, SampleArray.GetFloatByPathOrNull("[2]"), "Index 2");
        Assert.AreEqual("123.456", SampleArray.GetFloatByPathOrNull("[3]").ToInvariantString("F3"), "Index 3");
        Assert.AreEqual(null, SampleArray.GetFloatByPathOrNull("[4]"), "Index 4");
        Assert.AreEqual(null, SampleArray.GetFloatByPathOrNull("[5]"), "Index 5");
        Assert.AreEqual(null, SampleArray.GetFloatByPathOrNull("[6]"), "Index 6");
        Assert.AreEqual(1, SampleArray.GetFloatByPathOrNull("[7]"), "Index 7");
        Assert.AreEqual(0, SampleArray.GetFloatByPathOrNull("[8]"), "Index 8");
        Assert.AreEqual("9223372036854775808", SampleArray.GetFloatByPath("[9]").ToInvariantString("F0"), "Index 9"); // Not sure why this comes back as 9223372036854775808 and not 9223372036854775807 (floats are a bit weird, so leaving this for now, considering it an edge case)
        Assert.AreEqual("9223372036854775808", SampleArray.GetFloatByPath("[10]").ToInvariantString("F0"), "Index 10");
        Assert.AreEqual(null, SampleArray.GetFloatByPathOrNull("[11]"), "Index 11");
        Assert.AreEqual(null, SampleArray.GetFloatByPathOrNull("[12]"), "Index 13");
        Assert.AreEqual(null, SampleArray.GetFloatByPathOrNull("[13]"), "Index 12");
    }

    [TestMethod]
    public void TryGetFloat() {

        bool success0 = SampleArray.TryGetFloat(0, out float result0);
        bool success1 = SampleArray.TryGetFloat(1, out float result1);
        bool success2 = SampleArray.TryGetFloat(2, out float result2);
        bool success3 = SampleArray.TryGetFloat(3, out float result3);
        bool success4 = SampleArray.TryGetFloat(4, out float result4);
        bool success5 = SampleArray.TryGetFloat(5, out float result5);
        bool success6 = SampleArray.TryGetFloat(6, out float result6);
        bool success7 = SampleArray.TryGetFloat(7, out float result7);
        bool success8 = SampleArray.TryGetFloat(8, out float result8);
        bool success9 = SampleArray.TryGetFloat(9, out float result9);
        bool success10 = SampleArray.TryGetFloat(10, out float result10);
        bool success11 = SampleArray.TryGetFloat(11, out float result11);
        bool success12 = SampleArray.TryGetFloat(12, out float result12);
        bool success13 = SampleArray.TryGetFloat(13, out float result13);

        Assert.IsFalse(success0);
        Assert.AreEqual(0, result0, "Index 0");

        Assert.IsFalse(success1);
        Assert.AreEqual(0, result1, "Index 1");

        Assert.IsTrue(success2);
        Assert.AreEqual(123, result2, "Index 2");

        Assert.IsTrue(success3);
        Assert.AreEqual("123.456", result3.ToInvariantString("F3"), "Index 3");

        Assert.IsFalse(success4);
        Assert.AreEqual(0, result4, "Index 4");

        Assert.IsFalse(success5);
        Assert.AreEqual(0, result5, "Index 5");

        Assert.IsFalse(success6);
        Assert.AreEqual(0, result6, "Index 6");

        Assert.IsTrue(success7);
        Assert.AreEqual(1, result7, "Index 7");

        Assert.IsTrue(success8);
        Assert.AreEqual(0, result8, "Index 8");

        Assert.IsTrue(success9);
        Assert.AreEqual("9223372036854775808", result9.ToInvariantString("F0"), "Index 9"); // Not sure why this comes back as 9223372036854775808 and not 9223372036854775807 (floats are a bit weird, so leaving this for now, considering it an edge case)

        Assert.IsTrue(success10);
        Assert.AreEqual("9223372036854775808", result10.ToInvariantString("F0"), "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(0, result11, "Index 11");

        Assert.IsFalse(success12);
        Assert.AreEqual(0, result12, "Index 12");

        Assert.IsFalse(success13);
        Assert.AreEqual(0, result13, "Index 13");

    }

    [TestMethod]
    public void TryGetFloatOrNull() {

        bool success0 = SampleArray.TryGetFloat(0, out float? result0);
        bool success1 = SampleArray.TryGetFloat(1, out float? result1);
        bool success2 = SampleArray.TryGetFloat(2, out float? result2);
        bool success3 = SampleArray.TryGetFloat(3, out float? result3);
        bool success4 = SampleArray.TryGetFloat(4, out float? result4);
        bool success5 = SampleArray.TryGetFloat(5, out float? result5);
        bool success6 = SampleArray.TryGetFloat(6, out float? result6);
        bool success7 = SampleArray.TryGetFloat(7, out float? result7);
        bool success8 = SampleArray.TryGetFloat(8, out float? result8);
        bool success9 = SampleArray.TryGetFloat(9, out float? result9);
        bool success10 = SampleArray.TryGetFloat(10, out float? result10);
        bool success11 = SampleArray.TryGetFloat(11, out float? result11);
        bool success12 = SampleArray.TryGetFloat(12, out float? result12);
        bool success13 = SampleArray.TryGetFloat(13, out float? result13);

        Assert.IsFalse(success0);
        Assert.AreEqual(null, result0, "Index 0");

        Assert.IsFalse(success1);
        Assert.AreEqual(null, result1, "Index 1");

        Assert.IsTrue(success2);
        Assert.AreEqual(123, result2, "Index 2");

        Assert.IsTrue(success3);
        Assert.AreEqual("123.456", result3.ToInvariantString("F3"), "Index 3");

        Assert.IsFalse(success4);
        Assert.AreEqual(null, result4, "Index 4");

        Assert.IsFalse(success5);
        Assert.AreEqual(null, result5, "Index 5");

        Assert.IsFalse(success6);
        Assert.AreEqual(null, result6, "Index 6");

        Assert.IsTrue(success7);
        Assert.AreEqual(1, result7, "Index 7");

        Assert.IsTrue(success8);
        Assert.AreEqual(0, result8, "Index 8");

        Assert.IsTrue(success9);
        Assert.AreEqual("9223372036854775808", result9.ToInvariantString("F0"), "Index 9"); // Not sure why this comes back as 9223372036854775808 and not 9223372036854775807 (floats are a bit weird, so leaving this for now, considering it an edge case)

        Assert.IsTrue(success10);
        Assert.AreEqual("9223372036854775808", result10.ToInvariantString("F0"), "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(null, result11, "Index 11");

        Assert.IsFalse(success12);
        Assert.AreEqual(null, result12, "Index 12");

        Assert.IsFalse(success13);
        Assert.AreEqual(null, result13, "Index 13");

    }

    [TestMethod]
    public void TryGetFloatByPath() {

        bool success0 = SampleArray.TryGetFloatByPath("[0]", out float result0);
        bool success1 = SampleArray.TryGetFloatByPath("[1]", out float result1);
        bool success2 = SampleArray.TryGetFloatByPath("[2]", out float result2);
        bool success3 = SampleArray.TryGetFloatByPath("[3]", out float result3);
        bool success4 = SampleArray.TryGetFloatByPath("[4]", out float result4);
        bool success5 = SampleArray.TryGetFloatByPath("[5]", out float result5);
        bool success6 = SampleArray.TryGetFloatByPath("[6]", out float result6);
        bool success7 = SampleArray.TryGetFloatByPath("[7]", out float result7);
        bool success8 = SampleArray.TryGetFloatByPath("[8]", out float result8);
        bool success9 = SampleArray.TryGetFloatByPath("[9]", out float result9);
        bool success10 = SampleArray.TryGetFloatByPath("[10]", out float result10);
        bool success11 = SampleArray.TryGetFloatByPath("[11]", out float result11);
        bool success12 = SampleArray.TryGetFloatByPath("[12]", out float result12);
        bool success13 = SampleArray.TryGetFloatByPath("[13]", out float result13);

        Assert.IsFalse(success0);
        Assert.AreEqual(0, result0, "Index 0");

        Assert.IsFalse(success1);
        Assert.AreEqual(0, result1, "Index 1");

        Assert.IsTrue(success2);
        Assert.AreEqual(123, result2, "Index 2");

        Assert.IsTrue(success3);
        Assert.AreEqual("123.456", result3.ToInvariantString("F3"), "Index 3");

        Assert.IsFalse(success4);
        Assert.AreEqual(0, result4, "Index 4");

        Assert.IsFalse(success5);
        Assert.AreEqual(0, result5, "Index 5");

        Assert.IsFalse(success6);
        Assert.AreEqual(0, result6, "Index 6");

        Assert.IsTrue(success7);
        Assert.AreEqual(1, result7, "Index 7");

        Assert.IsTrue(success8);
        Assert.AreEqual(0, result8, "Index 8");

        Assert.IsTrue(success9);
        Assert.AreEqual("9223372036854775808", result9.ToInvariantString("F0"), "Index 9"); // Not sure why this comes back as 9223372036854775808 and not 9223372036854775807 (floats are a bit weird, so leaving this for now, considering it an edge case)

        Assert.IsTrue(success10);
        Assert.AreEqual("9223372036854775808", result10.ToInvariantString("F0"), "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(0, result11, "Index 11");

        Assert.IsFalse(success12);
        Assert.AreEqual(0, result12, "Index 12");

        Assert.IsFalse(success13);
        Assert.AreEqual(0, result13, "Index 13");

    }

    [TestMethod]
    public void TryGetFloatByPathOrNull() {

        bool success0 = SampleArray.TryGetFloatByPath("[0]", out float? result0);
        bool success1 = SampleArray.TryGetFloatByPath("[1]", out float? result1);
        bool success2 = SampleArray.TryGetFloatByPath("[2]", out float? result2);
        bool success3 = SampleArray.TryGetFloatByPath("[3]", out float? result3);
        bool success4 = SampleArray.TryGetFloatByPath("[4]", out float? result4);
        bool success5 = SampleArray.TryGetFloatByPath("[5]", out float? result5);
        bool success6 = SampleArray.TryGetFloatByPath("[6]", out float? result6);
        bool success7 = SampleArray.TryGetFloatByPath("[7]", out float? result7);
        bool success8 = SampleArray.TryGetFloatByPath("[8]", out float? result8);
        bool success9 = SampleArray.TryGetFloatByPath("[9]", out float? result9);
        bool success10 = SampleArray.TryGetFloatByPath("[10]", out float? result10);
        bool success11 = SampleArray.TryGetFloatByPath("[11]", out float? result11);
        bool success12 = SampleArray.TryGetFloatByPath("[12]", out float? result12);
        bool success13 = SampleArray.TryGetFloatByPath("[13]", out float? result13);

        Assert.IsFalse(success0);
        Assert.AreEqual(null, result0, "Index 0");

        Assert.IsFalse(success1);
        Assert.AreEqual(null, result1, "Index 1");

        Assert.IsTrue(success2);
        Assert.AreEqual(123, result2, "Index 2");

        Assert.IsTrue(success3);
        Assert.AreEqual("123.456", result3.ToInvariantString("F3"), "Index 3");

        Assert.IsFalse(success4);
        Assert.AreEqual(null, result4, "Index 4");

        Assert.IsFalse(success5);
        Assert.AreEqual(null, result5, "Index 5");

        Assert.IsFalse(success6);
        Assert.AreEqual(null, result6, "Index 6");

        Assert.IsTrue(success7);
        Assert.AreEqual(1, result7, "Index 7");

        Assert.IsTrue(success8);
        Assert.AreEqual(0, result8, "Index 8");

        Assert.IsTrue(success9);
        Assert.AreEqual("9223372036854775808", result9.ToInvariantString("F0"), "Index 9"); // Not sure why this comes back as 9223372036854775808 and not 9223372036854775807 (floats are a bit weird, so leaving this for now, considering it an edge case)

        Assert.IsTrue(success10);
        Assert.AreEqual("9223372036854775808", result10.ToInvariantString("F0"), "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(null, result11, "Index 11");

        Assert.IsFalse(success12);
        Assert.AreEqual(null, result12, "Index 12");

        Assert.IsFalse(success13);
        Assert.AreEqual(null, result13, "Index 13");

    }

}