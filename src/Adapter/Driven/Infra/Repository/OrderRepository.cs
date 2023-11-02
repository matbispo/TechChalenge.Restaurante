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

        public OrderRepository(ILogger<OrderRepository> logger, IUnitOfWork unitOfWork, DbSession session)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            _session = session;
        }

        public string? CreateOrder(Ordered ordered)
        {           
            try
            {
                unitOfWork.BeginTransaction();

                InsertOrder(ordered);

                InsertOrderProduct(ordered);

                unitOfWork.Commit();

                return ordered.OrderedId.ToString();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                logger.LogError(ex, $"Falha ao inserir o pedido: {ordered.OrderedId}");
                throw;
            }
        }

        private void InsertOrder(Ordered ordered)
        {
            var parameterOrder = new
            {
                ordered.OrderedId,
                ordered.RequestDate,
                ordered.TotalPrice,
                ordered.OrderStatus,
                ordered?.Customer?.CustomerId,
                ordered?.IsActive
            };

            const string queryOrder = $"INSERT INTO Ordered VALUES (@OrderedId, @RequestDate, @TotalPrice, @OrderStatus, @CustomerId, @IsActive)";

            _session.Connection.Execute(queryOrder, parameterOrder, _session.Transaction);
        }

        private void InsertOrderProduct(Ordered ordered)
        {
            var productOrdered = new List<ProductOrdered>();

            foreach (var products in ordered.Products)
            {
                productOrdered.Add(new ProductOrdered { OrderedId = ordered.OrderedId, ProductId = products.ProductId });
            }

            const string queryProductOrder = @"INSERT INTO ProductOrdered VALUES(@OrderedId, @ProductId)";

            _session.Connection.Execute(queryProductOrder, productOrdered, _session.Transaction);
        }

        public IList<Ordered> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
