using MealsDistributor.Model.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealsDistributor.Model.Response.OrderProposition
{
    public class GetOrderPropositionsResponseModel
    {
        public IList<OrderPropositionApiModel> OrderPropositions { get; set; }
    }
}
