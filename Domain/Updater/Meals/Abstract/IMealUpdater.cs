using System.Threading.Tasks;
using Domain.Updater.Meals.Request.Abstract;
using Domain.Updater.Meals.Response.Abstract;

namespace Domain.Updater.Meals.Abstract
{
    public interface IMealUpdater
    {
        Task<IUpdateMealResponse> UpdateMeal(IUpdateMealRequest updateMealRequest);
    }
}
