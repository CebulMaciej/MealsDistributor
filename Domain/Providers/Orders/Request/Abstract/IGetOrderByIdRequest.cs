using System;

namespace Domain.Providers.Orders.Request.Abstract
{
    public interface IGetOrderByIdRequest
    {
        Guid OrderId { get; }
    }
}
