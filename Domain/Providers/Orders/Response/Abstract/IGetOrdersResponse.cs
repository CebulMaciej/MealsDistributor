using System.Collections.Generic;
using Domain.BusinessObject;
using Domain.Providers.Orders.Response.Const;

namespace Domain.Providers.Orders.Response.Abstract
{
    public interface IGetOrdersResponse
    {
        OrderProvideResultEnum Result { get; }
        IList<Order> Order { get; }
    }
}
