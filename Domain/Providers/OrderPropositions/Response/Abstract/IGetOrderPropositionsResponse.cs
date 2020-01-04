using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.OrderPropositions.Response.Const;

namespace Domain.Providers.OrderPropositions.Response.Abstract
{
    public interface IGetOrderPropositionsResponse
    {
        IList<OrderProposition> OrderPropositions { get; }
        OrderPropositionsProvideResultEnum Result { get; }
    }
}
