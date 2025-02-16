namespace RestaurantTableReservation.DAL.Models;

public record RegularOpeningEntry(
    int OpeningScheduleId,
    DayOfWeek Weekday,
    TimeOnly Start,
    TimeOnly End
);
