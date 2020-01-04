using System;
using System.Collections.Generic;
using System.Text;
using Domain.Providers.OrdersPositions.Request.Abstract;

namespace Domain.Providers.OrdersPositions.Request.Concrete
{
    public class GetOrderPositionsByOrderIdRequest : IGetOrderPositionsByOrderIdRequest
    {
        public GetOrderPositionsByOrderIdRequest(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; }
    }
}
