
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;

namespace RestaurantTableReservation.Test;

public enum AmountOfPeople
{
    Two,
    Four,
    Six,
    Eight,
    Ten
}

public class TestDto
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AmountOfPeople Amount { get; set; }
}

public class StringEnumSerializerTests
{
    [Theory]
    [InlineData(AmountOfPeople.Two, "{ \"Amount\": \"Two\" }")]
    [InlineData(AmountOfPeople.Four, "{ \"Amount\": \"Four\" }")]
    [InlineData(AmountOfPeople.Six, "{ \"Amount\": \"Six\" }")]
    [InlineData(AmountOfPeople.Eight, "{ \"Amount\": \"Eight\" }")]
    [InlineData(AmountOfPeople.Ten, "{ \"Amount\": \"Ten\" }")]
    public void Test_CanSerialize_StringEnum(AmountOfPeople expAmount, string amountAsStr)
    {
        var amount = JsonSerializer.Deserialize<TestDto>(amountAsStr);
        amount.Should().BeEquivalentTo(new TestDto() { Amount = expAmount });
    }
}
