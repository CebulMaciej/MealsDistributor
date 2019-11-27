using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Providers.Meals.Request.Abstract
{
    public interface IGetMealsByRestaurantIdRequest
    {
        Guid RestaurantId { get; }
    }
}
