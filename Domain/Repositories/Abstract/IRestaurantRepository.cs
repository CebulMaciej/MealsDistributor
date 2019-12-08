using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.BusinessObject;

namespace Domain.Repositories.Abstract
{
    public interface IRestaurantRepository
    {
        Task<Restaurant> CreateRestaurant(string name, string phoneNumber, bool isPyszne, decimal? minOrderCost,
            decimal? deliveryCost, decimal? maxPaidOrderValue);
        Task<Restaurant> EditRestaurant(Guid id, string name, string phoneNumber, bool isPyszne, decimal? minOrderCost, decimal? deliveryCost, decimal? maxPaidOrderValue);
        Task<Restaurant> GetRestaurant(Guid id);
        Task<IList<Restaurant>> GetRestaurants();
        Task RemoveRestaurant(Guid id);
    }
}
