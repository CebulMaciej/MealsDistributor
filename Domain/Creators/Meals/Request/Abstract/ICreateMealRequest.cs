using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Creators.Meals.Request.Abstract
{
    public interface ICreateMealRequest
    {
        string Name { get; }
        string Description { get; }
        decimal Price { get; }
        DateTime? StartDate { get; }
        DateTime? EndDate { get; }
        Guid RestaurantId { get; }

    }
}
