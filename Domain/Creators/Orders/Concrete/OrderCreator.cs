using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Creators.Orders.Abstract;
using Domain.Creators.Orders.Request.Abstract;
using Domain.Creators.Orders.Response.Abstract;
using Domain.Creators.Orders.Response.Concrete;
using Domain.Creators.Orders.Response.Const;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Repositories.Abstract;

namespace Domain.Creators.Orders.Concrete
{
    public class OrderCreator : IOrderCreator
    {
        private readonly ILogger _logger;
        private readonly IOrderRepository _orderRepository;

        public OrderCreator(ILogger logger, IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        public async Task<ICreateOrderResponse> CreateOrder(ICreateOrderRequest request)
        {
            try
            {
                Order order = await _orderRepository.CreateOrder(request.OrderPropositionId);
                if (order == null)
                {
                    return new CreateOrderResponse(CreateOrderResult.CreatedNotFound);
                }
                return new CreateOrderResponse(order);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new CreateOrderResponse(CreateOrderResult.Exception);
            }
        }
    }
}
