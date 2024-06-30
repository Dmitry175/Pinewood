using System;
using Dapper;
using Pinewood.Entities;
using Pinewood.Exceptions;
using Pinewood.Interfaces;

namespace Pinewood.DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        private IADOProvider _adoProvider;
        public CustomerRepository(IADOProvider adoProvider)
        {
            _adoProvider = adoProvider;
        }
        public async Task AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new CustomerNullException();
            }

            string formattedDOB = customer.DateOfBirth.ToString("yyyy-MM-dd");
            string formattedDateAdded = customer.DateAdded.ToString("yyyy-MM-dd");

            var parameters = new DynamicParameters();
            parameters.Add("@name", customer.Name);
            parameters.Add("@phone", customer.Phone);
            parameters.Add("@dateofbirth", formattedDOB);
            parameters.Add("@email", customer.Email);

            string sql = $"INSERT INTO [Customers] ([Name], [DateOfBirth], [Phone], [Email], [DateAdded]) " +
            $"VALUES (@name,@dateofbirth,@phone,@email,'{formattedDateAdded}')";

            await _adoProvider.QueryAsync<Customer>(sql,parameters);
        }

        public async Task UpdateCustomer()
        {

        }

        public async Task<List<Customer>> GetCustomers()
        {
            string sql = $"SELECT * FROM [Customers]";

            var result = await _adoProvider.QueryAsync<Customer>(sql);

            return result.ToList();
        }

        

    }
}
