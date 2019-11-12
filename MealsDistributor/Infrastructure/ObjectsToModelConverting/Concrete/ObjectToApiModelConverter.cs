using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.BusinessObject;
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
    }
}
