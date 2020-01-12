using System;
using System.Collections.Generic;
using System.Text;
using Domain.Updater.Order.Request.Abstract;

namespace Domain.Updater.Order.Request.Concrete
{
    public class OrderUpdateRequest : IOrderUpdateRequest
    {
        public OrderUpdateRequest(Guid id, Guid currentLoggedInUserId)
        {
            Id = id;
            CurrentLoggedInUserId = currentLoggedInUserId;
        }

        public Guid Id { get; }
        public Guid CurrentLoggedInUserId { get; }
    }
}
