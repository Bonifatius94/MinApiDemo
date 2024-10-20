
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using MinApiDemo;

var reservationService = ReservationServiceFactory.Create();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JsonOptions>(
    options => options.JsonSerializerOptions.Converters.Add(
        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, allowIntegerValues: true)
    )
);
// builder.Services.Configure<JsonOptions>(
//     options => options.JsonSerializerOptions.Converters.Add(
//         new IsoDateTimeConverter("yyyy-MM-dd HH:mm:ss")
//     )
// );

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapPost(
        "/opened",
        ([FromBody] OpeningTimespanDto dto) =>
            reservationService.IsOpened(dto.AsTimespan())
                ? Results.Ok("restaurant is opened")
                : Results.BadRequest("restaurant is closed")
    )
    .WithName("Opening Schedule")
    .WithOpenApi();

app.MapPost(
        "/reservate",
        ([FromBody] ReservationRequestDto dto) => reservationService.TryReservate(dto.AsReservation())
            .Match(res => Results.Ok(res), err => Results.BadRequest(err.Message))
    )
    .WithName("Reservation Service")
    .WithOpenApi();

app.Run();
