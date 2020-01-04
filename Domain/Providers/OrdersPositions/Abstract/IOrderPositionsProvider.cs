using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Providers.OrdersPositions.Request.Abstract;
using Domain.Providers.OrdersPositions.Response.Abstract;

namespace Domain.Providers.OrdersPositions.Abstract
{
    public interface IOrderPositionsProvider
    {
        Task<IGetOrderPositionsResponse> GetOrderPositionsByUserId(IGetOrderPositionsByUserIdRequest request);
        Task<IGetOrderPositionsResponse> GetOrderPositionsByOrderId(IGetOrderPositionsByOrderIdRequest request);
    }
}
