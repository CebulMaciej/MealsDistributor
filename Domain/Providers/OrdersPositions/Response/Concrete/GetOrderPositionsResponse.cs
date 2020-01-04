using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.OrdersPositions.Response.Abstract;
using Domain.Providers.OrdersPositions.Response.Const;

namespace Domain.Providers.OrdersPositions.Response.Concrete
{
    public class GetOrderPositionsResponse : IGetOrderPositionsResponse
    {
        public GetOrderPositionsResponse(IList<OrderPosition> orderPositions)
        {
            OrderPositions = orderPositions;
            OrderPositionProvideResult = OrderPositionProvideResult.Success;
        }

        public GetOrderPositionsResponse(OrderPositionProvideResult orderPositionProvideResult)
        {
            OrderPositionProvideResult = orderPositionProvideResult;
        }

        public IList<OrderPosition> OrderPositions { get; }
        public OrderPositionProvideResult OrderPositionProvideResult { get; }
    }
}
