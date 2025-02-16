namespace RestaurantTableReservation.Core.Models;

public record TimespanOfDay(DayOfWeek Day, TimeOnly From, TimeOnly To)
{
    public bool IsBetween(Timespan subSpan)
        => subSpan.From.DayOfWeek == Day
            && From <= TimeOnly.FromDateTime(subSpan.From)
            && (To == new TimeOnly(00, 00) || TimeOnly.FromDateTime(subSpan.To) <= To);
}
