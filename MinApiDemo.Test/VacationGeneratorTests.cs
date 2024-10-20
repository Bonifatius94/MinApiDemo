using FluentAssertions;

namespace MinApiDemo.Test;

public class VacationGeneratorTests
{
    [Fact]
    public void Test_CanGenerate_VacationDays_OfYear_2024()
    {
        var vacationDays = BavarianVacationDays.OfYear(2024);

        vacationDays.Should().BeEquivalentTo(
            new List<VacationDay>() {
                VacationDay.FromDate(2024, 01, 01),
                VacationDay.FromDate(2024, 01, 06),
                VacationDay.FromDate(2024, 03, 29),
                VacationDay.FromDate(2024, 04, 01),
                VacationDay.FromDate(2024, 05, 01),
                VacationDay.FromDate(2024, 05, 09),
                VacationDay.FromDate(2024, 05, 20),
                VacationDay.FromDate(2024, 05, 30),
                VacationDay.FromDate(2024, 08, 15),
                VacationDay.FromDate(2024, 10, 03),
                VacationDay.FromDate(2024, 11, 01),
                VacationDay.FromDate(2024, 12, 25),
                VacationDay.FromDate(2024, 12, 26),
        });
    }
}
