using System;

namespace Domain.Infrastructure.OrderPropositionRealizing.Request.Abstract
{
    public interface IRealizeOrderPropositionRequest
    {
        Guid OrderPropositionId { get; }
        Guid UserId { get; }
    }
}
