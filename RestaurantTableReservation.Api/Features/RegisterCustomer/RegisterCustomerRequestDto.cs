using RestaurantTableReservation.Core.Models;

namespace RestaurantTableReservation.Api.Features.RegisterCustomer;

/// <summary>a request to register a new customer</summary>
public class RegisterCustomerRequestDto
{
    /// <example>Max Mustermann</example>
    public required string Name { get; set; }

    /// <summary>needs to be unique</summary>
    /// <example>max.mustermann@live.de</example>
    public required string Email { get; set; }

    /// <example>+49 176 34458972</example>
    public string? Phone { get; set; }

    internal RegisterCustomerRequest AsRequest()
        => new RegisterCustomerRequest(Name, Email, Phone);
}
