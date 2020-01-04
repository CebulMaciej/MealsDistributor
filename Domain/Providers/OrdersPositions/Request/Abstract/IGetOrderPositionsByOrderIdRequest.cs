using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Providers.OrdersPositions.Request.Abstract
{
    public interface IGetOrderPositionsByOrderIdRequest
    {
        Guid OrderId { get; }
    }
}
