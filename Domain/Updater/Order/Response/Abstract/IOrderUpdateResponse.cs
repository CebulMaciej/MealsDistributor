using System;
using System.Collections.Generic;
using System.Text;
using Domain.Updater.Order.Response.Const;

namespace Domain.Updater.Order.Response.Abstract
{
    public interface IOrderUpdateResponse
    {
        UpdateOrderResultEnum Result { get; }
    }
}
