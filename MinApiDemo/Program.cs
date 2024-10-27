
using System.Text.Json;
using System.Text.Json.Serialization;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;
using MinApiDemo;

var restaurantRepository = new RestaurantRepository();
var reservationService = ReservationServiceFactory.Create();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JsonOptions>(
    options => options.JsonSerializerOptions.Converters.Add(
        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, allowIntegerValues: true)
    )
);

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapPost(
        "/opened",
        ([FromBody] OpeningTimespanDto dto) =>
            dto.AsTimespan().WrapAsResult()
                .ContinueWith(reservationService.IsOpened)
                .ContinueWith(r => r.ToString())
                .AsHttpResult()
    )
    .WithName("Opening Schedule")
    .WithOpenApi();

app.MapPost(
        "/reserve",
        ([FromBody] ReservationRequestDto dto)
            => dto.AsReservation().WrapAsResult()
                .ContinueWith(reservationService.TryReservate)
                .ContinueWith(restaurantRepository.CreateReservation)
                .AsHttpResult()
    )
    .WithName("Reservation Service")
    .WithOpenApi();

app.Run();

static class ResultMonadEx
{
    public static Result<T> WrapAsResult<T>(this T orig)
        => new Result<T>(orig);

    public static Result<TOut> ContinueWith<TIn, TOut>(
            this Result<TIn> input, Func<TIn, Result<TOut>> map)
        => input.Match(
            res => map(res),
            err => new Result<TOut>(err)
        );

    public static Result<TOut> ContinueWith<TIn, TOut>(
            this Result<TIn> input, Func<TIn, TOut> map)
        => input.Match(
            res => map(res),
            err => new Result<TOut>(err)
        );

    public static IResult AsHttpResult<TRes>(this Result<TRes> result)
        => result.Match(
            res => Results.Ok(res),
            err => Results.Problem(err.Message)
        );
}
