using System.Globalization;
using Microsoft.Extensions.Configuration;
using Skybrud.Essentials.Configuration;
using Skybrud.Essentials.Strings.Extensions;

namespace TestProject1.Configuration;

[TestClass]
public class ConfigurationTests {

    [TestMethod]
    public void GetDouble() {

        IConfiguration config = GetConfiguration();

        double value1 = config.GetDouble("SectionName:Double");
        Assert.AreEqual(1234.5678, value1);

        double value2 = config.GetDouble("SectionName:Double:Nope");
        Assert.AreEqual(0, value2);

    }

    [TestMethod]
    public void GetDoubleOrNull() {

        IConfiguration config = GetConfiguration();

        double? value1 = config.GetDoubleOrNull("SectionName:Double");
        Assert.AreEqual(1234.5678, value1);

        double? value2 = config.GetDoubleOrNull("SectionName:Double:Nope");
        Assert.IsNull(value2);

    }

    [TestMethod]
    public void GetRequiredDouble() {

        IConfiguration config = GetConfiguration();

        double? value1 = config.GetRequiredDouble("SectionName:Double");
        Assert.AreEqual(1234.5678, value1);

        Assert.ThrowsException<Exception>(() => {
            config.GetRequiredDouble("SectionName:Double:Nope");
        });

    }

    [TestMethod]
    public void TryGetDouble() {

        IConfiguration config = GetConfiguration();

        bool result1 = config.TryGetDouble("SectionName:Double", out double value1);
        Assert.IsTrue(result1);
        Assert.AreEqual(1234.5678, value1);

        bool result2 = config.TryGetDouble("SectionName:Double:Nope", out double value2);
        Assert.IsFalse(result2);
        Assert.AreEqual(0, value2);

        bool result3 = config.TryGetDouble("SectionName:Double", out double? value3);
        Assert.IsTrue(result3);
        Assert.AreEqual(1234.5678, value3);

        bool result4 = config.TryGetDouble("SectionName:Double:Nope", out double? value4);
        Assert.IsFalse(result4);
        Assert.IsNull(value4);

    }

    [TestMethod]
    public void GetFloat() {

        IConfiguration config = GetConfiguration();

        float value1 = config.GetFloat("SectionName:Float");
        Assert.AreEqual(1234.568, ToPrecision(value1, 3));

        float value2 = config.GetFloat("SectionName:Float:Nope");
        Assert.AreEqual(0, value2);

    }

    [TestMethod]
    public void GetFloatOrNull() {

        IConfiguration config = GetConfiguration();

        float? value1 = config.GetFloatOrNull("SectionName:Float");
        Assert.AreEqual(1234.568, ToPrecision(value1, 3));

        float? value2 = config.GetFloatOrNull("SectionName:Float:Nope");
        Assert.IsNull(value2);

    }

    [TestMethod]
    public void GetRequiredFloat() {

        IConfiguration config = GetConfiguration();

        float? value1 = config.GetRequiredFloat("SectionName:Float");
        Assert.AreEqual(1234.568, ToPrecision(value1, 3));

        Assert.ThrowsException<Exception>(() => {
            config.GetRequiredFloat("SectionName:Float:Nope");
        });

    }

    [TestMethod]
    public void TryGetFloat() {

        IConfiguration config = GetConfiguration();

        bool result1 = config.TryGetFloat("SectionName:Float", out float value1);
        Assert.IsTrue(result1);
        Assert.AreEqual(1234.568, ToPrecision(value1, 3));

        bool result2 = config.TryGetFloat("SectionName:Float:Nope", out float value2);
        Assert.IsFalse(result2);
        Assert.AreEqual(0, value2);

        bool result3 = config.TryGetFloat("SectionName:Float", out float? value3);
        Assert.IsTrue(result3);
        Assert.AreEqual(1234.568, ToPrecision(value3, 3));

        bool result4 = config.TryGetFloat("SectionName:Float:Nope", out float? value4);
        Assert.IsFalse(result4);
        Assert.IsNull(value4);

    }

    [TestMethod]
    public void GetInt32() {

        IConfiguration config = GetConfiguration();

        int value1 = config.GetInt32("SectionName:Int32");
        Assert.AreEqual(1234, value1);

        int value2 = config.GetInt32("SectionName:Int32:Nope");
        Assert.AreEqual(0, value2);

    }

    [TestMethod]
    public void GetInt32OrNull() {

        IConfiguration config = GetConfiguration();

        int? value1 = config.GetInt32OrNull("SectionName:Int32");
        Assert.AreEqual(1234, value1);

        int? value2 = config.GetInt32OrNull("SectionName:Int32:Nope");
        Assert.IsNull(value2);

    }

    [TestMethod]
    public void GetRequiredInt32() {

        IConfiguration config = GetConfiguration();

        int? value1 = config.GetRequiredInt32("SectionName:Int32");
        Assert.AreEqual(1234, value1);

        Assert.ThrowsException<Exception>(() => {
            config.GetRequiredInt32("SectionName:Int32:Nope");
        });

    }

    [TestMethod]
    public void TryGetInt32() {

        IConfiguration config = GetConfiguration();

        bool result1 = config.TryGetInt32("SectionName:Int32", out int value1);
        Assert.IsTrue(result1);
        Assert.AreEqual(1234, value1);

        bool result2 = config.TryGetInt32("SectionName:Int32:Nope", out int value2);
        Assert.IsFalse(result2);
        Assert.AreEqual(0, value2);

        bool result3 = config.TryGetInt32("SectionName:Int32", out int? value3);
        Assert.IsTrue(result3);
        Assert.AreEqual(1234, value3);

        bool result4 = config.TryGetInt32("SectionName:Int32:Nope", out int? value4);
        Assert.IsFalse(result4);
        Assert.IsNull(value4);

    }

    [TestMethod]
    public void GetInt64() {

        IConfiguration config = GetConfiguration();

        long value1 = config.GetInt64("SectionName:Int64");
        Assert.AreEqual(12345678, value1);

        long value2 = config.GetInt64("SectionName:Int64:Nope");
        Assert.AreEqual(0, value2);

    }

    [TestMethod]
    public void GetInt64OrNull() {

        IConfiguration config = GetConfiguration();

        long? value1 = config.GetInt64OrNull("SectionName:Int64");
        Assert.AreEqual(12345678, value1);

        long? value2 = config.GetInt64OrNull("SectionName:Int64:Nope");
        Assert.IsNull(value2);

    }

    [TestMethod]
    public void GetRequiredInt64() {

        IConfiguration config = GetConfiguration();

        long? value1 = config.GetRequiredInt64("SectionName:Int64");
        Assert.AreEqual(12345678, value1);

        Assert.ThrowsException<Exception>(() => {
            config.GetRequiredInt64("SectionName:Int64:Nope");
        });

    }

    [TestMethod]
    public void TryGetInt64() {

        IConfiguration config = GetConfiguration();

        bool result1 = config.TryGetInt64("SectionName:Int64", out long value1);
        Assert.IsTrue(result1);
        Assert.AreEqual(12345678, value1);

        bool result2 = config.TryGetInt64("SectionName:Int64:Nope", out long value2);
        Assert.IsFalse(result2);
        Assert.AreEqual(0, value2);

        bool result3 = config.TryGetInt64("SectionName:Int64", out long? value3);
        Assert.IsTrue(result3);
        Assert.AreEqual(12345678, value3);

        bool result4 = config.TryGetInt64("SectionName:Int64:Nope", out long? value4);
        Assert.IsFalse(result4);
        Assert.IsNull(value4);

    }

    [TestMethod]
    public void GetString() {

        IConfiguration config = GetConfiguration();

        string? value1 = config.GetString("SectionName:String");
        Assert.AreEqual("Hello there!", value1);

        string? value2 = config.GetString("SectionName:String:Nope");
        Assert.IsNull(value2);

    }

    [TestMethod]
    public void GetRequiredString() {

        IConfiguration config = GetConfiguration();

        string? value1 = config.GetRequiredString("SectionName:String");
        Assert.AreEqual("Hello there!", value1);

        Assert.ThrowsException<Exception>(() => {
            config.GetRequiredString("SectionName:String:Nope");
        });

    }

    [TestMethod]
    public void TryGetString() {

        IConfiguration config = GetConfiguration();

        bool result1 = config.TryGetString("SectionName:String", out string? value1);
        Assert.IsTrue(result1);
        Assert.AreEqual("Hello there!", value1);

        bool result2 = config.TryGetString("SectionName:String:Nope", out string? value2);
        Assert.IsFalse(result2);
        Assert.IsNull(value2);

    }

    private static double ToPrecision(double value, int decimals) {
        double meh = Math.Pow(10, decimals);
        return Math.Round(value * meh) / meh;
    }

    private static double? ToPrecision(double? value, int decimals) {
        if (value is null) return null;
        double meh = Math.Pow(10, decimals);
        return Math.Round(value.Value * meh) / meh;
    }

    private static IConfiguration GetConfiguration() {

        Dictionary<string, string> values = new() {
            {"SectionName:Double", "1234.5678"},
            {"SectionName:Float", "1234.5678"},
            {"SectionName:Guid", "2f056463-e36a-49d0-a712-1fcf870763fe"},
            {"SectionName:Int32", "1234"},
            {"SectionName:Int64", "12345678"},
            {"SectionName:String", "Hello there!"}
        };

        return new ConfigurationBuilder()
            .AddInMemoryCollection(values)
            .Build();

    }

}