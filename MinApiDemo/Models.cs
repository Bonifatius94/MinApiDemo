
namespace MinApiDemo;

public record Table(
    int TableId,
    int Capacity
) {
    public TableReservation Reserve(ReservationRequest request)
        => new TableReservation(
            this, request.AmountOfPeople,
            request.Between, request.Customer
        );
};

public record Customer(
    string Name,
    string Email,
    string Phone
);

public record ReservationRequest(
    int AmountOfPeople,
    Timespan Between,
    Customer Customer
);

public record TableReservation(
    Table Table,
    int AmountOfPeople,
    Timespan Between,
    Customer Customer
);

public record Timespan(DateTime From, DateTime To) {
    public bool IsBetween(Timespan subSpan)
        => From <= subSpan.From && subSpan.To <= To;
}

public record TimespanOfDay(DayOfWeek Day, TimeOnly From, TimeOnly To) {
    public bool IsBetween(Timespan subSpan)
        => subSpan.From.DayOfWeek == Day
            && From <= TimeOnly.FromDateTime(subSpan.From)
            && (To == new TimeOnly(00, 00) || TimeOnly.FromDateTime(subSpan.To) <= To);
}

public interface IOpeningSchedule
{
    bool IsOpened(Timespan between);
}

public record RegularSchedule(IList<TimespanOfDay> Openings) : IOpeningSchedule {
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

public record SpecialOpening(Timespan Timespan) : IOpeningSchedule {
    public bool IsOpened(Timespan between)
        => Timespan.IsBetween(between);
}

public record OpeningSchedule(
    RegularSchedule RegularSchedule,
    IList<SpecialOpening> SpecialOpenings,
    Func<int, IList<VacationDay>> VacationDaysGenerator
) : IOpeningSchedule {
    public bool IsOpened(Timespan between)
        => (RegularSchedule.IsOpened(between)
                && !VacationDaysGenerator(between.From.Year).Any(v => v.IsOpened(between)))
            || SpecialOpenings.Any(s => s.IsOpened(between));
}
