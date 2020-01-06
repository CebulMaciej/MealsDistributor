using System;
using System.Threading.Tasks;
using Domain.Creators.Restaurants.Abstract;
using Domain.Creators.Restaurants.Request.Concrete;
using Domain.Creators.Restaurants.Response.Abstract;
using Domain.Creators.Restaurants.Response.Const;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Meals.Response;
using Domain.Providers.Restaurants.Abstract;
using Domain.Providers.Restaurants.Request.Concrete;
using Domain.Providers.Restaurants.Response.Abstract;
using Domain.Remover.Restaurants.Abstract;
using Domain.Remover.Restaurants.Request.Concrete;
using Domain.Remover.Restaurants.Response.Abstract;
using Domain.Updater.Restaurants.Abstract;
using Domain.Updater.Restaurants.Request.Concrete;
using Domain.Updater.Restaurants.Response.Abstract;
using Domain.Updater.Restaurants.Response.Const;
using MealsDistributor.Model.Request.Restaurant;
using MealsDistributor.Model.Response.Restaurant;
using Microsoft.AspNetCore.Mvc;

namespace MealsDistributor.Controllers
{
    [Route("api")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {

        private readonly ILogger _logger;
        private readonly IRestaurantProvider _restaurantProvider;
        private readonly IRestaurantCreator _restaurantCreator;
        private readonly IRestaurantRemover _restaurantRemover;
        private readonly IRestaurantUpdater _restaurantUpdater;

        public RestaurantsController(ILogger logger, IRestaurantProvider restaurantProvider, IRestaurantCreator restaurantCreator, IRestaurantRemover restaurantRemover, IRestaurantUpdater restaurantUpdater)
        {
            _logger = logger;
            _restaurantProvider = restaurantProvider;
            _restaurantCreator = restaurantCreator;
            _restaurantRemover = restaurantRemover;
            _restaurantUpdater = restaurantUpdater;
        }

        [HttpGet("restaurant/{id:Guid}")]
        [ProducesResponseType(200, Type = typeof(GetRestaurantResponseModel))]
        public async Task<ActionResult> GetRestaurant(Guid id)
        {
            try
            {
                IGetRestaurantResponse getRestaurantResponse = await _restaurantProvider.GetRestaurant(new GetRestaurantRequest(id));
                switch (getRestaurantResponse.Result)
                {
                    case RestaurantProvideResultEnum.Success:
                        return Ok(getRestaurantResponse.Restaurant);
                    case RestaurantProvideResultEnum.NotFound:
                        return NotFound();
                    case RestaurantProvideResultEnum.Exception:
                        return StatusCode(500);
                    case RestaurantProvideResultEnum.Forbidden:
                        return Forbid();
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }

        [HttpGet("restaurants")]
        [ProducesResponseType(200, Type = typeof(GetRestaurantsResponseModel))]
        public async Task<ActionResult> GetRestaurants()
        {
            try
            {
                var z = HttpContext.User;


                IGetRestaurantsResponse getRestaurantsResponse = await _restaurantProvider.GetRestaurants();
                return getRestaurantsResponse.Result switch
                {
                    RestaurantProvideResultEnum.Success => (ActionResult) Ok(getRestaurantsResponse.Restaurants),
                    RestaurantProvideResultEnum.NotFound => NotFound(),
                    RestaurantProvideResultEnum.Exception => StatusCode(500),
                    RestaurantProvideResultEnum.Forbidden => Forbid(),
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }

        [HttpPost("restaurant")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> AddRestaurant(AddRestaurantRequestModel requestModel)
        {
            try
            {
                ICreateRestaurantResponse createRestaurantResponse = await _restaurantCreator.CreateRestaurant(new CreateRestaurantRequest(requestModel.Name,
                    requestModel.PhoneNumber, requestModel.IsPyszne, requestModel.MinOrderCost,
                    requestModel.DeliveryCost, requestModel.MaxPaidOrderValue));
                switch (createRestaurantResponse.Result)
                {
                    case CreateRestaurantEnum.Success:
                        return Ok(createRestaurantResponse.Restaurant);
                    case CreateRestaurantEnum.Error:
                        return StatusCode(500);
                    case CreateRestaurantEnum.CreatedNotFound:
                        return NotFound();
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }

        [HttpPut("restaurant")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> EditRestaurant(EditRestaurantRequestModel requestModel)
        {
            try
            {
                IRestaurantUpdateResponse restaurantUpdateResponse = await _restaurantUpdater.UpdateRestaurant(new RestaurantUpdateRequest(requestModel.Id,
                    requestModel.Name, requestModel.PhoneNumber, requestModel.IsPyszne, requestModel.MinOrderCost,
                    requestModel.DeliveryCost, requestModel.MaxPaidOrderValue));
                switch (restaurantUpdateResponse.Result)
                {
                    case RestaurantUpdateResponseEnum.Success:
                        return Ok(restaurantUpdateResponse.Restaurant);
                    case RestaurantUpdateResponseEnum.NotFound:
                        return NotFound();
                    case RestaurantUpdateResponseEnum.Error:
                        return StatusCode(500);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }
        [HttpDelete("restaurant/{id:Guid}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> DeleteRestaurant(Guid id)
        {
            try
            {
                IRestaurantRemoveResponse restaurantRemoveResponse = await _restaurantRemover.RemoveRestaurant(new RestaurantRemoveRequest(id));
                if (restaurantRemoveResponse.Success)
                {
                    return Ok();
                }

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }
    }
}
