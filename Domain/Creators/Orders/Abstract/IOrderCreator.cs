using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Creators.Orders.Request.Abstract;
using Domain.Creators.Orders.Response.Abstract;

namespace Domain.Creators.Orders.Abstract
{
    public interface IOrderCreator
    {
        Task<ICreateOrderResponse> CreateOrder(ICreateOrderRequest request);
    }
}
