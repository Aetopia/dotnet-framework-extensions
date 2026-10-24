using System.IO;
using System.IO.Extensions;
using System.Web.Script.Serialization;
using System.Xml.Linq;
using static System.Runtime.Serialization.Json.JsonReaderWriterFactory;
using static System.Text.Encoding;
using static System.Xml.XmlDictionaryReaderQuotas;

namespace System.Extensions;

public static class Stringification
{
    static readonly JavaScriptSerializer s_serializer = new()
    {
        MaxJsonLength = int.MaxValue,
        RecursionLimit = int.MaxValue
    };

    extension<T>(T @this)
    {
        public string Stringify() => s_serializer.Serialize(@this);

        public unsafe string Formatify()
        {
            var value = @this.Stringify();
            var count = UTF8.GetByteCount(value);

            using StringStream input = new(value);
            using MemoryStream output = new(count);

            using var reader = CreateJsonReader(input, Max);
            using var writer = CreateJsonWriter(output, UTF8, false, true);

            XElement.Load(reader).WriteTo(writer);
            writer.Flush();

            fixed (byte* bytes = output.GetBuffer())
                return UTF8.GetString(bytes, (int)output.Length);
        }
    }
}