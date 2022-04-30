using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Assemblies;
using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Json;
using Skybrud.Essentials.Locations;
using Skybrud.Essentials.Maps.Geometry;
using Skybrud.Essentials.Reflection;
using Skybrud.Essentials.Reflection.Extensions;
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
        public void EnumIsObsolete() {

            Assert.IsFalse(ReflectionUtils.IsObsolete(EnumTest.WithDescription));
            Assert.IsTrue(ReflectionUtils.IsObsolete(EnumTest.IsObsolete));

            Assert.IsFalse(EnumTest.WithDescription.IsObsolete());
            Assert.IsTrue(EnumTest.IsObsolete.IsObsolete());

            Assert.IsFalse(ReflectionUtils.IsObsolete(EnumTest.WithDescription, out ObsoleteAttribute result1));
            Assert.IsNull(result1);

            Assert.IsTrue(ReflectionUtils.IsObsolete(EnumTest.IsObsolete, out ObsoleteAttribute result2));
            Assert.IsNotNull(result2);
            Assert.AreEqual("This is obsolete.", result2.Message);


            Assert.IsFalse(EnumTest.WithDescription.IsObsolete(out ObsoleteAttribute result3));
            Assert.IsNull(result3);

            Assert.IsTrue(EnumTest.IsObsolete.IsObsolete(out ObsoleteAttribute result4));
            Assert.IsNotNull(result4);
            Assert.AreEqual("This is obsolete.", result4.Message);

        }

        [TestMethod]
        public void MemberIsObsolete() {

            Assert.IsFalse(ReflectionUtils.IsObsolete(typeof(JsonObjectBase)));
            Assert.IsFalse(ReflectionUtils.IsObsolete<JsonObjectBase>());

            Assert.IsTrue(ReflectionUtils.IsObsolete(typeof(EssentialsLocation)));
            Assert.IsTrue(ReflectionUtils.IsObsolete<EssentialsLocation>());

            Assert.IsFalse(ReflectionUtils.IsEnum(typeof(IPoint)));
            Assert.IsFalse(ReflectionUtils.IsEnum<IPoint>());

        }

        [TestMethod]
        public void TypeIsObsolete() {

            Assert.IsFalse(ReflectionUtils.IsObsolete(typeof(JsonObjectBase)));
            Assert.IsFalse(ReflectionUtils.IsObsolete<JsonObjectBase>());

            Assert.IsTrue(ReflectionUtils.IsObsolete(typeof(EssentialsLocation)));
            Assert.IsTrue(ReflectionUtils.IsObsolete<EssentialsLocation>());

            Assert.IsFalse(ReflectionUtils.IsEnum(typeof(IPoint)));
            Assert.IsFalse(ReflectionUtils.IsEnum<IPoint>());

        }

        [TestMethod]
        public void EnumHasCustomAttribute() {

            bool success1 = ReflectionUtils.HasCustomAttribute<DescriptionAttribute>(EnumTest.WithDescription);
            Assert.AreEqual(true, success1);

            bool success2 = EnumTest.WithDescription.HasCustomAttribute<DescriptionAttribute>();
            Assert.AreEqual(true, success2);

            bool success3 = ReflectionUtils.HasCustomAttribute(EnumTest.WithDescription, out DescriptionAttribute result3);
            Assert.AreEqual(true, success3);
            Assert.AreEqual("A description.", result3.Description);

            bool success4 = EnumTest.WithDescription.HasCustomAttribute(out DescriptionAttribute result4);
            Assert.AreEqual(true, success4);
            Assert.AreEqual("A description.", result4.Description);

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

        [TestMethod]
        public void MemberHasCustomAttribute() {

            var member1 = typeof(AssemblyUtils).GetMember("GetVersion").First();
            var member2 = typeof(ReflectionUtils).GetMember("GetVersion").First();

            Assert.IsTrue(ReflectionUtils.HasCustomAttribute<ObsoleteAttribute>(member1));
            Assert.IsTrue(member1.HasCustomAttribute<ObsoleteAttribute>());

            Assert.IsTrue(ReflectionUtils.HasCustomAttribute(member1, out ObsoleteAttribute obsolete));
            Assert.IsNotNull(obsolete);
            Assert.AreEqual("Use ReflectionUtils.GetVersion() method instead.", obsolete.Message);

            Assert.IsTrue(member1.HasCustomAttribute(out obsolete));
            Assert.IsNotNull(obsolete);
            Assert.AreEqual("Use ReflectionUtils.GetVersion() method instead.", obsolete.Message);

            Assert.IsFalse(ReflectionUtils.HasCustomAttribute<ObsoleteAttribute>(member2));
            Assert.IsFalse(member2.HasCustomAttribute<ObsoleteAttribute>());

            Assert.IsFalse(ReflectionUtils.HasCustomAttribute(member2, out obsolete));
            Assert.IsNull(obsolete);

            Assert.IsFalse(member2.HasCustomAttribute(out obsolete));
            Assert.IsNull(obsolete);

        }

        [TestMethod]
        public void MemberGetCustomAttribute() {

            var member1 = typeof(AssemblyUtils).GetMember("GetVersion").First();
            var member2 = typeof(ReflectionUtils).GetMember("GetVersion").First();

            ObsoleteAttribute attribute1 = ReflectionUtils.GetCustomAttribute<ObsoleteAttribute>(member1);
            ObsoleteAttribute attribute2 = member1.GetCustomAttribute<ObsoleteAttribute>();

            ObsoleteAttribute attribute3 = ReflectionUtils.GetCustomAttribute<ObsoleteAttribute>(member2);
            ObsoleteAttribute attribute4 = member2.GetCustomAttribute<ObsoleteAttribute>();

            Assert.IsNotNull(attribute1, "#1");
            Assert.AreEqual("Use ReflectionUtils.GetVersion() method instead.", attribute1.Message, "#1");

            Assert.IsNotNull(attribute2, "#2");
            Assert.AreEqual("Use ReflectionUtils.GetVersion() method instead.", attribute2.Message, "#2");

            Assert.IsNull(attribute3, "#4");

            Assert.IsNull(attribute4, "#4");

        }

        [TestMethod]
        public void MemberGetCustomAttributes() {

            var member1 = typeof(AssemblyUtils).GetMember("GetVersion").First();
            var member2 = typeof(ReflectionUtils).GetMember("GetVersion").First();

            ObsoleteAttribute[] attributes1 = ReflectionUtils.GetCustomAttributes<ObsoleteAttribute>(member1);
            ObsoleteAttribute[] attributes2 = member1.GetCustomAttributes<ObsoleteAttribute>();

            ObsoleteAttribute[] attributes3 = ReflectionUtils.GetCustomAttributes<ObsoleteAttribute>(member2);
            ObsoleteAttribute[] attributes4 = member2.GetCustomAttributes<ObsoleteAttribute>();

            Assert.IsNotNull(attributes1, "#1");
            Assert.AreEqual(1, attributes1.Length, "#1");
            Assert.IsNotNull(attributes1[0], "#1");
            Assert.AreEqual("Use ReflectionUtils.GetVersion() method instead.", attributes1[0].Message, "#1");

            Assert.IsNotNull(attributes2, "#2");
            Assert.AreEqual(1, attributes2.Length, "#2");
            Assert.IsNotNull(attributes2[0], "#2");
            Assert.AreEqual("Use ReflectionUtils.GetVersion() method instead.", attributes2[0].Message, "#2");

            Assert.IsNotNull(attributes3, "#3");
            Assert.AreEqual(0, attributes3.Length, "#3");

            Assert.IsNotNull(attributes4, "#4");
            Assert.AreEqual(0, attributes4.Length, "#4");

        }





















        [TestMethod]
        public void TypeHasCustomAttribute() {

            var type1 = typeof(AssemblyUtils);
            var type2 = typeof(ReflectionUtils);

            Assert.IsTrue(ReflectionUtils.HasCustomAttribute<ObsoleteAttribute>(type1));
            Assert.IsTrue(type1.HasCustomAttribute<ObsoleteAttribute>());

            Assert.IsTrue(ReflectionUtils.HasCustomAttribute(type1, out ObsoleteAttribute obsolete));
            Assert.IsNotNull(obsolete);
            Assert.AreEqual("Use static methods in the ReflectionUtils class instead.", obsolete.Message);

            Assert.IsTrue(type1.HasCustomAttribute(out obsolete));
            Assert.IsNotNull(obsolete);
            Assert.AreEqual("Use static methods in the ReflectionUtils class instead.", obsolete.Message);

            Assert.IsFalse(ReflectionUtils.HasCustomAttribute<ObsoleteAttribute>(type2));
            Assert.IsFalse(type2.HasCustomAttribute<ObsoleteAttribute>());

            Assert.IsFalse(ReflectionUtils.HasCustomAttribute(type2, out obsolete));
            Assert.IsNull(obsolete);

            Assert.IsFalse(type2.HasCustomAttribute(out obsolete));
            Assert.IsNull(obsolete);

        }

        [TestMethod]
        public void TypeGetCustomAttribute() {

            var type1 = typeof(AssemblyUtils);
            var type2 = typeof(ReflectionUtils);

            ObsoleteAttribute attribute1 = ReflectionUtils.GetCustomAttribute<ObsoleteAttribute>(type1);
            ObsoleteAttribute attribute2 = type1.GetCustomAttribute<ObsoleteAttribute>();

            ObsoleteAttribute attribute3 = ReflectionUtils.GetCustomAttribute<ObsoleteAttribute>(type2);
            ObsoleteAttribute attribute4 = type2.GetCustomAttribute<ObsoleteAttribute>();

            Assert.IsNotNull(attribute1, "#1");
            Assert.AreEqual("Use static methods in the ReflectionUtils class instead.", attribute1.Message, "#1");

            Assert.IsNotNull(attribute2, "#2");
            Assert.AreEqual("Use static methods in the ReflectionUtils class instead.", attribute2.Message, "#2");

            Assert.IsNull(attribute3, "#4");

            Assert.IsNull(attribute4, "#4");

        }

        [TestMethod]
        public void TypeGetCustomAttributes() {

            var type1 = typeof(AssemblyUtils);
            var type2 = typeof(ReflectionUtils);

            ObsoleteAttribute[] attributes1 = ReflectionUtils.GetCustomAttributes<ObsoleteAttribute>(type1);
            ObsoleteAttribute[] attributes2 = type1.GetCustomAttributes<ObsoleteAttribute>();

            ObsoleteAttribute[] attributes3 = ReflectionUtils.GetCustomAttributes<ObsoleteAttribute>(type2);
            ObsoleteAttribute[] attributes4 = type2.GetCustomAttributes<ObsoleteAttribute>();

            Assert.IsNotNull(attributes1, "#1");
            Assert.AreEqual(1, attributes1.Length, "#1");
            Assert.IsNotNull(attributes1[0], "#1");
            Assert.AreEqual("Use static methods in the ReflectionUtils class instead.", attributes1[0].Message, "#1");

            Assert.IsNotNull(attributes2, "#2");
            Assert.AreEqual(1, attributes2.Length, "#2");
            Assert.IsNotNull(attributes2[0], "#2");
            Assert.AreEqual("Use static methods in the ReflectionUtils class instead.", attributes2[0].Message, "#2");

            Assert.IsNotNull(attributes3, "#3");
            Assert.AreEqual(0, attributes3.Length, "#3");

            Assert.IsNotNull(attributes4, "#4");
            Assert.AreEqual(0, attributes4.Length, "#4");

        }

    }

}