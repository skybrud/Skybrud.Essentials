using System.Globalization;
using Skybrud.Essentials.Time;

// ReSharper disable UseStringInterpolation

namespace TestProject1.Time;

[TestClass]
public class EssentialsDateTests {

    [TestMethod]
    public void ToStringDefault() {

        EssentialsDate date = new(2024, 3, 27);

        Assert.AreEqual("2024-03-27", date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture), "#1");
        Assert.AreEqual("2024-03-27", date.ToString("yyyy-MM-dd", CultureInfo.GetCultureInfo("da-DK")), "#2");
        Assert.AreEqual("2024-03-27", $"{date}", "#3");

    }

    [TestMethod]
    public void ToStringWithFormat() {

        EssentialsDate date = new(2024, 3, 27);

        IFormattable formattable = date;

        Assert.AreEqual("2024_03_27", date.ToString("yyyy_MM_dd"), "#1");
        Assert.AreEqual("2024_03_27", string.Format("{0:yyyy_MM_dd}", date), "#2");
        Assert.AreEqual("2024_03_27", $"{date:yyyy_MM_dd}", "#3");
        Assert.AreEqual("2024_03_27", formattable.ToString("yyyy_MM_dd", CultureInfo.InvariantCulture), "#4");

    }

    [TestMethod]
    public void TryParse() {

        bool success1 = EssentialsDate.TryParse("2024-03-27", out EssentialsDate? result1);

        // Since "EssentialsDate.TryParse" uses "DateTime.TryParse" internally, we don't support "yyyyMMdd". But maybe
        // this format should be supported as well?
        bool success2 = EssentialsDate.TryParse("20240327", out EssentialsDate? result2);

        Assert.IsTrue(success1, "Success 1");
        Assert.IsNotNull(result1, "Result #1");
        Assert.AreEqual("2024-03-27", result1.ToString("yyyy-MM-dd"), "Result #1");

        Assert.IsFalse(success2, "Success 2");
        Assert.IsNull(result2, "Result #2");

    }

}