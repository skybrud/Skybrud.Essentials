using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Locations;
using Skybrud.Essentials.Maps.Geometry;
using Skybrud.Essentials.Reflection;

#pragma warning disable 618

namespace UnitTestProject1.Reflection {
    
    [TestClass]
    public class ReflectionTests {

        [TestMethod]
        public void IsClass() {

            Assert.IsTrue(ReflectionUtils.IsClass(typeof(JsonObjectBase)));
            Assert.IsTrue(ReflectionUtils.IsClass<JsonObjectBase>());

            Assert.IsFalse(ReflectionUtils.IsClass(typeof(SortOrder)));
            Assert.IsFalse(ReflectionUtils.IsClass<SortOrder>());

            Assert.IsFalse(ReflectionUtils.IsClass(typeof(IPoint)));
            Assert.IsFalse(ReflectionUtils.IsClass<IPoint>());

        }

        [TestMethod]
        public void IsInterface() {

            Assert.IsFalse(ReflectionUtils.IsInterface(typeof(JsonObjectBase)));
            Assert.IsFalse(ReflectionUtils.IsInterface<JsonObjectBase>());

            Assert.IsFalse(ReflectionUtils.IsInterface(typeof(SortOrder)));
            Assert.IsFalse(ReflectionUtils.IsInterface<SortOrder>());

            Assert.IsTrue(ReflectionUtils.IsInterface(typeof(IPoint)));
            Assert.IsTrue(ReflectionUtils.IsInterface<IPoint>());

        }

        [TestMethod]
        public void IsEnum() {

            Assert.IsFalse(ReflectionUtils.IsEnum(typeof(JsonObjectBase)));
            Assert.IsFalse(ReflectionUtils.IsEnum<JsonObjectBase>());

            Assert.IsTrue(ReflectionUtils.IsEnum(typeof(SortOrder)));
            Assert.IsTrue(ReflectionUtils.IsEnum<SortOrder>());

            Assert.IsFalse(ReflectionUtils.IsEnum(typeof(IPoint)));
            Assert.IsFalse(ReflectionUtils.IsEnum<IPoint>());

        }

        [TestMethod]
        public void IsObsolete() {

            Assert.IsFalse(ReflectionUtils.IsObsolete(typeof(JsonObjectBase)));
            Assert.IsFalse(ReflectionUtils.IsObsolete<JsonObjectBase>());

            Assert.IsTrue(ReflectionUtils.IsObsolete(typeof(EssentialsLocation)));
            Assert.IsTrue(ReflectionUtils.IsObsolete<EssentialsLocation>());

            Assert.IsFalse(ReflectionUtils.IsEnum(typeof(IPoint)));
            Assert.IsFalse(ReflectionUtils.IsEnum<IPoint>());

        }

    }

}