using System.Globalization;
using Skybrud.Essentials.Time;
using Skybrud.Essentials.Time.Iso8601;

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

    [TestMethod]
    public void FromTicks() {

        long ticks = 638959464000000000;

        EssentialsTime et1 = EssentialsTime.FromTicks(ticks, TimeSpan.Zero);
        Assert.AreEqual("2025-10-13T10:00:00.000Z", et1.Iso8601, "et1");

        EssentialsTime et2 = EssentialsTime.FromTicks(ticks, TimeZoneInfo.Utc);
        Assert.AreEqual("2025-10-13T10:00:00.000Z", et2.Iso8601, "et2");

        DateTime dt = new(ticks, DateTimeKind.Utc);
        Assert.AreEqual("2025-10-13T10:00:00.000Z", Iso8601Utils.ToString(dt), "dt");

        DateTimeOffset dto = new(ticks, TimeSpan.Zero);
        Assert.AreEqual("2025-10-13T10:00:00.000Z", Iso8601Utils.ToString(dto), "dto");

    }

}