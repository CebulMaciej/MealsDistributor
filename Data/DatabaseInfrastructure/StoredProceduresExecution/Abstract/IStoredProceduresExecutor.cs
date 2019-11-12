using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Data.Infrastructure.StoredProceduresExecution.Abstract
{
    public interface IStoredProceduresExecutor
    {
        void ExecuteNonQuery(string name, IList<SqlParameter> parameters = null);
        Task<DataSet> ExecuteQuery(string name, IList<SqlParameter> parameters = null);
    }
}
