
using LanguageExt.Common;

namespace MinApiDemo;

public enum OpeningState { Open, Closed }

public record RestaurantReservationService(
    OpeningSchedule Schedule,
    IEnumerable<Table> Tables,
    IEnumerable<TableReservation> Reservations
) {
    public OpeningState IsOpened(Timespan between)
        => Schedule.IsOpened(between) ? OpeningState.Open : OpeningState.Closed;

    public Result<TableReservation> TryReservate(ReservationRequest request)
    {
        if (IsOpened(request.Between) == OpeningState.Closed)
            return new Result<TableReservation>(ApiError.OfState(ApiErrorState.RestaurantIsClosed));

        var tablesWithSufficientCapacity = Tables
            .Where(t => t.Capacity >= request.AmountOfPeople)
            .ToHashSet();

        var reservationsWithinTimespan = Reservations
            .Where(r => r.Between.From > request.Between.To && r.Between.To < request.Between.From)
            .ToList();

        var freeTable = tablesWithSufficientCapacity
            .Where(t => reservationsWithinTimespan.Any(r => r.Table == t))
            .FirstOrDefault();

        var reservation = freeTable?.Reservate(request);

        return reservation != null
            ? new Result<TableReservation>(reservation)
            : new Result<TableReservation>(ApiError.OfState(ApiErrorState.InsufficientCapacity));
    }
}
