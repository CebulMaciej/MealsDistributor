using System.Collections.Generic;
using MealsDistributor.Model.ApiModels;

namespace MealsDistributor.Model.Response.Order
{
    public class GetOrderResponseModel
    {
        public OrderApiModel Order { get; set; }
        public IList<ExtendedOrderPositionApiModel> OrderPositions { get; set; }
        public UserApiModel OrderBoy { get; set; }
        public RestaurantApiModel Restaurant { get; set; }
    }
}
