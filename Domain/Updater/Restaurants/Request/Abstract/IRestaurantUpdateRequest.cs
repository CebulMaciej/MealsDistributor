using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Updater.Restaurants.Request.Abstract
{
    public interface IRestaurantUpdateRequest
    {
        Guid Id { get; }
        string Name { get; }
        string PhoneNumber { get; }
        bool IsPyszne { get; }
        decimal? MinOrderCost { get; }
        decimal? DeliveryCost { get; }
        decimal? MaxPaidOrderValue { get; }
    }
}
