using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Creators.Restaurants.Abstract;
using Domain.Creators.Restaurants.Request.Abstract;
using Domain.Creators.Restaurants.Response.Abstract;
using Domain.Creators.Restaurants.Response.Concrete;
using Domain.Creators.Restaurants.Response.Const;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Repositories.Abstract;

namespace Domain.Creators.Restaurants.Concrete
{
    public class RestaurantCreator : IRestaurantCreator
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ILogger _logger;

        public RestaurantCreator(ILogger logger, IRestaurantRepository restaurantRepository)
        {
            _logger = logger;
            _restaurantRepository = restaurantRepository;
        }

        public async Task<ICreateRestaurantResponse> CreateRestaurant(ICreateRestaurantRequest request)
        {
            try
            {
                Restaurant restaurant = await _restaurantRepository.CreateRestaurant(request.Name, request.PhoneNumber, request.IsPyszne,
                    request.MinOrderCost, request.DeliveryCost, request.MaxPaidOrderValue);
                if (restaurant == null)
                {
                    return new CreateRestaurantResponse(CreateRestaurantEnum.CreatedNotFound);
                }
                return new CreateRestaurantResponse(restaurant);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new CreateRestaurantResponse(CreateRestaurantEnum.Error);
            }
        }
    }
}
