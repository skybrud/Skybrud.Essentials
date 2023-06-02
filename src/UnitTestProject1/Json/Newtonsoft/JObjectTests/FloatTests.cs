using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace UnitTestProject1.Json.Newtonsoft.JObjectTests {

    [TestClass]
    public class FloatTests {

        [TestMethod]
        public void GetFloat() {

            CultureInfo culture = CultureInfo.InvariantCulture;

            JObject json = new JObject {
                { "a", 0 },
                { "b", 1234 },
                { "c", 1234.456 },
                { "d", false },
                { "e", true },
                { "f", "hello" },
                { "g", null },
                { "h", "" },
                { "i", Guid.Parse("68bc2d8b-c600-4f63-8e10-7d4a6f89e6e0") },
                { "j", new DateTime(2022, 10, 27, 14, 40, 25) },
                { "k", new DateTimeOffset(2022, 10, 27, 14, 40, 25, TimeSpan.FromHours(1)) },
                {"outer", new JObject {
                    { "a", 0 },
                    { "b", 1234 },
                    { "c", 1234.456 },
                    { "d", false },
                    { "e", true },
                    { "f", "hello" },
                    { "g", null },
                    { "h", "" },
                    { "i", Guid.Parse("68bc2d8b-c600-4f63-8e10-7d4a6f89e6e0") },
                    { "j", new DateTime(2022, 10, 27, 14, 40, 25) },
                    { "k", new DateTimeOffset(2022, 10, 27, 14, 40, 25, TimeSpan.FromHours(1)) },
                }}
            };

            JObject outer = json.GetObject("outer");

            Assert.AreEqual(0, json.GetFloat("a"), "Check #1 failed");
            Assert.AreEqual(0, json.GetFloat("a", 2), "Check #2 failed");
            Assert.AreEqual(1, json.GetFloat("a", x => x + 1), "Check #3 failed");

            Assert.AreEqual(1234, json.GetFloat("b"), "Check #4 failed");
            Assert.AreEqual(1234, json.GetFloat("b", 2), "Check #5 failed");
            Assert.AreEqual(1235, json.GetFloat("b", x => x + 1), "Check #6 failed");

            Assert.AreEqual("1234.456", json.GetFloat("c").ToString("F3", culture), "Check #7 failed");
            Assert.AreEqual("1234.456", json.GetFloat("c", 2).ToString("F3", culture), "Check #8 failed");
            Assert.AreEqual("1235.456", json.GetFloat("c", x => x + 1).ToString("F3", culture), "Check #9 failed");

            Assert.AreEqual(0, json.GetFloat("d"), "Check #10 failed");
            Assert.AreEqual(0, json.GetFloat("d", 2), "Check #11 failed");
            Assert.AreEqual(1, json.GetFloat("d", x => x + 1), "Check #12 failed");

            Assert.AreEqual(1, json.GetFloat("e"), "Check #13 failed");
            Assert.AreEqual(1, json.GetFloat("e", 2), "Check #14 failed");
            Assert.AreEqual(2, json.GetFloat("e", x => x + 1), "Check #15 failed");

            Assert.AreEqual(0, json.GetFloat("f"), "Check #16 failed");
            Assert.AreEqual(2, json.GetFloat("f", 2), "Check #17 failed");
            Assert.AreEqual(0, json.GetFloat("f", x => x + 1), "Check #18 failed");

            Assert.AreEqual(0, json.GetFloat("g"), "Check #19 failed");
            Assert.AreEqual(2, json.GetFloat("g", 2), "Check #20 failed");
            Assert.AreEqual(0, json.GetFloat("g", x => x + 1), "Check #21 failed");

            Assert.AreEqual(0, json.GetFloat("h"), "Check #22 failed");
            Assert.AreEqual(2, json.GetFloat("h", 2), "Check #23 failed");
            Assert.AreEqual(0, json.GetFloat("h", x => x + 1), "Check #24 failed");

            Assert.AreEqual(0, json.GetFloat("i"), "Check #25 failed");
            Assert.AreEqual(2, json.GetFloat("i", 2), "Check #26 failed");
            Assert.AreEqual(0, json.GetFloat("i", x => x + 1), "Check #27 failed");

            Assert.AreEqual(0, json.GetFloat("j"), "Check #28 failed");
            Assert.AreEqual(2, json.GetFloat("j", 2), "Check #29 failed");
            Assert.AreEqual(0, json.GetFloat("j", x => x + 1), "Check #30 failed");

            Assert.AreEqual(0, json.GetFloat("k"), "Check #31 failed");
            Assert.AreEqual(2, json.GetFloat("k", 2), "Check #32 failed");
            Assert.AreEqual(0, json.GetFloat("k", x => x + 1), "Check #33 failed");

            Assert.AreEqual(0, json.GetFloat("outer"), "Check #34 failed");
            Assert.AreEqual(2, json.GetFloat("outer", 2), "Check #35 failed");
            Assert.AreEqual(0, json.GetFloat("outer", x => x + 1), "Check #36 failed");






            Assert.AreEqual(0, json.GetFloat("outer.a"), "Check #37 failed");
            Assert.AreEqual(2, json.GetFloat("outer.a", 2), "Check #38 failed");
            Assert.AreEqual(0, json.GetFloat("outer.a", x => x + 1), "Check #39 failed");

            Assert.AreEqual(0, json.GetFloat("outer.b"), "Check #40 failed");
            Assert.AreEqual(2, json.GetFloat("outer.b", 2), "Check #41 failed");
            Assert.AreEqual(0, json.GetFloat("outer.b", x => x + 1), "Check #42 failed");

            Assert.AreEqual(0, json.GetFloat("outer.c"), "Check #43 failed");
            Assert.AreEqual(2, json.GetFloat("outer.c", 2), "Check #44 failed");
            Assert.AreEqual(0, json.GetFloat("outer.c", x => x + 1), "Check #45 failed");

            Assert.AreEqual(0, json.GetFloat("outer.d"), "Check #46 failed");
            Assert.AreEqual(2, json.GetFloat("outer.d", 2), "Check #47 failed");
            Assert.AreEqual(0, json.GetFloat("outer.d", x => x + 1), "Check #48 failed");

            Assert.AreEqual(0, json.GetFloat("outer.e"), "Check #49 failed");
            Assert.AreEqual(2, json.GetFloat("outer.e", 2), "Check #20 failed");
            Assert.AreEqual(0, json.GetFloat("outer.e", x => x + 1), "Check #51 failed");

            Assert.AreEqual(0, json.GetFloat("outer.f"), "Check #52 failed");
            Assert.AreEqual(2, json.GetFloat("outer.f", 2), "Check #53 failed");
            Assert.AreEqual(0, json.GetFloat("outer.f", x => x + 1), "Check #54 failed");

            Assert.AreEqual(0, json.GetFloat("outer.g"), "Check #55failed");
            Assert.AreEqual(2, json.GetFloat("outer.g", 2), "Check #56 failed");
            Assert.AreEqual(0, json.GetFloat("outer.g", x => x + 1), "Check #57 failed");

            Assert.AreEqual(0, json.GetFloat("outer.h"), "Check #58 failed");
            Assert.AreEqual(2, json.GetFloat("outer.h", 2), "Check #59 failed");
            Assert.AreEqual(0, json.GetFloat("outer.h", x => x + 1), "Check #60 failed");

            Assert.AreEqual(0, json.GetFloat("outer.i"), "Check #61 failed");
            Assert.AreEqual(2, json.GetFloat("outer.i", 2), "Check #62 failed");
            Assert.AreEqual(0, json.GetFloat("outer.i", x => x + 1), "Check #63 failed");

            Assert.AreEqual(0, json.GetFloat("outer.j"), "Check #64 failed");
            Assert.AreEqual(2, json.GetFloat("outer.j", 2), "Check #65 failed");
            Assert.AreEqual(0, json.GetFloat("outer.j", x => x + 1), "Check #66 failed");

            Assert.AreEqual(0, json.GetFloat("outer.k"), "Check #67 failed");
            Assert.AreEqual(2, json.GetFloat("outer.k", 2), "Check #68 failed");
            Assert.AreEqual(0, json.GetFloat("outer.k", x => x + 1), "Check #69 failed");





            Assert.AreEqual(0, outer.GetFloat("a"), "Check #70 failed");
            Assert.AreEqual(0, outer.GetFloat("a", 2), "Check #71 failed");
            Assert.AreEqual(1, outer.GetFloat("a", x => x + 1), "Check #72 failed");

            Assert.AreEqual(1234, outer.GetFloat("b"), "Check #73 failed");
            Assert.AreEqual(1234, outer.GetFloat("b", 2), "Check #74 failed");
            Assert.AreEqual(1235, outer.GetFloat("b", x => x + 1), "Check #75 failed");

            Assert.AreEqual("1234.456", outer.GetFloat("c").ToString("F3", CultureInfo.InvariantCulture), "Check #76 failed");
            Assert.AreEqual("1234.456", outer.GetFloat("c", 2).ToString("F3", CultureInfo.InvariantCulture), "Check #77 failed");
            Assert.AreEqual("1235.456", outer.GetFloat("c", x => x + 1).ToString("F3", CultureInfo.InvariantCulture), "Check #78 failed");

            Assert.AreEqual(0, outer.GetFloat("d"), "Check #79 failed");
            Assert.AreEqual(0, outer.GetFloat("d", 2), "Check #80 failed");
            Assert.AreEqual(1, outer.GetFloat("d", x => x + 1), "Check #81 failed");

            Assert.AreEqual(1, outer.GetFloat("e"), "Check #82 failed");
            Assert.AreEqual(1, outer.GetFloat("e", 2), "Check #83failed");
            Assert.AreEqual(2, outer.GetFloat("e", x => x + 1), "Check #84 failed");

            Assert.AreEqual(0, outer.GetFloat("f"), "Check #85 failed");
            Assert.AreEqual(2, outer.GetFloat("f", 2), "Check #86 failed");
            Assert.AreEqual(0, outer.GetFloat("f", x => x + 1), "Check #87 failed");

            Assert.AreEqual(0, outer.GetFloat("g"), "Check #88 failed");
            Assert.AreEqual(2, outer.GetFloat("g", 2), "Check #89 failed");
            Assert.AreEqual(0, outer.GetFloat("g", x => x + 1), "Check #90 failed");

            Assert.AreEqual(0, outer.GetFloat("h"), "Check #100 failed");
            Assert.AreEqual(2, outer.GetFloat("h", 2), "Check #101 failed");
            Assert.AreEqual(0, outer.GetFloat("h", x => x + 1), "Check #102 failed");

            Assert.AreEqual(0, outer.GetFloat("i"), "Check #103 failed");
            Assert.AreEqual(2, outer.GetFloat("i", 2), "Check #104 failed");
            Assert.AreEqual(0, outer.GetFloat("i", x => x + 1), "Check #105 failed");

            Assert.AreEqual(0, outer.GetFloat("j"), "Check #106 failed");
            Assert.AreEqual(2, outer.GetFloat("j", 2), "Check #107 failed");
            Assert.AreEqual(0, outer.GetFloat("j", x => x + 1), "Check #108 failed");

            Assert.AreEqual(0, outer.GetFloat("k"), "Check #109 failed");
            Assert.AreEqual(2, outer.GetFloat("k", 2), "Check #110 failed");
            Assert.AreEqual(0, outer.GetFloat("k", x => x + 1), "Check #111 failed");

        }

        [TestMethod]
        public void GetFloatByPath() {

            JObject json = new JObject {
                { "a", 0 },
                { "b", 1234 },
                { "c", 1234.456 },
                { "d", false },
                { "e", true },
                { "f", "hello" },
                { "g", null },
                { "h", "" },
                { "i", Guid.Parse("68bc2d8b-c600-4f63-8e10-7d4a6f89e6e0") },
                { "j", new DateTime(2022, 10, 27, 14, 40, 25) },
                { "k", new DateTimeOffset(2022, 10, 27, 14, 40, 25, TimeSpan.FromHours(1)) },
                {"outer", new JObject {
                    { "a", 0 },
                    { "b", 1234 },
                    { "c", 1234.456 },
                    { "d", false },
                    { "e", true },
                    { "f", "hello" },
                    { "g", null },
                    { "h", "" },
                    { "i", Guid.Parse("68bc2d8b-c600-4f63-8e10-7d4a6f89e6e0") },
                    { "j", new DateTime(2022, 10, 27, 14, 40, 25) },
                    { "k", new DateTimeOffset(2022, 10, 27, 14, 40, 25, TimeSpan.FromHours(1)) },
                }}
            };

            JObject outer = json.GetObject("outer");

            Assert.AreEqual(0, json.GetFloatByPath("a"), "Check #1 failed");
            Assert.AreEqual(0, json.GetFloatByPath("a", 2), "Check #2 failed");
            Assert.AreEqual(1, json.GetFloatByPath("a", x => x + 1), "Check #3 failed");

            Assert.AreEqual(1234, json.GetFloatByPath("b"), "Check #4 failed");
            Assert.AreEqual(1234, json.GetFloatByPath("b", 2), "Check #5 failed");
            Assert.AreEqual(1235, json.GetFloatByPath("b", x => x + 1), "Check #6 failed");

            Assert.AreEqual("1234.456", json.GetFloatByPath("c").ToString("F3", CultureInfo.InvariantCulture), "Check #7 failed");
            Assert.AreEqual("1234.456", json.GetFloatByPath("c", 2).ToString("F3", CultureInfo.InvariantCulture), "Check #8 failed");
            Assert.AreEqual("1235.456", json.GetFloatByPath("c", x => x + 1).ToString("F3", CultureInfo.InvariantCulture), "Check #9 failed");

            Assert.AreEqual(0, json.GetFloatByPath("d"), "Check #10 failed");
            Assert.AreEqual(0, json.GetFloatByPath("d", 2), "Check #11 failed");
            Assert.AreEqual(1, json.GetFloatByPath("d", x => x + 1), "Check #12 failed");

            Assert.AreEqual(1, json.GetFloatByPath("e"), "Check #13 failed");
            Assert.AreEqual(1, json.GetFloatByPath("e", 2), "Check #14 failed");
            Assert.AreEqual(2, json.GetFloatByPath("e", x => x + 1), "Check #15 failed");

            Assert.AreEqual(0, json.GetFloatByPath("f"), "Check #16 failed");
            Assert.AreEqual(2, json.GetFloatByPath("f", 2), "Check #17 failed");
            Assert.AreEqual(0, json.GetFloatByPath("f", x => x + 1), "Check #18 failed");

            Assert.AreEqual(0, json.GetFloatByPath("g"), "Check #19 failed");
            Assert.AreEqual(2, json.GetFloatByPath("g", 2), "Check #20 failed");
            Assert.AreEqual(0, json.GetFloatByPath("g", x => x + 1), "Check #21 failed");

            Assert.AreEqual(0, json.GetFloatByPath("h"), "Check #22 failed");
            Assert.AreEqual(2, json.GetFloatByPath("h", 2), "Check #23 failed");
            Assert.AreEqual(0, json.GetFloatByPath("h", x => x + 1), "Check #24 failed");

            Assert.AreEqual(0, json.GetFloatByPath("i"), "Check #25 failed");
            Assert.AreEqual(2, json.GetFloatByPath("i", 2), "Check #26 failed");
            Assert.AreEqual(0, json.GetFloatByPath("i", x => x + 1), "Check #27 failed");

            Assert.AreEqual(0, json.GetFloatByPath("j"), "Check #28 failed");
            Assert.AreEqual(2, json.GetFloatByPath("j", 2), "Check #29 failed");
            Assert.AreEqual(0, json.GetFloatByPath("j", x => x + 1), "Check #30 failed");

            Assert.AreEqual(0, json.GetFloatByPath("k"), "Check #31 failed");
            Assert.AreEqual(2, json.GetFloatByPath("k", 2), "Check #32 failed");
            Assert.AreEqual(0, json.GetFloatByPath("k", x => x + 1), "Check #33 failed");

            Assert.AreEqual(0, json.GetFloatByPath("outer"), "Check #34 failed");
            Assert.AreEqual(2, json.GetFloatByPath("outer", 2), "Check #35 failed");
            Assert.AreEqual(0, json.GetFloatByPath("outer", x => x + 1), "Check #36 failed");






            Assert.AreEqual(0, json.GetFloatByPath("outer.a"), "Check #37 failed");
            Assert.AreEqual(0, json.GetFloatByPath("outer.a", 2), "Check #38 failed");
            Assert.AreEqual(1, json.GetFloatByPath("outer.a", x => x + 1), "Check #39 failed");

            Assert.AreEqual(1234, json.GetFloatByPath("outer.b"), "Check #40 failed");
            Assert.AreEqual(1234, json.GetFloatByPath("outer.b", 2), "Check #41 failed");
            Assert.AreEqual(1235, json.GetFloatByPath("outer.b", x => x + 1), "Check #42 failed");

            Assert.AreEqual("1234.456", json.GetFloatByPath("outer.c").ToString("F3", CultureInfo.InvariantCulture), "Check #43 failed");
            Assert.AreEqual("1234.456", json.GetFloatByPath("outer.c", 2).ToString("F3", CultureInfo.InvariantCulture), "Check #44 failed");
            Assert.AreEqual("1235.456", json.GetFloatByPath("outer.c", x => x + 1).ToString("F3", CultureInfo.InvariantCulture), "Check #45 failed");

            Assert.AreEqual(0, json.GetFloatByPath("outer.d"), "Check #46 failed");
            Assert.AreEqual(0, json.GetFloatByPath("outer.d", 2), "Check #47 failed");
            Assert.AreEqual(1, json.GetFloatByPath("outer.d", x => x + 1), "Check #48 failed");

            Assert.AreEqual(1, json.GetFloatByPath("outer.e"), "Check #49 failed");
            Assert.AreEqual(1, json.GetFloatByPath("outer.e", 2), "Check #20 failed");
            Assert.AreEqual(2, json.GetFloatByPath("outer.e", x => x + 1), "Check #51 failed");

            Assert.AreEqual(0, json.GetFloatByPath("outer.f"), "Check #52 failed");
            Assert.AreEqual(2, json.GetFloatByPath("outer.f", 2), "Check #53 failed");
            Assert.AreEqual(0, json.GetFloatByPath("outer.f", x => x + 1), "Check #54 failed");

            Assert.AreEqual(0, json.GetFloatByPath("outer.g"), "Check #55failed");
            Assert.AreEqual(2, json.GetFloatByPath("outer.g", 2), "Check #56 failed");
            Assert.AreEqual(0, json.GetFloatByPath("outer.g", x => x + 1), "Check #57 failed");

            Assert.AreEqual(0, json.GetFloatByPath("outer.h"), "Check #58 failed");
            Assert.AreEqual(2, json.GetFloatByPath("outer.h", 2), "Check #59 failed");
            Assert.AreEqual(0, json.GetFloatByPath("outer.h", x => x + 1), "Check #60 failed");

            Assert.AreEqual(0, json.GetFloatByPath("outer.i"), "Check #61 failed");
            Assert.AreEqual(2, json.GetFloatByPath("outer.i", 2), "Check #62 failed");
            Assert.AreEqual(0, json.GetFloatByPath("outer.i", x => x + 1), "Check #63 failed");

            Assert.AreEqual(0, json.GetFloatByPath("outer.j"), "Check #64 failed");
            Assert.AreEqual(2, json.GetFloatByPath("outer.j", 2), "Check #65 failed");
            Assert.AreEqual(0, json.GetFloatByPath("outer.j", x => x + 1), "Check #66 failed");

            Assert.AreEqual(0, json.GetFloatByPath("outer.k"), "Check #67 failed");
            Assert.AreEqual(2, json.GetFloatByPath("outer.k", 2), "Check #68 failed");
            Assert.AreEqual(0, json.GetFloatByPath("outer.k", x => x + 1), "Check #69 failed");





            Assert.AreEqual(0, outer.GetFloatByPath("a"), "Check #70 failed");
            Assert.AreEqual(0, outer.GetFloatByPath("a", 2), "Check #71 failed");
            Assert.AreEqual(1, outer.GetFloatByPath("a", x => x + 1), "Check #72 failed");

            Assert.AreEqual(1234, outer.GetFloatByPath("b"), "Check #73 failed");
            Assert.AreEqual(1234, outer.GetFloatByPath("b", 2), "Check #74 failed");
            Assert.AreEqual(1235, outer.GetFloatByPath("b", x => x + 1), "Check #75 failed");

            Assert.AreEqual("1234.456", outer.GetFloatByPath("c").ToString("F3", CultureInfo.InvariantCulture), "Check #76 failed");
            Assert.AreEqual("1234.456", outer.GetFloatByPath("c", 2).ToString("F3", CultureInfo.InvariantCulture), "Check #77 failed");
            Assert.AreEqual("1235.456", outer.GetFloatByPath("c", x => x + 1).ToString("F3", CultureInfo.InvariantCulture), "Check #78 failed");

            Assert.AreEqual(0, outer.GetFloatByPath("d"), "Check #79 failed");
            Assert.AreEqual(0, outer.GetFloatByPath("d", 2), "Check #80 failed");
            Assert.AreEqual(1, outer.GetFloatByPath("d", x => x + 1), "Check #81 failed");

            Assert.AreEqual(1, outer.GetFloatByPath("e"), "Check #82 failed");
            Assert.AreEqual(1, outer.GetFloatByPath("e", 2), "Check #83failed");
            Assert.AreEqual(2, outer.GetFloatByPath("e", x => x + 1), "Check #84 failed");

            Assert.AreEqual(0, outer.GetFloatByPath("f"), "Check #85 failed");
            Assert.AreEqual(2, outer.GetFloatByPath("f", 2), "Check #86 failed");
            Assert.AreEqual(0, outer.GetFloatByPath("f", x => x + 1), "Check #87 failed");

            Assert.AreEqual(0, outer.GetFloatByPath("g"), "Check #88 failed");
            Assert.AreEqual(2, outer.GetFloatByPath("g", 2), "Check #89 failed");
            Assert.AreEqual(0, outer.GetFloatByPath("g", x => x + 1), "Check #90 failed");

            Assert.AreEqual(0, outer.GetFloatByPath("h"), "Check #100 failed");
            Assert.AreEqual(2, outer.GetFloatByPath("h", 2), "Check #101 failed");
            Assert.AreEqual(0, outer.GetFloatByPath("h", x => x + 1), "Check #102 failed");

            Assert.AreEqual(0, outer.GetFloatByPath("i"), "Check #103 failed");
            Assert.AreEqual(2, outer.GetFloatByPath("i", 2), "Check #104 failed");
            Assert.AreEqual(0, outer.GetFloatByPath("i", x => x + 1), "Check #105 failed");

            Assert.AreEqual(0, outer.GetFloatByPath("j"), "Check #106 failed");
            Assert.AreEqual(2, outer.GetFloatByPath("j", 2), "Check #107 failed");
            Assert.AreEqual(0, outer.GetFloatByPath("j", x => x + 1), "Check #108 failed");

            Assert.AreEqual(0, outer.GetFloatByPath("k"), "Check #109 failed");
            Assert.AreEqual(2, outer.GetFloatByPath("k", 2), "Check #110 failed");
            Assert.AreEqual(0, outer.GetFloatByPath("k", x => x + 1), "Check #111 failed");

        }

        [TestMethod]
        public void GetFloatArray() {

            JObject json = new JObject {
                {"csv", "1,2,3"},
                {"array", new JArray(1, 2, 3)},
                {"nested", new JObject {
                    {"csv", "1,2,3"},
                    {"array", new JArray(1, 2, 3)},
                }}
            };

            Assert.AreEqual(3, json.GetFloatArray("csv").Length, "Check #1 failed");
            Assert.AreEqual(1, json.GetFloatArray("csv")[0], "Check #2 failed");
            Assert.AreEqual(2, json.GetFloatArray("csv")[1], "Check #3 failed");
            Assert.AreEqual(3, json.GetFloatArray("csv")[2], "Check #4 failed");

            Assert.AreEqual(3, json.GetFloatArray("array").Length, "Check #5 failed");
            Assert.AreEqual(1, json.GetFloatArray("array")[0], "Check #6 failed");
            Assert.AreEqual(2, json.GetFloatArray("array")[1], "Check #7 failed");
            Assert.AreEqual(3, json.GetFloatArray("array")[2], "Check #8 failed");

            Assert.AreEqual(0, json.GetFloatArray("nested.csv").Length, "Check #9 failed");
            Assert.AreEqual(0, json.GetFloatArray("nested.array").Length, "Check #13 failed");

        }

        [TestMethod]
        public void GetFloatArrayByPath() {

            JObject json = new JObject {
                {"csv", "1,2,3"},
                {"array", new JArray(1, 2, 3)},
                {"nested", new JObject {
                    {"csv", "1,2,3"},
                    {"array", new JArray(1, 2, 3)},
                }}
            };

            Assert.AreEqual(3, json.GetFloatArrayByPath("csv").Length, "Check #1 failed");
            Assert.AreEqual(1, json.GetFloatArrayByPath("csv")[0], "Check #2 failed");
            Assert.AreEqual(2, json.GetFloatArrayByPath("csv")[1], "Check #3 failed");
            Assert.AreEqual(3, json.GetFloatArrayByPath("csv")[2], "Check #4 failed");

            Assert.AreEqual(3, json.GetFloatArrayByPath("array").Length, "Check #5 failed");
            Assert.AreEqual(1, json.GetFloatArrayByPath("array")[0], "Check #6 failed");
            Assert.AreEqual(2, json.GetFloatArrayByPath("array")[1], "Check #7 failed");
            Assert.AreEqual(3, json.GetFloatArrayByPath("array")[2], "Check #8 failed");

            Assert.AreEqual(3, json.GetFloatArrayByPath("nested.csv").Length, "Check #9 failed");
            Assert.AreEqual(1, json.GetFloatArrayByPath("nested.csv")[0], "Check #10 failed");
            Assert.AreEqual(2, json.GetFloatArrayByPath("nested.csv")[1], "Check #11 failed");
            Assert.AreEqual(3, json.GetFloatArrayByPath("nested.csv")[2], "Check #12 failed");

            Assert.AreEqual(3, json.GetFloatArrayByPath("nested.array").Length, "Check #13 failed");
            Assert.AreEqual(1, json.GetFloatArrayByPath("nested.array")[0], "Check #14 failed");
            Assert.AreEqual(2, json.GetFloatArrayByPath("nested.array")[1], "Check #15 failed");
            Assert.AreEqual(3, json.GetFloatArrayByPath("nested.array")[2], "Check #16 failed");

        }

    }

}