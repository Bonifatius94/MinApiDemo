using Microsoft.AspNetCore.Mvc;
using RestaurantTableReservation.Core.Services;

namespace RestaurantTableReservation.Api.Features.RestaurantOpening;

internal static class RestaurantOpeningEndpointSetup
{
    public static WebApplication MapIsRestaurantOpen(this WebApplication app, string routeBase)
    {
        app.MapPost(
                routeBase + "/restaurant/{restaurantId}",
                (
                    IRestaurantOpeningService service,
                    [FromBody] IsRestaurantOpenedRequestDto dto,
                    [FromRoute] int restaurantId
                ) =>
                    dto.AsTimespan().WrapAsResult()
                        .ContinueWith(x => service.IsOpened(restaurantId, x))
                        .ContinueWith(r => r.ToString())
                        .AsHttpResult()
            )
            .WithName("Opening Schedule")
            .WithOpenApi();
        return app;
    }
}
