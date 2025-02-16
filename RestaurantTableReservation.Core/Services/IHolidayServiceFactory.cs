namespace RestaurantTableReservation.Core.Services;

public interface IHolidayServiceFactory
{
    IHolidayService GetHolidayService(int restaurantId);
}
