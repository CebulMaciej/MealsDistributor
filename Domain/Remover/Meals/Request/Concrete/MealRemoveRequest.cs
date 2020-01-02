using System;
using Domain.Remover.Meals.Request.Abstract;

namespace Domain.Remover.Meals.Request.Concrete
{
    public class MealRemoveRequest : IMealRemoveRequest
    {
        public MealRemoveRequest(Guid mealId)
        {
            MealId = mealId;
        }

        public Guid MealId { get; }
    }
}
