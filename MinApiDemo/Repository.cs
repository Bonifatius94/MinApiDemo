
using LanguageExt.Common;

namespace MinApiDemo;

public class RestaurantRepository
{
    public Result<TableReservation> CreateReservation(TableReservation reservation)
    {
        // TODO: write to database
        return new Result<TableReservation>(reservation);
    }
}
