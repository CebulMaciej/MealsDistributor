using System;
using System.Collections.Generic;
using System.Text;
using Domain.Creators.OrderPropositions.Request.Abstract;

namespace Domain.Creators.OrderPropositions.Request.Concrete
{
    public class OrderPropositionCreationRequest : IOrderPropositionCreationRequest
    {
        public OrderPropositionCreationRequest(Guid userId, Guid restaurantId, DateTime timeToOrdering)
        {
            UserId = userId;
            RestaurantId = restaurantId;
            TimeToOrdering = timeToOrdering;
        }

        public Guid UserId { get; }
        public Guid RestaurantId { get; }
        public DateTime TimeToOrdering { get; }
    }
}
