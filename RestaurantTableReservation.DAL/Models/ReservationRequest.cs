namespace RestaurantTableReservation.DAL.Models;

public record ReservationRequest(
    int RequestId,
    int CustomerId,
    int AmountOfPeople,
    DateTime From,
    DateTime To
);
