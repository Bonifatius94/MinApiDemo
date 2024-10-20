
namespace MinApiDemo;

public class ReservationServiceFactory
{
    public static RestaurantReservationService Create()
    {
        return new RestaurantReservationService(
            new OpeningSchedule(
                new RegularSchedule(new List<Timespan>() {

                }),
                new List<SpecialOpening>() {

                },
                BavarianVacationDays.OfYear
            ),
            new List<Table>() {

            },
            new List<TableReservation>() {

            }
        );
    }
}
