using Dapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Infra.Context;
using Microsoft.Extensions.Logging;

namespace Infra.Repository
{
    internal class ProductRepository : IproductRepository
    {
        private readonly ILogger<ProductRepository> logger;
        private readonly IUnitOfWork unitOfWork;
        private DbSession _session;

        public ProductRepository(ILogger<ProductRepository> logger, IUnitOfWork unitOfWork, DbSession session)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            _session = session;
        }

        public long CreateProduct(Product product)
        {
            var parameter = new
            {
                product.Name,
                product.Description,
                product.Price,
                product.Category
            };

            const string query = @"INSERT INTO Product (Name, Description, Price, Category, IsActive)
                                        VALUES (@Name, @Description, @Price, @Category, 1);
                                    SELECT LAST_INSERT_ID();";

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

        public IList<Product?> GetProductByCategory(ProductCategory ProductCategoty)
        {
            var parameter = new { Category = (int)ProductCategoty };

            const string query = $"SELECT * FROM Product WHERE Category = @Category AND IsActive = 1";

            return _session.Connection.Query<Product>(query, parameter, _session.Transaction).ToList();
        }

        public void DeleteProduct(long productId)
        {
            var parameter = new
            {
                productId       
            };

            const string query = $"UPDATE Product SET IsActive = 0 WHERE ProductId = @productId";

            _session.Connection.Execute(query, parameter, _session.Transaction);

        }

        public void UpdateProduct(long productId, Product product)
        {
            var parameter = new
            {
                productId,
                product.Name,
                product.Description,
                product.Category,
                product.Price,
            };

            const string query = $"UPDATE Product SET Name = @Name, Description = @Description, Category = @Category, Price = @Price WHERE ProductId = @productId";

            _session.Connection.Execute(query, parameter, _session.Transaction);
        }

        public IList<Product> GetProductsById(IList<long> ids)
        {
            var parameter = new { ProductIds = ids.ToArray() };

            const string query = $"SELECT * FROM Product WHERE ProductId IN @ProductIds AND IsActive = 1";

            return _session.Connection.Query<Product>(query, parameter, _session.Transaction).ToList();
        }
    }
}
