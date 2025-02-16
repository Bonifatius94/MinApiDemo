using RestaurantTableReservation.Core.Models;
using RestaurantTableReservation.Core.Repositories;

namespace RestaurantTableReservation.DAL.Repositories;

public class OpeningScheduleRepository : IOpeningScheduleRepository
{
    public async Task<IList<TimespanOfDay>> GetRegularOpeningSchedule(int restaurantId)
    {
        var rawDtos =
            new List<Models.RegularOpeningEntry>() {
                new Models.RegularOpeningEntry(1,  DayOfWeek.Tuesday,   new TimeOnly(10, 00), new TimeOnly(14, 00)),
                new Models.RegularOpeningEntry(2,  DayOfWeek.Tuesday,   new TimeOnly(17, 00), new TimeOnly(23, 00)),
                new Models.RegularOpeningEntry(3,  DayOfWeek.Wednesday, new TimeOnly(10, 00), new TimeOnly(14, 00)),
                new Models.RegularOpeningEntry(4,  DayOfWeek.Wednesday, new TimeOnly(17, 00), new TimeOnly(23, 00)),
                new Models.RegularOpeningEntry(5,  DayOfWeek.Thursday,  new TimeOnly(17, 00), new TimeOnly(23, 00)),
                new Models.RegularOpeningEntry(6,  DayOfWeek.Friday,    new TimeOnly(10, 00), new TimeOnly(14, 00)),
                new Models.RegularOpeningEntry(7,  DayOfWeek.Friday,    new TimeOnly(17, 00), new TimeOnly(23, 00)),
                new Models.RegularOpeningEntry(8,  DayOfWeek.Saturday,  new TimeOnly(10, 00), new TimeOnly(00, 00)),
                new Models.RegularOpeningEntry(9,  DayOfWeek.Sunday,    new TimeOnly(00, 00), new TimeOnly(01, 00)),
                new Models.RegularOpeningEntry(10, DayOfWeek.Sunday,    new TimeOnly(10, 00), new TimeOnly(23, 00)),
            };

        return await Task.FromResult(rawDtos.Select(MapDto).ToList());
    }

    public async Task<IList<SpecialOpening>> GetSpecialOpenings(int restaurantId)
    {
        return await Task.FromResult(
            new List<SpecialOpening>() {
                new SpecialOpening(
                    new Timespan(
                        new DateTime(2025, 12, 31, 18, 00, 00),
                        new DateTime(2026, 01, 01, 02, 00, 00)
                    )
                )
            });
    }

    private static TimespanOfDay MapDto(Models.RegularOpeningEntry dbDto)
        => new TimespanOfDay(dbDto.Weekday, dbDto.Start, dbDto.End);
}
