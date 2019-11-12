using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Data.Infrastructure.ProvidingSqlConnection.Abstract;
using Microsoft.Extensions.Configuration;

namespace Data.Infrastructure.ProvidingSqlConnection.Concrete
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
