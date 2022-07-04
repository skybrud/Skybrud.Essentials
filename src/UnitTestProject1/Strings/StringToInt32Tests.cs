using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Strings;

namespace UnitTestProject1.Strings {

    [TestClass]
    public class StringToInt32Tests {

        [TestMethod]
        public void TryParse() {

            var samples = new[] {
                new { Input = default(string), Output = false, Result = 0 },
                new { Input = string.Empty, Output = false, Result = 0 },
                new { Input = "1", Output = true, Result = 1 },
                new { Input = "2", Output = true, Result = 2 },
                new { Input = "3", Output = true, Result = 3 },
                new { Input = "3.00", Output = true, Result = 3 },
                new { Input = "3.14", Output = false, Result = 0 },
                new { Input = " 1 ", Output = true, Result = 1 },
                new { Input = "2147483647", Output = true, Result = int.MaxValue },
                new { Input = "2147483648", Output = false, Result = 0 },
                new { Input = "aaa", Output = false, Result = 0 },
            };


            int n = 1;

            foreach (var sample in samples) {

                bool output = StringUtils.TryParseInt32(sample.Input, out int result);

                Assert.AreEqual(sample.Output, output, $"#{n} Output ({sample.Input ?? "NULL"})");
                Assert.AreEqual(sample.Result, result, $"#{n} Result ({sample.Input ?? "NULL"})");

                n++;

            }


        }

        [TestMethod]
        public void TryParseNullable() {

            var samples = new[] {
                new { Input = default(string), Output = false, Result = default(int?) },
                new { Input = string.Empty, Output = false, Result = default(int?) },
                new { Input = "1", Output = true, Result = (int?) 1 },
                new { Input = "2", Output = true, Result = (int?) 2 },
                new { Input = "3", Output = true, Result = (int?) 3 },
                new { Input = "3.00", Output = true, Result = (int?) 3 },
                new { Input = "3.14", Output = false, Result = default(int?) },
                new { Input = " 1 ", Output = true, Result = (int?) 1 },
                new { Input = "2147483647", Output = true, Result = (int?) int.MaxValue },
                new { Input = "2147483648", Output = false, Result = default(int?) },
                new { Input = "aaa", Output = false, Result = default(int?) },
            };


            int n = 1;

            foreach (var sample in samples) {

                bool output = StringUtils.TryParseInt32(sample.Input, out int? result);

                Assert.AreEqual(sample.Output, output, $"#{n} Output ({sample.Input ?? "NULL"})");
                Assert.AreEqual(sample.Result, result, $"#{n} Result ({sample.Input ?? "NULL"})");

                n++;

            }


        }

    }

}