using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Orders.Abstract;
using Domain.Providers.Orders.Request.Abstract;
using Domain.Providers.Orders.Response.Abstract;
using Domain.Providers.Orders.Response.Concrete;
using Domain.Providers.Orders.Response.Const;
using Domain.Repositories.Abstract;

namespace Domain.Providers.Orders.Concrete
{
    public class OrderProvider : IOrderProvider
    {
        private readonly ILogger _logger;
        private readonly IOrderRepository _orderRepository;

        public OrderProvider(ILogger logger, IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        public async Task<IGetOrderResponse> GetOrderById(IGetOrderByIdRequest request)
        {
            try
            {
                Order order = await _orderRepository.GetOrderById(request.OrderId);
                if (order == null)
                {
                    return new GetOrderResponse(OrderProvideResultEnum.NotFound);
                }
                return new GetOrderResponse(order);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new GetOrderResponse(OrderProvideResultEnum.Exception);
            }
        }

        public async Task<IGetOrdersResponse> GetOrders()
        {
            try
            {
                IList<Order> orders = await _orderRepository.GetOrders();
                if (orders == null)
                {
                    return new GetOrdersResponse(OrderProvideResultEnum.NotFound);
                }
                return new GetOrdersResponse(orders);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new GetOrdersResponse(OrderProvideResultEnum.Exception);
            }
        }
    }
}
