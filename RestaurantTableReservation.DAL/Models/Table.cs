namespace RestaurantTableReservation.DAL.Models;

public record Table(
    int TableId,
    int RestaurantId,
    int Capacity
);
