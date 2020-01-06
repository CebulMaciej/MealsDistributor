using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.OrderPropositionPositions.Abstract;
using Domain.Providers.OrderPropositionPositions.Request.Abstract;
using Domain.Providers.OrderPropositionPositions.Response.Abstract;
using Domain.Providers.OrderPropositionPositions.Response.Concrete;
using Domain.Providers.OrderPropositionPositions.Response.Const;
using Domain.Repositories.Abstract;

namespace Domain.Providers.OrderPropositionPositions.Concrete
{
    public class OrderPropositionsPositionsProvider : IOrderPropositionsPositionsProvider
    {
        private readonly ILogger _logger;
        private readonly IOrderPropositionPositionRepository _orderPropositionPositionRepository;

        public OrderPropositionsPositionsProvider(ILogger logger, IOrderPropositionPositionRepository orderPropositionPositionRepository)
        {
            _logger = logger;
            _orderPropositionPositionRepository = orderPropositionPositionRepository;
        }

        public async Task<IGetOrderPropositionPositionsResponse> GetOrderPropositionPositionsByOrderPropositionId(
            IGetOrderPropositionPositionByOrderPropositionIdRequest getOrderPropositionPositionByOrderPropositionIdRequest)
        {
            try
            {
                IList<OrderPropositionPosition>orderPropositionPositions = await _orderPropositionPositionRepository.GetOrderPropositionPositionsByPropositionOrderId(getOrderPropositionPositionByOrderPropositionIdRequest.OrderPropositionId);
                if (orderPropositionPositions == null)
                {
                    return new GetOrderPropositionPositionsResponse(GetOrderPropositionPositionsResult.NotFound);
                }
                return new GetOrderPropositionPositionsResponse(orderPropositionPositions);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new GetOrderPropositionPositionsResponse(GetOrderPropositionPositionsResult.Exception);
            }

        }
    }
}
