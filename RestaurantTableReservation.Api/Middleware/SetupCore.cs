using RestaurantTableReservation.Core;
using RestaurantTableReservation.DAL;

namespace RestaurantTableReservation.Api.Middleware;

internal static class SetupCore
{
    public static WebApplicationBuilder AddCore(this WebApplicationBuilder builder)
    {
        builder.Services.AddRepositories();
        builder.Services.AddCoreServices();
        return builder;
    }
}
