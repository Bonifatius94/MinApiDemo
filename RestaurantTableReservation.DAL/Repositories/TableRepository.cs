using RestaurantTableReservation.Core.Models;
using RestaurantTableReservation.Core.Repositories;

namespace RestaurantTableReservation.DAL.Repositories;

public class TableRepository : ITableRepository
{
    public async Task<IList<Table>> GetAllTables(int restaurantId)
    {
        // TODO: implement logic
        return await Task.FromResult(new List<Table>());
    }

    public async Task CreateTable(int restaurantId, Table table)
    {
        // TODO: implement logic
        await Task.Delay(200);
    }

    public Task<Table?> GetTable(int tableId)
    {
        throw new NotImplementedException();
    }
}
