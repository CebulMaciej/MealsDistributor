﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.Creators.Meals.Abstract;
using Domain.Creators.Meals.Request.Abstract;
using Domain.Creators.Meals.Request.Concrete;
using Domain.Creators.Meals.Response.Abstract;
using Domain.Creators.Meals.Response.Const;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Meals.Abstract;
using Domain.Providers.Meals.Request.Abstract;
using Domain.Providers.Meals.Request.Concrete;
using Domain.Providers.Meals.Response;
using Domain.Providers.Meals.Response.Abstract;
using Domain.Updater.Meals.Abstract;
using Domain.Updater.Meals.Request.Abstract;
using Domain.Updater.Meals.Request.Concrete;
using Domain.Updater.Meals.Response.Abstract;
using MealsDistributor.Infrastructure.ObjectsToModelConverting.Abstract;
using MealsDistributor.Model.ApiModels;
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
        private readonly IMealCreator _mealCreator;
        private readonly IMealUpdater _mealUpdater;

        public MealsController(ILogger logger, IMealProvider mealsProvider, IObjectToApiModelConverter objectToApiModelConverter, IMealCreator mealCreator, IMealUpdater mealUpdater)
        {
            _logger = logger;
            _mealsProvider = mealsProvider;
            _objectToApiModelConverter = objectToApiModelConverter;
            _mealCreator = mealCreator;
            _mealUpdater = mealUpdater;
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
        public async Task<ActionResult> AddMeal(AddMealRequestModel requestModel)
        {
            try
            {
                if (!requestModel.RestaurantId.HasValue)
                {
                    return StatusCode(400);
                }

                ICreateMealRequest createMealRequest = PrepareCreateMealRequestFromApiRequest(requestModel);
                ICreateMealResponse createMealResponse = await _mealCreator.CreateMeal(createMealRequest);

                if (createMealResponse.Result == CreateMealEnum.Success)
                {
                    return Ok(createMealResponse.Meal);
                }

                return StatusCode(500);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }

        private static CreateMealRequest PrepareCreateMealRequestFromApiRequest(MealApiModel requestModel)
        {
            return new CreateMealRequest(requestModel.Name,requestModel.Description,
                requestModel.Price, requestModel.StartDate, requestModel.EndDate, requestModel.RestaurantId.Value);
        }

        [HttpPut("meal")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> EditMeal(EditMealRequestModel requestModel)
        {
            try
            {
                IUpdateMealRequest updateMealRequest = new UpdateMealRequest(requestModel.Id.Value, requestModel.Name,
                    requestModel.Description, requestModel.Price, requestModel.StartDate, requestModel.EndDate,
                    requestModel.RestaurantId.Value);
                IUpdateMealResponse response = await _mealUpdater.UpdateMeal(updateMealRequest);
                return null;
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return StatusCode(500);
            }
        }
    }
}
