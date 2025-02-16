using Microsoft.Extensions.DependencyInjection;
using RestaurantTableReservation.Core.Services;
using RestaurantTableReservation.Core.Services.Implementations;

namespace RestaurantTableReservation.Core;

public static class Registration
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddSingleton<IRestaurantOpeningService, RestaurantOpeningService>();
        services.AddSingleton<ITableReservationService, TableReservationService>();
        services.AddSingleton<IHolidayServiceFactory, HolidayServiceFactory>();
        return services;
    }
}
