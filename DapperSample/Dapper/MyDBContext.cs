using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace DapperSample.Dapper
{
    public class MyDBContext : DapperDBContext
    {
        public MyDBContext(IOptions<DapperDBContextOptions> optionsAccessor) : base(optionsAccessor)
        {
        }

        protected override IDbConnection CreateConnection(string connectionString)
        {
            var conn = new SqlConnection(connectionString);
            return conn;
        }
    }
}
