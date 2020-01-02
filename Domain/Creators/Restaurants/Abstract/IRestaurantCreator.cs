using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Creators.Restaurants.Request.Abstract;
using Domain.Creators.Restaurants.Response.Abstract;

namespace Domain.Creators.Restaurants.Abstract
{
    public interface IRestaurantCreator
    {
        Task<ICreateRestaurantResponse> CreateRestaurant(ICreateRestaurantRequest request);
    }
}
