using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Providers.OrderPropositionPositions.Response.Const
{
    public enum GetOrderPropositionPositionsResult
    {
        Success = 0,
        NotFound = 1,
        Exception = 2,
        Forbidden = 3
    }
}
