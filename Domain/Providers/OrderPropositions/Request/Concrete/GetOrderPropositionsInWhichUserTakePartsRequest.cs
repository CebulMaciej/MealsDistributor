using System;
using System.Collections.Generic;
using System.Text;
using Domain.Providers.OrderPropositions.Request.Abstract;

namespace Domain.Providers.OrderPropositions.Request.Concrete
{
    public class GetOrderPropositionsInWhichUserTakePartsRequest : IGetOrderPropositionsInWhichUserTakePartsRequest
    {
        public GetOrderPropositionsInWhichUserTakePartsRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
