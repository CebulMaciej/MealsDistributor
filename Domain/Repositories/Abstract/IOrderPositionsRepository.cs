using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;

namespace Domain.Repositories.Abstract
{
    public interface IOrderPositionsRepository
    {
        Task<IList<OrderPosition>> GetOrderPositionsByOrderId(Guid orderId);
        Task<IList<OrderPosition>> GetOrderPositionsByUserIdId(Guid userIdId);
    }
}
