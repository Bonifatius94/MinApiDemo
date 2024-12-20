
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MinApiDemo;

public class IsoDateTimeConverter(string IsoFormat) : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Debug.Assert(typeToConvert == typeof(DateTime));
        return DateTime.ParseExact(
            reader.GetString() ?? string.Empty, IsoFormat, CultureInfo.InvariantCulture
        );
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(IsoFormat));
    }
}
