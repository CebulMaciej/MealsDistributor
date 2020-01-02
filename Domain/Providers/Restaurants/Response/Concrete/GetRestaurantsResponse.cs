using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.Meals.Response;
using Domain.Providers.Restaurants.Response.Abstract;

namespace Domain.Providers.Restaurants.Response.Concrete
{
    public class GetRestaurantsResponse : IGetRestaurantsResponse
    {
        public GetRestaurantsResponse(IList<Restaurant> restaurants)
        {
            Restaurants = restaurants;
            Result = RestaurantProvideResultEnum.Success;
        }

        public GetRestaurantsResponse(RestaurantProvideResultEnum result)
        {
            Result = result;
        }

        public IList<Restaurant> Restaurants { get; }
        public RestaurantProvideResultEnum Result { get; }
    }
}
