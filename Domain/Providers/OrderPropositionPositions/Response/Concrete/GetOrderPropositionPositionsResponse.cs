using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.OrderPropositionPositions.Response.Abstract;
using Domain.Providers.OrderPropositionPositions.Response.Const;

namespace Domain.Providers.OrderPropositionPositions.Response.Concrete
{
    public class GetOrderPropositionPositionsResponse : IGetOrderPropositionPositionsResponse
    {
        public GetOrderPropositionPositionsResponse(IList<OrderPropositionPosition> orderPropositionPositions)
        {
            OrderPropositionPositions = orderPropositionPositions;
            GetOrderPropositionPositionsResult = GetOrderPropositionPositionsResult.Success;
        }

        public GetOrderPropositionPositionsResponse(GetOrderPropositionPositionsResult orderPropositionPositionsResult)
        {
            GetOrderPropositionPositionsResult = orderPropositionPositionsResult;
        }

        public IList<OrderPropositionPosition> OrderPropositionPositions { get; }
        public GetOrderPropositionPositionsResult GetOrderPropositionPositionsResult { get; }
    }
}
