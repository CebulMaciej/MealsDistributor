using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Providers.Meals.Request.Abstract
{
    public interface IGetMealByIdRequest
    {
        Guid MealId { get; }
        bool IsValid { get; }
    }
}
