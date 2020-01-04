using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DatabaseInfrastructure;
using Data.Infrastructure.StoredProceduresExecution.Abstract;
using Domain.BusinessObject;
using Domain.Creators.OrderPropositions.Response.Concrete;
using Domain.Creators.OrderPropositions.Response.Const;
using Domain.Infrastructure.DataRowToObjectMapping.Abstract;
using Domain.Repositories.Abstract;

namespace Domain.Repositories.Concrete
{
    public class OrderPropositionRepository : IOrderPropositionRepository
    {
        private readonly IStoredProceduresExecutor _storedProceduresExecutor;

        public OrderPropositionRepository(IStoredProceduresExecutor storedProceduresExecutor, IDataRowToObjectMapper dataRowToObjectMapper)
        {
            _storedProceduresExecutor = storedProceduresExecutor;
            _dataRowToObjectMapper = dataRowToObjectMapper;
        }

        private readonly IDataRowToObjectMapper _dataRowToObjectMapper;
        public async Task<IList<OrderProposition>> GetOrderPropositionsInWhichUserHasActualOffers(Guid userId)
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.GetOrderPropositionsInWhichUserHasAvailableOffer, new List<SqlParameter>(1)
                {
                    new SqlParameter("@userId",userId)
                });
            return (from DataRow row in dataSet.Tables[0].Rows select _dataRowToObjectMapper.ConvertOrderProposition(row)).ToList();
        }

        public async Task<IList<OrderProposition>> GetOrderPropositions()
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.GetOrderPropositions, new List<SqlParameter>());
            return (from DataRow row in dataSet.Tables[0].Rows select _dataRowToObjectMapper.ConvertOrderProposition(row)).ToList();
        }

        public async Task<OrderPropositionWithResultCode> CreateOrderProposition(DateTime timeToOrdering, Guid userId, Guid restaurantId)
        {
            DataSet dataSet = await _storedProceduresExecutor.ExecuteQuery(StoredProceduresNames.CreateOrderProposition,
                new List<SqlParameter>(3)
                {
                    new SqlParameter("@userId",userId),
                    new SqlParameter("@timeToOrdering",timeToOrdering),
                    new SqlParameter("@restaurantId",restaurantId)
                });
            int resultCode = (int)dataSet.Tables[0].Rows[0][0];
            OrderPropositionCreateSqlResult result = (OrderPropositionCreateSqlResult) resultCode;

            OrderProposition orderProposition = null;

            if (result == OrderPropositionCreateSqlResult.Success)
            {
                orderProposition = _dataRowToObjectMapper.ConvertOrderProposition(dataSet.Tables[1].Rows[0]);
            }
            return new OrderPropositionWithResultCode(orderProposition,result);

        }
    }
}
