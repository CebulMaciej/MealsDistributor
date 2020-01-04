using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.BusinessObject
{
    public class Order
    {
        public Order(Guid id, DateTime creationDate, Guid orderBoyId, bool isOrdered, Guid restaurantId)
        {
            Id = id;
            CreationDate = creationDate;
            OrderBoyId = orderBoyId;
            IsOrdered = isOrdered;
            RestaurantId = restaurantId;
        }

        public Guid Id { get; }
        public DateTime CreationDate { get; }
        public Guid OrderBoyId { get; }
        public Guid RestaurantId { get; }
        public bool IsOrdered { get; }
    }
}
