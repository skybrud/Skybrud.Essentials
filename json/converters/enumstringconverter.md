# EnumStringConverter

The <code type="Skybrud.Essentials.Json.Newtonsoft.Converters.Enums.EnumStringConverter">EnumStringConverter</code> JSON converter will take an enum value and serialize it to it's string equivalent.

By default, the string value will be based on the *Pascal cased* version of the enum name, but other text casings are supported as well. Using Pascal casing as default follows the conventions in .NET, and also matches calling the `ToString` method on the enum value.

When creating your enum class, you can decorate the type with the <code type="type:Newtonsoft.Json.JsonConverterAttribute">JsonConverterAttribute</code> class as following:

```c#
[JsonConverter(typeof(StringEnumConverter))]
public enum Test {
    HelloWorld,
    HiWorld
}
```

As mentioned, this will make sure that a value of this type is serialized to a *Pascal cased* string - eg. `HelloWorld` or `HiWorld`.

The <code type="Skybrud.Essentials.Json.Newtonsoft.Converters.Enums.EnumStringConverter">EnumStringConverter</code> class does however also support specifying another text casing to be used instead. This could be *camel case*:

```c#
[JsonConverter(typeof(StringEnumConverter), TextCasing.CamelCase)]
public enum Test {
    HelloWorld,
    HiWorld
}
```

While *Pascal case* starts with an uppercase letter, *camel case* will start with a lowercase letter instead, but otherwise they're the same. So `HelloWorld` and `HiWorld` would instead be `helloWorld` and `hiWorld` respectively. Another example could be *kebab case*:

```c#
[JsonConverter(typeof(StringEnumConverter), TextCasing.KebabCase)]
public enum Test {
    HelloWorld,
    HiWorld
}
```

Following this casing, the result will be a lowercase string with words separated by commas - eg. `hello-world` or `hi-world`. You can see the <code type="Skybrud.Essentials.Strings.TextCasing">TextCasing</code> enum class for a list of supported casings.

### Deserializing

For each enum value, we have a single value in C# that can be serialized to a number of different values depending on the format of the JSON converter. When deserializing back to an enum value in C#, it's the other way around. This means that we have a number of possible string values can be parsed back to a single enum value in C#.

This means that the deserializing logic supports other casings than the one specified for the current <code type="Skybrud.Essentials.Json.Newtonsoft.Converters.Enums.EnumStringConverter">EnumStringConverter</code>.
