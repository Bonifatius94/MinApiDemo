using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantTableReservation.Api.Middleware;

internal static class SetupJsonSerializer
{
    public static WebApplicationBuilder ConfigureJsonSerializer(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JsonOptions>(
            options => options.JsonSerializerOptions.Converters.Add(
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, allowIntegerValues: true)
            )
        );
        return builder;
    }
}

// TODO: figure out how to use this in case it's needed
internal class IsoDateTimeConverter(string IsoFormat) : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.ParseExact(
            reader.GetString() ?? string.Empty, IsoFormat, CultureInfo.InvariantCulture
        );
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(IsoFormat));
    }
}
