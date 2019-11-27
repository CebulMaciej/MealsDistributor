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
        Task<IList<Meal>> GetMealsByRestaurantId(Guid restaurantId);
    }
}
