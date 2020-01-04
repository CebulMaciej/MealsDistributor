using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.OrdersPositions.Response.Const;

namespace Domain.Providers.OrdersPositions.Response.Abstract
{
    public interface IGetOrderPositionsResponse
    {
        IList<OrderPosition> OrderPositions { get; }
        OrderPositionProvideResult OrderPositionProvideResult { get; }
    }
}
