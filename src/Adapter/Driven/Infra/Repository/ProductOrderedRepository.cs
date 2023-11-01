using Domain.Repositories;
using Infra.Context;
using Microsoft.Extensions.Logging;

namespace Infra.Repository
{
    internal class ProductOrderedRepository : IProductOrderedRepository
    {
        private readonly ILogger<ProductOrderedRepository> logger;
        private readonly IUnitOfWork unitOfWork;
        private DbSession _session;

        public ProductOrderedRepository(ILogger<ProductOrderedRepository> logger, IUnitOfWork unitOfWork, DbSession session)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            _session = session;
        }
    }
}
