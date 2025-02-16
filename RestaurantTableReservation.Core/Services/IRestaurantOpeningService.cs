using RestaurantTableReservation.Core.Models;

namespace RestaurantTableReservation.Core.Services;

public interface IRestaurantOpeningService
{
    OpeningState IsOpened(int restaurantId, Timespan between);
}
