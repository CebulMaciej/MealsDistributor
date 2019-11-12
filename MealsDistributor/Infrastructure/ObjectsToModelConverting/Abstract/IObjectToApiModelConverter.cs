using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.BusinessObject;
using MealsDistributor.Model.ApiModels;

namespace MealsDistributor.Infrastructure.ObjectsToModelConverting.Abstract
{
    public interface IObjectToApiModelConverter
    {
        UserApiModel ConvertUser(User user);
    }
}
