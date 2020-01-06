using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Creators.Orders.Abstract;
using Domain.Creators.Orders.Request.Concrete;
using Domain.Creators.Orders.Response.Abstract;
using Domain.Creators.Orders.Response.Const;
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
        private readonly IOrderCreator _orderCreator;

        public OrderPropositionRealizator(IOrderPropositionsProvider orderPropositionsProvider, ILogger logger, IOrderCreator orderCreator)
        {
            _orderPropositionsProvider = orderPropositionsProvider;
            _logger = logger;
            _orderCreator = orderCreator;
        }

        public async Task<IRealizeOrderPropositionResponse> RealizeOrderProposition(IRealizeOrderPropositionRequest request)
        {
            try
            {
                IGetOrderPropositionByIdRequest getOrderPropositionByIdRequest =
                    new GetOrderPropositionByIdRequest(request.OrderPropositionId);
                IGetOrderPropositionResponse getOrderPropositionResponse = await _orderPropositionsProvider.GetOrderPropositionById(getOrderPropositionByIdRequest);

                if (getOrderPropositionResponse.Result == OrderPropositionsProvideResultEnum.Exception ||
                    getOrderPropositionResponse.Result == OrderPropositionsProvideResultEnum.Forbidden)
                {
                    return new RealizeOrderPropositionResponse(RealizeOrderPropositionResult.Exception);
                }

                if (getOrderPropositionResponse.Result == OrderPropositionsProvideResultEnum.NotFound)
                {
                    return new RealizeOrderPropositionResponse(RealizeOrderPropositionResult.NotFound);
                }

                OrderProposition orderProposition = getOrderPropositionResponse.OrderProposition;
                if (request.UserId != orderProposition.CreatorID)
                {
                    return new RealizeOrderPropositionResponse(RealizeOrderPropositionResult.Forbidden);
                }

                ICreateOrderResponse createOrderResponse = await _orderCreator.CreateOrder(new CreateOrderRequest(request.OrderPropositionId));
                return createOrderResponse.Result switch
                {
                    CreateOrderResult.Success => new RealizeOrderPropositionResponse(createOrderResponse.Order),
                    CreateOrderResult.Exception => new RealizeOrderPropositionResponse(RealizeOrderPropositionResult.Exception),
                    CreateOrderResult.CreatedNotFound => new RealizeOrderPropositionResponse(RealizeOrderPropositionResult.Exception),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new RealizeOrderPropositionResponse(RealizeOrderPropositionResult.Exception);
            }
        }
    }
}
