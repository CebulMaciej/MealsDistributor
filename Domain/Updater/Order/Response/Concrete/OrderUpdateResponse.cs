using System;
using System.Collections.Generic;
using System.Text;
using Domain.Updater.Order.Response.Abstract;
using Domain.Updater.Order.Response.Const;

namespace Domain.Updater.Order.Response.Concrete
{
    public class OrderUpdateResponse : IOrderUpdateResponse
    {
        public OrderUpdateResponse(UpdateOrderResultEnum result)
        {
            Result = result;
        }

        public UpdateOrderResultEnum Result { get; }
    }
}
