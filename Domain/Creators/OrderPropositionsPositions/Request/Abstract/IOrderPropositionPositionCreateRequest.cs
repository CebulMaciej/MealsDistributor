using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Creators.OrderPropositionsPositions.Request.Abstract
{
    public interface IOrderPropositionPositionCreateRequest
    {
        Guid UserId { get; }
        Guid MealId { get; }
        Guid OrderPropositionId { get; }
    }
}
