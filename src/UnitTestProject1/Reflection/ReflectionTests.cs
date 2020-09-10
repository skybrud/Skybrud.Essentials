using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Locations;
using Skybrud.Essentials.Maps.Geometry;
using Skybrud.Essentials.Reflection;

using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

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

        [TestMethod]
        public void HasCustomAttribute() {

            bool success = ReflectionUtils.HasCustomAttribute(EnumTest.WithDescription, out DescriptionAttribute result);

            Assert.AreEqual(true, success);
            Assert.AreEqual("A description.", result.Description);

        }

        [TestMethod]
        public void EnumHasCustomAttributes() {

            bool success = ReflectionUtils.HasCustomAttributes(EnumTest.WithDescription, out DescriptionAttribute[] result);

            Assert.AreEqual(true, success);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual("A description.", result[0].Description);

        }

        [TestMethod]
        public void EnumGetCustomAttributes() {

            DescriptionAttribute[] attributes1 = ReflectionUtils.GetCustomAttributes<DescriptionAttribute>(EnumTest.WithDescription);

            ObsoleteAttribute[] attributes2 = ReflectionUtils.GetCustomAttributes<ObsoleteAttribute>(EnumTest.IsObsolete);

            Assert.AreEqual(1, attributes1.Length);
            Assert.AreEqual("A description.", attributes1[0].Description);

            Assert.AreEqual(1, attributes2.Length);
            Assert.AreEqual("This is obsolete.", attributes2[0].Message);

        }

        public enum EnumTest {

            [Description("A description.")]
            WithDescription,

            [Obsolete("This is obsolete.")]
            IsObsolete

        }

    }

}