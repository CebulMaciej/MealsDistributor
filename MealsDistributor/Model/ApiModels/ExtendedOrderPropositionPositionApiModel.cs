using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealsDistributor.Model.ApiModels
{
    public class ExtendedOrderPropositionPositionApiModel : OrderPropositionPositionApiModel
    {
        public MealApiModel Meal { get; set; }
        public UserApiModel User { get; set; }
    }
}
