using System;
using System.Collections.Generic;
using System.Text;
using Domain.Creators.Restaurants.Request.Abstract;

namespace Domain.Creators.Restaurants.Request.Concrete
{
    public class CreateRestaurantRequest : ICreateRestaurantRequest
    {
        public CreateRestaurantRequest(string name, string phoneNumber, bool isPyszne, decimal? minOrderCost, decimal? deliveryCost, decimal? maxPaidOrderValue)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            IsPyszne = isPyszne;
            MinOrderCost = minOrderCost;
            DeliveryCost = deliveryCost;
            MaxPaidOrderValue = maxPaidOrderValue;
        }

        public string Name { get; }
        public string PhoneNumber { get; }
        public bool IsPyszne { get; }
        public decimal? MinOrderCost { get; }
        public decimal? DeliveryCost { get; }
        public decimal? MaxPaidOrderValue { get; }
    }
}
