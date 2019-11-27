using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Data.DatabaseInfrastructure;
using Data.Infrastructure.StoredProceduresExecution.Abstract;
using Domain.Infrastructure.Config.Objects;
using Domain.Infrastructure.DataRowToObjectMapping.Abstract;
using Domain.Repositories.Abstract;

namespace Domain.Repositories.Concrete
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly IStoredProceduresExecutor _storedProceduresExecutor;
        private readonly IDataRowToObjectMapper _dataRowToObjectMapper;

        public ConfigurationRepository(IStoredProceduresExecutor storedProceduresExecutor, IDataRowToObjectMapper dataRowToObjectMapper)
        {
            _storedProceduresExecutor = storedProceduresExecutor;
            _dataRowToObjectMapper = dataRowToObjectMapper;
        }

        public async Task<ConfigurationObject> GetConfigurationObject(string key)
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.GetConfiguration, new List<SqlParameter> { new SqlParameter("@key", key) });
            return ReadConfigurationObjectFromDataRow(dataSet);
        }

        public async Task<ConfigurationObject> UpdateConfigurationObject(string key, string value)
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.UpdateConfigurationAndThenGet,
                new List<SqlParameter> { new SqlParameter("@key", key), new SqlParameter("@value", value) });
            return ReadConfigurationObjectFromDataRow(dataSet);
        }

        private ConfigurationObject ReadConfigurationObjectFromDataRow(DataSet dataSet)
        {
            DataRow dataRow = dataSet.Tables[0].Rows.Count == 0 ? null : dataSet.Tables[0].Rows[0];

            return _dataRowToObjectMapper.ConvertConfigurationObject(dataRow);
        }
    }
}
