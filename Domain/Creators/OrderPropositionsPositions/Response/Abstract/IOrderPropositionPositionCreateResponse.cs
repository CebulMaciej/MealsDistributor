using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Creators.OrderPropositionsPositions.Response.Const;

namespace Domain.Creators.OrderPropositionsPositions.Response.Abstract
{
    public interface IOrderPropositionPositionCreateResponse
    {
        OrderPropositionPositionCreateResultEnum Result { get; }
        OrderPropositionPosition OrderPropositionPosition { get; }
    }
}
