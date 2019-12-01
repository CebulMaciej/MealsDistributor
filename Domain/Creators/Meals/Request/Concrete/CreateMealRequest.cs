using System;
using System.Collections.Generic;
using System.Text;
using Domain.Creators.Meals.Request.Abstract;

namespace Domain.Creators.Meals.Request.Concrete
{
    public class CreateMealRequest : ICreateMealRequest
    {
        public CreateMealRequest(string name, string description, decimal price, DateTime? startDate, DateTime? endDate, Guid restaurantId)
        {
            Name = name;
            Description = description;
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
            RestaurantId = restaurantId;
        }

        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }
        public Guid RestaurantId { get; }
    }
}
