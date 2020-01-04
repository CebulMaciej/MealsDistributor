using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.OrderPropositions.Abstract;
using Domain.Providers.OrderPropositions.Request.Abstract;
using Domain.Providers.OrderPropositions.Response.Abstract;
using Domain.Providers.OrderPropositions.Response.Concrete;
using Domain.Providers.OrderPropositions.Response.Const;
using Domain.Repositories.Abstract;

namespace Domain.Providers.OrderPropositions.Concrete
{
    public class OrderPropositionsProvider : IOrderPropositionsProvider
    {
        private readonly ILogger _logger;
        private readonly IOrderPropositionRepository _orderPropositionRepository;

        public OrderPropositionsProvider(ILogger logger, IOrderPropositionRepository orderPropositionRepository)
        {
            _logger = logger;
            _orderPropositionRepository = orderPropositionRepository;
        }

        public async Task<IGetOrderPropositionsResponse> GetOrderPropositionsInWhichUserTakeParts(IGetOrderPropositionsInWhichUserTakePartsRequest request)
        {
            try
            {
                IList<OrderProposition> orderPropositions = await _orderPropositionRepository.GetOrderPropositionsInWhichUserHasActualOffers(request.Id);
                if (orderPropositions == null)
                {
                    return new GetOrderPropositionsResponse(OrderPropositionsProvideResultEnum.NotFound);
                }
                return new GetOrderPropositionsResponse(orderPropositions);
            }
            catch (Exception ex)
            {
              _logger.Log(ex);  
              return new GetOrderPropositionsResponse(OrderPropositionsProvideResultEnum.Exception);
            }
        }

        public async Task<IGetOrderPropositionsResponse> GetActualOrderPropositions()
        {
            try
            {
                IList<OrderProposition> orderPropositions = await _orderPropositionRepository.GetOrderPropositions();
                if (orderPropositions == null)
                {
                    return new GetOrderPropositionsResponse(OrderPropositionsProvideResultEnum.NotFound);
                }
                return new GetOrderPropositionsResponse(orderPropositions);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new GetOrderPropositionsResponse(OrderPropositionsProvideResultEnum.Exception);
            }
        }
    }
}
