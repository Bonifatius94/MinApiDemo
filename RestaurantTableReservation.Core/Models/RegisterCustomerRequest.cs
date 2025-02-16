namespace RestaurantTableReservation.Core.Models;

public record RegisterCustomerRequest(
    string Name,
    string Email,
    string? Phone
);
