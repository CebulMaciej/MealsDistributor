using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Creators.Orders.Response.Const;

namespace Domain.Creators.Orders.Response.Abstract
{
    public interface ICreateOrderResponse
    {
        Order Order { get; }
        CreateOrderResult Result { get; }
    }
}
