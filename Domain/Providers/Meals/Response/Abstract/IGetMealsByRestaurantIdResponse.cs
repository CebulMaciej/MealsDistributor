using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;

namespace Domain.Providers.Meals.Response.Abstract
{
    public interface IGetMealsByRestaurantIdResponse
    {
        MealProvideResultEnum MealProvideResult { get; }
        IList<Meal> Meals { get; }
    }
}
