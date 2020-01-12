using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealsDistributor.Model.ApiModels
{
    public class OrderPropositionPositionApiModel
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid UserId { get; set; }
        public Guid MealId { get; set; }
        public Guid OrderPropositionId { get; set; }
    }
}
