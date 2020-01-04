using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealsDistributor.Model.Request.OrderProposition
{
    public class CreateOrderPropositionRequestModel
    {
        public Guid RestaurantId { get; set; }
        public DateTime OrderingTime { get; set; }
    }
}
