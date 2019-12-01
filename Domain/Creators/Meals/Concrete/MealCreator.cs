using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Creators.Meals.Abstract;
using Domain.Creators.Meals.Request.Abstract;
using Domain.Creators.Meals.Response.Abstract;
using Domain.Creators.Meals.Response.Concrete;
using Domain.Creators.Meals.Response.Const;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Repositories.Abstract;

namespace Domain.Creators.Meals.Concrete
{
    public class MealCreator : IMealCreator
    {
        private readonly ILogger _logger;
        private readonly IMealRepository _mealRepository;
        public MealCreator(ILogger logger, IMealRepository mealRepository)
        {
            _logger = logger;
            _mealRepository = mealRepository;
        }

        public async Task<ICreateMealResponse> CreateMeal(ICreateMealRequest createMealRequest)
        {
            try
            {
                Meal meal = await _mealRepository.CreateMeal(createMealRequest.Name, createMealRequest.Description,
                    createMealRequest.Price, createMealRequest.StartDate, createMealRequest.EndDate,
                    createMealRequest.RestaurantId);
                return new CreateMealResponse(meal);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new CreateMealResponse(CreateMealEnum.Exception);
            }
        }
    }
}
