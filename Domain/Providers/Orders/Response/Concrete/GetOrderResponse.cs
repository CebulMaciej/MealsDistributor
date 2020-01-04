using Domain.BusinessObject;
using Domain.Providers.Orders.Response.Abstract;
using Domain.Providers.Orders.Response.Const;

namespace Domain.Providers.Orders.Response.Concrete
{
    public class GetOrderResponse : IGetOrderResponse
    {
        public GetOrderResponse(OrderProvideResultEnum result)
        {
            Result = result;
        }

        public GetOrderResponse(Order order)
        {
            Order = order;
            Result = OrderProvideResultEnum.Success;
        }

        public OrderProvideResultEnum Result { get; }
        public Order Order { get; }
    }
}
