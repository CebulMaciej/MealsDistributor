using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.BusinessObject
{
    public class OrderProposition
    {
        public OrderProposition(Guid id, DateTime creationDate, DateTime timeToOrdering, Guid creatorId, Guid restaurantId, bool orderingStopped)
        {
            Id = id;
            CreationDate = creationDate;
            TimeToOrdering = timeToOrdering;
            CreatorID = creatorId;
            RestaurantId = restaurantId;
            OrderingStopped = orderingStopped;
        }

        public Guid Id { get; }
        public DateTime CreationDate { get; }
        public DateTime TimeToOrdering { get; }
        public Guid CreatorID { get; }
        public Guid RestaurantId { get; }
        public bool OrderingStopped { get; }
    }
}
