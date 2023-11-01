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
    }
}
