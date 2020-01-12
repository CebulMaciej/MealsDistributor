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

        public OrderPositionApiModel ConvertOrderPosition(OrderPosition orderPosition)
        {
            if (orderPosition == null) return null;
            return new OrderPositionApiModel
            {
                Id = orderPosition.Id,
                MealId = orderPosition.MealId,
                CreationDate = orderPosition.CreationDate,
                UserId = orderPosition.UserId,
                OrderId = orderPosition.OrderId
            };
        }

        public OrderPropositionApiModel ConvertOrderProposition(OrderProposition orderProposition)
        {
            if (orderProposition == null) return null;
            return new OrderPropositionApiModel
            {
                Id = orderProposition.Id,
                CreationDate = orderProposition.CreationDate,
                CreatorID = orderProposition.CreatorID,
                RestaurantId = orderProposition.RestaurantId,
                TimeToOrdering = orderProposition.TimeToOrdering,
                OrderingStopped = orderProposition.OrderingStopped
            };
        }

        public OrderApiModel ConvertOrder(Order order)
        {
            if (order == null) return null;
            return new OrderApiModel
            {
                Id = order.Id,
                CreationDate = order.CreationDate,
                RestaurantId = order.RestaurantId,
                IsOrdered = order.IsOrdered,
                OrderBoyId = order.OrderBoyId
            };
        }

        public OrderPropositionPositionApiModel ConvertOrderPropositionPosition(OrderPropositionPosition orderPropositionPosition)
        {
            if (orderPropositionPosition == null) return null;
            return new OrderPropositionPositionApiModel
            {
                Id = orderPropositionPosition.Id,
                OrderPropositionId = orderPropositionPosition.OrderPropositionId,
                CreationDate = orderPropositionPosition.CreationDate,
                MealId = orderPropositionPosition.MealId,
                UserId = orderPropositionPosition.UserId
            };
        }

        public RestaurantApiModel ConvertRestaurant(Restaurant restaurant)
        {
            if (restaurant == null) return null;
            return new RestaurantApiModel
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                MaxPaidOrderValue = restaurant.MaxPaidOrderValue,
                DeliveryCost = restaurant.DeliveryCost,
                IsPyszne = restaurant.IsPyszne,
                PhoneNumber = restaurant.PhoneNumber,
                MinOrderConst = restaurant.MinOrderCost
            };
        }
    }
}
