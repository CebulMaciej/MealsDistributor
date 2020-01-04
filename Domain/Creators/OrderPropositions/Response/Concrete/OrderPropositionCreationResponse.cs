using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Creators.OrderPropositions.Response.Abstract;
using Domain.Creators.OrderPropositions.Response.Const;

namespace Domain.Creators.OrderPropositions.Response.Concrete
{
    public class OrderPropositionCreationResponse : IOrderPropositionCreationResponse
    {
        public OrderPropositionCreationResponse(OrderProposition orderProposition)
        {
            OrderProposition = orderProposition;
            Result = OrderPropositionCreationResultEnum.Success;
        }

        public OrderPropositionCreationResponse(OrderPropositionCreationResultEnum result)
        {
            Result = result;
        }

        public OrderPropositionCreationResultEnum Result { get; }
        public OrderProposition OrderProposition { get; }
    }
}
