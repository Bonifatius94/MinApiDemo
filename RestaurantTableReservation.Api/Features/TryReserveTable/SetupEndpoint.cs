using Microsoft.AspNetCore.Mvc;
using RestaurantTableReservation.Core.Repositories;
using RestaurantTableReservation.Core.Services;

namespace RestaurantTableReservation.Api.Features.TryReserveTable;

internal static class ProcessReservationEndpointSetup
{
    public static WebApplication MapTryReserveTable(this WebApplication app, string route)
    {
        app.MapPost(
                route,
                (
                    ITableReservationService reservationService,
                    ITableReservationRepository reservationRepo,
                    [FromBody] TableReservationRequestDto dto
                )
                    => dto.AsReservation().WrapAsResult()
                        .ContinueWith(reservationService.TryReserve)
                        .ContinueWith(reservationRepo.CreateReservation)
                        .AsHttpResult()
            )
            .WithName("Table Reservation Service")
            .WithOpenApi();
        return app;
    }
}
