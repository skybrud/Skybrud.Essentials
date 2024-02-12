---
title: Utility class
---

# Utils

## EnumUtils class

The <code type="Skybrud.Essentials.Enums.EnumUtils">EnumUtils</code> class contains a number of helpful methods - mostly for parsing enum values.

.NET it self has similar logic for parsing enum values, but the idea with the methods in this class is that they are more forgiving and easier to use.





### ParseEnum method

The generic <code method="Skybrud.Essentials.Enums.EnumUtils.ParseEnum">EnumUtils.ParseEnum</code> method comes with a few overloads. With one of the overloads, you pass a string value as the first parameter and the enum type as a generic parameter:

```csharp
HttpStatusCode code = EnumUtils.Parse<HttpStatusCode>("ok");
```

In comparison to .NET's `Enum.Parse` method, the same statement would look like:

```csharp
HttpStatusCode code = (HttpStatusCode) Enum.Parse(typeof(HttpStatusCode), "OK");
```

The return type of the method is in this case `object`, so you will have to cast the result to `HttpStatusCode`. Also notice that the string is now `OK`, as the value must match the casing of the enum property. The {{method:Skybrud.Essentials.Enums.EnumUtils.ParseEnum}} method doesn't care about the case, meaning that it will accept a number of different casings:

```csharp
HttpStatusCode code1 = EnumUtils.ParseEnum<HttpStatusCode>("not-found"); // kebab case
HttpStatusCode code2 = EnumUtils.ParseEnum<HttpStatusCode>("not_found"); // underscore
HttpStatusCode code3 = EnumUtils.ParseEnum<HttpStatusCode>("not found"); // space
```

All three lines will correctly be parsed to `HttpStatusCode.NotFound`. Even though this method is less prone to errors, there will still be string values that can't be parsed to a enum value, which then will trigger an exception. To avoid this, you can specify a second parameter with a fallback value:

```csharp
HttpStatusCode code4 = EnumUtils.ParseEnum("nope", HttpStatusCode.NotFound);
```

As `nope` isn't an enum value of `HttpStatusCode`, the result will instead be `HttpStatusCode.NotFound`. Also notice that the method now knows about the enum type from the second parameter, so specifying the generic parameter is optional.





### TryParseEnum method

Similar to how .NET has a `Enum.TryParse` method, Skybrud.Essentials also has a <code method="Skybrud.Essentials.Enums.EnumUtils.TryParseEnum">EnumUtils.TryParseEnum</code> method that shares the behaviour of the `ParseEnum` described above.

Usage would be something like:

```csharp
if (EnumUtils.TryParseWnum("not found", out HttpStatusCode status)) {
    // Yay
}
```

Similar to <code method="Skybrud.Essentials.Enums.EnumUtils.ParseEnum">EnumUtils.ParseEnum</code>, a value like `not found` will be properly recognized by the <code method="Skybrud.Essentials.Enums.EnumUtils.TryParseEnum">EnumUtils.TryParseEnum</code> method - but not by .NET's `Enum.TryParse` method.
