using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Providers.Meals.Request.Abstract;
using Domain.Providers.Meals.Response.Abstract;

namespace Domain.Providers.Meals.Abstract
{
    public interface IMealProvider
    {
        Task<IGetMealByIdResponse> GetMealById(IGetMealByIdRequest request);
        Task<IGetMealsByRestaurantIdResponse> GetMealsByRestaurantId(IGetMealsByRestaurantIdRequest request);
    }
}
