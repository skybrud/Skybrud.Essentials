using Skybrud.Essentials.Time.Iso8601;

namespace TestProject1.Time;

[TestClass]
public class Iso8601Tests {

    [TestMethod]
    public void Parse() {

        // Initialize some reference timestamps
        DateTimeOffset reference0 = new(2026, 11, 19, 15, 40, 27, TimeSpan.Zero);
        DateTimeOffset reference1 = reference0.AddTicks(1000000);
        DateTimeOffset reference2 = reference0.AddTicks(1200000);
        DateTimeOffset reference3 = reference0.AddTicks(1230000);
        DateTimeOffset reference4 = reference0.AddTicks(1234000);
        DateTimeOffset reference5 = reference0.AddTicks(1234500);
        DateTimeOffset reference6 = reference0.AddTicks(1234560);
        DateTimeOffset reference7 = reference0.AddTicks(1234567);

        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27+00:00"));
        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27.0+00:00"));
        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27.00+00:00"));
        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27.000+00:00"));
        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27.0000+00:00"));
        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27.00000+00:00"));
        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27.000000+00:00"));
        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27.0000000+00:00"));

        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27.0+00:00"));
        Assert.AreEqual(reference1, Iso8601Utils.Parse("2026-11-19T15:40:27.1+00:00"));
        Assert.AreEqual(reference2, Iso8601Utils.Parse("2026-11-19T15:40:27.12+00:00"));
        Assert.AreEqual(reference3, Iso8601Utils.Parse("2026-11-19T15:40:27.123+00:00"));
        Assert.AreEqual(reference4, Iso8601Utils.Parse("2026-11-19T15:40:27.1234+00:00"));
        Assert.AreEqual(reference5, Iso8601Utils.Parse("2026-11-19T15:40:27.12345+00:00"));
        Assert.AreEqual(reference6, Iso8601Utils.Parse("2026-11-19T15:40:27.123456+00:00"));
        Assert.AreEqual(reference7, Iso8601Utils.Parse("2026-11-19T15:40:27.1234567+00:00"));

        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27Z"));
        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27.0Z"));
        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27.00Z"));
        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27.000Z"));
        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27.0000Z"));
        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27.00000Z"));
        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27.000000Z"));
        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27.0000000Z"));

        Assert.AreEqual(reference0, Iso8601Utils.Parse("2026-11-19T15:40:27.0Z"));
        Assert.AreEqual(reference1, Iso8601Utils.Parse("2026-11-19T15:40:27.1Z"));
        Assert.AreEqual(reference2, Iso8601Utils.Parse("2026-11-19T15:40:27.12Z"));
        Assert.AreEqual(reference3, Iso8601Utils.Parse("2026-11-19T15:40:27.123Z"));
        Assert.AreEqual(reference4, Iso8601Utils.Parse("2026-11-19T15:40:27.1234Z"));
        Assert.AreEqual(reference5, Iso8601Utils.Parse("2026-11-19T15:40:27.12345Z"));
        Assert.AreEqual(reference6, Iso8601Utils.Parse("2026-11-19T15:40:27.123456Z"));
        Assert.AreEqual(reference7, Iso8601Utils.Parse("2026-11-19T15:40:27.1234567Z"));

    }

}