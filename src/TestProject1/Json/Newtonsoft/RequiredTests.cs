using System.Globalization;
using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Exceptions;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Strings.Extensions;

namespace TestProject1.Json.Newtonsoft;

[TestClass]
public class RequiredTests {

    [TestMethod]
    public void GetRequiredBoolean() {

        JObject json = new() {
            {"false", "false"},
            {"true", "true"},
            {"0a", 0},
            {"0b", "0"},
            {"1a", 1},
            {"1b", "1"},
            {"empty", ""},
            {"nope", "nope"},
            {"null", null}
        };

        Assert.IsFalse(json.GetRequiredBoolean("false"));
        Assert.AreEqual("False", json.GetRequiredBoolean("false", x => x.ToString()));

        Assert.IsTrue(json.GetRequiredBoolean("true"));
        Assert.AreEqual("True", json.GetRequiredBoolean("true", x => x.ToString()));

        Assert.IsFalse(json.GetRequiredBoolean("0a"));
        Assert.AreEqual("False", json.GetRequiredBoolean("0a", x => x.ToString()));

        Assert.IsFalse(json.GetRequiredBoolean("0b"));
        Assert.AreEqual("False", json.GetRequiredBoolean("0b", x => x.ToString()));

        Assert.IsTrue(json.GetRequiredBoolean("1a"));
        Assert.AreEqual("True", json.GetRequiredBoolean("1a", x => x.ToString()));

        Assert.IsTrue(json.GetRequiredBoolean("1b"));
        Assert.AreEqual("True", json.GetRequiredBoolean("1b", x => x.ToString()));

        // Throws 'JsonException' since the property is found, but value doesn't match
        Assert.ThrowsException<JsonException>(() => json.GetRequiredBoolean("empty"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredBoolean("nope"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredBoolean("null"));

        // Throws 'JsonPropertyNotFoundException' since the property isn't found
        Assert.ThrowsException<JsonPropertyNotFoundException>(() => json.GetRequiredBoolean("nothing"));

    }

    [TestMethod]
    public void GetRequiredDouble() {

        JObject json = new() {
            {"a", 0.25},
            {"b", "0.25"},
            {"empty", ""},
            {"nope", "nope"},
            {"null", null}
        };

        Assert.AreEqual("0.25", json.GetRequiredDouble("a").ToString("F2", CultureInfo.InvariantCulture), "a #1");
        Assert.AreEqual("1.25", json.GetRequiredDouble("a", x => x + 1).ToString("F2", CultureInfo.InvariantCulture), "a #2");

        Assert.AreEqual("0.25", json.GetRequiredDouble("b").ToString("F2", CultureInfo.InvariantCulture), "b #1");
        Assert.AreEqual("1.25", json.GetRequiredDouble("b", x => x + 1).ToString("F2", CultureInfo.InvariantCulture), "b #2");

        // Throws 'JsonException' since the property is found, but value doesn't match
        Assert.ThrowsException<JsonException>(() => json.GetRequiredDouble("empty"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredDouble("nope"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredDouble("null"));

        // Throws 'JsonPropertyNotFoundException' since the property isn't found
        Assert.ThrowsException<JsonPropertyNotFoundException>(() => json.GetRequiredDouble("nothing"));

    }

    [TestMethod]
    public void GetRequiredEnum() {

        JObject json = new() {
            {"not_found", 404},
            {"bad_request", "bad_request"},
            {"error", "INTERNAL SERVER ERROR"},
            {"empty", ""},
            {"nope", "nope"},
            {"null", null}
        };

        Assert.AreEqual(HttpStatusCode.NotFound, json.GetRequiredEnum<HttpStatusCode>("not_found"));
        Assert.AreEqual("NOT-FOUND", json.GetRequiredEnum<HttpStatusCode, string>("not_found", x => x.ToTrainCase()));

        Assert.AreEqual(HttpStatusCode.BadRequest, json.GetRequiredEnum<HttpStatusCode>("bad_request"));
        Assert.AreEqual("BAD-REQUEST", json.GetRequiredEnum<HttpStatusCode, string>("bad_request", x => x.ToTrainCase()));

        Assert.AreEqual(HttpStatusCode.InternalServerError, json.GetRequiredEnum<HttpStatusCode>("error"));
        Assert.AreEqual("INTERNAL-SERVER-ERROR", json.GetRequiredEnum<HttpStatusCode, string>("error", x => x.ToTrainCase()));

        // Throws 'JsonException' since the property is found, but value doesn't match
        Assert.ThrowsException<JsonException>(() => json.GetRequiredEnum<HttpStatusCode>("empty"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredEnum<HttpStatusCode>("nope"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredEnum<HttpStatusCode>("null"));

        // Throws 'JsonPropertyNotFoundException' since the property isn't found
        Assert.ThrowsException<JsonPropertyNotFoundException>(() => json.GetRequiredEnum<HttpStatusCode>("nothing"));

    }

    [TestMethod]
    public void GetRequiredFloat() {

        JObject json = new() {
            {"a", 0.25},
            {"b", "0.25"},
            {"empty", ""},
            {"nope", "nope"},
            {"null", null}
        };

        Assert.AreEqual("0.25", json.GetRequiredFloat("a").ToString("F2", CultureInfo.InvariantCulture), "a #1");
        Assert.AreEqual("1.25", json.GetRequiredFloat("a", x => x + 1).ToString("F2", CultureInfo.InvariantCulture), "a #2");

        Assert.AreEqual("0.25", json.GetRequiredFloat("b").ToString("F2", CultureInfo.InvariantCulture), "b #1");
        Assert.AreEqual("1.25", json.GetRequiredFloat("b", x => x + 1).ToString("F2", CultureInfo.InvariantCulture), "b #2");

        // Throws 'JsonException' since the property is found, but value doesn't match
        Assert.ThrowsException<JsonException>(() => json.GetRequiredFloat("empty"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredFloat("nope"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredFloat("null"));

        // Throws 'JsonPropertyNotFoundException' since the property isn't found
        Assert.ThrowsException<JsonPropertyNotFoundException>(() => json.GetRequiredFloat("nothing"));

    }

    [TestMethod]
    public void GetRequiredGuid() {

        JObject json = new() {
            {"a", "a890e990-dd50-4f54-bf4f-5ac8e57a8de2"},
            {"b", "00000000-0000-0000-0000-000000000000"},
            {"empty", ""},
            {"nope", "nope"},
            {"null", null}
        };

        Assert.AreEqual("a890e990-dd50-4f54-bf4f-5ac8e57a8de2", json.GetRequiredGuid("a").ToString());
        Assert.AreEqual("a890e990dd504f54bf4f5ac8e57a8de2", json.GetRequiredGuid("a", x => x.ToString("N")));

        Assert.AreEqual("00000000-0000-0000-0000-000000000000", json.GetRequiredGuid("b").ToString());
        Assert.AreEqual("00000000000000000000000000000000", json.GetRequiredGuid("b", x => x.ToString("N")));

        // Throws 'JsonException' since the property is found, but value doesn't match
        Assert.ThrowsException<JsonException>(() => json.GetRequiredGuid("empty"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredGuid("nope"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredGuid("null"));

        // Throws 'JsonPropertyNotFoundException' since the property isn't found
        Assert.ThrowsException<JsonPropertyNotFoundException>(() => json.GetRequiredGuid("nothing"));

    }

    [TestMethod]
    public void GetRequiredInt16() {

        JObject json = new() {
            {"one", 1},
            {"two", "2"},
            {"empty", ""},
            {"nope", "nope"},
            {"null", null}
        };

        Assert.AreEqual(1, json.GetRequiredInt16("one"));
        Assert.AreEqual(4, json.GetRequiredInt16("one", x => x + 3));

        Assert.AreEqual(2, json.GetRequiredInt16("two"));
        Assert.AreEqual(5, json.GetRequiredInt16("two", x => x + 3));

        // Throws 'JsonException' since the property is found, but value doesn't match
        Assert.ThrowsException<JsonException>(() => json.GetRequiredInt16("empty"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredInt16("nope"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredInt16("null"));

        // Throws 'JsonPropertyNotFoundException' since the property isn't found
        Assert.ThrowsException<JsonPropertyNotFoundException>(() => json.GetRequiredInt16("nothing"));

    }

    [TestMethod]
    public void GetRequiredInt32() {

        JObject json = new() {
            {"one", 1},
            {"two", "2"},
            {"empty", ""},
            {"nope", "nope"},
            {"null", null}
        };

        Assert.AreEqual(1, json.GetRequiredInt32("one"));
        Assert.AreEqual(4, json.GetRequiredInt32("one", x => x + 3));

        Assert.AreEqual(2, json.GetRequiredInt16("two"));
        Assert.AreEqual(5, json.GetRequiredInt16("two", x => x + 3));

        // Throws 'JsonException' since the property is found, but value doesn't match
        Assert.ThrowsException<JsonException>(() => json.GetRequiredInt32("empty"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredInt32("nope"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredInt32("null"));

        // Throws 'JsonPropertyNotFoundException' since the property isn't found
        Assert.ThrowsException<JsonPropertyNotFoundException>(() => json.GetRequiredInt32("nothing"));

    }

    [TestMethod]
    public void GetRequiredInt64() {

        JObject json = new() {
            {"one", 1},
            {"two", "2"},
            {"empty", ""},
            {"nope", "nope"},
            {"null", null}
        };

        Assert.AreEqual(1, json.GetRequiredInt64("one"));
        Assert.AreEqual(4, json.GetRequiredInt64("one", x => x + 3));

        Assert.AreEqual(2, json.GetRequiredInt64("two"));
        Assert.AreEqual(5, json.GetRequiredInt64("two", x => x + 3));

        // Throws 'JsonException' since the property is found, but value doesn't match
        Assert.ThrowsException<JsonException>(() => json.GetRequiredInt64("empty"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredInt64("nope"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredInt64("null"));

        // Throws 'JsonPropertyNotFoundException' since the property isn't found
        Assert.ThrowsException<JsonPropertyNotFoundException>(() => json.GetRequiredInt64("nothing"));

    }

    [TestMethod]
    public void GetRequiredString() {

        JObject json = new() {
            {"hello", "there"},
            {"empty", ""},
            {"null", null}
        };

        // Hello there!
        Assert.AreEqual("there", json.GetRequiredString("hello"));
        Assert.AreEqual("__there__", json.GetRequiredString("hello", x => $"__{x}__"));

        // An empty string is still a valid string
        Assert.AreEqual("", json.GetRequiredString("empty"));
        Assert.AreEqual("____", json.GetRequiredString("empty", x => $"__{x}__"));

        // Throws 'JsonException' since the property is found, but value doesn't match
        Assert.ThrowsException<JsonException>(() => json.GetRequiredString("null"));
        Assert.ThrowsException<JsonException>(() => json.GetRequiredString("null", x => x));

        // Throws 'JsonPropertyNotFoundException' since the property isn't found
        Assert.ThrowsException<JsonPropertyNotFoundException>(() => json.GetRequiredString("nothing"));
        Assert.ThrowsException<JsonPropertyNotFoundException>(() => json.GetRequiredString("nothing", x => x));

    }

}