using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Infrastructure.Logging.Abstract;
using MealsDistributor.Model.Request.Meals;
using MealsDistributor.Model.Response.Meal;
using Microsoft.AspNetCore.Mvc;

namespace MealsDistributor.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MealsController : ControllerBase
    {

        private readonly ILogger _logger;

        [HttpGet("meal/{id:int}")]
        [ProducesResponseType(200, Type = typeof(GetMealResponseModel))]
        public Task<ActionResult> GetMeal(int id)
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

        [HttpGet("restaurant/{restaurantId:int}/meals")]
        [ProducesResponseType(200, Type = typeof(GetMealsResponseModel))]
        public Task<ActionResult> GetMeals(int restaurantId)
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

        [HttpPost("meal")]
        [ProducesResponseType(200)]
        public Task<ActionResult> AddMeal(AddMealRequestModel requestModel)
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

        [HttpPut("meal")]
        [ProducesResponseType(200)]
        public Task<ActionResult> EditMeal(EditMealRequestModel requestModel)
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
