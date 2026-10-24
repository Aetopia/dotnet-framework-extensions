using System.IO;
using System.IO.Extensions;
using System.Text;
using static System.Text.Encoding;

namespace System.Runtime.Serialization.Json.Extensions;

public static partial class JsonSerializer
{
    static readonly DataContractJsonSerializerSettings s_settings = new()
    {
        UseSimpleDictionaryFormat = true,
        MaxItemsInObjectGraph = int.MaxValue
    };

    static class Serializer<T>
    {
        internal static readonly DataContractJsonSerializer s_value = new(typeof(T), s_settings);
    }

    public static T Deserialize<T>(Stream stream)
    {
        return (T)Serializer<T>.s_value.ReadObject(stream);
    }

    internal static void Serialize<T>(Stream stream, T value)
    {
        Serializer<T>.s_value.WriteObject(stream, value);
    }
}

partial class JsonSerializer
{
    internal static T Deserialize<T>(string value)
    {
        using StringStream stream = new(value);
        return Deserialize<T>(stream);
    }

    internal static unsafe string Serialize<T>(T value)
    {
        MemoryStream stream = new();
        Serialize(stream, value);

        fixed (byte* bytes = stream.GetBuffer())
            return UTF8.GetString(bytes, (int)stream.Length);
    }
}