using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Providers.OrderPropositions.Request.Abstract
{
    public interface IGetOrderPropositionsInWhichUserTakePartsRequest
    {
        Guid Id { get; }
    }
}
