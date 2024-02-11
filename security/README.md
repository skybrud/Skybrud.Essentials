# Security

The `Skybrud.Essentials.Security` namespace revolves around the static `SecurityUtils` class that contains a number of methods that makes it easy to hash, encrypt or decrypt using various popular algorithms.


## Encoding

### Base64

The `Base64Encode` and `Base64Decode` methods let you encode to Base64 string and decode from a Base64 string respectively.

#### Encode

```csharp
// Encode a string value
string encoded = SecurityUtils.Base64Encode("Hello there!");

// Outputs "SGVsbG8gdGhlcmUh"
Console.WriteLine(encoded);
```

#### Decode

```csharp
// Encode a string value
string decoded = SecurityUtils.Base64Decode("SGVsbG8gdGhlcmUh");

// Outputs "Hello there!"
Console.WriteLine(decoded);
```

Notice that both methods use `Encoding.UTF8`, so results may differ when working with non-latin characters. At this time it's not supported to specify another encoding.



## Hashing

### MD5

#### As string

A MD5 hash may be formatted as a 32-character string - either with letters in lower case or in upper case. The `SecurityUtils.GetMd5` method takes an input string and returns the corresponding MD5 hash:

```csharp
// Generate the MD5 hash
string hash = SecurityUtils.GetMd5Hash("Hello there!");

// Outputs "a77b55332699835c035957df17630d28"
Console.WriteLine(hash);
```

The package contains a few method overloads that let you control the output - eg. whether the generated hash should be in lower case (default) or upper case:

```csharp
// Generate the MD5 hash
string hash = SecurityUtils.GetMd5Hash("Hello there!", HexFormat.LowerCase);

// Outputs "a77b55332699835c035957df17630d28"
Console.WriteLine(hash);
```

```csharp
// Generate the MD5 hash
string hash = SecurityUtils.GetMd5Hash("Hello there!", HexFormat.UpperCase);

// Outputs "A77B55332699835C035957DF17630D28"
Console.WriteLine(hash);
```

By default `Encoding.UTF8` is used when generating the hash, but it's also possibly to explicitly specify the encoding:

```csharp
// Generate the MD5 hash
string hash = SecurityUtils.GetMd5Hash("Rød grød med fløde", Encoding.ASCII));

// Outputs "769aeeb3658f0cb83c0ae16f1303e08b"
Console.WriteLine(hash);
```

```csharp
// Generate the MD5 hash
string hash = SecurityUtils.GetMd5Hash("Rød grød med fløde", Encoding.UTF8));

// Outputs "64d6f69ac402593bc004c8adf3db4b22"
Console.WriteLine(hash);
```

or even both HEX format and an encoding:

```csharp
// Generate the MD5 hash
string hash = SecurityUtils.GetMd5Hash("Rød grød med fløde", HexFormat.LowerCase, Encoding.ASCII));

// Outputs "769aeeb3658f0cb83c0ae16f1303e08b"
Console.WriteLine(hash);
```

```csharp
// Generate the MD5 hash
string hash = SecurityUtils.GetMd5Hash("Rød grød med fløde", HexFormat.LowerCase, Encoding.UTF8));

// Outputs "64d6f69ac402593bc004c8adf3db4b22"
Console.WriteLine(hash);
```

#### As GUID

A MD5 hash has a length that also makes it suitable to be represented as a `GUID`:

```csharp
// Generate the MD5 hash
Guid hash = SecurityUtils.GetMd5Guid("Hello there!");

// Outputs "33557ba7-9926-5c83-0359-57df17630d28"
Console.WriteLine(hash);
```

```csharp
// Generate the MD5 hash
Guid hash = SecurityUtils.GetMd5Guid("Hello there!", Encoding.UTF8);

// Outputs "33557ba7-9926-5c83-0359-57df17630d28"
Console.WriteLine(hash);
```

