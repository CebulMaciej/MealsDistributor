using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Providers.Meals.Abstract;
using Domain.Providers.Meals.Request.Abstract;
using Domain.Providers.Meals.Response;
using Domain.Providers.Meals.Response.Abstract;
using Domain.Providers.Meals.Response.Concrete;
using Domain.Repositories.Abstract;

namespace Domain.Providers.Meals.Concrete
{
    public class MealProvider : IMealProvider
    {
        private readonly ILogger _logger;
        private readonly IMealRepository _mealRepository;

        public MealProvider(ILogger logger, IMealRepository mealRepository)
        {
            _logger = logger;
            _mealRepository = mealRepository;
        }

        public async Task<IGetMealByIdResponse> GetMealById(IGetMealByIdRequest request)
        {
            try
            {
                Meal meal = await _mealRepository.GetMealById(request.MealId);
                return new GetMealByIdResponse(meal);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new GetMealByIdResponse(MealProvideResultEnum.Exception);
            }
        }

        public async Task<IGetMealsByRestaurantIdResponse> GetMealsByRestaurantId(IGetMealsByRestaurantIdRequest request)
        {
            try
            {
                IList<Meal> meals = await _mealRepository.GetMealsByRestaurantId(request.RestaurantId);
                return new GetMealsByRestaurantIdResponse(meals);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new GetMealsByRestaurantIdResponse(MealProvideResultEnum.Exception);
            }
        }
    }
}
