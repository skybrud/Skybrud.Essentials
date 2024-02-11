### Base64

The `SecurityUtils` class in the `Skybrud.Essentials.Security` contains the `Base64Encode` that lets you encode a string value to Base64 string representation and the `Base64Decode` method that lets you convert a Base64 string representation back to the original string value.

## `Base64Encode`

```csharp
// Encode a string value
string encoded = SecurityUtils.Base64Encode("Hello there!");

// Outputs "SGVsbG8gdGhlcmUh"
Console.WriteLine(encoded);
```

## `Base64Decode`

```csharp
// Encode a string value
string decoded = SecurityUtils.Base64Decode("SGVsbG8gdGhlcmUh");

// Outputs "Hello there!"
Console.WriteLine(decoded);
```

Notice that both methods use `Encoding.UTF8`, so results may differ when working with non-latin characters. At this time, it's not supported to specify another encoding.
