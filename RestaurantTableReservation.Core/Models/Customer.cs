namespace RestaurantTableReservation.Core.Models;

public record Customer(
    int CustomerId,
    string Name,
    string Email,
    string? Phone
);

public record CustomerToRegister(
    string Name,
    string Email,
    string? Phone
);
