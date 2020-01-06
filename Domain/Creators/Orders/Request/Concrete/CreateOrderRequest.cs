using System;
using System.Collections.Generic;
using System.Text;
using Domain.Creators.Orders.Request.Abstract;

namespace Domain.Creators.Orders.Request.Concrete
{
    public class CreateOrderRequest : ICreateOrderRequest
    {
        public CreateOrderRequest(Guid orderPropositionId)
        {
            OrderPropositionId = orderPropositionId;
        }

        public Guid OrderPropositionId { get; }
    }
}
