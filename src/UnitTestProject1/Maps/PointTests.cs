using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Maps;
using Skybrud.Essentials.Maps.Geometry;

namespace UnitTestProject1.Maps {

    [TestClass]
    public class PointTests {

        protected IPoint Limbo = new Point(55.714643, 9.531309);

        protected IPoint Equator = new Point(0, 9.531309);

        protected IPoint Greenwich = new Point(55.714643, 0);

        protected IPoint ZeroZero = new Point(0, 0);

        [TestMethod]
        public void LimboIsNullIsland() {
            Assert.AreEqual(false, Limbo.IsNullIsland());
        }

        [TestMethod]
        public void EquatorIsNullIsland() {
            Assert.AreEqual(false, Equator.IsNullIsland());
        }

        [TestMethod]
        public void GreenwichIsNullIsland() {
            Assert.AreEqual(false, Greenwich.IsNullIsland());
        }

        [TestMethod]
        public void ZeroZeroIsNullIsland() {
            Assert.AreEqual(true, ZeroZero.IsNullIsland());
        }

    }

}