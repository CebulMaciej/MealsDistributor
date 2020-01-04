using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Creators.OrderPropositions.Response.Const;

namespace Domain.Creators.OrderPropositions.Response.Concrete
{
    public class OrderPropositionWithResultCode
    {
        public OrderPropositionWithResultCode(OrderProposition orderProposition, OrderPropositionCreateSqlResult resultCode)
        {
            OrderProposition = orderProposition;
            ResultCode = resultCode;
        }

        public OrderProposition OrderProposition { get; }
        public OrderPropositionCreateSqlResult ResultCode { get; }
    }
}
