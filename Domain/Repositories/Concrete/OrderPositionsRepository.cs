using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Data.DatabaseInfrastructure;
using Data.Infrastructure.StoredProceduresExecution.Abstract;
using Domain.BusinessObject;
using Domain.Infrastructure.DataRowToObjectMapping.Abstract;
using Domain.Repositories.Abstract;

namespace Domain.Repositories.Concrete
{
    public class OrderPositionsRepository : IOrderPositionsRepository
    {
        private readonly IStoredProceduresExecutor _storedProceduresExecutor;
        private readonly IDataRowToObjectMapper _dataRowToObjectMapper;
        public OrderPositionsRepository(IStoredProceduresExecutor storedProceduresExecutor, IDataRowToObjectMapper dataRowToObjectMapper)
        {
            _storedProceduresExecutor = storedProceduresExecutor;
            _dataRowToObjectMapper = dataRowToObjectMapper;
        }

        public async Task<IList<OrderPosition>> GetOrderPositionsByOrderId(Guid orderId)
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(
                StoredProceduresNames.GetOrderPositionsByOrderId, new List<SqlParameter>(1)
                {
                    new SqlParameter("@orderId", orderId)
                });
            IList<OrderPosition> orderPositions = new List<OrderPosition>();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                orderPositions.Add(_dataRowToObjectMapper.ConvertOrderPosition(row));
            }
            return orderPositions;
        }

        public async Task<IList<OrderPosition>> GetOrderPositionsByUserIdId(Guid userIdId)
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(
                StoredProceduresNames.GetOrderPositionsByUserId, new List<SqlParameter>(1)
                {
                    new SqlParameter("@userId", userIdId)
                });
            IList<OrderPosition> orderPositions = new List<OrderPosition>();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                orderPositions.Add(_dataRowToObjectMapper.ConvertOrderPosition(row));
            }
            return orderPositions;
        }
    }
}
