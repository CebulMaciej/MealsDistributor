using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Creators.OrderPropositions.Response.Const;

namespace Domain.Creators.OrderPropositions.Response.Abstract
{
    public interface IOrderPropositionCreationResponse
    {
        OrderPropositionCreationResultEnum Result { get; }
        OrderProposition OrderProposition { get; }
    }
}
