using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Updater.Order.Request.Abstract
{
    public interface IOrderUpdateRequest
    {
        Guid Id { get; }
        Guid CurrentLoggedInUserId { get; }
    }
}
