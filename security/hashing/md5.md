# MD5

MD5 is a hashing algorithm that generates a 128-bit hash value. It may be formatted in a number of different ways, where a 32-byte hexadecimal string is the most popular.

In Skybrud.Essentials the `SecurityUtils` class in the `Skybrud.Essentials.Security` namespace contains both the `GetMd5Hash` and `GetMd5HashFromFile`  methods as well as the `GetMd5Guid` method.

## `GetMd5Hash`

The `GetMd5Hash` method takes an input string and returns a 32-byte hexadecimal string:

```csharp
// Generate the MD5 hash
string hash = SecurityUtils.GetMd5Hash("Hello there!");

// Outputs "a77b55332699835c035957df17630d28"
Console.WriteLine(hash);
```

The method has few different method that let you control the output - eg. whether the generated hash should be in lower case (default) or upper case:

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

and also both HEX format and an encoding:

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

## `GetMd5HashFromFile`

The `GetMd5HashFromFile` method lets you generate a MD5 hash directly from a file on disk:

```csharp
// Generate the MD5 hash
Guid hash = SecurityUtils.GetMd5hashFromFile("c:/obi-wan.txt");

// Outputs "a77b55332699835c035957df17630d28"
Console.WriteLine(hash);
```

The method will read the raw bytes of the file, meaning it isn't necessary to specify an encoding to be used.

## `GetMd5Guid`

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

