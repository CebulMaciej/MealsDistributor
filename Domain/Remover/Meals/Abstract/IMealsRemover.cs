using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Remover.Meals.Request.Abstract;
using Domain.Remover.Meals.Response.Abstract;

namespace Domain.Remover.Meals.Abstract
{
    public interface IMealsRemover
    {
        Task<IMealRemoveResponse> RemoveMeal(IMealRemoveRequest request);
    }
}
