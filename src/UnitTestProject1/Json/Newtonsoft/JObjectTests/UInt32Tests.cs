using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace UnitTestProject1.Json.Newtonsoft.JObjectTests {

    [TestClass]
    public class UInt32Tests {

        [TestMethod]
        public void GetUInt32() {

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

            Assert.AreEqual((uint) 0, json.GetUInt32("a"), "Check #1 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("a", 2), "Check #2 failed");
            Assert.AreEqual((uint) 1, json.GetUInt32("a", x => x + 1), "Check #3 failed");

            Assert.AreEqual((uint) 1234, json.GetUInt32("b"), "Check #4 failed");
            Assert.AreEqual((uint) 1234, json.GetUInt32("b", 2), "Check #5 failed");
            Assert.AreEqual((uint) 1235, json.GetUInt32("b", x => x + 1), "Check #6 failed");

            Assert.AreEqual((uint) 1234, json.GetUInt32("c"), "Check #7 failed");
            Assert.AreEqual((uint) 1234, json.GetUInt32("c", 2), "Check #8 failed");
            Assert.AreEqual((uint) 1235, json.GetUInt32("c", x => x + 1), "Check #9 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("d"), "Check #10 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("d", 2), "Check #11 failed");
            Assert.AreEqual((uint) 1, json.GetUInt32("d", x => x + 1), "Check #12 failed");

            Assert.AreEqual((uint) 1, json.GetUInt32("e"), "Check #13 failed");
            Assert.AreEqual((uint) 1, json.GetUInt32("e", 2), "Check #14 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("e", x => x + 1), "Check #15 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("f"), "Check #16 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("f", 2), "Check #17 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("f", x => x + 1), "Check #18 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("g"), "Check #19 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("g", 2), "Check #20 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("g", x => x + 1), "Check #21 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("h"), "Check #22 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("h", 2), "Check #23 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("h", x => x + 1), "Check #24 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("i"), "Check #25 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("i", 2), "Check #26 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("i", x => x + 1), "Check #27 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("j"), "Check #28 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("j", 2), "Check #29 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("j", x => x + 1), "Check #30 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("k"), "Check #31 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("k", 2), "Check #32 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("k", x => x + 1), "Check #33 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("outer"), "Check #34 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("outer", 2), "Check #35 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("outer", x => x + 1), "Check #36 failed");






            Assert.AreEqual((uint) 0, json.GetUInt32("outer.a"), "Check #37 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("outer.a", 2), "Check #38 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("outer.a", x => x + 1), "Check #39 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("outer.b"), "Check #40 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("outer.b", 2), "Check #41 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("outer.b", x => x + 1), "Check #42 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("outer.c"), "Check #43 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("outer.c", 2), "Check #44 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("outer.c", x => x + 1), "Check #45 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("outer.d"), "Check #46 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("outer.d", 2), "Check #47 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("outer.d", x => x + 1), "Check #48 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("outer.e"), "Check #49 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("outer.e", 2), "Check #20 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("outer.e", x => x + 1), "Check #51 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("outer.f"), "Check #52 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("outer.f", 2), "Check #53 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("outer.f", x => x + 1), "Check #54 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("outer.g"), "Check #55failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("outer.g", 2), "Check #56 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("outer.g", x => x + 1), "Check #57 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("outer.h"), "Check #58 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("outer.h", 2), "Check #59 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("outer.h", x => x + 1), "Check #60 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("outer.i"), "Check #61 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("outer.i", 2), "Check #62 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("outer.i", x => x + 1), "Check #63 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("outer.j"), "Check #64 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("outer.j", 2), "Check #65 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("outer.j", x => x + 1), "Check #66 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32("outer.k"), "Check #67 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32("outer.k", 2), "Check #68 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32("outer.k", x => x + 1), "Check #69 failed");





            Assert.AreEqual((uint) 0, outer.GetUInt32("a"), "Check #70 failed");
            Assert.AreEqual((uint) 0, outer.GetUInt32("a", 2), "Check #71 failed");
            Assert.AreEqual((uint) 1, outer.GetUInt32("a", x => x + 1), "Check #72 failed");

            Assert.AreEqual((uint) 1234, outer.GetUInt32("b"), "Check #73 failed");
            Assert.AreEqual((uint) 1234, outer.GetUInt32("b", 2), "Check #74 failed");
            Assert.AreEqual((uint) 1235, outer.GetUInt32("b", x => x + 1), "Check #75 failed");

            Assert.AreEqual((uint) 1234, outer.GetUInt32("c"), "Check #76 failed");
            Assert.AreEqual((uint) 1234, outer.GetUInt32("c", 2), "Check #77 failed");
            Assert.AreEqual((uint) 1235, outer.GetUInt32("c", x => x + 1), "Check #78 failed");

            Assert.AreEqual((uint) 0, outer.GetUInt32("d"), "Check #79 failed");
            Assert.AreEqual((uint) 0, outer.GetUInt32("d", 2), "Check #80 failed");
            Assert.AreEqual((uint) 1, outer.GetUInt32("d", x => x + 1), "Check #81 failed");

            Assert.AreEqual((uint) 1, outer.GetUInt32("e"), "Check #82 failed");
            Assert.AreEqual((uint) 1, outer.GetUInt32("e", 2), "Check #83failed");
            Assert.AreEqual((uint) 2, outer.GetUInt32("e", x => x + 1), "Check #84 failed");

            Assert.AreEqual((uint) 0, outer.GetUInt32("f"), "Check #85 failed");
            Assert.AreEqual((uint) 2, outer.GetUInt32("f", 2), "Check #86 failed");
            Assert.AreEqual((uint) 0, outer.GetUInt32("f", x => x + 1), "Check #87 failed");

            Assert.AreEqual((uint) 0, outer.GetUInt32("g"), "Check #88 failed");
            Assert.AreEqual((uint) 2, outer.GetUInt32("g", 2), "Check #89 failed");
            Assert.AreEqual((uint) 0, outer.GetUInt32("g", x => x + 1), "Check #90 failed");

            Assert.AreEqual((uint) 0, outer.GetUInt32("h"), "Check #100 failed");
            Assert.AreEqual((uint) 2, outer.GetUInt32("h", 2), "Check #101 failed");
            Assert.AreEqual((uint) 0, outer.GetUInt32("h", x => x + 1), "Check #102 failed");

            Assert.AreEqual((uint) 0, outer.GetUInt32("i"), "Check #103 failed");
            Assert.AreEqual((uint) 2, outer.GetUInt32("i", 2), "Check #104 failed");
            Assert.AreEqual((uint) 0, outer.GetUInt32("i", x => x + 1), "Check #105 failed");

            Assert.AreEqual((uint) 0, outer.GetUInt32("j"), "Check #106 failed");
            Assert.AreEqual((uint) 2, outer.GetUInt32("j", 2), "Check #107 failed");
            Assert.AreEqual((uint) 0, outer.GetUInt32("j", x => x + 1), "Check #108 failed");

            Assert.AreEqual((uint) 0, outer.GetUInt32("k"), "Check #109 failed");
            Assert.AreEqual((uint) 2, outer.GetUInt32("k", 2), "Check #110 failed");
            Assert.AreEqual((uint) 0, outer.GetUInt32("k", x => x + 1), "Check #111 failed");

        }

        [TestMethod]
        public void GetUInt32ByPath() {

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

            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("a"), "Check #1 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("a", 2), "Check #2 failed");
            Assert.AreEqual((uint) 1, json.GetUInt32ByPath("a", x => x + 1), "Check #3 failed");

            Assert.AreEqual((uint) 1234, json.GetUInt32ByPath("b"), "Check #4 failed");
            Assert.AreEqual((uint) 1234, json.GetUInt32ByPath("b", 2), "Check #5 failed");
            Assert.AreEqual((uint) 1235, json.GetUInt32ByPath("b", x => x + 1), "Check #6 failed");

            Assert.AreEqual((uint) 1234, json.GetUInt32ByPath("c"), "Check #7 failed");
            Assert.AreEqual((uint) 1234, json.GetUInt32ByPath("c", 2), "Check #8 failed");
            Assert.AreEqual((uint) 1235, json.GetUInt32ByPath("c", x => x + 1), "Check #9 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("d"), "Check #10 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("d", 2), "Check #11 failed");
            Assert.AreEqual((uint) 1, json.GetUInt32ByPath("d", x => x + 1), "Check #12 failed");

            Assert.AreEqual((uint) 1, json.GetUInt32ByPath("e"), "Check #13 failed");
            Assert.AreEqual((uint) 1, json.GetUInt32ByPath("e", 2), "Check #14 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ByPath("e", x => x + 1), "Check #15 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("f"), "Check #16 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ByPath("f", 2), "Check #17 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("f", x => x + 1), "Check #18 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("g"), "Check #19 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ByPath("g", 2), "Check #20 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("g", x => x + 1), "Check #21 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("h"), "Check #22 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ByPath("h", 2), "Check #23 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("h", x => x + 1), "Check #24 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("i"), "Check #25 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ByPath("i", 2), "Check #26 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("i", x => x + 1), "Check #27 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("j"), "Check #28 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ByPath("j", 2), "Check #29 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("j", x => x + 1), "Check #30 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("k"), "Check #31 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ByPath("k", 2), "Check #32 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("k", x => x + 1), "Check #33 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer"), "Check #34 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ByPath("outer", 2), "Check #35 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer", x => x + 1), "Check #36 failed");






            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer.a"), "Check #37 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer.a", 2), "Check #38 failed");
            Assert.AreEqual((uint) 1, json.GetUInt32ByPath("outer.a", x => x + 1), "Check #39 failed");

            Assert.AreEqual((uint) 1234, json.GetUInt32ByPath("outer.b"), "Check #40 failed");
            Assert.AreEqual((uint) 1234, json.GetUInt32ByPath("outer.b", 2), "Check #41 failed");
            Assert.AreEqual((uint) 1235, json.GetUInt32ByPath("outer.b", x => x + 1), "Check #42 failed");

            Assert.AreEqual((uint) 1234, json.GetUInt32ByPath("outer.c"), "Check #43 failed");
            Assert.AreEqual((uint) 1234, json.GetUInt32ByPath("outer.c", 2), "Check #44 failed");
            Assert.AreEqual((uint) 1235, json.GetUInt32ByPath("outer.c", x => x + 1), "Check #45 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer.d"), "Check #46 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer.d", 2), "Check #47 failed");
            Assert.AreEqual((uint) 1, json.GetUInt32ByPath("outer.d", x => x + 1), "Check #48 failed");

            Assert.AreEqual((uint) 1, json.GetUInt32ByPath("outer.e"), "Check #49 failed");
            Assert.AreEqual((uint) 1, json.GetUInt32ByPath("outer.e", 2), "Check #20 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ByPath("outer.e", x => x + 1), "Check #51 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer.f"), "Check #52 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ByPath("outer.f", 2), "Check #53 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer.f", x => x + 1), "Check #54 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer.g"), "Check #55failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ByPath("outer.g", 2), "Check #56 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer.g", x => x + 1), "Check #57 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer.h"), "Check #58 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ByPath("outer.h", 2), "Check #59 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer.h", x => x + 1), "Check #60 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer.i"), "Check #61 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ByPath("outer.i", 2), "Check #62 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer.i", x => x + 1), "Check #63 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer.j"), "Check #64 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ByPath("outer.j", 2), "Check #65 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer.j", x => x + 1), "Check #66 failed");

            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer.k"), "Check #67 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ByPath("outer.k", 2), "Check #68 failed");
            Assert.AreEqual((uint) 0, json.GetUInt32ByPath("outer.k", x => x + 1), "Check #69 failed");





            Assert.AreEqual((uint) 0, outer.GetUInt32ByPath("a"), "Check #70 failed");
            Assert.AreEqual((uint) 0, outer.GetUInt32ByPath("a", 2), "Check #71 failed");
            Assert.AreEqual((uint) 1, outer.GetUInt32ByPath("a", x => x + 1), "Check #72 failed");

            Assert.AreEqual((uint) 1234, outer.GetUInt32ByPath("b"), "Check #73 failed");
            Assert.AreEqual((uint) 1234, outer.GetUInt32ByPath("b", 2), "Check #74 failed");
            Assert.AreEqual((uint) 1235, outer.GetUInt32ByPath("b", x => x + 1), "Check #75 failed");

            Assert.AreEqual((uint) 1234, outer.GetUInt32ByPath("c"), "Check #76 failed");
            Assert.AreEqual((uint) 1234, outer.GetUInt32ByPath("c", 2), "Check #77 failed");
            Assert.AreEqual((uint) 1235, outer.GetUInt32ByPath("c", x => x + 1), "Check #78 failed");

            Assert.AreEqual((uint) 0, outer.GetUInt32ByPath("d"), "Check #79 failed");
            Assert.AreEqual((uint) 0, outer.GetUInt32ByPath("d", 2), "Check #80 failed");
            Assert.AreEqual((uint) 1, outer.GetUInt32ByPath("d", x => x + 1), "Check #81 failed");

            Assert.AreEqual((uint) 1, outer.GetUInt32ByPath("e"), "Check #82 failed");
            Assert.AreEqual((uint) 1, outer.GetUInt32ByPath("e", 2), "Check #83failed");
            Assert.AreEqual((uint) 2, outer.GetUInt32ByPath("e", x => x + 1), "Check #84 failed");

            Assert.AreEqual((uint) 0, outer.GetUInt32ByPath("f"), "Check #85 failed");
            Assert.AreEqual((uint) 2, outer.GetUInt32ByPath("f", 2), "Check #86 failed");
            Assert.AreEqual((uint) 0, outer.GetUInt32ByPath("f", x => x + 1), "Check #87 failed");

            Assert.AreEqual((uint) 0, outer.GetUInt32ByPath("g"), "Check #88 failed");
            Assert.AreEqual((uint) 2, outer.GetUInt32ByPath("g", 2), "Check #89 failed");
            Assert.AreEqual((uint) 0, outer.GetUInt32ByPath("g", x => x + 1), "Check #90 failed");

            Assert.AreEqual((uint) 0, outer.GetUInt32ByPath("h"), "Check #100 failed");
            Assert.AreEqual((uint) 2, outer.GetUInt32ByPath("h", 2), "Check #101 failed");
            Assert.AreEqual((uint) 0, outer.GetUInt32ByPath("h", x => x + 1), "Check #102 failed");

            Assert.AreEqual((uint) 0, outer.GetUInt32ByPath("i"), "Check #103 failed");
            Assert.AreEqual((uint) 2, outer.GetUInt32ByPath("i", 2), "Check #104 failed");
            Assert.AreEqual((uint) 0, outer.GetUInt32ByPath("i", x => x + 1), "Check #105 failed");

            Assert.AreEqual((uint) 0, outer.GetUInt32ByPath("j"), "Check #106 failed");
            Assert.AreEqual((uint) 2, outer.GetUInt32ByPath("j", 2), "Check #107 failed");
            Assert.AreEqual((uint) 0, outer.GetUInt32ByPath("j", x => x + 1), "Check #108 failed");

            Assert.AreEqual((uint) 0, outer.GetUInt32ByPath("k"), "Check #109 failed");
            Assert.AreEqual((uint) 2, outer.GetUInt32ByPath("k", 2), "Check #110 failed");
            Assert.AreEqual((uint) 0, outer.GetUInt32ByPath("k", x => x + 1), "Check #111 failed");

        }

        [TestMethod]
        public void GetUInt32Array() {

            JObject json = new JObject {
                {"csv", "1,2,3"},
                {"array", new JArray(1, 2, 3)},
                {"nested", new JObject {
                    {"csv", "1,2,3"},
                    {"array", new JArray(1, 2, 3)},
                }}
            };

            Assert.AreEqual(3, json.GetUInt32Array("csv").Length, "Check #1 failed");
            Assert.AreEqual((uint) 1, json.GetUInt32Array("csv")[0], "Check #2 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32Array("csv")[1], "Check #3 failed");
            Assert.AreEqual((uint) 3, json.GetUInt32Array("csv")[2], "Check #4 failed");

            Assert.AreEqual(3, json.GetUInt32Array("array").Length, "Check #5 failed");
            Assert.AreEqual((uint) 1, json.GetUInt32Array("array")[0], "Check #6 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32Array("array")[1], "Check #7 failed");
            Assert.AreEqual((uint) 3, json.GetUInt32Array("array")[2], "Check #8 failed");

            Assert.AreEqual(0, json.GetUInt32Array("nested.csv").Length, "Check #9 failed");
            Assert.AreEqual(0, json.GetUInt32Array("nested.array").Length, "Check #13 failed");

        }

        [TestMethod]
        public void GetUInt32ArrayByPath() {

            JObject json = new JObject {
                {"csv", "1,2,3"},
                {"array", new JArray(1, 2, 3)},
                {"nested", new JObject {
                    {"csv", "1,2,3"},
                    {"array", new JArray(1, 2, 3)},
                }}
            };

            Assert.AreEqual(3, json.GetUInt32ArrayByPath("csv").Length, "Check #1 failed");
            Assert.AreEqual((uint) 1, json.GetUInt32ArrayByPath("csv")[0], "Check #2 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ArrayByPath("csv")[1], "Check #3 failed");
            Assert.AreEqual((uint) 3, json.GetUInt32ArrayByPath("csv")[2], "Check #4 failed");

            Assert.AreEqual(3, json.GetUInt32ArrayByPath("array").Length, "Check #5 failed");
            Assert.AreEqual((uint) 1, json.GetUInt32ArrayByPath("array")[0], "Check #6 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ArrayByPath("array")[1], "Check #7 failed");
            Assert.AreEqual((uint) 3, json.GetUInt32ArrayByPath("array")[2], "Check #8 failed");

            Assert.AreEqual(3, json.GetUInt32ArrayByPath("nested.csv").Length, "Check #9 failed");
            Assert.AreEqual((uint) 1, json.GetUInt32ArrayByPath("nested.csv")[0], "Check #10 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ArrayByPath("nested.csv")[1], "Check #11 failed");
            Assert.AreEqual((uint) 3, json.GetUInt32ArrayByPath("nested.csv")[2], "Check #12 failed");

            Assert.AreEqual(3, json.GetUInt32ArrayByPath("nested.array").Length, "Check #13 failed");
            Assert.AreEqual((uint) 1, json.GetUInt32ArrayByPath("nested.array")[0], "Check #14 failed");
            Assert.AreEqual((uint) 2, json.GetUInt32ArrayByPath("nested.array")[1], "Check #15 failed");
            Assert.AreEqual((uint) 3, json.GetUInt32ArrayByPath("nested.array")[2], "Check #16 failed");

        }

    }

}