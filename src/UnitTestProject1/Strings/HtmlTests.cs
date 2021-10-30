using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;
using System.Web;

namespace UnitTestProject1.Strings {
    
    [TestClass]
    public class HtmlTests {

        [TestMethod]
        public void StripHtml() {

            var samples = new[] {
                new { Input = default(string), Output = default(string) },
                new { Input = "", Output = "" },
                new { Input = "<p>Hello World</p>", Output = "Hello World" },
                new { Input = "Hello<br />World", Output = "HelloWorld" },
                new { Input = "<p>Hello World &amp; Goodbye World</p>", Output = "Hello World & Goodbye World" }
            };

            foreach (var sample in samples) {
                
                Assert.AreEqual(sample.Output, StringUtils.StripHtml(sample.Input));

                Assert.AreEqual(sample.Output, sample.Input.StripHtml());

            }

        }

        [TestMethod]
        public void StripHtmlIgnore() {

            var samples = new[] {
                new { Input = default(string), Output = default(string), Ignore = new []{"strong"} },
                new { Input = "", Output = "", Ignore = new []{"strong"} },
                new { Input = "<p>Hello <strong>World</strong></p>", Output = "Hello <strong>World</strong>", Ignore = new []{"strong"} },
                new { Input = "<ul><li><a href=\"#hest\"><strong>Hest</strong><br /></a></li></ul>", Output = "<a href=\"#hest\">Hest</a>", Ignore = new []{"a"} }
            };

            foreach (var sample in samples) {

                Assert.AreEqual(sample.Output, StringUtils.StripHtml(sample.Input, sample.Ignore));

                Assert.AreEqual(sample.Output, sample.Input.StripHtml(sample.Ignore));

            }

        }

        [TestMethod]
        public void ReplaceLineBreaks() {

            var samples = new[] {
                new { Input = default(string), Output = default(string) },
                new { Input = "", Output = "" },
                new { Input = "Hello\rWorld", Output = "Hello<br />World" },
                new { Input = "Hello\nWorld", Output = "Hello<br />World" },
                new { Input = "Hello\r\nWorld", Output = "Hello<br />World" }
            };

            foreach (var sample in samples) {

                Assert.AreEqual(sample.Output, StringUtils.ReplaceLineBreaks(sample.Input));

                Assert.AreEqual(sample.Output, sample.Input.ReplaceLineBreaks());

            }

        }

        [TestMethod]
        public void ToHtmlString() {

            var samples = new[] {
                new { Input = default(string), Output = "" },
                new { Input = "", Output = "" },
                new { Input = "<div>Hello World</div>", Output = "<div>Hello World</div>" }
            };

            foreach (var sample in samples) {

                IHtmlString html = sample.Input.ToHtmlString();

                Assert.AreEqual(sample.Output, html.ToHtmlString());

            }

        }

    }

}