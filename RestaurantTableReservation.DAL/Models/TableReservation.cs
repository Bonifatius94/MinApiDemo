namespace RestaurantTableReservation.DAL.Models;

public record TableReservation(
    int RestaurantId,
    int TableId,
    int CustomerId,
    int AmountOfPeople,
    DateTime From,
    DateTime To
);
