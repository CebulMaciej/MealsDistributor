using System.Collections.Generic;
using MealsDistributor.Model.ApiModels;

namespace MealsDistributor.Model.Response.Order
{
    public class GetOrderResponseModel
    {
        public OrderApiModel Order { get; set; }
        public IList<ExtendedOrderPositionApiModel> OrderPositions { get; set; }
    }
}
