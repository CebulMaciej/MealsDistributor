using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.Meals.Response;
using Domain.Providers.Restaurants.Response.Abstract;

namespace Domain.Providers.Restaurants.Request.Concrete
{
    public class GetRestaurantsResponse : IGetRestaurantsResponse
    {
        public GetRestaurantsResponse()
        {
            Result = RestaurantProvideResultEnum.Exception;
        }

        public GetRestaurantsResponse(IList<Restaurant> restaurant)
        {
            Restaurants = restaurant;
            Result = RestaurantProvideResultEnum.Success;
        }

        public GetRestaurantsResponse(RestaurantProvideResultEnum result)
        {
            Result = result;
            if (result == RestaurantProvideResultEnum.Success) throw new InvalidOperationException("Use constructor with object while success");
        }

        public IList<Restaurant> Restaurants { get; }
        public RestaurantProvideResultEnum Result { get; }
    }
}
