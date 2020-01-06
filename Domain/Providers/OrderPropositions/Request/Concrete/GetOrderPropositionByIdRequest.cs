using System;
using System.Collections.Generic;
using System.Text;
using Domain.Providers.OrderPropositions.Request.Abstract;

namespace Domain.Providers.OrderPropositions.Request.Concrete
{
    public class GetOrderPropositionByIdRequest : IGetOrderPropositionByIdRequest
    {
        public GetOrderPropositionByIdRequest(Guid orderPropositionId)
        {
            OrderPropositionId = orderPropositionId;
        }

        public Guid OrderPropositionId { get; }
    }
}
