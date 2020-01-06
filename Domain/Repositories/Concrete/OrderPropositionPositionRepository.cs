using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Data.DatabaseInfrastructure;
using Data.Infrastructure.StoredProceduresExecution.Abstract;
using Domain.BusinessObject;
using Domain.Creators.OrderPropositionsPositions.Response.Concrete;
using Domain.Creators.OrderPropositionsPositions.Response.Const;
using Domain.Infrastructure.DataRowToObjectMapping.Abstract;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Repositories.Abstract;

namespace Domain.Repositories.Concrete
{
    public class OrderPropositionPositionRepository : IOrderPropositionPositionRepository
    {
        private readonly IStoredProceduresExecutor _storedProceduresExecutor;
        private readonly IDataRowToObjectMapper _dataRowToObjectMapper;

        public OrderPropositionPositionRepository(IStoredProceduresExecutor storedProceduresExecutor, IDataRowToObjectMapper dataRowToObjectMapper)
        {
            _storedProceduresExecutor = storedProceduresExecutor;
            _dataRowToObjectMapper = dataRowToObjectMapper;
        }


        public async Task<IList<OrderPropositionPosition>> GetOrderPropositionPositionsByPropositionOrderId(Guid propositionOrderId)
        {
            DataSet ds = await _storedProceduresExecutor.ExecuteQuery(
                StoredProceduresNames.GetOrderPropositionPositionsByPropositionOrderId, new List<SqlParameter>(1)
                {
                    new SqlParameter("@orderPropositionId",propositionOrderId)
                });
            IList < OrderPropositionPosition > orderPropositionPositions = new List<OrderPropositionPosition>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                orderPropositionPositions.Add(_dataRowToObjectMapper.ConvertOrderPropositionPosition(row));
            }
            return orderPropositionPositions;
        }

        public async Task<OrderPropositionPositionWithResultCode> CreateOrderPropositionPosition(Guid userId, Guid mealId, Guid orderPropositionId)
        {
            DataSet ds = await _storedProceduresExecutor.ExecuteQuery(
                StoredProceduresNames.CreateOrderPropositionPosition, new List<SqlParameter>(3)
                {
                    new SqlParameter("@userId", userId),
                    new SqlParameter("@mealId", mealId),
                    new SqlParameter("@orderPropositionId", orderPropositionId)
                });
            return new OrderPropositionPositionWithResultCode(OrderPropositionPositionCreateSqlResult.Success,_dataRowToObjectMapper.ConvertOrderPropositionPosition(ds.Tables[0].Rows[0]));
        }
    }
}
