using System;
using System.Collections.Generic;
using System.Text;
using Domain.Providers.OrderPropositionPositions.Request.Abstract;

namespace Domain.Providers.OrderPropositionPositions.Request.Concrete
{
    public class GetOrderPropositionPositionByOrderPropositionIdRequest : IGetOrderPropositionPositionByOrderPropositionIdRequest
    {
        public GetOrderPropositionPositionByOrderPropositionIdRequest(Guid orderPropositionId)
        {
            OrderPropositionId = orderPropositionId;
        }

        public Guid OrderPropositionId { get; }
    }
}
