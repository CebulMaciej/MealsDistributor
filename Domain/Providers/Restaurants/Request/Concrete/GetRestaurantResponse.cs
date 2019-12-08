using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.Meals.Response;
using Domain.Providers.Restaurants.Response.Abstract;

namespace Domain.Providers.Restaurants.Request.Concrete
{
    public class GetRestaurantResponse : IGetRestaurantResponse
    {
        public GetRestaurantResponse()
        {
            Result = RestaurantProvideResultEnum.Exception;
        }

        public GetRestaurantResponse(Restaurant restaurant)
        {
            Restaurant = restaurant;
            Result = RestaurantProvideResultEnum.Success;
        }

        public GetRestaurantResponse(RestaurantProvideResultEnum result)
        {
            Result = result;
            if(result == RestaurantProvideResultEnum.Success) throw new InvalidOperationException("Use constructor with object while success");
        }

        public Restaurant Restaurant { get; }
        public RestaurantProvideResultEnum Result { get; }
    }
}
