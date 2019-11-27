using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Meals.Abstract;
using Domain.Providers.Meals.Request.Abstract;
using Domain.Providers.Meals.Request.Concrete;
using Domain.Providers.Meals.Response;
using Domain.Providers.Meals.Response.Abstract;
using MealsDistributor.Infrastructure.ObjectsToModelConverting.Abstract;
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
        private readonly IMealProvider _mealsProvider;
        private readonly IObjectToApiModelConverter _objectToApiModelConverter;

        public MealsController(ILogger logger, IMealProvider mealsProvider, IObjectToApiModelConverter objectToApiModelConverter)
        {
            _logger = logger;
            _mealsProvider = mealsProvider;
            _objectToApiModelConverter = objectToApiModelConverter;
        }

        [HttpGet("meal/{id:guid?}")]
        [ProducesResponseType(200, Type = typeof(GetMealResponseModel))]
        public async Task<ActionResult> GetMeal(Guid? id)
        {
            try
            {
                IGetMealByIdRequest request = new GetMealByIdRequest(id.GetValueOrDefault(Guid.Empty));   
                IGetMealByIdResponse response = await _mealsProvider.GetMealById(request);
                return PrepareResponseAfterGetMealById(response);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }

        private ActionResult PrepareResponseAfterGetMealById(IGetMealByIdResponse response)
        {
            return response.MealProvideResult switch
            {
                MealProvideResultEnum.Success => (ActionResult) Ok(_objectToApiModelConverter.ConvertMeal(response.Meal)),
                MealProvideResultEnum.NotFound => StatusCode(404),
                MealProvideResultEnum.Exception => StatusCode(500),
                MealProvideResultEnum.Forbidden => StatusCode(403),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        [HttpGet("restaurant/{restaurantId:guid}/meals")]
        [ProducesResponseType(200, Type = typeof(GetMealsResponseModel))]
        public async Task<ActionResult> GetMeals(Guid restaurantId)
        {
            try
            {
                IGetMealsByRestaurantIdRequest request = new GetMealsByRestaurantIdRequest(restaurantId);
                IGetMealsByRestaurantIdResponse response = await _mealsProvider.GetMealsByRestaurantId(request);
                return PrepareResponseAfterGetMealsByRestaurantId(response);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }

        private ActionResult PrepareResponseAfterGetMealsByRestaurantId(IGetMealsByRestaurantIdResponse response)
        {
            return response.MealProvideResult switch
            {
                MealProvideResultEnum.Success => (ActionResult) Ok(new GetMealsResponseModel
                {
                    Meals = response.Meals.Select(_objectToApiModelConverter.ConvertMeal).ToList()
                }),
                MealProvideResultEnum.NotFound => StatusCode(404),
                MealProvideResultEnum.Exception => StatusCode(500),
                MealProvideResultEnum.Forbidden => StatusCode(403),
                _ => throw new ArgumentOutOfRangeException()
            };
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
