using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace UnitTestProject1.Json.Newtonsoft.JObjectTests {

    [TestClass]
    public class UInt64Tests {

        [TestMethod]
        public void GetUInt64() {

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

            Assert.AreEqual((ulong) 0, json.GetUInt64("a"), "Check #1 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("a", 2), "Check #2 failed");
            Assert.AreEqual((ulong) 1, json.GetUInt64("a", x => x + 1), "Check #3 failed");

            Assert.AreEqual((ulong) 1234, json.GetUInt64("b"), "Check #4 failed");
            Assert.AreEqual((ulong) 1234, json.GetUInt64("b", 2), "Check #5 failed");
            Assert.AreEqual((ulong) 1235, json.GetUInt64("b", x => x + 1), "Check #6 failed");

            Assert.AreEqual((ulong) 1234, json.GetUInt64("c"), "Check #7 failed");
            Assert.AreEqual((ulong) 1234, json.GetUInt64("c", 2), "Check #8 failed");
            Assert.AreEqual((ulong) 1235, json.GetUInt64("c", x => x + 1), "Check #9 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("d"), "Check #10 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("d", 2), "Check #11 failed");
            Assert.AreEqual((ulong) 1, json.GetUInt64("d", x => x + 1), "Check #12 failed");

            Assert.AreEqual((ulong) 1, json.GetUInt64("e"), "Check #13 failed");
            Assert.AreEqual((ulong) 1, json.GetUInt64("e", 2), "Check #14 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("e", x => x + 1), "Check #15 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("f"), "Check #16 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("f", 2), "Check #17 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("f", x => x + 1), "Check #18 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("g"), "Check #19 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("g", 2), "Check #20 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("g", x => x + 1), "Check #21 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("h"), "Check #22 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("h", 2), "Check #23 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("h", x => x + 1), "Check #24 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("i"), "Check #25 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("i", 2), "Check #26 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("i", x => x + 1), "Check #27 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("j"), "Check #28 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("j", 2), "Check #29 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("j", x => x + 1), "Check #30 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("k"), "Check #31 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("k", 2), "Check #32 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("k", x => x + 1), "Check #33 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("outer"), "Check #34 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("outer", 2), "Check #35 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("outer", x => x + 1), "Check #36 failed");






            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.a"), "Check #37 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("outer.a", 2), "Check #38 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.a", x => x + 1), "Check #39 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.b"), "Check #40 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("outer.b", 2), "Check #41 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.b", x => x + 1), "Check #42 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.c"), "Check #43 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("outer.c", 2), "Check #44 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.c", x => x + 1), "Check #45 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.d"), "Check #46 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("outer.d", 2), "Check #47 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.d", x => x + 1), "Check #48 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.e"), "Check #49 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("outer.e", 2), "Check #20 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.e", x => x + 1), "Check #51 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.f"), "Check #52 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("outer.f", 2), "Check #53 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.f", x => x + 1), "Check #54 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.g"), "Check #55failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("outer.g", 2), "Check #56 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.g", x => x + 1), "Check #57 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.h"), "Check #58 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("outer.h", 2), "Check #59 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.h", x => x + 1), "Check #60 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.i"), "Check #61 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("outer.i", 2), "Check #62 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.i", x => x + 1), "Check #63 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.j"), "Check #64 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("outer.j", 2), "Check #65 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.j", x => x + 1), "Check #66 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.k"), "Check #67 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64("outer.k", 2), "Check #68 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64("outer.k", x => x + 1), "Check #69 failed");





            Assert.AreEqual((ulong) 0, outer.GetUInt64("a"), "Check #70 failed");
            Assert.AreEqual((ulong) 0, outer.GetUInt64("a", 2), "Check #71 failed");
            Assert.AreEqual((ulong) 1, outer.GetUInt64("a", x => x + 1), "Check #72 failed");

            Assert.AreEqual((ulong) 1234, outer.GetUInt64("b"), "Check #73 failed");
            Assert.AreEqual((ulong) 1234, outer.GetUInt64("b", 2), "Check #74 failed");
            Assert.AreEqual((ulong) 1235, outer.GetUInt64("b", x => x + 1), "Check #75 failed");

            Assert.AreEqual((ulong) 1234, outer.GetUInt64("c"), "Check #76 failed");
            Assert.AreEqual((ulong) 1234, outer.GetUInt64("c", 2), "Check #77 failed");
            Assert.AreEqual((ulong) 1235, outer.GetUInt64("c", x => x + 1), "Check #78 failed");

            Assert.AreEqual((ulong) 0, outer.GetUInt64("d"), "Check #79 failed");
            Assert.AreEqual((ulong) 0, outer.GetUInt64("d", 2), "Check #80 failed");
            Assert.AreEqual((ulong) 1, outer.GetUInt64("d", x => x + 1), "Check #81 failed");

            Assert.AreEqual((ulong) 1, outer.GetUInt64("e"), "Check #82 failed");
            Assert.AreEqual((ulong) 1, outer.GetUInt64("e", 2), "Check #83failed");
            Assert.AreEqual((ulong) 2, outer.GetUInt64("e", x => x + 1), "Check #84 failed");

            Assert.AreEqual((ulong) 0, outer.GetUInt64("f"), "Check #85 failed");
            Assert.AreEqual((ulong) 2, outer.GetUInt64("f", 2), "Check #86 failed");
            Assert.AreEqual((ulong) 0, outer.GetUInt64("f", x => x + 1), "Check #87 failed");

            Assert.AreEqual((ulong) 0, outer.GetUInt64("g"), "Check #88 failed");
            Assert.AreEqual((ulong) 2, outer.GetUInt64("g", 2), "Check #89 failed");
            Assert.AreEqual((ulong) 0, outer.GetUInt64("g", x => x + 1), "Check #90 failed");

            Assert.AreEqual((ulong) 0, outer.GetUInt64("h"), "Check #100 failed");
            Assert.AreEqual((ulong) 2, outer.GetUInt64("h", 2), "Check #101 failed");
            Assert.AreEqual((ulong) 0, outer.GetUInt64("h", x => x + 1), "Check #102 failed");

            Assert.AreEqual((ulong) 0, outer.GetUInt64("i"), "Check #103 failed");
            Assert.AreEqual((ulong) 2, outer.GetUInt64("i", 2), "Check #104 failed");
            Assert.AreEqual((ulong) 0, outer.GetUInt64("i", x => x + 1), "Check #105 failed");

            Assert.AreEqual((ulong) 0, outer.GetUInt64("j"), "Check #106 failed");
            Assert.AreEqual((ulong) 2, outer.GetUInt64("j", 2), "Check #107 failed");
            Assert.AreEqual((ulong) 0, outer.GetUInt64("j", x => x + 1), "Check #108 failed");

            Assert.AreEqual((ulong) 0, outer.GetUInt64("k"), "Check #109 failed");
            Assert.AreEqual((ulong) 2, outer.GetUInt64("k", 2), "Check #110 failed");
            Assert.AreEqual((ulong) 0, outer.GetUInt64("k", x => x + 1), "Check #111 failed");

        }

        [TestMethod]
        public void GetUInt64ByPath() {

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

            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("a"), "Check #1 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("a", 2), "Check #2 failed");
            Assert.AreEqual((ulong) 1, json.GetUInt64ByPath("a", x => x + 1), "Check #3 failed");

            Assert.AreEqual((ulong) 1234, json.GetUInt64ByPath("b"), "Check #4 failed");
            Assert.AreEqual((ulong) 1234, json.GetUInt64ByPath("b", 2), "Check #5 failed");
            Assert.AreEqual((ulong) 1235, json.GetUInt64ByPath("b", x => x + 1), "Check #6 failed");

            Assert.AreEqual((ulong) 1234, json.GetUInt64ByPath("c"), "Check #7 failed");
            Assert.AreEqual((ulong) 1234, json.GetUInt64ByPath("c", 2), "Check #8 failed");
            Assert.AreEqual((ulong) 1235, json.GetUInt64ByPath("c", x => x + 1), "Check #9 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("d"), "Check #10 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("d", 2), "Check #11 failed");
            Assert.AreEqual((ulong) 1, json.GetUInt64ByPath("d", x => x + 1), "Check #12 failed");

            Assert.AreEqual((ulong) 1, json.GetUInt64ByPath("e"), "Check #13 failed");
            Assert.AreEqual((ulong) 1, json.GetUInt64ByPath("e", 2), "Check #14 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ByPath("e", x => x + 1), "Check #15 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("f"), "Check #16 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ByPath("f", 2), "Check #17 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("f", x => x + 1), "Check #18 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("g"), "Check #19 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ByPath("g", 2), "Check #20 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("g", x => x + 1), "Check #21 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("h"), "Check #22 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ByPath("h", 2), "Check #23 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("h", x => x + 1), "Check #24 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("i"), "Check #25 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ByPath("i", 2), "Check #26 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("i", x => x + 1), "Check #27 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("j"), "Check #28 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ByPath("j", 2), "Check #29 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("j", x => x + 1), "Check #30 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("k"), "Check #31 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ByPath("k", 2), "Check #32 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("k", x => x + 1), "Check #33 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer"), "Check #34 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ByPath("outer", 2), "Check #35 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer", x => x + 1), "Check #36 failed");






            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer.a"), "Check #37 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer.a", 2), "Check #38 failed");
            Assert.AreEqual((ulong) 1, json.GetUInt64ByPath("outer.a", x => x + 1), "Check #39 failed");

            Assert.AreEqual((ulong) 1234, json.GetUInt64ByPath("outer.b"), "Check #40 failed");
            Assert.AreEqual((ulong) 1234, json.GetUInt64ByPath("outer.b", 2), "Check #41 failed");
            Assert.AreEqual((ulong) 1235, json.GetUInt64ByPath("outer.b", x => x + 1), "Check #42 failed");

            Assert.AreEqual((ulong) 1234, json.GetUInt64ByPath("outer.c"), "Check #43 failed");
            Assert.AreEqual((ulong) 1234, json.GetUInt64ByPath("outer.c", 2), "Check #44 failed");
            Assert.AreEqual((ulong) 1235, json.GetUInt64ByPath("outer.c", x => x + 1), "Check #45 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer.d"), "Check #46 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer.d", 2), "Check #47 failed");
            Assert.AreEqual((ulong) 1, json.GetUInt64ByPath("outer.d", x => x + 1), "Check #48 failed");

            Assert.AreEqual((ulong) 1, json.GetUInt64ByPath("outer.e"), "Check #49 failed");
            Assert.AreEqual((ulong) 1, json.GetUInt64ByPath("outer.e", 2), "Check #20 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ByPath("outer.e", x => x + 1), "Check #51 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer.f"), "Check #52 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ByPath("outer.f", 2), "Check #53 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer.f", x => x + 1), "Check #54 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer.g"), "Check #55failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ByPath("outer.g", 2), "Check #56 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer.g", x => x + 1), "Check #57 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer.h"), "Check #58 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ByPath("outer.h", 2), "Check #59 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer.h", x => x + 1), "Check #60 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer.i"), "Check #61 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ByPath("outer.i", 2), "Check #62 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer.i", x => x + 1), "Check #63 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer.j"), "Check #64 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ByPath("outer.j", 2), "Check #65 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer.j", x => x + 1), "Check #66 failed");

            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer.k"), "Check #67 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ByPath("outer.k", 2), "Check #68 failed");
            Assert.AreEqual((ulong) 0, json.GetUInt64ByPath("outer.k", x => x + 1), "Check #69 failed");





            Assert.AreEqual((ulong) 0, outer.GetUInt64ByPath("a"), "Check #70 failed");
            Assert.AreEqual((ulong) 0, outer.GetUInt64ByPath("a", 2), "Check #71 failed");
            Assert.AreEqual((ulong) 1, outer.GetUInt64ByPath("a", x => x + 1), "Check #72 failed");

            Assert.AreEqual((ulong) 1234, outer.GetUInt64ByPath("b"), "Check #73 failed");
            Assert.AreEqual((ulong) 1234, outer.GetUInt64ByPath("b", 2), "Check #74 failed");
            Assert.AreEqual((ulong) 1235, outer.GetUInt64ByPath("b", x => x + 1), "Check #75 failed");

            Assert.AreEqual((ulong) 1234, outer.GetUInt64ByPath("c"), "Check #76 failed");
            Assert.AreEqual((ulong) 1234, outer.GetUInt64ByPath("c", 2), "Check #77 failed");
            Assert.AreEqual((ulong) 1235, outer.GetUInt64ByPath("c", x => x + 1), "Check #78 failed");

            Assert.AreEqual((ulong) 0, outer.GetUInt64ByPath("d"), "Check #79 failed");
            Assert.AreEqual((ulong) 0, outer.GetUInt64ByPath("d", 2), "Check #80 failed");
            Assert.AreEqual((ulong) 1, outer.GetUInt64ByPath("d", x => x + 1), "Check #81 failed");

            Assert.AreEqual((ulong) 1, outer.GetUInt64ByPath("e"), "Check #82 failed");
            Assert.AreEqual((ulong) 1, outer.GetUInt64ByPath("e", 2), "Check #83failed");
            Assert.AreEqual((ulong) 2, outer.GetUInt64ByPath("e", x => x + 1), "Check #84 failed");

            Assert.AreEqual((ulong) 0, outer.GetUInt64ByPath("f"), "Check #85 failed");
            Assert.AreEqual((ulong) 2, outer.GetUInt64ByPath("f", 2), "Check #86 failed");
            Assert.AreEqual((ulong) 0, outer.GetUInt64ByPath("f", x => x + 1), "Check #87 failed");

            Assert.AreEqual((ulong) 0, outer.GetUInt64ByPath("g"), "Check #88 failed");
            Assert.AreEqual((ulong) 2, outer.GetUInt64ByPath("g", 2), "Check #89 failed");
            Assert.AreEqual((ulong) 0, outer.GetUInt64ByPath("g", x => x + 1), "Check #90 failed");

            Assert.AreEqual((ulong) 0, outer.GetUInt64ByPath("h"), "Check #100 failed");
            Assert.AreEqual((ulong) 2, outer.GetUInt64ByPath("h", 2), "Check #101 failed");
            Assert.AreEqual((ulong) 0, outer.GetUInt64ByPath("h", x => x + 1), "Check #102 failed");

            Assert.AreEqual((ulong) 0, outer.GetUInt64ByPath("i"), "Check #103 failed");
            Assert.AreEqual((ulong) 2, outer.GetUInt64ByPath("i", 2), "Check #104 failed");
            Assert.AreEqual((ulong) 0, outer.GetUInt64ByPath("i", x => x + 1), "Check #105 failed");

            Assert.AreEqual((ulong) 0, outer.GetUInt64ByPath("j"), "Check #106 failed");
            Assert.AreEqual((ulong) 2, outer.GetUInt64ByPath("j", 2), "Check #107 failed");
            Assert.AreEqual((ulong) 0, outer.GetUInt64ByPath("j", x => x + 1), "Check #108 failed");

            Assert.AreEqual((ulong) 0, outer.GetUInt64ByPath("k"), "Check #109 failed");
            Assert.AreEqual((ulong) 2, outer.GetUInt64ByPath("k", 2), "Check #110 failed");
            Assert.AreEqual((ulong) 0, outer.GetUInt64ByPath("k", x => x + 1), "Check #111 failed");

        }

        [TestMethod]
        public void GetUInt64Array() {

            JObject json = new JObject {
                {"csv", "1,2,3"},
                {"array", new JArray(1, 2, 3)},
                {"nested", new JObject {
                    {"csv", "1,2,3"},
                    {"array", new JArray(1, 2, 3)},
                }}
            };

            Assert.AreEqual(3, json.GetUInt64Array("csv").Length, "Check #1 failed");
            Assert.AreEqual((ulong) 1, json.GetUInt64Array("csv")[0], "Check #2 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64Array("csv")[1], "Check #3 failed");
            Assert.AreEqual((ulong) 3, json.GetUInt64Array("csv")[2], "Check #4 failed");

            Assert.AreEqual(3, json.GetUInt64Array("array").Length, "Check #5 failed");
            Assert.AreEqual((ulong) 1, json.GetUInt64Array("array")[0], "Check #6 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64Array("array")[1], "Check #7 failed");
            Assert.AreEqual((ulong) 3, json.GetUInt64Array("array")[2], "Check #8 failed");

            Assert.AreEqual(0, json.GetUInt64Array("nested.csv").Length, "Check #9 failed");
            Assert.AreEqual(0, json.GetUInt64Array("nested.array").Length, "Check #13 failed");

        }

        [TestMethod]
        public void GetUInt64ArrayByPath() {

            JObject json = new JObject {
                {"csv", "1,2,3"},
                {"array", new JArray(1, 2, 3)},
                {"nested", new JObject {
                    {"csv", "1,2,3"},
                    {"array", new JArray(1, 2, 3)},
                }}
            };

            Assert.AreEqual(3, json.GetUInt64ArrayByPath("csv").Length, "Check #1 failed");
            Assert.AreEqual((ulong) 1, json.GetUInt64ArrayByPath("csv")[0], "Check #2 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ArrayByPath("csv")[1], "Check #3 failed");
            Assert.AreEqual((ulong) 3, json.GetUInt64ArrayByPath("csv")[2], "Check #4 failed");

            Assert.AreEqual(3, json.GetUInt64ArrayByPath("array").Length, "Check #5 failed");
            Assert.AreEqual((ulong) 1, json.GetUInt64ArrayByPath("array")[0], "Check #6 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ArrayByPath("array")[1], "Check #7 failed");
            Assert.AreEqual((ulong) 3, json.GetUInt64ArrayByPath("array")[2], "Check #8 failed");

            Assert.AreEqual(3, json.GetUInt64ArrayByPath("nested.csv").Length, "Check #9 failed");
            Assert.AreEqual((ulong) 1, json.GetUInt64ArrayByPath("nested.csv")[0], "Check #10 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ArrayByPath("nested.csv")[1], "Check #11 failed");
            Assert.AreEqual((ulong) 3, json.GetUInt64ArrayByPath("nested.csv")[2], "Check #12 failed");

            Assert.AreEqual(3, json.GetUInt64ArrayByPath("nested.array").Length, "Check #13 failed");
            Assert.AreEqual((ulong) 1, json.GetUInt64ArrayByPath("nested.array")[0], "Check #14 failed");
            Assert.AreEqual((ulong) 2, json.GetUInt64ArrayByPath("nested.array")[1], "Check #15 failed");
            Assert.AreEqual((ulong) 3, json.GetUInt64ArrayByPath("nested.array")[2], "Check #16 failed");

        }

    }

}