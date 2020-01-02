using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Remover.Restaurants.Request.Abstract;
using Domain.Remover.Restaurants.Response.Abstract;

namespace Domain.Remover.Restaurants.Abstract
{
    public interface IRestaurantRemover
    {
        Task<IRestaurantRemoveResponse> RemoveRestaurant(IRestaurantRemoveRequest request);
    }
}
