using System;
using Domain.BusinessObject;
using Domain.Updater.Meals.Response.Abstract;
using Domain.Updater.Meals.Response.Const;

namespace Domain.Updater.Meals.Response.Concrete
{
    public class UpdateMealResponse : IUpdateMealResponse
    {
        public UpdateMealResponse(UpdateMealResponseEnum result)
        {
            if(result == UpdateMealResponseEnum.Success) throw new InvalidOperationException("Use constructor with object while success");
            Result = result;
        }
        public UpdateMealResponse(Meal meal)
        {
            Meal = meal;
        }
        public Meal Meal { get; }
        public UpdateMealResponseEnum Result { get; }
    }
}
