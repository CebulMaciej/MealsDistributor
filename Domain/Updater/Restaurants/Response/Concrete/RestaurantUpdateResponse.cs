using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Updater.Restaurants.Response.Abstract;
using Domain.Updater.Restaurants.Response.Const;

namespace Domain.Updater.Restaurants.Response.Concrete
{
    public class RestaurantUpdateResponse : IRestaurantUpdateResponse
    {
        public RestaurantUpdateResponse(RestaurantUpdateResponseEnum result)
        {
            Result = result;
        }

        public RestaurantUpdateResponse(Restaurant restaurant)
        {
            Restaurant = restaurant;
            Result = RestaurantUpdateResponseEnum.Success;
        }

        public RestaurantUpdateResponseEnum Result { get; }
        public Restaurant Restaurant { get; }
    }
}
