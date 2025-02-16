using LanguageExt.Common;
using RestaurantTableReservation.Core.Models;
using RestaurantTableReservation.Core.Repositories;

namespace RestaurantTableReservation.Core.Services.Implementations;

public class CustomerDiscoveryService(ICustomerRepository customerRepository) : ICustomerDiscoveryService
{
    public Result<CustomerToRegister> ValidateRegistrationRequest(RegisterCustomerRequest request)
    {
        var maybeExistingCustomer = customerRepository.FindCustomerByEmail(request.Email).Result;
        if (maybeExistingCustomer is not null)
            return new CustomerToRegister(request.Name, request.Email, request.Phone);
        else
            return new Result<CustomerToRegister>(ServiceError.OfState(ErrorState.CustomerAlreadyExists));
    }
}
