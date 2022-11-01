using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace UnitTestProject1.Json.Newtonsoft.JObjectTests {

    [TestClass]
    public class DoubleTests {

        [TestMethod]
        public void GetDouble() {

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

            Assert.AreEqual(0, json.GetDouble("a"), "Check #1 failed");
            Assert.AreEqual(0, json.GetDouble("a", 2), "Check #2 failed");
            Assert.AreEqual(1, json.GetDouble("a", x => x + 1), "Check #3 failed");

            Assert.AreEqual(1234, json.GetDouble("b"), "Check #4 failed");
            Assert.AreEqual(1234, json.GetDouble("b", 2), "Check #5 failed");
            Assert.AreEqual(1235, json.GetDouble("b", x => x + 1), "Check #6 failed");

            Assert.AreEqual(1234.456, json.GetDouble("c"), "Check #7 failed");
            Assert.AreEqual(1234.456, json.GetDouble("c", 2), "Check #8 failed");
            Assert.AreEqual(1235.456, json.GetDouble("c", x => x + 1), "Check #9 failed");

            Assert.AreEqual(0, json.GetDouble("d"), "Check #10 failed");
            Assert.AreEqual(0, json.GetDouble("d", 2), "Check #11 failed");
            Assert.AreEqual(1, json.GetDouble("d", x => x + 1), "Check #12 failed");

            Assert.AreEqual(1, json.GetDouble("e"), "Check #13 failed");
            Assert.AreEqual(1, json.GetDouble("e", 2), "Check #14 failed");
            Assert.AreEqual(2, json.GetDouble("e", x => x + 1), "Check #15 failed");

            Assert.AreEqual(0, json.GetDouble("f"), "Check #16 failed");
            Assert.AreEqual(2, json.GetDouble("f", 2), "Check #17 failed");
            Assert.AreEqual(0, json.GetDouble("f", x => x + 1), "Check #18 failed");

            Assert.AreEqual(0, json.GetDouble("g"), "Check #19 failed");
            Assert.AreEqual(2, json.GetDouble("g", 2), "Check #20 failed");
            Assert.AreEqual(0, json.GetDouble("g", x => x + 1), "Check #21 failed");

            Assert.AreEqual(0, json.GetDouble("h"), "Check #22 failed");
            Assert.AreEqual(2, json.GetDouble("h", 2), "Check #23 failed");
            Assert.AreEqual(0, json.GetDouble("h", x => x + 1), "Check #24 failed");

            Assert.AreEqual(0, json.GetDouble("i"), "Check #25 failed");
            Assert.AreEqual(2, json.GetDouble("i", 2), "Check #26 failed");
            Assert.AreEqual(0, json.GetDouble("i", x => x + 1), "Check #27 failed");

            Assert.AreEqual(0, json.GetDouble("j"), "Check #28 failed");
            Assert.AreEqual(2, json.GetDouble("j", 2), "Check #29 failed");
            Assert.AreEqual(0, json.GetDouble("j", x => x + 1), "Check #30 failed");

            Assert.AreEqual(0, json.GetDouble("k"), "Check #31 failed");
            Assert.AreEqual(2, json.GetDouble("k", 2), "Check #32 failed");
            Assert.AreEqual(0, json.GetDouble("k", x => x + 1), "Check #33 failed");

            Assert.AreEqual(0, json.GetDouble("outer"), "Check #34 failed");
            Assert.AreEqual(2, json.GetDouble("outer", 2), "Check #35 failed");
            Assert.AreEqual(0, json.GetDouble("outer", x => x + 1), "Check #36 failed");






            Assert.AreEqual(0, json.GetDouble("outer.a"), "Check #37 failed");
            Assert.AreEqual(2, json.GetDouble("outer.a", 2), "Check #38 failed");
            Assert.AreEqual(0, json.GetDouble("outer.a", x => x + 1), "Check #39 failed");

            Assert.AreEqual(0, json.GetDouble("outer.b"), "Check #40 failed");
            Assert.AreEqual(2, json.GetDouble("outer.b", 2), "Check #41 failed");
            Assert.AreEqual(0, json.GetDouble("outer.b", x => x + 1), "Check #42 failed");

            Assert.AreEqual(0, json.GetDouble("outer.c"), "Check #43 failed");
            Assert.AreEqual(2, json.GetDouble("outer.c", 2), "Check #44 failed");
            Assert.AreEqual(0, json.GetDouble("outer.c", x => x + 1), "Check #45 failed");

            Assert.AreEqual(0, json.GetDouble("outer.d"), "Check #46 failed");
            Assert.AreEqual(2, json.GetDouble("outer.d", 2), "Check #47 failed");
            Assert.AreEqual(0, json.GetDouble("outer.d", x => x + 1), "Check #48 failed");

            Assert.AreEqual(0, json.GetDouble("outer.e"), "Check #49 failed");
            Assert.AreEqual(2, json.GetDouble("outer.e", 2), "Check #20 failed");
            Assert.AreEqual(0, json.GetDouble("outer.e", x => x + 1), "Check #51 failed");

            Assert.AreEqual(0, json.GetDouble("outer.f"), "Check #52 failed");
            Assert.AreEqual(2, json.GetDouble("outer.f", 2), "Check #53 failed");
            Assert.AreEqual(0, json.GetDouble("outer.f", x => x + 1), "Check #54 failed");

            Assert.AreEqual(0, json.GetDouble("outer.g"), "Check #55failed");
            Assert.AreEqual(2, json.GetDouble("outer.g", 2), "Check #56 failed");
            Assert.AreEqual(0, json.GetDouble("outer.g", x => x + 1), "Check #57 failed");

            Assert.AreEqual(0, json.GetDouble("outer.h"), "Check #58 failed");
            Assert.AreEqual(2, json.GetDouble("outer.h", 2), "Check #59 failed");
            Assert.AreEqual(0, json.GetDouble("outer.h", x => x + 1), "Check #60 failed");

            Assert.AreEqual(0, json.GetDouble("outer.i"), "Check #61 failed");
            Assert.AreEqual(2, json.GetDouble("outer.i", 2), "Check #62 failed");
            Assert.AreEqual(0, json.GetDouble("outer.i", x => x + 1), "Check #63 failed");

            Assert.AreEqual(0, json.GetDouble("outer.j"), "Check #64 failed");
            Assert.AreEqual(2, json.GetDouble("outer.j", 2), "Check #65 failed");
            Assert.AreEqual(0, json.GetDouble("outer.j", x => x + 1), "Check #66 failed");

            Assert.AreEqual(0, json.GetDouble("outer.k"), "Check #67 failed");
            Assert.AreEqual(2, json.GetDouble("outer.k", 2), "Check #68 failed");
            Assert.AreEqual(0, json.GetDouble("outer.k", x => x + 1), "Check #69 failed");





            Assert.AreEqual(0, outer.GetDouble("a"), "Check #70 failed");
            Assert.AreEqual(0, outer.GetDouble("a", 2), "Check #71 failed");
            Assert.AreEqual(1, outer.GetDouble("a", x => x + 1), "Check #72 failed");

            Assert.AreEqual(1234, outer.GetDouble("b"), "Check #73 failed");
            Assert.AreEqual(1234, outer.GetDouble("b", 2), "Check #74 failed");
            Assert.AreEqual(1235, outer.GetDouble("b", x => x + 1), "Check #75 failed");

            Assert.AreEqual(1234.456, outer.GetDouble("c"), "Check #76 failed");
            Assert.AreEqual(1234.456, outer.GetDouble("c", 2), "Check #77 failed");
            Assert.AreEqual(1235.456, outer.GetDouble("c", x => x + 1), "Check #78 failed");

            Assert.AreEqual(0, outer.GetDouble("d"), "Check #79 failed");
            Assert.AreEqual(0, outer.GetDouble("d", 2), "Check #80 failed");
            Assert.AreEqual(1, outer.GetDouble("d", x => x + 1), "Check #81 failed");

            Assert.AreEqual(1, outer.GetDouble("e"), "Check #82 failed");
            Assert.AreEqual(1, outer.GetDouble("e", 2), "Check #83failed");
            Assert.AreEqual(2, outer.GetDouble("e", x => x + 1), "Check #84 failed");

            Assert.AreEqual(0, outer.GetDouble("f"), "Check #85 failed");
            Assert.AreEqual(2, outer.GetDouble("f", 2), "Check #86 failed");
            Assert.AreEqual(0, outer.GetDouble("f", x => x + 1), "Check #87 failed");

            Assert.AreEqual(0, outer.GetDouble("g"), "Check #88 failed");
            Assert.AreEqual(2, outer.GetDouble("g", 2), "Check #89 failed");
            Assert.AreEqual(0, outer.GetDouble("g", x => x + 1), "Check #90 failed");

            Assert.AreEqual(0, outer.GetDouble("h"), "Check #100 failed");
            Assert.AreEqual(2, outer.GetDouble("h", 2), "Check #101 failed");
            Assert.AreEqual(0, outer.GetDouble("h", x => x + 1), "Check #102 failed");

            Assert.AreEqual(0, outer.GetDouble("i"), "Check #103 failed");
            Assert.AreEqual(2, outer.GetDouble("i", 2), "Check #104 failed");
            Assert.AreEqual(0, outer.GetDouble("i", x => x + 1), "Check #105 failed");

            Assert.AreEqual(0, outer.GetDouble("j"), "Check #106 failed");
            Assert.AreEqual(2, outer.GetDouble("j", 2), "Check #107 failed");
            Assert.AreEqual(0, outer.GetDouble("j", x => x + 1), "Check #108 failed");

            Assert.AreEqual(0, outer.GetDouble("k"), "Check #109 failed");
            Assert.AreEqual(2, outer.GetDouble("k", 2), "Check #110 failed");
            Assert.AreEqual(0, outer.GetDouble("k", x => x + 1), "Check #111 failed");

        }

        [TestMethod]
        public void GetDoubleByPath() {

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

            Assert.AreEqual(0, json.GetDoubleByPath("a"), "Check #1 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("a", 2), "Check #2 failed");
            Assert.AreEqual(1, json.GetDoubleByPath("a", x => x + 1), "Check #3 failed");

            Assert.AreEqual(1234, json.GetDoubleByPath("b"), "Check #4 failed");
            Assert.AreEqual(1234, json.GetDoubleByPath("b", 2), "Check #5 failed");
            Assert.AreEqual(1235, json.GetDoubleByPath("b", x => x + 1), "Check #6 failed");

            Assert.AreEqual(1234.456, json.GetDoubleByPath("c"), "Check #7 failed");
            Assert.AreEqual(1234.456, json.GetDoubleByPath("c", 2), "Check #8 failed");
            Assert.AreEqual(1235.456, json.GetDoubleByPath("c", x => x + 1), "Check #9 failed");

            Assert.AreEqual(0, json.GetDoubleByPath("d"), "Check #10 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("d", 2), "Check #11 failed");
            Assert.AreEqual(1, json.GetDoubleByPath("d", x => x + 1), "Check #12 failed");

            Assert.AreEqual(1, json.GetDoubleByPath("e"), "Check #13 failed");
            Assert.AreEqual(1, json.GetDoubleByPath("e", 2), "Check #14 failed");
            Assert.AreEqual(2, json.GetDoubleByPath("e", x => x + 1), "Check #15 failed");

            Assert.AreEqual(0, json.GetDoubleByPath("f"), "Check #16 failed");
            Assert.AreEqual(2, json.GetDoubleByPath("f", 2), "Check #17 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("f", x => x + 1), "Check #18 failed");

            Assert.AreEqual(0, json.GetDoubleByPath("g"), "Check #19 failed");
            Assert.AreEqual(2, json.GetDoubleByPath("g", 2), "Check #20 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("g", x => x + 1), "Check #21 failed");

            Assert.AreEqual(0, json.GetDoubleByPath("h"), "Check #22 failed");
            Assert.AreEqual(2, json.GetDoubleByPath("h", 2), "Check #23 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("h", x => x + 1), "Check #24 failed");

            Assert.AreEqual(0, json.GetDoubleByPath("i"), "Check #25 failed");
            Assert.AreEqual(2, json.GetDoubleByPath("i", 2), "Check #26 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("i", x => x + 1), "Check #27 failed");

            Assert.AreEqual(0, json.GetDoubleByPath("j"), "Check #28 failed");
            Assert.AreEqual(2, json.GetDoubleByPath("j", 2), "Check #29 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("j", x => x + 1), "Check #30 failed");

            Assert.AreEqual(0, json.GetDoubleByPath("k"), "Check #31 failed");
            Assert.AreEqual(2, json.GetDoubleByPath("k", 2), "Check #32 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("k", x => x + 1), "Check #33 failed");

            Assert.AreEqual(0, json.GetDoubleByPath("outer"), "Check #34 failed");
            Assert.AreEqual(2, json.GetDoubleByPath("outer", 2), "Check #35 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("outer", x => x + 1), "Check #36 failed");






            Assert.AreEqual(0, json.GetDoubleByPath("outer.a"), "Check #37 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("outer.a", 2), "Check #38 failed");
            Assert.AreEqual(1, json.GetDoubleByPath("outer.a", x => x + 1), "Check #39 failed");

            Assert.AreEqual(1234, json.GetDoubleByPath("outer.b"), "Check #40 failed");
            Assert.AreEqual(1234, json.GetDoubleByPath("outer.b", 2), "Check #41 failed");
            Assert.AreEqual(1235, json.GetDoubleByPath("outer.b", x => x + 1), "Check #42 failed");

            Assert.AreEqual(1234.456, json.GetDoubleByPath("outer.c"), "Check #43 failed");
            Assert.AreEqual(1234.456, json.GetDoubleByPath("outer.c", 2), "Check #44 failed");
            Assert.AreEqual(1235.456, json.GetDoubleByPath("outer.c", x => x + 1), "Check #45 failed");

            Assert.AreEqual(0, json.GetDoubleByPath("outer.d"), "Check #46 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("outer.d", 2), "Check #47 failed");
            Assert.AreEqual(1, json.GetDoubleByPath("outer.d", x => x + 1), "Check #48 failed");

            Assert.AreEqual(1, json.GetDoubleByPath("outer.e"), "Check #49 failed");
            Assert.AreEqual(1, json.GetDoubleByPath("outer.e", 2), "Check #20 failed");
            Assert.AreEqual(2, json.GetDoubleByPath("outer.e", x => x + 1), "Check #51 failed");

            Assert.AreEqual(0, json.GetDoubleByPath("outer.f"), "Check #52 failed");
            Assert.AreEqual(2, json.GetDoubleByPath("outer.f", 2), "Check #53 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("outer.f", x => x + 1), "Check #54 failed");

            Assert.AreEqual(0, json.GetDoubleByPath("outer.g"), "Check #55failed");
            Assert.AreEqual(2, json.GetDoubleByPath("outer.g", 2), "Check #56 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("outer.g", x => x + 1), "Check #57 failed");

            Assert.AreEqual(0, json.GetDoubleByPath("outer.h"), "Check #58 failed");
            Assert.AreEqual(2, json.GetDoubleByPath("outer.h", 2), "Check #59 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("outer.h", x => x + 1), "Check #60 failed");

            Assert.AreEqual(0, json.GetDoubleByPath("outer.i"), "Check #61 failed");
            Assert.AreEqual(2, json.GetDoubleByPath("outer.i", 2), "Check #62 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("outer.i", x => x + 1), "Check #63 failed");

            Assert.AreEqual(0, json.GetDoubleByPath("outer.j"), "Check #64 failed");
            Assert.AreEqual(2, json.GetDoubleByPath("outer.j", 2), "Check #65 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("outer.j", x => x + 1), "Check #66 failed");

            Assert.AreEqual(0, json.GetDoubleByPath("outer.k"), "Check #67 failed");
            Assert.AreEqual(2, json.GetDoubleByPath("outer.k", 2), "Check #68 failed");
            Assert.AreEqual(0, json.GetDoubleByPath("outer.k", x => x + 1), "Check #69 failed");





            Assert.AreEqual(0, outer.GetDoubleByPath("a"), "Check #70 failed");
            Assert.AreEqual(0, outer.GetDoubleByPath("a", 2), "Check #71 failed");
            Assert.AreEqual(1, outer.GetDoubleByPath("a", x => x + 1), "Check #72 failed");

            Assert.AreEqual(1234, outer.GetDoubleByPath("b"), "Check #73 failed");
            Assert.AreEqual(1234, outer.GetDoubleByPath("b", 2), "Check #74 failed");
            Assert.AreEqual(1235, outer.GetDoubleByPath("b", x => x + 1), "Check #75 failed");

            Assert.AreEqual(1234.456, outer.GetDoubleByPath("c"), "Check #76 failed");
            Assert.AreEqual(1234.456, outer.GetDoubleByPath("c", 2), "Check #77 failed");
            Assert.AreEqual(1235.456, outer.GetDoubleByPath("c", x => x + 1), "Check #78 failed");

            Assert.AreEqual(0, outer.GetDoubleByPath("d"), "Check #79 failed");
            Assert.AreEqual(0, outer.GetDoubleByPath("d", 2), "Check #80 failed");
            Assert.AreEqual(1, outer.GetDoubleByPath("d", x => x + 1), "Check #81 failed");

            Assert.AreEqual(1, outer.GetDoubleByPath("e"), "Check #82 failed");
            Assert.AreEqual(1, outer.GetDoubleByPath("e", 2), "Check #83failed");
            Assert.AreEqual(2, outer.GetDoubleByPath("e", x => x + 1), "Check #84 failed");

            Assert.AreEqual(0, outer.GetDoubleByPath("f"), "Check #85 failed");
            Assert.AreEqual(2, outer.GetDoubleByPath("f", 2), "Check #86 failed");
            Assert.AreEqual(0, outer.GetDoubleByPath("f", x => x + 1), "Check #87 failed");

            Assert.AreEqual(0, outer.GetDoubleByPath("g"), "Check #88 failed");
            Assert.AreEqual(2, outer.GetDoubleByPath("g", 2), "Check #89 failed");
            Assert.AreEqual(0, outer.GetDoubleByPath("g", x => x + 1), "Check #90 failed");

            Assert.AreEqual(0, outer.GetDoubleByPath("h"), "Check #100 failed");
            Assert.AreEqual(2, outer.GetDoubleByPath("h", 2), "Check #101 failed");
            Assert.AreEqual(0, outer.GetDoubleByPath("h", x => x + 1), "Check #102 failed");

            Assert.AreEqual(0, outer.GetDoubleByPath("i"), "Check #103 failed");
            Assert.AreEqual(2, outer.GetDoubleByPath("i", 2), "Check #104 failed");
            Assert.AreEqual(0, outer.GetDoubleByPath("i", x => x + 1), "Check #105 failed");

            Assert.AreEqual(0, outer.GetDoubleByPath("j"), "Check #106 failed");
            Assert.AreEqual(2, outer.GetDoubleByPath("j", 2), "Check #107 failed");
            Assert.AreEqual(0, outer.GetDoubleByPath("j", x => x + 1), "Check #108 failed");

            Assert.AreEqual(0, outer.GetDoubleByPath("k"), "Check #109 failed");
            Assert.AreEqual(2, outer.GetDoubleByPath("k", 2), "Check #110 failed");
            Assert.AreEqual(0, outer.GetDoubleByPath("k", x => x + 1), "Check #111 failed");

        }

        [TestMethod]
        public void GetDoubleArray() {

            JObject json = new JObject {
                {"csv", "1,2,3"},
                {"array", new JArray(1, 2, 3)},
                {"nested", new JObject {
                    {"csv", "1,2,3"},
                    {"array", new JArray(1, 2, 3)},
                }}
            };

            Assert.AreEqual(3, json.GetDoubleArray("csv").Length, "Check #1 failed");
            Assert.AreEqual(1, json.GetDoubleArray("csv")[0], "Check #2 failed");
            Assert.AreEqual(2, json.GetDoubleArray("csv")[1], "Check #3 failed");
            Assert.AreEqual(3, json.GetDoubleArray("csv")[2], "Check #4 failed");

            Assert.AreEqual(3, json.GetDoubleArray("array").Length, "Check #5 failed");
            Assert.AreEqual(1, json.GetDoubleArray("array")[0], "Check #6 failed");
            Assert.AreEqual(2, json.GetDoubleArray("array")[1], "Check #7 failed");
            Assert.AreEqual(3, json.GetDoubleArray("array")[2], "Check #8 failed");

            Assert.AreEqual(0, json.GetDoubleArray("nested.csv").Length, "Check #9 failed");
            Assert.AreEqual(0, json.GetDoubleArray("nested.array").Length, "Check #13 failed");

        }

        [TestMethod]
        public void GetDoubleArrayByPath() {

            JObject json = new JObject {
                {"csv", "1,2,3"},
                {"array", new JArray(1, 2, 3)},
                {"nested", new JObject {
                    {"csv", "1,2,3"},
                    {"array", new JArray(1, 2, 3)},
                }}
            };

            Assert.AreEqual(3, json.GetDoubleArrayByPath("csv").Length, "Check #1 failed");
            Assert.AreEqual(1, json.GetDoubleArrayByPath("csv")[0], "Check #2 failed");
            Assert.AreEqual(2, json.GetDoubleArrayByPath("csv")[1], "Check #3 failed");
            Assert.AreEqual(3, json.GetDoubleArrayByPath("csv")[2], "Check #4 failed");

            Assert.AreEqual(3, json.GetDoubleArrayByPath("array").Length, "Check #5 failed");
            Assert.AreEqual(1, json.GetDoubleArrayByPath("array")[0], "Check #6 failed");
            Assert.AreEqual(2, json.GetDoubleArrayByPath("array")[1], "Check #7 failed");
            Assert.AreEqual(3, json.GetDoubleArrayByPath("array")[2], "Check #8 failed");

            Assert.AreEqual(3, json.GetDoubleArrayByPath("nested.csv").Length, "Check #9 failed");
            Assert.AreEqual(1, json.GetDoubleArrayByPath("nested.csv")[0], "Check #10 failed");
            Assert.AreEqual(2, json.GetDoubleArrayByPath("nested.csv")[1], "Check #11 failed");
            Assert.AreEqual(3, json.GetDoubleArrayByPath("nested.csv")[2], "Check #12 failed");

            Assert.AreEqual(3, json.GetDoubleArrayByPath("nested.array").Length, "Check #13 failed");
            Assert.AreEqual(1, json.GetDoubleArrayByPath("nested.array")[0], "Check #14 failed");
            Assert.AreEqual(2, json.GetDoubleArrayByPath("nested.array")[1], "Check #15 failed");
            Assert.AreEqual(3, json.GetDoubleArrayByPath("nested.array")[2], "Check #16 failed");

        }

    }

}