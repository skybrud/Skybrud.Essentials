using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Exceptions;
using Skybrud.Essentials.IO;
using Skybrud.Essentials.Json.Newtonsoft;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace TestProject1.Json.Newtonsoft;

[TestClass]
public class LoadStreamTests {

    protected const string ObjectSample = """
                                          {
                                              "hello": "world"
                                          }
                                          """;

    protected const string ArraySample = """
                                         [
                                             {
                                                 "hello": "world"
                                             }
                                         ]
                                         """;
    [TestMethod]
    public void LoadJsonToken1() {

        using Stream stream = StreamUtils.ToStream(ObjectSample);

        JObject? result = JsonUtils.LoadJsonToken(stream) as JObject;

        Assert.IsNotNull(result);

        string? hello = result.GetString("hello");

        Assert.AreEqual("world", hello);

    }

    [TestMethod]
    public void LoadJsonToken2() {

        using Stream stream = StreamUtils.ToStream(ObjectSample);

        SampleClass? result = JsonUtils.LoadJsonToken(stream, typeof(SampleClass)) as SampleClass;

        Assert.IsNotNull(result);

        Assert.AreEqual("world", result.Hello);

    }

    [TestMethod]
    public void LoadJsonToken3() {

        using Stream stream = StreamUtils.ToStream(ObjectSample);

        SampleClass result = JsonUtils.LoadJsonToken<SampleClass>(stream);

        Assert.IsNotNull(result);

        Assert.AreEqual("world", result.Hello);

    }

    [TestMethod]
    public void LoadJsonToken4() {

        using Stream stream = StreamUtils.ToStream(ObjectSample);

        SampleClass result = JsonUtils.LoadJsonToken(stream, SampleClass.ParseToken);

        Assert.IsNotNull(result);

        Assert.AreEqual("world", result.Hello);

    }






    [TestMethod]
    public void LoadJsonObject1() {

        using Stream stream = StreamUtils.ToStream(ObjectSample);

        JObject result = JsonUtils.LoadJsonObject(stream);

        Assert.IsNotNull(result);

        string? hello = result.GetString("hello");

        Assert.AreEqual("world", hello);

    }

    [TestMethod]
    public void LoadJsonObject2() {

        using Stream stream = StreamUtils.ToStream(ObjectSample);

        SampleClass? result = JsonUtils.LoadJsonObject(stream, typeof(SampleClass)) as SampleClass;

        Assert.IsNotNull(result);

        Assert.AreEqual("world", result.Hello);

    }

    [TestMethod]
    public void LoadJsonObject3() {

        using Stream stream = StreamUtils.ToStream(ObjectSample);

        SampleClass result = JsonUtils.LoadJsonObject<SampleClass>(stream);

        Assert.IsNotNull(result);

        Assert.AreEqual("world", result.Hello);

    }

    [TestMethod]
    public void LoadJsonObject4() {

        using Stream stream = StreamUtils.ToStream(ObjectSample);

        SampleClass result = JsonUtils.LoadJsonObject(stream, SampleClass.ParseObject);

        Assert.IsNotNull(result);

        Assert.AreEqual("world", result.Hello);

    }

















    [TestMethod]
    public void LoadJsonArray1() {

        using Stream stream = StreamUtils.ToStream(ArraySample);

        JArray result = JsonUtils.LoadJsonArray(stream);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);

        JObject? first = result.FirstOrDefault() as JObject;

        string? hello = first.GetString("hello");

        Assert.AreEqual("world", hello);

    }

    [TestMethod]
    public void LoadJsonArray2() {

        using Stream stream = StreamUtils.ToStream(ArraySample);

        SampleClass[]? result = JsonUtils.LoadJsonArray(stream, typeof(SampleClass[])) as SampleClass[];

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Length);

        Assert.AreEqual("world", result[0].Hello);

    }

    [TestMethod]
    public void LoadJsonArray3() {

        using Stream stream = StreamUtils.ToStream(ArraySample);

        SampleClass[] result = JsonUtils.LoadJsonArray<SampleClass>(stream);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Length);

        Assert.AreEqual("world", result[0].Hello);

    }

    [TestMethod]
    public void LoadJsonArray4() {

        using Stream stream = StreamUtils.ToStream(ArraySample);

        SampleClass[] result = JsonUtils.LoadJsonArray(stream, SampleClass.ParseObject);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Length);

        Assert.AreEqual("world", result[0].Hello);

    }

    [TestMethod]
    public void LoadJsonArray5() {

        using Stream stream = StreamUtils.ToStream(ArraySample);

        SampleList result = JsonUtils.LoadJsonArray(stream, SampleList.Parse);

        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);

        Assert.AreEqual("world", result[0].Hello);

    }



    public class SampleList : List<SampleClass> {

        public static SampleList Parse(JArray array) {

            SampleList list = [];

            foreach (JToken token in array) {

                if (token is not JObject obj) throw new ComputerSaysNoException("Not an instance of 'JObject'.");

                list.Add(SampleClass.ParseObject(obj));

            }

            return list;

        }

    }

    public class SampleClass {

        public string? Hello { get; set; }

        public SampleClass() { }

        public SampleClass(JObject json) {
            Hello = json.GetString("hello");
        }

        public static SampleClass ParseObject(JObject json) {
            return new SampleClass(json);
        }

        public static SampleClass ParseToken(JToken token) {
            return new SampleClass(token as JObject ?? throw new ComputerSaysNoException());
        }

    }

}