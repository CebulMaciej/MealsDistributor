using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.Meals.Response;

namespace Domain.Providers.Restaurants.Response.Abstract
{
    public interface IGetRestaurantResponse
    {
        Restaurant Restaurant { get; }
        RestaurantProvideResultEnum Result { get; }
    }
}
