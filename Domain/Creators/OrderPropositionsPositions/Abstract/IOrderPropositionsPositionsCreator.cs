using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Creators.OrderPropositionsPositions.Request.Abstract;
using Domain.Creators.OrderPropositionsPositions.Response.Abstract;

namespace Domain.Creators.OrderPropositionsPositions.Abstract
{
    public interface IOrderPropositionsPositionsCreator
    {
        Task<IOrderPropositionPositionCreateResponse> CreateOrderPropositionPosition(
            IOrderPropositionPositionCreateRequest request);
    }
}
