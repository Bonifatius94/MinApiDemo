using RestaurantTableReservation.Core.Models;
using RestaurantTableReservation.Core.Repositories;

namespace RestaurantTableReservation.DAL.Repositories;

public class CustomerRepository : ICustomerRepository
{
    public async Task<IList<Customer>> GetAllCustomers()
    {
        // TODO: implement logic
        return await Task.FromResult(Array.Empty<Customer>());
    }

    public async Task CreateCustomer(Customer customer)
    {
        // TODO: implement logic
        await Task.Delay(100);
    }

    public Task<Customer> CreateCustomer(CustomerToRegister customer)
    {
        // TODO: implement logic
        throw new NotImplementedException();
    }

    public Task<Customer?> FindCustomerByEmail(string email)
    {
        // TODO: implement logic
        throw new NotImplementedException();
    }

    public Task<Customer?> FindCustomerById(int customerId)
    {
        // TODO: implement logic
        throw new NotImplementedException();
    }
}
