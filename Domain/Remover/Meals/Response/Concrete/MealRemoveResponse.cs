using System;
using System.Collections.Generic;
using System.Text;
using Domain.Remover.Meals.Response.Abstract;

namespace Domain.Remover.Meals.Response.Concrete
{
    public class MealRemoveResponse : IMealRemoveResponse
    {
        public MealRemoveResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
    }
}
