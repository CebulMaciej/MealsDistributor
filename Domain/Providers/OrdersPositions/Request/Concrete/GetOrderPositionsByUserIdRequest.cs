using System;
using System.Collections.Generic;
using System.Text;
using Domain.Providers.OrdersPositions.Request.Abstract;

namespace Domain.Providers.OrdersPositions.Request.Concrete
{
    public class GetOrderPositionsByUserIdRequest : IGetOrderPositionsByUserIdRequest
    {
        public GetOrderPositionsByUserIdRequest(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; }
    }
}
