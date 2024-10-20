
namespace MinApiDemo;

public static class BavarianVacationDays
{
    public static IList<VacationDay> OfYear(int year)
    {
        var easterSunday = EasterSunday(year);

        var holidays = new List<VacationDay>() {

            // holidays with fixed date
            VacationDay.FromDate(year, 01, 01), // Neujahr
            VacationDay.FromDate(year, 01, 06), // Heilige drei Könige
            VacationDay.FromDate(year, 05, 01), // Tag der Arbeit
            VacationDay.FromDate(year, 08, 15), // Maria Himmelfahrt
            VacationDay.FromDate(year, 10, 03), // Tag der Deutschen Einheit
            VacationDay.FromDate(year, 11, 01), // Allerheiligen
            VacationDay.FromDate(year, 12, 25), // Erster Weihnachtsfeiertag
            VacationDay.FromDate(year, 12, 26), // Zweiter Weihnachtsfeiertag

            // holidays with variable date
            new VacationDay(easterSunday.AddDays(-2)), // Karfreitag
            new VacationDay(easterSunday.AddDays(1)), // Ostermontag
            new VacationDay(easterSunday.AddDays(39)), // Christi Himmelfahrt
            new VacationDay(easterSunday.AddDays(50)), // Pfingsmontag
            new VacationDay(easterSunday.AddDays(60)), // Fronleichnam
        };

        return holidays.OrderBy(x => x.Day).ToList();
    }

    // Neujahr	Mo, 01.01.2024
    // Heilige Drei Könige	Sa, 06.01.2024
    // Karfreitag	Fr, 29.03.2024
    // Ostermontag	Mo, 01.04.2024
    // Tag der Arbeit	Mi, 01.05.2024
    // Christi Himmelfahrt	Do, 09.05.2024
    // Pfingstmontag	Mo, 20.05.2024
    // Fronleichnam	Do, 30.05.2024
    // Mariä Himmelfahrt	Do, 15.08.2024
    // Tag der Deutschen Einheit	Do, 03.10.2024
    // Allerheiligen	Fr, 01.11.2024
    // 1. Weihnachtstag	Mi, 25.12.2024
    // 2. Weihnachtstag	Do, 26.12.2024

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
