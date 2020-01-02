using System;
using System.Collections.Generic;
using System.Text;
using Domain.Updater.Restaurants.Request.Abstract;

namespace Domain.Updater.Restaurants.Request.Concrete
{
    public class RestaurantUpdateRequest : IRestaurantUpdateRequest
    {
        public RestaurantUpdateRequest(Guid id,string name, string phoneNumber, bool isPyszne, decimal? minOrderCost, decimal? deliveryCost, decimal? maxPaidOrderValue)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            IsPyszne = isPyszne;
            MinOrderCost = minOrderCost;
            DeliveryCost = deliveryCost;
            MaxPaidOrderValue = maxPaidOrderValue;
            Id = id;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string PhoneNumber { get; }
        public bool IsPyszne { get; }
        public decimal? MinOrderCost { get; }
        public decimal? DeliveryCost { get; }
        public decimal? MaxPaidOrderValue { get; }
    }
}
