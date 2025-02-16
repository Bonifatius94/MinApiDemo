namespace RestaurantTableReservation.Core.Services;

public interface IHolidayService
{
    IList<DateOnly> GetHolidaysOfYear(int year);
}
