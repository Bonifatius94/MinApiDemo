using RestaurantTableReservation.Core.Models;
using RestaurantTableReservation.Core.Repositories;

namespace RestaurantTableReservation.Core.Services.Implementations;

public class RestaurantOpeningService(
    IOpeningScheduleRepository openingScheduleRepository,
    IHolidayServiceFactory holidayServiceFactory
) : IRestaurantOpeningService
{
    public OpeningState IsOpened(int restaurantId, Timespan between)
    {
        var regularScheduleEntries = openingScheduleRepository.GetRegularOpeningSchedule(restaurantId).Result;
        var specialOpenings = openingScheduleRepository.GetSpecialOpenings(restaurantId).Result;
        var holidayService = holidayServiceFactory.GetHolidayService(restaurantId);
        var regularSchedule = new RegularSchedule(regularScheduleEntries);
        var schedule = new OpeningSchedule(
            regularSchedule,
            specialOpenings,
            year => holidayService.GetHolidaysOfYear(year).Select(x => new VacationDay(x)).ToList()
        );
        return schedule.IsOpened(between) ? OpeningState.Open : OpeningState.Closed;
    }
}
