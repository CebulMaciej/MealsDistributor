using System.Threading.Tasks;
using Domain.Providers.OrderPropositionPositions.Request.Abstract;
using Domain.Providers.OrderPropositionPositions.Response.Abstract;

namespace Domain.Providers.OrderPropositionPositions.Abstract
{
    public interface IOrderPropositionsPositionsProvider
    {
        Task<IGetOrderPropositionPositionsResponse> GetOrderPropositionPositionsByOrderPropositionId(
            IGetOrderPropositionPositionByOrderPropositionIdRequest
                getOrderPropositionPositionByOrderPropositionIdRequest);
    }
}
