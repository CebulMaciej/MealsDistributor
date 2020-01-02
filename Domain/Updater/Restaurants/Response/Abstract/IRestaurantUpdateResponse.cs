using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Updater.Restaurants.Response.Const;

namespace Domain.Updater.Restaurants.Response.Abstract
{
    public interface IRestaurantUpdateResponse
    {
        RestaurantUpdateResponseEnum Result { get; }
        Restaurant Restaurant { get; }
    }
}
