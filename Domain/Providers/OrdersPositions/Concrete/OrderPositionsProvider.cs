using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.OrdersPositions.Abstract;
using Domain.Providers.OrdersPositions.Request.Abstract;
using Domain.Providers.OrdersPositions.Request.Concrete;
using Domain.Providers.OrdersPositions.Response.Abstract;
using Domain.Providers.OrdersPositions.Response.Concrete;
using Domain.Providers.OrdersPositions.Response.Const;
using Domain.Repositories.Abstract;

namespace Domain.Providers.OrdersPositions.Concrete
{
    public class OrderPositionsProvider : IOrderPositionsProvider
    {
        private readonly ILogger _logger;
        private readonly IOrderPositionsRepository _orderPositionsRepository;

        public OrderPositionsProvider(ILogger logger, IOrderPositionsRepository orderPositionsRepository)
        {
            _logger = logger;
            _orderPositionsRepository = orderPositionsRepository;
        }

        public async Task<IGetOrderPositionsResponse> GetOrderPositionsByUserId(IGetOrderPositionsByUserIdRequest request)
        {
            try
            {
                IList<OrderPosition> orderPositions = await _orderPositionsRepository.GetOrderPositionsByUserIdId(request.UserId);
                if (orderPositions == null)
                {
                    return new GetOrderPositionsResponse(OrderPositionProvideResult.NotFound);
                }
                return new GetOrderPositionsResponse(orderPositions);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new GetOrderPositionsResponse(OrderPositionProvideResult.Exception);
            }
        }

        public async Task<IGetOrderPositionsResponse> GetOrderPositionsByOrderId(IGetOrderPositionsByOrderIdRequest request)
        {
            try
            {
                IList<OrderPosition> orderPositions = await _orderPositionsRepository.GetOrderPositionsByOrderId(request.OrderId);
                if (orderPositions == null)
                {
                    return new GetOrderPositionsResponse(OrderPositionProvideResult.NotFound);
                }
                return new GetOrderPositionsResponse(orderPositions);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new GetOrderPositionsResponse(OrderPositionProvideResult.Exception);
            }
        }
    }
}
