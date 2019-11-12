using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.BusinessObject
{
    public class Order
    {
        public Order(Guid id, DateTime creationDate, Guid orderBoyId, bool isOrdered)
        {
            Id = id;
            CreationDate = creationDate;
            OrderBoyId = orderBoyId;
            IsOrdered = isOrdered;
        }

        public Guid Id { get; }
        public DateTime CreationDate { get; }
        public Guid OrderBoyId { get; }
        public bool IsOrdered { get; }
    }
}
