using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Creators.Orders.Request.Abstract
{
    public interface ICreateOrderRequest
    {
        Guid OrderPropositionId { get; }
    }
}
