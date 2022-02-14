using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Security;
using Skybrud.Essentials.Strings;
using System.Text;

namespace UnitTestProject1.Security {

    [TestClass]
    public class SecurityTests {

#pragma warning disable 618

        [TestMethod]
        public void Base64Encode() {

            var samples = new[] {
                new { Input = "Hello World", Expected = "SGVsbG8gV29ybGQ=" },
                new { Input = "Rød grød med fløde", Expected = "UsO4ZCBncsO4ZCBtZWQgZmzDuGRl" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, SecurityHelper.Base64Encode(sample.Input));
                Assert.AreEqual(sample.Expected, SecurityUtils.Base64Encode(sample.Input));
            }

        }

        [TestMethod]
        public void Base64Decode() {

            var samples = new[] {
                new { Input = "SGVsbG8gV29ybGQ=", Expected = "Hello World" },
                new { Input = "UsO4ZCBncsO4ZCBtZWQgZmzDuGRl", Expected = "Rød grød med fløde" }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, SecurityHelper.Base64Decode(sample.Input));
                Assert.AreEqual(sample.Expected, SecurityUtils.Base64Decode(sample.Input));
            }

        }

        [TestMethod]
        public void GetMd5Hash() {

            var samples = new[] {
                new { Input = "Hello World", Expected = "b10a8db164e0754105b7a99be72e3fe5" },
                new { Input = "Rød grød med fløde", Expected = "64d6f69ac402593bc004c8adf3db4b22" }
            };

            foreach (var sample in samples) {

                Assert.AreEqual(sample.Expected, SecurityHelper.GetMd5Hash(sample.Input), "Failed hashing " + sample.Input + " (no encoding)");
                Assert.AreEqual(sample.Expected, SecurityHelper.GetMd5Hash(sample.Input, Encoding.UTF8), "Failed hashing " + sample.Input + " (UTF8)");

                Assert.AreEqual(sample.Expected, SecurityUtils.GetMd5Hash(sample.Input), "Failed hashing " + sample.Input + " (no encoding)");
                Assert.AreEqual(sample.Expected, SecurityUtils.GetMd5Hash(sample.Input, Encoding.UTF8), "Failed hashing " + sample.Input + " (UTF8)");

            }

        }

        [TestMethod]
        public void GetSha1Hash() {

            var samples = new[] {
                new { Input = "Hello World", Expected = "0a4d55a8d778e5022fab701977c5d840bbc486d0" },
                new { Input = "Rød grød med fløde", Expected = "20a219e95c358780bfc974bd47ae13ba49a6e871" }
            };

            foreach (var sample in samples) {

                Assert.AreEqual(sample.Expected, SecurityHelper.GetSha1Hash(sample.Input), "Failed hashing " + sample.Expected + " (no encoding)");
                Assert.AreEqual(sample.Expected, SecurityHelper.GetSha1Hash(sample.Input, Encoding.UTF8), "Failed hashing " + sample.Expected + " (UTF8)");

                Assert.AreEqual(sample.Expected, SecurityUtils.GetSha1Hash(sample.Input), "Failed hashing " + sample.Expected + " (no encoding)");
                Assert.AreEqual(sample.Expected, SecurityUtils.GetSha1Hash(sample.Input, Encoding.UTF8), "Failed hashing " + sample.Expected + " (UTF8)");

            }

        }

        [TestMethod]
        public void GetSha256Hash() {

            var samples = new[] {
                new { Input = "Hello World", Expected = "a591a6d40bf420404a011733cfb7b190d62c65bf0bcda32b57b277d9ad9f146e" },
                new { Input = "Rød grød med fløde", Expected = "16037d3adef43eb338b1b96bb6ee1211c5906bdb671a5aae92be62a744ada72b" }
            };

            foreach (var sample in samples) {

                Assert.AreEqual(sample.Expected, SecurityHelper.GetSha256Hash(sample.Input), "Failed hashing " + sample.Expected + " (no encoding)");
                Assert.AreEqual(sample.Expected, SecurityHelper.GetSha256Hash(sample.Input, Encoding.UTF8), "Failed hashing " + sample.Expected + " (UTF8)");

                Assert.AreEqual(sample.Expected, SecurityUtils.GetSha256Hash(sample.Input), "Failed hashing " + sample.Expected + " (no encoding)");
                Assert.AreEqual(sample.Expected, SecurityUtils.GetSha256Hash(sample.Input, Encoding.UTF8), "Failed hashing " + sample.Expected + " (UTF8)");

            }

        }

        [TestMethod]
        public void GetSha512Hash() {

            var samples = new[] {
                new { Input = "Hello World", Expected = "2c74fd17edafd80e8447b0d46741ee243b7eb74dd2149a0ab1b9246fb30382f27e853d8585719e0e67cbda0daa8f51671064615d645ae27acb15bfb1447f459b" },
                new { Input = "Rød grød med fløde", Expected = "23d6e34e1a04aff3c4971d9666d4b4e490dda54ea4241083dc4f18f9bd813333de4731c90ea6c9b7913cc42cd0a9f5b8bd734b07cad5fb5359de4db3e9bb7476" }
            };

            foreach (var sample in samples) {

                Assert.AreEqual(sample.Expected, SecurityHelper.GetSha512Hash(sample.Input), "Failed hashing " + sample.Expected + " (no encoding)");
                Assert.AreEqual(sample.Expected, SecurityHelper.GetSha512Hash(sample.Input, Encoding.UTF8), "Failed hashing " + sample.Expected + " (UTF8)");

                Assert.AreEqual(sample.Expected, SecurityUtils.GetSha512Hash(sample.Input), "Failed hashing " + sample.Expected + " (no encoding)");
                Assert.AreEqual(sample.Expected, SecurityUtils.GetSha512Hash(sample.Input, Encoding.UTF8), "Failed hashing " + sample.Expected + " (UTF8)");

            }

        }

        [TestMethod]
        public void GetHmacSha1Hash() {

            string key = "hi";
            string value = "hello world";

            string expected1 = "164bdb73753c4f950472e58354d20badfca10ed5";
            string expected2 = expected1;
            string expected3 = expected1.ToUpper();

            string result1 = SecurityUtils.GetHmacSha1Hash(key, value);
            Assert.AreEqual(expected1, result1, "#1");

            string result2 = SecurityUtils.GetHmacSha1Hash(key, value, HexFormat.LowerCase);
            Assert.AreEqual(expected2, result2, "#2");

            string result3 = SecurityUtils.GetHmacSha1Hash(key, value, HexFormat.UpperCase);
            Assert.AreEqual(expected3, result3, "#3");

            key = "rødbede";
            value = "rød grød med fløde";

            expected1 = "d2fcbbcc313efab5c36e6583a9d7738b84e744fa";
            expected2 = expected1;
            expected3 = expected1.ToUpper();

            string result4 = SecurityUtils.GetHmacSha1Hash(key, value, Encoding.UTF8);
            Assert.AreEqual(expected1, result4, "#4");

            string result5 = SecurityUtils.GetHmacSha1Hash(key, value, HexFormat.LowerCase, Encoding.UTF8);
            Assert.AreEqual(expected2, result5, "#5");

            string result6 = SecurityUtils.GetHmacSha1Hash(key, value, HexFormat.UpperCase, Encoding.UTF8);
            Assert.AreEqual(expected3, result6, "#6");

        }

        [TestMethod]
        public void GetHmacSha256Hash() {

            string key = "hi";
            string value = "hello world";

            string expected1 = "88970eda57442ac99f3d44d3494fb883e23715c742ecd192083e28b8c6232a4c";
            string expected2 = expected1;
            string expected3 = expected1.ToUpper();

            string result1 = SecurityUtils.GetHmacSha256Hash(key, value);
            Assert.AreEqual(expected1, result1, "#1");

            string result2 = SecurityUtils.GetHmacSha256Hash(key, value, HexFormat.LowerCase);
            Assert.AreEqual(expected2, result2, "#2");

            string result3 = SecurityUtils.GetHmacSha256Hash(key, value, HexFormat.UpperCase);
            Assert.AreEqual(expected3, result3, "#3");

            key = "rødbede";
            value = "rød grød med fløde";

            expected1 = "05ae05d0750939c579dee0948a81cd80cb205f3bbb19d7153015573f28cd0e55";
            expected2 = expected1;
            expected3 = expected1.ToUpper();

            string result4 = SecurityUtils.GetHmacSha256Hash(key, value, Encoding.UTF8);
            Assert.AreEqual(expected1, result4, "#4");

            string result5 = SecurityUtils.GetHmacSha256Hash(key, value, HexFormat.LowerCase, Encoding.UTF8);
            Assert.AreEqual(expected2, result5, "#5");

            string result6 = SecurityUtils.GetHmacSha256Hash(key, value, HexFormat.UpperCase, Encoding.UTF8);
            Assert.AreEqual(expected3, result6, "#6");

        }

        [TestMethod]
        public void GetHmacSha512Hash() {

            string key = "hi";
            string value = "hello world";

            string expected1 = "9d4b7aec5e364bdafada54d18ec7ba858b2eabf92a39cb5ca64baedae67b659c2a826aa919c2d4b19fe6c3fdc3bf1b82c7b5b11a9bcfe3eb0c1cbff71cc8e106";
            string expected2 = expected1;
            string expected3 = expected1.ToUpper();

            string result1 = SecurityUtils.GetHmacSha512Hash(key, value);
            Assert.AreEqual(expected1, result1, "#1");

            string result2 = SecurityUtils.GetHmacSha512Hash(key, value, HexFormat.LowerCase);
            Assert.AreEqual(expected2, result2, "#2");

            string result3 = SecurityUtils.GetHmacSha512Hash(key, value, HexFormat.UpperCase);
            Assert.AreEqual(expected3, result3, "#3");

            key = "rødbede";
            value = "rød grød med fløde";

            expected1 = "0e9c50aeabe283b108ff6253c7542c7171f18e830a6d2ca5e4190d8f7ff526bdf6805a736afe0d65f7a296efca46882efb59d01563d7a549473964e72e79a70b";
            expected2 = expected1;
            expected3 = expected1.ToUpper();

            string result4 = SecurityUtils.GetHmacSha512Hash(key, value, Encoding.UTF8);
            Assert.AreEqual(expected1, result4, "#4");

            string result5 = SecurityUtils.GetHmacSha512Hash(key, value, HexFormat.LowerCase, Encoding.UTF8);
            Assert.AreEqual(expected2, result5, "#5");

            string result6 = SecurityUtils.GetHmacSha512Hash(key, value, HexFormat.UpperCase, Encoding.UTF8);
            Assert.AreEqual(expected3, result6, "#6");

        }

#pragma warning restore 618

    }

}