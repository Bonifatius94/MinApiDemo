using LanguageExt.Common;
using RestaurantTableReservation.Core.Models;
using RestaurantTableReservation.Core.Repositories;

namespace RestaurantTableReservation.Core.Services.Implementations;

public class TableReservationService(
    IRestaurantOpeningService restaurantOpeningService,
    ICustomerRepository customerRepository,
    IRestaurantRepository restaurantRepository,
    ITableRepository tableRepository,
    ITableReservationRepository tableReservationRepository
) : ITableReservationService
{
    public Result<TableReservation> TryReserve(TableReservationRequest request)
    {
        var restaurant = restaurantRepository.FindRestaurantById(request.RestaurantId).Result;
        if (restaurant is null)
            return new Result<TableReservation>(ServiceError.OfState(ErrorState.RestaurantNotFound));

        var customer = customerRepository.FindCustomerById(request.CustomerId).Result;
        if (customer is null)
            return new Result<TableReservation>(ServiceError.OfState(ErrorState.CustomerNotFound));

        if (restaurantOpeningService.IsOpened(request.RestaurantId, request.Between) == OpeningState.Closed)
            return new Result<TableReservation>(ServiceError.OfState(ErrorState.RestaurantIsClosed));

        var tables = tableRepository.GetAllTables(request.RestaurantId).Result;
        var tablesWithSufficientCapacity = tables
            .Where(t => t.Capacity >= request.AmountOfPeople)
            .ToHashSet();

        var reservations = tableReservationRepository.GetAllReservations(request.RestaurantId).Result;
        var reservationsWithinTimespan = reservations
            .Where(r => r.Between.From > request.Between.To && r.Between.To < request.Between.From)
            .ToList();

        var freeTable = tablesWithSufficientCapacity
            .Where(t => reservationsWithinTimespan.Any(r => r.Table == t))
            .FirstOrDefault();

        var requestWithMeta = request.AttachMeta(restaurant, customer);
        var reservation = freeTable?.Reserve(requestWithMeta);

        return reservation != null
            ? new Result<TableReservation>(reservation)
            : new Result<TableReservation>(ServiceError.OfState(ErrorState.RestaurantNotFound));
    }
}
