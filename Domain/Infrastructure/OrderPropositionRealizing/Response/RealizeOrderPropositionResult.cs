using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Infrastructure.OrderPropositionRealizing.Response
{
    public enum RealizeOrderPropositionResult
    {
        Exception,
        Forbidden,
        NotFound,
        Success
    }
}
