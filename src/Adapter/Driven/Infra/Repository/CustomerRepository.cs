
using Dapper;
using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;

namespace Infra.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {

        private readonly ILogger<CustomerRepository> logger;
        private readonly IUnitOfWork unitOfWork;
        private DbSession _session;

        private readonly string _connString = "";

        public CustomerRepository(ILogger<CustomerRepository> logger, DbSession session, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            _session = session;
            this.unitOfWork = unitOfWork;
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
                unitOfWork.BeginTransaction();
                var id = _session.Connection.ExecuteScalar<int>(query, parameter, _session.Transaction);
                unitOfWork.Commit();

                return id;
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

            return _session.Connection.Query<Customer>(query, parameter, _session.Transaction).FirstOrDefault();
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
