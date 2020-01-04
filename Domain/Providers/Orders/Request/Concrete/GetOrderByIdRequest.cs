using System;
using Domain.Providers.Orders.Request.Abstract;

namespace Domain.Providers.Orders.Request.Concrete
{
    public class GetOrderByIdRequest : IGetOrderByIdRequest
    {
        public GetOrderByIdRequest(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; }
    }
}
