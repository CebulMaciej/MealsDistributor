using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealsDistributor.Model.ApiModels
{
    public class OrderApiModel
    {
        public Guid? Id { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid? OrderBoyId { get; set; }
        public bool IsOrdered { get; set; }
    }
}
