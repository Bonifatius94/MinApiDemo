
namespace MinApiDemo;

public class ReservationServiceFactory
{
    public static RestaurantReservationService Create()
    {
        var regularSchedule = new RegularSchedule(new List<TimespanOfDay>() {
            new TimespanOfDay(DayOfWeek.Tuesday,   new TimeOnly(10, 00), new TimeOnly(14, 00)),
            new TimespanOfDay(DayOfWeek.Tuesday,   new TimeOnly(17, 00), new TimeOnly(23, 00)),
            new TimespanOfDay(DayOfWeek.Wednesday, new TimeOnly(10, 00), new TimeOnly(14, 00)),
            new TimespanOfDay(DayOfWeek.Wednesday, new TimeOnly(17, 00), new TimeOnly(23, 00)),
            new TimespanOfDay(DayOfWeek.Thursday,  new TimeOnly(17, 00), new TimeOnly(23, 00)),
            new TimespanOfDay(DayOfWeek.Friday,    new TimeOnly(10, 00), new TimeOnly(14, 00)),
            new TimespanOfDay(DayOfWeek.Friday,    new TimeOnly(17, 00), new TimeOnly(23, 00)),
            new TimespanOfDay(DayOfWeek.Saturday,  new TimeOnly(10, 00), new TimeOnly(00, 00)),
            new TimespanOfDay(DayOfWeek.Sunday,    new TimeOnly(00, 00), new TimeOnly(01, 00)),
            new TimespanOfDay(DayOfWeek.Sunday,    new TimeOnly(10, 00), new TimeOnly(23, 00)),
        });

        var specialOpenings = new List<SpecialOpening>() {

        };

        var specialClosings = new List<SpecialOpening>() {

        };

        return new RestaurantReservationService(
            new OpeningSchedule(
                regularSchedule,
                specialOpenings,
                BavarianVacationDays.OfYear
            ),
            new List<Table>() {

            },
            new List<TableReservation>() {

            }
        );
    }
}
