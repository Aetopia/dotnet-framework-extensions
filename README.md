# .NET Framework Extensions
Provides extensions for some inbuilt .NET Framework libraries.

## [`System`](System)
- [Stringification](System/Stringification.cs)
    - Converts any .NET object into a string, unformatted or formatted.
    > Provides a quick & dirty way to display object properties at a glance.

## [`System.IO`](System.IO)
- [StringStream](System.IO/StringStream.cs)
    - Allows a .NET string to be intepreted as read only stream.
    > Useful when you need strings as streams without copying.

## [`System.Runtime.Serialization.Json`](System.Runtime.Serialization.Json)
- [`JsonSerializer`](System.Runtime.Serialization.Json/JsonSerializer.cs)
    - Provides a wrapper on top of `DataContractJsonSerializer`.
    - Provides serialization & deserialization from [strings](System.Runtime.Serialization.Json/StringStream.cs) & streams.

    > Provides a convenient & basic wrapper for dealing with JSON. 