using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Collections;
using Skybrud.Essentials.Enums;
using Skybrud.Essentials.Strings;
using Skybrud.Essentials.Strings.Extensions;

namespace UnitTestProject1.Enums {

    [TestClass]
    public class EnumTests {

        [TestMethod]
        public void GetEnumValues() {

            Enum[] values = EnumUtils.GetEnumValues(typeof(SortOrder));

            Assert.AreEqual(2, values.Length);

            Assert.AreEqual(values[0], SortOrder.Ascending);
            Assert.AreEqual(values[1], SortOrder.Descending);

        }

        [TestMethod]
        public void GetEnumValuesOfT() {

            SortOrder[] values = EnumUtils.GetEnumValues<SortOrder>();

            Assert.AreEqual(2, values.Length);

            Assert.AreEqual(values[0], SortOrder.Ascending);
            Assert.AreEqual(values[1], SortOrder.Descending);

        }

        [TestMethod]
        public void ParseEnum() {

            var samples = new[] {
                new { Input = default(string), Expected = HttpStatusCode.OK },
                new { Input = "", Expected = HttpStatusCode.OK },
                new { Input = "ok", Expected = HttpStatusCode.OK },
                new { Input = "OK", Expected = HttpStatusCode.OK },
                new { Input = "Ok", Expected = HttpStatusCode.OK },
                new { Input = "Not found", Expected = HttpStatusCode.NotFound },
                new { Input = "NOT FOUND", Expected = HttpStatusCode.NotFound },
                new { Input = "NotFound", Expected = HttpStatusCode.NotFound },
                new { Input = "not found", Expected = HttpStatusCode.NotFound }
            };

            foreach (var sample in samples) {
                Assert.AreEqual(sample.Expected, EnumUtils.ParseEnum(sample.Input, HttpStatusCode.OK));
            }

        }

        [TestMethod]
        public void ParseEnumArray() {

            var samples = new[] {
                new { Input = default(string), Expected = new HttpStatusCode[0] },
                new { Input = "", Expected = new HttpStatusCode[0] },
                new { Input = "ok", Expected = new [] { HttpStatusCode.OK } },
                new { Input = "OK", Expected = new [] { HttpStatusCode.OK } },
                new { Input = "Ok", Expected = new [] { HttpStatusCode.OK } },
                new { Input = "notfound", Expected = new [] { HttpStatusCode.NotFound } },
                new { Input = "NOTFOUND", Expected = new [] { HttpStatusCode.NotFound } },
                new { Input = "NotFound", Expected = new [] { HttpStatusCode.NotFound } },
                new { Input = "ok,notfound", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "OK,NOTFOUND", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "OK,NotFound", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "ok notfound", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "OK NOTFOUND", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "OK NotFound", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "ok\nnotfound", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "OK\nNOTFOUND", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "OK\nNotFound", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "ok\tnotfound", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "OK\tNOTFOUND", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } },
                new { Input = "OK\tNotFound", Expected = new [] { HttpStatusCode.OK, HttpStatusCode.NotFound } }
            };

            foreach (var sample in samples) {

                HttpStatusCode[] array = EnumUtils.ParseEnumArray<HttpStatusCode>(sample.Input);

                Assert.AreEqual(sample.Expected.Length, array.Length);
                for (int i = 0; i < array.Length; i++) {
                    Assert.AreEqual(sample.Expected[i], array[i]);
                }

                bool result = EnumUtils.TryParseEnumArray(sample.Input, out array);

                Assert.AreEqual(true, result);
                Assert.AreEqual(sample.Expected.Length, array.Length);
                for (int i = 0; i < array.Length; i++) {
                    Assert.AreEqual(sample.Expected[i], array[i]);
                }

            }

        }

        [TestMethod]
        public void TryParseEnum() {

            bool status1 = EnumUtils.TryParseEnum(null, out HttpStatusCode result1);
            bool status2 = EnumUtils.TryParseEnum("", out HttpStatusCode result2);
            bool status3 = EnumUtils.TryParseEnum("ok", out HttpStatusCode result3);
            bool status4 = EnumUtils.TryParseEnum("OK", out HttpStatusCode result4);
            bool status5 = EnumUtils.TryParseEnum("Ok", out HttpStatusCode result5);
            bool status6 = EnumUtils.TryParseEnum("Not found", out HttpStatusCode result6);
            bool status7 = EnumUtils.TryParseEnum("NOT FOUND", out HttpStatusCode result7);
            bool status8 = EnumUtils.TryParseEnum("NotFound", out HttpStatusCode result8);
            bool status9 = EnumUtils.TryParseEnum("not found", out HttpStatusCode result9);

            Assert.IsFalse(status1);
            Assert.AreEqual(result1, default);

            Assert.IsFalse(status2);
            Assert.AreEqual(result2, default);

            Assert.IsTrue(status3);
            Assert.AreEqual(result3, HttpStatusCode.OK);

            Assert.IsTrue(status4);
            Assert.AreEqual(result4, HttpStatusCode.OK);

            Assert.IsTrue(status5);
            Assert.AreEqual(result5, HttpStatusCode.OK);

            Assert.IsTrue(status6);
            Assert.AreEqual(result6, HttpStatusCode.NotFound);

            Assert.IsTrue(status7);
            Assert.AreEqual(result7, HttpStatusCode.NotFound);

            Assert.IsTrue(status8);
            Assert.AreEqual(result8, HttpStatusCode.NotFound);

            Assert.IsTrue(status9);
            Assert.AreEqual(result9, HttpStatusCode.NotFound);

        }

        [TestMethod]
        public void Min() {

            var result1 = EnumUtils.Min(HttpStatusCode.OK, HttpStatusCode.NotFound);
            var result2 = EnumUtils.Min(HttpStatusCode.NotFound, HttpStatusCode.OK);

            Assert.AreEqual(HttpStatusCode.OK, result1, "#1");
            Assert.AreEqual(HttpStatusCode.OK, result2, "#2");

        }

        [TestMethod]
        public void MinArray() {

            var result1 = EnumUtils.Min(HttpStatusCode.OK, HttpStatusCode.NotFound, HttpStatusCode.Continue);
            var result2 = EnumUtils.Min(HttpStatusCode.Continue, HttpStatusCode.NotFound, HttpStatusCode.OK);

            Assert.AreEqual(HttpStatusCode.Continue, result1, "#1");
            Assert.AreEqual(HttpStatusCode.Continue, result2, "#2");

        }

        [TestMethod]
        public void MinList() {

            var result1 = EnumUtils.Min(new List<HttpStatusCode> { HttpStatusCode.OK, HttpStatusCode.NotFound, HttpStatusCode.Continue });
            var result2 = EnumUtils.Min(new List<HttpStatusCode> { HttpStatusCode.Continue, HttpStatusCode.NotFound, HttpStatusCode.OK });

            Assert.AreEqual(HttpStatusCode.Continue, result1, "#1");
            Assert.AreEqual(HttpStatusCode.Continue, result2, "#2");

        }

        [TestMethod]
        public void Max() {

            var result1 = EnumUtils.Max(HttpStatusCode.OK, HttpStatusCode.NotFound);
            var result2 = EnumUtils.Max(HttpStatusCode.NotFound, HttpStatusCode.OK);

            Assert.AreEqual(HttpStatusCode.NotFound, result1, "#1");
            Assert.AreEqual(HttpStatusCode.NotFound, result2, "#2");

        }

        [TestMethod]
        public void MaxArray() {

            var result1 = EnumUtils.Max(HttpStatusCode.OK, HttpStatusCode.NotFound, HttpStatusCode.Continue);
            var result2 = EnumUtils.Max(HttpStatusCode.Continue, HttpStatusCode.NotFound, HttpStatusCode.OK);

            Assert.AreEqual(HttpStatusCode.NotFound, result1, "#1");
            Assert.AreEqual(HttpStatusCode.NotFound, result2, "#2");

        }

        [TestMethod]
        public void MaxList() {

            var result1 = EnumUtils.Max(new List<HttpStatusCode> { HttpStatusCode.OK, HttpStatusCode.NotFound, HttpStatusCode.Continue });
            var result2 = EnumUtils.Max(new List<HttpStatusCode> { HttpStatusCode.Continue, HttpStatusCode.NotFound, HttpStatusCode.OK });

            Assert.AreEqual(HttpStatusCode.NotFound, result1, "#1");
            Assert.AreEqual(HttpStatusCode.NotFound, result2, "#2");

        }

        [TestMethod]
        public void GetFlags() {

            PizzaIngredients ingredients1 = default;
            PizzaIngredients ingredients2 = PizzaIngredients.PizzaSauce | PizzaIngredients.Cheese | PizzaIngredients.Kebab | PizzaIngredients.Bacon | PizzaIngredients.Salad | PizzaIngredients.Dressing;

            IEnumerable<PizzaIngredients> flags1 = ingredients1.GetFlags();
            IEnumerable<PizzaIngredients> flags2 = ingredients2.GetFlags();

            Assert.AreEqual("none", flags1.ToCamelCase());
            Assert.AreEqual("pizzaSauce,kebab,bacon,salad,dressing,cheese", flags2.ToCamelCase());

        }

        [TestMethod]
        public void CollectionToCamelCase() {

            const PizzaIngredients ingredients1 = default;
            const PizzaIngredients ingredients2 = PizzaIngredients.PizzaSauce | PizzaIngredients.Cheese | PizzaIngredients.Kebab | PizzaIngredients.Bacon | PizzaIngredients.Salad | PizzaIngredients.Dressing;

            const string expected1 = "none";
            const string expected2 = "pizzaSauce,kebab,bacon,salad,dressing,cheese";

            PizzaIngredients[] flags1 = ingredients1.GetFlags().ToArray();
            PizzaIngredients[] flags2 = ingredients2.GetFlags().ToArray();

            Assert.AreEqual(expected1, StringUtils.ToCamelCase(flags1));
            Assert.AreEqual(expected2, StringUtils.ToCamelCase(flags2));

            Assert.AreEqual(expected1, StringUtils.ToCasing(flags1, TextCasing.CamelCase));
            Assert.AreEqual(expected2, StringUtils.ToCasing(flags2, TextCasing.CamelCase));

            Assert.AreEqual(expected1, flags1.ToCamelCase());
            Assert.AreEqual(expected2, flags2.ToCamelCase());

            Assert.AreEqual(expected1, flags1.ToCasing(TextCasing.CamelCase));
            Assert.AreEqual(expected2, flags2.ToCasing(TextCasing.CamelCase));

        }

        [TestMethod]
        public void CollectionToPascalCase() {

            const PizzaIngredients ingredients1 = default;
            const PizzaIngredients ingredients2 = PizzaIngredients.PizzaSauce | PizzaIngredients.Cheese | PizzaIngredients.Kebab | PizzaIngredients.Bacon | PizzaIngredients.Salad | PizzaIngredients.Dressing;

            const string expected1 = "None";
            const string expected2 = "PizzaSauce,Kebab,Bacon,Salad,Dressing,Cheese";

            PizzaIngredients[] flags1 = ingredients1.GetFlags().ToArray();
            PizzaIngredients[] flags2 = ingredients2.GetFlags().ToArray();

            Assert.AreEqual(expected1, StringUtils.ToPascalCase(flags1), "#1");
            Assert.AreEqual(expected2, StringUtils.ToPascalCase(flags2), "#2");

            Assert.AreEqual(expected1, StringUtils.ToCasing(flags1, TextCasing.PascalCase), "#3");
            Assert.AreEqual(expected2, StringUtils.ToCasing(flags2, TextCasing.PascalCase), "#4");

            Assert.AreEqual(expected1, flags1.ToPascalCase(), "#5");
            Assert.AreEqual(expected2, flags2.ToPascalCase(), "#6");

            Assert.AreEqual(expected1, flags1.ToCasing(TextCasing.PascalCase), "#7");
            Assert.AreEqual(expected2, flags2.ToCasing(TextCasing.PascalCase), "#8");

        }

        [TestMethod]
        public void CollectionToKebabCase() {

            const PizzaIngredients ingredients1 = default;
            const PizzaIngredients ingredients2 = PizzaIngredients.PizzaSauce | PizzaIngredients.Cheese | PizzaIngredients.Kebab | PizzaIngredients.Bacon | PizzaIngredients.Salad | PizzaIngredients.Dressing;

            const string expected1 = "none";
            const string expected2 = "pizza-sauce,kebab,bacon,salad,dressing,cheese";

            PizzaIngredients[] flags1 = ingredients1.GetFlags().ToArray();
            PizzaIngredients[] flags2 = ingredients2.GetFlags().ToArray();

            Assert.AreEqual(expected1, StringUtils.ToKebabCase(flags1), "#1");
            Assert.AreEqual(expected2, StringUtils.ToKebabCase(flags2), "#2");

            Assert.AreEqual(expected1, StringUtils.ToCasing(flags1, TextCasing.KebabCase), "#3");
            Assert.AreEqual(expected2, StringUtils.ToCasing(flags2, TextCasing.KebabCase), "#4");

            Assert.AreEqual(expected1, flags1.ToKebabCase(), "#5");
            Assert.AreEqual(expected2, flags2.ToKebabCase(), "#6");

            Assert.AreEqual(expected1, flags1.ToCasing(TextCasing.KebabCase), "#7");
            Assert.AreEqual(expected2, flags2.ToCasing(TextCasing.KebabCase), "#8");

        }

        [TestMethod]
        public void CollectionToTrainCase() {

            const PizzaIngredients ingredients1 = default;
            const PizzaIngredients ingredients2 = PizzaIngredients.PizzaSauce | PizzaIngredients.Cheese | PizzaIngredients.Kebab | PizzaIngredients.Bacon | PizzaIngredients.Salad | PizzaIngredients.Dressing;

            const string expected1 = "NONE";
            const string expected2 = "PIZZA-SAUCE,KEBAB,BACON,SALAD,DRESSING,CHEESE";

            PizzaIngredients[] flags1 = ingredients1.GetFlags().ToArray();
            PizzaIngredients[] flags2 = ingredients2.GetFlags().ToArray();

            Assert.AreEqual(expected1, StringUtils.ToTrainCase(flags1), "#1");
            Assert.AreEqual(expected2, StringUtils.ToTrainCase(flags2), "#2");

            Assert.AreEqual(expected1, StringUtils.ToCasing(flags1, TextCasing.TrainCase), "#3");
            Assert.AreEqual(expected2, StringUtils.ToCasing(flags2, TextCasing.TrainCase), "#4");

            Assert.AreEqual(expected1, flags1.ToTrainCase(), "#5");
            Assert.AreEqual(expected2, flags2.ToTrainCase(), "#6");

            Assert.AreEqual(expected1, flags1.ToCasing(TextCasing.TrainCase), "#7");
            Assert.AreEqual(expected2, flags2.ToCasing(TextCasing.TrainCase), "#8");

        }

        [TestMethod]
        public void CollectionToUnderscore() {

            const PizzaIngredients ingredients1 = default;
            const PizzaIngredients ingredients2 = PizzaIngredients.PizzaSauce | PizzaIngredients.Cheese | PizzaIngredients.Kebab | PizzaIngredients.Bacon | PizzaIngredients.Salad | PizzaIngredients.Dressing;

            const string expected1 = "none";
            const string expected2 = "pizza_sauce,kebab,bacon,salad,dressing,cheese";

            PizzaIngredients[] flags1 = ingredients1.GetFlags().ToArray();
            PizzaIngredients[] flags2 = ingredients2.GetFlags().ToArray();

            Assert.AreEqual(expected1, StringUtils.ToUnderscore(flags1), "#1");
            Assert.AreEqual(expected2, StringUtils.ToUnderscore(flags2), "#2");

            Assert.AreEqual(expected1, StringUtils.ToCasing(flags1, TextCasing.Underscore), "#3");
            Assert.AreEqual(expected2, StringUtils.ToCasing(flags2, TextCasing.Underscore), "#4");

            Assert.AreEqual(expected1, flags1.ToUnderscore(), "#5");
            Assert.AreEqual(expected2, flags2.ToUnderscore(), "#6");

            Assert.AreEqual(expected1, flags1.ToCasing(TextCasing.Underscore), "#7");
            Assert.AreEqual(expected2, flags2.ToCasing(TextCasing.Underscore), "#8");

        }

        [TestMethod]
        public void CollectionToLower() {

            const PizzaIngredients ingredients1 = default;
            const PizzaIngredients ingredients2 = PizzaIngredients.PizzaSauce | PizzaIngredients.Cheese | PizzaIngredients.Kebab | PizzaIngredients.Bacon | PizzaIngredients.Salad | PizzaIngredients.Dressing;

            const string expected1 = "none";
            const string expected2 = "pizzasauce,kebab,bacon,salad,dressing,cheese";

            PizzaIngredients[] flags1 = ingredients1.GetFlags().ToArray();
            PizzaIngredients[] flags2 = ingredients2.GetFlags().ToArray();

            Assert.AreEqual(expected1, StringUtils.ToLower(flags1), "#1");
            Assert.AreEqual(expected2, StringUtils.ToLower(flags2), "#2");

            Assert.AreEqual(expected1, StringUtils.ToCasing(flags1, TextCasing.LowerCase), "#3");
            Assert.AreEqual(expected2, StringUtils.ToCasing(flags2, TextCasing.LowerCase), "#4");

            Assert.AreEqual(expected1, flags1.ToLower(), "#5");
            Assert.AreEqual(expected2, flags2.ToLower(), "#6");

            Assert.AreEqual(expected1, flags1.ToCasing(TextCasing.LowerCase), "#7");
            Assert.AreEqual(expected2, flags2.ToCasing(TextCasing.LowerCase), "#8");

        }

        [TestMethod]
        public void CollectionToUpper() {

            const PizzaIngredients ingredients1 = default;
            const PizzaIngredients ingredients2 = PizzaIngredients.PizzaSauce | PizzaIngredients.Cheese | PizzaIngredients.Kebab | PizzaIngredients.Bacon | PizzaIngredients.Salad | PizzaIngredients.Dressing;

            const string expected1 = "NONE";
            const string expected2 = "PIZZASAUCE,KEBAB,BACON,SALAD,DRESSING,CHEESE";

            PizzaIngredients[] flags1 = ingredients1.GetFlags().ToArray();
            PizzaIngredients[] flags2 = ingredients2.GetFlags().ToArray();

            Assert.AreEqual(expected1, StringUtils.ToUpper(flags1), "#1");
            Assert.AreEqual(expected2, StringUtils.ToUpper(flags2), "#2");

            Assert.AreEqual(expected1, StringUtils.ToCasing(flags1, TextCasing.UpperCase), "#3");
            Assert.AreEqual(expected2, StringUtils.ToCasing(flags2, TextCasing.UpperCase), "#4");

            Assert.AreEqual(expected1, flags1.ToUpper(), "#5");
            Assert.AreEqual(expected2, flags2.ToUpper(), "#6");

            Assert.AreEqual(expected1, flags1.ToCasing(TextCasing.UpperCase), "#7");
            Assert.AreEqual(expected2, flags2.ToCasing(TextCasing.UpperCase), "#8");

        }

    }

    [Flags]
    public enum PizzaIngredients {

        None = 0,

        PizzaSauce = 1 << 0,

        Pepperoni = 1 << 1,

        SlicedHam = 1 << 2,

        Kebab = 1 << 3,

        Sausages = 1 << 4,

        Bacon = 1 << 5,

        Salad = 1 << 6,

        Dressing = 1 << 7,

        Jalapenos = 1 << 8,

        Cheese = 1 << 9,

        //Pineapple = 1 << 10

    }

}