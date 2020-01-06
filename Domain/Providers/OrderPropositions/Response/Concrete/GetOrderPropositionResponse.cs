using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.OrderPropositions.Response.Abstract;
using Domain.Providers.OrderPropositions.Response.Const;

namespace Domain.Providers.OrderPropositions.Response.Concrete
{
    public class GetOrderPropositionResponse : IGetOrderPropositionResponse
    {
        public GetOrderPropositionResponse(OrderProposition orderProposition)
        {
            OrderProposition = orderProposition;
            Result = OrderPropositionsProvideResultEnum.Success;
        }

        public GetOrderPropositionResponse(OrderPropositionsProvideResultEnum result)
        {
            Result = result;
        }

        public OrderProposition OrderProposition { get; }
        public OrderPropositionsProvideResultEnum Result { get; }
    }
}
