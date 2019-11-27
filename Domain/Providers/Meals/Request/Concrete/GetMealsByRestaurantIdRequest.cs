using System;
using System.Collections.Generic;
using System.Text;
using Domain.Providers.Meals.Request.Abstract;

namespace Domain.Providers.Meals.Request.Concrete
{
    public class GetMealsByRestaurantIdRequest : IGetMealsByRestaurantIdRequest
    {
        public GetMealsByRestaurantIdRequest(Guid restaurantId)
        {
            RestaurantId = restaurantId;
        }

        public Guid RestaurantId { get; }
    }
}
