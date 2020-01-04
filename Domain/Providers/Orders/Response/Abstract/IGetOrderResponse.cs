using Domain.BusinessObject;
using Domain.Providers.Orders.Response.Const;

namespace Domain.Providers.Orders.Response.Abstract
{
    public interface IGetOrderResponse
    {
        OrderProvideResultEnum Result { get; }
        Order Order { get; }
    }
}
