using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealsDistributor.Model.ApiModels;

namespace MealsDistributor.Model.Response.Order
{
    public class GetOrdersResponseModel
    {
        public IList<OrderApiModel> Orders { get; set; }
    }
}
