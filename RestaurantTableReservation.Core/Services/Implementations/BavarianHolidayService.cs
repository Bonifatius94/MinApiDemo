namespace RestaurantTableReservation.Core.Services;

public class BavarianHolidayService : IHolidayService
{
    public IList<DateOnly> GetHolidaysOfYear(int year)
    {
        var easterSunday = EasterSunday(year);

        var holidays = new List<DateOnly>() {

            // holidays with fixed date
            new DateOnly(year, 01, 01), // Neujahr
            new DateOnly(year, 01, 06), // Heilige drei Könige
            new DateOnly(year, 05, 01), // Tag der Arbeit
            new DateOnly(year, 08, 15), // Maria Himmelfahrt
            new DateOnly(year, 10, 03), // Tag der Deutschen Einheit
            new DateOnly(year, 11, 01), // Allerheiligen
            new DateOnly(year, 12, 25), // Erster Weihnachtsfeiertag
            new DateOnly(year, 12, 26), // Zweiter Weihnachtsfeiertag

            // holidays with variable date
            easterSunday.AddDays(-2), // Karfreitag
            easterSunday.AddDays(1), // Ostermontag
            easterSunday.AddDays(39), // Christi Himmelfahrt
            easterSunday.AddDays(50), // Pfingsmontag
            easterSunday.AddDays(60), // Fronleichnam
        };

        return holidays.OrderBy(x => x.Day).ToList();
    }

    // source: https://stackoverflow.com/questions/26022233/calculate-the-date-of-easter-sunday
    private static DateOnly EasterSunday(int year)
    {
        int a = year % 19;
        int b = year / 100;
        int c = year % 100;
        int d = b / 4;
        int e = b % 4;
        int g = (8 * b + 13) / 25;
        int h = (19 * a + b - d - g + 15) % 30;
        int j = c / 4;
        int k = c % 4;
        int m = (a + 11 * h) / 319;
        int r = (2 * e + 2 * j - k - h + m + 32) % 7;
        int n = (h - m + r + 90) / 25;
        int p = (h - m + r + n + 19) % 32;
        return new DateOnly(year, n, p);
    }
}
