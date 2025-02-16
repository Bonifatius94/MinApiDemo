
namespace RestaurantTableReservation.Core.Models;

public record TableReservationRequest(
    int RestaurantId,
    int CustomerId,
    int AmountOfPeople,
    Timespan Between
)
{
    public TableReservationRequestWithMeta AttachMeta(Restaurant restaurant, Customer customer)
        => new TableReservationRequestWithMeta(restaurant, customer, AmountOfPeople, Between);
}

public record TableReservationRequestWithMeta(
    Restaurant Restaurant,
    Customer Customer,
    int AmountOfPeople,
    Timespan Between
)
{
    public int RestaurantId => Restaurant.RestaurantId;
    public int CustomerId => Customer.CustomerId;
};
