using Skybrud.Essentials.Time;

namespace TestProject1.Time;

[TestClass]
public class EssentialsWeekTests {

    [TestMethod]
    public void ToStringDefault() {

        EssentialsWeek week = new(2024, 13);

        Assert.AreEqual("2024-W13", week.ToString());

    }

}