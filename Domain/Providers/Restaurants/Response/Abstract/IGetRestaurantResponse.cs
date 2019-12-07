using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.Meals.Response;

namespace Domain.Providers.Restaurants.Response.Abstract
{
    public interface IGetRestaurantsResponse
    {
        IList<Restaurant> Restaurants { get; }
        RestaurantProvideResultEnum Result { get; }
    }
}
