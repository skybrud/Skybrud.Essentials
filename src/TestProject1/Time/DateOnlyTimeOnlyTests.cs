using Skybrud.Essentials.Time;

namespace TestProject1.Time;

[TestClass]
public class DateOnlyTimeOnlyTests {

    [TestMethod]
    public void EssentialsDate_RoundTrip() {

        DateOnly expected = new(2026, 10, 27);

        EssentialsDate date = EssentialsDate.FromDateOnly(expected);

        Assert.AreEqual(expected, date.ToDateOnly());
        Assert.AreEqual(expected, new EssentialsDate(expected).ToDateOnly());

    }

    [TestMethod]
    public void EssentialsTime_ExtractsDateAndTime() {

        DateOnly date = new(2026, 10, 27);
        TimeOnly time = new(14, 30, 45);

        EssentialsTime result = EssentialsTime.FromDateOnlyAndTimeOnly(
            date,
            time,
            TimeSpan.FromHours(2)
        );

        Assert.AreEqual(date, result.ToDateOnly());
        Assert.AreEqual(time, result.ToTimeOnly());
        Assert.AreEqual(TimeSpan.FromHours(2), result.Offset);

    }

    [TestMethod]
    public void EssentialsTime_PreservesSubsecondPrecision() {

        DateOnly date = new(2026, 10, 27);
        TimeOnly time = new TimeOnly(14, 30, 45).Add(TimeSpan.FromTicks(1234567));

        EssentialsTime result = EssentialsTime.FromDateOnlyAndTimeOnly(
            date,
            time,
            TimeSpan.Zero
        );

        Assert.AreEqual(time, result.ToTimeOnly());

    }

    [TestMethod]
    public void EssentialsTime_RejectsInvalidLocalTime() {

        TimeZoneInfo zone = TimeZoneInfo.CreateCustomTimeZone(
            "TestZone",
            TimeSpan.FromHours(1),
            "Test zone",
            "Standard",
            "Daylight",
            [
                TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(
                    new DateTime(2026, 1, 1),
                    new DateTime(2026, 12, 31),
                    TimeSpan.FromHours(1),
                    TimeZoneInfo.TransitionTime.CreateFixedDateRule(
                        new DateTime(1, 1, 1, 2, 0, 0),
                        3,
                        29
                    ),
                    TimeZoneInfo.TransitionTime.CreateFixedDateRule(
                        new DateTime(1, 1, 1, 3, 0, 0),
                        10,
                        25
                    )
                )
            ]
        );

        Assert.ThrowsException<ArgumentException>(() =>
            EssentialsTime.FromDateOnlyAndTimeOnly(
                new DateOnly(2026, 3, 29),
                new TimeOnly(2, 30),
                zone
            )
        );

    }

}