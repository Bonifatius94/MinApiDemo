using Microsoft.Extensions.DependencyInjection;
using RestaurantTableReservation.Core.Repositories;
using RestaurantTableReservation.DAL.Repositories;

namespace RestaurantTableReservation.DAL;

public static class Registration
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ICustomerRepository, CustomerRepository>();
        services.AddSingleton<IOpeningScheduleRepository, OpeningScheduleRepository>();
        services.AddSingleton<IRestaurantRepository, RestaurantRepository>();
        services.AddSingleton<ITableRepository, TableRepository>();
        services.AddSingleton<ITableReservationRepository, TableReservationRepository>();
        return services;
    }
}
