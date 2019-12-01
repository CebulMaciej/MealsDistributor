using System;
using Domain.BusinessObject;
using Domain.Creators.Meals.Response.Abstract;
using Domain.Creators.Meals.Response.Const;

namespace Domain.Creators.Meals.Response.Concrete
{
    public class CreateMealResponse : ICreateMealResponse
    {
        public CreateMealResponse(Meal meal)
        {
            Meal = meal;
        }

        public CreateMealResponse(CreateMealEnum result)
        {
            Result = result;
            if(result != CreateMealEnum.Success) throw new InvalidOperationException("while success use constructor with Meal object");
        }

        public CreateMealEnum Result { get; }
        public Meal Meal { get; }
    }
}
