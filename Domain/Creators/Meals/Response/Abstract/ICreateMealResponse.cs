using System;
using System.Collections.Generic;
using System.Text;
using Domain.BusinessObject;
using Domain.Creators.Meals.Response.Const;

namespace Domain.Creators.Meals.Response.Abstract
{
    public interface ICreateMealResponse
    {
        CreateMealEnum Result { get; }
        Meal Meal { get; }
    }
}
