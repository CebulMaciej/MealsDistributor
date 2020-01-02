using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Remover.Restaurants.Request.Abstract
{
    public interface IRestaurantRemoveRequest
    {
        Guid Id { get; }
    }
}
