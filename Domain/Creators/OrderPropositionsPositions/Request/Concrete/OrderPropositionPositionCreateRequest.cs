using System;
using System.Collections.Generic;
using System.Text;
using Domain.Creators.OrderPropositionsPositions.Request.Abstract;

namespace Domain.Creators.OrderPropositionsPositions.Request.Concrete
{
    public class OrderPropositionPositionCreateRequest : IOrderPropositionPositionCreateRequest
    {
        public OrderPropositionPositionCreateRequest(Guid userId, Guid mealId, Guid orderPropositionId)
        {
            UserId = userId;
            MealId = mealId;
            OrderPropositionId = orderPropositionId;
        }

        public Guid UserId { get; }
        public Guid MealId { get; }
        public Guid OrderPropositionId { get; }
    }
}
