using Skybrud.Essentials.Time;

namespace TestProject1.Time;

[TestClass]
public class EssentialsMonthTests {

    [TestMethod]
    public void ToStringDefault() {

        EssentialsMonth month = new(2024, 3);

        Assert.AreEqual("2024-03", month.ToString());

    }

}