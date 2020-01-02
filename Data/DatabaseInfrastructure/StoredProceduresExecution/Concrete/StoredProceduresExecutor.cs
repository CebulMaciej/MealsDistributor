using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Data.Infrastructure.ProvidingSqlConnection.Abstract;
using Data.Infrastructure.StoredProceduresExecution.Abstract;

namespace Data.Infrastructure.StoredProceduresExecution.Concrete
{
    public class StoredProceduresExecutor : IStoredProceduresExecutor
    {
        private readonly ISqlConnectionProvider _sqlConnectionProvider;

        public StoredProceduresExecutor(ISqlConnectionProvider sqlConnectionProvider)
        {
            _sqlConnectionProvider = sqlConnectionProvider;
        }

        public async Task ExecuteNonQuery(string name, IList<SqlParameter> parameters = null)
        {
            await using SqlConnection connection = _sqlConnectionProvider.GetSqlConnection();
            await using SqlCommand sqlCommand = new SqlCommand(name, connection)
            {
                CommandText = name, CommandType = CommandType.StoredProcedure, Connection = connection
            };
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    sqlCommand.Parameters.Add(parameter);
                }
            }
            await connection.OpenAsync();
            await sqlCommand.ExecuteNonQueryAsync();
        }

        public async Task<DataSet> ExecuteQuery(string name, IList<SqlParameter> parameters = null)
        {
            await using SqlConnection connection = _sqlConnectionProvider.GetSqlConnection();
            await using SqlCommand sqlCommand = new SqlCommand(name, connection)
            {
                CommandType = CommandType.StoredProcedure
            };
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    sqlCommand.Parameters.Add(parameter);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
