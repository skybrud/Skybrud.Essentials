using Skybrud.Essentials.Collections;

namespace TestProject1.Collections {

    [TestClass]
    public class ArrayUtilsTests {

        [TestMethod]
        public void EmptyStringArray() {

            Array array = ArrayUtils.Empty(typeof(string));

            Assert.IsNotNull(array);
            Assert.AreEqual(0, array.Length);

            Assert.AreEqual(typeof(string[]), array.GetType());

        }

    }

}