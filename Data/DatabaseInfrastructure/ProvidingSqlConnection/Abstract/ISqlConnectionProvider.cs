using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data.Infrastructure.ProvidingSqlConnection.Abstract
{
    public interface ISqlConnectionProvider
    {
        SqlConnection GetSqlConnection();
    }
}
