namespace RestaurantTableReservation.Core.Models;

public record TableReservation(
    Restaurant Restaurant,
    Customer Customer,
    Table Table,
    int AmountOfPeople,
    Timespan Between
)
{
    public int RestaurantId => Restaurant.RestaurantId;
    public int CustomerId => Customer.CustomerId;
    public int TableId => Table.TableId;
};
