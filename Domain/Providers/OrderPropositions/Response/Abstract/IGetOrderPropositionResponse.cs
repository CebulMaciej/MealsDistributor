using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.OrderPropositions.Response.Const;

namespace Domain.Providers.OrderPropositions.Response.Abstract
{
    public interface IGetOrderPropositionResponse
    {
        OrderProposition OrderProposition { get; }
        OrderPropositionsProvideResultEnum Result { get; }
    }
}
