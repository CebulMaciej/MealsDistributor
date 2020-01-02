using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastructure.Logging.Abstract;
using Domain.Remover.Meals.Abstract;
using Domain.Remover.Meals.Request.Abstract;
using Domain.Remover.Meals.Response.Abstract;
using Domain.Remover.Meals.Response.Concrete;
using Domain.Repositories.Abstract;

namespace Domain.Remover.Meals.Concrete
{
    public class MealsRemover : IMealsRemover
    {
        private readonly ILogger _logger;
        private readonly IMealRepository _mealRepository;
        public async Task<IMealRemoveResponse> RemoveMeal(IMealRemoveRequest request)
        {
            try
            {
                await _mealRepository.RemoveMeal(request.MealId);
                return new MealRemoveResponse(true);
            }
            catch (Exception ex)
            {
                _logger.Log(ex);
                return new MealRemoveResponse(false);
            }
        }
    }
}
