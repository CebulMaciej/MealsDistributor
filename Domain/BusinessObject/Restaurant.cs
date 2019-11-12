using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.BusinessObject
{
    public class Restaurant
    {
        public Restaurant(Guid id, string name, string phoneNumber, bool isPyszne, decimal? minOrderCost, decimal? deliveryCost, decimal? maxPaidOrderValue)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            IsPyszne = isPyszne;
            MinOrderCost = minOrderCost;
            DeliveryCost = deliveryCost;
            MaxPaidOrderValue = maxPaidOrderValue;
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
