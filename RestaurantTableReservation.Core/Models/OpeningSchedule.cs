namespace RestaurantTableReservation.Core.Models;

public interface IOpeningSchedule
{
    bool IsOpened(Timespan between);
}

public record OpeningSchedule(
    RegularSchedule RegularSchedule,
    IList<SpecialOpening> SpecialOpenings,
    Func<int, IList<VacationDay>> VacationDaysGenerator
) : IOpeningSchedule
{
    public bool IsOpened(Timespan between)
        => (RegularSchedule.IsOpened(between)
                && !VacationDaysGenerator(between.From.Year).Any(v => v.IsOpened(between)))
            || SpecialOpenings.Any(s => s.IsOpened(between));
}

public record RegularSchedule(IList<TimespanOfDay> Openings) : IOpeningSchedule
{
    public bool IsOpened(Timespan between)
        => Openings.Any(span => span.IsBetween(between));
}

public record VacationDay(DateOnly Day) : IOpeningSchedule
{
    public static VacationDay FromDate(int year, int month, int day)
        => new VacationDay(new DateOnly(year, month, day));

    public bool IsOpened(Timespan between)
        => Day == DateOnly.FromDateTime(between.From)
            || Day == DateOnly.FromDateTime(between.To);
}

public record SpecialOpening(Timespan Timespan) : IOpeningSchedule
{
    public bool IsOpened(Timespan between)
        => Timespan.IsBetween(between);
}
