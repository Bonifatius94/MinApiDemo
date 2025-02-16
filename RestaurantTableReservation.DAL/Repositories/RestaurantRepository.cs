using RestaurantTableReservation.Core.Models;
using RestaurantTableReservation.Core.Repositories;

namespace RestaurantTableReservation.DAL.Repositories;

internal class RestaurantRepository : IRestaurantRepository
{
    public Task<Restaurant?> FindRestaurantById(int restaurantId)
    {
        // TODO: implement logic
        throw new NotImplementedException();
    }

    public async Task<IList<Restaurant>> GetAllRestaurants()
    {
        // TODO: implement logic
        return await Task.FromResult(new List<Restaurant>());
    }
}
