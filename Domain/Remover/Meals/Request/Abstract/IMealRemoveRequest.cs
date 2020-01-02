using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Remover.Meals.Request.Abstract
{
    public interface IMealRemoveRequest
    {
        Guid MealId { get; }
    }
}
