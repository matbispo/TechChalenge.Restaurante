
using Dapper;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace Infra.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly string _connString;
        private readonly ILogger<CustomerRepository> logger;
        public CustomerRepository(IConfiguration config)
        {
            _connString = config.GetConnectionString("techChallengeDb");   
        }

        public long CreateCustomer(Customer customer)
        {
            var parameter = new 
            { 
                customer.Name,
                customer.Email,
                customer.Cpf
            };

            const string query = $"INSERT INTO Customer OUTPUT INSERTED.CustomerId VALUES (@Name, @Email, @CPF)";

            try
            {
                using (var sqlConnection = new SqlConnection(_connString))
                {
                    var id = sqlConnection.ExecuteScalar<int>(query, parameter);

                    return id;
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "");
                throw;
            }
        }

        public Customer? GetCustomerByCpf(string customerCpf)
        {
            var parameter = new { cpf = customerCpf };

            const string query = $"SELECT * FROM Customer WHERE CPF = @cpf";

            using (var sqlConnection = new SqlConnection(_connString))
            {
                var customer = sqlConnection.Query<Customer>(query, parameter).FirstOrDefault();

                return customer;
            }
        }

        public void UpdateCustomer(long customerId, Customer customer)
        {
            var parameter = new
            {
                customerId,
                customer.Name,
                customer.Email,
                customer.Cpf
            };

            const string query = $"UPDATE Customer SET Name = @Name, CPF = @CPF, Email = @Email WHERE CustomerId = @CustomerId";

            using (var sqlConnection = new SqlConnection(_connString))
            {
                sqlConnection.Execute(query, parameter);

            }
        }
    }
}
