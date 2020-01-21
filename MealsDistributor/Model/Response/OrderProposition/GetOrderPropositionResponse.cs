using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealsDistributor.Model.ApiModels;

namespace MealsDistributor.Model.Response.OrderProposition
{
    public class GetOrderPropositionResponse
    {
        public OrderPropositionApiModel OrderProposition { get; set; }
        public RestaurantApiModel Restaurant { get; set; }
        public IList<ExtendedOrderPropositionPositionApiModel> Positions { get; set; }
        public UserApiModel Creator { get; set; }
    }
}
