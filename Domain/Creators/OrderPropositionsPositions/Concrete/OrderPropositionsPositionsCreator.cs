using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Creators.OrderPropositionsPositions.Abstract;
using Domain.Creators.OrderPropositionsPositions.Request.Abstract;
using Domain.Creators.OrderPropositionsPositions.Response.Abstract;
using Domain.Creators.OrderPropositionsPositions.Response.Concrete;
using Domain.Creators.OrderPropositionsPositions.Response.Const;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Repositories.Abstract;

namespace Domain.Creators.OrderPropositionsPositions.Concrete
{
    public class OrderPropositionsPositionsCreator : IOrderPropositionsPositionsCreator
    {
        private readonly ILogger _logger;
        private readonly IOrderPropositionPositionRepository _orderPropositionPositionRepository;

        public OrderPropositionsPositionsCreator(ILogger logger, IOrderPropositionPositionRepository orderPropositionPositionRepository)
        {
            _logger = logger;
            _orderPropositionPositionRepository = orderPropositionPositionRepository;
        }

        public async Task<IOrderPropositionPositionCreateResponse> CreateOrderPropositionPosition(IOrderPropositionPositionCreateRequest request)
        {
            try
            {
                OrderPropositionPositionWithResultCode orderPropositionPositionWithResultCode = await _orderPropositionPositionRepository.CreateOrderPropositionPosition(request.UserId,
                    request.MealId, request.OrderPropositionId);
                return new OrderPropositionPositionCreateResponse(OrderPropositionPositionCreateResultEnum.Success,orderPropositionPositionWithResultCode.OrderPropositionPosition);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new OrderPropositionPositionCreateResponse(OrderPropositionPositionCreateResultEnum.Exception,null);
            }
        }
    }
}
