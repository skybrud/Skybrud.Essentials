using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Essentials.Time;

namespace TestProject1.Strings;

[TestClass]
public class ToInvariantStringTests {

    [TestMethod]
    public void Int32() {
        Assert.AreEqual("1234", 1234.ToInvariantString());
        Assert.AreEqual("1,234", 1234.ToInvariantString("N0"));
    }

    [TestMethod]
    public void DateTime() {
        DateTime dt = new(2025, 10, 16, 14, 7, 2, DateTimeKind.Utc);
        Assert.AreEqual("10/16/2025 14:07:02", dt.ToInvariantString());
        Assert.AreEqual("2025-10-16", dt.ToInvariantString("yyyy-MM-dd"));
        Assert.AreEqual("October", dt.ToInvariantString("MMMM"));
        Assert.AreEqual("Thursday", dt.ToInvariantString("dddd"));
    }

    [TestMethod]
    public void DateTimeNullable() {
        DateTime? dt = new(2025, 10, 16, 14, 7, 2, DateTimeKind.Utc);
        Assert.AreEqual("10/16/2025 14:07:02", dt.ToInvariantString());
        Assert.AreEqual("2025-10-16", dt.ToInvariantString("yyyy-MM-dd"));
        Assert.AreEqual("October", dt.ToInvariantString("MMMM"));
        Assert.AreEqual("Thursday", dt.ToInvariantString("dddd"));
    }

    [TestMethod]
    public void DateTimeOffset() {
        DateTimeOffset dto = new(2025, 10, 16, 14, 7, 2, TimeSpan.Zero);
        Assert.AreEqual("10/16/2025 14:07:02 +00:00", dto.ToInvariantString());
        Assert.AreEqual("2025-10-16", dto.ToInvariantString("yyyy-MM-dd"));
        Assert.AreEqual("October", dto.ToInvariantString("MMMM"));
        Assert.AreEqual("Thursday", dto.ToInvariantString("dddd"));
    }

    [TestMethod]
    public void DateTimeOffsetNullable() {
        DateTimeOffset? dto = new(2025, 10, 16, 14, 7, 2, TimeSpan.Zero);
        Assert.AreEqual("10/16/2025 14:07:02 +00:00", dto.ToInvariantString());
        Assert.AreEqual("2025-10-16", dto.ToInvariantString("yyyy-MM-dd"));
        Assert.AreEqual("October", dto.ToInvariantString("MMMM"));
        Assert.AreEqual("Thursday", dto.ToInvariantString("dddd"));
    }

    [TestMethod]
    public void EssentialsTime() {
        EssentialsTime dto = new(2025, 10, 16, 14, 7, 2, TimeSpan.Zero);
        Assert.AreEqual("2025-10-16T14:07:02.000Z", dto.ToInvariantString());
        Assert.AreEqual("2025-10-16", dto.ToInvariantString("yyyy-MM-dd"));
        Assert.AreEqual("October", dto.ToInvariantString("MMMM"));
        Assert.AreEqual("Thursday", dto.ToInvariantString("dddd"));
    }

}