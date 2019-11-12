using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealsDistributor.Model.ApiModels;

namespace MealsDistributor.Model.Response.Meal
{
    public class GetMealsResponseModel
    {
        public IList<MealApiModel> Meals { get; set; }
    }
}
