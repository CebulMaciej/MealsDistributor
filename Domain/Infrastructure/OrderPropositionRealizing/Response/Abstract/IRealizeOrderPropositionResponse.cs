using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;

namespace Domain.Infrastructure.OrderPropositionRealizing.Response.Abstract
{
    public interface IRealizeOrderPropositionResponse
    {
        Order Order { get; }
        RealizeOrderPropositionResult Result { get; }
    }
}
