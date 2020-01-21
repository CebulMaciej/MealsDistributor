using MealsDistributor.Model.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealsDistributor.Model.Response.OrderPosition
{
    public class GetExtendedOrderPositionsResponseModel
    {
        public IList<ExtendedOrderPositionApiModel> OrderPositions { get; set; }
    }
}
