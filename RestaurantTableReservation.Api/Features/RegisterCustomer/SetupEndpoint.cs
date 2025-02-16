using Microsoft.AspNetCore.Mvc;
using RestaurantTableReservation.Core.Repositories;
using RestaurantTableReservation.Core.Services;

namespace RestaurantTableReservation.Api.Features.RegisterCustomer;

internal static class RegisterCustomerEndpointSetup
{
    public static WebApplication MapTryReserveTable(this WebApplication app, string route)
    {
        app.MapPost(
                route,
                (
                    ICustomerDiscoveryService customerDiscoveryService,
                    ICustomerRepository reservationRepo,
                    [FromBody] RegisterCustomerRequestDto dto
                )
                    => dto.AsRequest().WrapAsResult()
                        .ContinueWith(customerDiscoveryService.ValidateRegistrationRequest)
                        .ContinueWith(reservationRepo.CreateCustomer)
                        .AsHttpResult()
            )
            .WithName("Customer Registration Service")
            .WithOpenApi();
        return app;
    }
}
