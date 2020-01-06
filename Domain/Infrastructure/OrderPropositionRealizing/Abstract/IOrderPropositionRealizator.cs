using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure.OrderPropositionRealizing.Request.Abstract;
using Domain.Infrastructure.OrderPropositionRealizing.Response.Abstract;

namespace Domain.Infrastructure.OrderPropositionRealizing.Abstract
{
    public interface IOrderPropositionRealizator
    {
        Task<IRealizeOrderPropositionResponse> RealizeOrderProposition(IRealizeOrderPropositionRequest request);
    }
}
