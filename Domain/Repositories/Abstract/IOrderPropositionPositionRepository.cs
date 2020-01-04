using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Creators.OrderPropositionsPositions.Response.Concrete;

namespace Domain.Repositories.Abstract
{
    public interface IOrderPropositionPositionRepository
    {
        Task<IList<OrderPropositionPosition>> GetOrderPropositionPositionsByPropositionOrderId(Guid propositionOrderId);

        Task<OrderPropositionPositionWithResultCode> CreateOrderPropositionPosition(Guid userId, Guid mealId,Guid orderPropositionId);
    }
}
