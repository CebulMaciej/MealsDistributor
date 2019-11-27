using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;

namespace Domain.Providers.Meals.Response.Abstract
{
    public interface IGetMealByIdResponse
    {
        MealProvideResultEnum MealProvideResult { get; }
        Meal Meal { get; }
    }
}
