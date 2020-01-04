using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.OrderPropositions.Response.Abstract;
using Domain.Providers.OrderPropositions.Response.Const;

namespace Domain.Providers.OrderPropositions.Response.Concrete
{
    public class GetOrderPropositionsResponse : IGetOrderPropositionsResponse
    {
        public GetOrderPropositionsResponse(IList<OrderProposition> orderPropositions)
        {
            OrderPropositions = orderPropositions;
            Result = OrderPropositionsProvideResultEnum.Success;
        }

        public GetOrderPropositionsResponse(OrderPropositionsProvideResultEnum result)
        {
            Result = result;
        }

        public IList<OrderProposition> OrderPropositions { get; }
        public OrderPropositionsProvideResultEnum Result { get; }
    }
}
