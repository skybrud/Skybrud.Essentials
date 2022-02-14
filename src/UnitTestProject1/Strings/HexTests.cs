using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Strings;
using System.Text;

namespace UnitTestProject1.Strings {
    
    [TestClass]
    public class HexTests {

        [TestMethod]
        public void ToHexString() {
            
            byte[] bytes1 = Encoding.UTF8.GetBytes("hello world");
            byte[] bytes2 = Encoding.UTF8.GetBytes("rød grød med fløde");
            byte[] bytes3 = Encoding.GetEncoding(1252).GetBytes("rød grød med fløde");
            
            string result1 = StringUtils.ToHexString(bytes1);
            string result2 = StringUtils.ToHexString(bytes2);
            string result3 = StringUtils.ToHexString(bytes3);
            
            Assert.AreEqual("68656c6c6f20776f726c64", result1, "#1");
            Assert.AreEqual("72c3b864206772c3b864206d656420666cc3b86465", result2, "#2");
            Assert.AreEqual("72f864206772f864206d656420666cf86465", result3, "#3");

        }

        [TestMethod]
        public void ParseHexString() {
            
            string hex1 = "68656c6c6f20776f726c64";
            string hex2 = "72c3b864206772c3b864206d656420666cc3b86465";
            string hex3 = "72f864206772f864206d656420666cf86465";
            
            byte[] result1 = StringUtils.ParseHexString(hex1);
            byte[] result2 = StringUtils.ParseHexString(hex2);
            byte[] result3 = StringUtils.ParseHexString(hex3);
            
            string str1 = Encoding.UTF8.GetString(result1);
            string str2 = Encoding.UTF8.GetString(result2);
            string str3 = Encoding.GetEncoding(1252).GetString(result3);
            
            Assert.AreEqual("hello world", str1, "#1");
            Assert.AreEqual("rød grød med fløde", str2, "#2");
            Assert.AreEqual("rød grød med fløde", str3, "#3");

        }

        [TestMethod]
        public void ParseHexStringWithHypens() {
            
            string hex1 = "68-65-6c-6c-6f-20-77-6f-72-6c-64";
            string hex2 = "72-c3-b8-64-20-67-72-c3-b8-64-20-6d-65-64-20-66-6c-c3-b8-64-65";
            string hex3 = "72-f8-64-20-67-72-f8-64-20-6d-65-64-20-66-6c-f8-64-65";
            
            byte[] result1 = StringUtils.ParseHexString(hex1);
            byte[] result2 = StringUtils.ParseHexString(hex2);
            byte[] result3 = StringUtils.ParseHexString(hex3);
            
            string str1 = Encoding.UTF8.GetString(result1);
            string str2 = Encoding.UTF8.GetString(result2);
            string str3 = Encoding.GetEncoding(1252).GetString(result3);
            
            Assert.AreEqual("hello world", str1, "#1");
            Assert.AreEqual("rød grød med fløde", str2, "#2");
            Assert.AreEqual("rød grød med fløde", str3, "#3");

        }

    }

}