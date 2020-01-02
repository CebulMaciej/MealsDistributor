using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Providers.Restaurants.Request.Abstract;
using Domain.Providers.Restaurants.Response.Abstract;

namespace Domain.Providers.Restaurants.Abstract
{
    public interface IRestaurantProvider
    {
        Task<IGetRestaurantResponse> GetRestaurant(IGetRestaurantRequest request);
        Task<IGetRestaurantsResponse> GetRestaurants();
    }
}
