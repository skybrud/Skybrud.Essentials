using System.Globalization;
using Skybrud.Essentials.Time;

// ReSharper disable UseStringInterpolation

namespace TestProject1.Time;

[TestClass]
public class EssentialsTimeTests {

    [TestMethod]
    public void ToStringDefault() {

        EssentialsTime time = new(2024, 3, 27, 12, 0, 0, TimeZoneInfo.Utc);

        Assert.AreEqual("2024-03-27T12:00:00.000Z", time.ToString(), "#1");
        Assert.AreEqual("2024-03-27T12:00:00.000Z", $"{time}", "#2");

    }

    [TestMethod]
    public void ToStringWithFormat() {

        EssentialsTime time = new(2024, 3, 27, 12, 0, 0, TimeZoneInfo.Utc);

        IFormattable formattable = time;

        Assert.AreEqual("2024-03-27 12:00:00", time.ToString("yyyy-MM-dd HH:mm:ss"), "#1");
        Assert.AreEqual("2024-03-27 12:00:00", string.Format("{0:yyyy-MM-dd HH:mm:ss}", time), "#2");
        Assert.AreEqual("2024-03-27 12:00:00", $"{time:yyyy-MM-dd HH:mm:ss}", "#3");
        Assert.AreEqual("2024-03-27 12:00:00", formattable.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture), "#4");

    }

}