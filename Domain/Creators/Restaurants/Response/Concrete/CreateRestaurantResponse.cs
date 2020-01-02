using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Creators.Restaurants.Response.Abstract;
using Domain.Creators.Restaurants.Response.Const;

namespace Domain.Creators.Restaurants.Response.Concrete
{
    public class CreateRestaurantResponse : ICreateRestaurantResponse
    {
        public CreateRestaurantResponse(Restaurant restaurant)
        {
            Restaurant = restaurant;
            Result = CreateRestaurantEnum.Success;
        }

        public CreateRestaurantResponse(CreateRestaurantEnum result)
        {
            Result = result;
        }

        public Restaurant Restaurant { get; }
        public CreateRestaurantEnum Result { get; }
    }
}
