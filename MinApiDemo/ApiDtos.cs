
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MinApiDemo;

public class OpeningTimespanDto
{
    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public Timespan AsTimespan()
        => new Timespan(From, To);
};

public enum AmountOfPeople
{
    Two = 2,
    Four = 4,
    Six = 6,
    Eight = 8,
    Ten = 10
}

public class ReservationRequestDto
{
    // const string ISO_DATETIME_REGEX =
    //     "^(\\d{4})\\-(0?[1-9]|1[012])\\-(0?[1-9]|[12][0-9]|3[01]) ([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$";

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AmountOfPeople Amount { get; set; }

    // [Required]
    // [RegularExpression("yyyy-MM-dd HH:mm:ss")]
    public DateTime From { get; set; }

    // [Required]
    // [RegularExpression("yyyy-MM-dd HH:mm:ss")]
    public DateTime To { get; set; }

    [Required]
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public ReservationRequest AsReservation()
        => new ReservationRequest(
            (int)Amount,
            new Timespan(From, To),
            new Reservator(Name, Email, Phone)
        );
}

// TODO: add validator to check wether either email or phone is set
