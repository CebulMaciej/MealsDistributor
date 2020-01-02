using System;
using System.Collections.Generic;
using System.Text;
using Domain.Remover.Restaurants.Request.Abstract;

namespace Domain.Remover.Restaurants.Request.Concrete
{
    public class RestaurantRemoveRequest : IRestaurantRemoveRequest
    {
        public RestaurantRemoveRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
