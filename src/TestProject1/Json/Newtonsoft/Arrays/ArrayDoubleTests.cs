using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace TestProject1.Json.Newtonsoft.Arrays;

[TestClass]
public class ArrayDoubleTests {

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
        [9] = double.MaxValue,
        [10] = "1797693134862315708145274237317043567980705675258449965989174768031572607800285387605895586327668781715404589535143824642343213268894641827684675467035375169860499105765512820762454900903893289440758685084551339423045832369032229481658085593321233482747978262041447231687381771809192998812504040261841248583680" // greater than double.MaxValue
    };


    [TestMethod]
    public void GetDouble() {
        Assert.AreEqual(0, SampleArray.GetDouble(0), "Index 0");
        Assert.AreEqual(0, SampleArray.GetDouble(1), "Index 1");
        Assert.AreEqual(123, SampleArray.GetDouble(2), "Index 2");
        Assert.AreEqual(123.456, SampleArray.GetDouble(3), "Index 3");
        Assert.AreEqual(0, SampleArray.GetDouble(4), "Index 4");
        Assert.AreEqual(0, SampleArray.GetDouble(5), "Index 5");
        Assert.AreEqual(0, SampleArray.GetDouble(6), "Index 6");
        Assert.AreEqual(1, SampleArray.GetDouble(7), "Index 7");
        Assert.AreEqual(0, SampleArray.GetDouble(8), "Index 8");
        Assert.AreEqual(double.MaxValue, SampleArray.GetDouble(9), "Index 9");
        Assert.AreEqual(0, SampleArray.GetDouble(10), "Index 10");
        Assert.AreEqual(0, SampleArray.GetDouble(11), "Index 11");
    }

    [TestMethod]
    public void GetDoubleOrNull() {
        Assert.AreEqual(null, SampleArray.GetDoubleOrNull(0), "Index 0");
        Assert.AreEqual(null, SampleArray.GetDoubleOrNull(1), "Index 1");
        Assert.AreEqual(123, SampleArray.GetDoubleOrNull(2), "Index 2");
        Assert.AreEqual(123.456, SampleArray.GetDoubleOrNull(3), "Index 3");
        Assert.AreEqual(null, SampleArray.GetDoubleOrNull(4), "Index 4");
        Assert.AreEqual(null, SampleArray.GetDoubleOrNull(5), "Index 5");
        Assert.AreEqual(null, SampleArray.GetDoubleOrNull(6), "Index 6");
        Assert.AreEqual(1, SampleArray.GetDoubleOrNull(7), "Index 7");
        Assert.AreEqual(0, SampleArray.GetDoubleOrNull(8), "Index 8");
        Assert.AreEqual(double.MaxValue, SampleArray.GetDoubleOrNull(9), "Index 9");
        Assert.AreEqual(null, SampleArray.GetDoubleOrNull(10), "Index 10");
        Assert.AreEqual(null, SampleArray.GetDoubleOrNull(11), "Index 11");
    }

    [TestMethod]
    public void GetDoubleByPath() {
        Assert.AreEqual(0, SampleArray.GetDoubleByPath("[0]"), "Index 0");
        Assert.AreEqual(0, SampleArray.GetDoubleByPath("[1]"), "Index 1");
        Assert.AreEqual(123, SampleArray.GetDoubleByPath("[2]"), "Index 2");
        Assert.AreEqual(123.456, SampleArray.GetDoubleByPath("[3]"), "Index 3");
        Assert.AreEqual(0, SampleArray.GetDoubleByPath("[4]"), "Index 4");
        Assert.AreEqual(0, SampleArray.GetDoubleByPath("[5]"), "Index 5");
        Assert.AreEqual(0, SampleArray.GetDoubleByPath("[6]"), "Index 6");
        Assert.AreEqual(1, SampleArray.GetDoubleByPath("[7]"), "Index 7");
        Assert.AreEqual(0, SampleArray.GetDoubleByPath("[8]"), "Index 8");
        Assert.AreEqual(double.MaxValue, SampleArray.GetDoubleByPath("[9]"), "Index 9");
        Assert.AreEqual(0, SampleArray.GetDoubleByPath("[10]"), "Index 10");
        Assert.AreEqual(0, SampleArray.GetDoubleByPath("[11]"), "Index 11");
    }

    [TestMethod]
    public void GetDoubleByPathOrNull() {
        Assert.AreEqual(null, SampleArray.GetDoubleByPathOrNull("[0]"), "Index 0");
        Assert.AreEqual(null, SampleArray.GetDoubleByPathOrNull("[1]"), "Index 1");
        Assert.AreEqual(123, SampleArray.GetDoubleByPathOrNull("[2]"), "Index 2");
        Assert.AreEqual(123.456, SampleArray.GetDoubleByPathOrNull("[3]"), "Index 3");
        Assert.AreEqual(null, SampleArray.GetDoubleByPathOrNull("[4]"), "Index 4");
        Assert.AreEqual(null, SampleArray.GetDoubleByPathOrNull("[5]"), "Index 5");
        Assert.AreEqual(null, SampleArray.GetDoubleByPathOrNull("[6]"), "Index 6");
        Assert.AreEqual(1, SampleArray.GetDoubleByPathOrNull("[7]"), "Index 7");
        Assert.AreEqual(0, SampleArray.GetDoubleByPathOrNull("[8]"), "Index 8");
        Assert.AreEqual(double.MaxValue, SampleArray.GetDoubleByPathOrNull("[9]"), "Index 9");
        Assert.AreEqual(null, SampleArray.GetDoubleByPathOrNull("[10]"), "Index 10");
        Assert.AreEqual(null, SampleArray.GetDoubleByPathOrNull("[11]"), "Index 11");
    }

    [TestMethod]
    public void TryGetDouble() {

        bool success0 = SampleArray.TryGetDouble(0, out double result0);
        bool success1 = SampleArray.TryGetDouble(1, out double result1);
        bool success2 = SampleArray.TryGetDouble(2, out double result2);
        bool success3 = SampleArray.TryGetDouble(3, out double result3);
        bool success4 = SampleArray.TryGetDouble(4, out double result4);
        bool success5 = SampleArray.TryGetDouble(5, out double result5);
        bool success6 = SampleArray.TryGetDouble(6, out double result6);
        bool success7 = SampleArray.TryGetDouble(7, out double result7);
        bool success8 = SampleArray.TryGetDouble(8, out double result8);
        bool success9 = SampleArray.TryGetDouble(9, out double result9);
        bool success10 = SampleArray.TryGetDouble(10, out double result10);
        bool success11 = SampleArray.TryGetDouble(11, out double result11);

        Assert.IsFalse(success0, "Index 0");
        Assert.AreEqual(0, result0, "Index 0");

        Assert.IsFalse(success1, "Index 1");
        Assert.AreEqual(0, result1, "Index 1");

        Assert.IsTrue(success2, "Index 2");
        Assert.AreEqual(123, result2, "Index 2");

        Assert.IsTrue(success3, "Index 3");
        Assert.AreEqual(123.456, result3, "Index 3");

        Assert.IsFalse(success4, "Index 4");
        Assert.AreEqual(0, result4, "Index 4");

        Assert.IsFalse(success5, "Index 5");
        Assert.AreEqual(0, result5, "Index 5");

        Assert.IsFalse(success6, "Index 6");
        Assert.AreEqual(0, result6, "Index 6");

        Assert.IsTrue(success7, "Index 7");
        Assert.AreEqual(1, result7, "Index 7");

        Assert.IsTrue(success8, "Index 8");
        Assert.AreEqual(0, result8, "Index 8");

        Assert.IsTrue(success9, "Index 9");
        Assert.AreEqual(double.MaxValue, result9, "Index 9");

        Assert.IsFalse(success10, "Index 10");
        Assert.AreEqual(0, result10, "Index 10");

        Assert.IsFalse(success11, "Index 11");
        Assert.AreEqual(0, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetDoubleOrNull() {

        bool success0 = SampleArray.TryGetDouble(0, out double? result0);
        bool success1 = SampleArray.TryGetDouble(1, out double? result1);
        bool success2 = SampleArray.TryGetDouble(2, out double? result2);
        bool success3 = SampleArray.TryGetDouble(3, out double? result3);
        bool success4 = SampleArray.TryGetDouble(4, out double? result4);
        bool success5 = SampleArray.TryGetDouble(5, out double? result5);
        bool success6 = SampleArray.TryGetDouble(6, out double? result6);
        bool success7 = SampleArray.TryGetDouble(7, out double? result7);
        bool success8 = SampleArray.TryGetDouble(8, out double? result8);
        bool success9 = SampleArray.TryGetDouble(9, out double? result9);
        bool success10 = SampleArray.TryGetDouble(10, out double? result10);
        bool success11 = SampleArray.TryGetDouble(11, out double? result11);

        Assert.IsFalse(success0, "Index 0");
        Assert.AreEqual(null, result0, "Index 0");

        Assert.IsFalse(success1, "Index 1");
        Assert.AreEqual(null, result1, "Index 1");

        Assert.IsTrue(success2, "Index 2");
        Assert.AreEqual(123, result2, "Index 2");

        Assert.IsTrue(success3, "Index 3");
        Assert.AreEqual(123.456, result3, "Index 3");

        Assert.IsFalse(success4, "Index 4");
        Assert.AreEqual(null, result4, "Index 4");

        Assert.IsFalse(success5, "Index 5");
        Assert.AreEqual(null, result5, "Index 5");

        Assert.IsFalse(success6, "Index 6");
        Assert.AreEqual(null, result6, "Index 6");

        Assert.IsTrue(success7, "Index 7");
        Assert.AreEqual(1, result7, "Index 7");

        Assert.IsTrue(success8, "Index 8");
        Assert.AreEqual(0, result8, "Index 8");

        Assert.IsTrue(success9, "Index 9");
        Assert.AreEqual(double.MaxValue, result9, "Index 9");

        Assert.IsFalse(success10, "Index 10");
        Assert.AreEqual(null, result10, "Index 10");

        Assert.IsFalse(success11, "Index 11");
        Assert.AreEqual(null, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetDoubleByPath() {

        bool success0 = SampleArray.TryGetDoubleByPath("[0]", out double result0);
        bool success1 = SampleArray.TryGetDoubleByPath("[1]", out double result1);
        bool success2 = SampleArray.TryGetDoubleByPath("[2]", out double result2);
        bool success3 = SampleArray.TryGetDoubleByPath("[3]", out double result3);
        bool success4 = SampleArray.TryGetDoubleByPath("[4]", out double result4);
        bool success5 = SampleArray.TryGetDoubleByPath("[5]", out double result5);
        bool success6 = SampleArray.TryGetDoubleByPath("[6]", out double result6);
        bool success7 = SampleArray.TryGetDoubleByPath("[7]", out double result7);
        bool success8 = SampleArray.TryGetDoubleByPath("[8]", out double result8);
        bool success9 = SampleArray.TryGetDoubleByPath("[9]", out double result9);
        bool success10 = SampleArray.TryGetDoubleByPath("[10]", out double result10);
        bool success11 = SampleArray.TryGetDoubleByPath("[11]", out double result11);

        Assert.IsFalse(success0, "Index 0");
        Assert.AreEqual(0, result0, "Index 0");

        Assert.IsFalse(success1, "Index 1");
        Assert.AreEqual(0, result1, "Index 1");

        Assert.IsTrue(success2, "Index 2");
        Assert.AreEqual(123, result2, "Index 2");

        Assert.IsTrue(success3, "Index 3");
        Assert.AreEqual(123.456, result3, "Index 3");

        Assert.IsFalse(success4, "Index 4");
        Assert.AreEqual(0, result4, "Index 4");

        Assert.IsFalse(success5, "Index 5");
        Assert.AreEqual(0, result5, "Index 5");

        Assert.IsFalse(success6, "Index 6");
        Assert.AreEqual(0, result6, "Index 6");

        Assert.IsTrue(success7, "Index 7");
        Assert.AreEqual(1, result7, "Index 7");

        Assert.IsTrue(success8, "Index 8");
        Assert.AreEqual(0, result8, "Index 8");

        Assert.IsTrue(success9, "Index 9");
        Assert.AreEqual(double.MaxValue, result9, "Index 9");

        Assert.IsFalse(success10, "Index 10");
        Assert.AreEqual(0, result10, "Index 10");

        Assert.IsFalse(success11, "Index 11");
        Assert.AreEqual(0, result11, "Index 11");

    }

    [TestMethod]
    public void TryGetDoubleByPathOrNull() {

        bool success0 = SampleArray.TryGetDoubleByPath("[0]", out double? result0);
        bool success1 = SampleArray.TryGetDoubleByPath("[1]", out double? result1);
        bool success2 = SampleArray.TryGetDoubleByPath("[2]", out double? result2);
        bool success3 = SampleArray.TryGetDoubleByPath("[3]", out double? result3);
        bool success4 = SampleArray.TryGetDoubleByPath("[4]", out double? result4);
        bool success5 = SampleArray.TryGetDoubleByPath("[5]", out double? result5);
        bool success6 = SampleArray.TryGetDoubleByPath("[6]", out double? result6);
        bool success7 = SampleArray.TryGetDoubleByPath("[7]", out double? result7);
        bool success8 = SampleArray.TryGetDoubleByPath("[8]", out double? result8);
        bool success9 = SampleArray.TryGetDoubleByPath("[9]", out double? result9);
        bool success10 = SampleArray.TryGetDoubleByPath("[10]", out double? result10);
        bool success11 = SampleArray.TryGetDoubleByPath("[11]", out double? result11);

        Assert.IsFalse(success0, "Index 0");
        Assert.AreEqual(null, result0, "Index 0");

        Assert.IsFalse(success1, "Index 1");
        Assert.AreEqual(null, result1, "Index 1");

        Assert.IsTrue(success2, "Index 2");
        Assert.AreEqual(123, result2, "Index 2");

        Assert.IsTrue(success3, "Index 3");
        Assert.AreEqual(123.456, result3, "Index 3");

        Assert.IsFalse(success4, "Index 4");
        Assert.AreEqual(null, result4, "Index 4");

        Assert.IsFalse(success5, "Index 5");
        Assert.AreEqual(null, result5, "Index 5");

        Assert.IsFalse(success6, "Index 6");
        Assert.AreEqual(null, result6, "Index 6");

        Assert.IsTrue(success7, "Index 7");
        Assert.AreEqual(1, result7, "Index 7");

        Assert.IsTrue(success8, "Index 8");
        Assert.AreEqual(0, result8, "Index 8");

        Assert.IsTrue(success9, "Index 9");
        Assert.AreEqual(double.MaxValue, result9, "Index 9");

        Assert.IsFalse(success10, "Index 10");
        Assert.AreEqual(null, result10, "Index 10");

        Assert.IsFalse(success11, "Index 11");
        Assert.AreEqual(null, result11, "Index 11");

    }

}