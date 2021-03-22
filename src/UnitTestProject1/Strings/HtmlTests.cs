using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Strings;

namespace UnitTestProject1.Strings {
    
    [TestClass]
    public class HtmlTests {

        [TestMethod]
        public void StripHtml() {

            var samples = new[] {
                new { Input = default(string), Output = "" },
                new { Input = "", Output = "" },
                new { Input = "<p>Hello World</p>", Output = "Hello World" },
                new { Input = "Hello<br />World", Output = "HelloWorld" },
                new { Input = "<p>Hello World &amp; Goodbye World</p>", Output = "Hello World & Goodbye World" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Output, StringUtils.StripHtml(sample.Input));
            }

        }

        [TestMethod]
        public void StripHtmlIgnore() {

            var samples = new[] {
                new { Input = default(string), Output = "", Ignore = new []{"strong"} },
                new { Input = "", Output = "", Ignore = new []{"strong"} },
                new { Input = "<p>Hello <strong>World</strong></p>", Output = "Hello <strong>World</strong>", Ignore = new []{"strong"} },
                new { Input = "<ul><li><a href=\"#hest\"><strong>Hest</strong><br /></a></li></ul>", Output = "<a href=\"#hest\">Hest</a>", Ignore = new []{"a"} }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Output, StringUtils.StripHtml(sample.Input, sample.Ignore));
            }

        }

    }

}