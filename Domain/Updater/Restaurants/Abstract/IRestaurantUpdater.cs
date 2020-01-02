using System.Threading.Tasks;
using Domain.Updater.Restaurants.Request.Abstract;
using Domain.Updater.Restaurants.Response.Abstract;

namespace Domain.Updater.Restaurants.Abstract
{
    public interface IRestaurantUpdater
    {
        Task<IRestaurantUpdateResponse> UpdateRestaurant(IRestaurantUpdateRequest request);
    }
}
