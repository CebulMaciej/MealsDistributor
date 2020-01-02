using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.Meals.Response;
using Domain.Providers.Restaurants.Request.Abstract;
using Domain.Providers.Restaurants.Response.Abstract;

namespace Domain.Providers.Restaurants.Request.Concrete
{
    public class GetRestaurantRequest : IGetRestaurantRequest
    {
        public GetRestaurantRequest(Guid restaurantId)
        {
            RestaurantId = restaurantId;
        }

        public Guid RestaurantId { get; }
    }
}
