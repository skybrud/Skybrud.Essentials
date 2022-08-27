using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Reflection.Extensions;
using Skybrud.Essentials.Time;

namespace UnitTestProject1 {

    [TestClass]
    public class ExtensionTests {

        [TestMethod]
        public void PublicMethodMustHaveThisKeyword() {

            foreach (var type in typeof(EssentialsTime).Assembly.GetTypes().Where(x => x.IsExtensionClass())) {

                foreach (var method in type.GetMethods(BindingFlags.Public | BindingFlags.Static)) {

                    Assert.IsTrue(method.IsExtensionMethod(), $"Public static method is missing 'this' keyword.\r\n\r\nType: " + type + "\r\n" + method);

                }

            }

        }

    }

}