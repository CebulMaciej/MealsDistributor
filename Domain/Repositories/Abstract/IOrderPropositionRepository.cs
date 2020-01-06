using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Creators.OrderPropositions.Response.Concrete;

namespace Domain.Repositories.Abstract
{
    public interface IOrderPropositionRepository
    {
        Task<IList<OrderProposition>> GetOrderPropositionsInWhichUserHasActualOffers(Guid userId);
        Task<IList<OrderProposition>> GetOrderPropositions();
        Task<OrderProposition> GetOrderPropositionById(Guid id);
        Task<OrderPropositionWithResultCode> CreateOrderProposition(DateTime timeToOrdering, Guid userId, Guid restaurantId);
    }
}
