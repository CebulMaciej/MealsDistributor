using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Providers.OrderPropositions.Request.Abstract;
using Domain.Providers.OrderPropositions.Response.Abstract;

namespace Domain.Providers.OrderPropositions.Abstract
{
    public interface IOrderPropositionsProvider
    {
        Task<IGetOrderPropositionsResponse> GetOrderPropositionsInWhichUserTakeParts(IGetOrderPropositionsInWhichUserTakePartsRequest request);
        Task<IGetOrderPropositionsResponse> GetActualOrderPropositions();
        Task<IGetOrderPropositionResponse> GetOrderPropositionById(IGetOrderPropositionByIdRequest request);
    }
}
