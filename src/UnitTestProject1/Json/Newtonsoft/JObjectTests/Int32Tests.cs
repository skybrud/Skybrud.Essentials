using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace UnitTestProject1.Json.Newtonsoft.JObjectTests {

    [TestClass]
    public class Int32Tests {

        [TestMethod]
        public void GetInt32() {

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

            Assert.AreEqual(0, json.GetInt32("a"), "Check #1 failed");
            Assert.AreEqual(0, json.GetInt32("a", 2), "Check #2 failed");
            Assert.AreEqual(1, json.GetInt32("a", x => x + 1), "Check #3 failed");

            Assert.AreEqual(1234, json.GetInt32("b"), "Check #4 failed");
            Assert.AreEqual(1234, json.GetInt32("b", 2), "Check #5 failed");
            Assert.AreEqual(1235, json.GetInt32("b", x => x + 1), "Check #6 failed");

            Assert.AreEqual(1234, json.GetInt32("c"), "Check #7 failed");
            Assert.AreEqual(1234, json.GetInt32("c", 2), "Check #8 failed");
            Assert.AreEqual(1235, json.GetInt32("c", x => x + 1), "Check #9 failed");

            Assert.AreEqual(0, json.GetInt32("d"), "Check #10 failed");
            Assert.AreEqual(0, json.GetInt32("d", 2), "Check #11 failed");
            Assert.AreEqual(1, json.GetInt32("d", x => x + 1), "Check #12 failed");

            Assert.AreEqual(1, json.GetInt32("e"), "Check #13 failed");
            Assert.AreEqual(1, json.GetInt32("e", 2), "Check #14 failed");
            Assert.AreEqual(2, json.GetInt32("e", x => x + 1), "Check #15 failed");

            Assert.AreEqual(0, json.GetInt32("f"), "Check #16 failed");
            Assert.AreEqual(2, json.GetInt32("f", 2), "Check #17 failed");
            Assert.AreEqual(0, json.GetInt32("f", x => x + 1), "Check #18 failed");

            Assert.AreEqual(0, json.GetInt32("g"), "Check #19 failed");
            Assert.AreEqual(2, json.GetInt32("g", 2), "Check #20 failed");
            Assert.AreEqual(0, json.GetInt32("g", x => x + 1), "Check #21 failed");

            Assert.AreEqual(0, json.GetInt32("h"), "Check #22 failed");
            Assert.AreEqual(2, json.GetInt32("h", 2), "Check #23 failed");
            Assert.AreEqual(0, json.GetInt32("h", x => x + 1), "Check #24 failed");

            Assert.AreEqual(0, json.GetInt32("i"), "Check #25 failed");
            Assert.AreEqual(2, json.GetInt32("i", 2), "Check #26 failed");
            Assert.AreEqual(0, json.GetInt32("i", x => x + 1), "Check #27 failed");

            Assert.AreEqual(0, json.GetInt32("j"), "Check #28 failed");
            Assert.AreEqual(2, json.GetInt32("j", 2), "Check #29 failed");
            Assert.AreEqual(0, json.GetInt32("j", x => x + 1), "Check #30 failed");

            Assert.AreEqual(0, json.GetInt32("k"), "Check #31 failed");
            Assert.AreEqual(2, json.GetInt32("k", 2), "Check #32 failed");
            Assert.AreEqual(0, json.GetInt32("k", x => x + 1), "Check #33 failed");

            Assert.AreEqual(0, json.GetInt32("outer"), "Check #34 failed");
            Assert.AreEqual(2, json.GetInt32("outer", 2), "Check #35 failed");
            Assert.AreEqual(0, json.GetInt32("outer", x => x + 1), "Check #36 failed");






            Assert.AreEqual(0, json.GetInt32("outer.a"), "Check #37 failed");
            Assert.AreEqual(2, json.GetInt32("outer.a", 2), "Check #38 failed");
            Assert.AreEqual(0, json.GetInt32("outer.a", x => x + 1), "Check #39 failed");

            Assert.AreEqual(0, json.GetInt32("outer.b"), "Check #40 failed");
            Assert.AreEqual(2, json.GetInt32("outer.b", 2), "Check #41 failed");
            Assert.AreEqual(0, json.GetInt32("outer.b", x => x + 1), "Check #42 failed");

            Assert.AreEqual(0, json.GetInt32("outer.c"), "Check #43 failed");
            Assert.AreEqual(2, json.GetInt32("outer.c", 2), "Check #44 failed");
            Assert.AreEqual(0, json.GetInt32("outer.c", x => x + 1), "Check #45 failed");

            Assert.AreEqual(0, json.GetInt32("outer.d"), "Check #46 failed");
            Assert.AreEqual(2, json.GetInt32("outer.d", 2), "Check #47 failed");
            Assert.AreEqual(0, json.GetInt32("outer.d", x => x + 1), "Check #48 failed");

            Assert.AreEqual(0, json.GetInt32("outer.e"), "Check #49 failed");
            Assert.AreEqual(2, json.GetInt32("outer.e", 2), "Check #20 failed");
            Assert.AreEqual(0, json.GetInt32("outer.e", x => x + 1), "Check #51 failed");

            Assert.AreEqual(0, json.GetInt32("outer.f"), "Check #52 failed");
            Assert.AreEqual(2, json.GetInt32("outer.f", 2), "Check #53 failed");
            Assert.AreEqual(0, json.GetInt32("outer.f", x => x + 1), "Check #54 failed");

            Assert.AreEqual(0, json.GetInt32("outer.g"), "Check #55failed");
            Assert.AreEqual(2, json.GetInt32("outer.g", 2), "Check #56 failed");
            Assert.AreEqual(0, json.GetInt32("outer.g", x => x + 1), "Check #57 failed");

            Assert.AreEqual(0, json.GetInt32("outer.h"), "Check #58 failed");
            Assert.AreEqual(2, json.GetInt32("outer.h", 2), "Check #59 failed");
            Assert.AreEqual(0, json.GetInt32("outer.h", x => x + 1), "Check #60 failed");

            Assert.AreEqual(0, json.GetInt32("outer.i"), "Check #61 failed");
            Assert.AreEqual(2, json.GetInt32("outer.i", 2), "Check #62 failed");
            Assert.AreEqual(0, json.GetInt32("outer.i", x => x + 1), "Check #63 failed");

            Assert.AreEqual(0, json.GetInt32("outer.j"), "Check #64 failed");
            Assert.AreEqual(2, json.GetInt32("outer.j", 2), "Check #65 failed");
            Assert.AreEqual(0, json.GetInt32("outer.j", x => x + 1), "Check #66 failed");

            Assert.AreEqual(0, json.GetInt32("outer.k"), "Check #67 failed");
            Assert.AreEqual(2, json.GetInt32("outer.k", 2), "Check #68 failed");
            Assert.AreEqual(0, json.GetInt32("outer.k", x => x + 1), "Check #69 failed");





            Assert.AreEqual(0, outer.GetInt32("a"), "Check #70 failed");
            Assert.AreEqual(0, outer.GetInt32("a", 2), "Check #71 failed");
            Assert.AreEqual(1, outer.GetInt32("a", x => x + 1), "Check #72 failed");

            Assert.AreEqual(1234, outer.GetInt32("b"), "Check #73 failed");
            Assert.AreEqual(1234, outer.GetInt32("b", 2), "Check #74 failed");
            Assert.AreEqual(1235, outer.GetInt32("b", x => x + 1), "Check #75 failed");

            Assert.AreEqual(1234, outer.GetInt32("c"), "Check #76 failed");
            Assert.AreEqual(1234, outer.GetInt32("c", 2), "Check #77 failed");
            Assert.AreEqual(1235, outer.GetInt32("c", x => x + 1), "Check #78 failed");

            Assert.AreEqual(0, outer.GetInt32("d"), "Check #79 failed");
            Assert.AreEqual(0, outer.GetInt32("d", 2), "Check #80 failed");
            Assert.AreEqual(1, outer.GetInt32("d", x => x + 1), "Check #81 failed");

            Assert.AreEqual(1, outer.GetInt32("e"), "Check #82 failed");
            Assert.AreEqual(1, outer.GetInt32("e", 2), "Check #83failed");
            Assert.AreEqual(2, outer.GetInt32("e", x => x + 1), "Check #84 failed");

            Assert.AreEqual(0, outer.GetInt32("f"), "Check #85 failed");
            Assert.AreEqual(2, outer.GetInt32("f", 2), "Check #86 failed");
            Assert.AreEqual(0, outer.GetInt32("f", x => x + 1), "Check #87 failed");

            Assert.AreEqual(0, outer.GetInt32("g"), "Check #88 failed");
            Assert.AreEqual(2, outer.GetInt32("g", 2), "Check #89 failed");
            Assert.AreEqual(0, outer.GetInt32("g", x => x + 1), "Check #90 failed");

            Assert.AreEqual(0, outer.GetInt32("h"), "Check #100 failed");
            Assert.AreEqual(2, outer.GetInt32("h", 2), "Check #101 failed");
            Assert.AreEqual(0, outer.GetInt32("h", x => x + 1), "Check #102 failed");

            Assert.AreEqual(0, outer.GetInt32("i"), "Check #103 failed");
            Assert.AreEqual(2, outer.GetInt32("i", 2), "Check #104 failed");
            Assert.AreEqual(0, outer.GetInt32("i", x => x + 1), "Check #105 failed");

            Assert.AreEqual(0, outer.GetInt32("j"), "Check #106 failed");
            Assert.AreEqual(2, outer.GetInt32("j", 2), "Check #107 failed");
            Assert.AreEqual(0, outer.GetInt32("j", x => x + 1), "Check #108 failed");

            Assert.AreEqual(0, outer.GetInt32("k"), "Check #109 failed");
            Assert.AreEqual(2, outer.GetInt32("k", 2), "Check #110 failed");
            Assert.AreEqual(0, outer.GetInt32("k", x => x + 1), "Check #111 failed");

        }

        [TestMethod]
        public void GetInt32ByPath() {

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

            Assert.AreEqual(0, json.GetInt32ByPath("a"), "Check #1 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("a", 2), "Check #2 failed");
            Assert.AreEqual(1, json.GetInt32ByPath("a", x => x + 1), "Check #3 failed");

            Assert.AreEqual(1234, json.GetInt32ByPath("b"), "Check #4 failed");
            Assert.AreEqual(1234, json.GetInt32ByPath("b", 2), "Check #5 failed");
            Assert.AreEqual(1235, json.GetInt32ByPath("b", x => x + 1), "Check #6 failed");

            Assert.AreEqual(1234, json.GetInt32ByPath("c"), "Check #7 failed");
            Assert.AreEqual(1234, json.GetInt32ByPath("c", 2), "Check #8 failed");
            Assert.AreEqual(1235, json.GetInt32ByPath("c", x => x + 1), "Check #9 failed");

            Assert.AreEqual(0, json.GetInt32ByPath("d"), "Check #10 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("d", 2), "Check #11 failed");
            Assert.AreEqual(1, json.GetInt32ByPath("d", x => x + 1), "Check #12 failed");

            Assert.AreEqual(1, json.GetInt32ByPath("e"), "Check #13 failed");
            Assert.AreEqual(1, json.GetInt32ByPath("e", 2), "Check #14 failed");
            Assert.AreEqual(2, json.GetInt32ByPath("e", x => x + 1), "Check #15 failed");

            Assert.AreEqual(0, json.GetInt32ByPath("f"), "Check #16 failed");
            Assert.AreEqual(2, json.GetInt32ByPath("f", 2), "Check #17 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("f", x => x + 1), "Check #18 failed");

            Assert.AreEqual(0, json.GetInt32ByPath("g"), "Check #19 failed");
            Assert.AreEqual(2, json.GetInt32ByPath("g", 2), "Check #20 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("g", x => x + 1), "Check #21 failed");

            Assert.AreEqual(0, json.GetInt32ByPath("h"), "Check #22 failed");
            Assert.AreEqual(2, json.GetInt32ByPath("h", 2), "Check #23 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("h", x => x + 1), "Check #24 failed");

            Assert.AreEqual(0, json.GetInt32ByPath("i"), "Check #25 failed");
            Assert.AreEqual(2, json.GetInt32ByPath("i", 2), "Check #26 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("i", x => x + 1), "Check #27 failed");

            Assert.AreEqual(0, json.GetInt32ByPath("j"), "Check #28 failed");
            Assert.AreEqual(2, json.GetInt32ByPath("j", 2), "Check #29 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("j", x => x + 1), "Check #30 failed");

            Assert.AreEqual(0, json.GetInt32ByPath("k"), "Check #31 failed");
            Assert.AreEqual(2, json.GetInt32ByPath("k", 2), "Check #32 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("k", x => x + 1), "Check #33 failed");

            Assert.AreEqual(0, json.GetInt32ByPath("outer"), "Check #34 failed");
            Assert.AreEqual(2, json.GetInt32ByPath("outer", 2), "Check #35 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("outer", x => x + 1), "Check #36 failed");






            Assert.AreEqual(0, json.GetInt32ByPath("outer.a"), "Check #37 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("outer.a", 2), "Check #38 failed");
            Assert.AreEqual(1, json.GetInt32ByPath("outer.a", x => x + 1), "Check #39 failed");

            Assert.AreEqual(1234, json.GetInt32ByPath("outer.b"), "Check #40 failed");
            Assert.AreEqual(1234, json.GetInt32ByPath("outer.b", 2), "Check #41 failed");
            Assert.AreEqual(1235, json.GetInt32ByPath("outer.b", x => x + 1), "Check #42 failed");

            Assert.AreEqual(1234, json.GetInt32ByPath("outer.c"), "Check #43 failed");
            Assert.AreEqual(1234, json.GetInt32ByPath("outer.c", 2), "Check #44 failed");
            Assert.AreEqual(1235, json.GetInt32ByPath("outer.c", x => x + 1), "Check #45 failed");

            Assert.AreEqual(0, json.GetInt32ByPath("outer.d"), "Check #46 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("outer.d", 2), "Check #47 failed");
            Assert.AreEqual(1, json.GetInt32ByPath("outer.d", x => x + 1), "Check #48 failed");

            Assert.AreEqual(1, json.GetInt32ByPath("outer.e"), "Check #49 failed");
            Assert.AreEqual(1, json.GetInt32ByPath("outer.e", 2), "Check #20 failed");
            Assert.AreEqual(2, json.GetInt32ByPath("outer.e", x => x + 1), "Check #51 failed");

            Assert.AreEqual(0, json.GetInt32ByPath("outer.f"), "Check #52 failed");
            Assert.AreEqual(2, json.GetInt32ByPath("outer.f", 2), "Check #53 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("outer.f", x => x + 1), "Check #54 failed");

            Assert.AreEqual(0, json.GetInt32ByPath("outer.g"), "Check #55failed");
            Assert.AreEqual(2, json.GetInt32ByPath("outer.g", 2), "Check #56 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("outer.g", x => x + 1), "Check #57 failed");

            Assert.AreEqual(0, json.GetInt32ByPath("outer.h"), "Check #58 failed");
            Assert.AreEqual(2, json.GetInt32ByPath("outer.h", 2), "Check #59 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("outer.h", x => x + 1), "Check #60 failed");

            Assert.AreEqual(0, json.GetInt32ByPath("outer.i"), "Check #61 failed");
            Assert.AreEqual(2, json.GetInt32ByPath("outer.i", 2), "Check #62 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("outer.i", x => x + 1), "Check #63 failed");

            Assert.AreEqual(0, json.GetInt32ByPath("outer.j"), "Check #64 failed");
            Assert.AreEqual(2, json.GetInt32ByPath("outer.j", 2), "Check #65 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("outer.j", x => x + 1), "Check #66 failed");

            Assert.AreEqual(0, json.GetInt32ByPath("outer.k"), "Check #67 failed");
            Assert.AreEqual(2, json.GetInt32ByPath("outer.k", 2), "Check #68 failed");
            Assert.AreEqual(0, json.GetInt32ByPath("outer.k", x => x + 1), "Check #69 failed");





            Assert.AreEqual(0, outer.GetInt32ByPath("a"), "Check #70 failed");
            Assert.AreEqual(0, outer.GetInt32ByPath("a", 2), "Check #71 failed");
            Assert.AreEqual(1, outer.GetInt32ByPath("a", x => x + 1), "Check #72 failed");

            Assert.AreEqual(1234, outer.GetInt32ByPath("b"), "Check #73 failed");
            Assert.AreEqual(1234, outer.GetInt32ByPath("b", 2), "Check #74 failed");
            Assert.AreEqual(1235, outer.GetInt32ByPath("b", x => x + 1), "Check #75 failed");

            Assert.AreEqual(1234, outer.GetInt32ByPath("c"), "Check #76 failed");
            Assert.AreEqual(1234, outer.GetInt32ByPath("c", 2), "Check #77 failed");
            Assert.AreEqual(1235, outer.GetInt32ByPath("c", x => x + 1), "Check #78 failed");

            Assert.AreEqual(0, outer.GetInt32ByPath("d"), "Check #79 failed");
            Assert.AreEqual(0, outer.GetInt32ByPath("d", 2), "Check #80 failed");
            Assert.AreEqual(1, outer.GetInt32ByPath("d", x => x + 1), "Check #81 failed");

            Assert.AreEqual(1, outer.GetInt32ByPath("e"), "Check #82 failed");
            Assert.AreEqual(1, outer.GetInt32ByPath("e", 2), "Check #83failed");
            Assert.AreEqual(2, outer.GetInt32ByPath("e", x => x + 1), "Check #84 failed");

            Assert.AreEqual(0, outer.GetInt32ByPath("f"), "Check #85 failed");
            Assert.AreEqual(2, outer.GetInt32ByPath("f", 2), "Check #86 failed");
            Assert.AreEqual(0, outer.GetInt32ByPath("f", x => x + 1), "Check #87 failed");

            Assert.AreEqual(0, outer.GetInt32ByPath("g"), "Check #88 failed");
            Assert.AreEqual(2, outer.GetInt32ByPath("g", 2), "Check #89 failed");
            Assert.AreEqual(0, outer.GetInt32ByPath("g", x => x + 1), "Check #90 failed");

            Assert.AreEqual(0, outer.GetInt32ByPath("h"), "Check #100 failed");
            Assert.AreEqual(2, outer.GetInt32ByPath("h", 2), "Check #101 failed");
            Assert.AreEqual(0, outer.GetInt32ByPath("h", x => x + 1), "Check #102 failed");

            Assert.AreEqual(0, outer.GetInt32ByPath("i"), "Check #103 failed");
            Assert.AreEqual(2, outer.GetInt32ByPath("i", 2), "Check #104 failed");
            Assert.AreEqual(0, outer.GetInt32ByPath("i", x => x + 1), "Check #105 failed");

            Assert.AreEqual(0, outer.GetInt32ByPath("j"), "Check #106 failed");
            Assert.AreEqual(2, outer.GetInt32ByPath("j", 2), "Check #107 failed");
            Assert.AreEqual(0, outer.GetInt32ByPath("j", x => x + 1), "Check #108 failed");

            Assert.AreEqual(0, outer.GetInt32ByPath("k"), "Check #109 failed");
            Assert.AreEqual(2, outer.GetInt32ByPath("k", 2), "Check #110 failed");
            Assert.AreEqual(0, outer.GetInt32ByPath("k", x => x + 1), "Check #111 failed");

        }

        [TestMethod]
        public void GetInt32Array() {

            JObject json = new JObject {
                {"csv", "1,2,3"},
                {"array", new JArray(1, 2, 3)},
                {"nested", new JObject {
                    {"csv", "1,2,3"},
                    {"array", new JArray(1, 2, 3)},
                }}
            };

            Assert.AreEqual(3, json.GetInt32Array("csv").Length, "Check #1 failed");
            Assert.AreEqual(1, json.GetInt32Array("csv")[0], "Check #2 failed");
            Assert.AreEqual(2, json.GetInt32Array("csv")[1], "Check #3 failed");
            Assert.AreEqual(3, json.GetInt32Array("csv")[2], "Check #4 failed");

            Assert.AreEqual(3, json.GetInt32Array("array").Length, "Check #5 failed");
            Assert.AreEqual(1, json.GetInt32Array("array")[0], "Check #6 failed");
            Assert.AreEqual(2, json.GetInt32Array("array")[1], "Check #7 failed");
            Assert.AreEqual(3, json.GetInt32Array("array")[2], "Check #8 failed");

            Assert.AreEqual(0, json.GetInt32Array("nested.csv").Length, "Check #9 failed");
            Assert.AreEqual(0, json.GetInt32Array("nested.array").Length, "Check #13 failed");

        }

        [TestMethod]
        public void GetInt32ArrayByPath() {

            JObject json = new JObject {
                {"csv", "1,2,3"},
                {"array", new JArray(1, 2, 3)},
                {"nested", new JObject {
                    {"csv", "1,2,3"},
                    {"array", new JArray(1, 2, 3)},
                }}
            };

            Assert.AreEqual(3, json.GetInt32ArrayByPath("csv").Length, "Check #1 failed");
            Assert.AreEqual(1, json.GetInt32ArrayByPath("csv")[0], "Check #2 failed");
            Assert.AreEqual(2, json.GetInt32ArrayByPath("csv")[1], "Check #3 failed");
            Assert.AreEqual(3, json.GetInt32ArrayByPath("csv")[2], "Check #4 failed");

            Assert.AreEqual(3, json.GetInt32ArrayByPath("array").Length, "Check #5 failed");
            Assert.AreEqual(1, json.GetInt32ArrayByPath("array")[0], "Check #6 failed");
            Assert.AreEqual(2, json.GetInt32ArrayByPath("array")[1], "Check #7 failed");
            Assert.AreEqual(3, json.GetInt32ArrayByPath("array")[2], "Check #8 failed");

            Assert.AreEqual(3, json.GetInt32ArrayByPath("nested.csv").Length, "Check #9 failed");
            Assert.AreEqual(1, json.GetInt32ArrayByPath("nested.csv")[0], "Check #10 failed");
            Assert.AreEqual(2, json.GetInt32ArrayByPath("nested.csv")[1], "Check #11 failed");
            Assert.AreEqual(3, json.GetInt32ArrayByPath("nested.csv")[2], "Check #12 failed");

            Assert.AreEqual(3, json.GetInt32ArrayByPath("nested.array").Length, "Check #13 failed");
            Assert.AreEqual(1, json.GetInt32ArrayByPath("nested.array")[0], "Check #14 failed");
            Assert.AreEqual(2, json.GetInt32ArrayByPath("nested.array")[1], "Check #15 failed");
            Assert.AreEqual(3, json.GetInt32ArrayByPath("nested.array")[2], "Check #16 failed");

        }

    }

}