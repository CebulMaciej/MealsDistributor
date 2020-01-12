using System;

namespace Domain.Updater.Meals.Request.Abstract
{
    public interface IUpdateMealRequest
    {
        Guid Id { get; }
        string Name { get; }
        string Description { get; }
        decimal Price { get; }
        DateTime? StartDate { get; }
        DateTime? EndDate { get; }
    }
}
