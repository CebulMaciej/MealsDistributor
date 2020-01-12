using System;
using Domain.Updater.Meals.Request.Abstract;

namespace Domain.Updater.Meals.Request.Concrete
{
    public class UpdateMealRequest : IUpdateMealRequest
    {
        public UpdateMealRequest(Guid id, string name, string description, decimal price, DateTime? startDate, DateTime? endDate)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public DateTime? StartDate { get; }
        public DateTime? EndDate { get; }
    }
}
