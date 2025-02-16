using RestaurantTableReservation.Core.Models;

namespace RestaurantTableReservation.Core.Repositories;

public interface ITableRepository
{
    Task<IList<Table>> GetAllTables(int restaurantId);
    Task<Table?> GetTable(int tableId);
}
