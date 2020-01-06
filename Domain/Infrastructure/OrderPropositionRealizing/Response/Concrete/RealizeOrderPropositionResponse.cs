using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Infrastructure.OrderPropositionRealizing.Response.Abstract;

namespace Domain.Infrastructure.OrderPropositionRealizing.Response.Concrete
{
    public class RealizeOrderPropositionResponse : IRealizeOrderPropositionResponse
    {
        public RealizeOrderPropositionResponse(Order order)
        {
            Order = order;
            Result = RealizeOrderPropositionResult.Success;
        }

        public RealizeOrderPropositionResponse(RealizeOrderPropositionResult result)
        {
            Result = result;
        }

        public Order Order { get; }
        public RealizeOrderPropositionResult Result { get; }
    }
}
