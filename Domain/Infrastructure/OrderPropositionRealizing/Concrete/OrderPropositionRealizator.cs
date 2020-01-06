using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Infrastructure.OrderPropositionRealizing.Abstract;
using Domain.Infrastructure.OrderPropositionRealizing.Request.Abstract;
using Domain.Infrastructure.OrderPropositionRealizing.Response;
using Domain.Infrastructure.OrderPropositionRealizing.Response.Abstract;
using Domain.Infrastructure.OrderPropositionRealizing.Response.Concrete;
using Domain.Providers.OrderPropositions.Abstract;
using Domain.Providers.OrderPropositions.Request.Abstract;
using Domain.Providers.OrderPropositions.Request.Concrete;
using Domain.Providers.OrderPropositions.Response.Abstract;
using Domain.Providers.OrderPropositions.Response.Const;

namespace Domain.Infrastructure.OrderPropositionRealizing.Concrete
{
    public class OrderPropositionRealizator : IOrderPropositionRealizator
    {
        private readonly IOrderPropositionsProvider _orderPropositionsProvider;
        private readonly ILogger _logger;

        public OrderPropositionRealizator(IOrderPropositionsProvider orderPropositionsProvider, ILogger logger)
        {
            _orderPropositionsProvider = orderPropositionsProvider;
            _logger = logger;
        }

        public async Task<IRealizeOrderPropositionResponse> RealizeOrderProposition(IRealizeOrderPropositionRequest request)
        {
            try
            {
                IGetOrderPropositionByIdRequest getOrderPropositionByIdRequest =
                    new GetOrderPropositionByIdRequest(request.OrderPropositionId);
                IGetOrderPropositionResponse getOrderPropositionResponse = await _orderPropositionsProvider.GetOrderPropositionById(getOrderPropositionByIdRequest);

                switch (getOrderPropositionResponse.Result)
                {
                    case OrderPropositionsProvideResultEnum.Exception:
                    case OrderPropositionsProvideResultEnum.Forbidden:
                        return new RealizeOrderPropositionResponse(RealizeOrderPropositionResult.Exception);
                    case OrderPropositionsProvideResultEnum.NotFound:
                        return new RealizeOrderPropositionResponse(RealizeOrderPropositionResult.NotFound);
                }

                OrderProposition orderProposition = getOrderPropositionResponse.OrderProposition;
                if (request.UserId != orderProposition.CreatorID)
                {
                    return new RealizeOrderPropositionResponse(RealizeOrderPropositionResult.Forbidden);
                }
                throw new NotImplementedException();

            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new RealizeOrderPropositionResponse(RealizeOrderPropositionResult.Exception);
            }
        }
    }
}
