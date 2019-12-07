using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.Meals.Response;
using Domain.Providers.Restaurants.Response.Abstract;

namespace Domain.Providers.Restaurants.Response.Concrete
{
    public class GetRestaurantResponse : IGetRestaurantResponse
    {
        public GetRestaurantResponse(Restaurant restaurant)
        {
            Restaurant = restaurant;
        }

        public GetRestaurantResponse()
        {
            Result = RestaurantProvideResultEnum.Exception;
        }

        public GetRestaurantResponse(RestaurantProvideResultEnum result)
        {
            if(result == RestaurantProvideResultEnum.Success) throw new InvalidOperationException("Use constructor with Restaurant Object");
            Result = result;
        }

        public Restaurant Restaurant { get; }
        public RestaurantProvideResultEnum Result { get; }
    }
}
