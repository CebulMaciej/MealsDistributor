using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure.StoredProceduresExecution.Abstract;
using Domain.BusinessObject;
using Domain.Creators.OrderPropositionsPositions.Response.Concrete;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Repositories.Abstract;

namespace Domain.Repositories.Concrete
{
    public class OrderPropositionPositionRepository : IOrderPropositionPositionRepository
    {
        private readonly ILogger _logger;
        private readonly IStoredProceduresExecutor _storedProceduresExecutor;

        public OrderPropositionPositionRepository(ILogger logger, IStoredProceduresExecutor storedProceduresExecutor)
        {
            _logger = logger;
            _storedProceduresExecutor = storedProceduresExecutor;
        }


        public async Task<IList<OrderPropositionPosition>> GetOrderPropositionPositionsByPropositionOrderId(Guid propositionOrderId)
        {
            DataSet ds = await 
        }

        public async Task<OrderPropositionPositionWithResultCode> CreateOrderPropositionPosition(Guid userId, Guid mealId, Guid orderPropositionId)
        {
            throw new NotImplementedException();
        }
    }
}
