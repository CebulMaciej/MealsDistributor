using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Creators.OrderPropositions.Abstract;
using Domain.Creators.OrderPropositions.Request.Abstract;
using Domain.Creators.OrderPropositions.Response.Abstract;
using Domain.Creators.OrderPropositions.Response.Concrete;
using Domain.Creators.OrderPropositions.Response.Const;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Repositories.Abstract;

namespace Domain.Creators.OrderPropositions.Concrete
{
    public class OrderPropositionsCreator : IOrderPropositionsCreator
    {
        private readonly ILogger _logger;
        private readonly IOrderPropositionRepository _orderPropositionRepository;
        public OrderPropositionsCreator(ILogger logger, IOrderPropositionRepository orderPropositionRepository)
        {
            _logger = logger;
            _orderPropositionRepository = orderPropositionRepository;
        }

        public async Task<IOrderPropositionCreationResponse> CreateOrderProposition(IOrderPropositionCreationRequest request)
        {
            try
            {
                OrderPropositionWithResultCode orderPropositionWithResultCode = await _orderPropositionRepository.CreateOrderProposition(
                    request.TimeToOrdering, 
                    request.UserId,
                    request.RestaurantId);
                if (orderPropositionWithResultCode.ResultCode == OrderPropositionCreateSqlResult.AlreadyExists)
                {
                    return new OrderPropositionCreationResponse(OrderPropositionCreationResultEnum.AlreadyExists);
                }
                return new OrderPropositionCreationResponse(orderPropositionWithResultCode.OrderProposition);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new OrderPropositionCreationResponse(OrderPropositionCreationResultEnum.Exception);
            }
        }
    }
}
