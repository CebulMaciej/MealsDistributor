using Domain.Updater.Meals.Response.Const;

namespace Domain.Updater.Meals.Response.Abstract
{
    public interface IUpdateMealResponse
    {
        BusinessObject.Meal Meal { get; }
        UpdateMealResponseEnum Result { get; }
    }
}
