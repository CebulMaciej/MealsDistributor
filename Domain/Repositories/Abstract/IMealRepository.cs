using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;

namespace Domain.Repositories.Abstract
{
    public interface IMealRepository
    {
        Task<Meal> GetMealById(Guid id);

        Task<Meal> CreateMeal(string name, string description, decimal price, DateTime? startDate, DateTime? endDate,
            Guid restaurantId);
        Task<IList<Meal>> GetMealsByRestaurantId(Guid restaurantId);
        Task<Meal> UpdateMeal(Guid id, string name, string description, decimal price, DateTime? startDate, DateTime? endDate,
            Guid restaurantId);
    }
}
