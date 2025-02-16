namespace RestaurantTableReservation.Core.Services.Implementations;

public class HolidayServiceFactory : IHolidayServiceFactory
{
    public IHolidayService GetHolidayService(int restaurantId)
    {
        // TODO: pick holiday generator based on the postal address of the restaurant
        return new BavarianHolidayService();
    }
}
