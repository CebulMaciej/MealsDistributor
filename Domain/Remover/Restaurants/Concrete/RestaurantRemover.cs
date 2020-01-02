using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Remover.Restaurants.Abstract;
using Domain.Remover.Restaurants.Request.Abstract;
using Domain.Remover.Restaurants.Response.Abstract;
using Domain.Remover.Restaurants.Response.Concrete;
using Domain.Repositories.Abstract;

namespace Domain.Remover.Restaurants.Concrete
{
    public class RestaurantRemover : IRestaurantRemover
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ILogger _logger;

        public RestaurantRemover(IRestaurantRepository restaurantRepository, ILogger logger)
        {
            _restaurantRepository = restaurantRepository;
            _logger = logger;
        }

        public async Task<IRestaurantRemoveResponse> RemoveRestaurant(IRestaurantRemoveRequest request)
        {
            try
            {
                await _restaurantRepository.RemoveRestaurant(request.Id);
                return new RestaurantRemoveResponse(true);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new RestaurantRemoveResponse(false);
            }
        }
    }
}
