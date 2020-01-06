using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Creators.Orders.Response.Const
{
    public enum CreateOrderResult
    {
        Success = 0,
        Exception = 1,
        CreatedNotFound = 2
    }
}
