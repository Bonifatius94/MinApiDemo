using RestaurantTableReservation.Core.Models;

namespace RestaurantTableReservation.Core.Repositories;

public interface IRestaurantRepository
{
    Task<IList<Restaurant>> GetAllRestaurants();
    Task<Restaurant?> FindRestaurantById(int restaurantId);
}
