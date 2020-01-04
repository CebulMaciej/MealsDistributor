using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.BusinessObject
{
    public class OrderPosition
    {
        public OrderPosition(Guid id, DateTime creationDate, Guid userId, Guid mealId, Guid orderId)
        {
            Id = id;
            CreationDate = creationDate;
            UserId = userId;
            MealId = mealId;
            OrderId = orderId;
        }

        public Guid Id { get; }
        public DateTime CreationDate { get; }
        public Guid UserId { get; }
        public Guid MealId { get; }
        public Guid OrderId { get; }
    }
}
