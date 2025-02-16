namespace RestaurantTableReservation.Core.Models;

public record Table(
    int TableId,
    int Capacity
)
{
    public TableReservation Reserve(TableReservationRequestWithMeta request)
        => new TableReservation(
            request.Restaurant,
            request.Customer,
            this,
            request.AmountOfPeople,
            request.Between
        );
};
