namespace RestaurantTableReservation.DAL.Models;

public record SpecialOpening(
    int OpeningScheduleId,
    DateTime From,
    DateTime To
);
