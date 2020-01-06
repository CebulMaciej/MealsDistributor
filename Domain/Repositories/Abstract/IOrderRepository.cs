using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;

namespace Domain.Repositories.Abstract
{
    public interface IOrderRepository
    {
        Task<IList<Order>> GetOrders();
        Task<Order> GetOrderById(Guid orderId);
        Task<Order> CreateOrder(Guid orderPropositionId);
    }
}
