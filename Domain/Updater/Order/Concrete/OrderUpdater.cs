using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Orders.Abstract;
using Domain.Providers.Orders.Request.Abstract;
using Domain.Providers.Orders.Request.Concrete;
using Domain.Providers.Orders.Response.Abstract;
using Domain.Providers.Orders.Response.Const;
using Domain.Repositories.Abstract;
using Domain.Updater.Order.Abstract;
using Domain.Updater.Order.Request.Abstract;
using Domain.Updater.Order.Response.Abstract;
using Domain.Updater.Order.Response.Concrete;
using Domain.Updater.Order.Response.Const;

namespace Domain.Updater.Order.Concrete
{
    public class OrderUpdater : IOrderUpdater
    {
        private readonly ILogger _logger;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderProvider _orderProvider;

        public OrderUpdater(IOrderRepository orderRepository, ILogger logger, IOrderProvider orderProvider)
        {
            _orderRepository = orderRepository;
            _logger = logger;
            _orderProvider = orderProvider;
        }

        public async Task<IOrderUpdateResponse> MarkOrderAsOrdered(IOrderUpdateRequest request)
        {
            try
            {
                IGetOrderByIdRequest getOrderByIdRequest = new GetOrderByIdRequest(request.Id);
                IGetOrderResponse getOrderByIdResponse = await _orderProvider.GetOrderById(new GetOrderByIdRequest(request.Id));

                switch (getOrderByIdResponse.Result)
                {
                    case OrderProvideResultEnum.Success:
                        break;
                    case OrderProvideResultEnum.NotFound:
                        return new OrderUpdateResponse(UpdateOrderResultEnum.NotFound);
                    case OrderProvideResultEnum.Exception:
                        return new OrderUpdateResponse(UpdateOrderResultEnum.Exception);
                    case OrderProvideResultEnum.Forbidden:
                        return new OrderUpdateResponse(UpdateOrderResultEnum.Forbidden);
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (getOrderByIdResponse.Order.OrderBoyId != request.CurrentLoggedInUserId)
                {
                    return new OrderUpdateResponse(UpdateOrderResultEnum.Forbidden);
                }

                await _orderRepository.MarkOrderAsOrdered(request.Id);
                return new OrderUpdateResponse(UpdateOrderResultEnum.Success);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new OrderUpdateResponse(UpdateOrderResultEnum.Exception);
            }
        }
    }
}
