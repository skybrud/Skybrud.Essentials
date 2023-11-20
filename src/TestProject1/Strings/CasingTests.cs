using System.Globalization;
using Skybrud.Essentials.Strings.Extensions;

namespace TestProject1.Strings;

[TestClass]
public class CasingTests {

    [TestMethod]
    public void ToTitleCase() {

        const string phrase = "The quick brown fox jumps over the lazy dog";

        string result1 = phrase.ToTitleCase();
        string expected1 = "The Quick Brown Fox Jumps Over The Lazy Dog";

        string result2 = phrase.ToTitleCase(CultureInfo.GetCultureInfo("en-GB"));
        string expected2 = "The Quick Brown Fox Jumps Over The Lazy Dog";

        string result3 = phrase.ToTitleCase(CultureInfo.GetCultureInfo("en-US"));
        string expected3 = "The Quick Brown Fox Jumps Over The Lazy Dog";

        string result4 = phrase.ToTitleCase(CultureInfo.GetCultureInfo("da-DK"));
        string expected4 = "The Quick Brown Fox Jumps Over The Lazy Dog";

        Assert.AreEqual(expected1, result1, "Invariant");
        Assert.AreEqual(expected2, result2, "en-GB");
        Assert.AreEqual(expected3, result3, "en-US");
        Assert.AreEqual(expected4, result4, "da-DK");

    }

}