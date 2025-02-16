namespace RestaurantTableReservation.Core.Models;

public record Timespan(DateTime From, DateTime To)
{
    public bool IsBetween(Timespan subSpan)
        => From <= subSpan.From && subSpan.To <= To;
}
