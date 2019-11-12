using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.BusinessObject
{
    public class Meal
    {
        public Meal(Guid id, string name, string description, decimal price, DateTime? startDate, DateTime? endDate, Guid restaurantId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
            RestaurantId = restaurantId;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }
        public Guid RestaurantId { get; }
    }
}
