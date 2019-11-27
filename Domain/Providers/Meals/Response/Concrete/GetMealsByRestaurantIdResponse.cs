using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Providers.Meals.Response.Abstract;

namespace Domain.Providers.Meals.Response.Concrete
{
    public class GetMealsByRestaurantIdResponse : IGetMealsByRestaurantIdResponse
    {
        public GetMealsByRestaurantIdResponse(IList<Meal> meals)
        {
            if (meals == null)
            {
                MealProvideResult = MealProvideResultEnum.NotFound;
            }
            else
            {
                MealProvideResult = MealProvideResultEnum.Success;
                Meals = meals;
            }
        }

        public GetMealsByRestaurantIdResponse(MealProvideResultEnum result)
        {
            MealProvideResult = result;
            if (result == MealProvideResultEnum.Success) throw new InvalidOperationException("while success use constructor with meal object");
        }

        public MealProvideResultEnum MealProvideResult { get; }
        public IList<Meal> Meals { get; }
    }
}
