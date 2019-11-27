using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Infrastructure.Config.Objects;
using Domain.Providers.Configuration.Response.Const;
using Domain.Providers.Meals.Response.Abstract;

namespace Domain.Providers.Meals.Response.Concrete
{
    public class GetMealByIdResponse : IGetMealByIdResponse
    {
        public GetMealByIdResponse(Meal meal)
        {
            if (meal == null)
            {
                MealProvideResult = MealProvideResultEnum.NotFound;
            }
            else
            {
                MealProvideResult = MealProvideResultEnum.Success;
                Meal = meal;
            }
        }

        public GetMealByIdResponse(MealProvideResultEnum result)
        {
            MealProvideResult = result;
            if (result == MealProvideResultEnum.Success) throw new InvalidOperationException("while success use constructor with meal object");
        }

        public MealProvideResultEnum MealProvideResult { get; }
        public Meal Meal { get; }
    }
}
