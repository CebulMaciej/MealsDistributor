using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealsDistributor.Model.ApiModels;

namespace MealsDistributor.Model.Response.Restaurant
{
    public class GetRestaurantResponseModel 
    {
        public RestaurantApiModel Restaurant { get; set; }
        public IList<MealApiModel> Meals { get; set; }
    }
}
