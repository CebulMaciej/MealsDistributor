using System.Collections.Generic;
using Domain.BusinessObject;
using Domain.Providers.Orders.Response.Abstract;
using Domain.Providers.Orders.Response.Const;

namespace Domain.Providers.Orders.Response.Concrete
{
    public class GetOrdersResponse : IGetOrdersResponse
    {
        public GetOrdersResponse(IList<Order> order)
        {
            Order = order;
            Result = OrderProvideResultEnum.Success;
        }

        public GetOrdersResponse(OrderProvideResultEnum result)
        {
            Result = result;
        }

        public OrderProvideResultEnum Result { get; }
        public IList<Order> Order { get; }
    }
}
