# SHA1

## `GetSha1Hash`

```csharp
// Generate the SHA1 hash
string hash = SecurityUtils.GetSha1Hash("Hello there!");

// Outputs "6b19cb3790b6da8f7c34b4d8895d78a56d078624"
Console.WriteLine(hash);
```

With encoding:

```csharp
// Generate the SHA1 hash
string hash = SecurityUtils.GetSha1Hash("Hello there!", Encoding.UTF8);

// Outputs "6b19cb3790b6da8f7c34b4d8895d78a56d078624"
Console.WriteLine(hash);
```

With HEX format:

```csharp
// Generate the SHA1 hash
string hash = SecurityUtils.GetSha1Hash("Hello there!", HexFormat.UpperCase));

// Outputs "6B19CB3790B6DA8F7C34B4D8895D78A56D078624"
Console.WriteLine(hash);
```

With HEX format and encoding:

```csharp
// Generate the SHA1 hash
string hash = SecurityUtils.GetSha1Hash("Hello there!", HexFormat.UpperCase, Encoding.UTF8));

// Outputs "6B19CB3790B6DA8F7C34B4D8895D78A56D078624"
Console.WriteLine(hash);
```

## `GetSha1HashFromFile`

```csharp
// Generate the SHA1 hash
Guid hash = SecurityUtils.GetSha1HashFromFile("c:/obi-wan.txt");

// Outputs "6b19cb3790b6da8f7c34b4d8895d78a56d078624"
Console.WriteLine(hash);
```

The `GetSha1HashFromFile` method currently doesn't allow specifying the desired HEX format. As the file is read from disk, a method overload taking an encoding also isn't available.
