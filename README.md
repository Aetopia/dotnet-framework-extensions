# .NET Framework Extensions
Provides extensions for some inbuilt .NET Framework libraries.

## [`System`](System)
- [Stringification](System/Stringification.cs)
    > Provides a quick & dirty way to display object properties at a glance.
    - Converts any .NET object into a string, unformatted or formatted.

## [`System.IO`](System.IO)
- [StringStream](System.IO/StringStream.cs)
    > Useful when you need strings as streams without copying.
    - Allows a .NET string to be intepreted as read only stream.

## [`System.Runtime.Serialization.Json`](System.Runtime.Serialization.Json)
- [`JsonSerializer`](System.Runtime.Serialization.Json/JsonSerializer.cs)
    > Provides a convenient & basic wrapper for dealing with JSON. 
    - Provides a wrapper on top of `DataContractJsonSerializer`.
    - Provides serialization & deserialization from [strings](System.Runtime.Serialization.Json/StringStream.cs) & streams.