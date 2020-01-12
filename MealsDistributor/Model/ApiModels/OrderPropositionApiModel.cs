using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealsDistributor.Model.ApiModels
{
    public class OrderPropositionApiModel
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime TimeToOrdering { get; set; }
        public Guid CreatorID { get; set; }
        public Guid RestaurantId { get; set; }
        public bool OrderingStopped { get; set; }
    }
}
