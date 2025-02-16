using RestaurantTableReservation.Core.Models;

namespace RestaurantTableReservation.Core.Repositories;

public interface ICustomerRepository
{
    Task<IList<Customer>> GetAllCustomers();
    Task<Customer> CreateCustomer(CustomerToRegister customer);
    Task<Customer?> FindCustomerByEmail(string email);
    Task<Customer?> FindCustomerById(int customerId);
}
