using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.BusinessObject;
using Domain.Infrastructure.Config.Objects;
using MealsDistributor.Infrastructure.ObjectsToModelConverting.Abstract;
using MealsDistributor.Model.ApiModels;

namespace MealsDistributor.Infrastructure.ObjectsToModelConverting.Concrete
{
    public class ObjectToApiModelConverter : IObjectToApiModelConverter
    {
        public UserApiModel ConvertUser(User user)
        {
            if (user == null)
            {
                throw new InvalidOperationException("Cannot convert empty object");
            }

            return new UserApiModel
            {
                Email = user.Email,
                Id = user.Id,
                CreationDate = user.CreationDate,
                Role = (int) user.Role 
            };
        }

        public ConfigurationApiModel ConvertConfiguration(ConfigurationObject configurationObject)
        {
            if (configurationObject == null) return null;
            return new ConfigurationApiModel
            {
                Key = configurationObject.Key,
                Value = configurationObject.Value
            };
        }

        public MealApiModel ConvertMeal(Meal meal)
        {
            if (meal == null) return null;
            return new MealApiModel
            {
                Id = meal.Id,
                RestaurantId = meal.RestaurantId,
                Description = meal.Description,
                EndDate = meal.EndDate,
                Name = meal.Name ,
                Price = meal.Price ,
                StartDate = meal.StartDate 
            };
        }
    }
}
