using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace TestProject1.Json.Newtonsoft.Arrays;

[TestClass]
public class ArrayGuidTests {

    protected static readonly JValue Null = JValue.CreateNull();

    public static readonly Guid Key = new("e4ac4109-303f-44ba-b29a-413f94beb00e");

    protected static readonly JArray SampleArray = new(new object[13]) {
        [0] = "",
        [1] = "Hello there!",
        [2] = 123,
        [3] = 123.456,
        [4] = Null,
        [5] = new JArray(),
        [6] = new JObject(),
        [7] = true,
        [8] = false,
        [9] = "e4ac4109-303f-44ba-b29a-413f94beb00e",
        [10] = new Guid("e4ac4109-303f-44ba-b29a-413f94beb00e"),
        [11] = long.MaxValue,
        [12] = "9223372036854775808" // long.MaxValue + 1
    };


    [TestMethod]
    public void GetGuid() {
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuid(0), "Index 0");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuid(1), "Index 1");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuid(2), "Index 2");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuid(3), "Index 3");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuid(4), "Index 4");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuid(5), "Index 5");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuid(6), "Index 6");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuid(7), "Index 7");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuid(8), "Index 8");
        Assert.AreEqual(Key, SampleArray.GetGuid(9), "Index 9");
        Assert.AreEqual(Key, SampleArray.GetGuid(10), "Index 10");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuid(11), "Index 11");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuid(12), "Index 12");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuid(13), "Index 13");
    }

    [TestMethod]
    public void GetGuidOrNull() {
        Assert.AreEqual(null, SampleArray.GetGuidOrNull(0), "Index 0");
        Assert.AreEqual(null, SampleArray.GetGuidOrNull(1), "Index 1");
        Assert.AreEqual(null, SampleArray.GetGuidOrNull(2), "Index 2");
        Assert.AreEqual(null, SampleArray.GetGuidOrNull(3), "Index 3");
        Assert.AreEqual(null, SampleArray.GetGuidOrNull(4), "Index 4");
        Assert.AreEqual(null, SampleArray.GetGuidOrNull(5), "Index 5");
        Assert.AreEqual(null, SampleArray.GetGuidOrNull(6), "Index 6");
        Assert.AreEqual(null, SampleArray.GetGuidOrNull(7), "Index 7");
        Assert.AreEqual(null, SampleArray.GetGuidOrNull(8), "Index 8");
        Assert.AreEqual(Key, SampleArray.GetGuidOrNull(9), "Index 9");
        Assert.AreEqual(Key, SampleArray.GetGuidOrNull(10), "Index 10");
        Assert.AreEqual(null, SampleArray.GetGuidOrNull(11), "Index 11");
        Assert.AreEqual(null, SampleArray.GetGuidOrNull(12), "Index 12");
        Assert.AreEqual(null, SampleArray.GetGuidOrNull(13), "Index 13");
    }

    [TestMethod]
    public void GetGuidByPath() {
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuidByPath("[0]"), "Index 0");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuidByPath("[1]"), "Index 1");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuidByPath("[2]"), "Index 2");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuidByPath("[3]"), "Index 3");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuidByPath("[4]"), "Index 4");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuidByPath("[5]"), "Index 5");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuidByPath("[6]"), "Index 6");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuidByPath("[7]"), "Index 7");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuidByPath("[8]"), "Index 8");
        Assert.AreEqual(Key, SampleArray.GetGuidByPath("[9]"), "Index 9");
        Assert.AreEqual(Key, SampleArray.GetGuidByPath("[10]"), "Index 10");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuidByPath("[11]"), "Index 11");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuidByPath("[12]"), "Index 12");
        Assert.AreEqual(Guid.Empty, SampleArray.GetGuidByPath("[13]"), "Index 13");
    }

    [TestMethod]
    public void GetGuidByPathOrNull() {
        Assert.AreEqual(null, SampleArray.GetGuidByPathOrNull("[0]"), "Index 0");
        Assert.AreEqual(null, SampleArray.GetGuidByPathOrNull("[1]"), "Index 1");
        Assert.AreEqual(null, SampleArray.GetGuidByPathOrNull("[2]"), "Index 2");
        Assert.AreEqual(null, SampleArray.GetGuidByPathOrNull("[3]"), "Index 3");
        Assert.AreEqual(null, SampleArray.GetGuidByPathOrNull("[4]"), "Index 4");
        Assert.AreEqual(null, SampleArray.GetGuidByPathOrNull("[5]"), "Index 5");
        Assert.AreEqual(null, SampleArray.GetGuidByPathOrNull("[6]"), "Index 6");
        Assert.AreEqual(null, SampleArray.GetGuidByPathOrNull("[7]"), "Index 7");
        Assert.AreEqual(null, SampleArray.GetGuidByPathOrNull("[8]"), "Index 8");
        Assert.AreEqual(Key, SampleArray.GetGuidByPathOrNull("[9]"), "Index 9");
        Assert.AreEqual(Key, SampleArray.GetGuidByPathOrNull("[10]"), "Index 10");
        Assert.AreEqual(null, SampleArray.GetGuidByPathOrNull("[11]"), "Index 11");
        Assert.AreEqual(null, SampleArray.GetGuidByPathOrNull("[12]"), "Index 12");
        Assert.AreEqual(null, SampleArray.GetGuidByPathOrNull("[13]"), "Index 13");
    }

    [TestMethod]
    public void TryGetGuid() {

        bool success0 = SampleArray.TryGetGuid(0, out Guid result0);
        bool success1 = SampleArray.TryGetGuid(1, out Guid result1);
        bool success2 = SampleArray.TryGetGuid(2, out Guid result2);
        bool success3 = SampleArray.TryGetGuid(3, out Guid result3);
        bool success4 = SampleArray.TryGetGuid(4, out Guid result4);
        bool success5 = SampleArray.TryGetGuid(5, out Guid result5);
        bool success6 = SampleArray.TryGetGuid(6, out Guid result6);
        bool success7 = SampleArray.TryGetGuid(7, out Guid result7);
        bool success8 = SampleArray.TryGetGuid(8, out Guid result8);
        bool success9 = SampleArray.TryGetGuid(9, out Guid result9);
        bool success10 = SampleArray.TryGetGuid(10, out Guid result10);
        bool success11 = SampleArray.TryGetGuid(11, out Guid result11);
        bool success12 = SampleArray.TryGetGuid(12, out Guid result12);
        bool success13 = SampleArray.TryGetGuid(13, out Guid result13);

        Assert.IsFalse(success0, "Index 0");
        Assert.AreEqual(Guid.Empty, result0, "Index 0");

        Assert.IsFalse(success1, "Index 1");
        Assert.AreEqual(Guid.Empty, result1, "Index 1");

        Assert.IsFalse(success2, "Index 2");
        Assert.AreEqual(Guid.Empty, result2, "Index 2");

        Assert.IsFalse(success3, "Index 3");
        Assert.AreEqual(Guid.Empty, result3, "Index 3");

        Assert.IsFalse(success4, "Index 4");
        Assert.AreEqual(Guid.Empty, result4, "Index 4");

        Assert.IsFalse(success5, "Index 5");
        Assert.AreEqual(Guid.Empty, result5, "Index 5");

        Assert.IsFalse(success6, "Index 6");
        Assert.AreEqual(Guid.Empty, result6, "Index 6");

        Assert.IsFalse(success7, "Index 7");
        Assert.AreEqual(Guid.Empty, result7, "Index 7");

        Assert.IsFalse(success8, "Index 8");
        Assert.AreEqual(Guid.Empty, result8, "Index 8");

        Assert.IsTrue(success9, "Index 9");
        Assert.AreEqual(Key, result9, "Index 9");

        Assert.IsTrue(success10, "Index 10");
        Assert.AreEqual(Key, result10, "Index 10");

        Assert.IsFalse(success11, "Index 11");
        Assert.AreEqual(Guid.Empty, result11, "Index 11");

        Assert.IsFalse(success12, "Index 12");
        Assert.AreEqual(Guid.Empty, result12, "Index 12");

        Assert.IsFalse(success13, "Index 13");
        Assert.AreEqual(Guid.Empty, result13, "Index 13");

    }

    [TestMethod]
    public void TryGetGuidOrNull() {

        bool success0 = SampleArray.TryGetGuid(0, out Guid? result0);
        bool success1 = SampleArray.TryGetGuid(1, out Guid? result1);
        bool success2 = SampleArray.TryGetGuid(2, out Guid? result2);
        bool success3 = SampleArray.TryGetGuid(3, out Guid? result3);
        bool success4 = SampleArray.TryGetGuid(4, out Guid? result4);
        bool success5 = SampleArray.TryGetGuid(5, out Guid? result5);
        bool success6 = SampleArray.TryGetGuid(6, out Guid? result6);
        bool success7 = SampleArray.TryGetGuid(7, out Guid? result7);
        bool success8 = SampleArray.TryGetGuid(8, out Guid? result8);
        bool success9 = SampleArray.TryGetGuid(9, out Guid? result9);
        bool success10 = SampleArray.TryGetGuid(10, out Guid? result10);
        bool success11 = SampleArray.TryGetGuid(11, out Guid? result11);
        bool success12 = SampleArray.TryGetGuid(12, out Guid? result12);
        bool success13 = SampleArray.TryGetGuid(13, out Guid? result13);

        Assert.IsFalse(success0);
        Assert.AreEqual(null, result0, "Index 0");

        Assert.IsFalse(success1);
        Assert.AreEqual(null, result1, "Index 1");

        Assert.IsFalse(success2);
        Assert.AreEqual(null, result2, "Index 2");

        Assert.IsFalse(success3);
        Assert.AreEqual(null, result3, "Index 3");

        Assert.IsFalse(success4);
        Assert.AreEqual(null, result4, "Index 4");

        Assert.IsFalse(success5);
        Assert.AreEqual(null, result5, "Index 5");

        Assert.IsFalse(success6);
        Assert.AreEqual(null, result6, "Index 6");

        Assert.IsFalse(success7);
        Assert.AreEqual(null, result7, "Index 7");

        Assert.IsFalse(success8);
        Assert.AreEqual(null, result8, "Index 8");

        Assert.IsTrue(success9);
        Assert.AreEqual(Key, result9, "Index 9");

        Assert.IsTrue(success10);
        Assert.AreEqual(Key, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(null, result11, "Index 11");

        Assert.IsFalse(success12);
        Assert.AreEqual(null, result12, "Index 12");

        Assert.IsFalse(success13);
        Assert.AreEqual(null, result13, "Index 13");

    }

    [TestMethod]
    public void TryGetGuidByPath() {

        bool success0 = SampleArray.TryGetGuidByPath("[0]", out Guid result0);
        bool success1 = SampleArray.TryGetGuidByPath("[1]", out Guid result1);
        bool success2 = SampleArray.TryGetGuidByPath("[2]", out Guid result2);
        bool success3 = SampleArray.TryGetGuidByPath("[3]", out Guid result3);
        bool success4 = SampleArray.TryGetGuidByPath("[4]", out Guid result4);
        bool success5 = SampleArray.TryGetGuidByPath("[5]", out Guid result5);
        bool success6 = SampleArray.TryGetGuidByPath("[6]", out Guid result6);
        bool success7 = SampleArray.TryGetGuidByPath("[7]", out Guid result7);
        bool success8 = SampleArray.TryGetGuidByPath("[8]", out Guid result8);
        bool success9 = SampleArray.TryGetGuidByPath("[9]", out Guid result9);
        bool success10 = SampleArray.TryGetGuidByPath("[10]", out Guid result10);
        bool success11 = SampleArray.TryGetGuidByPath("[11]", out Guid result11);
        bool success12 = SampleArray.TryGetGuidByPath("[12]", out Guid result12);
        bool success13 = SampleArray.TryGetGuidByPath("[13]", out Guid result13);

        Assert.IsFalse(success0, "Index 0");
        Assert.AreEqual(Guid.Empty, result0, "Index 0");

        Assert.IsFalse(success1, "Index 1");
        Assert.AreEqual(Guid.Empty, result1, "Index 1");

        Assert.IsFalse(success2, "Index 2");
        Assert.AreEqual(Guid.Empty, result2, "Index 2");

        Assert.IsFalse(success3, "Index 3");
        Assert.AreEqual(Guid.Empty, result3, "Index 3");

        Assert.IsFalse(success4, "Index 4");
        Assert.AreEqual(Guid.Empty, result4, "Index 4");

        Assert.IsFalse(success5, "Index 5");
        Assert.AreEqual(Guid.Empty, result5, "Index 5");

        Assert.IsFalse(success6, "Index 6");
        Assert.AreEqual(Guid.Empty, result6, "Index 6");

        Assert.IsFalse(success7, "Index 7");
        Assert.AreEqual(Guid.Empty, result7, "Index 7");

        Assert.IsFalse(success8, "Index 8");
        Assert.AreEqual(Guid.Empty, result8, "Index 8");

        Assert.IsTrue(success9, "Index 9");
        Assert.AreEqual(Key, result9, "Index 9");

        Assert.IsTrue(success10, "Index 10");
        Assert.AreEqual(Key, result10, "Index 10");

        Assert.IsFalse(success11, "Index 11");
        Assert.AreEqual(Guid.Empty, result11, "Index 11");

        Assert.IsFalse(success12, "Index 12");
        Assert.AreEqual(Guid.Empty, result12, "Index 12");

        Assert.IsFalse(success13, "Index 13");
        Assert.AreEqual(Guid.Empty, result13, "Index 13");

    }

    [TestMethod]
    public void TryGetGuidByPathOrNull() {

        bool success0 = SampleArray.TryGetGuidByPath("[0]", out Guid? result0);
        bool success1 = SampleArray.TryGetGuidByPath("[1]", out Guid? result1);
        bool success2 = SampleArray.TryGetGuidByPath("[2]", out Guid? result2);
        bool success3 = SampleArray.TryGetGuidByPath("[3]", out Guid? result3);
        bool success4 = SampleArray.TryGetGuidByPath("[4]", out Guid? result4);
        bool success5 = SampleArray.TryGetGuidByPath("[5]", out Guid? result5);
        bool success6 = SampleArray.TryGetGuidByPath("[6]", out Guid? result6);
        bool success7 = SampleArray.TryGetGuidByPath("[7]", out Guid? result7);
        bool success8 = SampleArray.TryGetGuidByPath("[8]", out Guid? result8);
        bool success9 = SampleArray.TryGetGuidByPath("[9]", out Guid? result9);
        bool success10 = SampleArray.TryGetGuidByPath("[10]", out Guid? result10);
        bool success11 = SampleArray.TryGetGuidByPath("[11]", out Guid? result11);
        bool success12 = SampleArray.TryGetGuidByPath("[12]", out Guid? result12);
        bool success13 = SampleArray.TryGetGuidByPath("[13]", out Guid? result13);

        Assert.IsFalse(success0);
        Assert.AreEqual(null, result0, "Index 0");

        Assert.IsFalse(success1);
        Assert.AreEqual(null, result1, "Index 1");

        Assert.IsFalse(success2);
        Assert.AreEqual(null, result2, "Index 2");

        Assert.IsFalse(success3);
        Assert.AreEqual(null, result3, "Index 3");

        Assert.IsFalse(success4);
        Assert.AreEqual(null, result4, "Index 4");

        Assert.IsFalse(success5);
        Assert.AreEqual(null, result5, "Index 5");

        Assert.IsFalse(success6);
        Assert.AreEqual(null, result6, "Index 6");

        Assert.IsFalse(success7);
        Assert.AreEqual(null, result7, "Index 7");

        Assert.IsFalse(success8);
        Assert.AreEqual(null, result8, "Index 8");

        Assert.IsTrue(success9);
        Assert.AreEqual(Key, result9, "Index 9");

        Assert.IsTrue(success10);
        Assert.AreEqual(Key, result10, "Index 10");

        Assert.IsFalse(success11);
        Assert.AreEqual(null, result11, "Index 11");

        Assert.IsFalse(success12);
        Assert.AreEqual(null, result12, "Index 12");

        Assert.IsFalse(success13);
        Assert.AreEqual(null, result13, "Index 13");

    }

}