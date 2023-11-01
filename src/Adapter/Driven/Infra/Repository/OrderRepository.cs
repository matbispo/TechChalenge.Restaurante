using Dapper;
using Domain.Entities;
using Domain.Repositories;
using Infra.Context;
using Microsoft.Extensions.Logging;

namespace Infra.Repository
{
    internal class OrderRepository : IOrderedRepository
    {
        private readonly ILogger<OrderRepository> logger;
        private readonly IUnitOfWork unitOfWork;
        private DbSession _session;

        public string? CreateOrder(Ordered ordered)
        {
            var parameter = new
            {
                ordered.OrderedId,
                ordered.RequestDate,
                ordered.TotalPrice,
                ordered.OrderStatus,
                ordered?.Customer?.CustomerId
            };

            const string query = $"INSERT INTO Ordered OUTPUT INSERTED.CustomerId VALUES (@Name, @Email, @CPF)";

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

        public IList<Ordered> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
