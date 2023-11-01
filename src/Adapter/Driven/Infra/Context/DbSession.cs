using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace Infra.Context
{
    public sealed class DbSession : IDisposable
    {
        private Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession(IConfiguration config)
        {
            _id = Guid.NewGuid();
            Connection = new SqlConnection(config.GetConnectionString("techChallengeDb"));
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
