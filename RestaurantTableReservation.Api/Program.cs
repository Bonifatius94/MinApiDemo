using RestaurantTableReservation.Api.Features.TryReserveTable;
using RestaurantTableReservation.Api.Features.RestaurantOpening;
using RestaurantTableReservation.Api.Middleware;

WebApplication
    .CreateBuilder()
    .AddSwaggerGeneration()
    .AddCore()
    .ConfigureJsonSerializer()
    .Build()
    .AddSwaggerUI()
    .MapIsRestaurantOpen("/isopen")
    .MapTryReserveTable("/reserve")
    .Run();
