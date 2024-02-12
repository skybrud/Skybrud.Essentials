# Converters

Skybrud.Essentials ships with a number of JSON converters that can make serializing and deserializing JSON a bit easier:

- [**EnumStringConverter**](./enumstringconverter.md)  
  JSON.net will by default serialize enum values to their numerical equivalent, but in many cases, it may be more ideal to use the name of the enum instead. This converter will help you doing that - and also let you control the casing used when serializing to JSON.

- [**TimeConverter**](./timeconverter.md)  
  When working with time, your JSON may use another format than the one JSON.net uses by default. By using this converter, you can serialize to or deserialize from a number of different time formats - eg. ISO 8601 or unix time.
