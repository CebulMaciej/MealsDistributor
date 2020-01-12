using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Infrastructure.Config.Objects;
using MealsDistributor.Model.ApiModels;

namespace MealsDistributor.Infrastructure.ObjectsToModelConverting.Abstract
{
    public interface IObjectToApiModelConverter
    {
        UserApiModel ConvertUser(User user);
        ConfigurationApiModel ConvertConfiguration(ConfigurationObject configurationObject);
        MealApiModel ConvertMeal(Meal meal);
        OrderPositionApiModel ConvertOrderPosition(OrderPosition orderPosition);
        OrderPropositionApiModel ConvertOrderProposition(OrderProposition orderProposition);
        OrderApiModel ConvertOrder(Order order);

        OrderPropositionPositionApiModel ConvertOrderPropositionPosition(OrderPropositionPosition orderPropositionPosition);
        RestaurantApiModel ConvertRestaurant(Restaurant restaurant);
    }
}
