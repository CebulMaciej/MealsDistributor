using System;
using System.Threading.Tasks;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Repositories.Abstract;
using Domain.Updater.Meals.Abstract;
using Domain.Updater.Meals.Request.Abstract;
using Domain.Updater.Meals.Response.Abstract;
using Domain.Updater.Meals.Response.Concrete;
using Domain.Updater.Meals.Response.Const;

namespace Domain.Updater.Meals.Concrete
{
    public class MealUpdater : IMealUpdater
    {
        private readonly ILogger _logger;
        private readonly IMealRepository _mealRepository;
        public MealUpdater(ILogger logger, IMealRepository mealRepository)
        {
            _logger = logger;
            _mealRepository = mealRepository;
        }

        public async Task<IUpdateMealResponse> UpdateMeal(IUpdateMealRequest updateMealRequest)
        {
            try
            {
                BusinessObject.Meal meal = await _mealRepository.UpdateMeal(updateMealRequest.Id,updateMealRequest.Name,updateMealRequest.Description,
                    updateMealRequest.Price,updateMealRequest.StartDate,updateMealRequest.EndDate);
                return new UpdateMealResponse(meal);
            }
            catch (Exception ex)
            { 
                _logger.Log(ex);
                return new UpdateMealResponse(UpdateMealResponseEnum.Exception);
            }
        }
    }
}
