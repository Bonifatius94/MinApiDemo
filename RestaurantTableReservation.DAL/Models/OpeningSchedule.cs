namespace RestaurantTableReservation.DAL.Models;

public enum ScheduleType
{
    Regular = 0,
}

public record OpeningSchedule(
    int OpeningScheduleId,
    int RestaurantId,
    ScheduleType ScheduleType
);
