using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Infrastructure.Logging.Abstract;
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
        [HttpGet("restaurant/{id:int}")]
        [ProducesResponseType(200, Type = typeof(GetRestaurantResponseModel))]
        public Task<ActionResult> GetRestaurant(int id)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }

            return null;
        }

        [HttpGet("restaurants")]
        [ProducesResponseType(200, Type = typeof(GetRestaurantsResponseModel))]
        public Task<ActionResult> GetRestaurants(int restaurantId)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }

            return null;
        }

        [HttpPost("restaurant")]
        [ProducesResponseType(200)]
        public Task<ActionResult> AddRestaurant(AddRestaurantRequestModel requestModel)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }

            return null;
        }

        [HttpPut("restaurant")]
        [ProducesResponseType(200)]
        public Task<ActionResult> EditRestaurant(EditRestaurantRequestModel requestModel)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }

            return null;
        }
        [HttpDelete("restaurant/{id:int}")]
        [ProducesResponseType(200)]
        public Task<ActionResult> DeleteRestaurant(int id)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
            }

            return null;
        }
    }
}
