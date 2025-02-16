namespace RestaurantTableReservation.DAL.Models;

public record Customer(
    int CustomerId,
    string Email,
    string Name,
    string Phone
);
