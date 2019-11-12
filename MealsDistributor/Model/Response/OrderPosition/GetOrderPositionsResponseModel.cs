using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealsDistributor.Model.ApiModels;

namespace MealsDistributor.Model.Response.OrderPosition
{
    public class GetOrderPositionsResponseModel
    {
        public IList<OrderPositionApiModel> OrderPositions { get; }
    }
}
