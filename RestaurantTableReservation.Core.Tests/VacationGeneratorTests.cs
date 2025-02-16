using FluentAssertions;
using RestaurantTableReservation.Core.Services;

namespace RestaurantTableReservation.Test;

public class VacationGeneratorTests
{
    [Fact]
    public void Test_CanGenerate_VacationDays_OfYear_2024()
    {
        var holidayService = new BavarianHolidayService();

        var holidays = holidayService.GetHolidaysOfYear(2024);

        holidays.Should().BeEquivalentTo(
            new List<DateOnly>() {
                new DateOnly(2024, 01, 01),
                new DateOnly(2024, 01, 06),
                new DateOnly(2024, 03, 29),
                new DateOnly(2024, 04, 01),
                new DateOnly(2024, 05, 01),
                new DateOnly(2024, 05, 09),
                new DateOnly(2024, 05, 20),
                new DateOnly(2024, 05, 30),
                new DateOnly(2024, 08, 15),
                new DateOnly(2024, 10, 03),
                new DateOnly(2024, 11, 01),
                new DateOnly(2024, 12, 25),
                new DateOnly(2024, 12, 26),
        });
    }
}
