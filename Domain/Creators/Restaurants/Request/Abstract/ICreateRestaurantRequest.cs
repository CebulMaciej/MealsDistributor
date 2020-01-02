using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Creators.Restaurants.Request.Abstract
{
    public interface ICreateRestaurantRequest
    {
        string Name { get; }
        string PhoneNumber { get; }
        bool IsPyszne { get; }
        decimal? MinOrderCost { get; }
        decimal? DeliveryCost { get; }
        decimal? MaxPaidOrderValue { get; }
    }
}
