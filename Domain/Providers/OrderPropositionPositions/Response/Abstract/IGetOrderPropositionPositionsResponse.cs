using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.OrderPropositionPositions.Response.Const;

namespace Domain.Providers.OrderPropositionPositions.Response.Abstract
{
    public interface IGetOrderPropositionPositionsResponse
    {
        IList<OrderPropositionPosition> OrderPropositionPositions { get; }
        GetOrderPropositionPositionsResult GetOrderPropositionPositionsResult { get; }
    }
}
