using RestaurantTableReservation.Core.Models;

namespace RestaurantTableReservation.Core.Repositories;

public interface ITableReservationRepository
{
    Task<IList<TableReservation>> GetAllReservations(int restaurantId);
    Task CreateReservation(TableReservation reservation);
}
