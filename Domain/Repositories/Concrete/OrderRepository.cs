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
    public class OrderRepository : IOrderRepository
    {
        private readonly IStoredProceduresExecutor _storedProceduresExecutor;
        private readonly IDataRowToObjectMapper _dataRowToObjectMapper;
        public OrderRepository(IStoredProceduresExecutor storedProceduresExecutor, IDataRowToObjectMapper dataRowToObjectMapper)
        {
            _storedProceduresExecutor = storedProceduresExecutor;
            _dataRowToObjectMapper = dataRowToObjectMapper;
        }

        public async Task<IList<Order>> GetOrders()
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.GetOrders, new List<SqlParameter>());
            IList<Order> orders = new List<Order>(dataSet.Tables[0].Rows.Count);
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                orders.Add(_dataRowToObjectMapper.ConvertOrder(row));
            }
            return orders;
        }

        public async Task<Order> GetOrderById(Guid orderId)
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.GetOrderById,
                new List<SqlParameter>(1)
                {
                    new SqlParameter("@orderId",orderId)
                });
            DataTable table = dataSet.Tables[0];
            if (table.Rows.Count == 0)
            {
                return null;
            }
            return _dataRowToObjectMapper.ConvertOrder(table.Rows[0]);
        }
    }
}
