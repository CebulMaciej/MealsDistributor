using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Creators.OrderPropositionsPositions.Response.Const;

namespace Domain.Creators.OrderPropositionsPositions.Response.Concrete
{
    public class OrderPropositionPositionWithResultCode
    {
        public OrderPropositionPositionWithResultCode(OrderPropositionPositionCreateSqlResult result, OrderPropositionPosition orderPropositionPosition)
        {
            Result = result;
            OrderPropositionPosition = orderPropositionPosition;
        }

        public OrderPropositionPositionCreateSqlResult Result { get; }
        public OrderPropositionPosition OrderPropositionPosition { get; }
    }
}
