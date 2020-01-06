using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Providers.OrderPropositionPositions.Request.Abstract
{
    public interface IGetOrderPropositionPositionByOrderPropositionIdRequest
    {
        Guid OrderPropositionId { get; }
    }
}
