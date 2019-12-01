using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Creators.Meals.Request.Abstract;
using Domain.Creators.Meals.Response.Abstract;

namespace Domain.Creators.Meals.Abstract
{
    public interface IMealCreator
    {
        Task<ICreateMealResponse> CreateMeal(ICreateMealRequest createMealRequest);
    }
}
