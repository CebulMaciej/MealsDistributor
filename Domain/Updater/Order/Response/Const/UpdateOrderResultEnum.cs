using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Updater.Order.Response.Const
{
    public enum UpdateOrderResultEnum
    {
        Exception = 0,
        Forbidden,
        NotFound,
        Success
    }
}
