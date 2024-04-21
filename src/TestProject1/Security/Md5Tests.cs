using System.Text;
using Skybrud.Essentials.Security;
using Skybrud.Essentials.Strings;

namespace TestProject1.Security;

[TestClass]
public class Md5Tests {

    [TestMethod]
    public void GetMd5Hash() {

        string a = SecurityUtils.GetMd5Hash("Hello there!");
        string b = SecurityUtils.GetMd5Hash("Hello there!", HexFormat.LowerCase);
        string c = SecurityUtils.GetMd5Hash("Hello there!", HexFormat.UpperCase);

        string d = SecurityUtils.GetMd5Hash("Hello there!", Encoding.UTF8);
        string e = SecurityUtils.GetMd5Hash("Hello there!", HexFormat.LowerCase, Encoding.UTF8);
        string f = SecurityUtils.GetMd5Hash("Hello there!", HexFormat.UpperCase, Encoding.UTF8);

        Assert.AreEqual("a77b55332699835c035957df17630d28", a, "#a");
        Assert.AreEqual("a77b55332699835c035957df17630d28", b, "#b");
        Assert.AreEqual("A77B55332699835C035957DF17630D28", c, "#c");

        Assert.AreEqual("a77b55332699835c035957df17630d28", d, "#d");
        Assert.AreEqual("a77b55332699835c035957df17630d28", e, "#e");
        Assert.AreEqual("A77B55332699835C035957DF17630D28", f, "#f");

    }

}