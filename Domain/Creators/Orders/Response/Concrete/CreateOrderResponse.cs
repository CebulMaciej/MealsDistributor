using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Creators.Orders.Response.Abstract;
using Domain.Creators.Orders.Response.Const;

namespace Domain.Creators.Orders.Response.Concrete
{
    public class CreateOrderResponse : ICreateOrderResponse
    {
        public CreateOrderResponse(Order order)
        {
            Order = order;
            Result = CreateOrderResult.Success;
        }

        public CreateOrderResponse(CreateOrderResult result)
        {
            Result = result;
        }

        public Order Order { get; }
        public CreateOrderResult Result { get; }
    }
}
