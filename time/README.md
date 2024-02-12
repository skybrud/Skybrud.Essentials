---
icon: fa-clock-o
title: Time
---

# Time

##  EssentialsDateTime

 `EssentialsDateTime` is a class that both wraps and and extends the functionality of the `DateTime` struct in .NET, and as such can be used as a replacement for `DateTime`.

You can get an instance of `EssentialsDateTime` in a number of ways. Like `DateTime`, you can use the `Now` property to get the instance representing the current, local time:

```c#
EssentialsDateTime dt = EssentialsDateTime.Now;
```

In a similar way, you can use `EssentialsDateTime.UtcNow` and `EssentialsDateTime.Today`.

### Formats

While `DateTime` has some support for various popular date and time format, it requires some help doing so in order to work properly. `EssentialsDateTime` works well with unix time, ISO 8601, RFC 822 and RFC 2822 out of the box.

#### Unix time

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

#### ISO 8601

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

#### RFC 822

```csharp
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

#### RFC 2822

```csharp
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
### Operator overloading

As you may already be using `DateTime` in your code, Skybrud.Essentials supports converting an instance of `DateTime` to `EssentialsDateTime` using operator overloading:

```csharp
@using Skybrud.Essentials.Time
@{

    // Get the current date
    EssentialsDateTime now = DateTime.Now;
    
    // Convert the date to a string
    <pre>@now.ToString("yyyy-MM-dd HH:mm")</pre>

}
```
