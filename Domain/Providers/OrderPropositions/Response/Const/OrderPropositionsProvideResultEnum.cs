using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Providers.OrderPropositions.Response.Const
{
    public enum OrderPropositionsProvideResultEnum
    {
        Success = 0,
        NotFound = 1,
        Exception = 2,
        Forbidden = 3
    }
}
