using RestaurantTableReservation.Core.Models;
using System.Text.Json.Serialization;

namespace RestaurantTableReservation.Api.Features.TryReserveTable;

/// <summary>
/// the amount of 
/// </summary>
public enum AmountOfPeople
{
    /// <summary>table for two people</summary>
    Two = 2,

    /// <summary>table for four people</summary>
    Four = 4,

    /// <summary>table for six people</summary>
    Six = 6,

    /// <summary>table for eight people</summary>
    Eight = 8,

    /// <summary>table for ten people</summary>
    Ten = 10
}

/// <summary>
/// a request to reserve a table at a given restaurant
/// </summary>
public class TableReservationRequestDto
{
    /// <example>100</example>
    public required int RestaurantId { get; set; }

    /// <example>128983</example>
    public required int CustomerId { get; set; }

    /// <example>Two</example>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required AmountOfPeople Amount { get; set; }

    /// <example>2025-02-07T19:00:30</example>
    public required DateTime From { get; set; }

    /// <example>2025-02-07T21:00:30</example>
    public required DateTime To { get; set; }

    internal TableReservationRequest AsReservation()
        => new TableReservationRequest(
            RestaurantId,
            CustomerId,
            (int)Amount,
            new Timespan(From, To)
        );
}
