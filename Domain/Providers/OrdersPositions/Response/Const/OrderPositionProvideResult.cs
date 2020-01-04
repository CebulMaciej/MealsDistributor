using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Providers.OrdersPositions.Response.Const
{
    public enum OrderPositionProvideResult
    {
        Success = 0,
        NotFound = 1,
        Exception = 2,
        Forbidden = 3

    }
}
