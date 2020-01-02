using System;
using System.Collections.Generic;
using System.Text;
using Domain.Remover.Restaurants.Response.Abstract;

namespace Domain.Remover.Restaurants.Response.Concrete
{
    public class RestaurantRemoveResponse : IRestaurantRemoveResponse
    {
        public RestaurantRemoveResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
    }
}
