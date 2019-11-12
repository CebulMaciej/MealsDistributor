using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealsDistributor.Model.ApiModels
{
    public class RestaurantApiModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPyszne { get; set; }
        public decimal? MinOrderConst { get; set; }
        public decimal? DeliveryCost { get; set; }
        public decimal? MaxPaidOrderValue { get; set; }
    }
}
