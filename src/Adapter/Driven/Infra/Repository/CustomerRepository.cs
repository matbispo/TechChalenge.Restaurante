using Dapper;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.Extensions.Logging;
using Domain.Entities;

namespace Infra.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {

        private readonly ILogger<CustomerRepository> logger;
        private readonly IUnitOfWork unitOfWork;
        private DbSession _session;

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

            const string query = @"INSERT INTO Customer(Name, Email, CPF) VALUES (@Name, @Email, @CPF);
                                    SELECT LAST_INSERT_ID()";

            try
            {
                unitOfWork.BeginTransaction();
                var id = _session.Connection.ExecuteScalar<long>(query, parameter, _session.Transaction);
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
    }
}
