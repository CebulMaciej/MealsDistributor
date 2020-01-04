using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.BusinessObject
{
    public class OrderPropositionPosition
    {
        public OrderPropositionPosition(Guid id, DateTime creationDate, Guid userId, Guid mealId, Guid orderPropositionId)
        {
            Id = id;
            CreationDate = creationDate;
            UserId = userId;
            MealId = mealId;
            OrderPropositionId = orderPropositionId;
        }

        public Guid Id { get; }
        public DateTime CreationDate { get; }
        public Guid UserId { get; }
        public Guid MealId { get; }
        public Guid OrderPropositionId { get; }
    }
}
