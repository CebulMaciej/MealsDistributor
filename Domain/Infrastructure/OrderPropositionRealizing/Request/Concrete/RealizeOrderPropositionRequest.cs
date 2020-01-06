using System;
using System.Collections.Generic;
using System.Text;
using Domain.Infrastructure.OrderPropositionRealizing.Request.Abstract;

namespace Domain.Infrastructure.OrderPropositionRealizing.Request.Concrete
{
    public class RealizeOrderPropositionRequest : IRealizeOrderPropositionRequest
    {
        public RealizeOrderPropositionRequest(Guid orderPropositionId, Guid userId)
        {
            OrderPropositionId = orderPropositionId;
            UserId = userId;
        }

        public Guid OrderPropositionId { get; }
        public Guid UserId { get; }
    }
}
