using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Creators.OrderPropositionsPositions.Response.Abstract;
using Domain.Creators.OrderPropositionsPositions.Response.Const;

namespace Domain.Creators.OrderPropositionsPositions.Response.Concrete
{
    public class OrderPropositionPositionCreateResponse : IOrderPropositionPositionCreateResponse
    {
        public OrderPropositionPositionCreateResponse(OrderPropositionPositionCreateResultEnum result, OrderPropositionPosition orderPropositionPosition)
        {
            Result = result;
            OrderPropositionPosition = orderPropositionPosition;
        }

        public OrderPropositionPositionCreateResultEnum Result { get; }
        public OrderPropositionPosition OrderPropositionPosition { get; }
    }
}
