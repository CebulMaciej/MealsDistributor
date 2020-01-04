using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Creators.OrderPropositions.Request.Abstract
{
    public interface IOrderPropositionCreationRequest
    {
        Guid UserId { get; }
        Guid RestaurantId { get; }
        DateTime TimeToOrdering { get; }
    }
}
