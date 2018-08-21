# Skybrud.Essentials

## JSON

### JsonUtils

In Skybrud.Essentials, the static `JsonUtils` class comes with a number of helpful utility methods and other functionality for working with JSON (and [JSON.net](https://www.newtonsoft.com/json) in particular). 

For instance, you can parse or load JSON objects using the `JsonUtils.ParseJsonObject` and `JsonUtils.LoadJsonObject` methods respectively:

```c#
@using Skybrud.Essentials.Json
@{

    // Parse a JSON object from a string
    JObject json1 = JsonUtils.Parse("{\"hello\":\"world\"}");
    
    // Load a JSON object from a file on disk
    JObject json2 = JsonUtils.Load("C:/path/to/file.json");

}
```

The `JsonUtils.Parse` method does somewhat the same as `JObject.Parse`, but JSON.net's default settings will deserialize string properties that look like dates to actual instances of `DateTime` - which when serialized back to a JSON string might not look like the original string value. The `JsonUtils.Parse` will make sure that these values will stay as strings so the format wont change.

The `JsonUtils.Load` will read from the file so you don't have to do this your self. The contents of the file is then passed on to the `JsonUtils.Parse` method, giving the same result as described above.

### Converters

Skybrud.Essentials also comes with a number of JSON converters. For instance, there are a number of ways to serialize an enum value. Default in JSON.net is to use the enum values numeric value, but this may not always be the desired result.

So, if you wish to store your enum values using camel case (eg. `camelCase`), you can use the `EnumCamelCaseConverter` on your property or enum class. In a similar way, you can convert to Pascal case (eg. `PascalCase`) using `EnumPascalCaseConverter`, and to lower case (eg. `lowercase`) using `EnumLowerCaseConverter`.









## Time

###  EssentialsDateTime

 `EssentialsDateTime` is a class that both wraps and and extends the functionality of the `DateTime` struct in .NET, and as such can be used as a replacement for `DateTime`.

You can get an instance of `EssentialsDateTime` in a number of ways. Like `DateTime`, you can use the `Now` property to get the instance representing the current, local time:

```c#
EssentialsDateTime dt = EssentialsDateTime.Now;
```

In a similar way, you can use `EssentialsDateTime.UtcNow` and `EssentialsDateTime.Today`.

#### Formats

While `DateTime` has some support for various popular date and time format, it requires some help doing so in order to work properly. `EssentialsDateTime` works well with unix time, ISO 8601, RFC 822 and RFC 2822 out of the box.

##### Unix time

```c#
@using Skybrud.Essentials.Time
@{

    // Write out the current unix timestamp
    <pre>@EssentialsDateTime.CurrentUnixTimestamp</pre>

    // Get the current date
    EssentialsDateTime now = EssentialsDateTime.Now;
    
    // Write out the unix timestamp of "now"
    <pre>@now.UnixTimestamp</pre>

    // Get the timestamp for the 1st of January 2018 at 00:00 (according to CET)
    EssentialsDateTime januarFirst2018 = EssentialsDateTime.FromUnixTimestamp(1514761200);

    // Convert the date to a string (should match "2018-01-01 00:00")
    <pre>@januarFirst2018.ToLocalTime().ToString("yyyy-MM-dd HH:mm")</pre>

}
```

##### ISO 8601

```c#
@using Skybrud.Essentials.Time
@{

    // Get the current date
    EssentialsDateTime now = EssentialsDateTime.Now;
    
    // Write out the ISO 8601 string representation of "now"
    <pre>@now.ToIso8601</pre>

    // Get the timestamp for the 1st of January 2018 at 00:00 (according to CET)
    EssentialsDateTime januarFirst2018 = EssentialsDateTime.FromIso8601("2018-01-01T00:00:00+01:00");

    // Convert the date to a string (should match "2018-01-01 00:00")
    <pre>@januarFirst2018.ToString("yyyy-MM-dd HH:mm")</pre>

}
```

##### RFC 822

```c#
@using Skybrud.Essentials.Time
@{

    // Get the current date
    EssentialsDateTime now = EssentialsDateTime.Now;
    
    // Write out the RFC 822 string representation of "now"
    <pre>@now.ToRfc2822</pre>

    // Get the timestamp for the 1st of January 2018 at 00:00 (according to CET)
    EssentialsDateTime januarFirst2018 = EssentialsDateTime.FromRfc822("Mon, 01 Jan 2018 00:00:00 +0100");

    // Convert the date to a string (should match "2018-01-01 00:00")
    <pre>@januarFirst2018.ToString("yyyy-MM-dd HH:mm")</pre>

}
```

##### RFC 2822

```c#
@using Skybrud.Essentials.Time
@{

    // Get the current date
    EssentialsDateTime now = EssentialsDateTime.Now;
    
    // Write out the RFC 2822 string representation of "now"
    <pre>@now.ToRfc2822</pre>

    // Get the timestamp for the 1st of January 2018 at 00:00 (according to CET)
    EssentialsDateTime januarFirst2018 = EssentialsDateTime.FromRfc2822("Mon, 01 Jan 2018 00:00:00 +0100");

    // Convert the date to a string (should match "2018-01-01 00:00")
    <pre>@januarFirst2018.ToString("yyyy-MM-dd HH:mm")</pre>

}
```
#### Operator overloading

As you may already be using `DateTime` in your code, Skybrud.Essentials supports converting an instance of `DateTime` to `EssentialsDateTime` using operator overloading:

```c#
@using Skybrud.Essentials.Time
@{

    // Get the current date
    EssentialsDateTime now = DateTime.Now;
    
    // Convert the date to a string
    <pre>@now.ToString("yyyy-MM-dd HH:mm")</pre>

}
```
