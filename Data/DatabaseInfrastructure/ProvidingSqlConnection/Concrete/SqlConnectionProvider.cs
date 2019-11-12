using System.Data.SqlClient;
using Data.Infrastructure.ProvidingSqlConnection.Abstract;
using Microsoft.Extensions.Configuration;

namespace Data.DatabaseInfrastructure.ProvidingSqlConnection.Concrete
{
    public class SqlConnectionProvider : ISqlConnectionProvider
    {
        private readonly IConfiguration _configuration;

        public SqlConnectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection GetSqlConnection()
        {
            string connectionString=_configuration.GetSection("Database").GetSection("ConnectionString").Value;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }
    }
}
