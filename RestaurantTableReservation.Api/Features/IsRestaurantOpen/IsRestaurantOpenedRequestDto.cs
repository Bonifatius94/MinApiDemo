using RestaurantTableReservation.Core.Models;

namespace RestaurantTableReservation.Api.Features.RestaurantOpening;

/// <summary>a request to find out whether the restaurant is opened within a given timespan</summary>
public class IsRestaurantOpenedRequestDto
{
    /// <example>2025-02-07T19:00:30</example>
    public DateTime From { get; set; }

    /// <example>2025-02-07T21:00:30</example>
    public DateTime To { get; set; }

    internal Timespan AsTimespan()
        => new Timespan(From, To);
};
