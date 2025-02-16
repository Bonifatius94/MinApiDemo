namespace RestaurantTableReservation.Core.Models;

public record Restaurant(
    int RestaurantId,
    string RestaurantName,
    string Street,
    string BuildingNumber,
    string PostalCode,
    string City
);
