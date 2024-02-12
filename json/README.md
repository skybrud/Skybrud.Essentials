---
icon: fa-code
title: JSON
---

# JSON

## JsonUtils

In Skybrud.Essentials, the static <code type="Skybrud.Essentials.Json.Newtonsoft.JsonUtils, Skybrud.Essentials">JsonUtils</code> class comes with a number of helpful utility methods and other functionality for working with JSON (and [JSON.net](https://www.newtonsoft.com/json) in particular). 

For instance, you can parse or load JSON objects using the <code method="Skybrud.Essentials.Json.Newtonsoft.JsonUtils.ParseJsonObject, Skybrud.Essentials">ParseJsonObject</code> and <code method="Skybrud.Essentials.Json.Newtonsoft.JsonUtils.LoadJsonObject, Skybrud.Essentials">LoadJsonObject</code> methods respectively:

```c#
@using Skybrud.Essentials.Json.Newtonsoft
@{

    // Parse a JSON object from a string
    JObject json1 = JsonUtils.Parse("{\"hello\":\"world\"}");
    
    // Load a JSON object from a file on disk
    JObject json2 = JsonUtils.Load("C:/path/to/file.json");

}
```

The <code method="Skybrud.Essentials.Json.Newtonsoft.JsonUtils.ParseJsonObject, Skybrud.Essentials">ParseJsonObject</code> method does somewhat the same as <code method="Newtonsoft.Json.Linq.JObject.Parse, Newtonsoft.Json">JObject.Parse</code>, but JSON.net's default settings will deserialize string properties that look like dates to actual instances of <code type="System.DateTime (struct)">DateTime</code> - which when serialized back to a JSON string might not look like the original string value. The <code method="Skybrud.Essentials.Json.Newtonsoft.JsonUtils.ParseJsonObject, Skybrud.Essentials">ParseJsonObject</code> will make sure that these values will stay as strings so the format wont change.

The <code method="Skybrud.Essentials.Json.JsonUtils.Newtonsoft.LoadJsonObject, Skybrud.Essentials">LoadJsonObject</code> will read from the file so you don't have to do this your self. The contents of the file is then passed on to the <code method="Skybrud.Essentials.Json.JsonUtils.ParseJsonObject, Skybrud.Essentials">ParseJsonObject</code> method, giving the same result as described above.

## Converters

Skybrud.Essentials also comes with a number of JSON converters. For instance, there are a number of ways to serialize an enum value. Default in JSON.net is to use the enum values numeric value, but this may not always be the desired result.

So, if you wish to store your enum values using camel case (eg. `camelCase`), you can use the <code type="Skybrud.Essentials.Json.Newtonsoft.Converters.Enums.EnumCamelCaseConverter, Skybrud.Essentials">EnumCamelCaseConverter</code> on your property or enum class. In a similar way, you can convert to Pascal case (eg. `PascalCase`) using <code type="Skybrud.Essentials.Json.Newtonsoft.Converters.Enums.EnumLowerCaseConverter, Skybrud.Essentials">EnumPascalCaseConverter</code>, and to lower case (eg. `lowercase`) using <code type="Skybrud.Essentials.Json.Newtonsoft.Converters.Enums.EnumLowerCaseConverter">EnumLowerCaseConverter</code>.
