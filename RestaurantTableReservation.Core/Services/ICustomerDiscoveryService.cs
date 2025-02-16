using LanguageExt.Common;
using RestaurantTableReservation.Core.Models;

namespace RestaurantTableReservation.Core.Services;

public interface ICustomerDiscoveryService
{
    Result<CustomerToRegister> ValidateRegistrationRequest(RegisterCustomerRequest request);
}
