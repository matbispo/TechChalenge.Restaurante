using Dapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.ValueObjects;
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

        public string? CreateOrder(Order ordered)
        {           
            try
            {
                unitOfWork.BeginTransaction();

                InsertOrder(ordered);

                InsertOrderProduct(ordered);

                unitOfWork.Commit();

                return ordered.OrderId.ToString();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                logger.LogError(ex, $"Falha ao inserir o pedido: {ordered.OrderId}");
                throw;
            }
        }

        private void InsertOrder(Order ordered)
        {
            var parameterOrder = new
            {
                ordered.OrderId,
                ordered.RequestDate,
                ordered.TotalPrice,
                ordered.OrderStatus,
                ordered?.CustomerId,
                ordered?.IsActive
            };

            const string queryOrder = $"INSERT INTO Ordered VALUES (@OrderedId, @RequestDate, @TotalPrice, @OrderStatus, @CustomerId, @IsActive)";

            _session.Connection.Execute(queryOrder, parameterOrder, _session.Transaction);
        }

        private void InsertOrderProduct(Order ordered)
        {
            var productOrdered = new List<object>();

            foreach (var products in ordered.Products)
            {
                productOrdered.Add(new { OrderedId = ordered.OrderId, ProductId = products.ProductId });
            }

            const string queryProductOrder = @"INSERT INTO ProductOrdered VALUES(@OrderedId, @ProductId)";

            _session.Connection.Execute(queryProductOrder, productOrdered, _session.Transaction);
        }

        public IEnumerable<Order> GetAll()
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

                var orders = _session.Connection.Query<Order, Product, Order>(sql, (order, product) => {
                    order.Products.Add(product);
                    return order;
                }, splitOn: "ProductId");

                var ordersResult = orders.GroupBy(p => p.OrderId).Select(g =>
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

        public void UpdateOrderStatus(string orderId, OrderStatus orderStatus)
        {
            var parameterOrder = new
            {
                orderId,
                orderStatus,
            };

            const string queryOrder = $"UPDATE Ordered SET OrderStatus = orderStatus WHERE OrderId = @orderId;";

            _session.Connection.Execute(queryOrder, parameterOrder, _session.Transaction);
        }

        public OrderStatus GetOrderPaymentStatus(string orderId)
        {
            var parameter = new { OrderId = orderId };

            const string query = $"SELECT OrderStatus FROM Order WHERE OrderId = @OrderId;";

            return _session.Connection.Query<OrderStatus>(query, parameter, _session.Transaction).FirstOrDefault();
        }
    }
}
