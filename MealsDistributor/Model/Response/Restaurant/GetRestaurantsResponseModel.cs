using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealsDistributor.Model.ApiModels;

namespace MealsDistributor.Model.Response.Restaurant
{
    public class GetRestaurantsResponseModel
    {
        public IList<RestaurantApiModel> Restaurants { get; set; }
    }
}
