using System;
using System.Collections.Generic;
using System.Text;
using Domain.Providers.Meals.Request.Abstract;

namespace Domain.Providers.Meals.Request.Concrete
{
    public class GetMealByIdRequest : IGetMealByIdRequest
    {
        public GetMealByIdRequest(Guid mealId)
        {
            MealId = mealId;
        }

        public Guid MealId { get; }
        public bool IsValid => MealId != Guid.Empty;
    }
}
