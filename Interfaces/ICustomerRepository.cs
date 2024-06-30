using Pinewood.Entities;

namespace Pinewood.Interfaces
{
    public interface ICustomerRepository
    {
        public Task AddCustomer(Customer customer);

		public Task<List<Customer>> GetCustomers();
    }
}
