using MealsDistributor.Model.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealsDistributor.Model.Response.OrderPropositionPosition
{
    public class GetExtendedOrderPropositionPositionsResponseModel
    {
        public IList<ExtendedOrderPropositionPositionApiModel> ExtendedOrderPropositionPositionApiModels { get; set; }
    }
}
