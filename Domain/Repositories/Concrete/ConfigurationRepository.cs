using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Data.DatabaseInfrastructure;
using Data.Infrastructure.StoredProceduresExecution.Abstract;
using Domain.Infrastructure.Config.Objects;
using Domain.Repositories.Abstract;

namespace Domain.Repositories.Concrete
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly IStoredProceduresExecutor _storedProceduresExecutor;

        public ConfigurationRepository(IStoredProceduresExecutor storedProceduresExecutor)
        {
            _storedProceduresExecutor = storedProceduresExecutor;
        }

        public async Task<ConfigurationObject> GetConfigurationObject(string key)
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.GetConfiguration,new List<SqlParameter> { new SqlParameter("@key",key)});
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            DataRow dataRow = dataSet.Tables[0].Rows[0];
            return ReadConfigurationObjectFromDataRow(dataRow); 
        }

        public async Task<ConfigurationObject> UpdateConfigurationObject(string key, string value)
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.UpdateConfigurationAndThenGet,
                new List<SqlParameter> {new SqlParameter("@key", key), new SqlParameter("@value", value)});
            if (dataSet.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            DataRow dataRow = dataSet.Tables[0].Rows[0];
            return ReadConfigurationObjectFromDataRow(dataRow);
        }

        private static ConfigurationObject ReadConfigurationObjectFromDataRow(DataRow dataRow)
        {
            return new ConfigurationObject(dataRow["CON_Key"].ToString(), dataRow["CON_Value"].ToString());
        }
    }
}
