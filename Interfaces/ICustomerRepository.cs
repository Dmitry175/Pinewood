using Pinewood.Entities;

namespace Pinewood.Interfaces
{
    public interface ICustomerRepository
    {
        public Task AddCustomer(Customer customer);
        public Task<Customer> GetCustomerById(int customerId);
        public Task<List<Customer>> GetCustomers();
        public Task UpdateCustomer(Customer customer);
        public Task DeleteCustomer(int customerId);
    }
}
