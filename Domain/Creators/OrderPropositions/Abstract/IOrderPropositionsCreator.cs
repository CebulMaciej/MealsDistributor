using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Creators.OrderPropositions.Request.Abstract;
using Domain.Creators.OrderPropositions.Response.Abstract;

namespace Domain.Creators.OrderPropositions.Abstract
{
    public interface IOrderPropositionsCreator
    {
        Task<IOrderPropositionCreationResponse> CreateOrderProposition(IOrderPropositionCreationRequest request);
    }
}
