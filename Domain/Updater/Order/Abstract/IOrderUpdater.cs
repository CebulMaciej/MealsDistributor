using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Updater.Order.Request.Abstract;
using Domain.Updater.Order.Response.Abstract;

namespace Domain.Updater.Order.Abstract
{
    public interface IOrderUpdater
    {
        Task<IOrderUpdateResponse> MarkOrderAsOrdered(IOrderUpdateRequest request);
    }
}
