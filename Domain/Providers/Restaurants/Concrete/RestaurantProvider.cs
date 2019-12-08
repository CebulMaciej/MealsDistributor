using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Restaurants.Abstract;
using Domain.Providers.Restaurants.Request.Abstract;
using Domain.Providers.Restaurants.Request.Concrete;
using Domain.Providers.Restaurants.Response.Abstract;
using Domain.Repositories.Abstract;

namespace Domain.Providers.Restaurants.Concrete
{
    public class RestaurantProvider : IRestaurantProvider
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ILogger _logger;
        public RestaurantProvider(IRestaurantRepository restaurantRepository, ILogger logger)
        {
            _restaurantRepository = restaurantRepository;
            _logger = logger;
        }

        public async Task<IGetRestaurantResponse> GetRestaurant(IGetRestaurantRequest request)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new GetRestaurantResponse();
            }
        }

        public async Task<IGetRestaurantsResponse> GetRestaurants(IGetRestaurantsRequest request)
        {
            try
            {
                _restaurantRepository
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new GetRestaurantsResponse();
            }
            throw new NotImplementedException();
        }
    }
}
