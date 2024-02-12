# TimeConverter

The <code type="Skybrud.Essentials.Json.Converters.Time.TimeConverter, Skybrud.Essentials">TimeConverter</code> class lets you serialize and deserialize a number of different types in both .NET and within the Skybrud.Essentials package. Currently the following types are supported:

- <code type="System.DateTime">DateTime</code>
- <code type="System.DateTimeOffset">DateTimeOffset</code>
- <code type="Skybrud.Essentials.Time.EssentialsDateTime, Skybrud.Essentials">EssentialsDateTime</code>
- <code type="Skybrud.Essentials.Time.EssentialsTime, Skybrud.Essentials">EssentialsTime</code>
- <code type="Skybrud.Essentials.Time.EssentialsDate, Skybrud.Essentials">EssentialsDate</code> *(no time, only date)*
- <code type="Skybrud.Essentials.Time.EssentialsPartialDate, Skybrud.Essentials">EssentialsPartialDate</code> *(no time, only date)*

The converter also supports a number of different standardized date and time formats:

- <code field="Skybrud.Essentials.Time.TimeFormat.Iso8601, Skybrud.Essentials">TimeFormat.Iso8601</code>  
  Indicates that the format is **ISO 8601**.
- <code field="Skybrud.Essentials.Time.TimeFormat.Rfc822, Skybrud.Essentials">TimeFormat.Rfc822</code>  
  Indicates that the format is **RFC 822**.
- <code field="Skybrud.Essentials.Time.TimeFormat.Rfc2822, Skybrud.Essentials">TimeFormat.Rfc2822</code>  
  Indicates that the format is **RFC 2822**.
- <code field="Skybrud.Essentials.Time.TimeFormat.UnixTime, Skybrud.Essentials">TimeFormat.UnixTime</code>  
  Indicates that the format is **Unix time**.

You can decorate your properties with the <code type="Newtonsoft.Json.JsonConverterAttribute, Newtonsoft.Json">JsonConverterAttribute</code> class as shown below. The converter will use <code field="Skybrud.Essentials.Time.TimeFormat.Iso8601, Skybrud.Essentials">TimeFormat.Iso8601</code> by default, but you can specify another format as well - eg. <code field="Skybrud.Essentials.Time.TimeFormat.Rfc822, Skybrud.Essentials">TimeFormat.Rfc822</code>:

```c#
public class Example {
    
    [JsonConverter(typeof(TimeConverter))]
    public DateTime Iso8601 { get; set; }
    
    [JsonConverter(typeof(TimeConverter), TimeFormat.Rfc822)]
    public DateTime Rfc822 { get; set;}
    
}
```

## Unix time

To serialize to unix time, you could use <code type="Skybrud.Essentials.Json.Newtonsoft.Converters.Time.TimeConverter, Skybrud.Essentials">TimeConverter</code> and then specify <code field="Skybrud.Essentials.Time.TimeFormat.UnixTime, Skybrud.Essentials">TimeFormat.UnixTime</code> as the second parameter for the attribute. But to make things a little easier, you could insetad use the <code type="Skybrud.Essentials.Json.Newtonsoft.Converters.Time.UnixTimeConverter, Skybrud.Essentials">UnixTimeConverter</code> class directly as shown below:

```c#
public class Example {
    
    [JsonConverter(typeof(TimeConverter), TimeFormat.UnixTime)]
    public DateTime UnixTime1 { get; set; }
    
    [JsonConverter(typeof(UnixTimeConverter))]
    public DateTime UnixTime2 { get; set;}
    
}
```
