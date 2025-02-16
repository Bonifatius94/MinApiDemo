using RestaurantTableReservation.Core.Models;

namespace RestaurantTableReservation.Core.Repositories;

public interface IOpeningScheduleRepository
{
    Task<IList<TimespanOfDay>> GetRegularOpeningSchedule(int restaurantId);
    Task<IList<SpecialOpening>> GetSpecialOpenings(int restaurantId);
}
