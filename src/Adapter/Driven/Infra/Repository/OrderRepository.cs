using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Context;
using Microsoft.Extensions.Logging;

namespace Infra.Repository
{
    internal class OrderRepository : IOrderRepository
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
                ordered?.CustomerId,
                ordered?.IsActive
            };

            const string queryOrder = $"INSERT INTO Ordered VALUES (@OrderedId, @RequestDate, @TotalPrice, @OrderStatus, @CustomerId, @IsActive)";

            _session.Connection.Execute(queryOrder, parameterOrder, _session.Transaction);
        }

        private void InsertOrderProduct(Ordered ordered)
        {
            var productOrdered = new List<object>();

            foreach (var products in ordered.Products)
            {
                productOrdered.Add(new { OrderedId = ordered.OrderedId, ProductId = products.ProductId });
            }

            const string queryProductOrder = @"INSERT INTO ProductOrdered VALUES(@OrderedId, @ProductId)";

            _session.Connection.Execute(queryProductOrder, productOrdered, _session.Transaction);
        }

        public IEnumerable<Ordered> GetAll()
        {
            try
            {
                var sql = @"SELECT 
	                            o.OrderedId, o.RequestDate, o.TotalPrice, o.OrderStatus, o.CustomerId, 
	                            p.ProductId, p.Name, p.Price, p.Category, p.Description 
                            FROM ProductOrdered AS po 
                            INNER JOIN Ordered AS o 
                            ON po.OrderedId = o.OrderedId 
                            INNER JOIN Product AS p
                            on po.ProductId = p.ProductId 
                            WHERE o.IsActive = 1";
                ;

                var orders = _session.Connection.Query<Ordered, Product, Ordered>(sql, (order, product) => {
                    order.Products.Add(product);
                    return order;
                }, splitOn: "ProductId");

                var ordersResult = orders.GroupBy(p => p.OrderedId).Select(g =>
                {
                    var groupedOrder = g.First();
                    groupedOrder.Products = g.Select(p => p.Products.Single()).ToList();
                    return groupedOrder;
                });

                return ordersResult;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao consultar todos os pedidos");
                throw;
            }
        }
    }
}
