using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Repositories.Abstract;
using Domain.Updater.Restaurants.Abstract;
using Domain.Updater.Restaurants.Request.Abstract;
using Domain.Updater.Restaurants.Response.Abstract;
using Domain.Updater.Restaurants.Response.Concrete;
using Domain.Updater.Restaurants.Response.Const;

namespace Domain.Updater.Restaurants.Concrete
{
    public class RestaurantUpdater : IRestaurantUpdater
    {
        private readonly ILogger _logger;
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantUpdater(ILogger logger, IRestaurantRepository restaurantRepository)
        {
            _logger = logger;
            _restaurantRepository = restaurantRepository;
        }

        public async Task<IRestaurantUpdateResponse> UpdateRestaurant(IRestaurantUpdateRequest request)
        {
            try
            {
                Restaurant restaurant = await _restaurantRepository.EditRestaurant(request.Id, request.Name, request.PhoneNumber,
                    request.IsPyszne, request.MinOrderCost, request.DeliveryCost, request.MaxPaidOrderValue);
                if (restaurant == null)
                {
                    return new RestaurantUpdateResponse(RestaurantUpdateResponseEnum.NotFound);
                }
                return new RestaurantUpdateResponse(restaurant);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new RestaurantUpdateResponse(RestaurantUpdateResponseEnum.Error);
            }
        }
    }
}
