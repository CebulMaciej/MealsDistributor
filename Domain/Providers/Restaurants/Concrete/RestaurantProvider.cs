using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Meals.Response;
using Domain.Providers.Restaurants.Abstract;
using Domain.Providers.Restaurants.Request.Abstract;
using Domain.Providers.Restaurants.Response.Abstract;
using Domain.Providers.Restaurants.Response.Concrete;
using Domain.Repositories.Abstract;
using GetRestaurantsResponse = Domain.Providers.Restaurants.Request.Concrete.GetRestaurantsResponse;

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
                Restaurant restaurant = await _restaurantRepository.GetRestaurant(request.RestaurantId);
                if (restaurant == null)
                {
                    return new GetRestaurantResponse(RestaurantProvideResultEnum.NotFound);
                }
                return new GetRestaurantResponse(restaurant);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new GetRestaurantResponse();
            }
        }

        public async Task<IGetRestaurantsResponse> GetRestaurants()
        {
            try
            {
                IList<Restaurant> restaurants = await _restaurantRepository.GetRestaurants();
                if (restaurants == null)
                {
                    return new GetRestaurantsResponse(RestaurantProvideResultEnum.NotFound);
                }
                return new GetRestaurantsResponse(restaurants);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new GetRestaurantsResponse();
            }
        }
    }
}
