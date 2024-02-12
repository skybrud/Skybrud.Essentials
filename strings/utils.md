---
title: Utility class
---

# StringUtils

The <code type="Skybrud.Essentials.Strings.StringUtils, Skybrud.Essentials">StringUtils</code> utility class contains methods for a number of different purposes in relation to parsing or manipulating strings.

## Parsing
.NET generally has a lot of great methods for parsing strings into other types, but these methods will fail if they see a format that they don't recognize.

### ParseBoolean
For instance, there are a number of different ways to represent a boolean value as a string. The <code method="System.Boolean.Parse">Parse</code> and <code method="System.Boolean.TryParse">TryParse</code> methods in .NET only knows about `true` and `false`  as boolean values, but not values such as `True` and `False` or `1` and `0`. If the {{see:System.Boolean.Parse}} method is given a value it doesn't know, it will throw an exception.

In Skybrud.Essentials, the <code method="Skybrud.Essentials.Strings.StringUtils.ParseBoolean, Skybrud.Essentials">ParseBoolean</code> method will look for known variations of `true`, but otherwise return `false` if the value isn't recognized. No exceptions are thrown. Supported string values are `true`, `1`, `t` and `on` (all case-insensitive).

### ParseInt32
In a similar way to parsing booleans, you can parse a string value into an integer using the <code method="Skybrud.Essentials.Strings.StringUtils.ParseInt32, Skybrud.Essentials">ParseInt32</code> method. If the parsing fails, `0` will be returned instead of the method throwing any exceptions. 

```csharp
// Returns "42"
int value1 = StringUtils.ParseInt32("42");

// Returns "0"
int value2 = StringUtils.ParseInt32("hello");
```
An overload of the methods also let's you specify a fallback - so if the parsing fails, it wil return your fallback value instead of `0`:

```csharp
// Returns "123"
int value2 = StringUtils.ParseInt32("hello", 123);
```

### ParseInt32Array
If you have a string with multiple integer values, you can use the <code method="Skybrud.Essentials.Strings.StringUtils.ParseInt32Array, Skybrud.Essentials">ParseInt32Array</code> method for parsing the string value into an actual array of integers:

```csharp
int[] value = StringUtils.ParseInt32Array("1,2,3,4");
```

The method will detect the `,` (comma), ` ` (space), `\r` (carriage return), `\n` (newline) and `\t` (tab) characters as separators by default, but you can also explicitly specify the separators to be used:

```csharp
int[] value = StringUtils.ParseInt32Array("1¤2@3?4", '¤', '@', '?');
```

Any values that isn't recognized will be ignored, so again this method is safe to use without any risks of exceptions.
